using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Creates draggable splitter bar functionality from two elements (element to be dragged and element to be resized).
	///     <br><br>
	///     Usage:
	///     <pre><code>
	///     var split = new Ext.SplitBar("elementToDrag", "elementToSize",
	///     Ext.SplitBar.HORIZONTAL, Ext.SplitBar.LEFT);
	///     split.setAdapter(new Ext.SplitBar.AbsoluteLayoutAdapter("container"));
	///     split.minSize = 100;
	///     split.maxSize = 600;
	///     split.animate = true;
	///     split.on('moved', splitterMoved);
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\SplitBar.js</jssource>
	public class SplitBarClass : Ext.util.Observable {

		/// <summary>
		///     Create a new SplitBar
		///     Ext.SplitBar.TOP or Ext.SplitBar.BOTTOM for vertical. (By default, this is determined automatically by the initial
		///     position of the SplitBar).
		/// </summary>
		/// <returns></returns>
		public extern SplitBarClass();
		/// <summary>
		///     Create a new SplitBar
		///     Ext.SplitBar.TOP or Ext.SplitBar.BOTTOM for vertical. (By default, this is determined automatically by the initial
		///     position of the SplitBar).
		/// </summary>
		/// <param name="dragElement">The element to be dragged and act as the SplitBar.</param>
		/// <returns></returns>
		public extern SplitBarClass(object dragElement);
		/// <summary>
		///     Create a new SplitBar
		///     Ext.SplitBar.TOP or Ext.SplitBar.BOTTOM for vertical. (By default, this is determined automatically by the initial
		///     position of the SplitBar).
		/// </summary>
		/// <param name="dragElement">The element to be dragged and act as the SplitBar.</param>
		/// <param name="resizingElement">The element to be resized based on where the SplitBar element is dragged</param>
		/// <returns></returns>
		public extern SplitBarClass(object dragElement, object resizingElement);
		/// <summary>
		///     Create a new SplitBar
		///     Ext.SplitBar.TOP or Ext.SplitBar.BOTTOM for vertical. (By default, this is determined automatically by the initial
		///     position of the SplitBar).
		/// </summary>
		/// <param name="dragElement">The element to be dragged and act as the SplitBar.</param>
		/// <param name="resizingElement">The element to be resized based on where the SplitBar element is dragged</param>
		/// <param name="orientation">(optional) Either Ext.SplitBar.HORIZONTAL or Ext.SplitBar.VERTICAL. (Defaults to HORIZONTAL)</param>
		/// <returns></returns>
		public extern SplitBarClass(object dragElement, object resizingElement, double orientation);
		/// <summary>
		///     Create a new SplitBar
		///     Ext.SplitBar.TOP or Ext.SplitBar.BOTTOM for vertical. (By default, this is determined automatically by the initial
		///     position of the SplitBar).
		/// </summary>
		/// <param name="dragElement">The element to be dragged and act as the SplitBar.</param>
		/// <param name="resizingElement">The element to be resized based on where the SplitBar element is dragged</param>
		/// <param name="orientation">(optional) Either Ext.SplitBar.HORIZONTAL or Ext.SplitBar.VERTICAL. (Defaults to HORIZONTAL)</param>
		/// <param name="placement">(optional) Either Ext.SplitBar.LEFT or Ext.SplitBar.RIGHT for horizontal or</param>
		/// <returns></returns>
		public extern SplitBarClass(object dragElement, object resizingElement, double orientation, double placement);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static SplitBarClass prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>The minimum size of the resizing element. (Defaults to 0)</summary>
		public extern double minSize { get; set; }

		/// <summary>The maximum size of the resizing element. (Defaults to 2000)</summary>
		public extern double maxSize { get; set; }

		/// <summary>Whether to animate the transition to the new size</summary>
		public extern bool animate { get; set; }

		/// <summary>Whether to create a transparent shim that overlays the page when dragging, enables dragging across iframes.</summary>
		public extern bool useShim { get; set; }


		/// <summary>Get the adapter this SplitBar uses</summary>
		/// <returns>The</returns>
		public extern virtual void getAdapter();

		/// <summary>Set the adapter this SplitBar uses</summary>
		/// <returns></returns>
		public extern virtual void setAdapter();

		/// <summary>Set the adapter this SplitBar uses</summary>
		/// <param name="adapter">A SplitBar adapter object</param>
		/// <returns></returns>
		public extern virtual void setAdapter(object adapter);

		/// <summary>Gets the minimum size for the resizing element</summary>
		/// <returns>Number</returns>
		public extern virtual void getMinimumSize();

		/// <summary>Sets the minimum size for the resizing element</summary>
		/// <returns></returns>
		public extern virtual void setMinimumSize();

		/// <summary>Sets the minimum size for the resizing element</summary>
		/// <param name="minSize">The minimum size</param>
		/// <returns></returns>
		public extern virtual void setMinimumSize(double minSize);

		/// <summary>Gets the maximum size for the resizing element</summary>
		/// <returns>Number</returns>
		public extern virtual void getMaximumSize();

		/// <summary>Sets the maximum size for the resizing element</summary>
		/// <returns></returns>
		public extern virtual void setMaximumSize();

		/// <summary>Sets the maximum size for the resizing element</summary>
		/// <param name="maxSize">The maximum size</param>
		/// <returns></returns>
		public extern virtual void setMaximumSize(double maxSize);

		/// <summary>Sets the initialize size for the resizing element</summary>
		/// <returns></returns>
		public extern virtual void setCurrentSize();

		/// <summary>Sets the initialize size for the resizing element</summary>
		/// <param name="size">The initial size</param>
		/// <returns></returns>
		public extern virtual void setCurrentSize(double size);

		/// <summary>Destroy this splitbar.</summary>
		/// <returns></returns>
		public extern virtual void destroy();

		/// <summary>Destroy this splitbar.</summary>
		/// <param name="removeEl">True to remove the element</param>
		/// <returns></returns>
		public extern virtual void destroy(bool removeEl);



	}

	[JsAnonymous]
	public class SplitBarConfig : System.DotWeb.JsDynamic {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class SplitBarEvents {
        /// <summary>Fires when the splitter is moved (alias for {@link #event-moved})
        /// <pre><code>
        /// USAGE: ({Ext.SplitBar} objthis, {Number} newSize)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>newSize</b></term><description>the new width or height</description></item>
        /// </list>
        /// </summary>
        public static string resize { get { return "resize"; } }
        /// <summary>Fires when the splitter is moved
        /// <pre><code>
        /// USAGE: ({Ext.SplitBar} objthis, {Number} newSize)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>newSize</b></term><description>the new width or height</description></item>
        /// </list>
        /// </summary>
        public static string moved { get { return "moved"; } }
        /// <summary>Fires before the splitter is dragged
        /// <pre><code>
        /// USAGE: ({Ext.SplitBar} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforeresize { get { return "beforeresize"; } }
    }

    public delegate void SplitBarResizeDelegate(Ext.SplitBarClass objthis, double newSize);
    public delegate void SplitBarMovedDelegate(Ext.SplitBarClass objthis, double newSize);
    public delegate void SplitBarBeforeresizeDelegate(Ext.SplitBarClass objthis);
}
