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
		public SystemException() : base("System error.") { }
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

	[UseSystem]
	public class ArgumentException : SystemException
	{
		public ArgumentException() : base("Value does not fall within the expected range.") { }
		public ArgumentException(string message) : base(message) { }
		public ArgumentException(string message, SysException inner) : base(message, inner) { }

		public ArgumentException(string message, string paramName)
			: base(message) {
			this.ParamName = paramName;
		}

		public ArgumentException(string message, string paramName, SysException innerException)
			: base(message, innerException) {
		}

		public override string Message {
			get {
				string message = base.Message;
				if ((this.ParamName != null) && (this.ParamName.Length != 0)) {
					return message + "\n" + "Parameter name: " + this.ParamName;
					//message + Environment.NewLine + string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_ParamName_Name"), new object[] { this.m_paramName })
				}
				return message;
			}
		}

		public virtual string ParamName { get; private set; }
	}

	[UseSystem]
	public class ArgumentNullException : ArgumentException
	{
		public ArgumentNullException() : base(DefaultMessage) { }
		public ArgumentNullException(string paramName) : base(DefaultMessage, paramName) { }
		public ArgumentNullException(string message, SysException inner) : base(message, inner) { }
		public ArgumentNullException(string paramName, string message) : base(message, paramName) { }

		private static string DefaultMessage = "Value cannot be null.";
	}

	[UseSystem]
	public class ArgumentOutOfRangeException : ArgumentException
	{
		public ArgumentOutOfRangeException() : base(RangeMessage) { }
		public ArgumentOutOfRangeException(string paramName) : base(RangeMessage, paramName) { }
		public ArgumentOutOfRangeException(string message, SysException inner) : base(message, inner) { }
		public ArgumentOutOfRangeException(string paramName, string message) : base(message, paramName) { }

		public ArgumentOutOfRangeException(string paramName, object actualValue, string message)
			: base(message, paramName) {
			this.ActualValue = actualValue;
		}

		public virtual object ActualValue { get; private set; }

		public override string Message {
			get {
				string message = base.Message;
				if (this.ActualValue == null) {
					return message;
				}
				string str2 = "Actual value was " + this.ActualValue.ToString();
				if (message == null) {
					return str2;
				}
				return message + "\n" + str2;
			}
		}

		private static string RangeMessage {
			get { return "Specified argument was out of the range of valid values."; }
		}
	}

	[UseSystem]
	public class InvalidOperationException : SystemException
	{
		public InvalidOperationException()
			: base("Operation is not valid due to the current state of the object.") {
		}
		public InvalidOperationException(string message) : base(message) { }
		public InvalidOperationException(string message, SysException innerException) : base(message, innerException) { }
 	}
}
