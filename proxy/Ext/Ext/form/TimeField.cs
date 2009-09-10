using System;
using DotWeb.Client;

namespace Ext.form {
	/// <summary>
	///     /**
	///     Provides a time input field with a time dropdown and automatic time validation.  Example usage:
	///     <pre><code>
	///     new Ext.form.TimeField({
	///     minValue: '9:00 AM',
	///     maxValue: '6:00 PM',
	///     increment: 30
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\form\TimeField.js</jssource>
	public class TimeField : Ext.form.ComboBox {

		/// <summary>Create a new TimeField</summary>
		/// <returns></returns>
		public TimeField() { C_(); }
		/// <summary>Create a new TimeField</summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public TimeField(object config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public TimeField(Ext.Element config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public TimeField(string config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TimeField prototype { get { return S_<TimeField>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.form.ComboBox superclass { get { return S_<Ext.form.ComboBox>(); } set { S_(value); } }

		/// <summary>
		///     The minimum allowed time. Can be either a Javascript date object with a valid time value or a string
		///     time in a valid format -- see {@link #format} and {@link #altFormats} (defaults to null).
		/// </summary>
		public object minValue { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     The maximum allowed time. Can be either a Javascript date object with a valid time value or a string
		///     time in a valid format -- see {@link #format} and {@link #altFormats} (defaults to null).
		/// </summary>
		public object maxValue { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     The error text to display when the date in the cell is before minValue (defaults to
		///     'The time in this field must be equal to or after {0}').
		/// </summary>
		public string minText { get { return _<string>(); } set { _(value); } }

		/// <summary>
		///     The error text to display when the time is after maxValue (defaults to
		///     'The time in this field must be equal to or before {0}').
		/// </summary>
		public string maxText { get { return _<string>(); } set { _(value); } }

		/// <summary>
		///     The error text to display when the time in the field is invalid (defaults to
		///     '{value} is not a valid time').
		/// </summary>
		public string invalidText { get { return _<string>(); } set { _(value); } }

		/// <summary>
		///     The default time format string which can be overriden for localization support.  The format must be
		///     valid according to {@link Date#parseDate} (defaults to 'g:i A', e.g., '3:15 PM').  For 24-hour time
		///     format try 'H:i' instead.
		/// </summary>
		public string format { get { return _<string>(); } set { _(value); } }

		/// <summary>
		///     Multiple date formats separated by "|" to try when parsing a user input value and it doesn't match the defined
		///     format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H').
		/// </summary>
		public string altFormats { get { return _<string>(); } set { _(value); } }

		/// <summary>The number of minutes between each time value in the list (defaults to 15).</summary>
		public double increment { get { return _<double>(); } set { _(value); } }


		/// <summary>@hide</summary>
		/// <returns></returns>
		public virtual void autoSize() { _(); }



	}

	[JsAnonymous]
	public class TimeFieldConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>{Date/String}  The minimum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see {@link #format} and {@link #altFormats} (defaults to null).</summary>
		public object minValue { get { return _<object>(); } set { _(value); } }

		/// <summary>{Date/String}  The maximum allowed time. Can be either a Javascript date object with a valid time value or a string time in a valid format -- see {@link #format} and {@link #altFormats} (defaults to null).</summary>
		public object maxValue { get { return _<object>(); } set { _(value); } }

		/// <summary>  The error text to display when the date in the cell is before minValue (defaults to 'The time in this field must be equal to or after {0}').</summary>
		public string minText { get { return _<string>(); } set { _(value); } }

		/// <summary>  The error text to display when the time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').</summary>
		public string maxText { get { return _<string>(); } set { _(value); } }

		/// <summary>  The error text to display when the time in the field is invalid (defaults to '{value} is not a valid time').</summary>
		public string invalidText { get { return _<string>(); } set { _(value); } }

		/// <summary>  The default time format string which can be overriden for localization support.  The format must be valid according to {@link Date#parseDate} (defaults to 'g:i A', e.g., '3:15 PM').  For 24-hour time format try 'H:i' instead.</summary>
		public string format { get { return _<string>(); } set { _(value); } }

		/// <summary>  Multiple date formats separated by "|" to try when parsing a user input value and it doesn't match the defined format (defaults to 'g:ia|g:iA|g:i a|g:i A|h:i|g:i|H:i|ga|ha|gA|h a|g a|g A|gi|hi|gia|hia|g|H').</summary>
		public string altFormats { get { return _<string>(); } set { _(value); } }

