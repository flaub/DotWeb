namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCompanyAttribute : Attribute
	{
		public AssemblyCompanyAttribute(string value) { }
	}
}