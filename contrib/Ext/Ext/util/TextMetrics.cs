using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Provides precise pixel measurements for blocks of text so that you can determine exactly how high and
	///     wide, in pixels, a given block of text will be.
	///     */
	///     Ext.util.TextMetrics = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\TextMetrics.js</jssource>
	public class TextMetrics : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern TextMetrics();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TextMetrics prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <returns>Object</returns>
		public extern static void measure();

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <returns>Object</returns>
		public extern static void measure(string el);

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <returns>Object</returns>
		public extern static void measure(string el, string text);

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Object</returns>
		public extern static void measure(string el, string text, double fixedWidth);

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <returns>Object</returns>
		public extern static void measure(DOMElement el);

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <returns>Object</returns>
		public extern static void measure(DOMElement el, string text);

		/// <summary>
		///     Measures the size of the specified text
		///     that can affect the size of the rendered text
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
		/// <param name="text">The text to measure</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Object</returns>
		public extern static void measure(DOMElement el, string text, double fixedWidth);

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public extern static void createInstance();

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public extern static void createInstance(string el);

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public extern static void createInstance(string el, double fixedWidth);

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public extern static void createInstance(DOMElement el);

		/// <summary>
		///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
		///     the overhead of multiple calls to initialize the style properties on each measurement.
		///     in order to accurately measure the text height
		/// </summary>
		/// <param name="el">The element, dom node or id that the instance will be bound to</param>
		/// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
		/// <returns>Ext.util.TextMetrics.Instance</returns>
		public extern static void createInstance(DOMElement el, double fixedWidth);

		/// <summary>Returns the size of the specified text based on the internal element's style and width properties</summary>
		/// <returns>Object</returns>
		public extern static void getSize();

		/// <summary>Returns the size of the specified text based on the internal element's style and width properties</summary>
		/// <param name="text">The text to measure</param>
		/// <returns>Object</returns>
		public extern static void getSize(string text);

		/// <summary>
		///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
		///     that can affect the size of the rendered text
		/// </summary>
		/// <returns></returns>
		public extern static void bind();

		/// <summary>
		///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
		///     that can affect the size of the rendered text
		/// </summary>
		/// <param name="el">The element, dom node or id</param>
		/// <returns></returns>
		public extern static void bind(string el);

		/// <summary>
		///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
		///     that can affect the size of the rendered text
		/// </summary>
		/// <param name="el">The element, dom node or id</param>
		/// <returns></returns>
		public extern static void bind(DOMElement el);

		/// <summary>
		///     Sets a fixed width on the internal measurement element.  If the text will be multiline, you have
		///     to set a fixed width in order to accurately measure the text height.
		/// </summary>
		/// <returns></returns>
		public extern static void setFixedWidth();

		/// <summary>
		///     Sets a fixed width on the internal measurement element.  If the text will be multiline, you have
		///     to set a fixed width in order to accurately measure the text height.
		/// </summary>
		/// <param name="width">The width to set on the element</param>
		/// <returns></returns>
		public extern static void setFixedWidth(double width);

		/// <summary>Returns the measured width of the specified text</summary>
		/// <returns>Number</returns>
		public extern static void getWidth();

		/// <summary>Returns the measured width of the specified text</summary>
		/// <param name="text">The text to measure</param>
		/// <returns>Number</returns>
		public extern static void getWidth(string text);

		/// <summary>
		///     Returns the measured height of the specified text.  For multiline text, be sure to call
		///     {@link #setFixedWidth} if necessary.
		/// </summary>
		/// <returns>Number</returns>
		public extern static void getHeight();

		/// <summary>
		///     Returns the measured height of the specified text.  For multiline text, be sure to call
		///     {@link #setFixedWidth} if necessary.
		/// </summary>
		/// <param name="text">The text to measure</param>
		/// <returns>Number</returns>
		public extern static void getHeight(string text);



	}
}
