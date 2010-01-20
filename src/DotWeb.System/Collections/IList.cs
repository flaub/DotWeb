using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections
#else
namespace System.Collections
#endif
{
//	[ComVisible(true)]
	public interface IList : ICollection, IEnumerable
	{
		// Methods
		int Add(object value);
		void Clear();
		bool Contains(object value);
		int IndexOf(object value);
		void Insert(int index, object value);
		void Remove(object value);
		void RemoveAt(int index);

		// Properties
		bool IsFixedSize { get; }
		bool IsReadOnly { get; }
		object this[int index] { get; set; }
	}
}
