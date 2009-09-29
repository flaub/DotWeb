namespace DotWeb.System
{
	public delegate R Func<R>();
	public delegate R Func<R, T>(T obj);
	public delegate R Func<R, T1, T2>(T1 obj1, T2 obj2);
	public delegate R Func<R, T1, T2, T3>(T1 obj1, T2 obj2, T3 obj3);
}
