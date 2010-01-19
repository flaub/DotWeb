using DotWeb.Client.Dom.Html;
using System.DotWeb;

namespace DotWeb.Client.Dom.Helper
{
	public static class ElementFactory
	{
		[JsMacro("$doc.createTextNode({0})")]
		public static extern Text CreateText(string text);

		[JsMacro("$doc.createElement('a')")]
		public static extern AnchorElement CreateAnchor();

		[JsMacro("$doc.createElement('div')")]
		public static extern HtmlDivElement CreateDiv();

		[JsMacro("$doc.createElement('br')")]
		public static extern HtmlBrElement CreateBreak();

		[JsMacro("$doc.createElement('p')")]
		public static extern HtmlParagraphElement CreateParagraph();
	}
}
