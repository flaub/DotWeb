using System;
using DotWeb.Client;

namespace Ext.layout {
	/// <summary>
	///     /**
	///     <p>This is a layout specifically designed for creating forms.
	///     This class can be extended or created via the layout:'form' {@link Ext.Container#layout} config,
	///     and should generally not need to be created directly via the new keyword.  However, when used in an application,
	///     it will usually be preferrable to use a {@link Ext.form.FormPanel} (which automatically uses FormLayout as its layout
	///     class) since it also provides built-in functionality for loading, validating and submitting the form.</p>
	///     <p>Note that when creating a layout via config, the layout-specific config properties must be passed in via
	///     the {@link Ext.Container#layoutConfig} object which will then be applied internally to the layout.  The container
	///     using the FormLayout can also supply the following form-specific config properties which will be applied by the layout:
	///     <ul>
	///     <li><b>hideLabels</b>: (Boolean) True to hide field labels by default (defaults to false)</li>
	///     <li><b>itemCls</b>: (String) A CSS class to add to the div wrapper that contains each field label
	///     and field element (the default class is 'x-form-item' and itemCls will be added to that)</li>
	///     <li><b>labelAlign</b>: (String) The default label alignment.  The default value is empty string ''
	///     for left alignment, but specifying 'top' will align the labels above the fields.</li>
	///     <li><b>labelPad</b>: (Number) The default padding in pixels for field labels (defaults to 5).  labelPad only
	///     applies if labelWidth is also specified, otherwise it will be ignored.</li>
	///     <li><b>labelWidth</b>: (Number) The default width in pixels of field labels (defaults to 100)</li>
	///     </ul></p>
	///     <p>Any type of components can be added to a FormLayout, but items that inherit from {@link Ext.form.Field}
	///     can also supply the following field-specific config properties:
	///     <ul>
	///     <li><b>clearCls</b>: (String) The CSS class to apply to the special clearing div rendered directly after each
	///     form field wrapper (defaults to 'x-form-clear-left')</li>
	///     <li><b>fieldLabel</b>: (String) The text to display as the label for this field (defaults to '')</li>
	///     <li><b>hideLabel</b>: (Boolean) True to hide the label and separator for this field (defaults to false).</li>
	///     <li><b>itemCls</b>: (String) A CSS class to add to the div wrapper that contains this field label
	///     and field element (the default class is 'x-form-item' and itemCls will be added to that).  If supplied,
	///     itemCls at the field level will override the default itemCls supplied at the container level.</li>
	///     <li><b>labelSeparator</b>: (String) The separator to display after the text of the label for this field
	///     (defaults to a colon ':' or the layout's value for {@link #labelSeparator}).  To hide the separator use empty string ''.</li>
	///     <li><b>labelStyle</b>: (String) A CSS style specification string to add to the field label for this field
	///     (defaults to '' or the layout's value for {@link #labelStyle}).</li>
	///     </ul>
	///     Example usage:</p>
	///     <pre><code>
	///     // Required if showing validation messages
	///     Ext.QuickTips.init();
	///     // While you can create a basic Panel with layout:'form', practically
	///     // you should usually use a FormPanel to also get its form functionality
	///     // since it already creates a FormLayout internally.
	///     var form = new Ext.form.FormPanel({
	///     labelWidth: 75,
	///     title: 'Form Layout',
	///     bodyStyle:'padding:15px',
	///     width: 350,
	///     labelPad: 10,
	///     defaultType: 'textfield',
	///     defaults: {
	///     // applied to each contained item
	///     width: 230,
	///     msgTarget: 'side'
	///     },
	///     layoutConfig: {
	///     // layout-specific configs go here
	///     labelSeparator: ''
	///     },
	///     items: [{
	///     fieldLabel: 'First Name',
	///     name: 'first',
	///     allowBlank: false
	///     },{
	///     fieldLabel: 'Last Name',
	///     name: 'last'
	///     },{
	///     fieldLabel: 'Company',
	///     name: 'company'
	///     },{
	///     fieldLabel: 'Email',
	///     name: 'email',
	///     vtype:'email'
	///     }
	///     ],
	///     buttons: [{
	///     text: 'Save'
	///     },{
	///     text: 'Cancel'
	///     }]
	///     });
	///     </code></pre>
	///     */
	///     Ext.layout.FormLayout = Ext.extend(Ext.layout.AnchorLayout, {
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\layout\FormLayout.js</jssource>
	public class FormLayout : Ext.layout.AnchorLayout {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public FormLayout() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static FormLayout prototype { get { return S_<FormLayout>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.layout.AnchorLayout superclass { get { return S_<Ext.layout.AnchorLayout>(); } set { S_(value); } }

		/// <summary>A CSS style specification string to add to each field label in this layout (defaults to '').</summary>
		public System.String labelStyle { get { return _<System.String>(); } set { _(value); } }

		/// <summary>A CSS style specification string to add to each field element in this layout (defaults to '').</summary>
		public System.String elementStyle { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     The standard separator to display after the text of each form label (defaults to a colon ':').  To turn off
		///     separators for all fields in this layout by default specify empty string '' (if the labelSeparator value is
		///     explicitly set at the field level, those will still be displayed).
		/// </summary>
		public System.String labelSeparator { get { return _<System.String>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class FormLayoutConfig : DotWeb.Client.JsAccessible {
		/// <summary>  A CSS style specification string to add to each field label in this layout (defaults to '').</summary>
		public System.String labelStyle { get; set; }

		/// <summary>  A CSS style specification string to add to each field element in this layout (defaults to '').</summary>
		public System.String elementStyle { get; set; }

		/// <summary>  The standard separator to display after the text of each form label (defaults to a colon ':').  To turn off separators for all fields in this layout by default specify empty string '' (if the labelSeparator value is explicitly set at the field level, those will still be displayed).</summary>
		public System.String labelSeparator { get; set; }

		/// <summary>  An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public System.String extraCls { get; set; }

		/// <summary>  True to hide each contained item on render (defaults to false).</summary>
		public bool renderHidden { get; set; }

	}
}
