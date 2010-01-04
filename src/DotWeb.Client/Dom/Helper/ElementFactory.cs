using DotWeb.Client.Dom.Html;
using System.DotWeb;

namespace DotWeb.Client.Dom.Helper
{
	public static class ElementFactory
	{
		[JsCode("return $doc.createTextNode(text);")]
		public static extern Text CreateText(string text);

		[JsCode("return $doc.createElement('a');")]
		public static extern HtmlAnchorElement CreateAnchor();

		[JsCode("return $doc.createElement('div');")]
		public static extern HtmlDivElement CreateDiv();

		[JsCode("return $doc.createElement('br');")]
		public static extern HtmlBrElement CreateBreak();

		[JsCode("return $doc.createElement('p');")]
		public static extern HtmlParagraphElement CreateParagraph();
	}
}
