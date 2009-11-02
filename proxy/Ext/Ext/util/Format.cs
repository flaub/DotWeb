using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Reusable data formatting functions
	///     */
	///     Ext.util.Format = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\Format.js</jssource>
	public class Format : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern Format();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Format prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
		/// <returns>String</returns>
		public extern static void ellipsis();

		/// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
		/// <param name="value">The string to truncate</param>
		/// <returns>String</returns>
		public extern static void ellipsis(string value);

		/// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
		/// <param name="value">The string to truncate</param>
		/// <param name="length">The maximum length to allow before truncating</param>
		/// <returns>String</returns>
		public extern static void ellipsis(string value, double length);

		/// <summary>Checks a reference and converts it to empty string if it is undefined</summary>
		/// <returns>Mixed</returns>
		public extern static void undef();

		/// <summary>Checks a reference and converts it to empty string if it is undefined</summary>
		/// <param name="value">Reference to check</param>
		/// <returns>Mixed</returns>
		public extern static void undef(object value);

		/// <summary>Checks a reference and converts it to the default value if it's empty</summary>
		/// <returns>String</returns>
		public extern static void defaultValue();

		/// <summary>Checks a reference and converts it to the default value if it's empty</summary>
		/// <param name="value">Reference to check</param>
		/// <returns>String</returns>
		public extern static void defaultValue(object value);

		/// <summary>Checks a reference and converts it to the default value if it's empty</summary>
		/// <param name="value">Reference to check</param>
		/// <param name="defaultValue">The value to insert of it's undefined (defaults to "")</param>
		/// <returns>String</returns>
		public extern static void defaultValue(object value, string defaultValue);

		/// <summary>Convert certain characters (&, <, >, and ') to their HTML character equivalents for literal display in web pages.</summary>
		/// <returns>String</returns>
		public extern static void htmlEncode();

		/// <summary>Convert certain characters (&, <, >, and ') to their HTML character equivalents for literal display in web pages.</summary>
		/// <param name="value">The string to encode</param>
		/// <returns>String</returns>
		public extern static void htmlEncode(string value);

		/// <summary>Convert certain characters (&, <, >, and ') from their HTML character equivalents.</summary>
		/// <returns>String</returns>
		public extern static void htmlDecode();

		/// <summary>Convert certain characters (&, <, >, and ') from their HTML character equivalents.</summary>
		/// <param name="value">The string to decode</param>
		/// <returns>String</returns>
		public extern static void htmlDecode(string value);

		/// <summary>Trims any whitespace from either side of a string</summary>
		/// <returns>String</returns>
		public extern static void trim();

		/// <summary>Trims any whitespace from either side of a string</summary>
		/// <param name="value">The text to trim</param>
		/// <returns>String</returns>
		public extern static void trim(string value);

		/// <summary>Returns a substring from within an original string</summary>
		/// <returns>String</returns>
		public extern static void substr();

		/// <summary>Returns a substring from within an original string</summary>
		/// <param name="value">The original text</param>
		/// <returns>String</returns>
		public extern static void substr(string value);

		/// <summary>Returns a substring from within an original string</summary>
		/// <param name="value">The original text</param>
		/// <param name="start">The start index of the substring</param>
		/// <returns>String</returns>
		public extern static void substr(string value, double start);

		/// <summary>Returns a substring from within an original string</summary>
		/// <param name="value">The original text</param>
		/// <param name="start">The start index of the substring</param>
		/// <param name="length">The length of the substring</param>
		/// <returns>String</returns>
		public extern static void substr(string value, double start, double length);

		/// <summary>Converts a string to all lower case letters</summary>
		/// <returns>String</returns>
		public extern static void lowercase();

		/// <summary>Converts a string to all lower case letters</summary>
		/// <param name="value">The text to convert</param>
		/// <returns>String</returns>
		public extern static void lowercase(string value);

		/// <summary>Converts a string to all upper case letters</summary>
		/// <returns>String</returns>
		public extern static void uppercase();

		/// <summary>Converts a string to all upper case letters</summary>
		/// <param name="value">The text to convert</param>
		/// <returns>String</returns>
		public extern static void uppercase(string value);

		/// <summary>Converts the first character only of a string to upper case</summary>
		/// <returns>String</returns>
		public extern static void capitalize();

		/// <summary>Converts the first character only of a string to upper case</summary>
		/// <param name="value">The text to convert</param>
		/// <returns>String</returns>
		public extern static void capitalize(string value);

		/// <summary>Format a number as US currency</summary>
		/// <returns>String</returns>
		public extern static void usMoney();

		/// <summary>Format a number as US currency</summary>
		/// <param name="value">The numeric value to format</param>
		/// <returns>String</returns>
		public extern static void usMoney(double value);

		/// <summary>Format a number as US currency</summary>
		/// <param name="value">The numeric value to format</param>
		/// <returns>String</returns>
		public extern static void usMoney(string value);

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <returns>String</returns>
		public extern static void date();

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <returns>String</returns>
		public extern static void date(string value);

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <param name="format">(optional) Any valid date format string (defaults to 'm/d/Y')</param>
		/// <returns>String</returns>
		public extern static void date(string value, string format);

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <returns>String</returns>
		public extern static void date(System.DateTime value);

		/// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
		/// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
		/// <param name="format">(optional) Any valid date format string (defaults to 'm/d/Y')</param>
		/// <returns>String</returns>
		public extern static void date(System.DateTime value, string format);

		/// <summary>Returns a date rendering function that can be reused to apply a date format multiple times efficiently</summary>
		/// <returns>Function</returns>
		public extern static void dateRenderer();

		/// <summary>Returns a date rendering function that can be reused to apply a date format multiple times efficiently</summary>
		/// <param name="format">Any valid date format string</param>
		/// <returns>Function</returns>
		public extern static void dateRenderer(string format);

		/// <summary>Strips all HTML tags</summary>
		/// <returns>String</returns>
		public extern static void stripTags();

		/// <summary>Strips all HTML tags</summary>
		/// <param name="value">The text from which to strip tags</param>
		/// <returns>String</returns>
		public extern static void stripTags(object value);

		/// <summary>Strips all script tags</summary>
		/// <returns>String</returns>
		public extern static void stripScripts();

		/// <summary>Strips all script tags</summary>
		/// <param name="value">The text from which to strip script tags</param>
		/// <returns>String</returns>
		public extern static void stripScripts(object value);

		/// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
		/// <returns>String</returns>
		public extern static void fileSize();

		/// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
		/// <param name="size">The numeric value to format</param>
		/// <returns>String</returns>
		public extern static void fileSize(double size);

		/// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
		/// <param name="size">The numeric value to format</param>
		/// <returns>String</returns>
		public extern static void fileSize(string size);



	}
}
