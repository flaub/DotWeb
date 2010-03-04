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
namespace DotWeb.System.Collections
#else
namespace System.Collections
#endif
{
	public class Hashtable : IDictionary, ICollection, IEnumerable, ICloneable
	{
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
	}
}
