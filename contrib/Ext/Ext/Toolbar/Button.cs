using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.Toolbar {
	/// <summary>
	///     /**
	///     A button that renders into a toolbar. Use the <tt>handler</tt> config to specify a callback function
	///     to handle the button's click event.
	///     <pre><code>
	///     new Ext.Panel({
	///     tbar : [
	///     {text: 'OK', handler: okHandler} // tbbutton is the default xtype if not specified
	///     ]
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Button : Ext.Button {

		/// <summary>Creates a new Button</summary>
		/// <returns></returns>
		public extern Button();
		/// <summary>Creates a new Button</summary>
		/// <param name="config">A standard {@link Ext.Button} config object</param>
		/// <returns></returns>
		public extern Button(object config);
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public extern Button(Ext.Element config);
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public extern Button(string config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Button prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.Button superclass { get; set; }




	}

	[JsAnonymous]
	public class ButtonConfig : System.DotWeb.JsDynamic {
		/// <summary> The button text</summary>
		public string text { get { return (string)this["text"]; } set { this["text"] = value; } }

		/// <summary> The path to an image to display in the button (the image will be set as the background-image</summary>
		public string icon { get { return (string)this["icon"]; } set { this["icon"] = value; } }

		/// <summary> A function called when the button is clicked (can be used instead of click event)</summary>
		public Delegate handler { get { return (Delegate)this["handler"]; } set { this["handler"] = value; } }

		/// <summary> The scope of the handler</summary>
		public object scope { get { return (object)this["scope"]; } set { this["scope"] = value; } }

		/// <summary> The minimum width for this button (used to give a set of buttons a common width)</summary>
		public double minWidth { get { return (double)this["minWidth"]; } set { this["minWidth"] = value; } }

		/// <summary>{String/Object} The tooltip for the button - can be a string or QuickTips config object</summary>
		public object tooltip { get { return (object)this["tooltip"]; } set { this["tooltip"] = value; } }

		/// <summary> True to start hidden (defaults to false)</summary>
		public bool hidden { get { return (bool)this["hidden"]; } set { this["hidden"] = value; } }

		/// <summary> True to start disabled (defaults to false)</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary> True to start pressed (only if enableToggle = true)</summary>
		public bool pressed { get { return (bool)this["pressed"]; } set { this["pressed"] = value; } }

		/// <summary> The group this toggle button is a member of (only 1 per group can be pressed, only</summary>
		public string toggleGroup { get { return (string)this["toggleGroup"]; } set { this["toggleGroup"] = value; } }

		/// <summary>{Boolean/Object} True to repeat fire the click event while the mouse is down. This can also be</summary>
		public object repeat { get { return (object)this["repeat"]; } set { this["repeat"] = value; } }

		/// <summary> Set a DOM tabIndex for this button (defaults to undefined)</summary>
		public double tabIndex { get { return (double)this["tabIndex"]; } set { this["tabIndex"] = value; } }

		/// <summary>  False to not allow a pressed Button to be depressed (defaults to undefined). Only valid when {@link #enableToggle} is true.</summary>
		public bool allowDepress { get { return (bool)this["allowDepress"]; } set { this["allowDepress"] = value; } }

		/// <summary>  True to enable pressed/not pressed toggling (defaults to false)</summary>
		public bool enableToggle { get { return (bool)this["enableToggle"]; } set { this["enableToggle"] = value; } }

		/// <summary>  Function called when a Button with {@link #enableToggle} set to true is clicked. Two arguments are passed:<ul class="mdetail-params"> <li><b>button</b> : Ext.Button<div class="sub-desc">this Button object</div></li> <li><b>state</b> : Boolean<div class="sub-desc">The next state if the Button, true means pressed.</div></li> </ul></summary>
		public Delegate toggleHandler { get { return (Delegate)this["toggleHandler"]; } set { this["toggleHandler"] = value; } }

		/// <summary>  Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob (defaults to undefined).</summary>
		public object menu { get { return (object)this["menu"]; } set { this["menu"] = value; } }

		/// <summary>  The position to align the menu to (see {@link Ext.Element#alignTo} for more details, defaults to 'tl-bl?').</summary>
		public string menuAlign { get { return (string)this["menuAlign"]; } set { this["menuAlign"] = value; } }

		/// <summary>  A css class which sets a background image to be used as the icon for this button</summary>
		public string iconCls { get { return (string)this["iconCls"]; } set { this["iconCls"] = value; } }

		/// <summary>  submit, reset or button - defaults to 'button'</summary>
		public string type { get { return (string)this["type"]; } set { this["type"] = value; } }

		/// <summary>  The type of event to map to the button's event handler (defaults to 'click')</summary>
		public string clickEvent { get { return (string)this["clickEvent"]; } set { this["clickEvent"] = value; } }

		/// <summary>  False to disable visual cues on mouseover, mouseout and mousedown (defaults to true)</summary>
		public bool handleMouseEvents { get { return (bool)this["handleMouseEvents"]; } set { this["handleMouseEvents"] = value; } }

		/// <summary>  The type of tooltip to use. Either "qtip" (default) for QuickTips or "title" for title attribute.</summary>
		public string tooltipType { get { return (string)this["tooltipType"]; } set { this["tooltipType"] = value; } }

		/// <summary> (Optional) An {@link Ext.Template} with which to create the Button's main element. This Template must contain numeric substitution parameter 0 if it is to display the text property. Changing the template could require code modifications if required elements (e.g. a button) aren't present.</summary>
		public Ext.Template template { get { return (Ext.Template)this["template"]; } set { this["template"] = value; } }

		/// <summary>  A CSS class string to apply to the button's main element.</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

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

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return (string)this["overCls"]; } set { this["overCls"] = value; } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return (string)this["style"]; } set { this["style"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return (string)this["ctCls"]; } set { this["ctCls"] = value; } }

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
}
