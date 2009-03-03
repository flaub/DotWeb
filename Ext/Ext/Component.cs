using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Base class for all Ext components.  All subclasses of Component can automatically participate in the standard
	///     Ext component lifecycle of creation, rendering and destruction.  They also have automatic support for basic hide/show
	///     and enable/disable behavior.  Component allows any subclass to be lazy-rendered into any {@link Ext.Container} and
	///     to be automatically registered with the {@link Ext.ComponentMgr} so that it can be referenced at any time via
	///     {@link Ext#getCmp}.  All visual widgets that require rendering into a layout should subclass Component (or
	///     {@link Ext.BoxComponent} if managed box model handling is required).</p>
	///     <p>Every component has a specific xtype, which is its Ext-specific type name, along with methods for checking the
	///     xtype like {@link #getXType} and {@link #isXType}. This is the list of all valid xtypes:</p>
	///     <pre>
	///     xtype            Class
	///     -------------    ------------------
	///     box              Ext.BoxComponent
	///     button           Ext.Button
	///     colorpalette     Ext.ColorPalette
	///     component        Ext.Component
	///     container        Ext.Container
	///     cycle            Ext.CycleButton
	///     dataview         Ext.DataView
	///     datepicker       Ext.DatePicker
	///     editor           Ext.Editor
	///     editorgrid       Ext.grid.EditorGridPanel
	///     grid             Ext.grid.GridPanel
	///     paging           Ext.PagingToolbar
	///     panel            Ext.Panel
	///     progress         Ext.ProgressBar
	///     propertygrid     Ext.grid.PropertyGrid
	///     slider           Ext.Slider
	///     splitbutton      Ext.SplitButton
	///     statusbar        Ext.StatusBar
	///     tabpanel         Ext.TabPanel
	///     treepanel        Ext.tree.TreePanel
	///     viewport         Ext.Viewport
	///     window           Ext.Window
	///     Toolbar components
	///     ---------------------------------------
	///     toolbar          Ext.Toolbar
	///     tbbutton         Ext.Toolbar.Button
	///     tbfill           Ext.Toolbar.Fill
	///     tbitem           Ext.Toolbar.Item
	///     tbseparator      Ext.Toolbar.Separator
	///     tbspacer         Ext.Toolbar.Spacer
	///     tbsplit          Ext.Toolbar.SplitButton
	///     tbtext           Ext.Toolbar.TextItem
	///     Form components
	///     ---------------------------------------
	///     form             Ext.FormPanel
	///     checkbox         Ext.form.Checkbox
	///     combo            Ext.form.ComboBox
	///     datefield        Ext.form.DateField
	///     field            Ext.form.Field
	///     fieldset         Ext.form.FieldSet
	///     hidden           Ext.form.Hidden
	///     htmleditor       Ext.form.HtmlEditor
	///     label            Ext.form.Label
	///     numberfield      Ext.form.NumberField
	///     radio            Ext.form.Radio
	///     textarea         Ext.form.TextArea
	///     textfield        Ext.form.TextField
	///     timefield        Ext.form.TimeField
	///     trigger          Ext.form.TriggerField
	///     </pre>
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\Component.js</jssource>
	public class Component : Ext.util.Observable {

		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <returns></returns>
		public Component() { C_(); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public Component(Ext.Element config) { C_(config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public Component(System.String config) { C_(config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public Component(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Component prototype { get { return S_<Component>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.util.Observable superclass { get { return S_<Ext.util.Observable>(); } set { S_(value); } }

		/// <summary>This Component's initial configuration specification. Read-only.</summary>
		public object initialConfig { get { return _<object>(); } set { _(value); } }

		/// <summary>The unique id of this component (defaults to an auto-assigned id).</summary>
		public System.String id { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     A tag name or DomHelper spec to create an element with. This is intended to create shorthand
		///     utility components inline via JSON. It should not be used for higher level components which already create
		///     their own elements. Example usage:
		///     <pre><code>
		///     {xtype:'box', autoEl: 'div', cls:'my-class'}
		///     {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper
		///     </code></pre>
		/// </summary>
		public object autoEl { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     The registered xtype to create. This config option is not used when passing
		///     a config object into a constructor. This config option is used only when
		///     lazy instantiation is being used, and a child item of a Container is being
		///     specified not as a fully instantiated Component, but as a <i>Component config
		///     object</i>. The xtype will be looked up at render time up to determine what
		///     type of child Component to create.<br><br>
		///     The predefined xtypes are listed {@link Ext.Component here}.
		///     <br><br>
		///     If you subclass Components to create your own Components, you may register
		///     them using {@link Ext.ComponentMgr#registerType} in order to be able to
		///     take advantage of lazy instantiation and rendering.
		/// </summary>
		public System.String xtype { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be
		///     useful for adding customized styles to the component or any of its children using standard CSS rules.
		/// </summary>
		public System.String cls { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     An optional extra CSS class that will be added to this component's Element when the mouse moves
		///     over the Element, and removed when the mouse moves out. (defaults to '').  This can be
		///     useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.
		/// </summary>
		public System.String overCls { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     A custom style specification to be applied to this component's Element.  Should be a valid argument to
		///     {@link Ext.Element#applyStyles}.
		/// </summary>
		public System.String style { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     An optional extra CSS class that will be added to this component's container (defaults to '').  This can be
		///     useful for adding customized styles to the container or any of its children using standard CSS rules.
		/// </summary>
		public System.String ctCls { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Render this component disabled (default is false).</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

		/// <summary>Render this component hidden (default is false).</summary>
		public bool hidden { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     An object or array of objects that will provide custom functionality for this component.  The only
		///     requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component.
		///     When a component is created, if any plugins are available, the component will call the init method on each
		///     plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the
		///     component as needed to provide its functionality.
		/// </summary>
		public object plugins { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in
		///     the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of
		///     the component can also be specified by id or CSS class name within the main element, and the component being created
		///     may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is
		///     not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target
		///     element's parent node will automatically be used as the component's container.
		/// </summary>
		public object applyTo { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     The id of the node, a DOM node or an existing Element that will be the container to render this component into.
		///     Using this config, a call to render() is not required.
		/// </summary>
		public object renderTo { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     A flag which causes the Component to attempt to restore the state of internal properties
		///     from a saved state on startup.<p>
		///     For state saving to work, the state manager's provider must have been set to an implementation
		///     of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set}
		///     and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs.
		///     A built-in implementation, {@link Ext.state.CookieProvider} is available.</p>
		///     <p>To set the state provider for the current page:</p>
		///     <pre><code>
		///     Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
		///     </code></pre>
		///     <p>Components attempt to save state when one of the events listed in the {@link #stateEvents}
		///     configuration fires.</p>
		///     <p>You can perform extra processing on state save and restore by attaching handlers to the
		///     {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p>
		/// </summary>
		public bool stateful { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     The unique id for this component to use for state management purposes (defaults to the component id).
		///     <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p>
		/// </summary>
		public System.String stateId { get { return _<System.String>(); } set { _(value); } }

		/// <summary>CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public System.String disabledClass { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove
		///     them on render (defaults to false).
		/// </summary>
		public bool autoShow { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative
		///     offset position) and "display" (css display) - defaults to "display".
		/// </summary>
		public System.String hideMode { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     True to hide and show the component's container when hide/show is called on the component, false to hide
		///     and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide
		///     button on a window by setting hide:true on the button when adding it to its parent container.
		/// </summary>
		public bool hideParent { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     The component's owner {@link Ext.Container} (defaults to undefined, and is set automatically when
		///     the component is added to a container).  Read-only.
		/// </summary>
		public Ext.Container ownerCt { get { return _<Ext.Container>(); } set { _(value); } }

		/// <summary>True if this component has been rendered. Read-only.</summary>
		public bool rendered { get { return _<bool>(); } set { _(value); } }


		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <returns></returns>
		public virtual void render() { _(); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <returns></returns>
		public virtual void render(Element container) { _(container); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <param name="position">(optional) The element ID or DOM node index within the container <b>before</b></param>
		/// <returns></returns>
		public virtual void render(Element container, System.String position) { _(container, position); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <returns></returns>
		public virtual void render(DOMElement container) { _(container); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <param name="position">(optional) The element ID or DOM node index within the container <b>before</b></param>
		/// <returns></returns>
		public virtual void render(DOMElement container, System.String position) { _(container, position); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <returns></returns>
		public virtual void render(System.String container) { _(container); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <param name="position">(optional) The element ID or DOM node index within the container <b>before</b></param>
		/// <returns></returns>
		public virtual void render(System.String container, System.String position) { _(container, position); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <param name="position">(optional) The element ID or DOM node index within the container <b>before</b></param>
		/// <returns></returns>
		public virtual void render(Element container, double position) { _(container, position); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <param name="position">(optional) The element ID or DOM node index within the container <b>before</b></param>
		/// <returns></returns>
		public virtual void render(DOMElement container, double position) { _(container, position); }

		/// <summary>
		///     <p>Render this Components into the passed HTML element.</p>
		///     <p><b>If you are using a {@link Ext.Container Container} object to house this Component, then
		///     do not use the render method.</b></p>
		///     <p>A Container's child Components are rendered by that Container's
		///     {@link Ext.Container#layout layout} manager when the Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when a new child Component is added, you may need to call
		///     the Container's {@link Ext.Container#doLayout doLayout} to refresh the view which causes any
		///     unrendered child Components to be rendered. This is required so that you can add multiple
		///     child components if needed while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link Ext.Container#layout layout} manager.
		///     If you expect child items to be sized in response to user interactions, you must
		///     configure the Container with a layout manager which creates and manages the type of layout you
		///     have in mind.</p>
		///     <p><b>Omitting the Container's {@link Ext.Container#layout layout} config means that a basic
		///     layout manager is used which does nothnig but render child components sequentially into the
		///     Container. No sizing or positioning will be performed in this situation.</b></p>
		///     rendered into. If it is being created from existing markup, this should be omitted.
		///     which this component will be inserted (defaults to appending to the end of the container)
		/// </summary>
		/// <param name="container">(optional) The element this Component should be</param>
		/// <param name="position">(optional) The element ID or DOM node index within the container <b>before</b></param>
		/// <returns></returns>
		public virtual void render(System.String container, double position) { _(container, position); }

		/// <summary>Apply this component to existing markup that is valid. With this function, no call to render() is required.</summary>
		/// <returns></returns>
		public virtual void applyToMarkup() { _(); }

		/// <summary>Apply this component to existing markup that is valid. With this function, no call to render() is required.</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public virtual void applyToMarkup(System.String el) { _(el); }

		/// <summary>Apply this component to existing markup that is valid. With this function, no call to render() is required.</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public virtual void applyToMarkup(DOMElement el) { _(el); }

		/// <summary>Adds a CSS class to the component's underlying element.</summary>
		/// <returns></returns>
		public virtual void addClass() { _(); }

		/// <summary>Adds a CSS class to the component's underlying element.</summary>
		/// <param name="cls">The CSS class name to add</param>
		/// <returns></returns>
		public virtual void addClass(string cls) { _(cls); }

		/// <summary>Removes a CSS class from the component's underlying element.</summary>
		/// <returns></returns>
		public virtual void removeClass() { _(); }

		/// <summary>Removes a CSS class from the component's underlying element.</summary>
		/// <param name="cls">The CSS class name to remove</param>
		/// <returns></returns>
		public virtual void removeClass(string cls) { _(cls); }

		/// <summary>
		///     Destroys this component by purging any event listeners, removing the component's element from the DOM,
		///     removing the component from its {@link Ext.Container} (if applicable) and unregistering it from
		///     {@link Ext.ComponentMgr}.  Destruction is generally handled automatically by the framework and this method
		///     should usually not need to be called directly.
		/// </summary>
		/// <returns></returns>
		public virtual void destroy() { _(); }

		/// <summary>Returns the underlying {@link Ext.Element}.</summary>
		/// <returns>Ext.Element</returns>
		public virtual void getEl() { _(); }

		/// <summary>Returns the id of this component.</summary>
		/// <returns>String</returns>
		public virtual void getId() { _(); }

		/// <summary>Returns the item id of this component.</summary>
		/// <returns>String</returns>
		public virtual void getItemId() { _(); }

		/// <summary>Try to focus this component.</summary>
		/// <returns>Ext.Component</returns>
		public virtual void focus() { _(); }

		/// <summary>Try to focus this component.</summary>
		/// <param name="selectText">(optional) If applicable, true to also select the text in this component</param>
		/// <returns>Ext.Component</returns>
		public virtual void focus(bool selectText) { _(selectText); }

		/// <summary>Try to focus this component.</summary>
		/// <param name="selectText">(optional) If applicable, true to also select the text in this component</param>
		/// <param name="delay">(optional) Delay the focus this number of milliseconds (true for 10 milliseconds)</param>
		/// <returns>Ext.Component</returns>
		public virtual void focus(bool selectText, bool delay) { _(selectText, delay); }

		/// <summary>Try to focus this component.</summary>
		/// <param name="selectText">(optional) If applicable, true to also select the text in this component</param>
		/// <param name="delay">(optional) Delay the focus this number of milliseconds (true for 10 milliseconds)</param>
		/// <returns>Ext.Component</returns>
		public virtual void focus(bool selectText, double delay) { _(selectText, delay); }

		/// <summary>Disable this component.</summary>
		/// <returns>Ext.Component</returns>
		public virtual void disable() { _(); }

		/// <summary>Enable this component.</summary>
		/// <returns>Ext.Component</returns>
		public virtual void enable() { _(); }

		/// <summary>Convenience function for setting disabled/enabled by boolean.</summary>
		/// <returns></returns>
		public virtual void setDisabled() { _(); }

		/// <summary>Convenience function for setting disabled/enabled by boolean.</summary>
		/// <param name="disabled"></param>
		/// <returns></returns>
		public virtual void setDisabled(bool disabled) { _(disabled); }

		/// <summary>Show this component.</summary>
		/// <returns>Ext.Component</returns>
		public virtual void show() { _(); }

		/// <summary>Hide this component.</summary>
		/// <returns>Ext.Component</returns>
		public virtual void hide() { _(); }

		/// <summary>Convenience function to hide or show this component by boolean.</summary>
		/// <returns>Ext.Component</returns>
		public virtual void setVisible() { _(); }

		/// <summary>Convenience function to hide or show this component by boolean.</summary>
		/// <param name="visible">True to show, false to hide</param>
		/// <returns>Ext.Component</returns>
		public virtual void setVisible(bool visible) { _(visible); }

		/// <summary>Returns true if this component is visible.</summary>
		/// <returns></returns>
		public virtual void isVisible() { _(); }

		/// <summary>
		///     Clone the current component using the original config values passed into this instance by default.
		///     An id property can be passed on this object, otherwise one will be generated to avoid duplicates.
		/// </summary>
		/// <returns>Ext.Component</returns>
		public virtual void cloneConfig() { _(); }

		/// <summary>
		///     Clone the current component using the original config values passed into this instance by default.
		///     An id property can be passed on this object, otherwise one will be generated to avoid duplicates.
		/// </summary>
		/// <param name="overrides">A new config containing any properties to override in the cloned version.</param>
		/// <returns>Ext.Component</returns>
		public virtual void cloneConfig(object overrides) { _(overrides); }

		/// <summary>
		///     Gets the xtype for this component as registered with {@link Ext.ComponentMgr}. For a list of all
		///     available xtypes, see the {@link Ext.Component} header. Example usage:
		///     <pre><code>
		///     var t = new Ext.form.TextField();
		///     alert(t.getXType());  // alerts 'textfield'
		///     </code></pre>
		/// </summary>
		/// <returns>String</returns>
		public virtual void getXType() { _(); }

		/// <summary>
		///     <p>Tests whether or not this Component is of a specific xtype. This can test whether this Component is descended
		///     from the xtype (default) or whether it is directly of the xtype specified (shallow = true).</p>
		///     <p><b>If using your own subclasses, be aware that a Component must register its own xtype
		///     to participate in determination of inherited xtypes.</b></p>
		///     <p>For a list of all available xtypes, see the {@link Ext.Component} header.</p>
		///     <p>Example usage:</p>
		///     <pre><code>
		///     var t = new Ext.form.TextField();
		///     var isText = t.isXType('textfield');        // true
		///     var isBoxSubclass = t.isXType('box');       // true, descended from BoxComponent
		///     var isBoxInstance = t.isXType('box', true); // false, not a direct BoxComponent instance
		///     </code></pre>
		///     the default), or true to check whether this Component is directly of the specified xtype.
		/// </summary>
		/// <returns></returns>
		public virtual void isXType() { _(); }

		/// <summary>
		///     <p>Tests whether or not this Component is of a specific xtype. This can test whether this Component is descended
		///     from the xtype (default) or whether it is directly of the xtype specified (shallow = true).</p>
		///     <p><b>If using your own subclasses, be aware that a Component must register its own xtype
		///     to participate in determination of inherited xtypes.</b></p>
		///     <p>For a list of all available xtypes, see the {@link Ext.Component} header.</p>
		///     <p>Example usage:</p>
		///     <pre><code>
		///     var t = new Ext.form.TextField();
		///     var isText = t.isXType('textfield');        // true
		///     var isBoxSubclass = t.isXType('box');       // true, descended from BoxComponent
		///     var isBoxInstance = t.isXType('box', true); // false, not a direct BoxComponent instance
		///     </code></pre>
		///     the default), or true to check whether this Component is directly of the specified xtype.
		/// </summary>
		/// <param name="xtype">The xtype to check for this Component</param>
		/// <returns></returns>
		public virtual void isXType(System.String xtype) { _(xtype); }

		/// <summary>
		///     <p>Tests whether or not this Component is of a specific xtype. This can test whether this Component is descended
		///     from the xtype (default) or whether it is directly of the xtype specified (shallow = true).</p>
		///     <p><b>If using your own subclasses, be aware that a Component must register its own xtype
		///     to participate in determination of inherited xtypes.</b></p>
		///     <p>For a list of all available xtypes, see the {@link Ext.Component} header.</p>
		///     <p>Example usage:</p>
		///     <pre><code>
		///     var t = new Ext.form.TextField();
		///     var isText = t.isXType('textfield');        // true
		///     var isBoxSubclass = t.isXType('box');       // true, descended from BoxComponent
		///     var isBoxInstance = t.isXType('box', true); // false, not a direct BoxComponent instance
		///     </code></pre>
		///     the default), or true to check whether this Component is directly of the specified xtype.
		/// </summary>
		/// <param name="xtype">The xtype to check for this Component</param>
		/// <param name="shallow">(optional) False to check whether this Component is descended from the xtype (this is</param>
		/// <returns></returns>
		public virtual void isXType(System.String xtype, bool shallow) { _(xtype, shallow); }

		/// <summary>
		///     <p>Returns this Component's xtype hierarchy as a slash-delimited string. For a list of all
		///     available xtypes, see the {@link Ext.Component} header.</p>
		///     <p><b>If using your own subclasses, be aware that a Component must register its own xtype
		///     to participate in determination of inherited xtypes.</b></p>
		///     <p>Example usage:</p>
		///     <pre><code>
		///     var t = new Ext.form.TextField();
		///     alert(t.getXTypes());  // alerts 'component/box/field/textfield'
		///     </pre></code>
		/// </summary>
		/// <returns>String</returns>
		public virtual void getXTypes() { _(); }

		/// <summary>
		///     Find a container above this component at any level by a custom function. If the passed function returns
		///     true, the container will be returned. The passed function is called with the arguments (container, this component).
		/// </summary>
		/// <returns>Array</returns>
		public virtual void findParentBy() { _(); }

		/// <summary>
		///     Find a container above this component at any level by a custom function. If the passed function returns
		///     true, the container will be returned. The passed function is called with the arguments (container, this component).
		/// </summary>
		/// <param name="fcn"></param>
		/// <returns>Array</returns>
		public virtual void findParentBy(Delegate fcn) { _(fcn); }

		/// <summary>
		///     Find a container above this component at any level by a custom function. If the passed function returns
		///     true, the container will be returned. The passed function is called with the arguments (container, this component).
		/// </summary>
		/// <param name="fcn"></param>
		/// <param name="scope">(optional)</param>
		/// <returns>Array</returns>
		public virtual void findParentBy(Delegate fcn, object scope) { _(fcn, scope); }

		/// <summary>Find a container above this component at any level by xtype or class</summary>
		/// <returns>Container</returns>
		public virtual void findParentByType() { _(); }

		/// <summary>Find a container above this component at any level by xtype or class</summary>
		/// <param name="xtype">The xtype string for a component, or the class of the component directly</param>
		/// <returns>Container</returns>
		public virtual void findParentByType(System.String xtype) { _(xtype); }

		/// <summary>Find a container above this component at any level by xtype or class</summary>
		/// <param name="xtype">The xtype string for a component, or the class of the component directly</param>
		/// <returns>Container</returns>
		public virtual void findParentByType(object xtype) { _(xtype); }



	}

	[JsAnonymous]
	public class ComponentConfig : DotWeb.Client.JsAccessible {
		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get; set; }

		/// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
		public System.String id { get; set; }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public System.String cls { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public System.String overCls { get; set; }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public System.String style { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public System.String ctCls { get; set; }

		/// <summary>  Render this component disabled (default is false).</summary>
		public bool disabled { get; set; }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get; set; }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get; set; }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
		public object applyTo { get; set; }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get; set; }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get; set; }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public System.String stateId { get; set; }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public System.String disabledClass { get; set; }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get; set; }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get; set; }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public System.String hideMode { get; set; }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class ComponentEvents {
        /// <summary>Fires after the component is disabled.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string disable { get { return "disable"; } }
        /// <summary>Fires after the component is enabled.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string enable { get { return "enable"; } }
        /// <summary>Fires before the component is shown. Return false to stop the show.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforeshow { get { return "beforeshow"; } }
        /// <summary>Fires after the component is shown.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string show { get { return "show"; } }
        /// <summary>Fires before the component is hidden. Return false to stop the hide.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforehide { get { return "beforehide"; } }
        /// <summary>Fires after the component is hidden.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string hide { get { return "hide"; } }
        /// <summary>Fires before the component is rendered. Return false to stop the render.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforerender { get { return "beforerender"; } }
        /// <summary>Fires after the component is rendered.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string render { get { return "render"; } }
        /// <summary>Fires before the component is destroyed. Return false to stop the destroy.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforedestroy { get { return "beforedestroy"; } }
        /// <summary>Fires after the component is destroyed.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string destroy { get { return "destroy"; } }
        /// <summary>Fires before the state of the component is restored. Return false to stop the restore.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis, {Object} state)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>state</b></term><description>The hash of state values</description></item>
        /// </list>
        /// </summary>
        public static string beforestaterestore { get { return "beforestaterestore"; } }
        /// <summary>Fires after the state of the component is restored.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis, {Object} state)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>state</b></term><description>The hash of state values</description></item>
        /// </list>
        /// </summary>
        public static string staterestore { get { return "staterestore"; } }
        /// <summary>Fires before the state of the component is saved to the configured state provider. Return false to stop the save.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis, {Object} state)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>state</b></term><description>The hash of state values</description></item>
        /// </list>
        /// </summary>
        public static string beforestatesave { get { return "beforestatesave"; } }
        /// <summary>Fires after the state of the component is saved to the configured state provider.
        /// <pre><code>
        /// USAGE: ({Ext.Component} objthis, {Object} state)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>state</b></term><description>The hash of state values</description></item>
        /// </list>
        /// </summary>
        public static string statesave { get { return "statesave"; } }
    }

    public delegate void ComponentDisableDelegate(Ext.Component objthis);
    public delegate void ComponentEnableDelegate(Ext.Component objthis);
    public delegate void ComponentBeforeshowDelegate(Ext.Component objthis);
    public delegate void ComponentShowDelegate(Ext.Component objthis);
    public delegate void ComponentBeforehideDelegate(Ext.Component objthis);
    public delegate void ComponentHideDelegate(Ext.Component objthis);
    public delegate void ComponentBeforerenderDelegate(Ext.Component objthis);
    public delegate void ComponentRenderDelegate(Ext.Component objthis);
    public delegate void ComponentBeforedestroyDelegate(Ext.Component objthis);
    public delegate void ComponentDestroyDelegate(Ext.Component objthis);
    public delegate void ComponentBeforestaterestoreDelegate(Ext.Component objthis, object state);
    public delegate void ComponentStaterestoreDelegate(Ext.Component objthis, object state);
    public delegate void ComponentBeforestatesaveDelegate(Ext.Component objthis, object state);
    public delegate void ComponentStatesaveDelegate(Ext.Component objthis, object state);
}
