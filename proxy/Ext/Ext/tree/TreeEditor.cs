using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     Provides editor functionality for inline tree node editing.  Any valid {@link Ext.form.Field} subclass can be used
	///     as the editor field.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeEditor.js</jssource>
	public class TreeEditor : Ext.Editor {

		/// <summary>that will be applied to the default field instance (defaults to a {@link Ext.form.TextField}).</summary>
		/// <returns></returns>
		public TreeEditor() { C_(); }
		/// <summary>that will be applied to the default field instance (defaults to a {@link Ext.form.TextField}).</summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		public TreeEditor(TreePanel tree) { C_(tree); }
		/// <summary>that will be applied to the default field instance (defaults to a {@link Ext.form.TextField}).</summary>
		/// <param name="tree"></param>
		/// <param name="fieldConfig">(optional) Either a prebuilt {@link Ext.form.Field} instance or a Field config object</param>
		/// <returns></returns>
		public TreeEditor(TreePanel tree, object fieldConfig) { C_(tree, fieldConfig); }
		/// <summary>that will be applied to the default field instance (defaults to a {@link Ext.form.TextField}).</summary>
		/// <param name="tree"></param>
		/// <param name="fieldConfig">(optional) Either a prebuilt {@link Ext.form.Field} instance or a Field config object</param>
		/// <param name="config">(optional) A TreeEditor config object</param>
		/// <returns></returns>
		public TreeEditor(TreePanel tree, object fieldConfig, object config) { C_(tree, fieldConfig, config); }
		/// <summary>Create a new Editor</summary>
		/// <param name="field">The Field object (or descendant)</param>
		/// <returns></returns>
		public TreeEditor(Ext.form.Field field) { C_(field); }
		/// <summary>Create a new Editor</summary>
		/// <param name="field">The Field object (or descendant)</param>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public TreeEditor(Ext.form.Field field, object config) { C_(field, config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public TreeEditor(Ext.Element config) { C_(config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public TreeEditor(string config) { C_(config); }
		/// <summary>
		///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
		///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
		/// </summary>
		/// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
		/// <returns></returns>
		public TreeEditor(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TreeEditor prototype { get { return S_<TreeEditor>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.Editor superclass { get { return S_<Ext.Editor>(); } set { S_(value); } }

		/// <summary>The position to align to (see {@link Ext.Element#alignTo} for more details, defaults to "l-l").</summary>
		public string alignment { get { return _<string>(); } set { _(value); } }

		/// <summary>True to hide the bound element while the editor is displayed (defaults to false)</summary>
		public bool hideEl { get { return _<bool>(); } set { _(value); } }

		/// <summary>CSS class to apply to the editor (defaults to "x-small-editor x-tree-editor")</summary>
		public string cls { get { return _<string>(); } set { _(value); } }

		/// <summary>True to shim the editor if selects/iframes could be displayed beneath it (defaults to false)</summary>
		public bool shim { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     The maximum width in pixels of the editor field (defaults to 250).  Note that if the maxWidth would exceed
		///     the containing tree element's size, it will be automatically limited for you to the container width, taking
		///     scroll and client offsets into account prior to each edit.
		/// </summary>
		public double maxWidth { get { return _<double>(); } set { _(value); } }

		/// <summary>
		///     The number of milliseconds between clicks to register a double-click that will triggerediting on the current node (defaults to 350).  If two clicks occur on the same node within this time span,
		///     the editor for the node will display, otherwise it will be processed as a regular click.
		/// </summary>
		public double editDelay { get { return _<double>(); } set { _(value); } }

		/// <summary>The tree node this editor is bound to. Read-only.</summary>
		public Ext.tree.TreeNode editNode { get { return _<Ext.tree.TreeNode>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class TreeEditorConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>  The position to align to (see {@link Ext.Element#alignTo} for more details, defaults to "l-l").</summary>
		public string alignment { get { return _<string>(); } set { _(value); } }

		/// <summary>  True to hide the bound element while the editor is displayed (defaults to false)</summary>
		public bool hideEl { get { return _<bool>(); } set { _(value); } }

		/// <summary>  CSS class to apply to the editor (defaults to "x-small-editor x-tree-editor")</summary>
		public string cls { get { return _<string>(); } set { _(value); } }

		/// <summary>  True to shim the editor if selects/iframes could be displayed beneath it (defaults to false)</summary>
		public bool shim { get { return _<bool>(); } set { _(value); } }

		/// <summary>  The maximum width in pixels of the editor field (defaults to 250).  Note that if the maxWidth would exceed the containing tree element's size, it will be automatically limited for you to the container width, taking scroll and client offsets into account prior to each edit.</summary>
		public double maxWidth { get { return _<double>(); } set { _(value); } }

		/// <summary> The number of milliseconds between clicks to register a double-click that will trigger editing on the current node (defaults to 350).  If two clicks occur on the same node within this time span, the editor for the node will display, otherwise it will be processed as a regular click.</summary>
		public double editDelay { get { return _<double>(); } set { _(value); } }

		/// <summary>{Boolean/String}  True for the editor to automatically adopt the size of the underlying field, "width" to adopt the width only, or "height" to adopt the height only (defaults to false)</summary>
		public object autoSize { get { return _<object>(); } set { _(value); } }

		/// <summary>  True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)</summary>
		public bool revertInvalid { get { return _<bool>(); } set { _(value); } }

		/// <summary>  True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false).  Applies only to string values - edits for other data types will never be ignored.</summary>
		public bool ignoreNoChange { get { return _<bool>(); } set { _(value); } }

		/// <summary>  The data value of the underlying field (defaults to "")</summary>
		public object value { get { return _<object>(); } set { _(value); } }

		/// <summary>{Boolean/String} "sides" for sides/bottom only, "frame" for 4-way shadow, and "drop" for bottom-right shadow (defaults to "frame")</summary>
		public object shadow { get { return _<object>(); } set { _(value); } }

		/// <summary> True to constrain the editor to the viewport</summary>
		public bool constrain { get { return _<bool>(); } set { _(value); } }

		/// <summary> Handle the keydown/keypress events so they don't propagate (defaults to true)</summary>
		public bool swallowKeys { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to complete the edit when the enter key is pressed (defaults to false)</summary>
		public bool completeOnEnter { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to cancel the edit when the escape key is pressed (defaults to false)</summary>
		public bool cancelOnEsc { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to update the innerHTML of the bound element when the update completes (defaults to false)</summary>
		public bool updateEl { get { return _<bool>(); } set { _(value); } }

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
