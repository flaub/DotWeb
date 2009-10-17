using System;
namespace DotWeb.Hosting
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

	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	public class AssemblyWeavedAttribute : Attribute
	{
	}
}
