using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
//	[TypeDependency("System.SZArrayHelper")]
	public interface ICollection<T> : IEnumerable<T>, IEnumerable
	{
		// Methods
		void Add(T item);
		void Clear();
		bool Contains(T item);
		void CopyTo(T[] array, int arrayIndex);
		bool Remove(T item);

		// Properties
		int Count { get; }
		bool IsReadOnly { get; }
	}
}
