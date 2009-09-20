namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyDescriptionAttribute : Attribute
	{
		public AssemblyDescriptionAttribute(string value) { }
	}
}