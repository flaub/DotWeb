namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyTitleAttribute : Attribute
	{
		public AssemblyTitleAttribute(string value) { }
	}
}