using System;
using H8.Support;

namespace Ext.form {
    /// <summary>
    ///     /**
    ///     Single checkbox field.  Can be used as a direct replacement for traditional checkbox fields.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\form\Checkbox.js</jssource>
    [Native]
    public class Checkbox : Ext.form.Field {

        /// <summary>Creates a new Checkbox</summary>
        /// <returns></returns>
        public Checkbox() {}
        /// <summary>Creates a new Checkbox</summary>
        /// <param name="config">Configuration options</param>
        /// <returns></returns>
        public Checkbox(object config) {}
        /// <summary></summary>
        /// <param name="config">The configuration options.</param>
        /// <returns></returns>
        public Checkbox(Ext.Element config) {}
        /// <summary></summary>
        /// <param name="config">The configuration options.</param>
        /// <returns></returns>
        public Checkbox(System.String config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Checkbox prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.form.Field superclass { get { return null; } set { } }

        /// <summary>The CSS class to use when the control is checked (defaults to 'x-form-check-checked').Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String checkedCls { get { return null; } set { } }

        /// <summary>The CSS class to use when the control receives input focus (defaults to 'x-form-check-focus').Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String focusCls { get { return null; } set { } }

        /// <summary>The CSS class to use when the control is hovered over (defaults to 'x-form-check-over').Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String overCls { get { return null; } set { } }

        /// <summary>The CSS class to use when the control is being actively clicked (defaults to 'x-form-check-down').Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String mouseDownCls { get { return null; } set { } }

        /// <summary>The tabIndex for this field. Note this only applies to fields that are rendered,not those which are built via applyTo (defaults to 0, which allows the browser to manage the tab index).</summary>
        public double tabIndex { get { return 0; } set { } }

        /// <summary>True if the checkbox should render already checked (defaults to false)</summary>
        public bool checked_ { get { return false; } set { } }

        /// <summary>A DomHelper element spec, or true for a default element spec (defaults to{tag: "input", type: "checkbox", autocomplete: "off"}).</summary>
        public object autoCreate { get { return null; } set { } }

        /// <summary>The text that appears beside the checkbox (defaults to '')</summary>
        public System.String boxLabel { get { return null; } set { } }

        /// <summary>The value that should go into the generated input element's value attribute(defaults to undefined, with no value attribute)</summary>
        public System.String inputValue { get { return null; } set { } }

        /// <summary>A function called when the {@link #checked} value changes (can be used instead ofhandling the check event)</summary>
        public Delegate handler { get { return null; } set { } }


        /// <summary>Overridden and disabled. The editor element does not support standard valid/invalid marking. @hide</summary>
        /// <returns></returns>
        public virtual void markInvalid() { return ; }

        /// <summary>Overridden and disabled. The editor element does not support standard valid/invalid marking. @hide</summary>
        /// <returns></returns>
        public virtual void clearInvalid() { return ; }

        /// <summary>Returns the checked state of the checkbox.</summary>
        /// <returns>Boolean</returns>
        public virtual bool getValue() { return false; }

        /// <summary>Sets the checked state of the checkbox.</summary>
        /// <returns></returns>
        public virtual void setValue() { return ; }

        /// <summary>Sets the checked state of the checkbox.</summary>
        /// <param name="chckd">True, 'true', '1', or 'on' to check the checkbox, any other value will uncheck it.</param>
        /// <returns></returns>
        public virtual void setValue(bool chckd) { return ; }

        /// <summary>Sets the checked state of the checkbox.</summary>
        /// <param name="chckd">True, 'true', '1', or 'on' to check the checkbox, any other value will uncheck it.</param>
        /// <returns></returns>
        public virtual void setValue(System.String chckd) { return ; }



    }
    [Anonymous]
    public class CheckboxConfig {

        /// <summary> The CSS class to use when the control is checked (defaults to 'x-form-check-checked'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String checkedCls { get { return null; } set { } }

        /// <summary> The CSS class to use when the control receives input focus (defaults to 'x-form-check-focus'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String focusCls { get { return null; } set { } }

        /// <summary> The CSS class to use when the control is hovered over (defaults to 'x-form-check-over'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String overCls { get { return null; } set { } }

        /// <summary> The CSS class to use when the control is being actively clicked (defaults to 'x-form-check-down'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.</summary>
        public System.String mouseDownCls { get { return null; } set { } }

        /// <summary> The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to 0, which allows the browser to manage the tab index).</summary>
        public double tabIndex { get { return 0; } set { } }

        /// <summary> True if the checkbox should render already checked (defaults to false)</summary>
        public bool checked_ { get { return false; } set { } }

        /// <summary>{String/Object} A DomHelper element spec, or true for a default element spec (defaults to {tag: "input", type: "checkbox", autocomplete: "off"}).</summary>
        public object autoCreate { get { return null; } set { } }

        /// <summary> The text that appears beside the checkbox (defaults to '')</summary>
        public System.String boxLabel { get { return null; } set { } }

        /// <summary> The value that should go into the generated input element's value attribute (defaults to undefined, with no value attribute)</summary>
        public System.String inputValue { get { return null; } set { } }

        /// <summary> A function called when the {@link #checked} value changes (can be used instead of handling the check event)</summary>
        public Delegate handler { get { return null; } set { } }

        /// <summary> The label text to display next to this field (defaults to '')</summary>
        public System.String fieldLabel { get { return null; } set { } }

        /// <summary> A CSS style specification to apply directly to this field's label (defaults to the container's labelStyle value if set, or ''). For example, <code>labelStyle: 'font-weight:bold;'</code>.</summary>
        public System.String labelStyle { get { return null; } set { } }

