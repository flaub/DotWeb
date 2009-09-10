using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     Defines the default sorting (casting?) comparison functions used when sorting data.
	///     */
	///     Ext.data.SortTypes = {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\SortTypes.js</jssource>
	public class SortTypes : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public SortTypes() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static SortTypes prototype { get { return S_<SortTypes>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The regular expression used to strip tags</summary>
		public static object stripTagsRE { get { return S_<object>(); } set { S_(value); } }


		/// <summary>Default sort that does nothing</summary>
		/// <returns>Mixed</returns>
		public static void none() { S_(); }

		/// <summary>Default sort that does nothing</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Mixed</returns>
		public static void none(object s) { S_(s); }

		/// <summary>Strips all HTML tags to sort on text only</summary>
		/// <returns>String</returns>
		public static void asText() { S_(); }

		/// <summary>Strips all HTML tags to sort on text only</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>String</returns>
		public static void asText(object s) { S_(s); }

		/// <summary>Strips all HTML tags to sort on text only - Case insensitive</summary>
		/// <returns>String</returns>
		public static void asUCText() { S_(); }

		/// <summary>Strips all HTML tags to sort on text only - Case insensitive</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>String</returns>
		public static void asUCText(object s) { S_(s); }

		/// <summary>Case insensitive string</summary>
		/// <returns>String</returns>
		public static void asUCString() { S_(); }

		/// <summary>Case insensitive string</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>String</returns>
		public static void asUCString(object s) { S_(s); }

		/// <summary>Date sorting</summary>
		/// <returns>Number</returns>
		public static void asDate() { S_(); }

		/// <summary>Date sorting</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Number</returns>
		public static void asDate(object s) { S_(s); }

		/// <summary>Float sorting</summary>
		/// <returns>Float</returns>
		public static void asFloat() { S_(); }

		/// <summary>Float sorting</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Float</returns>
		public static void asFloat(object s) { S_(s); }

		/// <summary>Integer sorting</summary>
		/// <returns>Number</returns>
		public static void asInt() { S_(); }

		/// <summary>Integer sorting</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Number</returns>
		public static void asInt(object s) { S_(s); }



	}
}
