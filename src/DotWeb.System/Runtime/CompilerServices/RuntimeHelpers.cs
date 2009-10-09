#if HOSTED_MODE
namespace DotWeb.System.Runtime.CompilerServices
#else
namespace System.Runtime.CompilerServices
#endif
{
	public static class RuntimeHelpers
	{
		public static void InitializeArray(Array array, RuntimeFieldHandle fldHandle) {
		}
	}
}
