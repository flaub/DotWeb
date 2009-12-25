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
using ThisType = DotWeb.System.String;
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using ThisType = System.String;
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	public class String
	{
		public int Length { get; private set; }

		public extern static ThisType Format(string format, params object[] args);

		[JsCode("return str0 + str1 + str2;")]
		public static extern ThisType Concat(string str0, string str1, string str2);

		public static bool operator !=(ThisType a, ThisType b) {
			return false;
		}

		public static bool operator ==(ThisType a, ThisType b) {
			return false;
		}

		public override bool Equals(object obj) {
			return false;
		}

		public override int GetHashCode() {
			return 0;
		}

//#if HOSTED_MODE
//        public String(string str) {
//        }

//        public static implicit operator String(string str) {
//            return null;
//        }

//        public static implicit operator string(String str) {
//            return null;
//        }
//#endif
	}
}
