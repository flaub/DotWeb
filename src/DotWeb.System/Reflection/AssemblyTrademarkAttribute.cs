namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyTrademarkAttribute : Attribute
	{
		public AssemblyTrademarkAttribute(string value) { }
	}
}