		/// <summary>  The number of minutes between each time value in the list (defaults to 15).</summary>
		public double increment { get { return _<double>(); } set { _(value); } }

		/// <summary> The id, DOM node or element of an existing HTML SELECT to convert to a ComboBox. Note that if you specify this and the combo is going to be in a {@link Ext.form.BasicForm} or {@link Ext.form.FormPanel}, you must also set {@link #lazyRender} = true.</summary>
		public object transform { get { return _<object>(); } set { _(value); } }

		/// <summary> True to prevent the ComboBox from rendering until requested (should always be used when rendering into an Ext.Editor, defaults to false).</summary>
		public bool lazyRender { get { return _<bool>(); } set { _(value); } }

		/// <summary>{Boolean/Object} A DomHelper element spec, or true for a default element spec (defaults to: {tag: "input", type: "text", size: "24", autocomplete: "off"})</summary>
		public object autoCreate { get { return _<object>(); } set { _(value); } }

		/// <summary>{Ext.data.Store/Array} The data source to which this combo is bound (defaults to undefined).  This can be any {@link Ext.data.Store} subclass, a 1-dimensional array (e.g., ['Foo','Bar']) or a 2-dimensional array (e.g., [['f','Foo'],['b','Bar']]).  Arrays will be converted to a {@link Ext.data.SimpleStore} internally. 1-dimensional arrays will automatically be expanded (each array item will be the combo value and text) and for multi-dimensional arrays, the value in index 0 of each item will be assumed to be the combo value, while the value at index 1 is assumed to be the combo text.</summary>
		public object store { get { return _<object>(); } set { _(value); } }

		/// <summary> If supplied, a header element is created containing this text and added into the top of the dropdown list (defaults to undefined, with no header element)</summary>
		public string title { get { return _<string>(); } set { _(value); } }

		/// <summary> The width in pixels of the dropdown list (defaults to the width of the ComboBox field)</summary>
		public double listWidth { get { return _<double>(); } set { _(value); } }

		/// <summary> The underlying data field name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'text' if transforming a select)</summary>
		public string displayField { get { return _<string>(); } set { _(value); } }

		/// <summary> The underlying data value name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'value' if transforming a select) Note: use of a valueField requires the user to make a selection in order for a value to be mapped.</summary>
		public string valueField { get { return _<string>(); } set { _(value); } }

		/// <summary> If specified, a hidden form field with this name is dynamically generated to store the field's data value (defaults to the underlying DOM element's name). Required for the combo's value to automatically post during a form submission.  Note that the hidden field's id will also default to this name if {@link #hiddenId} is not specified.  The combo's id and the hidden field's ids should be different, since no two DOM nodes should share the same id, so if the combo and hidden names are the same, you should specify a unique hiddenId.</summary>
		public string hiddenName { get { return _<string>(); } set { _(value); } }

		/// <summary> If {@link #hiddenName} is specified, hiddenId can also be provided to give the hidden field a unique id (defaults to the hiddenName).  The hiddenId and combo {@link #id} should be different, since no two DOM nodes should share the same id.</summary>
		public string hiddenId { get { return _<string>(); } set { _(value); } }

		/// <summary> CSS class to apply to the dropdown list element (defaults to '')</summary>
		public string listClass { get { return _<string>(); } set { _(value); } }

		/// <summary> CSS class to apply to the selected item in the dropdown list (defaults to 'x-combo-selected')</summary>
		public string selectedClass { get { return _<string>(); } set { _(value); } }

		/// <summary> An additional CSS class used to style the trigger button.  The trigger will always get the class 'x-form-trigger' and triggerClass will be <b>appended</b> if specified (defaults to 'x-form-arrow-trigger' which displays a downward arrow icon).</summary>
		public string triggerClass { get { return _<string>(); } set { _(value); } }

		/// <summary>{Boolean/String} True or "sides" for the default effect, "frame" for 4-way shadow, and "drop" for bottom-right</summary>
		public object shadow { get { return _<object>(); } set { _(value); } }

		/// <summary> A valid anchor position value. See {@link Ext.Element#alignTo} for details on supported anchor positions (defaults to 'tl-bl')</summary>
		public string listAlign { get { return _<string>(); } set { _(value); } }

		/// <summary> The maximum height in pixels of the dropdown list before scrollbars are shown (defaults to 300)</summary>
		public double maxHeight { get { return _<double>(); } set { _(value); } }

		/// <summary> The minimum height in pixels of the dropdown list when the list is constrained by its distance to the viewport edges (defaults to 90)</summary>
		public double minHeight { get { return _<double>(); } set { _(value); } }

