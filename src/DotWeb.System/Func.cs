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

namespace System
{
	public delegate R Func<R>();
	public delegate R Func<R, T>(T obj);
	public delegate R Func<R, T1, T2>(T1 obj1, T2 obj2);
	public delegate R Func<R, T1, T2, T3>(T1 obj1, T2 obj2, T3 obj3);
}
