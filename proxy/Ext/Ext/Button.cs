using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Simple Button class
	///     @cfg {String} text The button text
	///     @cfg {String} icon The path to an image to display in the button (the image will be set as the background-image
	///     CSS property of the button by default, so if you want a mixed icon/text button, set cls:"x-btn-text-icon")
	///     @cfg {Function} handler A function called when the button is clicked (can be used instead of click event)
	///     @cfg {Object} scope The scope of the handler
	///     @cfg {Number} minWidth The minimum width for this button (used to give a set of buttons a common width)
	///     @cfg {String/Object} tooltip The tooltip for the button - can be a string or QuickTips config object
	///     @cfg {Boolean} hidden True to start hidden (defaults to false)
	///     @cfg {Boolean} disabled True to start disabled (defaults to false)
	///     @cfg {Boolean} pressed True to start pressed (only if enableToggle = true)
	///     @cfg {String} toggleGroup The group this toggle button is a member of (only 1 per group can be pressed, only
	///     applies if enableToggle = true)
	///     @cfg {Boolean/Object} repeat True to repeat fire the click event while the mouse is down. This can also be
	///     an {@link Ext.util.ClickRepeater} config object (defaults to false).
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Button.js</jssource>
	public class Button : Ext.Component {

		/// <summary>Create a new button</summary>
		/// <returns></returns>
		public Button() { C_(); }
		/// <summary>Create a new button</summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public Button(object config) { C_(config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public Button(Ext.Element config) { C_(config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public Button(string config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Button prototype { get { return S_<Button>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.Component superclass { get { return S_<Ext.Component>(); } set { S_(value); } }

		/// <summary>Read-only. True if this button is hidden</summary>
		public bool hidden { get { return _<bool>(); } set { _(value); } }

		/// <summary>Read-only. True if this button is disabled</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

		/// <summary>Read-only. True if this button is pressed (only if enableToggle = true)</summary>
		public bool pressed { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     The Button's owner {@link Ext.Panel} (defaults to undefined, and is set automatically when
		///     the Button is added to a container).  Read-only.
		/// </summary>
		public Ext.Panel ownerCt { get { return _<Ext.Panel>(); } set { _(value); } }

		/// <summary>Set a DOM tabIndex for this button (defaults to undefined)</summary>
		public double tabIndex { get { return _<double>(); } set { _(value); } }

		/// <summary>False to not allow a pressed Button to be depressed (defaults to undefined). Only valid when {@link #enableToggle} is true.</summary>
		public bool allowDepress { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to enable pressed/not pressed toggling (defaults to false)</summary>
		public bool enableToggle { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     Function called when a Button with {@link #enableToggle} set to true is clicked. Two arguments are passed:<ul class="mdetail-params">
		///     <li><b>button</b> : Ext.Button<div class="sub-desc">this Button object</div></li>
		///     <li><b>state</b> : Boolean<div class="sub-desc">The next state if the Button, true means pressed.</div></li>
		///     </ul>
		/// </summary>
		public Delegate toggleHandler { get { return _<Delegate>(); } set { _(value); } }

		/// <summary>Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob (defaults to undefined).</summary>
		public object menu { get { return _<object>(); } set { _(value); } }

		/// <summary>The position to align the menu to (see {@link Ext.Element#alignTo} for more details, defaults to 'tl-bl?').</summary>
		public string menuAlign { get { return _<string>(); } set { _(value); } }

		/// <summary>A css class which sets a background image to be used as the icon for this button</summary>
		public string iconCls { get { return _<string>(); } set { _(value); } }

		/// <summary>submit, reset or button - defaults to 'button'</summary>
		public string type { get { return _<string>(); } set { _(value); } }

		/// <summary>The type of event to map to the button's event handler (defaults to 'click')</summary>
		public string clickEvent { get { return _<string>(); } set { _(value); } }

		/// <summary>False to disable visual cues on mouseover, mouseout and mousedown (defaults to true)</summary>
		public bool handleMouseEvents { get { return _<bool>(); } set { _(value); } }

		/// <summary>The type of tooltip to use. Either "qtip" (default) for QuickTips or "title" for title attribute.</summary>
		public string tooltipType { get { return _<string>(); } set { _(value); } }

		/// <summary>
		///     (Optional)An {@link Ext.Template} with which to create the Button's main element. This Template must
		///     contain numeric substitution parameter 0 if it is to display the text property. Changing the template could
		///     require code modifications if required elements (e.g. a button) aren't present.
		/// </summary>
		public Ext.Template template { get { return _<Ext.Template>(); } set { _(value); } }

		/// <summary>A CSS class string to apply to the button's main element.</summary>
		public string cls { get { return _<string>(); } set { _(value); } }


		/// <summary>
		///     Sets the CSS class that provides a background image to use as the button's icon.  This method also changes
		///     the value of the {@link iconCls} config internally.
		/// </summary>
		/// <returns></returns>
		public virtual void setIconClass() { _(); }

		/// <summary>
		///     Sets the CSS class that provides a background image to use as the button's icon.  This method also changes
		///     the value of the {@link iconCls} config internally.
		/// </summary>
		/// <param name="cls">The CSS class providing the icon image</param>
		/// <returns></returns>
		public virtual void setIconClass(string cls) { _(cls); }

		/// <summary>Assigns this button's click handler</summary>
		/// <returns></returns>
		public virtual void setHandler() { _(); }

		/// <summary>Assigns this button's click handler</summary>
		/// <param name="handler">The function to call when the button is clicked</param>
		/// <returns></returns>
		public virtual void setHandler(Delegate handler) { _(handler); }

		/// <summary>Assigns this button's click handler</summary>
		/// <param name="handler">The function to call when the button is clicked</param>
		/// <param name="scope">(optional) Scope for the function passed in</param>
		/// <returns></returns>
		public virtual void setHandler(Delegate handler, object scope) { _(handler, scope); }

		/// <summary>Sets this button's text</summary>
		/// <returns></returns>
		public virtual void setText() { _(); }

		/// <summary>Sets this button's text</summary>
		/// <param name="text">The button text</param>
		/// <returns></returns>
		public virtual void setText(string text) { _(text); }

		/// <summary>Gets the text for this button</summary>
		/// <returns>String</returns>
		public virtual void getText() { _(); }

		/// <summary>If a state it passed, it becomes the pressed state otherwise the current state is toggled.</summary>
		/// <returns></returns>
		public virtual void toggle() { _(); }

		/// <summary>If a state it passed, it becomes the pressed state otherwise the current state is toggled.</summary>
		/// <param name="state">(optional) Force a particular state</param>
		/// <returns></returns>
		public virtual void toggle(bool state) { _(state); }

		/// <summary>Focus the button</summary>
		/// <returns></returns>
		public virtual void focus() { _(); }

		/// <summary>Show this button's menu (if it has one)</summary>
		/// <returns></returns>
		public virtual void showMenu() { _(); }

		/// <summary>Hide this button's menu (if it has one)</summary>
		/// <returns></returns>
		public virtual void hideMenu() { _(); }

		/// <summary>Returns true if the button has a menu and it is visible</summary>
		/// <returns>Boolean</returns>
		public virtual void hasVisibleMenu() { _(); }



	}

	[JsAnonymous]
	public class ButtonConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> The button text</summary>
		public string text { get { return _<string>(); } set { _(value); } }

		/// <summary> The path to an image to display in the button (the image will be set as the background-image</summary>
		public string icon { get { return _<string>(); } set { _(value); } }

		/// <summary> A function called when the button is clicked (can be used instead of click event)</summary>
		public Delegate handler { get { return _<Delegate>(); } set { _(value); } }

		/// <summary> The scope of the handler</summary>
		public object scope { get { return _<object>(); } set { _(value); } }

		/// <summary> The minimum width for this button (used to give a set of buttons a common width)</summary>
		public double minWidth { get { return _<double>(); } set { _(value); } }

		/// <summary>{String/Object} The tooltip for the button - can be a string or QuickTips config object</summary>
		public object tooltip { get { return _<object>(); } set { _(value); } }

		/// <summary> True to start hidden (defaults to false)</summary>
		public bool hidden { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to start disabled (defaults to false)</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to start pressed (only if enableToggle = true)</summary>
		public bool pressed { get { return _<bool>(); } set { _(value); } }

		/// <summary> The group this toggle button is a member of (only 1 per group can be pressed, only</summary>
		public string toggleGroup { get { return _<string>(); } set { _(value); } }

		/// <summary>{Boolean/Object} True to repeat fire the click event while the mouse is down. This can also be</summary>
		public object repeat { get { return _<object>(); } set { _(value); } }

		/// <summary> Set a DOM tabIndex for this button (defaults to undefined)</summary>
		public double tabIndex { get { return _<double>(); } set { _(value); } }

		/// <summary>  False to not allow a pressed Button to be depressed (defaults to undefined). Only valid when {@link #enableToggle} is true.</summary>
		public bool allowDepress { get { return _<bool>(); } set { _(value); } }

		/// <summary>  True to enable pressed/not pressed toggling (defaults to false)</summary>
		public bool enableToggle { get { return _<bool>(); } set { _(value); } }

		/// <summary>  Function called when a Button with {@link #enableToggle} set to true is clicked. Two arguments are passed:<ul class="mdetail-params"> <li><b>button</b> : Ext.Button<div class="sub-desc">this Button object</div></li> <li><b>state</b> : Boolean<div class="sub-desc">The next state if the Button, true means pressed.</div></li> </ul></summary>
		public Delegate toggleHandler { get { return _<Delegate>(); } set { _(value); } }

		/// <summary>  Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob (defaults to undefined).</summary>
		public object menu { get { return _<object>(); } set { _(value); } }

		/// <summary>  The position to align the menu to (see {@link Ext.Element#alignTo} for more details, defaults to 'tl-bl?').</summary>
		public string menuAlign { get { return _<string>(); } set { _(value); } }

		/// <summary>  A css class which sets a background image to be used as the icon for this button</summary>
		public string iconCls { get { return _<string>(); } set { _(value); } }

		/// <summary>  submit, reset or button - defaults to 'button'</summary>
		public string type { get { return _<string>(); } set { _(value); } }

		/// <summary>  The type of event to map to the button's event handler (defaults to 'click')</summary>
		public string clickEvent { get { return _<string>(); } set { _(value); } }

		/// <summary>  False to disable visual cues on mouseover, mouseout and mousedown (defaults to true)</summary>
		public bool handleMouseEvents { get { return _<bool>(); } set { _(value); } }

		/// <summary>  The type of tooltip to use. Either "qtip" (default) for QuickTips or "title" for title attribute.</summary>
		public string tooltipType { get { return _<string>(); } set { _(value); } }

		/// <summary> (Optional) An {@link Ext.Template} with which to create the Button's main element. This Template must contain numeric substitution parameter 0 if it is to display the text property. Changing the template could require code modifications if required elements (e.g. a button) aren't present.</summary>
		public Ext.Template template { get { return _<Ext.Template>(); } set { _(value); } }

		/// <summary>  A CSS class string to apply to the button's main element.</summary>
		public string cls { get { return _<string>(); } set { _(value); } }

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

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return _<string>(); } set { _(value); } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return _<string>(); } set { _(value); } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return _<string>(); } set { _(value); } }

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

    public class ButtonEvents {
        /// <summary>Fires when this button is clicked
        /// <pre><code>
        /// USAGE: ({Button} objthis, {EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description>The click event</description></item>
        /// </list>
        /// </summary>
        public static string click { get { return "click"; } }
        /// <summary>Fires when the "pressed" state of this button changes (only if enableToggle = true)
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Boolean} pressed)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>pressed</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string toggle { get { return "toggle"; } }
        /// <summary>Fires when the mouse hovers over the button
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Event} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description>The event object</description></item>
        /// </list>
        /// </summary>
        public static string mouseover { get { return "mouseover"; } }
        /// <summary>Fires when the mouse exits the button
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Event} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description>The event object</description></item>
        /// </list>
        /// </summary>
        public static string mouseout { get { return "mouseout"; } }
        /// <summary>If this button has a menu, this event fires when it is shown
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Menu} menu)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>menu</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string menushow { get { return "menushow"; } }
        /// <summary>If this button has a menu, this event fires when it is hidden
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Menu} menu)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>menu</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string menuhide { get { return "menuhide"; } }
        /// <summary>If this button has a menu, this event fires when the mouse enters the menu triggering element
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Menu} menu, {EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>menu</b></term><description></description></item>
        /// <item><term><b>e</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string menutriggerover { get { return "menutriggerover"; } }
        /// <summary>If this button has a menu, this event fires when the mouse leaves the menu triggering element
        /// <pre><code>
        /// USAGE: ({Button} objthis, {Menu} menu, {EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>menu</b></term><description></description></item>
        /// <item><term><b>e</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string menutriggerout { get { return "menutriggerout"; } }
    }

    public delegate void ButtonClickDelegate(Button objthis, EventObject e);
    public delegate void ButtonToggleDelegate(Button objthis, bool pressed);
    public delegate void ButtonMouseoverDelegate(Button objthis, Event e);
    public delegate void ButtonMouseoutDelegate(Button objthis, Event e);
    public delegate void ButtonMenushowDelegate(Button objthis, Ext.menu.Menu menu);
    public delegate void ButtonMenuhideDelegate(Button objthis, Ext.menu.Menu menu);
    public delegate void ButtonMenutriggeroverDelegate(Button objthis, Ext.menu.Menu menu, EventObject e);
    public delegate void ButtonMenutriggeroutDelegate(Button objthis, Ext.menu.Menu menu, EventObject e);
}
