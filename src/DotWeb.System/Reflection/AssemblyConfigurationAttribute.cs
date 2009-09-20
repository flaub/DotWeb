namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyConfigurationAttribute : Attribute
	{
		public AssemblyConfigurationAttribute(string value) { }
	}
}