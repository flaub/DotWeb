#if HOSTED_MODE
namespace DotWeb.System.DotWeb
#else
namespace System.DotWeb
#endif
{
	public class JsDynamic
	{
		public extern object this[string name] {
			[JsCode("return this[name];")]
			get;

			[JsCode("this[name] = value;")]
			set;
		}
	}
}
