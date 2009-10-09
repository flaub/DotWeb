#if HOSTED_MODE
namespace DotWeb.System
#else
namespace System
#endif
{
	public delegate void Action();
	public delegate void Action<T>(T obj);
	public delegate void Action<T1, T2>(T1 obj1, T2 obj2);
	public delegate void Action<T1, T2, T3>(T1 obj1, T2 obj2, T3 obj3);
}
