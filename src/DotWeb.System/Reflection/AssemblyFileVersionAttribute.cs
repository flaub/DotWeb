namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyFileVersionAttribute : Attribute
	{
		public AssemblyFileVersionAttribute(string value) { }
	}
}