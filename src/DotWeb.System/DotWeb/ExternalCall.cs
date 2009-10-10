#if HOSTED_MODE
namespace System.DotWeb
{
	public interface IDotWebHost
	{
		object Invoke(object scope, object method, object[] args);
		T Cast<T>(object obj);
	}

	public static class HostedMode
	{
		public static IDotWebHost Host { get; set; }
	}
}
#endif
