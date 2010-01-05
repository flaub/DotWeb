using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.form {
	/// <summary>
	///     /**
	///     Provides a lightweight HTML Editor component. Some toolbar features are not supported by Safari and will be
	///     automatically hidden when needed.  These are noted in the config options where appropriate.
	///     <br><br>The editor's toolbar buttons have tooltips defined in the {@link #buttonTips} property, but they are not
	///     enabled by default unless the global {@link Ext.QuickTips} singleton is {@link Ext.QuickTips#init initialized}.
	///     <br><br><b>Note: The focus/blur and validation marking functionality inherited from Ext.form.Field is NOT
	///     supported by this editor.</b>
	///     <br><br>An Editor is a sensitive component that can't be used in all spots standard fields can be used. Putting an Editor within
	///     any element that has display set to 'none' can cause problems in Safari and Firefox due to their default iframe reloading bugs.
	///     <br><br>Example usage:
	///     <pre><code>
	///     // Simple example rendered with default options:
	///     Ext.QuickTips.init();  // enable tooltips
	///     new Ext.form.HtmlEditor({
	///     renderTo: Ext.getBody(),
	///     width: 800,
	///     height: 300
	///     });
	///     // Passed via xtype into a container and with custom options:
	///     Ext.QuickTips.init();  // enable tooltips
	///     new Ext.Panel({
	///     title: 'HTML Editor',
	///     renderTo: Ext.getBody(),
	///     width: 600,
	///     height: 300,
	///     frame: true,
	///     layout: 'fit',
	///     items: {
	///     xtype: 'htmleditor',
	///     enableColors: false,
	///     enableAlignments: false
	///     }
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\form\HtmlEditor.js</jssource>
	public class HtmlEditor : Ext.form.Field {

		/// <summary>Create a new HtmlEditor</summary>
		/// <returns></returns>
		public extern HtmlEditor();
		/// <summary>Create a new HtmlEditor</summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern HtmlEditor(object config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern HtmlEditor(Ext.Element config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern HtmlEditor(string config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static HtmlEditor prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.form.Field superclass { get; set; }

		/// <summary>Enable the bold, italic and underline buttons (defaults to true)</summary>
		public extern bool enableFormat { get; set; }

		/// <summary>Enable the increase/decrease font size buttons (defaults to true)</summary>
		public extern bool enableFontSize { get; set; }

		/// <summary>Enable the fore/highlight color buttons (defaults to true)</summary>
		public extern bool enableColors { get; set; }

		/// <summary>Enable the left, center, right alignment buttons (defaults to true)</summary>
		public extern bool enableAlignments { get; set; }

		/// <summary>Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true)</summary>
		public extern bool enableLists { get; set; }

		/// <summary>Enable the switch to source edit button. Not available in Safari. (defaults to true)</summary>
		public extern bool enableSourceEdit { get; set; }

		/// <summary>Enable the create link button. Not available in Safari. (defaults to true)</summary>
		public extern bool enableLinks { get; set; }

		/// <summary>Enable font selection. Not available in Safari. (defaults to true)</summary>
		public extern bool enableFont { get; set; }

		/// <summary>The default text for the create link prompt</summary>
		public extern string createLinkText { get; set; }

		/// <summary>The default value for the create link prompt (defaults to http:/ /)</summary>
		public extern string defaultLinkValue { get; set; }

		/// <summary>An array of available font families</summary>
		public extern System.Array fontFamilies { get; set; }

		/// <summary>
		///     Object collection of toolbar tooltips for the buttons in the editor. The key
		///     is the command id associated with that button and the value is a valid QuickTips object.
		///     For example:
		///     <pre><code>
		///     {
		///     bold : {
		///     title: 'Bold (Ctrl+B)',
		///     text: 'Make the selected text bold.',
		///     cls: 'x-html-editor-tip'
		///     },
		///     italic : {
		///     title: 'Italic (Ctrl+I)',
		///     text: 'Make the selected text italic.',
		///     cls: 'x-html-editor-tip'
		///     },
		///     ...
		///     </code></pre>
		/// </summary>
		public extern object buttonTips { get; set; }


		/// <summary>
		///     Protected method that will not generally be called directly. It
		///     is called when the editor initializes the iframe with HTML contents. Override this method if you
		///     want to change the initialization markup of the iframe (e.g. to add stylesheets).
		/// </summary>
		/// <returns></returns>
		public extern virtual void getDocMarkup();

		/// <summary>Toggles the editor between standard and source edit mode.</summary>
		/// <returns></returns>
		public extern virtual void toggleSourceEdit();

		/// <summary>Toggles the editor between standard and source edit mode.</summary>
		/// <param name="sourceEdit">(optional) True for source edit, false for standard</param>
		/// <returns></returns>
		public extern virtual void toggleSourceEdit(bool sourceEdit);

		/// <summary>Overridden and disabled. The editor element does not support standard valid/invalid marking. @hide</summary>
		/// <returns></returns>
		public extern virtual void markInvalid();

		/// <summary>Overridden and disabled. The editor element does not support standard valid/invalid marking. @hide</summary>
		/// <returns></returns>
		public extern virtual void clearInvalid();

		/// <summary>
		///     Protected method that will not generally be called directly. If you need/want
		///     custom HTML cleanup, this is the method you should override.
		///     return {String} The cleaned HTML
		/// </summary>
		/// <returns></returns>
		public extern virtual void cleanHtml();

		/// <summary>
		///     Protected method that will not generally be called directly. If you need/want
		///     custom HTML cleanup, this is the method you should override.
		///     return {String} The cleaned HTML
		/// </summary>
		/// <param name="html">The HTML to be cleaned</param>
		/// <returns></returns>
		public extern virtual void cleanHtml(string html);

		/// <summary>
		///     Protected method that will not generally be called directly. Syncs the contents
		///     of the editor iframe with the textarea.
		/// </summary>
		/// <returns></returns>
		public extern virtual void syncValue();

		/// <summary>
		///     Protected method that will not generally be called directly. Pushes the value of the textarea
		///     into the iframe editor.
		/// </summary>
		/// <returns></returns>
		public extern virtual void pushValue();

		/// <summary>
		///     Protected method that will not generally be called directly. It triggers
		///     a toolbar update by reading the markup state of the current selection in the editor.
		/// </summary>
		/// <returns></returns>
		public extern virtual void updateToolbar();

		/// <summary>
		///     Executes a Midas editor command on the editor document and performs necessary focus and
		///     toolbar updates. <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <returns></returns>
		public extern virtual void relayCmd();

		/// <summary>
		///     Executes a Midas editor command on the editor document and performs necessary focus and
		///     toolbar updates. <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <param name="cmd">The Midas command</param>
		/// <returns></returns>
		public extern virtual void relayCmd(string cmd);

		/// <summary>
		///     Executes a Midas editor command on the editor document and performs necessary focus and
		///     toolbar updates. <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <param name="cmd">The Midas command</param>
		/// <param name="value">(optional) The value to pass to the command (defaults to null)</param>
		/// <returns></returns>
		public extern virtual void relayCmd(string cmd, string value);

		/// <summary>
		///     Executes a Midas editor command on the editor document and performs necessary focus and
		///     toolbar updates. <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <param name="cmd">The Midas command</param>
		/// <param name="value">(optional) The value to pass to the command (defaults to null)</param>
		/// <returns></returns>
		public extern virtual void relayCmd(string cmd, bool value);

		/// <summary>
		///     Executes a Midas editor command directly on the editor document.
		///     For visual commands, you should use {@link #relayCmd} instead.
		///     <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <returns></returns>
		public extern virtual void execCmd();

		/// <summary>
		///     Executes a Midas editor command directly on the editor document.
		///     For visual commands, you should use {@link #relayCmd} instead.
		///     <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <param name="cmd">The Midas command</param>
		/// <returns></returns>
		public extern virtual void execCmd(string cmd);

		/// <summary>
		///     Executes a Midas editor command directly on the editor document.
		///     For visual commands, you should use {@link #relayCmd} instead.
		///     <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <param name="cmd">The Midas command</param>
		/// <param name="value">(optional) The value to pass to the command (defaults to null)</param>
		/// <returns></returns>
		public extern virtual void execCmd(string cmd, string value);

		/// <summary>
		///     Executes a Midas editor command directly on the editor document.
		///     For visual commands, you should use {@link #relayCmd} instead.
		///     <b>This should only be called after the editor is initialized.</b>
		/// </summary>
		/// <param name="cmd">The Midas command</param>
		/// <param name="value">(optional) The value to pass to the command (defaults to null)</param>
		/// <returns></returns>
		public extern virtual void execCmd(string cmd, bool value);

		/// <summary>
		///     Inserts the passed text at the current cursor position. Note: the editor must be initialized and activated
		///     to insert text.
		/// </summary>
		/// <returns></returns>
		public extern virtual void insertAtCursor();

		/// <summary>
		///     Inserts the passed text at the current cursor position. Note: the editor must be initialized and activated
		///     to insert text.
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public extern virtual void insertAtCursor(string text);

		/// <summary>Returns the editor's toolbar. <b>This is only available after the editor has been rendered.</b></summary>
		/// <returns>Ext.Toolbar</returns>
		public extern virtual void getToolbar();

		/// <summary>@hide</summary>
		/// <returns></returns>
		public extern virtual void applyToMarkup();

		/// <summary>@hide</summary>
		/// <returns></returns>
		public extern virtual void disable();

		/// <summary>@hide</summary>
		/// <returns></returns>
		public extern virtual void enable();

		/// <summary>@hide</summary>
		/// <returns></returns>
		public extern virtual void validate();

		/// <summary>@hide</summary>
		/// <returns></returns>
		public extern virtual void setDisabled();



	}

	[JsAnonymous]
	public class HtmlEditorConfig : System.DotWeb.JsDynamic {
		/// <summary> Enable the bold, italic and underline buttons (defaults to true)</summary>
		public bool enableFormat { get { return (bool)this["enableFormat"]; } set { this["enableFormat"] = value; } }

		/// <summary> Enable the increase/decrease font size buttons (defaults to true)</summary>
		public bool enableFontSize { get { return (bool)this["enableFontSize"]; } set { this["enableFontSize"] = value; } }

		/// <summary> Enable the fore/highlight color buttons (defaults to true)</summary>
		public bool enableColors { get { return (bool)this["enableColors"]; } set { this["enableColors"] = value; } }

		/// <summary> Enable the left, center, right alignment buttons (defaults to true)</summary>
		public bool enableAlignments { get { return (bool)this["enableAlignments"]; } set { this["enableAlignments"] = value; } }

		/// <summary> Enable the bullet and numbered list buttons. Not available in Safari. (defaults to true)</summary>
		public bool enableLists { get { return (bool)this["enableLists"]; } set { this["enableLists"] = value; } }

		/// <summary> Enable the switch to source edit button. Not available in Safari. (defaults to true)</summary>
		public bool enableSourceEdit { get { return (bool)this["enableSourceEdit"]; } set { this["enableSourceEdit"] = value; } }

		/// <summary> Enable the create link button. Not available in Safari. (defaults to true)</summary>
		public bool enableLinks { get { return (bool)this["enableLinks"]; } set { this["enableLinks"] = value; } }

		/// <summary> Enable font selection. Not available in Safari. (defaults to true)</summary>
		public bool enableFont { get { return (bool)this["enableFont"]; } set { this["enableFont"] = value; } }

		/// <summary> The default text for the create link prompt</summary>
		public string createLinkText { get { return (string)this["createLinkText"]; } set { this["createLinkText"] = value; } }

		/// <summary> The default value for the create link prompt (defaults to http:/ /)</summary>
		public string defaultLinkValue { get { return (string)this["defaultLinkValue"]; } set { this["defaultLinkValue"] = value; } }

		/// <summary> An array of available font families</summary>
		public System.Array fontFamilies { get { return (System.Array)this["fontFamilies"]; } set { this["fontFamilies"] = value; } }

		/// <summary> The label text to display next to this field (defaults to '')</summary>
		public string fieldLabel { get { return (string)this["fieldLabel"]; } set { this["fieldLabel"] = value; } }

		/// <summary> A CSS style specification to apply directly to this field's label (defaults to the container's labelStyle value if set, or ''). For example, <code>labelStyle: 'font-weight:bold;'</code>.</summary>
		public string labelStyle { get { return (string)this["labelStyle"]; } set { this["labelStyle"] = value; } }

		/// <summary> The standard separator to display after the text of each form label (defaults to the value of {@link Ext.layout.FormLayout#labelSeparator}, which is a colon ':' by default).  To display no separator for this field's label specify empty string ''.</summary>
		public string labelSeparator { get { return (string)this["labelSeparator"]; } set { this["labelSeparator"] = value; } }

		/// <summary> True to completely hide the label element (defaults to false)</summary>
		public bool hideLabel { get { return (bool)this["hideLabel"]; } set { this["hideLabel"] = value; } }

		/// <summary> The CSS class used to provide field clearing (defaults to 'x-form-clear-left')</summary>
		public string clearCls { get { return (string)this["clearCls"]; } set { this["clearCls"] = value; } }

		/// <summary> An additional CSS class to apply to the wrapper's form item element of this field (defaults to the container's itemCls value if set, or '').  Since it is applied to the item wrapper, it allows you to write standard CSS rules that can apply to the field, the label (if specified) or any other element within the markup for the field. NOTE: this will not have any effect on fields that are not part of a form. Example use: <pre><code> // Apply a style to the field's label: &lt;style> .required .x-form-item-label {font-weight:bold;color:red;} &lt;/style> new Ext.FormPanel({ height: 100, renderTo: document.body, items: [{ xtype: 'textfield', fieldLabel: 'Name', itemCls: 'required' //this label will be styled },{ xtype: 'textfield', fieldLabel: 'Favorite Color' }] }); </code></pre></summary>
		public string itemCls { get { return (string)this["itemCls"]; } set { this["itemCls"] = value; } }

		/// <summary> The type attribute for input fields -- e.g. radio, text, password, file (defaults to "text"). The types "file" and "password" must be used to render those field types currently -- there are no separate Ext components for those. Note that if you use <tt>inputType:'file'</tt>, {@link #emptyText} is not supported and should be avoided.</summary>
		public string inputType { get { return (string)this["inputType"]; } set { this["inputType"] = value; } }

		/// <summary> The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).</summary>
		public double tabIndex { get { return (double)this["tabIndex"]; } set { this["tabIndex"] = value; } }

		/// <summary> A value to initialize this field with (defaults to undefined).</summary>
		public object value { get { return (object)this["value"]; } set { this["value"] = value; } }

		/// <summary> The field's HTML name attribute (defaults to "").</summary>
		public string name { get { return (string)this["name"]; } set { this["name"] = value; } }

		/// <summary> A custom CSS class to apply to the field's underlying element (defaults to "").</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

		/// <summary> The CSS class to use when marking a field invalid (defaults to "x-form-invalid")</summary>
		public string invalidClass { get { return (string)this["invalidClass"]; } set { this["invalidClass"] = value; } }

		/// <summary> The error text to use when marking a field invalid and no message is provided (defaults to "The value in this field is invalid")</summary>
		public string invalidText { get { return (string)this["invalidText"]; } set { this["invalidText"] = value; } }

		/// <summary> The CSS class to use when the field receives focus (defaults to "x-form-focus")</summary>
		public string focusClass { get { return (string)this["focusClass"]; } set { this["focusClass"] = value; } }

		/// <summary>{String/Boolean} The event that should initiate field validation. Set to false to disable automatic validation (defaults to "keyup").</summary>
		public object validationEvent { get { return (object)this["validationEvent"]; } set { this["validationEvent"] = value; } }

		/// <summary> Whether the field should validate when it loses focus (defaults to true).</summary>
		public bool validateOnBlur { get { return (bool)this["validateOnBlur"]; } set { this["validateOnBlur"] = value; } }

		/// <summary> The length of time in milliseconds after user input begins until validation is initiated (defaults to 250)</summary>
		public double validationDelay { get { return (double)this["validationDelay"]; } set { this["validationDelay"] = value; } }

		/// <summary>{String/Object} A DomHelper element spec, or true for a default element spec (defaults to {tag: "input", type: "text", size: "20", autocomplete: "off"})</summary>
		public object autoCreate { get { return (object)this["autoCreate"]; } set { this["autoCreate"] = value; } }

		/// <summary> The default CSS class for the field (defaults to "x-form-field")</summary>
		public string fieldClass { get { return (string)this["fieldClass"]; } set { this["fieldClass"] = value; } }

		/// <summary> The location where error text should display.  Should be one of the following values (defaults to 'qtip'): <pre> Value         Description -----------   ---------------------------------------------------------------------- qtip          Display a quick tip when the user hovers over the field title         Display a default browser title attribute popup under         Add a block div beneath the field containing the error text side          Add an error icon to the right of the field with a popup on hover [element id]  Add the error text directly to the innerHTML of the specified element </pre></summary>
		public string msgTarget { get { return (string)this["msgTarget"]; } set { this["msgTarget"] = value; } }

		/// <summary> <b>Experimental</b> The effect used when displaying a validation message under the field (defaults to 'normal').</summary>
		public string msgFx { get { return (string)this["msgFx"]; } set { this["msgFx"] = value; } }

		/// <summary> True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.</summary>
		public bool readOnly { get { return (bool)this["readOnly"]; } set { this["readOnly"] = value; } }

		/// <summary> True to disable the field (defaults to false).</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

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

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return (string)this["overCls"]; } set { this["overCls"] = value; } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return (string)this["style"]; } set { this["style"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return (string)this["ctCls"]; } set { this["ctCls"] = value; } }

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

    public class HtmlEditorEvents {
        /// <summary>Fires when the editor is fully initialized (including the iframe)
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string initialize { get { return "initialize"; } }
        /// <summary>
        ///     Fires when the editor is first receives the focus. Any insertion must wait
        ///     until after this event.
        /// 
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string activate { get { return "activate"; } }
        /// <summary>
        ///     Fires before the textarea is updated with content from the editor iframe. Return false
        ///     to cancel the sync.
        /// 
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis, {String} html)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>html</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforesync { get { return "beforesync"; } }
        /// <summary>
        ///     Fires before the iframe editor is updated with content from the textarea. Return false
        ///     to cancel the push.
        /// 
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis, {String} html)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>html</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforepush { get { return "beforepush"; } }
        /// <summary>Fires when the textarea is updated with content from the editor iframe.
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis, {String} html)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>html</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string sync { get { return "sync"; } }
        /// <summary>Fires when the iframe editor is updated with content from the textarea.
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis, {String} html)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>html</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string push { get { return "push"; } }
        /// <summary>Fires when the editor switches edit modes
        /// <pre><code>
        /// USAGE: ({HtmlEditor} objthis, {Boolean} sourceEdit)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>sourceEdit</b></term><description>True if source edit, false if standard editing.</description></item>
        /// </list>
        /// </summary>
        public static string editmodechange { get { return "editmodechange"; } }
    }

    public delegate void HtmlEditorInitializeDelegate(HtmlEditor objthis);
    public delegate void HtmlEditorActivateDelegate(HtmlEditor objthis);
    public delegate void HtmlEditorBeforesyncDelegate(HtmlEditor objthis, string html);
    public delegate void HtmlEditorBeforepushDelegate(HtmlEditor objthis, string html);
    public delegate void HtmlEditorSyncDelegate(HtmlEditor objthis, string html);
    public delegate void HtmlEditorPushDelegate(HtmlEditor objthis, string html);
    public delegate void HtmlEditorEditmodechangeDelegate(HtmlEditor objthis, bool sourceEdit);
}
