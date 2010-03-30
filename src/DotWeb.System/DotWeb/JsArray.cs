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
using System;

#if HOSTED_MODE
namespace DotWeb.System.DotWeb
#else
namespace System.DotWeb
#endif
{
	public delegate int ArrayCompareFn(object x, object y);

	public delegate bool ArrayCallbackFn(object item, int index, JsArray array);

	public delegate object ArrayMapFn(object item, int index, JsArray array);

	public delegate object ArrayReduceFn(object previousValue, object currentValue, int currentIndex, JsArray array);

	[JsNamespace]
	[JsCamelCase]
	public class JsArray : JsObject
	{
		[JsMacro("{1}")]
		public static extern implicit operator JsArray(Array array);

		[JsMacro("{1}")]
		public static extern implicit operator Array(JsArray array);

		/// <summary>
		/// <para>
		/// This description applies if and only if the Array constructor is given no arguments or at least two arguments.
		/// </para>
		/// <para>
		/// The [[Prototype]] internal property of the newly constructed object is set to the original Array prototype object, the one that is the initial value of Array.prototype (15.4.3.1).
		/// </para>
		/// <para>
		/// The [[Class]] internal property of the newly constructed object is set to "Array".
		/// </para>
		/// <para>
		/// The [[Extensible]] internal property of the newly constructed object is set to true.
		/// </para>
		/// <para>
		/// The length property of the newly constructed object is set to the number of arguments.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The 0 property of the newly constructed object is set to item0 (if supplied); the 1 property of the newly constructed object is set to item1 (if supplied); and, in general, for as many arguments as there are, the k property of the newly constructed object is set to argument k, where the first argument is considered to be argument number 0. These properties all have the attributes {[[Writable]]: true, [[Enumerable]]: true, [[Configurable]]: true}.
		/// </remarks>
		[JsMacro("new Array()")]
		public extern JsArray();

		/// <summary>
		/// The [[Prototype]] internal property of the newly constructed object is set to the original Array prototype object, the one that is the initial value of Array.prototype (15.4.3.1). The [[Class]] internal property of the newly constructed object is set to "Array". The [[Extensible]] internal property of the newly constructed object is set to true.
		/// </summary>
		/// <remarks>
		/// <para>
		/// constructed object is set to ToUint32(len). If the argument len is a Number and ToUint32(len) is not equal to len, a RangeError exception is thrown.
		/// </para>
		/// <para>
		/// If the argument len is not a Number, then the length property of the newly constructed object is set to 1 and the 0 property of the newly constructed object is set to len with attributes {[[Writable]]: true, [[Enumerable]]: true, [[Configurable]]: true}..
		/// </para>
		/// </remarks>
		/// <param name="len"></param>
		[JsMacro("new Array({1})")]
		public extern JsArray(int len);

		/// <summary>
		/// <para>
		/// This description applies if and only if the Array constructor is given no arguments or at least two arguments.
		/// </para>
		/// <para>
		/// The [[Prototype]] internal property of the newly constructed object is set to the original Array prototype object, the one that is the initial value of Array.prototype (15.4.3.1).
		/// </para>
		/// <para>
		/// The [[Class]] internal property of the newly constructed object is set to "Array".
		/// </para>
		/// <para>
		/// The [[Extensible]] internal property of the newly constructed object is set to true.
		/// </para>
		/// <para>
		/// The length property of the newly constructed object is set to the number of arguments.
		/// </para>
		/// </summary>
		/// <remarks>
		/// The 0 property of the newly constructed object is set to item0 (if supplied); the 1 property of the newly constructed object is set to item1 (if supplied); and, in general, for as many arguments as there are, the k property of the newly constructed object is set to argument k, where the first argument is considered to be argument number 0. These properties all have the attributes {[[Writable]]: true, [[Enumerable]]: true, [[Configurable]]: true}.
		/// </remarks>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		[JsMacro("new Array({1}, {2})")]
		public extern JsArray(object arg1, object arg2);

		/// <summary>
		/// The length property of this Array object is a data property whose value is always numerically greater than the name of every deletable property whose name is an array index.
		/// </summary>
		public extern int Length { get; }

		public extern object this[int index] { get; set; }

		//[JsMacro("{0}")]
		//public static extern implicit operator Array(JsArray from);

		//[JsMacro("{0}")]
		//public static extern implicit operator JsArray(Array from);

		[JsMacro("{0}")]
		public extern object[] ToArray();

		/// <summary>
		/// The isArray function takes one argument arg, 
		/// and returns the Boolean value true if the argument is an 
		/// object whose class internal property is "Array"; 
		/// otherwise it returns false.
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		[JsMacro("Array.isArray({1})")]
		public static extern bool IsArray(object arg);

		/// <summary>
		/// When the concat method is called with zero or more arguments 
		/// item1, item2, etc., it returns an array containing the array 
		/// elements of the object followed by the array elements of each argument in order.
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		[JsMacro("Array.concat({1}, {2})")]
		public static extern JsArray Concat(object item1, object item2);

		/// <summary>
		/// The elements of the array are converted to Strings, 
		/// and these Strings are then concatenated, separated by occurrences of the separator. 
		/// If no separator is provided, a single comma is used as the separator.
		/// </summary>
		/// <returns></returns>
		public extern string Join();

		/// <summary>
		/// The elements of the array are converted to Strings, 
		/// and these Strings are then concatenated, separated by occurrences of the separator. 
		/// If no separator is provided, a single comma is used as the separator.
		/// </summary>
		/// <param name="separator"></param>
		/// <returns></returns>
		public extern string Join(string separator);

		/// <summary>
		/// The last element of the array is removed from the array and returned.
		/// </summary>
		/// <returns></returns>
		public extern object Pop();

		/// <summary>
		/// The arguments are appended to the end of the array, in the order in which they appear. 
		/// The new length of the array is returned as the result of the call.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The new length of the array</returns>
		public extern int Push(object item);

		/// <summary>
		/// The arguments are appended to the end of the array, in the order in which they appear. 
		/// The new length of the array is returned as the result of the call.
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>The new length of the array</returns>
		public extern int Push(object item1, object item2);

		/// <summary>
		/// The elements of the array are rearranged so as to reverse their order. 
		/// The object is returned as the result of the call.
		/// </summary>
		/// <returns></returns>
		public extern object Reverse();

		/// <summary>
		/// The first element of the array is removed from the array and returned.
		/// </summary>
		/// <returns></returns>
		public extern object Shift();

		/// <summary>
		/// The slice method takes two arguments, start and end, and returns an array 
		/// containing the elements of the array from element start up to, but not including, 
		/// element end (or through the end of the array if end is undefined). 
		/// If start is negative, it is treated as length+start where length is the length of the array. 
		/// If end is negative, it is treated as length+end where length is the length of the array.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public extern JsArray Slice(int start, int end);

		/// <summary>
		/// The elements of this array are sorted. 
		/// The sort is not necessarily stable (that is, elements that compare equal do not 
		/// necessarily remain in their original order). 
		/// If comparefn is not undefined, it should be a function that accepts two 
		/// arguments x and y and returns a negative value if x &lt; y, 
		/// zero if x = y, or a positive value if x &gt; y.
		/// </summary>
		/// <param name="comparator"></param>
		public extern void Sort(ArrayCompareFn comparator);

		/// <summary>
		/// When the splice method is called with two or more arguments start, 
		/// deleteCount and (optionally) item1, item2, etc., the deleteCount 
		/// elements of the array starting at array index start are replaced by the 
		/// arguments item1, item2, etc. 
		/// An Array object containing the deleted elements (if any) is returned.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="deleteCount"></param>
		/// <returns></returns>
		public extern JsArray Splice(int start, int deleteCount);

		/// <summary>
		/// When the splice method is called with two or more arguments start, 
		/// deleteCount and (optionally) item1, item2, etc., the deleteCount 
		/// elements of the array starting at array index start are replaced by the 
		/// arguments item1, item2, etc. 
		/// An Array object containing the deleted elements (if any) is returned.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="deleteCount"></param>
		/// <param name="item1"></param>
		/// <returns></returns>
		public extern JsArray Splice(int start, int deleteCount, object item1);

		/// <summary>
		/// When the splice method is called with two or more arguments start, 
		/// deleteCount and (optionally) item1, item2, etc., the deleteCount 
		/// elements of the array starting at array index start are replaced by the 
		/// arguments item1, item2, etc. 
		/// An Array object containing the deleted elements (if any) is returned.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="deleteCount"></param>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public extern JsArray Splice(int start, int deleteCount, object item1, object item2);

		/// <summary>
		/// The arguments are prepended to the start of the array, 
		/// such that their order within the array is the same as the order in 
		/// which they appear in the argument list.
		/// </summary>
		/// <param name="item"></param>
		public extern void Unshift(object item);

		/// <summary>
		/// The arguments are prepended to the start of the array, 
		/// such that their order within the array is the same as the order in 
		/// which they appear in the argument list.
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		public extern void Unshift(object item1, object item2);

		/// <summary>
		/// <para>
		/// indexOf compares searchElement to the elements of the array, 
		/// in ascending order, using the internal Strict Equality Comparison Algorithm (11.9.6), 
		/// and if found at one or more positions, returns the index of the 
		/// first such position; otherwise, -1 is returned.
		/// </para>
		/// <para>
		/// The optional second argument fromIndex defaults to 0 (i.e. the whole array is searched). 
		/// If it is greater than or equal to the length of the array, 
		/// -1 is returned, i.e. the array will not be searched. 
		/// If it is negative, it is used as the offset from the end of the array 
		/// to compute fromIndex. If the computed index is less than 0, 
		/// the whole array will be searched.
		/// </para>
		/// </summary>
		/// <param name="searchElement"></param>
		/// <returns></returns>
		public extern int IndexOf(object searchElement);

		/// <summary>
		/// <para>
		/// indexOf compares searchElement to the elements of the array, 
		/// in ascending order, using the internal Strict Equality Comparison Algorithm (11.9.6), 
		/// and if found at one or more positions, returns the index of the 
		/// first such position; otherwise, -1 is returned.
		/// </para>
		/// <para>
		/// The optional second argument fromIndex defaults to 0 (i.e. the whole array is searched). 
		/// If it is greater than or equal to the length of the array, 
		/// -1 is returned, i.e. the array will not be searched. 
		/// If it is negative, it is used as the offset from the end of the array 
		/// to compute fromIndex. If the computed index is less than 0, 
		/// the whole array will be searched.
		/// </para>
		/// </summary>
		/// <param name="searchElement"></param>
		/// <param name="fromIndex"></param>
		/// <returns></returns>
		public extern int IndexOf(object searchElement, int fromIndex);

		/// <summary>
		/// <para>
		/// lastIndexOf compares searchElement to the elements of the array in 
		/// descending order using the internal Strict Equality Comparison Algorithm (11.9.6), 
		/// and if found at one or more positions, returns the index of the 
		/// last such position; otherwise, -1 is returned.
		/// </para>
		/// </summary>
		/// <param name="searchElement"></param>
		/// <returns></returns>
		public extern int LastIndexOf(object searchElement);

		/// <summary>
		/// <para>
		/// lastIndexOf compares searchElement to the elements of the array in 
		/// descending order using the internal Strict Equality Comparison Algorithm (11.9.6), 
		/// and if found at one or more positions, returns the index of the 
		/// last such position; otherwise, -1 is returned.
		/// </para>
		/// <para>
		/// The optional second argument fromIndex defaults to the array's length 
		/// (i.e. the whole array is searched). 
		/// If it is greater than or equal to the length of the array, 
		/// the whole array will be searched. If it is negative, it is used as the 
		/// offset from the end of the array to compute fromIndex. 
		/// If the computed index is less than 0, -1 is returned.
		/// </para>
		/// </summary>
		/// <param name="searchElement"></param>
		/// <param name="fromIndex"></param>
		/// <returns></returns>
		public extern int LastIndexOf(object searchElement, int fromIndex);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that accepts three arguments and returns a 
		/// value that is coercible to the Boolean value true or false. 
		/// every calls callbackfn once for each element present in the array, 
		/// in ascending order, until it finds one where callbackfn returns false. 
		/// If such an element is found, every immediately returns false. 
		/// Otherwise, if callbackfn returned true for all elements, every will return true. 
		/// callbackfn is called only for elements of the array which 
		/// actually exist; it is not called for missing elements of the array.
		/// </para>
		/// <para>
		/// callbackfn is called with three arguments: the value of the element, 
		/// the index of the element, and the object being traversed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// every does not directly mutate the object on which it is called 
		/// but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by every is set before the first call to callbackfn. 
		/// Elements which are appended to the array after the call to every begins will not 
		/// be visited by callbackfn. If existing elements of the array are changed, their value 
		/// as passed to callbackfn will be the value at the time every visits them; elements 
		/// that are deleted after the call to every begins and before being visited 
		/// are not visited. every acts like the "for all" quantifier in mathematics. 
		/// In particular, for an empty array, it returns true.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern bool Every(ArrayCallbackFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that accepts three arguments and returns a value 
		/// that is coercible to the Boolean value true or false. some calls callbackfn 
		/// once for each element present in the array, in ascending order, until it 
		/// finds one where callbackfn returns true. If such an element is found, 
		/// some immediately returns true. Otherwise, some returns false. 
		/// callbackfn is called only for elements of the array which actually 
		/// exist; it is not called for missing elements of the array.
		/// </para>
		/// <para>
		/// callbackfn is called with three arguments: the value of the element, 
		/// the index of the element, and the object being traversed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// some does not directly mutate the object on which it is called but 
		/// the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by some is set before the first call 
		/// to callbackfn. Elements that are appended to the array after the call to 
		/// some begins will not be visited by callbackfn. If existing elements 
		/// of the array are changed, their value as passed to callbackfn will be 
		/// the value at the time that some visits them; elements that are deleted 
		/// after the call to some begins and before being visited are not visited. 
		/// some acts like the "exists" quantifier in mathematics. 
		/// In particular, for an empty array, it returns false.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern bool Some(ArrayCallbackFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that accepts three arguments. forEach calls callbackfn once for each element present in the array, in ascending order. callbackfn is called only for elements of the array which actually exist; it is not called for missing elements of the array.
		/// </para>
		/// <para>
		/// callbackfn is called with three arguments: the value of the element, the index of the element, and the object being traversed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// forEach does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by forEach is set before the first call to callbackfn. Elements which are appended to the array after the call to forEach begins will not be visited by callbackfn. If existing elements of the array are changed, their value as passed to callback will be the value at the time forEach visits them; elements that are deleted after the call to forEach begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		public extern void ForEach(ArrayCallbackFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that accepts three arguments. map calls callbackfn once for each element in the array, in ascending order, and constructs a new Array from the results. callbackfn is called only for elements of the array which actually exist; it is not called for missing elements of the array.
		/// </para>
		/// <para>
		/// callbackfn is called with three arguments: the value of the element, the index of the element, and the object being traversed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// map does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by map is set before the first call to callbackfn. Elements which are appended to the array after the call to map begins will not be visited by callbackfn. If existing elements of the array are changed, their value as passed to callbackfn will be the value at the time map visits them; elements that are deleted after the call to map begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern JsArray Map(ArrayMapFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that accepts three arguments and returns a value that is coercible to the Boolean value true or false. filter calls callbackfn once for each element in the array, in ascending order, and constructs a new array of all the values for which callbackfn returns true. callbackfn is called only for elements of the array which actually exist; it is not called for missing elements of the array.
		/// </para>
		/// <para>
		/// callbackfn is called with three arguments: the value of the element, the index of the element, and the object being traversed.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// filter does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by filter is set before the first call to callbackfn. Elements which are appended to the array after the call to filter begins will not be visited by callbackfn. If existing elements of the array are changed their value as passed to callbackfn will be the value at the time filter visits them; elements that are deleted after the call to filter begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern JsArray Filter(ArrayCallbackFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that takes four arguments. reduce calls the callback, as a function, once for each element present in the array, in ascending order.
		/// </para>
		/// <para>
		/// callbackfn is called with four arguments: the previousValue (or value from the previous call to callbackfn), the currentValue (value of the current element), the currentIndex, and the object being traversed. The first time that callback is called, the previousValue and currentValue can be one of two values. If an initialValue was provided in the call to reduce, then previousValue will be equal to initialValue and currentValue will be equal to the first value in the array. If no initialValue was provided, then previousValue will be equal to the first value in the array and currentValue will be equal to the second. It is a TypeError if the array contains no elements and initialValue is not provided.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// reduce does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by reduce is set before the first call to callbackfn. Elements that are appended to the array after the call to reduce begins will not be visited by callbackfn. If existing elements of the array are changed, their value as passed to callbackfn will be the value at the time reduce visits them; elements that are deleted after the call to filter begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern object Reduce(ArrayReduceFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that takes four arguments. reduce calls the callback, as a function, once for each element present in the array, in ascending order.
		/// </para>
		/// <para>
		/// callbackfn is called with four arguments: the previousValue (or value from the previous call to callbackfn), the currentValue (value of the current element), the currentIndex, and the object being traversed. The first time that callback is called, the previousValue and currentValue can be one of two values. If an initialValue was provided in the call to reduce, then previousValue will be equal to initialValue and currentValue will be equal to the first value in the array. If no initialValue was provided, then previousValue will be equal to the first value in the array and currentValue will be equal to the second. It is a TypeError if the array contains no elements and initialValue is not provided.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// reduce does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by reduce is set before the first call to callbackfn. Elements that are appended to the array after the call to reduce begins will not be visited by callbackfn. If existing elements of the array are changed, their value as passed to callbackfn will be the value at the time reduce visits them; elements that are deleted after the call to filter begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <param name="initialValue"></param>
		/// <returns></returns>
		public extern object Reduce(ArrayReduceFn callback, object initialValue);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that takes four arguments. reduceRight calls the callback, as a function, once for each element present in the array, in descending order.
		/// </para>
		/// <para>
		/// callbackfn is called with four arguments: the previousValue (or value from the previous call to callbackfn), the currentValue (value of the current element), the currentIndex, and the object being traversed. The first time the function is called, the previousValue and currentValue can be one of two values. If an initialValue was provided in the call to reduceRight, then previousValue will be equal to initialValue and currentValue will be equal to the last value in the array. If no initialValue was provided, then previousValue will be equal to the last value in the array and currentValue will be equal to the second-to-last value. It is a TypeError if the array contains no elements and initialValue is not provided.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// reduceRight does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by reduceRight is set before the first call to callbackfn. Elements that are appended to the array after the call to reduceRight begins will not be visited by callbackfn. If existing elements of the array are changed by callbackfn, their value as passed to callbackfn will be the value at the time reduceRight visits them; elements that are deleted after the call to filter begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern object ReduceRight(ArrayReduceFn callback);

		/// <summary>
		/// <para>
		/// callbackfn should be a function that takes four arguments. reduceRight calls the callback, as a function, once for each element present in the array, in descending order.
		/// </para>
		/// <para>
		/// callbackfn is called with four arguments: the previousValue (or value from the previous call to callbackfn), the currentValue (value of the current element), the currentIndex, and the object being traversed. The first time the function is called, the previousValue and currentValue can be one of two values. If an initialValue was provided in the call to reduceRight, then previousValue will be equal to initialValue and currentValue will be equal to the last value in the array. If no initialValue was provided, then previousValue will be equal to the last value in the array and currentValue will be equal to the second-to-last value. It is a TypeError if the array contains no elements and initialValue is not provided.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// reduceRight does not directly mutate the object on which it is called but the object may be mutated by the calls to callbackfn.
		/// </para>
		/// <para>
		/// The range of elements processed by reduceRight is set before the first call to callbackfn. Elements that are appended to the array after the call to reduceRight begins will not be visited by callbackfn. If existing elements of the array are changed by callbackfn, their value as passed to callbackfn will be the value at the time reduceRight visits them; elements that are deleted after the call to filter begins and before being visited are not visited.
		/// </para>
		/// </remarks>
		/// <param name="callback"></param>
		/// <param name="initialValue"></param>
		/// <returns></returns>
		public extern object ReduceRight(ArrayReduceFn callback, object initialValue);
	}
}
