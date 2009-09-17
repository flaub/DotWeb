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

namespace DotWeb.Client.Dom.Css
{
	public class CssValue : JsNativeBase
	{
	}

	public class CssStyleDeclaration : JsNativeBase
	{
		public string cssText { get { return _<string>(); } set { _(value); } }
		public int length { get { return _<int>(); } }
		public CssRule parentRule { get { return _<CssRule>(); } }

		public string item(int index) { return _<string>(index); }

		public string getPropertyValue(string propertyName) { return _<string>(propertyName); }
		public CssValue getPropertyCSSValue(string propertyName) { return _<CssValue>(propertyName); }
		public string removeProperty(string propertyName) { return _<string>(propertyName); }
		public string getPropertyPriority(string propertyName) { return _<string>(propertyName); }
		public void setProperty(string propertyName, string value, string priority) { _(propertyName, value, priority); }
	}
}
