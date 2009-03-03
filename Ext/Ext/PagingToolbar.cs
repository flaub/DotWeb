using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     A specialized toolbar that is bound to a {@link Ext.data.Store} and provides automatic paging controls.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\PagingToolbar.js</jssource>
	public class PagingToolbar : Ext.ToolbarClass {

		/// <summary>Create a new PagingToolbar</summary>
		/// <returns></returns>
		public PagingToolbar() { C_(); }
		/// <summary>Create a new PagingToolbar</summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public PagingToolbar(object config) { C_(config); }
		/// <summary>Creates a new Toolbar</summary>
		/// <param name="config">A config object or an array of buttons to add</param>
		/// <returns></returns>
		public PagingToolbar(System.Array config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public PagingToolbar(Ext.Element config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public PagingToolbar(System.String config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static PagingToolbar prototype { get { return S_<PagingToolbar>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.ToolbarClass superclass { get { return S_<Ext.ToolbarClass>(); } set { S_(value); } }

		/// <summary>The {@link Ext.data.Store} the paging toolbar should use as its data source (required).</summary>
		public Ext.data.Store store { get { return _<Ext.data.Store>(); } set { _(value); } }

		/// <summary>True to display the displayMsg (defaults to false)</summary>
		public bool displayInfo { get { return _<bool>(); } set { _(value); } }

		/// <summary>The number of records to display per page (defaults to 20)</summary>
		public double pageSize { get { return _<double>(); } set { _(value); } }

		/// <summary>
		///     The paging status message to display (defaults to "Displaying {0} - {1} of {2}").  Note that this string is
		///     formatted using the braced numbers 0-2 as tokens that are replaced by the values for start, end and total
		///     respectively. These tokens should be preserved when overriding this string if showing those values is desired.
		/// </summary>
		public System.String displayMsg { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The message to display when no records are found (defaults to "No data to display")</summary>
		public System.String emptyMsg { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Customizable piece of the default paging text (defaults to "Page")</summary>
		public System.String beforePageText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     Customizable piece of the default paging text (defaults to "of {0}"). Note that this string is
		///     formatted using {0} as a token that is replaced by the number of total pages. This token should be
		///     preserved when overriding this string if showing the total page count is desired.
		/// </summary>
		public System.String afterPageText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Customizable piece of the default paging text (defaults to "First Page")</summary>
		public System.String firstText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Customizable piece of the default paging text (defaults to "Previous Page")</summary>
		public System.String prevText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Customizable piece of the default paging text (defaults to "Next Page")</summary>
		public System.String nextText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Customizable piece of the default paging text (defaults to "Last Page")</summary>
		public System.String lastText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Customizable piece of the default paging text (defaults to "Refresh")</summary>
		public System.String refreshText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Object mapping of parameter names for load calls (defaults to {start: 'start', limit: 'limit'})</summary>
		public object paramNames { get { return _<object>(); } set { _(value); } }


		/// <summary>Change the active page</summary>
		/// <returns></returns>
		public virtual void changePage() { _(); }

		/// <summary>Change the active page</summary>
		/// <param name="page">The page to display</param>
		/// <returns></returns>
		public virtual void changePage(System.Number page) { _(page); }

		/// <summary>Unbinds the paging toolbar from the specified {@link Ext.data.Store}</summary>
		/// <returns></returns>
		public virtual void unbind() { _(); }

		/// <summary>Unbinds the paging toolbar from the specified {@link Ext.data.Store}</summary>
		/// <param name="store">The data store to unbind</param>
		/// <returns></returns>
		public virtual void unbind(Ext.data.Store store) { _(store); }

		/// <summary>Binds the paging toolbar to the specified {@link Ext.data.Store}</summary>
		/// <returns></returns>
		public virtual void bind() { _(); }

		/// <summary>Binds the paging toolbar to the specified {@link Ext.data.Store}</summary>
		/// <param name="store">The data store to bind</param>
		/// <returns></returns>
		public virtual void bind(Ext.data.Store store) { _(store); }



	}

	[JsAnonymous]
	public class PagingToolbarConfig : DotWeb.Client.JsAccessible {
		/// <summary> The {@link Ext.data.Store} the paging toolbar should use as its data source (required).</summary>
		public Ext.data.Store store { get; set; }

		/// <summary>  True to display the displayMsg (defaults to false)</summary>
		public bool displayInfo { get; set; }

		/// <summary>  The number of records to display per page (defaults to 20)</summary>
		public double pageSize { get; set; }

		/// <summary>  The paging status message to display (defaults to "Displaying {0} - {1} of {2}").  Note that this string is formatted using the braced numbers 0-2 as tokens that are replaced by the values for start, end and total respectively. These tokens should be preserved when overriding this string if showing those values is desired.</summary>
		public System.String displayMsg { get; set; }

		/// <summary>  The message to display when no records are found (defaults to "No data to display")</summary>
		public System.String emptyMsg { get; set; }

		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get; set; }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get; set; }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get; set; }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get; set; }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get; set; }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get; set; }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get; set; }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get; set; }

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
}
