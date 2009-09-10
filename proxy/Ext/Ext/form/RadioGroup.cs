using System;
using DotWeb.Client;

namespace Ext.form {
	/// <summary>
	///     /**
	///     A grouping container for {@link Ext.form.Radio} controls.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\form\RadioGroup.js</jssource>
	public class RadioGroup : Ext.form.CheckboxGroup {

		/// <summary>Creates a new CheckboxGroup</summary>
		/// <returns></returns>
		public RadioGroup() { C_(); }
		/// <summary>Creates a new CheckboxGroup</summary>
		/// <param name="config">Configuration options</param>
		/// <returns></returns>
		public RadioGroup(object config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public RadioGroup(Ext.Element config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public RadioGroup(string config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static RadioGroup prototype { get { return S_<RadioGroup>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.form.CheckboxGroup superclass { get { return S_<Ext.form.CheckboxGroup>(); } set { S_(value); } }

		/// <summary>True to allow every item in the group to be blank (defaults to false). If allowBlank =false and no items are selected at validation time, {@link @blankText} will be used as the error text.</summary>
		public bool allowBlank { get { return _<bool>(); } set { _(value); } }

		/// <summary>Error text to display if the {@link #allowBlank} validation fails (defaults to "You mustselect one item in this group")</summary>
		public string blankText { get { return _<string>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class RadioGroupConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> True to allow every item in the group to be blank (defaults to false). If allowBlank = false and no items are selected at validation time, {@link @blankText} will be used as the error text.</summary>
		public bool allowBlank { get { return _<bool>(); } set { _(value); } }

		/// <summary> Error text to display if the {@link #allowBlank} validation fails (defaults to "You must select one item in this group")</summary>
		public string blankText { get { return _<string>(); } set { _(value); } }

		/// <summary>{String/Number/Array} Specifies the number of columns to use when displaying grouped checkbox/radio controls using automatic layout.  This config can take several types of values: <ul><li><b>'auto'</b> : <p class="sub-desc">The controls will be rendered one per column on one row and the width of each column will be evenly distributed based on the width of the overall field container. This is the default.</p></li> <li><b>Number</b> : <p class="sub-desc">If you specific a number (e.g., 3) that number of columns will be created and the contained controls will be automatically distributed based on the value of {@link #vertical}.</p></li> <li><b>Array</b> : Object<p class="sub-desc">You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.</p></li></ul></summary>
		public object columns { get { return _<object>(); } set { _(value); } }

		/// <summary> True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column.  The number of controls in each column will be automatically calculated to keep columns as even as possible.  The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.</summary>
		public bool vertical { get { return _<bool>(); } set { _(value); } }

		/// <summary> The label text to display next to this field (defaults to '')</summary>
		public string fieldLabel { get { return _<string>(); } set { _(value); } }

		/// <summary> A CSS style specification to apply directly to this field's label (defaults to the container's labelStyle value if set, or ''). For example, <code>labelStyle: 'font-weight:bold;'</code>.</summary>
		public string labelStyle { get { return _<string>(); } set { _(value); } }

		/// <summary> The standard separator to display after the text of each form label (defaults to the value of {@link Ext.layout.FormLayout#labelSeparator}, which is a colon ':' by default).  To display no separator for this field's label specify empty string ''.</summary>
		public string labelSeparator { get { return _<string>(); } set { _(value); } }

		/// <summary> True to completely hide the label element (defaults to false)</summary>
		public bool hideLabel { get { return _<bool>(); } set { _(value); } }

		/// <summary> The CSS class used to provide field clearing (defaults to 'x-form-clear-left')</summary>
		public string clearCls { get { return _<string>(); } set { _(value); } }

		/// <summary> An additional CSS class to apply to the wrapper's form item element of this field (defaults to the container's itemCls value if set, or '').  Since it is applied to the item wrapper, it allows you to write standard CSS rules that can apply to the field, the label (if specified) or any other element within the markup for the field. NOTE: this will not have any effect on fields that are not part of a form. Example use: <pre><code> // Apply a style to the field's label: &lt;style> .required .x-form-item-label {font-weight:bold;color:red;} &lt;/style> new Ext.FormPanel({ height: 100, renderTo: document.body, items: [{ xtype: 'textfield', fieldLabel: 'Name', itemCls: 'required' //this label will be styled },{ xtype: 'textfield', fieldLabel: 'Favorite Color' }] }); </code></pre></summary>
		public string itemCls { get { return _<string>(); } set { _(value); } }

		/// <summary> The type attribute for input fields -- e.g. radio, text, password, file (defaults to "text"). The types "file" and "password" must be used to render those field types currently -- there are no separate Ext components for those. Note that if you use <tt>inputType:'file'</tt>, {@link #emptyText} is not supported and should be avoided.</summary>
		public string inputType { get { return _<string>(); } set { _(value); } }

		/// <summary> The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).</summary>
		public double tabIndex { get { return _<double>(); } set { _(value); } }

		/// <summary> A value to initialize this field with (defaults to undefined).</summary>
		public object value { get { return _<object>(); } set { _(value); } }

		/// <summary> The field's HTML name attribute (defaults to "").</summary>
		public string name { get { return _<string>(); } set { _(value); } }

		/// <summary> A custom CSS class to apply to the field's underlying element (defaults to "").</summary>
		public string cls { get { return _<string>(); } set { _(value); } }

		/// <summary> The CSS class to use when marking a field invalid (defaults to "x-form-invalid")</summary>
		public string invalidClass { get { return _<string>(); } set { _(value); } }

		/// <summary> The error text to use when marking a field invalid and no message is provided (defaults to "The value in this field is invalid")</summary>
		public string invalidText { get { return _<string>(); } set { _(value); } }

		/// <summary> The CSS class to use when the field receives focus (defaults to "x-form-focus")</summary>
		public string focusClass { get { return _<string>(); } set { _(value); } }

		/// <summary>{String/Boolean} The event that should initiate field validation. Set to false to disable automatic validation (defaults to "keyup").</summary>
		public object validationEvent { get { return _<object>(); } set { _(value); } }

		/// <summary> Whether the field should validate when it loses focus (defaults to true).</summary>
		public bool validateOnBlur { get { return _<bool>(); } set { _(value); } }

		/// <summary> The length of time in milliseconds after user input begins until validation is initiated (defaults to 250)</summary>
		public double validationDelay { get { return _<double>(); } set { _(value); } }

		/// <summary>{String/Object} A DomHelper element spec, or true for a default element spec (defaults to {tag: "input", type: "text", size: "20", autocomplete: "off"})</summary>
		public object autoCreate { get { return _<object>(); } set { _(value); } }

		/// <summary> The default CSS class for the field (defaults to "x-form-field")</summary>
		public string fieldClass { get { return _<string>(); } set { _(value); } }

		/// <summary> The location where error text should display.  Should be one of the following values (defaults to 'qtip'): <pre> Value         Description -----------   ---------------------------------------------------------------------- qtip          Display a quick tip when the user hovers over the field title         Display a default browser title attribute popup under         Add a block div beneath the field containing the error text side          Add an error icon to the right of the field with a popup on hover [element id]  Add the error text directly to the innerHTML of the specified element </pre></summary>
		public string msgTarget { get { return _<string>(); } set { _(value); } }

		/// <summary> <b>Experimental</b> The effect used when displaying a validation message under the field (defaults to 'normal').</summary>
		public string msgFx { get { return _<string>(); } set { _(value); } }

		/// <summary> True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.</summary>
		public bool readOnly { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to disable the field (defaults to false).</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

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

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return _<string>(); } set { _(value); } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return _<string>(); } set { _(value); } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return _<string>(); } set { _(value); } }

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
