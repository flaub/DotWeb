using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.form {
	/// <summary>
	///     /**
	///     <p>The subclasses of this class provide actions to perform upon {@link Ext.form.BasicForm Form}s.</p>
	///     <p>Instances of this class are only created by a {@link Ext.form.BasicForm Form} when
	///     the Form needs to perform an action such as submit or load. The Configuration options
	///     listed for this class are set through the Form's action methods: {@link Ext.form.BasicForm#submit submit},
	///     {@link Ext.form.BasicForm#load load} and {@link Ext.form.BasicForm#doAction doAction}</p>
	///     <p>The instance of Action which performed the action is passed to the success
	///     and failure callbacks of the Form's action methods ({@link Ext.form.BasicForm#submit submit},
	///     {@link Ext.form.BasicForm#load load} and {@link Ext.form.BasicForm#doAction doAction}),
	///     and to the {@link Ext.form.BasicForm#actioncomplete actioncomplete} and
	///     {@link Ext.form.BasicForm#actionfailed actionfailed} event handlers.</p>
	///     */
	///     Ext.form.Action = function(form, options){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\form\Action.js</jssource>
	public class ActionClass : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern ActionClass();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ActionClass prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>
		///     Failure type returned when client side validation of the Form fails
		///     thus aborting a submit action.
		/// </summary>
		public extern static string CLIENT_INVALID { get; set; }

		/// <summary>
		///     Failure type returned when server side validation of the Form fails
		///     indicating that field-specific error messages have been returned in the
		///     response's <tt style="font-weight:bold">errors</tt> property.
		/// </summary>
		public extern static string SERVER_INVALID { get; set; }

		/// <summary>
		///     Failure type returned when a communication error happens when attempting
		///     to send a request to the remote server.
		/// </summary>
		public extern static string CONNECT_FAILURE { get; set; }

		/// <summary>
		///     Failure type returned when no field values are returned in the response's
		///     <tt style="font-weight:bold">data</tt> property.
		/// </summary>
		public extern static string LOAD_FAILURE { get; set; }

		/// <summary>The URL that the Action is to invoke.</summary>
		public extern string url { get; set; }

		/// <summary>
		///     When set to <tt><b>true</b></tt>, causes the Form to be{@link Ext.form.BasicForm.reset reset} on Action success. If specified, this happens
		///     <b>before</b> the {@link #success} callback is called and before the Form's
		///     {@link Ext.form.BasicForm.actioncomplete actioncomplete} event fires.
		/// </summary>
		public extern bool reset { get; set; }

		/// <summary>The HTTP method to use to access the requested URL. Defaults to the{@link Ext.form.BasicForm}'s method, or if that is not specified, the underlying DOM form's method.</summary>
		public extern string method { get; set; }

		/// <summary>
		///     Extra parameter values to pass. These are added to the Form's{@link Ext.form.BasicForm#baseParams} and passed to the specified URL along with the Form's
		///     input fields.
		/// </summary>
		public extern object params_ { get; set; }

		/// <summary>The number of milliseconds to wait for a server response beforefailing with the {@link #failureType} as {@link #CONNECT_FAILURE}.</summary>
		public extern double timeout { get; set; }

		/// <summary>
		///     The function to call when a valid success return packet is recieved.The function is passed the following parameters:<ul class="mdetail-params">
		///     <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li>
		///     <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. The {@link #result}
		///     property of this object may be examined to perform custom postprocessing.</div></li>
		///     </ul>
		/// </summary>
		public extern Delegate success { get; set; }

		/// <summary>
		///     The function to call when a failure packet was recieved, or when anerror ocurred in the Ajax communication.
		///     The function is passed the following parameters:<ul class="mdetail-params">
		///     <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li>
		///     <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. If an Ajax
		///     error ocurred, the failure type will be in {@link #failureType}. The {@link #result}
		///     property of this object may be examined to perform custom postprocessing.</div></li>
		///     </ul>
		/// </summary>
		public extern Delegate failure { get; set; }

		/// <summary>The scope in which to call the callback functions (The <tt>this</tt> referencefor the callback functions).</summary>
		public extern object scope { get; set; }

		/// <summary>The message to be displayed by a call to {@link Ext.MessageBox#wait}during the time the action is being processed.</summary>
		public extern string waitMsg { get; set; }

		/// <summary>The title to be displayed by a call to {@link Ext.MessageBox#wait}during the time the action is being processed.</summary>
		public extern string waitTitle { get; set; }

		/// <summary>
		///     The type of action this Action instance performs.
		///     Currently only "submit" and "load" are supported.
		/// </summary>
		public extern string type { get; set; }

		/// <summary>
		///     The type of failure detected. See {@link #Ext.form.Action.CLIENT_INVALID CLIENT_INVALID}, {@link #Ext.form.Action.SERVER_INVALID SERVER_INVALID},
		///     {@link #Ext.form.Action.CONNECT_FAILURE CONNECT_FAILURE}, {@link #Ext.form.Action.LOAD_FAILURE LOAD_FAILURE}
		///     //**
		///     The XMLHttpRequest object used to perform the action.
		///     //**
		///     The decoded response object containing a boolean <tt style="font-weight:bold">success</tt> property and
		///     other, action-specific properties.
		/// </summary>
		public extern object result { get; set; }




	}

	[JsAnonymous]
	public class ActionConfig : System.DotWeb.JsDynamic {
		/// <summary> The URL that the Action is to invoke.</summary>
		public string url { get { return (string)this["url"]; } set { this["url"] = value; } }

		/// <summary> When set to <tt><b>true</b></tt>, causes the Form to be {@link Ext.form.BasicForm.reset reset} on Action success. If specified, this happens <b>before</b> the {@link #success} callback is called and before the Form's {@link Ext.form.BasicForm.actioncomplete actioncomplete} event fires.</summary>
		public bool reset { get { return (bool)this["reset"]; } set { this["reset"] = value; } }

		/// <summary> The HTTP method to use to access the requested URL. Defaults to the {@link Ext.form.BasicForm}'s method, or if that is not specified, the underlying DOM form's method.</summary>
		public string method { get { return (string)this["method"]; } set { this["method"] = value; } }

		/// <summary> Extra parameter values to pass. These are added to the Form's {@link Ext.form.BasicForm#baseParams} and passed to the specified URL along with the Form's input fields.</summary>
		public object params_ { get { return (object)this["params_"]; } set { this["params_"] = value; } }

		/// <summary> The number of milliseconds to wait for a server response before failing with the {@link #failureType} as {@link #CONNECT_FAILURE}.</summary>
		public double timeout { get { return (double)this["timeout"]; } set { this["timeout"] = value; } }

		/// <summary> The function to call when a valid success return packet is recieved. The function is passed the following parameters:<ul class="mdetail-params"> <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li> <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. The {@link #result} property of this object may be examined to perform custom postprocessing.</div></li> </ul></summary>
		public Delegate success { get { return (Delegate)this["success"]; } set { this["success"] = value; } }

		/// <summary> The function to call when a failure packet was recieved, or when an error ocurred in the Ajax communication. The function is passed the following parameters:<ul class="mdetail-params"> <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li> <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. If an Ajax error ocurred, the failure type will be in {@link #failureType}. The {@link #result} property of this object may be examined to perform custom postprocessing.</div></li> </ul></summary>
		public Delegate failure { get { return (Delegate)this["failure"]; } set { this["failure"] = value; } }

		/// <summary> The scope in which to call the callback functions (The <tt>this</tt> reference for the callback functions).</summary>
		public object scope { get { return (object)this["scope"]; } set { this["scope"] = value; } }

		/// <summary> The message to be displayed by a call to {@link Ext.MessageBox#wait} during the time the action is being processed.</summary>
		public string waitMsg { get { return (string)this["waitMsg"]; } set { this["waitMsg"] = value; } }

		/// <summary> The title to be displayed by a call to {@link Ext.MessageBox#wait} during the time the action is being processed.</summary>
		public string waitTitle { get { return (string)this["waitTitle"]; } set { this["waitTitle"] = value; } }

	}
}
