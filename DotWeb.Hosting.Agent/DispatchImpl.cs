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
using DotWeb.Agent.Ie.Interop;
using System.Runtime.InteropServices;

namespace DotWeb.Agent.Ie
{
	[Flags]
	enum GetDispIdFlags : byte
	{
		CaseSensitive = 0x00000001,
		Ensure = 0x00000002,
		Implicit = 0x00000004,
		CaseInsensitive = 0x00000008,
		Internal = 0x00000010,
		NoDynamicProperties = 0x00000020,
	}

	[Flags]
	enum MemberProperties : short
	{
		CanGet = 0x00000001,
		CannotGet = 0x00000002,
		CanPut = 0x00000004,
		CannotPut = 0x00000008,
		CanPutRef = 0x00000010,
		CannotPutRef = 0x00000020,
		NoSideEffects = 0x00000040,
		DynamicType = 0x00000080,
		CanCall = 0x00000100,
		CannotCall = 0x00000200,
		CanConstruct = 0x00000400,
		CannotConstruct = 0x00000800,
		CanSourceEvents = 0x00001000,
		CannotSourceEvents = 0x00002000,

		CanAll =
			   (CanGet | CanPut | CanPutRef |
				CanCall | CanConstruct | CanSourceEvents),
		CannotAll =
			   (CannotGet | CannotPut | CannotPutRef |
				CannotCall | CannotConstruct | CannotSourceEvents),
		ExtraAll =
			   (NoSideEffects | DynamicType),
		All =
			   (CanAll | CannotAll | ExtraAll)
	}


	[ClassInterface(ClassInterfaceType.None)]
	class DispatchImpl : IDispatchImpl
	{
		public DispatchImpl() {
			this.IDispatch = DispatchInterceptor.Create(this);
		}

		public object IDispatch { get; private set; }

		#region IDispatchImpl Members

		public virtual DispatchResult GetDispID(string name, uint flags, out int id) {
			id = DispId.Unknown;
			return DispatchResult.UnknownName;
		}

		public virtual DispatchResult GetIDsOfNames(string[] names, uint lcid, out int[] dispIds) {
			int id;
			DispatchResult hr = GetDispID(names.First(), 0, out id);
			if (hr == DispatchResult.Ok) {
				dispIds = new int[1];
				dispIds[0] = id;
			}
			else {
				dispIds = null;
			}
			return hr;
		}

		public virtual uint GetMemberProperties(int id, uint flags) {
			return 0;
		}

		public virtual DispatchResult GetNextDispID(GetNextDispIdFlags grfdex, int id, out int nextId) {
			nextId = 0;
			return DispatchResult.NotImpl;
		}

		public virtual System.Runtime.InteropServices.ComTypes.ITypeInfo GetTypeInfo(uint iTInfo, uint lcid) {
			throw new NotImplementedException();
		}

		public virtual uint GetTypeInfoCount() {
			throw new NotImplementedException();
		}

		public virtual DispatchResult Invoke(int id, uint lcid, ushort wFlags, object[] args, out System.Runtime.InteropServices.ComTypes.EXCEPINFO pExcepInfo, out uint puArgErr, out object ret) {
			pExcepInfo = new System.Runtime.InteropServices.ComTypes.EXCEPINFO();
			puArgErr = 0;
			ret = null;
			return DispatchResult.NotImpl;
		}

		public virtual DispatchResult GetMemberName(int id, out string name) {
			name = null;
			return DispatchResult.NotImpl;
		}

		#endregion
	}
}
