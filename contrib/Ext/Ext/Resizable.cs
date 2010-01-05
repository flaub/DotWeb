using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Applies drag handles to an element to make it resizable. The drag handles are inserted into the element
	///     and positioned absolute. Some elements, such as a textarea or image, don't support this. To overcome that, you can wrap
	///     the textarea in a div and set "resizeChild" to true (or to the id of the element), <b>or</b> set wrap:true in your config and
	///     the element will be wrapped for you automatically.</p>
	///     <p>Here is the list of valid resize handles:</p>
	///     <pre>
	///     Value   Description
	///     ------  -------------------
	///     'n'     north
	///     's'     south
	///     'e'     east
	///     'w'     west
	///     'nw'    northwest
	///     'sw'    southwest
	///     'se'    southeast
	///     'ne'    northeast
	///     'all'   all
	///     </pre>
	///     <p>Here's an example showing the creation of a typical Resizable:</p>
	///     <pre><code>
	///     var resizer = new Ext.Resizable("element-id", {
	///     handles: 'all',
	///     minWidth: 200,
	///     minHeight: 100,
	///     maxWidth: 500,
	///     maxHeight: 400,
	///     pinned: true
	///     });
	///     resizer.on("resize", myHandler);
	///     </code></pre>
	///     <p>To hide a particular handle, set its display to none in CSS, or through script:<br>
	///     resizer.east.setDisplayed(false);</p>
	///     @cfg {Boolean/String/Element} resizeChild True to resize the first child, or id/element to resize (defaults to false)
	///     @cfg {Array/String} adjustments String "auto" or an array [width, height] with values to be <b>added</b> to the
	///     resize operation's new size (defaults to [0, 0])
	///     @cfg {Number} minWidth The minimum width for the element (defaults to 5)
	///     @cfg {Number} minHeight The minimum height for the element (defaults to 5)
	///     @cfg {Number} maxWidth The maximum width for the element (defaults to 10000)
	///     @cfg {Number} maxHeight The maximum height for the element (defaults to 10000)
	///     @cfg {Boolean} enabled False to disable resizing (defaults to true)
	///     @cfg {Boolean} wrap True to wrap an element with a div if needed (required for textareas and images, defaults to false)
	///     @cfg {Number} width The width of the element in pixels (defaults to null)
	///     @cfg {Number} height The height of the element in pixels (defaults to null)
	///     @cfg {Boolean} animate True to animate the resize (not compatible with dynamic sizing, defaults to false)
	///     @cfg {Number} duration Animation duration if animate = true (defaults to .35)
	///     @cfg {Boolean} dynamic True to resize the element while dragging instead of using a proxy (defaults to false)
	///     @cfg {String} handles String consisting of the resize handles to display (defaults to undefined)
	///     @cfg {Boolean} multiDirectional <b>Deprecated</b>.  The old style of adding multi-direction resize handles, deprecated
	///     in favor of the handles config option (defaults to false)
	///     @cfg {Boolean} disableTrackOver True to disable mouse tracking. This is only applied at config time. (defaults to false)
	///     @cfg {String} easing Animation easing if animate = true (defaults to 'easingOutStrong')
	///     @cfg {Number} widthIncrement The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)
	///     @cfg {Number} heightIncrement The increment to snap the height resize in pixels (dynamic must be true, defaults to 0)
	///     @cfg {Boolean} pinned True to ensure that the resize handles are always visible, false to display them only when the
	///     user mouses over the resizable borders. This is only applied at config time. (defaults to false)
	///     @cfg {Boolean} preserveRatio True to preserve the original ratio between height and width during resize (defaults to false)
	///     @cfg {Boolean} transparent True for transparent handles. This is only applied at config time. (defaults to false)
	///     @cfg {Number} minX The minimum allowed page X for the element (only used for west resizing, defaults to 0)
	///     @cfg {Number} minY The minimum allowed page Y for the element (only used for north resizing, defaults to 0)
	///     @cfg {Boolean} draggable Convenience to initialize drag drop (defaults to false)
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Resizable.js</jssource>
	public class Resizable : Ext.util.Observable {

		/// <summary>Create a new resizable component</summary>
		/// <returns></returns>
		public extern Resizable();
		/// <summary>Create a new resizable component</summary>
		/// <param name="el">The id or element to resize</param>
		/// <returns></returns>
		public extern Resizable(object el);
		/// <summary>Create a new resizable component</summary>
		/// <param name="el">The id or element to resize</param>
		/// <param name="config">configuration options</param>
		/// <returns></returns>
		public extern Resizable(object el, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Resizable prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>
		///     The proxy Element that is resized in place of the real Element during the resize operation.
		///     This may be queried using {@link Ext.Element#getBox} to provide the new area to resize to.
		///     Read only.
		/// </summary>
		public extern Ext.Element proxy { get; set; }

		/// <summary>Constrain the resize to a particular element</summary>
		public extern object constrainTo { get; set; }

		/// <summary>Constrain the resize to a particular region</summary>
		public extern object resizeRegion { get; set; }


		/// <summary>Perform a manual resize</summary>
		/// <returns></returns>
		public extern virtual void resizeTo();

		/// <summary>Perform a manual resize</summary>
		/// <param name="width"></param>
		/// <returns></returns>
		public extern virtual void resizeTo(double width);

		/// <summary>Perform a manual resize</summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		public extern virtual void resizeTo(double width, double height);

		/// <summary>
		///     <p>Performs resizing of the associated Element. This method is called internally by this
		///     class, and should not be called by user code.</p>
		///     <p>If a Resizable is being used to resize an Element which encapsulates a more complex UI
		///     component such as a Panel, this method may be overridden by specifying an implementation
		///     as a config option to provide appropriate behaviour at the end of the resize operation on
		///     mouseup, for example resizing the Panel, and relaying the Panel's content.</p>
		///     <p>The new area to be resized to is available by examining the state of the {@link #proxy}
		///     Element. Example:
		///     <pre><code>
		///     new Ext.Panel({
		///     title: 'Resize me',
		///     x: 100,
		///     y: 100,
		///     renderTo: Ext.getBody(),
		///     floating: true,
		///     frame: true,
		///     width: 400,
		///     height: 200,
		///     listeners: {
		///     render: function(p) {
		///     new Ext.Resizable(p.getEl(), {
		///     handles: 'all',
		///     pinned: true,
		///     transparent: true,
		///     resizeElement: function() {
		///     var box = this.proxy.getBox();
		///     p.updateBox(box);
		///     if (p.layout) {
		///     p.doLayout();
		///     }
		///     return box;
		///     }
		///     });
		///     }
		///     }
		///     }).show();
		///     </code></pre>
		/// </summary>
		/// <returns></returns>
		public extern virtual void resizeElement();

		/// <summary>Returns the element this component is bound to.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void getEl();

		/// <summary>Returns the resizeChild element (or null).</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void getResizeChild();

		/// <summary>
		///     Destroys this resizable. If the element was wrapped and
		///     removeEl is not true then the element remains.
		/// </summary>
		/// <returns></returns>
		public extern virtual void destroy();

		/// <summary>
		///     Destroys this resizable. If the element was wrapped and
		///     removeEl is not true then the element remains.
		/// </summary>
		/// <param name="removeEl">(optional) true to remove the element from the DOM</param>
		/// <returns></returns>
		public extern virtual void destroy(bool removeEl);



	}

	[JsAnonymous]
	public class ResizableConfig : System.DotWeb.JsDynamic {
		/// <summary>{Boolean/String/Element} True to resize the first child, or id/element to resize (defaults to false)</summary>
		public object resizeChild { get { return (object)this["resizeChild"]; } set { this["resizeChild"] = value; } }

		/// <summary>{Array/String} String "auto" or an array [width, height] with values to be <b>added</b> to the</summary>
		public object adjustments { get { return (object)this["adjustments"]; } set { this["adjustments"] = value; } }

		/// <summary> The minimum width for the element (defaults to 5)</summary>
		public double minWidth { get { return (double)this["minWidth"]; } set { this["minWidth"] = value; } }

		/// <summary> The minimum height for the element (defaults to 5)</summary>
		public double minHeight { get { return (double)this["minHeight"]; } set { this["minHeight"] = value; } }

		/// <summary> The maximum width for the element (defaults to 10000)</summary>
		public double maxWidth { get { return (double)this["maxWidth"]; } set { this["maxWidth"] = value; } }

		/// <summary> The maximum height for the element (defaults to 10000)</summary>
		public double maxHeight { get { return (double)this["maxHeight"]; } set { this["maxHeight"] = value; } }

		/// <summary> False to disable resizing (defaults to true)</summary>
		public bool enabled { get { return (bool)this["enabled"]; } set { this["enabled"] = value; } }

		/// <summary> True to wrap an element with a div if needed (required for textareas and images, defaults to false)</summary>
		public bool wrap { get { return (bool)this["wrap"]; } set { this["wrap"] = value; } }

		/// <summary> The width of the element in pixels (defaults to null)</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary> The height of the element in pixels (defaults to null)</summary>
		public double height { get { return (double)this["height"]; } set { this["height"] = value; } }

		/// <summary> True to animate the resize (not compatible with dynamic sizing, defaults to false)</summary>
		public bool animate { get { return (bool)this["animate"]; } set { this["animate"] = value; } }

		/// <summary> Animation duration if animate = true (defaults to .35)</summary>
		public double duration { get { return (double)this["duration"]; } set { this["duration"] = value; } }

		/// <summary> True to resize the element while dragging instead of using a proxy (defaults to false)</summary>
		public bool dynamic { get { return (bool)this["dynamic"]; } set { this["dynamic"] = value; } }

		/// <summary> String consisting of the resize handles to display (defaults to undefined)</summary>
		public string handles { get { return (string)this["handles"]; } set { this["handles"] = value; } }

		/// <summary> <b>Deprecated</b>.  The old style of adding multi-direction resize handles, deprecated</summary>
		public bool multiDirectional { get { return (bool)this["multiDirectional"]; } set { this["multiDirectional"] = value; } }

		/// <summary> True to disable mouse tracking. This is only applied at config time. (defaults to false)</summary>
		public bool disableTrackOver { get { return (bool)this["disableTrackOver"]; } set { this["disableTrackOver"] = value; } }

		/// <summary> Animation easing if animate = true (defaults to 'easingOutStrong')</summary>
		public string easing { get { return (string)this["easing"]; } set { this["easing"] = value; } }

		/// <summary> The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)</summary>
		public double widthIncrement { get { return (double)this["widthIncrement"]; } set { this["widthIncrement"] = value; } }

		/// <summary> The increment to snap the height resize in pixels (dynamic must be true, defaults to 0)</summary>
		public double heightIncrement { get { return (double)this["heightIncrement"]; } set { this["heightIncrement"] = value; } }

		/// <summary> True to ensure that the resize handles are always visible, false to display them only when the</summary>
		public bool pinned { get { return (bool)this["pinned"]; } set { this["pinned"] = value; } }

		/// <summary> True to preserve the original ratio between height and width during resize (defaults to false)</summary>
		public bool preserveRatio { get { return (bool)this["preserveRatio"]; } set { this["preserveRatio"] = value; } }

		/// <summary> True for transparent handles. This is only applied at config time. (defaults to false)</summary>
		public bool transparent { get { return (bool)this["transparent"]; } set { this["transparent"] = value; } }

		/// <summary> The minimum allowed page X for the element (only used for west resizing, defaults to 0)</summary>
		public double minX { get { return (double)this["minX"]; } set { this["minX"] = value; } }

		/// <summary> The minimum allowed page Y for the element (only used for north resizing, defaults to 0)</summary>
		public double minY { get { return (double)this["minY"]; } set { this["minY"] = value; } }

		/// <summary> Convenience to initialize drag drop (defaults to false)</summary>
		public bool draggable { get { return (bool)this["draggable"]; } set { this["draggable"] = value; } }

		/// <summary> Constrain the resize to a particular element</summary>
		public object constrainTo { get { return (object)this["constrainTo"]; } set { this["constrainTo"] = value; } }

		/// <summary> Constrain the resize to a particular region</summary>
		public object resizeRegion { get { return (object)this["resizeRegion"]; } set { this["resizeRegion"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class ResizableEvents {
        /// <summary>Fired before resize is allowed. Set enabled to false to cancel resize.
        /// <pre><code>
        /// USAGE: ({Ext.Resizable} objthis, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description>The mousedown event</description></item>
        /// </list>
        /// </summary>
        public static string beforeresize { get { return "beforeresize"; } }
        /// <summary>Fired after a resize.
        /// <pre><code>
        /// USAGE: ({Ext.Resizable} objthis, {Number} width, {Number} height, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>width</b></term><description>The new width</description></item>
        /// <item><term><b>height</b></term><description>The new height</description></item>
        /// <item><term><b>e</b></term><description>The mouseup event</description></item>
        /// </list>
        /// </summary>
        public static string resize { get { return "resize"; } }
    }

    public delegate void ResizableBeforeresizeDelegate(Ext.Resizable objthis, Ext.EventObject e);
    public delegate void ResizableResizeDelegate(Ext.Resizable objthis, double width, double height, Ext.EventObject e);
}