		/// <summary> The action to execute when the trigger field is activated.  Use 'all' to run the query specified by the allQuery config option (defaults to 'query')</summary>
		public string triggerAction { get { return _<string>(); } set { _(value); } }

		/// <summary> The minimum number of characters the user must type before autocomplete and typeahead activate (defaults to 4 if remote or 0 if local, does not apply if editable = false)</summary>
		public double minChars { get { return _<double>(); } set { _(value); } }

		/// <summary> True to populate and autoselect the remainder of the text being typed after a configurable delay ({@link #typeAheadDelay}) if it matches a known value (defaults to false)</summary>
		public bool typeAhead { get { return _<bool>(); } set { _(value); } }

		/// <summary> The length of time in milliseconds to delay between the start of typing and sending the query to filter the dropdown list (defaults to 500 if mode = 'remote' or 10 if mode = 'local')</summary>
		public double queryDelay { get { return _<double>(); } set { _(value); } }

		/// <summary> If greater than 0, a paging toolbar is displayed in the footer of the dropdown list and the filter queries will execute with page start and limit parameters.  Only applies when mode = 'remote' (defaults to 0)</summary>
		public double pageSize { get { return _<double>(); } set { _(value); } }

		/// <summary> True to select any existing text in the field immediately on focus.  Only applies when editable = true (defaults to false)</summary>
		public bool selectOnFocus { get { return _<bool>(); } set { _(value); } }

		/// <summary> Name of the query as it will be passed on the querystring (defaults to 'query')</summary>
		public string queryParam { get { return _<string>(); } set { _(value); } }

		/// <summary> The text to display in the dropdown list while data is loading.  Only applies when mode = 'remote' (defaults to 'Loading...')</summary>
		public string loadingText { get { return _<string>(); } set { _(value); } }

		/// <summary> True to add a resize handle to the bottom of the dropdown list (defaults to false)</summary>
		public bool resizable { get { return _<bool>(); } set { _(value); } }

		/// <summary> The height in pixels of the dropdown list resize handle if resizable = true (defaults to 8)</summary>
		public double handleHeight { get { return _<double>(); } set { _(value); } }

		/// <summary> False to prevent the user from typing text directly into the field, just like a traditional select (defaults to true)</summary>
		public bool editable { get { return _<bool>(); } set { _(value); } }

		/// <summary> The text query to send to the server to return all records for the list with no filtering (defaults to '')</summary>
		public string allQuery { get { return _<string>(); } set { _(value); } }

		/// <summary> Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server)</summary>
		public string mode { get { return _<string>(); } set { _(value); } }

		/// <summary> The minimum width of the dropdown list in pixels (defaults to 70, will be ignored if listWidth has a higher value)</summary>
		public double minListWidth { get { return _<double>(); } set { _(value); } }

		/// <summary> True to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to false)</summary>
		public bool forceSelection { get { return _<bool>(); } set { _(value); } }

		/// <summary> The length of time in milliseconds to wait until the typeahead text is displayed if typeAhead = true (defaults to 250)</summary>
		public double typeAheadDelay { get { return _<double>(); } set { _(value); } }

		/// <summary> When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined). If this defaut text is used, it means there is no value set and no validation will occur on this field.</summary>
		public string valueNotFoundText { get { return _<string>(); } set { _(value); } }

		/// <summary> True to not initialize the list for this combo until the field is focused (defaults to true)</summary>
		public bool lazyInit { get { return _<bool>(); } set { _(value); } }

		/// <summary>{String/Ext.XTemplate} The template string, or {@link Ext.XTemplate} instance to use to display each item in the dropdown list. Use this to create custom UI layouts for items in the list. <p> If you wish to preserve the default visual look of list items, add the CSS class name <pre>x-combo-list-item</pre> to the template's container element. <p> <b>The template must contain one or more substitution parameters using field names from the Combo's</b> {@link #store Store}. An example of a custom template would be adding an <pre>ext:qtip</pre> attribute which might display other fields from the Store. <p> The dropdown list is displayed in a DataView. See {@link Ext.DataView} for details.</summary>
		public object tpl { get { return _<object>(); } set { _(value); } }

		/// <summary>  <b>This setting is required if a custom XTemplate has been specified in {@link #tpl} which assigns a class other than <pre>'x-combo-list-item'</pre> to dropdown list items</b>. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes the DataView which handles the dropdown display will be working with.</summary>
		public string itemSelector { get { return _<string>(); } set { _(value); } }

