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

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	public static class Console
	{
		[JsCode("console.log(value);")]
		public static extern void Write(int value);

		[JsCode("console.log(value);")]
		public static extern void WriteLine(object value);

		[JsCode("console.log(value);")]
		public static extern void WriteLine(string value);

		public static void WriteLine(string format, params object[] args) {
			WriteLine(string.Format(format, args));
		}

		public static void WriteLine(string format, object arg0, object arg1) {
			WriteLine(string.Format(format, arg0, arg1));
		}
	}
}
