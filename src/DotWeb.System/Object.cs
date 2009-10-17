#if HOSTED_MODE
namespace DotWeb.System
#else
namespace System
#endif
{
	public class Object
	{
#if HOSTED_MODE
		public override bool Equals(object obj) {
#else
		public virtual bool Equals(object obj) {
#endif
			return false;
		}

#if HOSTED_MODE
		public override int GetHashCode() {
#else
		public virtual int GetHashCode() {
#endif
			return 0;
		}
	}
}
