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
	public interface HtmlInputElement : HtmlElement
	{
		string defaultValue { get; set; }
		bool defaultChecked { get; set; }
		HtmlFormElement form { get; }
		string accept { get; set; }
		string accessKey { get; set; }
		string align { get; set; }
		string alt { get; set; }

		bool _checked {
			[JsCode("return this.checked")]
			get;
			[JsCode("this.checked = value;")]
			set;
		}

		bool disabled { get; set; }
		int maxLength { get; set; }
		string name { get; set; }
		bool readOnly { get; set; }
		// Modified in DOM Level 2:
		uint size { get; set; }
		string src { get; set; }
		int tabIndex { get; set; }
		// Modified in DOM Level 2:
		string type { get; set; }
		string useMap { get; set; }
		string value { get; set; }
		void blur();
		void focus();
		void select();
		void click();
	}
}