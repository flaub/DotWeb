using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     A split button that provides a built-in dropdown arrow that can fire an event separately from the default
    ///     click event of the button.  Typically this would be used to display a dropdown menu that provides additional
    ///     options to the primary button action, but any custom handler can provide the arrowclick implementation.  Example usage:
    ///     <pre><code>
    ///     // display a dropdown menu:
    ///     new Ext.SplitButton({
    ///     renderTo: 'button-ct', // the container id
    ///     text: 'Options',
    ///     handler: optionsHandler, // handle a click on the button itself
    ///     menu: new Ext.menu.Menu({
    ///     items: [
    ///     // these items will render as dropdown menu items when the arrow is clicked:
    ///     {text: 'Item 1', handler: item1Handler},
    ///     {text: 'Item 2', handler: item2Handler}
    ///     ]
    ///     })
    ///     });
    ///     // Instead of showing a menu, you provide any type of custom
    ///     // functionality you want when the dropdown arrow is clicked:
    ///     new Ext.SplitButton({
    ///     renderTo: 'button-ct',
    ///     text: 'Options',
    ///     handler: optionsHandler,
    ///     arrowHandler: myCustomHandler
    ///     });
    ///     </code></pre>
    ///     @cfg {Function} arrowHandler A function called when the arrow button is clicked (can be used instead of click event)
    ///     @cfg {String} arrowTooltip The title attribute of the arrow
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\SplitButton.js</jssource>
    [Native]
    public class SplitButton : Ext.Button {

        /// <summary>Create a new menu button</summary>
        /// <returns></returns>
        public SplitButton() {}
        /// <summary>Create a new menu button</summary>
        /// <param name="config">The config object</param>
        /// <returns></returns>
        public SplitButton(object config) {}
        /// <summary>
        ///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
        ///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
        /// </summary>
        /// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
        /// <returns></returns>
        public SplitButton(Ext.Element config) {}
        /// <summary>
        ///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
        ///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
        /// </summary>
        /// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
        /// <returns></returns>
        public SplitButton(System.String config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static SplitButton prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.Button superclass { get { return null; } set { } }


        /// <summary>Sets this button's arrow click handler.</summary>
        /// <returns></returns>
        public virtual void setArrowHandler() { return ; }

        /// <summary>Sets this button's arrow click handler.</summary>
        /// <param name="handler">The function to call when the arrow is clicked</param>
        /// <returns></returns>
        public virtual void setArrowHandler(Delegate handler) { return ; }

        /// <summary>Sets this button's arrow click handler.</summary>
        /// <param name="handler">The function to call when the arrow is clicked</param>
        /// <param name="scope">(optional) Scope for the function passed above</param>
        /// <returns></returns>
        public virtual void setArrowHandler(Delegate handler, object scope) { return ; }



    }
    [Anonymous]
    public class SplitButtonConfig {

        /// <summary> A function called when the arrow button is clicked (can be used instead of click event)</summary>
        public Delegate arrowHandler { get { return null; } set { } }

        /// <summary> The title attribute of the arrow</summary>
        public System.String arrowTooltip { get { return null; } set { } }

        /// <summary> The button text</summary>
        public System.String text { get { return null; } set { } }

        /// <summary> The path to an image to display in the button (the image will be set as the background-image</summary>
        public System.String icon { get { return null; } set { } }

        /// <summary> A function called when the button is clicked (can be used instead of click event)</summary>
        public Delegate handler { get { return null; } set { } }

        /// <summary> The scope of the handler</summary>
        public object scope { get { return null; } set { } }

        /// <summary> The minimum width for this button (used to give a set of buttons a common width)</summary>
        public double minWidth { get { return 0; } set { } }

        /// <summary>{String/Object} The tooltip for the button - can be a string or QuickTips config object</summary>
        public object tooltip { get { return null; } set { } }

        /// <summary> True to start hidden (defaults to false)</summary>
        public bool hidden { get { return false; } set { } }

        /// <summary> True to start disabled (defaults to false)</summary>
        public bool disabled { get { return false; } set { } }

        /// <summary> True to start pressed (only if enableToggle = true)</summary>
        public bool pressed { get { return false; } set { } }

        /// <summary> The group this toggle button is a member of (only 1 per group can be pressed, only</summary>
        public System.String toggleGroup { get { return null; } set { } }

        /// <summary>{Boolean/Object} True to repeat fire the click event while the mouse is down. This can also be</summary>
        public object repeat { get { return null; } set { } }

        /// <summary> Set a DOM tabIndex for this button (defaults to undefined)</summary>
        public double tabIndex { get { return 0; } set { } }

        /// <summary>  False to not allow a pressed Button to be depressed (defaults to undefined). Only valid when {@link #enableToggle} is true.</summary>
        public bool allowDepress { get { return false; } set { } }

        /// <summary>  True to enable pressed/not pressed toggling (defaults to false)</summary>
        public bool enableToggle { get { return false; } set { } }

        /// <summary>  Function called when a Button with {@link #enableToggle} set to true is clicked. Two arguments are passed:<ul class="mdetail-params"> <li><b>button</b> : Ext.Button<div class="sub-desc">this Button object</div></li> <li><b>state</b> : Boolean<div class="sub-desc">The next state if the Button, true means pressed.</div></li> </ul></summary>
        public Delegate toggleHandler { get { return null; } set { } }

        /// <summary>  Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob (defaults to undefined).</summary>
        public object menu { get { return null; } set { } }

        /// <summary>  The position to align the menu to (see {@link Ext.Element#alignTo} for more details, defaults to 'tl-bl?').</summary>
        public System.String menuAlign { get { return null; } set { } }

        /// <summary>  A css class which sets a background image to be used as the icon for this button</summary>
        public System.String iconCls { get { return null; } set { } }

        /// <summary>  submit, reset or button - defaults to 'button'</summary>
        public System.String type { get { return null; } set { } }

        /// <summary>  The type of event to map to the button's event handler (defaults to 'click')</summary>
        public System.String clickEvent { get { return null; } set { } }

        /// <summary>  False to disable visual cues on mouseover, mouseout and mousedown (defaults to true)</summary>
        public bool handleMouseEvents { get { return false; } set { } }

        /// <summary>  The type of tooltip to use. Either "qtip" (default) for QuickTips or "title" for title attribute.</summary>
        public System.String tooltipType { get { return null; } set { } }

        /// <summary> (Optional) An {@link Ext.Template} with which to create the Button's main element. This Template must contain numeric substitution parameter 0 if it is to display the text property. Changing the template could require code modifications if required elements (e.g. a button) aren't present.</summary>
        public Ext.Template template { get { return null; } set { } }

        /// <summary>  A CSS class string to apply to the button's main element.</summary>
        public System.String cls { get { return null; } set { } }

        /// <summary> 
        ///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
        ///     The predefined xtypes are listed at the top of this document.
        ///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
        /// </summary>
        public string xtype { get { return null; } set { } }

        /// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
        public System.String id { get { return null; } set { } }

        /// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
        public object autoEl { get { return null; } set { } }

        /// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
        public System.String overCls { get { return null; } set { } }

        /// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
        public System.String style { get { return null; } set { } }

        /// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
        public System.String ctCls { get { return null; } set { } }

        /// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
        public object plugins { get { return null; } set { } }

        /// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
        public object applyTo { get { return null; } set { } }

        /// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
        public object renderTo { get { return null; } set { } }

        /// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
        public bool stateful { get { return false; } set { } }

        /// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
        public System.String stateId { get { return null; } set { } }

        /// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
        public System.String disabledClass { get { return null; } set { } }

        /// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
        public bool allowDomMove { get { return false; } set { } }

        /// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
        public bool autoShow { get { return false; } set { } }

        /// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
        public System.String hideMode { get { return null; } set { } }

        /// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
        public bool hideParent { get { return false; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }

    public class SplitButtonEvents {
        /// <summary>Fires when this button's arrow is clicked
        /// <pre><code>
        /// USAGE: ({MenuButton} objthis, {EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description>The click event</description></item>
        /// </list>
        /// </summary>
        public static string arrowclick { get { return "arrowclick"; } }
    }

    public delegate void SplitButtonArrowclickDelegate(Ext.Button objthis, EventObject e);
}
