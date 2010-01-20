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
// 

using SysException = System.Exception;

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	public class Exception
	{
		public Exception() {
		}

		public Exception(string message) {
			Message = message;
		}
		//		protected Exception(SerializationInfo info, StreamingContext context);
		public Exception(string message, Exception innerException) {
			Message = message;
			InnerException = innerException;
		}

		//		public virtual IDictionary Data { get; }
		//		public virtual string HelpLink { get; set; }
		//		protected int HResult { get; set; }
		public Exception InnerException { get; protected set; }

		public virtual string Message { get; protected set; }
		public virtual string Source { get; set; }
		public virtual string StackTrace { get; protected set; }

		//		public MethodBase TargetSite { get; }
		//		public virtual Exception GetBaseException();
		//		public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		//		public Type GetType();
		//		public override string ToString();
	}

	[UseSystem]
	public class SystemException : SysException
	{
		public SystemException() { }
		public SystemException(string message) : base(message) { }
		public SystemException(string message, SysException innerException) : base(message, innerException) { }
	}

	[UseSystem]
	public class NotImplementedException : SystemException
	{
		public NotImplementedException() { }
		public NotImplementedException(string message) : base(message) { }
		public NotImplementedException(string message, SysException inner) : base(message, inner) { }
	}

	[UseSystem]
	public class NotSupportedException : SystemException
	{
		public NotSupportedException() { }
		public NotSupportedException(string message) : base(message) { }
		public NotSupportedException(string message, SysException inner) : base(message, inner) { }
	}
}
