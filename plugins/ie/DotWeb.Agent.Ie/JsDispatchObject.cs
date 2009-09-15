// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.Expando;
using System.Reflection;
using System.Runtime.InteropServices;
using ComDISPPARAMS = System.Runtime.InteropServices.ComTypes.DISPPARAMS;
using ComEXCEPINFO = System.Runtime.InteropServices.ComTypes.EXCEPINFO;
using System.Diagnostics;
using DotWeb.Agent.Ie.Interop;
using DotWeb.Hosting;

namespace DotWeb.Agent.Ie
{
	class TypeMemberEntry
	{
		public int DispId { get; set; }
		public string Name { get; set; }
		public DispatchType DispatchType { get; set; }
	}

	[ClassInterface(ClassInterfaceType.None)]
	class JsDispatchObject : DispatchImpl
	{
		private int targetId;
		private JsAgent agent;
		private Dictionary<string, TypeMemberEntry> infoByName = new Dictionary<string, TypeMemberEntry>();
		private Dictionary<int, TypeMemberEntry> infoById = new Dictionary<int, TypeMemberEntry>();
		private int indexerLength = -1;
		private int lastDispId = 0;

		public JsDispatchObject(JsAgent agent, int targetId) {
			this.agent = agent;
			this.targetId = targetId;
		}

		#region IDispatchImpl Members

		public override DispatchResult Invoke(
			int dispId, 
			uint lcid, 
			DispatchFlags wFlags, 
			object[] args, 
			out ComEXCEPINFO pExcepInfo, 
			out uint puArgErr,
			out object ret) {
			pExcepInfo = new ComEXCEPINFO();
			puArgErr = 0;

			DispatchType dispType = (DispatchType)wFlags;
//			if (dispId == 0) {
//				if (dispType.IsPropertyGet()) {
//					return this.target.ToString();
//				}
//				ret = null;
//				return DispatchResult.MemberNotFound;
//			}

//			if (dispType.IsPropertyGet()) {
//				JsMethodAdapter adapter = new JsMethodAdapter(this.target, dispId);
//				return adapter.IDispatch;
//			}

			var member = GetMemberById(dispId);
			if(member == null) {
				ret = null;
				return DispatchResult.MemberNotFound;
			}

			Debug.WriteLine(string.Format("JsDispatchObject.Invoke({0}, {1}, {2})",
				this.targetId,
				dispType,
				member.Name
			));

			//if ((member.DispatchType & dispType) == 0) {
			//    ret = null;
			//    return DispatchResult.MemberNotFound;
			//}

			DispatchIdentifier id = new DispatchIdentifier(member.Name);
			ret = this.agent.InvokeRemoteMember(this.targetId, id, dispType, args);
			return DispatchResult.Ok;
		}

		public override DispatchResult GetDispID(string name, GetDispIdFlags flags, out int id) {
			Debug.WriteLine(string.Format("JsDispatchObject.GetDispID({0}, {1})", this.targetId, name));

			var member = GetMemberByName(name);
			if (member == null) {
				if ((flags & GetDispIdFlags.Ensure) != 0) {
					member = new TypeMemberEntry {
						DispId = this.lastDispId++,
						Name = name,
						DispatchType = DispatchType.PropertyGet | DispatchType.PropertySet
					};
					this.infoByName.Add(member.Name, member);
					this.infoById.Add(member.DispId, member);
				}
				else {
					id = DispId.Unknown;
					return DispatchResult.UnknownName;
				}
			}

			id = member.DispId;
			return DispatchResult.Ok;
		}

		public override uint GetMemberProperties(int id, GetMemberPropertiesFlags flags) {
			var member = GetMemberById(id);
			if (member == null)
				return 0;

			GetMemberPropertiesFlags ret = 0;
			if ((member.DispatchType & DispatchType.Method) != 0)
				ret |= GetMemberPropertiesFlags.CanCall;
			if ((member.DispatchType & DispatchType.PropertyGet) != 0)
				ret |= GetMemberPropertiesFlags.CanGet;
			if ((member.DispatchType & DispatchType.PropertySet) != 0)
				ret |= GetMemberPropertiesFlags.CanPut;
			return (uint)ret;
		}

		public override DispatchResult GetNextDispID(GetNextDispIdFlags grfdex, int id, out int nextId) {
			Debug.WriteLine(string.Format("JsDispatchObject.GetNextDispID({0}, {1})", this.targetId, id));

			GetTypeInfo();

			if (!this.infoById.Any()) {
				nextId = DispId.Unknown;
				return DispatchResult.False;
			}

			if (id == -1 || id == DispId.NewEnum) {
				nextId = 0;
			}
			else {
				nextId = id + 1;
			}

			if (nextId < this.infoById.Count)
				return DispatchResult.Ok;
			return DispatchResult.False;
		}

		public override DispatchResult GetMemberName(int id, out string name) {
			Debug.WriteLine(string.Format("JsDispatchObject.GetMemberName({0}, {1})", this.targetId, id));
			var member = GetMemberById(id);
			if (member == null) {
				name = null;
				return DispatchResult.MemberNotFound;
			}

			name = member.Name;
			return DispatchResult.Ok;
		}

		#endregion

		private TypeMemberEntry GetMemberById(int id) {
			GetTypeInfo();

			TypeMemberEntry member;
			if (!this.infoById.TryGetValue(id, out member)) {
				return GetElementEntry(id);
			}

			return member;
		}

		private TypeMemberEntry GetMemberByName(string name) {
			GetTypeInfo();

			TypeMemberEntry member;
			if (!this.infoByName.TryGetValue(name, out member)) {
				int index;
				if (int.TryParse(name, out index)) {
					return GetElementEntry(index);
				}
				return null;
			}

			return member;
		}

		private TypeMemberEntry GetElementEntry(int id) {
			if (this.indexerLength >= 0 && id < this.indexerLength) {
				return new TypeMemberEntry {
					DispatchType = DispatchType.PropertyGet | DispatchType.PropertySet,
					DispId = id,
					Name = id.ToString()
				};
			}
			return null;
		}

		private void GetTypeInfo() {
			GetTypeResponseMessage msg = this.agent.GetRemoteTypeInfo(this.targetId);
			if (msg == null)
				return;

			this.indexerLength = msg.IndexerLength;
			foreach (TypeMemberInfo item in msg.Members) {
				if (!this.infoByName.ContainsKey(item.Name)) {
					int id = this.lastDispId++;
					var member = new TypeMemberEntry {
						DispatchType = item.DispatchType,
						Name = item.Name,
						DispId = id
					};
					this.infoByName.Add(member.Name, member);
					this.infoById.Add(member.DispId, member);
				}
			}
		}

	}
}
