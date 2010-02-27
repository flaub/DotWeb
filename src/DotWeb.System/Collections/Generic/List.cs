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
using DotWeb.System;
using DotWeb.System.DotWeb;
namespace DotWeb.System.Collections.Generic
#else
using System;
using System.DotWeb;
namespace System.Collections.Generic
#endif
{
//	[Serializable]
//	[DebuggerDisplay("Count = {Count}")]
//	[DebuggerTypeProxy(typeof(Mscorlib_CollectionDebugView<>))]
	public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
	{
		private JsArray items;

		public List() {
			this.items = new JsArray();
		}

		public List(int capacity) {
			this.items = new JsArray(capacity);
		}

		#region IList<T> Members

		public int IndexOf(T item) {
			return this.items.IndexOf(item);
		}

		public void Insert(int index, T item) {
			var len = this.items.Length;
			if (index == 0) {
				this.items.Unshift(item);
			}
			else if (index == len) {
				this.items.Push(item);
			}
			else {
				var newItems = new JsArray(len + 1);
				for (int i = 0; i < index; i++) {
					newItems[i] = this.items[i];
				}
				newItems[index] = item;
				for (int i = index; i < len; i++) {
					newItems[i + 1] = this.items[i];
				}
				this.items = newItems;
			}
		}

		/// <summary>
		/// Removes the element at the specified index of the List&lt;T&gt;.
		/// </summary>
		/// <remarks>
		/// This method is an O(n) operation, where n is (Count - index).
		/// </remarks>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// index is less than 0.  -or- index is equal to or greater than <see cref="Count"/>.
		/// </exception>
		/// <param name="index">The zero-based index of the element to remove.</param>
		public void RemoveAt(int index) {
			if (index < 0 || index > this.items.Length) {
				throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.", "index");
			}

			if (index == 0) {
				this.items.Shift();
			}
			else if (index == this.items.Length - 1) {
				this.items.Pop();
			}
			else {
				this.items = this.items.Filter((object item, int i, JsArray array) => {
					return i != index;
				});
			}
		}

		public T this[int index] {
			get {
				//if (index >= this._size) {
				//    ThrowHelper.ThrowArgumentOutOfRangeException();
				//}
				return (T)this.items[index]; 
			}
			set {
				//if (index >= this._size) {
				//    ThrowHelper.ThrowArgumentOutOfRangeException();
				//}
				this.items[index] = value; 
			}
		}

		#endregion

		#region ICollection<T> Members

		public void Add(T item) { 
			this.items.Push(item);
		}

		public void Clear() {
			this.items = new JsArray();
		}

		public bool Contains(T item) {
			return this.IndexOf(item) != -1;
		}

		public void CopyTo(T[] array, int arrayIndex) {
			throw new NotImplementedException();
//			global::System.Array.Copy(this.items.ToArray(), 0, array, arrayIndex, this.items.Length);
		}

		public bool Remove(T item) {
			bool foundFirst = false;
			this.items = this.items.Filter((object element, int i, JsArray array) => {
				if (!foundFirst && JsObject.StrictEquals(item, element)) {
					foundFirst = true;
					return false;
				}
				return true;
			});
			return foundFirst;
		}

		public int Count {
			get { return this.items.Length; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		#endregion

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator() {
			return new Enumerator(this);
		}

		#endregion

		#region IList Members

		public int Add(object item) {
//			List<T>.VerifyValueType(item);
			this.Add((T)item);
			return (this.Count - 1);
		}

		public bool Contains(object item) {
//			return (List<T>.IsCompatibleObject(item) && this.Contains((T)item));
			return this.Contains((T)item);
		}

		public int IndexOf(object item) {
//			if (List<T>.IsCompatibleObject(item)) {
				return this.IndexOf((T)item);
//			}
//			return -1;
		}

		public void Insert(int index, object item) {
//			List<T>.VerifyValueType(item);
			this.Insert(index, (T)item);
		}

		public void Remove(object item) {
//			if (List<T>.IsCompatibleObject(item)) {
				this.Remove((T)item);
//			}
		}

		public bool IsFixedSize {
			get { return false; }
		}

		object IList.this[int index] {
			get {
				//if (index >= this._size) {
				//    ThrowHelper.ThrowArgumentOutOfRangeException();
				//}
				return this.items[index]; 
			}
			set {
				//if (index >= this._size) {
				//    ThrowHelper.ThrowArgumentOutOfRangeException();
				//}
				this.items[index] = value; 
			}
		}

		#endregion

		#region ICollection Members

		public void CopyTo(global::System.Array array, int index) {
			throw new NotImplementedException();
			//if ((array != null) && (array.Rank != 1)) {
			//    ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
			//}
			//try {
			//global::System.Array.Copy(this.items.ToArray(), 0, array, index, this.items.Length);
			//}
			//catch (ArrayTypeMismatchException) {
			//	ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
			//}
		}

		public bool IsSynchronized {
			get { return false; }
		}

		public object SyncRoot {
			get { return null; }
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			throw new global::System.NotImplementedException();
		}

		#endregion

		[JsCode("return this.items;")]
		public extern T[] ToArray();

		[JsCamelCase]
		public override string ToString() {
			return "[ " + this.items.ToString() + " ]";
		}

		class Enumerator : IEnumerator<T>, IDisposable, IEnumerator
		{
			private List<T> list;
			private int index;
			private T current;

			internal Enumerator(List<T> list) {
				this.list = list;
				this.index = 0;
				this.current = default(T);
			}

			#region IEnumerator<T> Members

			public T Current {
				get { return this.current; }
			}

			#endregion

			#region IEnumerator Members

			public bool MoveNext() {
				if (this.index < this.list.Count) {
					this.current = this.list[this.index];
					this.index++;
					return true;
				}
				return this.MoveNextRare();
			}

			object IEnumerator.Current {
				get {
					//if ((this.index == 0) || (this.index == (this.list._size + 1))) {
					//    ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
					//}
					return this.Current;
				}
			}

			public void Reset() {
				this.index = 0;
				this.current = default(T);
			}

			#endregion

			#region IDisposable Members

			public void Dispose() {
			}

			#endregion

			private bool MoveNextRare() {
				this.index = this.list.Count + 1;
				this.current = default(T);
				return false;
			}
		}
	}
}
