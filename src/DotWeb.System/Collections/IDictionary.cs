// Copyright 2010, Frank Laub
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
using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections
#else
namespace System.Collections
#endif
{
	public interface IDictionary : ICollection
	{
		bool IsFixedSize { get; }
		bool IsReadOnly { get; }
		object this[object key] { get; set; }
		ICollection Keys { get; }
		ICollection Values { get; }

		void Add(object key, object value);
		void Clear();
		bool Contains(object key);
		new IDictionaryEnumerator GetEnumerator();
		void Remove(object key);
	}

	public interface IDictionaryEnumerator : IEnumerator
	{
		DictionaryEntry Entry { get; }
		object Key { get; }
		object Value { get; }
	}

	public class DictionaryEntry
	{
		public DictionaryEntry(object key, object value) {
			this.Key = key;
			this.Value = value;
		}

		public object Key { get; set; }
		public object Value { get; set; }
	}
}
