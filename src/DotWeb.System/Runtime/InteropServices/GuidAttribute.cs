namespace System.Runtime.InteropServices
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class GuidAttribute : Attribute
	{
		public GuidAttribute(string value) { }
	}
}