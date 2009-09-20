namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyProductAttribute : Attribute
	{
		public AssemblyProductAttribute(string value) { }
	}
}