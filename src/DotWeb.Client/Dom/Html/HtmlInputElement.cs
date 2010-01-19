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
	public class HtmlInputElement : HtmlElement
	{
		public extern string defaultValue { get; set; }
		public extern bool defaultChecked { get; set; }
		public extern HtmlFormElement form { get; }
		public extern string accept { get; set; }
		public extern string accessKey { get; set; }
		public extern string align { get; set; }
		public extern string alt { get; set; }

		public extern bool @checked { get; set; }
		public extern bool disabled { get; set; }
		public extern int maxLength { get; set; }
		public extern string name { get; set; }
		public extern bool readOnly { get; set; }
		// Modified in DOM Level 2:
		public extern uint size { get; set; }
		public extern string src { get; set; }
		public extern int tabIndex { get; set; }
		// Modified in DOM Level 2:
		public extern string type { get; set; }
		public extern string useMap { get; set; }
		public extern string value { get; set; }

		public extern void blur();
		public extern void focus();
		public extern void select();
		public extern void click();
	}
}