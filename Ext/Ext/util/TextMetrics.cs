using System;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Provides precise pixel measurements for blocks of text so that you can determine exactly how high and
	///     wide, in pixels, a given block of text will be.
	///     */
	///     Ext.util.TextMetrics = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\util\TextMetrics.js</jssource>
	public class TextMetrics : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public TextMetrics() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TextMetrics prototype { get { return S_<TextMetrics>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <returns>Object</returns>
		public static void measure() { S_(); }

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <returns>Object</returns>
		public static void measure(System.String el) { S_(el); }

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <returns>Object</returns>
		public static void measure(System.String el, System.String text) { S_(el, text); }

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Object</returns>
		public static void measure(System.String el, System.String text, double fixedWidth) { S_(el, text, fixedWidth); }

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <returns>Object</returns>
		public static void measure(DOMElement el) { S_(el); }

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <returns>Object</returns>
		public static void measure(DOMElement el, System.String text) { S_(el, text); }

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Object</returns>
		public static void measure(DOMElement el, System.String text, double fixedWidth) { S_(el, text, fixedWidth); }

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public static void createInstance() { S_(); }

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public static void createInstance(System.String el) { S_(el); }

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public static void createInstance(System.String el, double fixedWidth) { S_(el, fixedWidth); }

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public static void createInstance(DOMElement el) { S_(el); }

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public static void createInstance(DOMElement el, double fixedWidth) { S_(el, fixedWidth); }

		/// <summary>Returns the size of the specified text based on the internal element's style and width properties</summary>
		/// <returns>Object</returns>
		public static void getSize() { S_(); }

		/// <summary>Returns the size of the specified text based on the internal element's style and width properties</summary>
		/// <param name="text">The text to measure</param>
		/// <returns>Object</returns>
		public static void getSize(System.String text) { S_(text); }

		/// <summary>
		///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
		///     that can affect the size of the rendered text
		/// </summary>
		/// <returns></returns>
		public static void bind() { S_(); }

		/// <summary>
		///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
		///     that can affect the size of the rendered text
		/// </summary>
		/// <param name="el">The element, dom node or id</param>
		/// <returns></returns>
		public static void bind(System.String el) { S_(el); }

		/// <summary>
		///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
		///     that can affect the size of the rendered text
		/// </summary>
		/// <param name="el">The element, dom node or id</param>
		/// <returns></returns>
		public static void bind(DOMElement el) { S_(el); }

		/// <summary>
		///     Sets a fixed width on the internal measurement element.  If the text will be multiline, you have
		///     to set a fixed width in order to accurately measure the text height.
		/// </summary>
		/// <returns></returns>
		public static void setFixedWidth() { S_(); }

		/// <summary>
		///     Sets a fixed width on the internal measurement element.  If the text will be multiline, you have
		///     to set a fixed width in order to accurately measure the text height.
		/// </summary>
		/// <param name="width">The width to set on the element</param>
		/// <returns></returns>
		public static void setFixedWidth(double width) { S_(width); }

		/// <summary>Returns the measured width of the specified text</summary>
		/// <returns>Number</returns>
		public static void getWidth() { S_(); }

		/// <summary>Returns the measured width of the specified text</summary>
		/// <param name="text">The text to measure</param>
		/// <returns>Number</returns>
		public static void getWidth(System.String text) { S_(text); }

		/// <summary>
		///     Returns the measured height of the specified text.  For multiline text, be sure to call
		///     {@link #setFixedWidth} if necessary.
		/// </summary>
		/// <returns>Number</returns>
		public static void getHeight() { S_(); }

		/// <summary>
		///     Returns the measured height of the specified text.  For multiline text, be sure to call
		///     {@link #setFixedWidth} if necessary.
		/// </summary>
		/// <param name="text">The text to measure</param>
		/// <returns>Number</returns>
		public static void getHeight(System.String text) { S_(text); }



	}
}
