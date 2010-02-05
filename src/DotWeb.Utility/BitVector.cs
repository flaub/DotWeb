using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Utility
{
	public class BitVector
	{
		private int[] array;
		public int Length { get; private set; }

		private static readonly int[] BitMasks;

		static BitVector() {
			BitMasks = new int[32];
			int x = 1;
			for (int i = 0; i < BitMasks.Length; i++) {
				BitMasks[i] = x - 1;
				x *= 2;
			}
		}

		private BitVector() {
		}

		public BitVector(int length)
			: this(length, false) {
		}

		public BitVector(int length, bool defaultValue) {
			this.array = new int[(length + 0x1f) / 0x20];
			this.Length = length;
			int num = defaultValue ? -1 : 0;
			for (int i = 0; i < this.array.Length; i++) {
				this.array[i] = num;
			}
		}

		public BitVector Not() {
			for (int i = 0; i < this.array.Length; i++) {
				this.array[i] = ~this.array[i];
			}
			return this;
		}

		public BitVector And(BitVector value) {
			if (this.Length != value.Length) {
				throw new ArgumentException();//Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
			}

			for (int i = 0; i < this.array.Length; i++) {
				this.array[i] &= value.array[i];
			}

			return this;
		}

		public BitVector Or(BitVector value) {
			if (this.Length != value.Length) {
				throw new ArgumentException();//Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
			}
			for (int i = 0; i < this.array.Length; i++) {
				this.array[i] |= value.array[i];
			}
			return this;
		}

		public BitVector Xor(BitVector value) {
			if (value == null) {
				throw new ArgumentNullException("value");
			}
			if (this.Length != value.Length) {
				throw new ArgumentException();//Environment.GetResourceString("Arg_ArrayLengthsDiffer"));
			}
			for (int i = 0; i < this.array.Length; i++) {
				this.array[i] ^= value.array[i];
			}
			return this;
		}

		public bool Get(int index) {
			return ((this.array[index / 0x20] & (((int)1) << (index % 0x20))) != 0);
		}

		public void Set(int index, bool value) {
			if ((index < 0) || (index >= this.Length)) {
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_Index");
			}
			if (value) {
				this.array[index / 0x20] |= ((int)1) << (index % 0x20);
			}
			else {
				this.array[index / 0x20] &= ~(((int)1) << (index % 0x20));
			}
		}

		public void SetAll(bool value) {
			int num = value ? -1 : 0;
			for (int i = 0; i < this.array.Length; i++) {
				this.array[i] = num;
			}
		}

		public void Set(int index) {
			Set(index, true);
		}

		public void Clear(int index) {
			Set(index, false);
		}

		public void SetAll() {
			SetAll(true);
		}

		public void ClearAll() {
			SetAll(false);
		}

		public bool this[int index] {
			get { return this.Get(index); }
			set { this.Set(index, value); }
		}

		public override string ToString() {
			var sb = new StringBuilder();
			sb.Append("{");
			for (int i = 0; i < this.Length; i++) {
				var x = this.Get(i);
				sb.Append(x ? "1" : "0");
			}
			sb.Append("}");
			return sb.ToString();
		}

		public override bool Equals(object obj) {
			var rhs = obj as BitVector;
			if ((object)rhs == null)
				return false;

			if (this.Length != rhs.Length)
				return false;

			int mask = -1;
			if (this.Length < 0x20) {
				mask = BitMasks[this.Length];
			}

			if((this.array[0] & mask) != (rhs.array[0] & mask))
				return false;

			for (int i = 1; i < this.array.Length; i++) {
				if (this.array[i] != rhs.array[i])
					return false;
			}

			return true;
		}

		public override int GetHashCode() {
			return this.array.GetHashCode();
		}

		public static bool operator ==(BitVector lhs, BitVector rhs) {
			// If both are null, or both are same instance, return true.
			if (Object.ReferenceEquals(lhs, rhs)) {
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)rhs == null) || ((object)rhs == null)) {
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(BitVector lhs, BitVector rhs) {
			return !(lhs == rhs);
		}
	}
}
