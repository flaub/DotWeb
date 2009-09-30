
namespace DotWeb.Client.System
{
	[JsNamespace("System")]
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

	[JsNamespace("System")]
	public class SystemException : Exception
	{
		public SystemException() { }
		public SystemException(string message) : base(message) { }
		public SystemException(string message, Exception innerException) : base(message, innerException) { }
	}

	[JsNamespace("System")]
	public class NotImplementedException : SystemException
	{
		public NotImplementedException() { }
		public NotImplementedException(string message) : base(message) { }
		public NotImplementedException(string message, Exception inner) : base(message, inner) { }
	}

	[JsNamespace("System")]
	public class NotSupportedException : SystemException
	{
		public NotSupportedException() { }
		public NotSupportedException(string message) : base(message) { }
		public NotSupportedException(string message, Exception inner) : base(message, inner) { }
	}
}
