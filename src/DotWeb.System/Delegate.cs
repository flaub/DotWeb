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

using System.Runtime.CompilerServices;

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	public class Delegate
	{
		//public static Delegate Combine(params Delegate[] delegates) {
		//    return null;
		//}

		[JsCode("throw 'Not Supported';")]
		public static extern Delegate Combine(Delegate a, Delegate b);

		[JsCode("throw 'Not Supported';")]
		public static extern Delegate Remove(Delegate source, Delegate value);
	}

	[UseSystem]
	public class MulticastDelegate : Delegate
	{
	}
}
