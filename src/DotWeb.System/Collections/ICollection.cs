using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections
#else
namespace System.Collections
#endif
{
	public interface ICollection : IEnumerable
	{
		// Methods
		void CopyTo(Array array, int index);

		// Properties
		int Count { get; }
		bool IsSynchronized { get; }
		object SyncRoot { get; }
	}
}
