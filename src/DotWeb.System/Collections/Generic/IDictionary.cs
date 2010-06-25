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

namespace System.Collections.Generic
{
	public interface IDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
	{
		void Add(TKey key, TValue value);
		bool ContainsKey(TKey key);
		bool Remove(TKey key);
		bool TryGetValue(TKey key, out TValue value);
		TValue this[TKey key] { get; set; }
		ICollection<TKey> Keys { get; }
		ICollection<TValue> Values { get; }
	}

	public class KeyValuePair<TKey, TValue>
	{
		public KeyValuePair(TKey key, TValue value) {
			this.Key = key;
			this.Value = value;
		}

		public TKey Key { get; private set; }
		public TValue Value { get; private set; }

		public override string ToString() {
			return "[" + (Key != null ? Key.ToString() : string.Empty) + ", " + (Value != null ? Value.ToString() : string.Empty) + "]";
		}
	}
}

