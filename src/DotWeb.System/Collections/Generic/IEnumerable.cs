using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
//	[TypeDependency("System.SZArrayHelper")]
	public interface IEnumerable<T> : IEnumerable
	{
		// Methods
		new IEnumerator<T> GetEnumerator();
	}
}
