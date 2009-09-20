namespace System.Runtime.InteropServices
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class ComVisibleAttribute : Attribute
	{
		public ComVisibleAttribute(bool value) { }
	}
}