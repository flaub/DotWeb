﻿// Copyright 2009, Frank Laub
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Utility
{
	public static class AttributeExtensions
	{
		public static R GetCustomAttribute<R>(this MemberInfo member) where R : Attribute {
			return Attribute.GetCustomAttribute(member, typeof(R)) as R;
		}

		public static R GetCustomAttribute<R>(this Type type) where R : Attribute {
			return Attribute.GetCustomAttribute(type, typeof(R)) as R;
		}
	}

}
