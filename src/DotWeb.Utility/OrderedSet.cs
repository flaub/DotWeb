using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Utility
{
	public class OrderedSet<T> : ICollection<T>, IList<T>, ICloneable
	{
		private readonly static object PlaceholderObject = new object();
		private SortedList<T, object> list = new SortedList<T, object>();

		public OrderedSet() {
		}

		public OrderedSet(ICollection<T> initialValues) {
			this.AddAll(initialValues);
		}

		#region ICollection<T> Members

		void ICollection<T>.Add(T item) {
			this.Add(item);
		}

		public void Clear() {
			this.Clear();
		}

		public bool Contains(T item) {
			return this.list.ContainsKey(item);
		}

		public void CopyTo(T[] array, int arrayIndex) {
			this.list.Keys.CopyTo(array, arrayIndex);
		}

		public int Count {
			get { return this.list.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public bool Remove(T item) {
			return this.list.Remove(item);
		}

		#endregion

		#region IEnumerable<T> Members

		public IEnumerator<T> GetEnumerator() {
			return this.list.Keys.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return this.list.Keys.GetEnumerator();
		}

		#endregion

		#region ICloneable Members

		public object Clone() {
			var set = new OrderedSet<T>();
			set.AddAll(this);
			return set;
		}	

		#endregion

		#region IList<T> Members

		public int IndexOf(T item) {
			return this.list.IndexOfKey(item);
		}

		public void Insert(int index, T item) {
			this.list.Keys.Insert(index, item);
			this.list.Values.Insert(index, PlaceholderObject);
		}

		public void RemoveAt(int index) {
			this.list.RemoveAt(index);
		}

		public T this[int index] {
			get {
				return this.list.Keys[index];
			}
			set {
				this.list.Keys[index] = value;
			}
		}

		#endregion

		public bool IsEmpty { get { return this.Count == 0; } }

		public OrderedSet<T> Union(OrderedSet<T> a) {
			var result = (OrderedSet<T>)this.Clone();
			if (a != null)
				result.AddAll(a);
			return result;
		}

		public OrderedSet<T> Intersect(OrderedSet<T> a) {
			var result = (OrderedSet<T>)this.Clone();
			if(a != null)
				result.RetainAll(a);
			else
				result.Clear();
			return result;
		}

		public OrderedSet<T> Minus(OrderedSet<T> a) {
			var result = (OrderedSet<T>)this.Clone();
			if (a != null)
				result.RemoveAll(a);
			return result;
		}

		public OrderedSet<T> ExclusiveOr(OrderedSet<T> a) {
			var result = (OrderedSet<T>)this.Clone();
			foreach (var element in a) {
				if (result.Contains(element))
					result.Remove(element);
				else
					result.Add(element);
			}
			return result;
		}

		public bool ContainsAll(ICollection<T> collection) {
			foreach (var item in collection) {
				if (!this.Contains(item)) {
					return false;
				}
			}
			return true;
		}

		public bool Add(T item) {
			if (!this.Contains(item)) {
				this.list.Add(item, PlaceholderObject);
				return true;
			}
			return false;
		}

		public bool AddAll(ICollection<T> collection) {
			bool changed = false;
			foreach (var item in collection)
				changed |= this.Add(item);
			return changed;
		}

		public bool RemoveAll(ICollection<T> collection) {
			bool changed = false;
			foreach (var item in collection)
				changed |= this.Remove(item);
			return changed;
		}

		public bool RetainAll(ICollection<T> collection) {
			//Put data from C into a set so we can use the Contains() method.
			var set = new OrderedSet<T>(collection);

			//We are going to build a set of elements to remove.
			var removeSet = new OrderedSet<T>();

			foreach (var item in this) {
				//If C does not contain O, then we need to remove O from our
				//set.  We can't do this while iterating through our set, so
				//we put it into RemoveSet for later.
				if (!set.Contains(item))
					removeSet.Add(item);
			}

			return this.RemoveAll(removeSet);
		}

		public override bool Equals(object obj) {
			var rhs = obj as OrderedSet<T>;
			if (rhs == null || rhs.Count != this.Count) {
				return false;
			}
			else {
				foreach (var elt in rhs) {
					if (!this.Contains(elt)) {
						return false;
					}
				}
				return true;
			}
		}

		public override int GetHashCode() {
			throw new NotImplementedException();
		}
	}
}
