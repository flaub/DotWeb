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
	public class AnchorElement : HtmlElement
	{
		public const string TAG = "a";

		public extern string accessKey { get; set; }
		public extern string charset { get; set; }
		public extern string coords { get; set; }
		public extern string href { get; set; }
		public extern string hreflang { get; set; }
		public extern string name { get; set; }
		public extern string rel { get; set; }
		public extern string rev { get; set; }
		public extern string shape { get; set; }
		public extern int tabIndex { get; set; }
		public extern string target { get; set; }
		public extern string type { get; set; }
	
		/// <summary>
		/// Removes keyboard focus from this element.
		/// </summary>
		public extern void blur();

		/// <summary>
		/// Gives keyboard focus to this element.
		/// </summary>
		public extern void focus();
	}
}