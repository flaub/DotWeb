using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.menu {
	/// <summary>
	///     /**
	///     A base class for all menu items that require menu-related functionality (like sub-menus) and are not static
	///     display items.  Item extends the base functionality of {@link Ext.menu.BaseItem} by adding menu-specific
	///     activation and click handling.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\menu\Item.js</jssource>
	public class Item : Ext.menu.BaseItem {

		/// <summary>Creates a new Item</summary>
		/// <returns></returns>
		public extern Item();
		/// <summary>Creates a new Item</summary>
		/// <param name="config">Configuration options</param>
		/// <returns></returns>
		public extern Item(object config);
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public extern Item(Ext.Element config);
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public extern Item(string config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Item prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.menu.BaseItem superclass { get; set; }

		/// <summary>Either an instance of {@link Ext.menu.Menu} or the config object for an{@link Ext.menu.Menu} which acts as the submenu when this item is activated.</summary>
		public extern object menu { get; set; }

		/// <summary>The path to an icon to display in this item (defaults to Ext.BLANK_IMAGE_URL).  Ificon is specified {@link #iconCls} should not be.</summary>
		public extern string icon { get; set; }

		/// <summary>A CSS class that specifies a background image that will be used as the icon forthis item (defaults to '').  If iconCls is specified {@link #icon} should not be.</summary>
		public extern string iconCls { get; set; }

		/// <summary>The text to display in this item (defaults to '').</summary>
		public extern string text { get; set; }

		/// <summary>The href attribute to use for the underlying anchor link (defaults to '#').</summary>
		public extern string href { get; set; }

		/// <summary>The target attribute to use for the underlying anchor link (defaults to '').</summary>
		public extern string hrefTarget { get; set; }

		/// <summary>The default CSS class to use for menu items (defaults to 'x-menu-item')</summary>
		public extern string itemCls { get; set; }

		/// <summary>True if this item can be visually activated (defaults to true)</summary>
		public extern bool canActivate { get; set; }

		/// <summary>Length of time in milliseconds to wait before showing this item (defaults to 200)</summary>
		public extern double showDelay { get; set; }


		/// <summary>Sets the text to display in this menu item</summary>
		/// <returns></returns>
		public extern virtual void setText();

		/// <summary>Sets the text to display in this menu item</summary>
		/// <param name="text">The text to display</param>
		/// <returns></returns>
		public extern virtual void setText(string text);

		/// <summary>Sets the CSS class to apply to the item's icon element</summary>
		/// <returns></returns>
		public extern virtual void setIconClass();

		/// <summary>Sets the CSS class to apply to the item's icon element</summary>
		/// <param name="cls">The CSS class to apply</param>
		/// <returns></returns>
		public extern virtual void setIconClass(string cls);



	}

	[JsAnonymous]
	public class ItemConfig : System.DotWeb.JsDynamic {
		/// <summary> Either an instance of {@link Ext.menu.Menu} or the config object for an {@link Ext.menu.Menu} which acts as the submenu when this item is activated.</summary>
		public object menu { get { return (object)this["menu"]; } set { this["menu"] = value; } }

		/// <summary> The path to an icon to display in this item (defaults to Ext.BLANK_IMAGE_URL).  If icon is specified {@link #iconCls} should not be.</summary>
		public string icon { get { return (string)this["icon"]; } set { this["icon"] = value; } }

		/// <summary> A CSS class that specifies a background image that will be used as the icon for this item (defaults to '').  If iconCls is specified {@link #icon} should not be.</summary>
		public string iconCls { get { return (string)this["iconCls"]; } set { this["iconCls"] = value; } }

		/// <summary> The text to display in this item (defaults to '').</summary>
		public string text { get { return (string)this["text"]; } set { this["text"] = value; } }

		/// <summary> The href attribute to use for the underlying anchor link (defaults to '#').</summary>
		public string href { get { return (string)this["href"]; } set { this["href"] = value; } }

		/// <summary> The target attribute to use for the underlying anchor link (defaults to '').</summary>
		public string hrefTarget { get { return (string)this["hrefTarget"]; } set { this["hrefTarget"] = value; } }

		/// <summary> The default CSS class to use for menu items (defaults to 'x-menu-item')</summary>
		public string itemCls { get { return (string)this["itemCls"]; } set { this["itemCls"] = value; } }

		/// <summary> True if this item can be visually activated (defaults to true)</summary>
		public bool canActivate { get { return (bool)this["canActivate"]; } set { this["canActivate"] = value; } }

		/// <summary> Length of time in milliseconds to wait before showing this item (defaults to 200)</summary>
		public double showDelay { get { return (double)this["showDelay"]; } set { this["showDelay"] = value; } }

		/// <summary>  A function that will handle the click event of this menu item (defaults to undefined)</summary>
		public Delegate handler { get { return (Delegate)this["handler"]; } set { this["handler"] = value; } }

		/// <summary>  The scope in which the handler function will be called.</summary>
		public object scope { get { return (object)this["scope"]; } set { this["scope"] = value; } }

		/// <summary> The CSS class to use when the item becomes activated (defaults to "x-menu-item-active")</summary>
		public string activeClass { get { return (string)this["activeClass"]; } set { this["activeClass"] = value; } }

		/// <summary> True to hide the containing menu after this item is clicked (defaults to true)</summary>
		public bool hideOnClick { get { return (bool)this["hideOnClick"]; } set { this["hideOnClick"] = value; } }

		/// <summary> Length of time in milliseconds to wait before hiding after a click (defaults to 100)</summary>
		public double hideDelay { get { return (double)this["hideDelay"]; } set { this["hideDelay"] = value; } }

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
}
