using System;
using DotWeb.Core;

namespace Ext.util {
    /// <summary>
    ///     /**
    ///     Reusable data formatting functions
    ///     */
    ///     Ext.util.Format = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\Format.js</jssource>
    [Native]
    public class Format  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public Format() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Format prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
        /// <returns>String</returns>
        public static System.String ellipsis() { return null; }

        /// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
        /// <param name="value">The string to truncate</param>
        /// <returns>String</returns>
        public static System.String ellipsis(System.String value) { return null; }

        /// <summary>Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length</summary>
        /// <param name="value">The string to truncate</param>
        /// <param name="length">The maximum length to allow before truncating</param>
        /// <returns>String</returns>
        public static System.String ellipsis(System.String value, double length) { return null; }

        /// <summary>Checks a reference and converts it to empty string if it is undefined</summary>
        /// <returns>Mixed</returns>
        public static object undef() { return null; }

        /// <summary>Checks a reference and converts it to empty string if it is undefined</summary>
        /// <param name="value">Reference to check</param>
        /// <returns>Mixed</returns>
        public static object undef(object value) { return null; }

        /// <summary>Checks a reference and converts it to the default value if it's empty</summary>
        /// <returns>String</returns>
        public static System.String defaultValue() { return null; }

        /// <summary>Checks a reference and converts it to the default value if it's empty</summary>
        /// <param name="value">Reference to check</param>
        /// <returns>String</returns>
        public static System.String defaultValue(object value) { return null; }

        /// <summary>Checks a reference and converts it to the default value if it's empty</summary>
        /// <param name="value">Reference to check</param>
        /// <param name="defaultValue">The value to insert of it's undefined (defaults to "")</param>
        /// <returns>String</returns>
        public static System.String defaultValue(object value, System.String defaultValue) { return null; }

        /// <summary>Convert certain characters (&, <, >, and ') to their HTML character equivalents for literal display in web pages.</summary>
        /// <returns>String</returns>
        public static System.String htmlEncode() { return null; }

        /// <summary>Convert certain characters (&, <, >, and ') to their HTML character equivalents for literal display in web pages.</summary>
        /// <param name="value">The string to encode</param>
        /// <returns>String</returns>
        public static System.String htmlEncode(System.String value) { return null; }

        /// <summary>Convert certain characters (&, <, >, and ') from their HTML character equivalents.</summary>
        /// <returns>String</returns>
        public static System.String htmlDecode() { return null; }

        /// <summary>Convert certain characters (&, <, >, and ') from their HTML character equivalents.</summary>
        /// <param name="value">The string to decode</param>
        /// <returns>String</returns>
        public static System.String htmlDecode(System.String value) { return null; }

        /// <summary>Trims any whitespace from either side of a string</summary>
        /// <returns>String</returns>
        public static System.String trim() { return null; }

        /// <summary>Trims any whitespace from either side of a string</summary>
        /// <param name="value">The text to trim</param>
        /// <returns>String</returns>
        public static System.String trim(System.String value) { return null; }

        /// <summary>Returns a substring from within an original string</summary>
        /// <returns>String</returns>
        public static System.String substr() { return null; }

        /// <summary>Returns a substring from within an original string</summary>
        /// <param name="value">The original text</param>
        /// <returns>String</returns>
        public static System.String substr(System.String value) { return null; }

        /// <summary>Returns a substring from within an original string</summary>
        /// <param name="value">The original text</param>
        /// <param name="start">The start index of the substring</param>
        /// <returns>String</returns>
        public static System.String substr(System.String value, double start) { return null; }

        /// <summary>Returns a substring from within an original string</summary>
        /// <param name="value">The original text</param>
        /// <param name="start">The start index of the substring</param>
        /// <param name="length">The length of the substring</param>
        /// <returns>String</returns>
        public static System.String substr(System.String value, double start, double length) { return null; }

        /// <summary>Converts a string to all lower case letters</summary>
        /// <returns>String</returns>
        public static System.String lowercase() { return null; }

