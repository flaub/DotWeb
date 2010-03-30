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
using StringBuilder = System.Text.StringBuilder;

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System.Collections.Generic
#else
using System.DotWeb;
namespace System.Collections.Generic
#endif
{
	[JsAnonymous]
	internal class Link
	{
		public int HashCode;
		public int Next;
	}

	public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary
	{
		#region Fields
		const int INITIAL_SIZE = 10;
		const float DEFAULT_LOAD_FACTOR = (90f / 100);
		const int NO_SLOT = -1;
		const int HASH_FLAG = -2147483648;

		private int[] table;
		private Link[] linkSlots;
		private TKey[] keySlots;
		private TValue[] valueSlots;
		private int touchedSlots;
		private int emptySlot;
		private int count;
		private int threshold;
		private IEqualityComparer<TKey> hcp;
		private int generation;

		private static readonly int[] primeTable = {
			11,
			19,
			37,
			73,
			109,
			163,
			251,
			367,
			557,
			823,
			1237,
			1861,
			2777,
			4177,
			6247,
			9371,
			14057,
			21089,
			31627,
			47431,
			71143,
			106721,
			160073,
			240101,
			360163,
			540217,
			810343,
			1215497,
			1823231,
			2734867,
			4102283,
			6153409,
			9230113,
			13845163
		};
		#endregion

		#region Construction
		public Dictionary() {
			Init(INITIAL_SIZE, null);
		}

		public Dictionary(IEqualityComparer<TKey> comparer) {
			Init(INITIAL_SIZE, comparer);
		}

		public Dictionary(IDictionary<TKey, TValue> dictionary)
			: this(dictionary, null) {
		}
	
		public Dictionary(int capacity) {
			Init(capacity, null);
		}

		public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) {
			if (dictionary == null)
				throw new ArgumentNullException("dictionary");
		
			int capacity = dictionary.Count;
			Init(capacity, comparer);
			foreach (KeyValuePair<TKey, TValue> entry in dictionary) {
				this.Add(entry.Key, entry.Value);
			}
		}

		public Dictionary(int capacity, IEqualityComparer<TKey> comparer) {
			Init(capacity, comparer);
		}

		private void Init(int capacity, IEqualityComparer<TKey> hcp) {
			if (capacity < 0)
				throw new ArgumentOutOfRangeException("capacity");

			this.hcp = (hcp != null) ? hcp : EqualityComparer<TKey>.Default;
			if (capacity == 0)
				capacity = INITIAL_SIZE;

			// Modify capacity so 'capacity' elements can be added without resizing
			capacity = (int)(capacity / DEFAULT_LOAD_FACTOR) + 1;

			InitArrays(capacity);
			generation = 0;
		}

		private void InitArrays(int size) {
			table = new int[size];

			linkSlots = new Link[size];
			emptySlot = NO_SLOT;

			keySlots = new TKey[size];
			valueSlots = new TValue[size];
			touchedSlots = 0;

			threshold = (int)(table.Length * DEFAULT_LOAD_FACTOR);
			if (threshold == 0 && table.Length > 0)
				threshold = 1;
		}
		#endregion

		#region IDictionary<TKey,TValue> Members

		public void Add(TKey key, TValue value) {
			PutImpl(key, value);
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
			PutImpl(item.Key, item.Value);
		}

		public void Clear() {
			count = 0;
			// clear the hash table
			SysArray.Clear(table, 0, table.Length);
			// clear arrays
			SysArray.Clear(keySlots, 0, keySlots.Length);
			SysArray.Clear(valueSlots, 0, valueSlots.Length);
			SysArray.Clear(linkSlots, 0, linkSlots.Length);

			// empty the "empty slots chain"
			emptySlot = NO_SLOT;

			touchedSlots = 0;
			generation++;
		}

		public bool Contains(KeyValuePair<TKey, TValue> item) {
			return ContainsKeyValuePair(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

		public bool Remove(KeyValuePair<TKey, TValue> item) {
			if (!ContainsKeyValuePair(item))
				return false;

			return Remove(item.Key);
		}

		public int Count {
			get { return this.count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		#endregion

		#region IEnumerable<KeyValuePair<TKey,TValue>> Members

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
			return new Enumerator(this);
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
			PutImpl((TKey)key, (TValue)value);
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

		#region Overrides
		public override string ToString() {
			var result = new StringBuilder();
			result.Append("{");
			var isFirst = true;
			foreach (var item in this) {
				if (isFirst) {
					isFirst = false;
				}
				else {
					result.Append(", ");
				}
				result.Append(item.Key);
				result.Append(": ");
				result.Append(item.Value);
			}
			result.Append("}");
			return result.ToString();
		}
		#endregion

		#region Impl
		internal static bool TestPrime(int x) {
			if ((x & 1) != 0) {
				int top = (int)Math.Sqrt(x);

				for (int n = 3; n < top; n += 2) {
					if ((x % n) == 0)
						return false;
				}
				return true;
			}
			// There is only one even prime - 2.
			return (x == 2);
		}

		internal static int CalcPrime(int x) {
			for (int i = (x & (~1)) - 1; i < Int32.MaxValue; i += 2) {
				if (TestPrime(i)) return i;
			}
			return x;
		}

		internal static int ToPrime(int x) {
			for (int i = 0; i < primeTable.Length; i++) {
				if (x <= primeTable[i]) {
					return primeTable[i];
				}
			}
			return CalcPrime(x);
		}

		private void PutImpl(TKey key, TValue value) {
			if (key == null)
				throw new ArgumentNullException("key");

			//JsDebug.Log("key: " + key);
			//JsDebug.Log("value: " + value);
		
			// get first item of linked list corresponding to given key
			int hashCode = hcp.GetHashCode(key) | HASH_FLAG;
			int index = (hashCode & int.MaxValue) % table.Length;
			int cur = table[index] - 1;

			//JsDebug.Log("hashCode: " + hashCode);
			//JsDebug.Log("index: " + index);
			//JsDebug.Log("table: " + table);
			//JsDebug.Log("table[index]: " + table[index]);
			//JsDebug.Log("cur: " + cur);

			// walk linked list until end is reached (throw an exception if a
			// existing slot is found having an equivalent key)
			while (cur != NO_SLOT) {
				// The ordering is important for compatibility with MS and strange
				// Object.Equals () implementations
				if (linkSlots[cur].HashCode == hashCode && hcp.Equals(keySlots[cur], key))
					throw new ArgumentException("An element with the same key already exists in the dictionary.");
				cur = linkSlots[cur].Next;
			}

			if (++count > threshold) {
				Resize();
				index = (hashCode & int.MaxValue) % table.Length;
			}

			// find an empty slot
			cur = emptySlot;
			if (cur == NO_SLOT)
				cur = touchedSlots++;
			else
				emptySlot = linkSlots[cur].Next;

			//JsDebug.Log("cur: " + cur);

			// store the hash code of the added item,
			// prepend the added item to its linked list,
			// update the hash table
			//JsDebug.Log("linkSlots[cur]: " + linkSlots[cur]);
			if (linkSlots[cur] == null) {
				linkSlots[cur] = new Link();
			}
			linkSlots[cur].HashCode = hashCode;
			linkSlots[cur].Next = table[index] - 1;
			//JsDebug.Log("linkSlots[cur]: " + linkSlots[cur]);
			table[index] = cur + 1;
			//JsDebug.Log("table: " + table);

			// store item's data 
			keySlots[cur] = key;
			valueSlots[cur] = value;

			//JsDebug.Log("keySlots: " + keySlots);
			//JsDebug.Log("valueSlots: " + valueSlots);

			generation++;
		}

		private void Resize() {
			//JsDebug.Log("Resize");
			// From the SDK docs:
			//	 Hashtable is automatically increased
			//	 to the smallest prime number that is larger
			//	 than twice the current number of Hashtable buckets
			var newSize = ToPrime((table.Length << 1) | 1);

			// allocate new hash table and link slots array
			var newTable = new int[newSize];
			var newLinkSlots = new Link[newSize];

			for (int i = 0; i < table.Length; i++) {
				int cur = table[i] - 1;
				while (cur != NO_SLOT) {
					int hashCode = newLinkSlots[cur].HashCode = hcp.GetHashCode(keySlots[cur]) | HASH_FLAG;
					int index = (hashCode & int.MaxValue) % newSize;
					newLinkSlots[cur].Next = newTable[index] - 1;
					newTable[index] = cur + 1;
					cur = linkSlots[cur].Next;
				}
			}
			table = newTable;
			linkSlots = newLinkSlots;

			// allocate new data slots, copy data
			var newKeySlots = new TKey[newSize];
			var newValueSlots = new TValue[newSize];
			SysArray.Copy(keySlots, 0, newKeySlots, 0, touchedSlots);
			SysArray.Copy(valueSlots, 0, newValueSlots, 0, touchedSlots);
			keySlots = newKeySlots;
			valueSlots = newValueSlots;

			threshold = (int)(newSize * DEFAULT_LOAD_FACTOR);
		}

		private bool ContainsKeyValuePair(KeyValuePair<TKey, TValue> pair) {
			TValue value;
			if (!TryGetValue(pair.Key, out value))
				return false;

			return EqualityComparer<TValue>.Default.Equals(pair.Value, value);
		}

		#endregion	
		
		public class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDictionaryEnumerator
		{
			Dictionary<TKey, TValue> dictionary;
			int next;
			int stamp;

			internal KeyValuePair<TKey, TValue> current;

			internal Enumerator(Dictionary<TKey, TValue> dictionary) {
				//JsDebug.Log("Enumerator");
				this.dictionary = dictionary;
				stamp = dictionary.generation;
			}
		
			#region IEnumerator<KeyValuePair<TKey,TValue>> Members

			public KeyValuePair<TKey, TValue> Current {
				get {
					//JsDebug.Log("Current");
					return this.current; 
				}
			}

			#endregion

			#region IDisposable Members

			public void Dispose() {
				//JsDebug.Log("Dispose");
				this.dictionary = null;
			}

			#endregion

			#region IEnumerator Members

			public bool MoveNext() {
				VerifyState();

				if (next < 0) {
					return false;
				}

				while (next < dictionary.touchedSlots) {
					int cur = next++;
					var link = dictionary.linkSlots[cur];
					if ((link.HashCode & HASH_FLAG) != 0) {
						var key = dictionary.keySlots[cur];
						var value = dictionary.valueSlots[cur];
						this.current = new KeyValuePair<TKey, TValue>(key, value);
						return true;
					}
				}

				next = -1;
				return false;
			}

			object IEnumerator.Current {
				get {
					//JsDebug.Log("IEnumerator.Current");
					VerifyCurrent();
					return this.current;
				}
			}

			public void Reset() {
				VerifyState();
				next = 0;
			}

			#endregion

			#region IDictionaryEnumerator Members

			public DictionaryEntry Entry {
				get {
					VerifyCurrent();
					return new DictionaryEntry(current.Key, current.Value);
				}
			}

			public object Key {
				get {
					VerifyCurrent();
					return current.Key;
				}
			}

			public object Value {
				get {
					VerifyCurrent();
					return current.Value;
				}
			}

			#endregion
		
			void VerifyState() {
				//if (dictionary == null)
				//	throw new ObjectDisposedException(null);
				if (dictionary.generation != stamp)
					throw new InvalidOperationException("out of sync");
			}

			void VerifyCurrent() {
				VerifyState();
				if (next <= 0)
					throw new InvalidOperationException("Current is not valid");
			}
		}

	}
}
