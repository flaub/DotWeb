using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Base class for any visual {@link Ext.Component} that uses a box container.  BoxComponent provides automatic box
	///     model adjustments for sizing and positioning and will work correctly withnin the Component rendering model.  All
	///     container classes should subclass BoxComponent so that they will work consistently when nested within other Ext
	///     layout containers.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\BoxComponent.js</jssource>
	public class BoxComponent : Ext.Component {

		/// <summary></summary>
		/// <returns></returns>
		public extern BoxComponent();
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern BoxComponent(Ext.Element config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern BoxComponent(string config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern BoxComponent(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static BoxComponent prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.Component superclass { get; set; }

		/// <summary>The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public extern double x { get; set; }

		/// <summary>The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public extern double y { get; set; }

		/// <summary>The page level x coordinate for this component if contained within a positioning container.</summary>
		public extern double pageX { get; set; }

		/// <summary>The page level y coordinate for this component if contained within a positioning container.</summary>
		public extern double pageY { get; set; }

		/// <summary>The height of this component in pixels (defaults to auto).</summary>
		public extern double height { get; set; }

		/// <summary>The width of this component in pixels (defaults to auto).</summary>
		public extern double width { get; set; }

		/// <summary>True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public extern bool autoHeight { get; set; }

		/// <summary>True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public extern bool autoWidth { get; set; }


		/// <summary>
		///     Sets the width and height of the component.  This method fires the {@link #resize} event.  This method can accept
		///     either width and height as separate numeric arguments, or you can pass a size object like {width:10, height:20}.
		/// </summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setSize();

		/// <summary>
		///     Sets the width and height of the component.  This method fires the {@link #resize} event.  This method can accept
		///     either width and height as separate numeric arguments, or you can pass a size object like {width:10, height:20}.
		/// </summary>
		/// <param name="width">The new width to set, or a size object in the format {width, height}</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setSize(double width);

		/// <summary>
		///     Sets the width and height of the component.  This method fires the {@link #resize} event.  This method can accept
		///     either width and height as separate numeric arguments, or you can pass a size object like {width:10, height:20}.
		/// </summary>
		/// <param name="width">The new width to set, or a size object in the format {width, height}</param>
		/// <param name="height">The new height to set (not required if a size object is passed as the first arg)</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setSize(double width, double height);

		/// <summary>
		///     Sets the width and height of the component.  This method fires the {@link #resize} event.  This method can accept
		///     either width and height as separate numeric arguments, or you can pass a size object like {width:10, height:20}.
		/// </summary>
		/// <param name="width">The new width to set, or a size object in the format {width, height}</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setSize(object width);

		/// <summary>
		///     Sets the width and height of the component.  This method fires the {@link #resize} event.  This method can accept
		///     either width and height as separate numeric arguments, or you can pass a size object like {width:10, height:20}.
		/// </summary>
		/// <param name="width">The new width to set, or a size object in the format {width, height}</param>
		/// <param name="height">The new height to set (not required if a size object is passed as the first arg)</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setSize(object width, double height);

		/// <summary>Sets the width of the component.  This method fires the {@link #resize} event.</summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setWidth();

		/// <summary>Sets the width of the component.  This method fires the {@link #resize} event.</summary>
		/// <param name="width">The new width to set</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setWidth(double width);

		/// <summary>Sets the height of the component.  This method fires the {@link #resize} event.</summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setHeight();

		/// <summary>Sets the height of the component.  This method fires the {@link #resize} event.</summary>
		/// <param name="height">The new height to set</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setHeight(double height);

		/// <summary>Gets the current size of the component's underlying element.</summary>
		/// <returns>Object</returns>
		public extern virtual void getSize();

		/// <summary>Gets the current XY position of the component's underlying element.</summary>
		/// <returns>Array</returns>
		public extern virtual void getPosition();

		/// <summary>Gets the current XY position of the component's underlying element.</summary>
		/// <param name="local">(optional) If true the element's left and top are returned instead of page XY (defaults to false)</param>
		/// <returns>Array</returns>
		public extern virtual void getPosition(bool local);

		/// <summary>Gets the current box measurements of the component's underlying element.</summary>
		/// <returns>Object</returns>
		public extern virtual void getBox();

		/// <summary>Gets the current box measurements of the component's underlying element.</summary>
		/// <param name="local">(optional) If true the element's left and top are returned instead of page XY (defaults to false)</param>
		/// <returns>Object</returns>
		public extern virtual void getBox(bool local);

		/// <summary>Sets the current box measurements of the component's underlying element.</summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void updateBox();

		/// <summary>Sets the current box measurements of the component's underlying element.</summary>
		/// <param name="box">An object in the format {x, y, width, height}</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void updateBox(object box);

		/// <summary>
		///     Sets the left and top of the component.  To set the page XY position instead, use {@link #setPagePosition}.
		///     This method fires the {@link #move} event.
		/// </summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setPosition();

		/// <summary>
		///     Sets the left and top of the component.  To set the page XY position instead, use {@link #setPagePosition}.
		///     This method fires the {@link #move} event.
		/// </summary>
		/// <param name="left">The new left</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setPosition(double left);

		/// <summary>
		///     Sets the left and top of the component.  To set the page XY position instead, use {@link #setPagePosition}.
		///     This method fires the {@link #move} event.
		/// </summary>
		/// <param name="left">The new left</param>
		/// <param name="top">The new top</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setPosition(double left, double top);

		/// <summary>
		///     Sets the page XY position of the component.  To set the left and top instead, use {@link #setPosition}.
		///     This method fires the {@link #move} event.
		/// </summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setPagePosition();

		/// <summary>
		///     Sets the page XY position of the component.  To set the left and top instead, use {@link #setPosition}.
		///     This method fires the {@link #move} event.
		/// </summary>
		/// <param name="x">The new x position</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setPagePosition(double x);

		/// <summary>
		///     Sets the page XY position of the component.  To set the left and top instead, use {@link #setPosition}.
		///     This method fires the {@link #move} event.
		/// </summary>
		/// <param name="x">The new x position</param>
		/// <param name="y">The new y position</param>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void setPagePosition(double x, double y);

		/// <summary>Force the component's size to recalculate based on the underlying element's current height and width.</summary>
		/// <returns>Ext.BoxComponent</returns>
		public extern virtual void syncSize();



	}

	[JsAnonymous]
	public class BoxComponentConfig : System.DotWeb.JsDynamic {
		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get { return (double)this["x"]; } set { this["x"] = value; } }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get { return (double)this["y"]; } set { this["y"] = value; } }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get { return (double)this["pageX"]; } set { this["pageX"] = value; } }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get { return (double)this["pageY"]; } set { this["pageY"] = value; } }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get { return (double)this["height"]; } set { this["height"] = value; } }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get { return (bool)this["autoHeight"]; } set { this["autoHeight"] = value; } }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get { return (bool)this["autoWidth"]; } set { this["autoWidth"] = value; } }

		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get { return (string)this["xtype"]; } set { this["xtype"] = value; } }

		/// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get { return (object)this["autoEl"]; } set { this["autoEl"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return (string)this["overCls"]; } set { this["overCls"] = value; } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return (string)this["style"]; } set { this["style"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return (string)this["ctCls"]; } set { this["ctCls"] = value; } }

		/// <summary>  Render this component disabled (default is false).</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get { return (bool)this["hidden"]; } set { this["hidden"] = value; } }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get { return (object)this["plugins"]; } set { this["plugins"] = value; } }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
		public object applyTo { get { return (object)this["applyTo"]; } set { this["applyTo"] = value; } }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get { return (object)this["renderTo"]; } set { this["renderTo"] = value; } }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get { return (bool)this["stateful"]; } set { this["stateful"] = value; } }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public string stateId { get { return (string)this["stateId"]; } set { this["stateId"] = value; } }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public string disabledClass { get { return (string)this["disabledClass"]; } set { this["disabledClass"] = value; } }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get { return (bool)this["allowDomMove"]; } set { this["allowDomMove"] = value; } }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get { return (bool)this["autoShow"]; } set { this["autoShow"] = value; } }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public string hideMode { get { return (string)this["hideMode"]; } set { this["hideMode"] = value; } }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get { return (bool)this["hideParent"]; } set { this["hideParent"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class BoxComponentEvents {
        /// <summary>Fires after the component is resized.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis, {Number} adjWidth, {Number} adjHeight, {Number} rawWidth, {Number} rawHeight)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>adjWidth</b></term><description>The box-adjusted width that was set</description></item>
        /// <item><term><b>adjHeight</b></term><description>The box-adjusted height that was set</description></item>
        /// <item><term><b>rawWidth</b></term><description>The width that was originally specified</description></item>
        /// <item><term><b>rawHeight</b></term><description>The height that was originally specified</description></item>
        /// </list>
        /// </summary>
        public static string resize { get { return "resize"; } }
        /// <summary>Fires after the component is moved.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis, {Number} x, {Number} y)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>x</b></term><description>The new x position</description></item>
        /// <item><term><b>y</b></term><description>The new y position</description></item>
        /// </list>
        /// </summary>
        public static string move { get { return "move"; } }
    }

    public delegate void BoxComponentResizeDelegate(Ext.Component objthis, double adjWidth, double adjHeight, double rawWidth, double rawHeight);
    public delegate void BoxComponentMoveDelegate(Ext.Component objthis, double x, double y);
}
