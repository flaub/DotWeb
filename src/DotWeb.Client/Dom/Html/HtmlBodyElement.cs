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
	public interface HtmlBodyElement : HtmlElement
	{
		/// <summary>
		/// Specifies the color of activated links in the document (Alink attribute).
		/// </summary>
		string aLink { get; set; }
	
		/// <summary>
		/// 
		/// </summary>
		string background { get; set; }

		/// <summary>
		/// Specifies the background color of the document.
		/// </summary>
		string bgColor { get; set; }

		/// <summary>
		/// Specifies the color of unvisited links in the document (link attribute).
		/// </summary>
		string link { get; set; }

		/// <summary>
		/// Specifies the default text color of the document (text attribute).
		/// </summary>
		string text { get; set; }

		/// <summary>
		/// Specifies the color of visited links in the document (vlink attribute).
		/// </summary>
		string vLink { get; set; }
	}
}