using SysException = System.Exception;

#if !HOSTED_MODE
namespace System.Collections.Generic
{
	public interface IEqualityComparer<T>
	{
		// Methods
		bool Equals(T x, T y);
		int GetHashCode(T obj);
	}

	[Serializable]
	//[TypeDependency("System.Collections.Generic.GenericEqualityComparer`1")]
	public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
	{
		private static EqualityComparer<T> defaultComparer;

		protected EqualityComparer() { }

		private static EqualityComparer<T> CreateComparer() {
			//Type c = typeof(T);
			//if (c == typeof(byte)) {
			//    return (EqualityComparer<T>)new ByteEqualityComparer();
			//}
			//if (typeof(IEquatable<T>).IsAssignableFrom(c)) {
			//    return (EqualityComparer<T>)typeof(GenericEqualityComparer<int>).TypeHandle.CreateInstanceForAnotherGenericParameter(c);
			//}
			//if (c.IsGenericType && (c.GetGenericTypeDefinition() == typeof(Nullable<>))) {
			//    Type type2 = c.GetGenericArguments()[0];
			//    if (typeof(IEquatable<>).MakeGenericType(new Type[] { type2 }).IsAssignableFrom(type2)) {
			//        return (EqualityComparer<T>)typeof(NullableEqualityComparer<int>).TypeHandle.CreateInstanceForAnotherGenericParameter(type2);
			//    }
			//}
			//return new ObjectEqualityComparer<T>();
			return null;
		}

		public abstract bool Equals(T x, T y);
		public abstract int GetHashCode(T obj);

		internal virtual int IndexOf(T[] array, T value, int startIndex, int count) {
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++) {
				if (this.Equals(array[i], value)) {
					return i;
				}
			}
			return -1;
		}

		internal virtual int LastIndexOf(T[] array, T value, int startIndex, int count) {
			int num = (startIndex - count) + 1;
			for (int i = startIndex; i >= num; i--) {
				if (this.Equals(array[i], value)) {
					return i;
				}
			}
			return -1;
		}

		bool IEqualityComparer.Equals(object x, object y) {
			if (x == y) {
				return true;
			}
			if ((x != null) && (y != null)) {
				if ((x is T) && (y is T)) {
					return this.Equals((T)x, (T)y);
				}
				//ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
				throw new SysException();
			}
			return false;
		}

		int IEqualityComparer.GetHashCode(object obj) {
			if (obj != null) {
				if (obj is T) {
					return this.GetHashCode((T)obj);
				}
				//ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
				throw new SysException();
			}
			return 0;
		}

		public static EqualityComparer<T> Default {
			get {
				var defaultComparer = EqualityComparer<T>.defaultComparer;
				if (defaultComparer == null) {
					defaultComparer = EqualityComparer<T>.CreateComparer();
					EqualityComparer<T>.defaultComparer = defaultComparer;
				}
				return defaultComparer;
			}
		}
	}

}
#endif
