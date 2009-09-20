namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	public class AssemblyCopyrightAttribute : Attribute
	{
		public AssemblyCopyrightAttribute(string value) { }
	}
}