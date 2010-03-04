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

using SysArray = System.Array;

#if HOSTED_MODE
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
	public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary
	{
		#region Fields
		IEqualityComparer<TKey> hcp;
		#endregion

		#region Construction
		public Dictionary() {
		}

		public Dictionary(IEqualityComparer<TKey> comparer) {
		}

		public Dictionary(IDictionary<TKey, TValue> dictionary) {
		}
	
		public Dictionary(int capacity) {
		}

		public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) {
		}

		public Dictionary(int capacity, IEqualityComparer<TKey> comparer) {
		}

		private void Init(int capacity, IEqualityComparer<TKey> hcp) {
			if (capacity < 0)
				throw new ArgumentOutOfRangeException("capacity");
			this.hcp = (hcp != null) ? hcp : EqualityComparer<TKey>.Default;
		}
		#endregion

		#region IDictionary<TKey,TValue> Members

		public void Add(TKey key, TValue value) {
			throw new NotImplementedException();
		}

		public bool ContainsKey(TKey key) {
			throw new NotImplementedException();
		}

		public bool Remove(TKey key) {
			throw new NotImplementedException();
		}

		public bool TryGetValue(TKey key, out TValue value) {
			throw new NotImplementedException();
		}

		public TValue this[TKey key] {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public ICollection<TKey> Keys {
			get { throw new NotImplementedException(); }
		}

		public ICollection<TValue> Values {
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region ICollection<KeyValuePair<TKey,TValue>> Members

		public void Add(KeyValuePair<TKey, TValue> item) {
			throw new NotImplementedException();
		}

		public void Clear() {
			throw new NotImplementedException();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item) {
			throw new NotImplementedException();
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

		public bool Remove(KeyValuePair<TKey, TValue> item) {
			throw new NotImplementedException();
		}

		public int Count {
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly {
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IEnumerable<KeyValuePair<TKey,TValue>> Members

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
			throw new NotImplementedException();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			throw new NotImplementedException();
		}

		#endregion

		#region IDictionary Members

		public bool IsFixedSize {
			get { throw new NotImplementedException(); }
		}

		public object this[object key] {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		ICollection IDictionary.Keys {
			get { throw new NotImplementedException(); }
		}

		ICollection IDictionary.Values {
			get { throw new NotImplementedException(); }
		}

		public void Add(object key, object value) {
			throw new NotImplementedException();
		}

		public bool Contains(object key) {
			throw new NotImplementedException();
		}

		IDictionaryEnumerator IDictionary.GetEnumerator() {
			throw new NotImplementedException();
		}

		public void Remove(object key) {
			throw new NotImplementedException();
		}

		#endregion

		#region ICollection Members

		public void CopyTo(SysArray array, int index) {
			throw new NotImplementedException();
		}

		public bool IsSynchronized {
			get { throw new NotImplementedException(); }
		}

		public object SyncRoot {
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