        /// <summary>Converts a string to all lower case letters</summary>
        /// <param name="value">The text to convert</param>
        /// <returns>String</returns>
        public static System.String lowercase(System.String value) { return null; }

        /// <summary>Converts a string to all upper case letters</summary>
        /// <returns>String</returns>
        public static System.String uppercase() { return null; }

        /// <summary>Converts a string to all upper case letters</summary>
        /// <param name="value">The text to convert</param>
        /// <returns>String</returns>
        public static System.String uppercase(System.String value) { return null; }

        /// <summary>Converts the first character only of a string to upper case</summary>
        /// <returns>String</returns>
        public static System.String capitalize() { return null; }

        /// <summary>Converts the first character only of a string to upper case</summary>
        /// <param name="value">The text to convert</param>
        /// <returns>String</returns>
        public static System.String capitalize(System.String value) { return null; }

        /// <summary>Format a number as US currency</summary>
        /// <returns>String</returns>
        public static System.String usMoney() { return null; }

        /// <summary>Format a number as US currency</summary>
        /// <param name="value">The numeric value to format</param>
        /// <returns>String</returns>
        public static System.String usMoney(double value) { return null; }

        /// <summary>Format a number as US currency</summary>
        /// <param name="value">The numeric value to format</param>
        /// <returns>String</returns>
        public static System.String usMoney(System.String value) { return null; }

        /// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
        /// <returns>String</returns>
        public static System.String date() { return null; }

        /// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
        /// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
        /// <returns>String</returns>
        public static System.String date(System.String value) { return null; }

        /// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
        /// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
        /// <param name="format">(optional) Any valid date format string (defaults to 'm/d/Y')</param>
        /// <returns>String</returns>
        public static System.String date(System.String value, System.String format) { return null; }

        /// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
        /// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
        /// <returns>String</returns>
        public static System.String date(System.DateTime value) { return null; }

        /// <summary>Parse a value into a formatted date using the specified format pattern.</summary>
        /// <param name="value">The value to format (Strings must conform to the format expected by the javascript Date object's <a href="http://www.w3schools.com/jsref/jsref_parse.asp">parse()</a> method)</param>
        /// <param name="format">(optional) Any valid date format string (defaults to 'm/d/Y')</param>
        /// <returns>String</returns>
        public static System.String date(System.DateTime value, System.String format) { return null; }

        /// <summary>Returns a date rendering function that can be reused to apply a date format multiple times efficiently</summary>
        /// <returns>Function</returns>
        public static Delegate dateRenderer() { return null; }

        /// <summary>Returns a date rendering function that can be reused to apply a date format multiple times efficiently</summary>
        /// <param name="format">Any valid date format string</param>
        /// <returns>Function</returns>
        public static Delegate dateRenderer(System.String format) { return null; }

        /// <summary>Strips all HTML tags</summary>
        /// <returns>String</returns>
        public static System.String stripTags() { return null; }

        /// <summary>Strips all HTML tags</summary>
        /// <param name="value">The text from which to strip tags</param>
        /// <returns>String</returns>
        public static System.String stripTags(object value) { return null; }

        /// <summary>Strips all script tags</summary>
        /// <returns>String</returns>
        public static System.String stripScripts() { return null; }

        /// <summary>Strips all script tags</summary>
        /// <param name="value">The text from which to strip script tags</param>
        /// <returns>String</returns>
        public static System.String stripScripts(object value) { return null; }

        /// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
        /// <returns>String</returns>
        public static System.String fileSize() { return null; }

        /// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
        /// <param name="size">The numeric value to format</param>
        /// <returns>String</returns>
        public static System.String fileSize(double size) { return null; }

        /// <summary>Simple format for a file size (xxx bytes, xxx KB, xxx MB)</summary>
        /// <param name="size">The numeric value to format</param>
        /// <returns>String</returns>
        public static System.String fileSize(System.String size) { return null; }



    }
    [Anonymous]
    public class FormatConfig {

    }


}
