#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	public class Object
	{
#if HOSTED_MODE
		public override bool Equals(object obj) {
			return base.Equals(obj);
		}

		public override int GetHashCode() {
			return base.GetHashCode();
		}
#else
		public virtual bool Equals(object obj) {
			return false;
		}

		public virtual int GetHashCode() {
			return 0;
		}
#endif
	}
}
