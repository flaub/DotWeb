using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     Defines the default sorting (casting?) comparison functions used when sorting data.
	///     */
	///     Ext.data.SortTypes = {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\SortTypes.js</jssource>
	public class SortTypes : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern SortTypes();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static SortTypes prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The regular expression used to strip tags</summary>
		public extern static object stripTagsRE { get; set; }


		/// <summary>Default sort that does nothing</summary>
		/// <returns>Mixed</returns>
		public extern static void none();

		/// <summary>Default sort that does nothing</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Mixed</returns>
		public extern static void none(object s);

		/// <summary>Strips all HTML tags to sort on text only</summary>
		/// <returns>String</returns>
		public extern static void asText();

		/// <summary>Strips all HTML tags to sort on text only</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>String</returns>
		public extern static void asText(object s);

		/// <summary>Strips all HTML tags to sort on text only - Case insensitive</summary>
		/// <returns>String</returns>
		public extern static void asUCText();

		/// <summary>Strips all HTML tags to sort on text only - Case insensitive</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>String</returns>
		public extern static void asUCText(object s);

		/// <summary>Case insensitive string</summary>
		/// <returns>String</returns>
		public extern static void asUCString();

		/// <summary>Case insensitive string</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>String</returns>
		public extern static void asUCString(object s);

		/// <summary>Date sorting</summary>
		/// <returns>Number</returns>
		public extern static void asDate();

		/// <summary>Date sorting</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Number</returns>
		public extern static void asDate(object s);

		/// <summary>Float sorting</summary>
		/// <returns>Float</returns>
		public extern static void asFloat();

		/// <summary>Float sorting</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Float</returns>
		public extern static void asFloat(object s);

		/// <summary>Integer sorting</summary>
		/// <returns>Number</returns>
		public extern static void asInt();

		/// <summary>Integer sorting</summary>
		/// <param name="s">The value being converted</param>
		/// <returns>Number</returns>
		public extern static void asInt(object s);



	}
}
