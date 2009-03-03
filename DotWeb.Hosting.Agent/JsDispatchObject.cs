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
	[ClassInterface(ClassInterfaceType.None)]
	class JsDispatchObject : DispatchImpl
	{
		private int targetId;
		private JsAgent agent;
		private Dictionary<string, TypeMemberInfo> infoByName;
		private Dictionary<int, TypeMemberInfo> infoById;
		private int indexerLength = -1;

		public JsDispatchObject(JsAgent agent, int targetId) {
			this.agent = agent;
			this.targetId = targetId;
		}

		private TypeMemberInfo GetInfo(int id) {
			if (this.infoById == null)
				GetTypeInfo();
	
			TypeMemberInfo info;
			if (!this.infoById.TryGetValue(id, out info)) {
				if (this.indexerLength >= 0 && id < this.indexerLength) {
					return new TypeMemberInfo {
						DispatchType = DispatchType.PropertyGet | DispatchType.PropertySet,
						MemberId = id,
						Name = id.ToString()
					};
				}
				return null;
			}

			return info;
		}

		private TypeMemberInfo GetInfo(string name) {
			if (this.infoByName == null)
				GetTypeInfo();

			TypeMemberInfo info;
			if (!this.infoByName.TryGetValue(name, out info)) {
				int index;
				if (int.TryParse(name, out index)) {
					if (this.indexerLength >= 0 && index < this.indexerLength) {
						return new TypeMemberInfo {
							DispatchType = DispatchType.PropertyGet | DispatchType.PropertySet,
							MemberId = index,
							Name = name
						};
					}
				}
				return null;
			}

			return info;
		}

		private void GetTypeInfo() {
			infoByName = new Dictionary<string, TypeMemberInfo>();
			infoById = new Dictionary<int, TypeMemberInfo>();

			GetTypeResponseMessage msg = this.agent.GetRemoteTypeInfo(this.targetId);
			if (msg == null)
				return;

			this.indexerLength = msg.IndexerLength;
			foreach (TypeMemberInfo item in msg.Members) {
				this.infoById.Add(item.MemberId, item);
				this.infoByName.Add(item.Name, item);
			}
		}

		#region IDispatchImpl Members

		public override DispatchResult Invoke(
			int dispId, 
			uint lcid, 
			ushort wFlags, 
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

			TypeMemberInfo info = GetInfo(dispId);
			if(info == null) {
				ret = null;
				return DispatchResult.MemberNotFound;
			}

			Debug.WriteLine(string.Format("JsDispatchObject.Invoke({0}, {1}, {2})",
				this.targetId,
				dispType,
				info.Name
			));

			if ((info.DispatchType & dispType) == 0) {
				ret = null;
				return DispatchResult.MemberNotFound;
			}

			ret = this.agent.InvokeRemoteMember(this.targetId, dispId, dispType, args);
			return DispatchResult.Ok;
		}

		public override DispatchResult GetDispID(string name, uint flags, out int id) {
			Debug.WriteLine(string.Format("JsDispatchObject.GetDispID({0}, {1})", this.targetId, name));

			TypeMemberInfo info = GetInfo(name);
			if (info == null) {
				id = DispId.Unknown;
				return DispatchResult.UnknownName;
			}

			id = info.MemberId;
			return DispatchResult.Ok;
		}

		public override uint GetMemberProperties(int id, uint flags) {
			TypeMemberInfo info = GetInfo(id);
			if (info == null)
				return 0;

			MemberProperties ret = 0;
			if ((info.DispatchType & DispatchType.Method) != 0)
				ret |= MemberProperties.CanCall;
			if ((info.DispatchType & DispatchType.PropertyGet) != 0)
				ret |= MemberProperties.CanGet;
			if ((info.DispatchType & DispatchType.PropertySet) != 0)
				ret |= MemberProperties.CanPut;
			return (uint)ret;
		}

		public override DispatchResult GetNextDispID(GetNextDispIdFlags grfdex, int id, out int nextId) {
			Debug.WriteLine(string.Format("JsDispatchObject.GetNextDispID({0}, {1})", this.targetId, id));

			if (this.infoById == null)
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
			TypeMemberInfo info = GetInfo(id);
			if (info == null) {
				name = null;
				return DispatchResult.MemberNotFound;
			}

			name = info.Name;
			return DispatchResult.Ok;
		}

		#endregion
	}
}
