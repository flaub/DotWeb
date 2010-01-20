// Copyright 2010, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 
using DotWeb.Client.Dom.Html;
using System.DotWeb;

namespace DotWeb.Client.Dom.Helper
{
	public static class ElementFactory
	{
		[JsMacro("$doc.createTextNode({1})")]
		public static extern Text CreateText(string text);

		[JsMacro("$doc.createElement('a')")]
		public static extern AnchorElement CreateAnchor();

		[JsMacro("$doc.createElement('div')")]
		public static extern HtmlDivElement CreateDiv();

		[JsMacro("$doc.createElement('br')")]
		public static extern HtmlBrElement CreateBreak();

		[JsMacro("$doc.createElement('p')")]
		public static extern HtmlParagraphElement CreateParagraph();

		[JsMacro("$doc.createElement('li')")]
		public static extern HtmlLiElement CreateListItem();
	}
}
