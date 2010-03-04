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
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
	public class HashSet<T> : ICollection<T>
	{
		#region ICollection<T> Members

		public void Add(T item) {
			throw new NotImplementedException();
		}

		public void Clear() {
			throw new NotImplementedException();
		}

		public bool Contains(T item) {
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

		public bool Remove(T item) {
			throw new NotImplementedException();
		}

		public int Count {
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly {
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator() {
			throw new NotImplementedException();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			throw new NotImplementedException();
		}

		#endregion
	}
}
