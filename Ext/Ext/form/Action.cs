using System;
using H8.Support;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\form\Action.js</jssource>
    [Native]
    public class ActionClass  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public ActionClass() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static ActionClass prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>
        ///     Failure type returned when client side validation of the Form fails
        ///     thus aborting a submit action.
        /// </summary>
        public static System.String CLIENT_INVALID { get { return null; } set { } }

        /// <summary>
        ///     Failure type returned when server side validation of the Form fails
        ///     indicating that field-specific error messages have been returned in the
        ///     response's <tt style="font-weight:bold">errors</tt> property.
        /// </summary>
        public static System.String SERVER_INVALID { get { return null; } set { } }

        /// <summary>
        ///     Failure type returned when a communication error happens when attempting
        ///     to send a request to the remote server.
        /// </summary>
        public static System.String CONNECT_FAILURE { get { return null; } set { } }

        /// <summary>
        ///     Failure type returned when no field values are returned in the response's
        ///     <tt style="font-weight:bold">data</tt> property.
        /// </summary>
        public static System.String LOAD_FAILURE { get { return null; } set { } }

        /// <summary>The URL that the Action is to invoke.</summary>
        public System.String url { get { return null; } set { } }

        /// <summary>
        ///     When set to <tt><b>true</b></tt>, causes the Form to be{@link Ext.form.BasicForm.reset reset} on Action success. If specified, this happens
        ///     <b>before</b> the {@link #success} callback is called and before the Form's
        ///     {@link Ext.form.BasicForm.actioncomplete actioncomplete} event fires.
        /// </summary>
        public bool reset { get { return false; } set { } }

        /// <summary>The HTTP method to use to access the requested URL. Defaults to the{@link Ext.form.BasicForm}'s method, or if that is not specified, the underlying DOM form's method.</summary>
        public System.String method { get { return null; } set { } }

        /// <summary>
        ///     Extra parameter values to pass. These are added to the Form's{@link Ext.form.BasicForm#baseParams} and passed to the specified URL along with the Form's
        ///     input fields.
        /// </summary>
        public object params_ { get { return null; } set { } }

        /// <summary>The number of milliseconds to wait for a server response beforefailing with the {@link #failureType} as {@link #CONNECT_FAILURE}.</summary>
        public double timeout { get { return 0; } set { } }

        /// <summary>
        ///     The function to call when a valid success return packet is recieved.The function is passed the following parameters:<ul class="mdetail-params">
        ///     <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li>
        ///     <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. The {@link #result}
        ///     property of this object may be examined to perform custom postprocessing.</div></li>
        ///     </ul>
        /// </summary>
        public Delegate success { get { return null; } set { } }

        /// <summary>
        ///     The function to call when a failure packet was recieved, or when anerror ocurred in the Ajax communication.
        ///     The function is passed the following parameters:<ul class="mdetail-params">
        ///     <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li>
        ///     <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. If an Ajax
        ///     error ocurred, the failure type will be in {@link #failureType}. The {@link #result}
        ///     property of this object may be examined to perform custom postprocessing.</div></li>
        ///     </ul>
        /// </summary>
        public Delegate failure { get { return null; } set { } }

        /// <summary>The scope in which to call the callback functions (The <tt>this</tt> referencefor the callback functions).</summary>
        public object scope { get { return null; } set { } }

        /// <summary>The message to be displayed by a call to {@link Ext.MessageBox#wait}during the time the action is being processed.</summary>
        public System.String waitMsg { get { return null; } set { } }

        /// <summary>The title to be displayed by a call to {@link Ext.MessageBox#wait}during the time the action is being processed.</summary>
        public System.String waitTitle { get { return null; } set { } }

        /// <summary>
        ///     The type of action this Action instance performs.
        ///     Currently only "submit" and "load" are supported.
        /// </summary>
        public System.String type { get { return null; } set { } }

        /// <summary>
        ///     The type of failure detected. See {@link #Ext.form.Action.CLIENT_INVALID CLIENT_INVALID}, {@link #Ext.form.Action.SERVER_INVALID SERVER_INVALID},
        ///     {@link #Ext.form.Action.CONNECT_FAILURE CONNECT_FAILURE}, {@link #Ext.form.Action.LOAD_FAILURE LOAD_FAILURE}
        ///     //**
        ///     The XMLHttpRequest object used to perform the action.
        ///     //**
        ///     The decoded response object containing a boolean <tt style="font-weight:bold">success</tt> property and
        ///     other, action-specific properties.
        /// </summary>
        public object result { get { return null; } set { } }




    }
    [Anonymous]
    public class ActionConfig {

        /// <summary> The URL that the Action is to invoke.</summary>
        public System.String url { get { return null; } set { } }

        /// <summary> When set to <tt><b>true</b></tt>, causes the Form to be {@link Ext.form.BasicForm.reset reset} on Action success. If specified, this happens <b>before</b> the {@link #success} callback is called and before the Form's {@link Ext.form.BasicForm.actioncomplete actioncomplete} event fires.</summary>
        public bool reset { get { return false; } set { } }

        /// <summary> The HTTP method to use to access the requested URL. Defaults to the {@link Ext.form.BasicForm}'s method, or if that is not specified, the underlying DOM form's method.</summary>
        public System.String method { get { return null; } set { } }

        /// <summary> Extra parameter values to pass. These are added to the Form's {@link Ext.form.BasicForm#baseParams} and passed to the specified URL along with the Form's input fields.</summary>
        public object params_ { get { return null; } set { } }

        /// <summary> The number of milliseconds to wait for a server response before failing with the {@link #failureType} as {@link #CONNECT_FAILURE}.</summary>
        public double timeout { get { return 0; } set { } }

        /// <summary> The function to call when a valid success return packet is recieved. The function is passed the following parameters:<ul class="mdetail-params"> <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li> <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. The {@link #result} property of this object may be examined to perform custom postprocessing.</div></li> </ul></summary>
        public Delegate success { get { return null; } set { } }

        /// <summary> The function to call when a failure packet was recieved, or when an error ocurred in the Ajax communication. The function is passed the following parameters:<ul class="mdetail-params"> <li><b>form</b> : Ext.form.BasicForm<div class="sub-desc">The form that requested the action</div></li> <li><b>action</b> : Ext.form.Action<div class="sub-desc">The Action class. If an Ajax error ocurred, the failure type will be in {@link #failureType}. The {@link #result} property of this object may be examined to perform custom postprocessing.</div></li> </ul></summary>
        public Delegate failure { get { return null; } set { } }

        /// <summary> The scope in which to call the callback functions (The <tt>this</tt> reference for the callback functions).</summary>
        public object scope { get { return null; } set { } }

        /// <summary> The message to be displayed by a call to {@link Ext.MessageBox#wait} during the time the action is being processed.</summary>
        public System.String waitMsg { get { return null; } set { } }

        /// <summary> The title to be displayed by a call to {@link Ext.MessageBox#wait} during the time the action is being processed.</summary>
        public System.String waitTitle { get { return null; } set { } }

    }


}
