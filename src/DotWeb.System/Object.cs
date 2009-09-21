namespace System
{
	public class Object
	{
		public Object() {
		}

		public virtual bool Equals(object obj) {
			return ReferenceEquals(this, obj);
		}

		public virtual int GetHashCode() {
			return 0;
		}

		public Type GetType() {
			return null;
		}

		protected object MemberwiseClone() {
			return this;
		}

		public virtual string ToString() {
			return null;
		}

		public static bool ReferenceEquals(object objA, object objB) {
			return false;
		}
	}
}
