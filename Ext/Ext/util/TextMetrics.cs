using System;
using DotWeb.Core;

namespace Ext.util {
    /// <summary>
    ///     /**
    ///     Provides precise pixel measurements for blocks of text so that you can determine exactly how high and
    ///     wide, in pixels, a given block of text will be.
    ///     */
    ///     Ext.util.TextMetrics = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\TextMetrics.js</jssource>
    [Native]
    public class TextMetrics  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public TextMetrics() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TextMetrics prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <returns>Object</returns>
        public static object measure() { return null; }

        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
        /// <returns>Object</returns>
        public static object measure(System.String el) { return null; }

        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
        /// <param name="text">The text to measure</param>
        /// <returns>Object</returns>
        public static object measure(System.String el, System.String text) { return null; }

        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
        /// <param name="text">The text to measure</param>
        /// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
        /// <returns>Object</returns>
        public static object measure(System.String el, System.String text, double fixedWidth) { return null; }

        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
        /// <returns>Object</returns>
        public static object measure(DOMElement el) { return null; }

        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
        /// <param name="text">The text to measure</param>
        /// <returns>Object</returns>
        public static object measure(DOMElement el, System.String text) { return null; }

        /// <summary>
        ///     Measures the size of the specified text
        ///     that can affect the size of the rendered text
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id from which to copy existing CSS styles</param>
        /// <param name="text">The text to measure</param>
        /// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
        /// <returns>Object</returns>
        public static object measure(DOMElement el, System.String text, double fixedWidth) { return null; }

        /// <summary>
        ///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
        ///     the overhead of multiple calls to initialize the style properties on each measurement.
        ///     in order to accurately measure the text height
        /// </summary>
        /// <returns>Ext.util.TextMetrics.Instance</returns>
        public static Ext.util.TextMetrics createInstance() { return null; }

        /// <summary>
        ///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
        ///     the overhead of multiple calls to initialize the style properties on each measurement.
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id that the instance will be bound to</param>
        /// <returns>Ext.util.TextMetrics.Instance</returns>
        public static Ext.util.TextMetrics createInstance(System.String el) { return null; }

        /// <summary>
        ///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
        ///     the overhead of multiple calls to initialize the style properties on each measurement.
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id that the instance will be bound to</param>
        /// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
        /// <returns>Ext.util.TextMetrics.Instance</returns>
        public static Ext.util.TextMetrics createInstance(System.String el, double fixedWidth) { return null; }

        /// <summary>
        ///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
        ///     the overhead of multiple calls to initialize the style properties on each measurement.
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id that the instance will be bound to</param>
        /// <returns>Ext.util.TextMetrics.Instance</returns>
        public static Ext.util.TextMetrics createInstance(DOMElement el) { return null; }

        /// <summary>
        ///     Return a unique TextMetrics instance that can be bound directly to an element and reused.  This reduces
        ///     the overhead of multiple calls to initialize the style properties on each measurement.
        ///     in order to accurately measure the text height
        /// </summary>
        /// <param name="el">The element, dom node or id that the instance will be bound to</param>
        /// <param name="fixedWidth">(optional) If the text will be multiline, you have to set a fixed width</param>
        /// <returns>Ext.util.TextMetrics.Instance</returns>
        public static Ext.util.TextMetrics createInstance(DOMElement el, double fixedWidth) { return null; }

        /// <summary>Returns the size of the specified text based on the internal element's style and width properties</summary>
        /// <returns>Object</returns>
        public static object getSize() { return null; }

        /// <summary>Returns the size of the specified text based on the internal element's style and width properties</summary>
        /// <param name="text">The text to measure</param>
        /// <returns>Object</returns>
        public static object getSize(System.String text) { return null; }

        /// <summary>
        ///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
        ///     that can affect the size of the rendered text
        /// </summary>
        /// <returns></returns>
        public static void bind() { return ; }

        /// <summary>
        ///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
        ///     that can affect the size of the rendered text
        /// </summary>
        /// <param name="el">The element, dom node or id</param>
        /// <returns></returns>
        public static void bind(System.String el) { return ; }

        /// <summary>
        ///     Binds this TextMetrics instance to an element from which to copy existing CSS styles
        ///     that can affect the size of the rendered text
        /// </summary>
        /// <param name="el">The element, dom node or id</param>
        /// <returns></returns>
        public static void bind(DOMElement el) { return ; }

        /// <summary>
        ///     Sets a fixed width on the internal measurement element.  If the text will be multiline, you have
        ///     to set a fixed width in order to accurately measure the text height.
        /// </summary>
        /// <returns></returns>
        public static void setFixedWidth() { return ; }

        /// <summary>
        ///     Sets a fixed width on the internal measurement element.  If the text will be multiline, you have
        ///     to set a fixed width in order to accurately measure the text height.
        /// </summary>
        /// <param name="width">The width to set on the element</param>
        /// <returns></returns>
        public static void setFixedWidth(double width) { return ; }

        /// <summary>Returns the measured width of the specified text</summary>
        /// <returns>Number</returns>
        public static double getWidth() { return 0; }

        /// <summary>Returns the measured width of the specified text</summary>
        /// <param name="text">The text to measure</param>
        /// <returns>Number</returns>
        public static double getWidth(System.String text) { return 0; }

        /// <summary>
        ///     Returns the measured height of the specified text.  For multiline text, be sure to call
        ///     {@link #setFixedWidth} if necessary.
        /// </summary>
        /// <returns>Number</returns>
        public static double getHeight() { return 0; }

        /// <summary>
        ///     Returns the measured height of the specified text.  For multiline text, be sure to call
        ///     {@link #setFixedWidth} if necessary.
        /// </summary>
        /// <param name="text">The text to measure</param>
        /// <returns>Number</returns>
        public static double getHeight(System.String text) { return 0; }



    }
    [Anonymous]
    public class TextMetricsConfig {

    }


}
