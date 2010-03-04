// Copyright 2010, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 
using SysException = System.Exception;

#if HOSTED_MODE
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
	public interface IEqualityComparer<T>
	{
		bool Equals(T x, T y);
		int GetHashCode(T obj);
	}

	public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
	{
		public abstract bool Equals(T x, T y);
		public abstract int GetHashCode(T obj);

		bool IEqualityComparer.Equals(object x, object y) {
			return this.Equals((T)x, (T)y);
		}

		int IEqualityComparer.GetHashCode(object obj) {
			return this.GetHashCode((T)obj);
		}

		public static EqualityComparer<T> Default {
			get {
				return new DefaultComparer();
			}
		}

		sealed class DefaultComparer : EqualityComparer<T>
		{
			public override int GetHashCode(T obj) {
				if (obj == null)
					return 0;
				return obj.GetHashCode();
			}

			public override bool Equals(T x, T y) {
				if (x == null)
					return y == null;
				return x.Equals(y);
			}
		}
	}

	//sealed class GenericEqualityComparer<T> : EqualityComparer<T> where T : IEquatable<T>
	//{
	//    public override int GetHashCode(T obj) {
	//        if (obj == null)
	//            return 0;
	//        return obj.GetHashCode();
	//    }

	//    public override bool Equals(T x, T y) {
	//        if (x == null)
	//            return y == null;
	//        return x.Equals(y);
	//    }
	//}
}
