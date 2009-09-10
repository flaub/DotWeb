using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Basic Toolbar class. Toolbar elements can be created explicitly via their constructors, or implicitly
	///     via their xtypes.  Some items also have shortcut strings for creation.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class ToolbarClass : Ext.BoxComponent {

		/// <summary>Creates a new Toolbar</summary>
		/// <returns></returns>
		public ToolbarClass() { C_(); }
		/// <summary>Creates a new Toolbar</summary>
		/// <param name="config">A config object or an array of buttons to add</param>
		/// <returns></returns>
		public ToolbarClass(object config) { C_(config); }
		/// <summary>Creates a new Toolbar</summary>
		/// <param name="config">A config object or an array of buttons to add</param>
		/// <returns></returns>
		public ToolbarClass(System.Array config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public ToolbarClass(Ext.Element config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public ToolbarClass(string config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static ToolbarClass prototype { get { return S_<ToolbarClass>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.BoxComponent superclass { get { return S_<Ext.BoxComponent>(); } set { S_(value); } }


		/// <summary>
		///     A MixedCollection of this Toolbar's items
		///     @property items
		///     @type Ext.util.MixedCollection
		/// </summary>
		/// <returns></returns>
		public virtual void items() { _(); }

		/// <summary>
		///     Adds element(s) to the toolbar -- this function takes a variable number of
		///     arguments of mixed type and adds them to the toolbar.
		///     <ul>
		///     <li>{@link Ext.Toolbar.Button} config: A valid button config object (equivalent to {@link #addButton})</li>
		///     <li>HtmlElement: Any standard HTML element (equivalent to {@link #addElement})</li>
		///     <li>Field: Any form field (equivalent to {@link #addField})</li>
		///     <li>Item: Any subclass of {@link Ext.Toolbar.Item} (equivalent to {@link #addItem})</li>
		///     <li>String: Any generic string (gets wrapped in a {@link Ext.Toolbar.TextItem}, equivalent to {@link #addText}).
		///     Note that there are a few special strings that are treated differently as explained next.</li>
		///     <li>'separator' or '-': Creates a separator element (equivalent to {@link #addSeparator})</li>
		///     <li>' ': Creates a spacer element (equivalent to {@link #addSpacer})</li>
		///     <li>'->': Creates a fill element (equivalent to {@link #addFill})</li>
		///     </ul>
		/// </summary>
		/// <returns></returns>
		public virtual void add() { _(); }

		/// <summary>
		///     Adds element(s) to the toolbar -- this function takes a variable number of
		///     arguments of mixed type and adds them to the toolbar.
		///     <ul>
		///     <li>{@link Ext.Toolbar.Button} config: A valid button config object (equivalent to {@link #addButton})</li>
		///     <li>HtmlElement: Any standard HTML element (equivalent to {@link #addElement})</li>
		///     <li>Field: Any form field (equivalent to {@link #addField})</li>
		///     <li>Item: Any subclass of {@link Ext.Toolbar.Item} (equivalent to {@link #addItem})</li>
		///     <li>String: Any generic string (gets wrapped in a {@link Ext.Toolbar.TextItem}, equivalent to {@link #addText}).
		///     Note that there are a few special strings that are treated differently as explained next.</li>
		///     <li>'separator' or '-': Creates a separator element (equivalent to {@link #addSeparator})</li>
		///     <li>' ': Creates a spacer element (equivalent to {@link #addSpacer})</li>
		///     <li>'->': Creates a fill element (equivalent to {@link #addFill})</li>
		///     </ul>
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public virtual void add(params object[] args) { _(args); }

		/// <summary>Adds a separator</summary>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addSeparator() { _(); }

		/// <summary>Adds a spacer element</summary>
		/// <returns>Ext.Toolbar.Spacer</returns>
		public virtual void addSpacer() { _(); }

		/// <summary>Adds a fill element that forces subsequent additions to the right side of the toolbar</summary>
		/// <returns>Ext.Toolbar.Fill</returns>
		public virtual void addFill() { _(); }

		/// <summary>Adds any standard HTML element to the toolbar</summary>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addElement() { _(); }

		/// <summary>Adds any standard HTML element to the toolbar</summary>
		/// <param name="el">The element or id of the element to add</param>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addElement(object el) { _(el); }

		/// <summary>Adds any Toolbar.Item or subclass</summary>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addItem() { _(); }

		/// <summary>Adds any Toolbar.Item or subclass</summary>
		/// <param name="item"></param>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addItem(Ext.Toolbar.Item item) { _(item); }

		/// <summary>Adds a button (or buttons). See {@link Ext.Toolbar.Button} for more info on the config.</summary>
		/// <returns>Ext.Toolbar.Button/Array</returns>
		public virtual void addButton() { _(); }

		/// <summary>Adds a button (or buttons). See {@link Ext.Toolbar.Button} for more info on the config.</summary>
		/// <param name="config">A button config or array of configs</param>
		/// <returns>Ext.Toolbar.Button/Array</returns>
		public virtual void addButton(object config) { _(config); }

		/// <summary>Adds a button (or buttons). See {@link Ext.Toolbar.Button} for more info on the config.</summary>
		/// <param name="config">A button config or array of configs</param>
		/// <returns>Ext.Toolbar.Button/Array</returns>
		public virtual void addButton(System.Array config) { _(config); }

		/// <summary>Adds text to the toolbar</summary>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addText() { _(); }

		/// <summary>Adds text to the toolbar</summary>
		/// <param name="text">The text to add</param>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addText(string text) { _(text); }

		/// <summary>
		///     Inserts any {@link Ext.Toolbar.Item}/{@link Ext.Toolbar.Button} at the specified index.
		///     inserted, or an array of buttons/configs.
		/// </summary>
		/// <returns>Ext.Toolbar.Button/Item</returns>
		public virtual void insertButton() { _(); }

		/// <summary>
		///     Inserts any {@link Ext.Toolbar.Item}/{@link Ext.Toolbar.Button} at the specified index.
		///     inserted, or an array of buttons/configs.
		/// </summary>
		/// <param name="index">The index where the item is to be inserted</param>
		/// <returns>Ext.Toolbar.Button/Item</returns>
		public virtual void insertButton(double index) { _(index); }

		/// <summary>
		///     Inserts any {@link Ext.Toolbar.Item}/{@link Ext.Toolbar.Button} at the specified index.
		///     inserted, or an array of buttons/configs.
		/// </summary>
		/// <param name="index">The index where the item is to be inserted</param>
		/// <param name="item">The button, or button config object to be</param>
		/// <returns>Ext.Toolbar.Button/Item</returns>
		public virtual void insertButton(double index, object item) { _(index, item); }

		/// <summary>
		///     Inserts any {@link Ext.Toolbar.Item}/{@link Ext.Toolbar.Button} at the specified index.
		///     inserted, or an array of buttons/configs.
		/// </summary>
		/// <param name="index">The index where the item is to be inserted</param>
		/// <param name="item">The button, or button config object to be</param>
		/// <returns>Ext.Toolbar.Button/Item</returns>
		public virtual void insertButton(double index, Ext.Toolbar.Item item) { _(index, item); }

		/// <summary>
		///     Inserts any {@link Ext.Toolbar.Item}/{@link Ext.Toolbar.Button} at the specified index.
		///     inserted, or an array of buttons/configs.
		/// </summary>
		/// <param name="index">The index where the item is to be inserted</param>
		/// <param name="item">The button, or button config object to be</param>
		/// <returns>Ext.Toolbar.Button/Item</returns>
		public virtual void insertButton(double index, Ext.Toolbar.Button item) { _(index, item); }

		/// <summary>
		///     Inserts any {@link Ext.Toolbar.Item}/{@link Ext.Toolbar.Button} at the specified index.
		///     inserted, or an array of buttons/configs.
		/// </summary>
		/// <param name="index">The index where the item is to be inserted</param>
		/// <param name="item">The button, or button config object to be</param>
		/// <returns>Ext.Toolbar.Button/Item</returns>
		public virtual void insertButton(double index, System.Array item) { _(index, item); }

		/// <summary>Adds a new element to the toolbar from the passed {@link Ext.DomHelper} config</summary>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addDom() { _(); }

		/// <summary>Adds a new element to the toolbar from the passed {@link Ext.DomHelper} config</summary>
		/// <param name="config"></param>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addDom(object config) { _(config); }

		/// <summary>
		///     Adds a dynamically rendered Ext.form field (TextField, ComboBox, etc). Note: the field should not have
		///     been rendered yet. For a field that has already been rendered, use {@link #addElement}.
		/// </summary>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addField() { _(); }

		/// <summary>
		///     Adds a dynamically rendered Ext.form field (TextField, ComboBox, etc). Note: the field should not have
		///     been rendered yet. For a field that has already been rendered, use {@link #addElement}.
		/// </summary>
		/// <param name="field"></param>
		/// <returns>Ext.Toolbar.Item</returns>
		public virtual void addField(Ext.form.Field field) { _(field); }



	}

	[JsAnonymous]
	public class ToolbarConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get { return _<double>(); } set { _(value); } }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get { return _<double>(); } set { _(value); } }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get { return _<double>(); } set { _(value); } }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get { return _<double>(); } set { _(value); } }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get { return _<double>(); } set { _(value); } }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get { return _<double>(); } set { _(value); } }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get { return _<bool>(); } set { _(value); } }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get { return _<bool>(); } set { _(value); } }

		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get { return _<string>(); } set { _(value); } }

		/// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
		public string id { get { return _<string>(); } set { _(value); } }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get { return _<object>(); } set { _(value); } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public string cls { get { return _<string>(); } set { _(value); } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return _<string>(); } set { _(value); } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return _<string>(); } set { _(value); } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return _<string>(); } set { _(value); } }

		/// <summary>  Render this component disabled (default is false).</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get { return _<bool>(); } set { _(value); } }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get { return _<object>(); } set { _(value); } }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
		public object applyTo { get { return _<object>(); } set { _(value); } }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get { return _<object>(); } set { _(value); } }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get { return _<bool>(); } set { _(value); } }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public string stateId { get { return _<string>(); } set { _(value); } }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public string disabledClass { get { return _<string>(); } set { _(value); } }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get { return _<bool>(); } set { _(value); } }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get { return _<bool>(); } set { _(value); } }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public string hideMode { get { return _<string>(); } set { _(value); } }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get { return _<bool>(); } set { _(value); } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return _<object>(); } set { _(value); } }

	}
}
