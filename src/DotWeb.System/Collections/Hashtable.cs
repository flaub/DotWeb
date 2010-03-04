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

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System.Collections
#else
using System.DotWeb;
namespace System.Collections
#endif
{
	public class Hashtable : IDictionary, ICloneable
	{
		#region Slot
		[JsAnonymous]
		internal struct Slot
		{
			internal object key;
			internal object value;
		}
		#endregion

		#region Fields
		private float loadFactor;
		private Slot[] table;
		private int threshold;
		private IEqualityComparer hcp;
		
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
		public Hashtable()
			: this(0, 1.0f, null) {
		}

		public Hashtable(int capacity, float loadFactor)
			: this(capacity, loadFactor, null) {
		}

		public Hashtable(int capacity)
			: this(capacity, 1.0f, null) {
		}

		public Hashtable(IEqualityComparer equalityComparer)
			: this(1, 1.0f, equalityComparer) {
		}

		public Hashtable(int capacity, float loadFactor, IEqualityComparer equalityComparer) {
			if (capacity < 0)
				throw new ArgumentOutOfRangeException("capacity", "negative capacity");

			if (loadFactor < 0.1f || loadFactor > 1.0f)// || Single.IsNaN(loadFactor))
				throw new ArgumentOutOfRangeException("loadFactor", "load factor");

			this.hcp = equalityComparer;
			if (capacity == 0) ++capacity;
			this.loadFactor = 0.75f * loadFactor;
			double tableSize = capacity / this.loadFactor;
			//if (tableSize > Int32.MaxValue)
			//    throw new ArgumentException("Size is too big");
			int size = (int)tableSize;
			size = ToPrime(size);
			this.hcp = equalityComparer;
		}

		public Hashtable(IDictionary dict)
			: this(dict, 1.0f, null) {
		}

		public Hashtable(IDictionary dict, IEqualityComparer equalityComparer)
			: this(dict, 1.0f, equalityComparer) {
		}

		public Hashtable(IDictionary dict, float loadFactor)
			: this(dict, loadFactor, null) {
		}

		public Hashtable(IDictionary dict, float loadFactor, IEqualityComparer equalityComparer)
			: this(dict != null ? dict.Count : 0, loadFactor, equalityComparer) {
			if (dict == null)
				throw new ArgumentNullException("dictionary");
		
			var it = dict.GetEnumerator();
			while (it.MoveNext()) {
				Add(it.Key, it.Value);
			}
		}
		#endregion

		#region IDictionary Members

		public bool IsFixedSize {
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly {
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

		public ICollection Keys {
			get { throw new NotImplementedException(); }
		}

		public ICollection Values {
			get { throw new NotImplementedException(); }
		}

		public void Add(object key, object value) {
			throw new NotImplementedException();
		}

		public void Clear() {
			throw new NotImplementedException();
		}

		public bool Contains(object key) {
			throw new NotImplementedException();
		}

		public IDictionaryEnumerator GetEnumerator() {
			throw new NotImplementedException();
		}

		public void Remove(object key) {
			throw new NotImplementedException();
		}

		#endregion

		#region ICollection Members

		public void CopyTo(global::System.Array array, int index) {
			throw new NotImplementedException();
		}

		public int Count {
			get { throw new NotImplementedException(); }
		}

		public bool IsSynchronized {
			get { throw new NotImplementedException(); }
		}

		public object SyncRoot {
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			throw new NotImplementedException();
		}

		#endregion

		#region ICloneable Members

		public object Clone() {
			throw new NotImplementedException();
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
				if (x <= primeTable[i])
					return primeTable[i];
			}
			return CalcPrime(x);
		}
		#endregion
	}
}
