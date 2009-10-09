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
	public interface HtmlAnchorElement : HtmlElement
	{
		string accessKey { get; set; }
		string charset { get; set; }
		string coords { get; set; }
		string href { get; set; }
		string hreflang { get; set; }
		string name { get; set; }
		string rel { get; set; }
		string rev { get; set; }
		string shape { get; set; }
		int tabIndex { get; set; }
		string target { get; set; }
		string type { get; set; }
		
		void blur();
		void focus();
	}
}