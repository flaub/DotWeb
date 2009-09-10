using System;
using DotWeb.Client;

namespace Ext.form.Action {
	/// <summary>
	///     /**
	///     <p>A class which handles submission of data from {@link Ext.form.BasicForm Form}s
	///     and processes the returned response.</p>
	///     <p>Instances of this class are only created by a {@link Ext.form.BasicForm Form} when
	///     {@link Ext.form.BasicForm#submit submit}ting.</p>
	///     <p>A response packet must contain a boolean <tt style="font-weight:bold">success</tt> property, and, optionally
	///     an <tt style="font-weight:bold">errors</tt> property. The <tt style="font-weight:bold">errors</tt> property contains error
	///     messages for invalid fields.</p>
	///     <p>By default, response packets are assumed to be JSON, so a typical response
	///     packet may look like this:</p><pre><code>
	///     {
	///     success: false,
	///     errors: {
	///     clientCode: "Client not found",
	///     portOfLoading: "This field must not be null"
	///     }
	///     }</code></pre>
	///     <p>Other data may be placed into the response for processing by the {@link Ext.form.BasicForm}'s callback
	///     or event handler methods. The object decoded from this JSON is available in the {@link #result} property.</p>
	///     <p>Alternatively, if an {@link #errorReader} is specified as an {@link Ext.data.XmlReader XmlReader}:</p><pre><code>
	///     errorReader: new Ext.data.XmlReader({
	///     record : 'field',
	///     success: '@success'
	///     }, [
	///     'id', 'msg'
	///     ]
	///     )
	///     </code></pre>
	///     <p>then the results may be sent back in XML format:</p><pre><code>
	///     &lt;?xml version="1.0" encoding="UTF-8"?&gt;
	///     &lt;message success="false"&gt;
	///     &lt;errors&gt;
	///     &lt;field&gt;
	///     &lt;id&gt;clientCode&lt;/id&gt;
	///     &lt;msg&gt;&lt;![CDATA[Code not found. &lt;br /&gt;&lt;i&gt;This is a test validation message from the server &lt;/i&gt;]]&gt;&lt;/msg&gt;
	///     &lt;/field&gt;
	///     &lt;field&gt;
	///     &lt;id&gt;portOfLoading&lt;/id&gt;
	///     &lt;msg&gt;&lt;![CDATA[Port not found. &lt;br /&gt;&lt;i&gt;This is a test validation message from the server &lt;/i&gt;]]&gt;&lt;/msg&gt;
	///     &lt;/field&gt;
	///     &lt;/errors&gt;
	///     &lt;/message&gt;
	///     </code></pre>
	///     <p>Other elements may be placed into the response XML for processing by the {@link Ext.form.BasicForm}'s callback
	///     or event handler methods. The XML document is available in the {@link #errorReader}'s {@link Ext.data.XmlReader#xmlData xmlData} property.</p>
	///     */
	///     Ext.form.Action.Submit = function(form, options){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\form\Action.js</jssource>
	public class Submit : Ext.form.ActionClass {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Submit() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Submit prototype { get { return S_<Submit>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.form.ActionClass superclass { get { return S_<Ext.form.ActionClass>(); } set { S_(value); } }

		/// <summary>
		///     <b>Optional. JSON is interpreted with no need for an errorReader.</b><p>A Reader which reads a single record from the returned data. The DataReader's <b>success</b> property specifies
		///     how submission success is determined. The Record's data provides the error messages to apply to any invalid form Fields.</p>.
		/// </summary>
		public Ext.data.DataReader errorReader { get { return _<Ext.data.DataReader>(); } set { _(value); } }

		/// <summary>
		///     Determines whether a Form's fields are validatedin a final call to {@link Ext.form.BasicForm#isValid isValid} prior to submission.
		///     Pass <tt>false</tt> in the Form's submit options to prevent this. If not defined, pre-submission field validation
		///     is performed.
		/// </summary>
		public bool clientValidation { get { return _<bool>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class SubmitConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> <b>Optional. JSON is interpreted with no need for an errorReader.</b> <p>A Reader which reads a single record from the returned data. The DataReader's <b>success</b> property specifies how submission success is determined. The Record's data provides the error messages to apply to any invalid form Fields.</p>.</summary>
		public Ext.data.DataReader errorReader { get { return _<Ext.data.DataReader>(); } set { _(value); } }

		/// <summary> Determines whether a Form's fields are validated in a final call to {@link Ext.form.BasicForm#isValid isValid} prior to submission. Pass <tt>false</tt> in the Form's submit options to prevent this. If not defined, pre-submission field validation is performed.</summary>
		public bool clientValidation { get { return _<bool>(); } set { _(value); } }

		/// <summary> The URL that the Action is to invoke.</summary>
		public string url { get { return _<string>(); } set { _(value); } }

		/// <summary> When set to <tt><b>true</b></tt>, causes the Form to be {@link Ext.form.BasicForm.reset reset} on Action success. If specified, this happens <b>before</b> the {@link #success} callback is called and before the Form's {@link Ext.form.BasicForm.actioncomplete actioncomplete} event fires.</summary>
		public bool reset { get { return _<bool>(); } set { _(value); } }

		/// <summary> The HTTP method to use to access the requested URL. Defaults to the {@link Ext.form.BasicForm}'s method, or if that is not specified, the underlying DOM form's method.</summary>
		public string method { get { return _<string>(); } set { _(value); } }

		/// <summary> Extra parameter values to pass. These are added to the Form's {@link Ext.form.BasicForm#baseParams} and passed to the specified URL along with the Form's input fields.</summary>
		public object params_ { get { return _<object>(); } set { _(value); } }

		/// <summary> The number of milliseconds to wait for a server response before failing with the {@link #failureType} as {@link #CONNECT_FAILURE}.</summary>
		public double timeout { get { return _<double>(); } set { _(value); } }

		/// <summary> The function to call when a valid success return packet is recieved. The function is passed the following parameters:<ul class="mdetail-params"> <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li> <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. The {@link #result} property of this object may be examined to perform custom postprocessing.</div></li> </ul></summary>
		public Delegate success { get { return _<Delegate>(); } set { _(value); } }

		/// <summary> The function to call when a failure packet was recieved, or when an error ocurred in the Ajax communication. The function is passed the following parameters:<ul class="mdetail-params"> <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li> <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. If an Ajax error ocurred, the failure type will be in {@link #failureType}. The {@link #result} property of this object may be examined to perform custom postprocessing.</div></li> </ul></summary>
		public Delegate failure { get { return _<Delegate>(); } set { _(value); } }

		/// <summary> The scope in which to call the callback functions (The <tt>this</tt> reference for the callback functions).</summary>
		public object scope { get { return _<object>(); } set { _(value); } }

		/// <summary> The message to be displayed by a call to {@link Ext.MessageBox#wait} during the time the action is being processed.</summary>
		public string waitMsg { get { return _<string>(); } set { _(value); } }

		/// <summary> The title to be displayed by a call to {@link Ext.MessageBox#wait} during the time the action is being processed.</summary>
		public string waitTitle { get { return _<string>(); } set { _(value); } }

	}
}
