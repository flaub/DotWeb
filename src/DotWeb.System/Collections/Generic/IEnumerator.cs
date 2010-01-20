using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
	public interface IEnumerator<T> : IDisposable, IEnumerator
	{
		// Properties
		new T Current { get; }
	}
}
