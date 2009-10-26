#if HOSTED_MODE
namespace DotWeb.System.Collections
#else
namespace System.Collections
#endif
{
	public interface IEqualityComparer
	{
		bool Equals(object x, object y);
		int GetHashCode(object obj);
	}
}
