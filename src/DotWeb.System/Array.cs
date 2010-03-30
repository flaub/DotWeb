// Copyright 2009, Frank Laub
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

#if HOSTED_MODE
using DotWeb.System.DotWeb;
namespace DotWeb.System
#else
using System.DotWeb;
namespace System
#endif
{
	[UseSystem]
	[JsNamespace]
	[JsAugment("Array")]
	public class Array
	{
		private Array() {
		}

		[JsCamelCase]
		public extern int Length { get; }

		public extern object this[int index] { get; set; }

#if !HOSTED_MODE
		/// <summary>
		/// Copies a range of elements from an Array starting at the specified source index and 
		/// pastes them to another Array starting at the specified destination index. 
		/// The length and the indexes are specified as 32-bit integers.
		/// </summary>
		/// <param name="sourceArray">The Array that contains the data to copy.</param>
		/// <param name="sourceIndex">A 32-bit integer that represents the index in the sourceArray at which copying begins.</param>
		/// <param name="destinationArray">The Array that receives the data.</param>
		/// <param name="destinationIndex">A 32-bit integer that represents the index in the destinationArray at which storing begins.</param>
		/// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
		public static void Copy(
			global::System.Array sourceArray,
			int sourceIndex,
			global::System.Array destinationArray,
			int destinationIndex,
			int length) {
			
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");

			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");

			if (length < 0)
				throw new ArgumentOutOfRangeException("length", "Value has to be >= 0.");

			if (sourceIndex < 0)
				throw new ArgumentOutOfRangeException("sourceIndex", "Value has to be >= 0.");

			if (destinationIndex < 0)
				throw new ArgumentOutOfRangeException("destinationIndex", "Value has to be >= 0.");
		
			for (int i = 0; i < length; i++) {
				destinationArray[destinationIndex + i] = sourceArray[sourceIndex + i];
			}
		}

		/// <summary>
		/// Sets a range of elements in the Array to zero, to false, or to null, depending on the element type.
		/// </summary>
		/// <param name="array">The Array whose elements need to be cleared.</param>
		/// <param name="index">The starting index of the range of elements to clear.</param>
		/// <param name="length">The number of elements to clear.</param>
		/// <exception cref="System.ArgumentNullException">array is null.</exception>
		/// <exception cref="System.IndexOutOfRangeException">
		/// index is less than the lower bound of array.
		/// -or-
		/// length is less than zero.
		/// -or-
		/// The sum of index and length is greater than the size of the Array.
		/// </exception>
		/// <remarks>
		/// Reference-type elements are set to null. Boolean-type elements are set to false. Other value-type elements are set to zero.
		/// The range of cleared elements wrap from row to row in a multi-dimensional array.
		/// This method only clears the values of the elements; it does not delete the elements themselves. An Array has a fixed size; therefore, elements cannot be added or removed.
		/// This method is an O(n) operation, where n is length.
		/// </remarks>
		public static void Clear(Array array, int index, int length) {
			if (array == null)
				throw new ArgumentNullException("array");
			if (length < 0)
				throw new IndexOutOfRangeException("length < 0");
			if (index < 0)
				throw new IndexOutOfRangeException("index < lower bound");

			// re-ordered to avoid possible integer overflow
			if (index > array.Length - length)
				throw new IndexOutOfRangeException("index + length > size");

			for (int i = 0; i < length; i++) {
				array[index + i] = 0;
			}
		}
#endif
	}
}