        /// <summary> The standard separator to display after the text of each form label (defaults to the value of {@link Ext.layout.FormLayout#labelSeparator}, which is a colon ':' by default).  To display no separator for this field's label specify empty string ''.</summary>
        public System.String labelSeparator { get { return null; } set { } }

        /// <summary> True to completely hide the label element (defaults to false)</summary>
        public bool hideLabel { get { return false; } set { } }

        /// <summary> The CSS class used to provide field clearing (defaults to 'x-form-clear-left')</summary>
        public System.String clearCls { get { return null; } set { } }

        /// <summary> An additional CSS class to apply to the wrapper's form item element of this field (defaults to the container's itemCls value if set, or '').  Since it is applied to the item wrapper, it allows you to write standard CSS rules that can apply to the field, the label (if specified) or any other element within the markup for the field. NOTE: this will not have any effect on fields that are not part of a form. Example use: <pre><code> // Apply a style to the field's label: &lt;style> .required .x-form-item-label {font-weight:bold;color:red;} &lt;/style> new Ext.FormPanel({ height: 100, renderTo: document.body, items: [{ xtype: 'textfield', fieldLabel: 'Name', itemCls: 'required' //this label will be styled },{ xtype: 'textfield', fieldLabel: 'Favorite Color' }] }); </code></pre></summary>
        public System.String itemCls { get { return null; } set { } }

        /// <summary> The type attribute for input fields -- e.g. radio, text, password, file (defaults to "text"). The types "file" and "password" must be used to render those field types currently -- there are no separate Ext components for those. Note that if you use <tt>inputType:'file'</tt>, {@link #emptyText} is not supported and should be avoided.</summary>
        public System.String inputType { get { return null; } set { } }

        /// <summary> A value to initialize this field with (defaults to undefined).</summary>
        public object value { get { return null; } set { } }

        /// <summary> The field's HTML name attribute (defaults to "").</summary>
        public System.String name { get { return null; } set { } }

        /// <summary> A custom CSS class to apply to the field's underlying element (defaults to "").</summary>
        public System.String cls { get { return null; } set { } }

        /// <summary> The CSS class to use when marking a field invalid (defaults to "x-form-invalid")</summary>
        public System.String invalidClass { get { return null; } set { } }

        /// <summary> The error text to use when marking a field invalid and no message is provided (defaults to "The value in this field is invalid")</summary>
        public System.String invalidText { get { return null; } set { } }

        /// <summary> The CSS class to use when the field receives focus (defaults to "x-form-focus")</summary>
        public System.String focusClass { get { return null; } set { } }

        /// <summary>{String/Boolean} The event that should initiate field validation. Set to false to disable automatic validation (defaults to "keyup").</summary>
        public object validationEvent { get { return null; } set { } }

        /// <summary> Whether the field should validate when it loses focus (defaults to true).</summary>
        public bool validateOnBlur { get { return false; } set { } }

        /// <summary> The length of time in milliseconds after user input begins until validation is initiated (defaults to 250)</summary>
        public double validationDelay { get { return 0; } set { } }

        /// <summary> The default CSS class for the field (defaults to "x-form-field")</summary>
        public System.String fieldClass { get { return null; } set { } }

        /// <summary> The location where error text should display.  Should be one of the following values (defaults to 'qtip'): <pre> Value         Description -----------   ---------------------------------------------------------------------- qtip          Display a quick tip when the user hovers over the field title         Display a default browser title attribute popup under         Add a block div beneath the field containing the error text side          Add an error icon to the right of the field with a popup on hover [element id]  Add the error text directly to the innerHTML of the specified element </pre></summary>
        public System.String msgTarget { get { return null; } set { } }

        /// <summary> <b>Experimental</b> The effect used when displaying a validation message under the field (defaults to 'normal').</summary>
        public System.String msgFx { get { return null; } set { } }

        /// <summary> True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.</summary>
        public bool readOnly { get { return false; } set { } }

        /// <summary> True to disable the field (defaults to false).</summary>
        public bool disabled { get { return false; } set { } }

        /// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
        public double x { get { return 0; } set { } }

        /// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
        public double y { get { return 0; } set { } }

        /// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
        public double pageX { get { return 0; } set { } }

        /// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
        public double pageY { get { return 0; } set { } }

        /// <summary>  The height of this component in pixels (defaults to auto).</summary>
        public double height { get { return 0; } set { } }

        /// <summary>  The width of this component in pixels (defaults to auto).</summary>
        public double width { get { return 0; } set { } }

        /// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
        public bool autoHeight { get { return false; } set { } }

        /// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
        public bool autoWidth { get { return false; } set { } }

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

        /// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
        public System.String style { get { return null; } set { } }

        /// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
        public System.String ctCls { get { return null; } set { } }

        /// <summary>  Render this component hidden (default is false).</summary>
        public bool hidden { get { return false; } set { } }

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

    public class CheckboxEvents {
        /// <summary>Fires when the checkbox is checked or unchecked.
        /// <pre><code>
        /// USAGE: ({Ext.form.Checkbox} objthis, {Boolean} chckd)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description>This checkbox</description></item>
        /// <item><term><b>chckd</b></term><description>The new checked value</description></item>
        /// </list>
        /// </summary>
        public static string check { get { return "check"; } }
    }

    public delegate void CheckboxCheckDelegate(Ext.form.Checkbox objthis, bool chckd);
}
