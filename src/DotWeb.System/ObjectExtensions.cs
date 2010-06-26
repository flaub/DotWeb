namespace System
{
	public static class ObjectExtensions
	{
#if HOSTED_MODE
		public static string GetTypeName(this object obj) {
			var type = obj.GetType();
			var name = type.FullName;
			if (name.StartsWith("DotWeb.System")) {
				name = name.Substring("DotWeb.".Length);
			}
			return name;
		}
#else
		[JsMacro("{1}.$typename")]
		public static extern string GetTypeName(this object obj);
#endif
	}
}
