
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
		[JsCode("this._items = [];")]
		public extern List();

		#region IList<T> Members

		[JsCode("return this._items.indexOf(item);")]
		public extern int IndexOf(T item);

		public void Insert(int index, T item) {
			throw new System.NotImplementedException();
		}

		public void RemoveAt(int index) {
			if (index >= this.Count) {
				//ThrowHelper.ThrowArgumentOutOfRangeException();
			}
			//this._size--;
			int len = this.Count - 1;
			if (index < len) {
//				Array.Copy(this._items, index + 1, this._items, index, this._size - index);
				//var left = Slice(0, index);
				//var right = Slice(index, len);
			}
			//this._items[this._size] = default(T);
			//this._version++;
		}

		public T this[int index] {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region ICollection<T> Members

		[JsCode("this._items.push(item);")]
		public extern void Add(T item);
//		{
//			if (this._size == this._items.Length) {
//				this.EnsureCapacity(this._size + 1);
//			}
//			this.items[this.size++] = item;
//		}

		[JsCode("this._items = [];")]
		public extern void Clear();

		public bool Contains(T item) {
			return this.IndexOf(item) != -1;
		}

		public void CopyTo(T[] array, int arrayIndex) {
			throw new NotImplementedException();
		}

		public bool Remove(T item) {
			int index = this.IndexOf(item);
			if (index >= 0) {
				this.RemoveAt(index);
				return true;
			}
			return false;
		}

		public extern int Count {
			[JsCode("return this._items.length;")]
			get;
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

		#region IList Members

		public int Add(object value) {
			throw new NotImplementedException();
		}

		public bool Contains(object value) {
			throw new NotImplementedException();
		}

		public int IndexOf(object value) {
			throw new NotImplementedException();
		}

		public void Insert(int index, object value) {
			throw new NotImplementedException();
		}

		public void Remove(object value) {
			throw new NotImplementedException();
		}

		public bool IsFixedSize {
			get { throw new NotImplementedException(); }
		}

		object IList.this[int index] {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		#endregion

		#region ICollection Members

		public void CopyTo(Array array, int index) {
			throw new NotImplementedException();
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
			throw new global::System.NotImplementedException();
		}

		#endregion

		//[JsCode("return this._items.slice(start, end);")]
		//private extern T[] Slice(int start, int end);

		//[JsCode("return Array.concat(item1, item2);")]
		//private static extern T[] Concat(T[] item1, T[] item2);

	}
}
