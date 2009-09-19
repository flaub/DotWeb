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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Utility
{
	//public static class HashSetExtensions
	//{
	//    public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> items) {
	//        foreach (var item in items) {
	//            set.Add(item);
	//        }
	//    }
	//}

	public static class ListExtensions
	{
		public static bool AddUnique<T>(this List<T> list, T item) {
			if (!list.Contains(item)) {
				list.Add(item);
				return true;
			}
			return false;
		}

		public static void Enqueue<T>(this List<T> list, T item) {
			list.Add(item);
		}

		public static T Dequeue<T>(this List<T> list) {
			T item = list.First();
			list.RemoveAt(0);
			return item;
		}
	}

}
