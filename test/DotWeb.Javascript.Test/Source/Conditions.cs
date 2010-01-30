using System;

namespace Source
{
	public class Conditions
	{
		public void SimpleIf(int x) {
			if (x == 12) {
				x = 14;
			}
		}

		public void SimpleIfElse(int x) {
			if (x == 12) {
				x = 42;
			}
			else {
				x = 128;
			}
			Console.WriteLine(1);
		}

		public void SimpleIfOr(int a) {
			if (a == 12 || a == 14) {
				a = 42;
			}
		}

		public void SimpleIfAnd(int a) {
			if (a < 12 && a > 2) {
				a = 42;
			}
		}

		public string NullCoalesce(string s) {
			return s ?? "nil";
		}

		public int ReturnTernary(int a) {
			return a > 10 ? 12 : 42;
		}

		public int ReturnNestedTernary(int a) {
			return (a < 0 ? (a < 100 ? 12 : 24) : (a > 0 ? 10 : 42));
		}

		public bool SingleAnd(int x, int y) {
			return ((x == 1) && (y == 2));
		}

		//.method public hidebysig instance void SimpleIfOr(int32 a) cil managed
		//{
		//    .maxstack 8
		//    L_0000: ldarg.1 
		//    L_0001: ldc.i4.s 12
		//    L_0003: beq.s L_000a
		//    L_0005: ldarg.1 
		//    L_0006: ldc.i4.s 14
		//    L_0008: bne.un.s L_000e
		//    L_000a: ldc.i4.s 0x2a
		//    L_000c: starg.s a
		//    L_000e: ret 
		//}
		public bool SingleOr(int x, int y) {
			return ((x == 1) || (y == 2));
		}
	}
}
