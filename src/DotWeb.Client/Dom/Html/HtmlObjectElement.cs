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
	public interface HtmlObjectElement : HtmlElement
	{
		HtmlFontElement form { get; }
		string code { get; set; }
		string align { get; set; }
		string archive { get; set; }
		string border { get; set; }
		string codeBase { get; set; }
		string codeType { get; set; }
		string data { get; set; }
		bool declare { get; set; }
		string height { get; set; }
		int hspace { get; set; }
		string name { get; set; }
		string standby { get; set; }
		int tabIndex { get; set; }
		string type { get; set; }
		string useMap { get; set; }
		int vspace { get; set; }
		string width { get; set; }
		Document contentDocument { get; }
	}
}