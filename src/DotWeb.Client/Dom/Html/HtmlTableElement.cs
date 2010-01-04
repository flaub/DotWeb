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
using System.DotWeb;
namespace DotWeb.Client.Dom.Html
{
	[JsIntrinsic]
	public interface HtmlTableElement : HtmlElement
	{
		HtmlTableCaptionElement caption { get; set; }
		HtmlTableSectionElement tHead { get; set; }
		HtmlTableSectionElement tFoot { get; set; }

		HtmlCollection rows { get; }
		HtmlCollection tBodies { get; }
		string align { get; set; }
		string bgColor { get; set; }
		string border { get; set; }
		string cellPadding { get; set; }
		string cellSpacing { get; set; }
		string frame { get; set; }
		string rules { get; set; }
		string summary { get; set; }
		string width { get; set; }
		HtmlElement createTHead();
		void deleteTHead();
		HtmlElement createTFoot();
		void deleteTFoot();
		HtmlElement createCaption();
		void deleteCaption();
		HtmlElement insertRow(int index);
		void deleteRow(int index);
	}
}