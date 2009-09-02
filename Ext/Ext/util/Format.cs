using System;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Reusable data formatting functions
	///     */
	///     Ext.util.Format = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\util\Format.js</jssource>
	public class Format : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Format() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Format prototype { get { return S_<Format>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
		/// <returns>String</returns>
		public static void ellipsis() { S_(); }

		/// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
		/// <param name="value">The string to truncate</param>
		/// <returns>String</returns>
		public static void ellipsis(System.String value) { S_(value); }

		/// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
		/// <param name="value">The string to truncate</param>
		/// <param name="length">The maximum length to allow before truncating</param>
		/// <returns>String</returns>
		public static void ellipsis(System.String value, double length) { S_(value, length); }

		/// <summary>Checks a reference and converts it to empty string if it is undefined</summary>
		/// <returns>Mixed</returns>
		public static void undef() { S_(); }

		/// <summary>Checks a reference and converts it to empty string if it is undefined</summary>
		/// <param name="value">Reference to check</param>
		/// <returns>Mixed</returns>
		public static void undef(object value) { S_(value); }

		/// <summary>Checks a reference and converts it to the default value if it's empty</summary>
		/// <returns>String</returns>
		public static void defaultValue() { S_(); }

		/// <summary>Checks a reference and converts it to the default value if it's empty</summary>
		/// <param name="value">Reference to check</param>
		/// <returns>String</returns>
		public static void defaultValue(object value) { S_(value); }

		/// <summary>Checks a reference and converts it to the default value if it's empty</summary>
		/// <param name="value">Reference to check</param>
		/// <param name="defaultValue">The value to insert of it's undefined (defaults to "")</param>
		/// <returns>String</returns>
		public static void defaultValue(object value, System.String defaultValue) { S_(value, defaultValue); }

		/// <summary>Convert certain characters (&, <, >, and ') to their HTML character equivalents for literal display in web pages.</summary>
		/// <returns>String</returns>
		public static void htmlEncode() { S_(); }

		/// <summary>Convert certain characters (&, <, >, and ') to their HTML character equivalents for literal display in web pages.</summary>
		/// <param name="value">The string to encode</param>
		/// <returns>String</returns>
		public static void htmlEncode(System.String value) { S_(value); }

		/// <summary>Convert certain characters (&, <, >, and ') from their HTML character equivalents.</summary>
		/// <returns>String</returns>
		public static void htmlDecode() { S_(); }

		/// <summary>Convert certain characters (&, <, >, and ') from their HTML character equivalents.</summary>
		/// <param name="value">The string to decode</param>
		/// <returns>String</returns>
		public static void htmlDecode(System.String value) { S_(value); }

		/// <summary>Trims any whitespace from either side of a string</summary>
		/// <returns>String</returns>
		public static void trim() { S_(); }

		/// <summary>Trims any whitespace from either side of a string</summary>
		/// <param name="value">The text to trim</param>
		/// <returns>String</returns>
		public static void trim(System.String value) { S_(value); }

		/// <summary>Returns a substring from within an original string</summary>
		/// <returns>String</returns>
		public static void substr() { S_(); }

		/// <summary>Returns a substring from within an original string</summary>
		/// <param name="value">The original text</param>
		/// <returns>String</returns>
		public static void substr(System.String value) { S_(value); }

		/// <summary>Returns a substring from within an original string</summary>
		/// <param name="value">The original text</param>
		/// <param name="start">The start index of the substring</param>
		/// <returns>String</returns>
		public static void substr(System.String value, double start) { S_(value, start); }

		/// <summary>Returns a substring from within an original string</summary>
		/// <param name="value">The original text</param>
		/// <param name="start">The start index of the substring</param>
		/// <param name="length">The length of the substring</param>
		/// <returns>String</returns>
		public static void substr(System.String value, double start, double length) { S_(value, start, length); }

		/// <summary>Converts a string to all lower case letters</summary>
		/// <returns>String</returns>
		public static void lowercase() { S_(); }

		/// <summary>Converts a string to all lower case letters</summary>
		/// <param name="value">The text to convert</param>
		/// <returns>String</returns>
		public static void lowercase(System.String value) { S_(value); }

		/// <summary>Converts a string to all upper case letters</summary>
		/// <returns>String</returns>
		public static void uppercase() { S_(); }

		/// <summary>Converts a string to all upper case letters</summary>
		/// <param name="value">The text to convert</param>
		/// <returns>String</returns>
		public static void uppercase(System.String value) { S_(value); }

		/// <summary>Converts the first character only of a string to upper case</summary>
		/// <returns>String</returns>
		public static void capitalize() { S_(); }

		/// <summary>Converts the first character only of a string to upper case</summary>
		/// <param name="value">The text to convert</param>
		/// <returns>String</returns>
		public static void capitalize(System.String value) { S_(value); }

		/// <summary>Format a number as US currency</summary>
		/// <returns>String</returns>
		public static void usMoney() { S_(); }

		/// <summary>Format a number as US currency</summary>
		/// <param name="value">The numeric value to format</param>
		/// <returns>String</returns>
		public static void usMoney(double value) { S_(value); }

		/// <summary>Format a number as US currency</summary>
		/// <param name="value">The numeric value to format</param>
		/// <returns>String</returns>
		public static void usMoney(System.String value) { S_(value); }

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <returns>String</returns>
		public static void date() { S_(); }

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <returns>String</returns>
		public static void date(System.String value) { S_(value); }

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <param name="format">(optional) Any valid date format string (defaults to 'm/d/Y')</param>
		/// <returns>String</returns>
		public static void date(System.String value, System.String format) { S_(value, format); }

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <returns>String</returns>
		public static void date(System.DateTime value) { S_(value); }

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <param name="format">(optional) Any valid date format string (defaults to 'm/d/Y')</param>
		/// <returns>String</returns>
		public static void date(System.DateTime value, System.String format) { S_(value, format); }

		/// <summary>Returns a date rendering function that can be reused to apply a date format multiple times efficiently</summary>
		/// <returns>Function</returns>
		public static void dateRenderer() { S_(); }

		/// <summary>Returns a date rendering function that can be reused to apply a date format multiple times efficiently</summary>
		/// <param name="format">Any valid date format string</param>
		/// <returns>Function</returns>
		public static void dateRenderer(System.String format) { S_(format); }

		/// <summary>Strips all HTML tags</summary>
		/// <returns>String</returns>
		public static void stripTags() { S_(); }

		/// <summary>Strips all HTML tags</summary>
		/// <param name="value">The text from which to strip tags</param>
		/// <returns>String</returns>
		public static void stripTags(object value) { S_(value); }

		/// <summary>Strips all script tags</summary>
		/// <returns>String</returns>
		public static void stripScripts() { S_(); }

		/// <summary>Strips all script tags</summary>
		/// <param name="value">The text from which to strip script tags</param>
		/// <returns>String</returns>
		public static void stripScripts(object value) { S_(value); }

		/// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
		/// <returns>String</returns>
		public static void fileSize() { S_(); }

		/// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
		/// <param name="size">The numeric value to format</param>
		/// <returns>String</returns>
		public static void fileSize(double size) { S_(size); }

		/// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
		/// <param name="size">The numeric value to format</param>
		/// <returns>String</returns>
		public static void fileSize(System.String size) { S_(size); }



	}
}