		/// <summary> True to hide the trigger element and display only the base text field (defaults to false)</summary>
		public bool hideTrigger { get { return _<bool>(); } set { _(value); } }

		/// <summary> A custom error message to display in place of the default message provided for the {@link #vtype} currently set for this field (defaults to '').  Only applies if vtype is set, else ignored.</summary>
		public string vtypeText { get { return _<string>(); } set { _(value); } }

		/// <summary> True if this field should automatically grow and shrink to its content</summary>
		public bool grow { get { return _<bool>(); } set { _(value); } }

		/// <summary> The minimum width to allow when grow = true (defaults to 30)</summary>
		public double growMin { get { return _<double>(); } set { _(value); } }

		/// <summary> The maximum width to allow when grow = true (defaults to 800)</summary>
		public double growMax { get { return _<double>(); } set { _(value); } }

		/// <summary> A validation type name as defined in {@link Ext.form.VTypes} (defaults to null)</summary>
		public string vtype { get { return _<string>(); } set { _(value); } }

		/// <summary> An input mask regular expression that will be used to filter keystrokes that don't match (defaults to null)</summary>
		public object maskRe { get { return _<object>(); } set { _(value); } }

		/// <summary> True to disable input keystroke filtering (defaults to false)</summary>
		public bool disableKeyFilter { get { return _<bool>(); } set { _(value); } }

		/// <summary> False to validate that the value length > 0 (defaults to true)</summary>
		public bool allowBlank { get { return _<bool>(); } set { _(value); } }

		/// <summary> Minimum input field length required (defaults to 0)</summary>
		public double minLength { get { return _<double>(); } set { _(value); } }

		/// <summary> Maximum input field length allowed (defaults to Number.MAX_VALUE)</summary>
		public double maxLength { get { return _<double>(); } set { _(value); } }

		/// <summary> Error text to display if the minimum length validation fails (defaults to "The minimum length for this field is {minLength}")</summary>
		public string minLengthText { get { return _<string>(); } set { _(value); } }

		/// <summary> Error text to display if the maximum length validation fails (defaults to "The maximum length for this field is {maxLength}")</summary>
		public string maxLengthText { get { return _<string>(); } set { _(value); } }

		/// <summary> Error text to display if the allow blank validation fails (defaults to "This field is required")</summary>
		public string blankText { get { return _<string>(); } set { _(value); } }

		/// <summary> A custom validation function to be called during field validation (defaults to null). If available, this function will be called only after the basic validators all return true, and will be passed the current field value and expected to return boolean true if the value is valid or a string error message if invalid.</summary>
		public Delegate validator { get { return _<Delegate>(); } set { _(value); } }

		/// <summary> A JavaScript RegExp object to be tested against the field value during validation (defaults to null). If available, this regex will be evaluated only after the basic validators all return true, and will be passed the current field value.  If the test fails, the field will be marked invalid using {@link #regexText}.</summary>
		public object regex { get { return _<object>(); } set { _(value); } }

		/// <summary> The error text to display if {@link #regex} is used and the test fails during validation (defaults to "")</summary>
		public string regexText { get { return _<string>(); } set { _(value); } }

		/// <summary> The default text to display in an empty field (defaults to null).</summary>
		public string emptyText { get { return _<string>(); } set { _(value); } }

		/// <summary> The CSS class to apply to an empty field to style the {@link #emptyText} (defaults to 'x-form-empty-field').  This class is automatically added and removed as needed depending on the current field value.</summary>
		public string emptyClass { get { return _<string>(); } set { _(value); } }

		/// <summary> True to enable the proxying of key events for the HTML input field (defaults to false)</summary>
		public bool enableKeyEvents { get { return _<bool>(); } set { _(value); } }

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

		/// <summary> The CSS class to use when the field receives focus (defaults to "x-form-focus")</summary>
		public string focusClass { get { return _<string>(); } set { _(value); } }

		/// <summary>{String/Boolean} The event that should initiate field validation. Set to false to disable automatic validation (defaults to "keyup").</summary>
		public object validationEvent { get { return _<object>(); } set { _(value); } }

		/// <summary> Whether the field should validate when it loses focus (defaults to true).</summary>
		public bool validateOnBlur { get { return _<bool>(); } set { _(value); } }

		/// <summary> The length of time in milliseconds after user input begins until validation is initiated (defaults to 250)</summary>
		public double validationDelay { get { return _<double>(); } set { _(value); } }

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
