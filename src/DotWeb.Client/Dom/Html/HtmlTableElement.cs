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
using System;
namespace DotWeb.Client.Dom.Html
{
	[JsIntrinsic]
	public class HtmlTableElement : HtmlElement
	{
		public extern HtmlTableCaptionElement caption { get; set; }
		public extern HtmlTableSectionElement tHead { get; set; }
		public extern HtmlTableSectionElement tFoot { get; set; }

		public extern HtmlCollection<HtmlTableRowElement> rows { get; }
		public extern HtmlCollection<HtmlTableSectionElement> tBodies { get; }

		public extern string align { get; set; }
		public extern string bgColor { get; set; }
		public extern string border { get; set; }
		public extern string cellPadding { get; set; }
		public extern string cellSpacing { get; set; }
		public extern string frame { get; set; }
		public extern string rules { get; set; }
		public extern string summary { get; set; }
		public extern string width { get; set; }

		public extern HtmlTableSectionElement createTHead();
		public extern void deleteTHead();
		public extern HtmlTableSectionElement createTFoot();
		public extern void deleteTFoot();
		public extern HtmlTableCaptionElement createCaption();
		public extern void deleteCaption();
		public extern HtmlTableRowElement insertRow(int index);
		public extern void deleteRow(int index);
	}
}