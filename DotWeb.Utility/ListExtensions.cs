using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Utility
{
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
