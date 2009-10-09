// Copyright 2009, Frank Laub
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
using DotWeb.Client.Dom.Css;
using System.DotWeb;

namespace DotWeb.Client.Dom.Html
{
	/// <summary>
	/// <para>
	/// All HTML element interfaces derive from this class. 
	/// Elements that only expose the HTML core attributes are represented by the base HTMLElement interface. 
	/// </para>
	/// These elements are as follows:
	/// <list type="">
	/// <item>special: SUB, SUP, SPAN, BDO</item>
	/// <item>font: TT, I, B, U, S, STRIKE, BIG, SMALL</item>
	/// <item>phrase: EM, STRONG, DFN, CODE, SAMP, KBD, VAR, CITE, ACRONYM, ABBR</item>
	/// <item>list: DD, DT</item>
	/// <item>NOFRAMES, NOSCRIPT</item>
	/// <item>ADDRESS, CENTER</item>
	/// </list>
	/// <remarks>
	/// Note: The style attribute of an HTML element is accessible through the 
	/// ElementCSSInlineStyle interface which is defined in the CSS module [DOM Level 2 Style Sheets and CSS] .
	/// </remarks>
	/// </summary>
	[JsIntrinsic]
	public interface HtmlElement : Element
	{
		string id { get; set; }
		string title { get; set; }
		string lang { get; set; }
		string dir { get; set; }
		string className { get; set; }
		Style style { get; set; }

		MouseEventHandler onclick { get; set; }
		MouseEventHandler onmouseover { get; set; }
		MouseEventHandler onmouseout { get; set; }
		GenericEventHandler onblur { get; set; }
	}
}