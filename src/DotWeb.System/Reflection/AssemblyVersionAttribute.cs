namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyVersionAttribute : Attribute
	{
		public AssemblyVersionAttribute(string value) { }
	}
}