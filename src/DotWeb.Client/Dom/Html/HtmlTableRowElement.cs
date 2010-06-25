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
	public class HtmlTableRowElement : HtmlElement
	{
		public extern HtmlCollection<HtmlTableCellElement> cells { get; }

		public extern int rowIndex { get; }
		public extern int sectionRowIndex { get; }
		public extern string align { get; set; }
		public extern string bgColor { get; set; }
		public extern string ch { get; set; }
		public extern string chOff { get; set; }
		public extern string vAlign { get; set; }

		public extern HtmlTableCellElement insertCell(int index);
		public extern void deleteCell(int index);
	}
}