namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCultureAttribute : Attribute
	{
		public AssemblyCultureAttribute(string value) { }
	}
}