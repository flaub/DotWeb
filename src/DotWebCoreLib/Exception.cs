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

using System.Text;
namespace System
{
	public class Exception
	{
		private string message;

		public Exception() {
		}

		public Exception(string message) {
			Message = message;
		}

		public Exception(string message, Exception innerException) {
			Message = message;
			InnerException = innerException;
		}

		public Exception InnerException { get; protected set; }
		public virtual string Source { get; set; }
		public virtual string StackTrace { get; protected set; }

		public virtual string Message {
			get {
				if (message == null) {
					message = string.Format("Exception of type '{0}' was thrown.", this.GetTypeName());
				}
				return message;
			}
			protected set { this.message = value; }
		}

		public override string ToString() {
			var result = new StringBuilder();
			result.Append(this.GetTypeName());
			result.Append(": ").Append(Message);

			//if (null != _remoteStackTraceString)
			//    result.Append(_remoteStackTraceString);

			if (InnerException != null) {
				result.Append(" ---> ").Append(InnerException.ToString());
				//result.Append(Environment.NewLine);
				result.AppendLine();
				result.Append("  --- End of inner exception stack trace ---");
			}

			//if (StackTrace != null)
			//    result.Append(Environment.NewLine).Append(StackTrace);
			return result.ToString();
		}
	}

	public class SystemException : Exception
	{
		public SystemException() : base("A system exception has occurred.") { }
		public SystemException(string message) : base(message) { }
		public SystemException(string message, Exception innerException) : base(message, innerException) { }
	}

	public class NotImplementedException : SystemException
	{
		public NotImplementedException() : base("The requested feature is not implemented.") { }
		public NotImplementedException(string message) : base(message) { }
		public NotImplementedException(string message, Exception inner) : base(message, inner) { }
	}

	public class NotSupportedException : SystemException
	{
		public NotSupportedException() : base("Operation is not supported.") { }
		public NotSupportedException(string message) : base(message) { }
		public NotSupportedException(string message, Exception inner) : base(message, inner) { }
	}

	public class ArgumentException : SystemException
	{
		public ArgumentException() : base("Value does not fall within the expected range.") { }
		public ArgumentException(string message) : base(message) { }
		public ArgumentException(string message, Exception inner) : base(message, inner) { }

		public ArgumentException(string message, string paramName)
			: base(message) {
			this.ParamName = paramName;
		}

		public ArgumentException(string message, string paramName, Exception innerException)
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

	public class ArgumentNullException : ArgumentException
	{
		public ArgumentNullException() : base(DefaultMessage) { }
		public ArgumentNullException(string paramName) : base(DefaultMessage, paramName) { }
		public ArgumentNullException(string message, Exception inner) : base(message, inner) { }
		public ArgumentNullException(string paramName, string message) : base(message, paramName) { }

		private static string DefaultMessage = "Value cannot be null.";
	}

	public class ArgumentOutOfRangeException : ArgumentException
	{
		public ArgumentOutOfRangeException() : base(RangeMessage) { }
		public ArgumentOutOfRangeException(string paramName) : base(RangeMessage, paramName) { }
		public ArgumentOutOfRangeException(string message, Exception inner) : base(message, inner) { }
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

		private static string RangeMessage = "Specified argument was out of the range of valid values.";
	}

	public class InvalidOperationException : SystemException
	{
		public InvalidOperationException()
			: base("Operation is not valid due to the current state of the object.") {
		}
		public InvalidOperationException(string message) : base(message) { }
		public InvalidOperationException(string message, Exception innerException) : base(message, innerException) { }
 	}

	public sealed class IndexOutOfRangeException : SystemException
	{
		public IndexOutOfRangeException() : base("Array index is out of range.") { }
		public IndexOutOfRangeException(string message) : base(message) { }
		public IndexOutOfRangeException(string message, Exception innerException) : base(message, innerException) { }
	}

	public class FormatException : SystemException
	{
		public FormatException() : base("Invalid format.") { }
		public FormatException(string message) : base(message) { }
		public FormatException(string message, Exception innerException) : base(message, innerException) { }
	}
}
