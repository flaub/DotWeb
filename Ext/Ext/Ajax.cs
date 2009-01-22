using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     Global Ajax request class.  Provides a simple way to make Ajax requests with maximum flexibility.  Example usage:
    ///     <pre><code>
    ///     // Basic request
    ///     Ext.Ajax.request({
    ///     url: 'foo.php',
    ///     success: someFn,
    ///     failure: otherFn,
    ///     headers: {
    ///     'my-header': 'foo'
    ///     },
    ///     params: { foo: 'bar' }
    ///     });
    ///     // Simple ajax form submission
    ///     Ext.Ajax.request({
    ///     form: 'some-form',
    ///     params: 'foo=bar'
    ///     });
    ///     // Default headers to pass in every request
    ///     Ext.Ajax.defaultHeaders = {
    ///     'Powered-By': 'Ext'
    ///     };
    ///     // Global Ajax events can be handled on every request!
    ///     Ext.Ajax.on('beforerequest', this.showSpinner, this);
    ///     </code></pre>
    ///     */
    ///     Ext.Ajax = new Ext.data.Connection({
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\data\Connection.js</jssource>
    [Native]
    public class Ajax : Ext.data.Connection {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public Ajax() {}
        /// <summary></summary>
        /// <param name="config">a configuration object.</param>
        /// <returns></returns>
        public Ajax(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Ajax prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.data.Connection superclass { get { return null; } set { } }

        /// <summary>True to add a unique cache-buster param to GET requests. (defaults to true)</summary>
        public static bool disableCaching { get { return false; } set { } }

        /// <summary>The default URL to be used for requests to the server. (defaults to undefined)</summary>
        public static System.String url { get { return null; } set { } }

        /// <summary>
        ///     An object containing properties which are used as
        ///     extra parameters to each request made by this object. (defaults to undefined)
        /// </summary>
        public static object extraParams { get { return null; } set { } }

        /// <summary>An object containing request headers which are added to each request made by this object. (defaults to undefined)</summary>
        public static object defaultHeaders { get { return null; } set { } }

        /// <summary>
        ///     The default HTTP method to be used for requests. Note that this is case-sensitive and should be all caps (defaults
        ///     to undefined; if not set but parms are present will use "POST," otherwise "GET.")
        /// </summary>
        public static System.String method { get { return null; } set { } }

        /// <summary>The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
        public static double timeout { get { return 0; } set { } }

        /// <summary>Whether a new request should abort any pending requests. (defaults to false)</summary>
        public static bool autoAbort { get { return false; } set { } }


        /// <summary>Serialize the passed form into a url encoded string</summary>
        /// <returns>String</returns>
        public static System.String serializeForm() { return null; }

        /// <summary>Serialize the passed form into a url encoded string</summary>
        /// <param name="form"></param>
        /// <returns>String</returns>
        public static System.String serializeForm(System.String form) { return null; }

        /// <summary>Serialize the passed form into a url encoded string</summary>
        /// <param name="form"></param>
        /// <returns>String</returns>
        public static System.String serializeForm(DOMElement form) { return null; }


        /// <summary>
        ///     <p>Sends an HTTP request to a remote server.</p>
        ///     <p><b>Important:</b> Ajax server requests are asynchronous, and this call will
        ///     return before the response has been recieved. Process any returned data
        ///     in a callback function.
        ///     <li><b>url</b> : String (Optional)<p style="margin-left:1em">The URL to
        ///     which to send the request. Defaults to configured URL</p></li>
        ///     <li><b>params</b> : Object/String/Function (Optional)<p style="margin-left:1em">
        ///     An object containing properties which are used as parameters to the
        ///     request, a url encoded string or a function to call to get either.</p></li>
        ///     <li><b>method</b> : String (Optional)<p style="margin-left:1em">The HTTP method to use
        ///     for the request. Defaults to the configured method, or if no method was configured,
        ///     "GET" if no parameters are being sent, and "POST" if parameters are being sent.</p></li>
        ///     <li><b>callback</b> : Function (Optional)<p style="margin-left:1em">The
        ///     function to be called upon receipt of the HTTP response. The callback is
        ///     called regardless of success or failure and is passed the following
        ///     parameters:<ul>
        ///     <li><b>options</b> : Object<p style="margin-left:1em">The parameter to the request call.</p></li>
        ///     <li><b>success</b> : Boolean<p style="margin-left:1em">True if the request succeeded.</p></li>
        ///     <li><b>response</b> : Object<p style="margin-left:1em">The XMLHttpRequest object containing the response data. See http://www.w3.org/TR/XMLHttpRequest/ for details about accessing elements of the response.</p></li>
        ///     </ul></p></li>
        ///     <li><b>success</b> : Function (Optional)<p style="margin-left:1em">The function
        ///     to be called upon success of the request. The callback is passed the following
        ///     parameters:<ul>
        ///     <li><b>response</b> : Object<p style="margin-left:1em">The XMLHttpRequest object containing the response data.</p></li>
        ///     <li><b>options</b> : Object<p style="margin-left:1em">The parameter to the request call.</p></li>
        ///     </ul></p></li>
        ///     <li><b>failure</b> : Function (Optional)<p style="margin-left:1em">The function
        ///     to be called upon failure of the request. The callback is passed the
        ///     following parameters:<ul>
        ///     <li><b>response</b> : Object<p style="margin-left:1em">The XMLHttpRequest object containing the response data.</p></li>
        ///     <li><b>options</b> : Object<p style="margin-left:1em">The parameter to the request call.</p></li>
        ///     </ul></p></li>
        ///     <li><b>scope</b> : Object (Optional)<p style="margin-left:1em">The scope in
        ///     which to execute the callbacks: The "this" object for the callback function.
        ///     Defaults to the browser window.</p></li>
        ///     <li><b>form</b> : Object/String (Optional)<p style="margin-left:1em">A form
        ///     object or id to pull parameters from.</p></li>
        ///     <li><b>isUpload</b> : Boolean (Optional)<p style="margin-left:1em">True if
        ///     the form object is a file upload (will usually be automatically detected).</p></li>
        ///     <li><b>headers</b> : Object (Optional)<p style="margin-left:1em">Request
        ///     headers to set for the request.</p></li>
        ///     <li><b>xmlData</b> : Object (Optional)<p style="margin-left:1em">XML document
        ///     to use for the post. Note: This will be used instead of params for the post
        ///     data. Any params will be appended to the URL.</p></li>
        ///     <li><b>jsonData</b> : Object/String (Optional)<p style="margin-left:1em">JSON
        ///     data to use as the post. Note: This will be used instead of params for the post
        ///     data. Any params will be appended to the URL.</p></li>
        ///     <li><b>disableCaching</b> : Boolean (Optional)<p style="margin-left:1em">True
        ///     to add a unique cache-buster param to GET requests.</p></li>
        ///     </ul></p>
        ///     <p>The options object may also contain any other property which might be needed to perform
        ///     postprocessing in a callback because it is passed to callback functions.</p>
        ///     to cancel the request.
        /// </summary>
        /// <param name="options">An object which may contain the following properties:<ul></param>
        /// <returns>Number</returns>
        public static double request(object options) { return 0; }

        /// <summary>Determine whether this object has a request outstanding.</summary>
        /// <returns>Boolean</returns>
        public static bool isLoading() { return false; }

        /// <summary>Determine whether this object has a request outstanding.</summary>
        /// <param name="transactionId">(Optional) defaults to the last transaction</param>
        /// <returns>Boolean</returns>
        public static bool isLoading(double transactionId) { return false; }

        /// <summary>Aborts any outstanding request.</summary>
        /// <returns></returns>
        public static void abort() { return ; }

        /// <summary>Aborts any outstanding request.</summary>
        /// <param name="transactionId">(Optional) defaults to the last transaction</param>
        /// <returns></returns>
        public static void abort(double transactionId) { return ; }
        /// <summary>Fires the specified event with the passed parameters (minus the event name).</summary>
        /// <returns>Boolean</returns>
        public static bool fireEvent() { return false; }

        /// <summary>Fires the specified event with the passed parameters (minus the event name).</summary>
        /// <param name="eventName"></param>
        /// <returns>Boolean</returns>
        public static bool fireEvent(System.String eventName) { return false; }

        /// <summary>Fires the specified event with the passed parameters (minus the event name).</summary>
        /// <param name="eventName"></param>
        /// <param name="args">Variable number of parameters are passed to handlers</param>
        /// <returns>Boolean</returns>
        public static bool fireEvent(System.String eventName, params object[] args) { return false; }

        /// <summary>
        ///     Appends an event handler to this component
        ///     function. The handler function's "this" context.
        ///     properties. This may contain any of the following properties:<ul>
        ///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
        ///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
        ///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
        ///     <li>buffer {Number} Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     Using the options argument, it is possible to combine different types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
        ///     <pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <returns></returns>
        public static void addListener() { return ; }

        /// <summary>
        ///     Appends an event handler to this component
        ///     function. The handler function's "this" context.
        ///     properties. This may contain any of the following properties:<ul>
        ///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
        ///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
        ///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
        ///     <li>buffer {Number} Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     Using the options argument, it is possible to combine different types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
        ///     <pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <returns></returns>
        public static void addListener(System.String eventName) { return ; }

        /// <summary>
        ///     Appends an event handler to this component
        ///     function. The handler function's "this" context.
        ///     properties. This may contain any of the following properties:<ul>
        ///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
        ///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
        ///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
        ///     <li>buffer {Number} Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     Using the options argument, it is possible to combine different types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
        ///     <pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The method the event invokes</param>
        /// <returns></returns>
        public static void addListener(System.String eventName, Delegate handler) { return ; }

        /// <summary>
        ///     Appends an event handler to this component
        ///     function. The handler function's "this" context.
        ///     properties. This may contain any of the following properties:<ul>
        ///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
        ///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
        ///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
        ///     <li>buffer {Number} Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     Using the options argument, it is possible to combine different types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
        ///     <pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The method the event invokes</param>
        /// <param name="scope">(optional) The scope in which to execute the handler</param>
        /// <returns></returns>
        public static void addListener(System.String eventName, Delegate handler, object scope) { return ; }

        /// <summary>
        ///     Appends an event handler to this component
        ///     function. The handler function's "this" context.
        ///     properties. This may contain any of the following properties:<ul>
        ///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
        ///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
        ///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
        ///     <li>buffer {Number} Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     Using the options argument, it is possible to combine different types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
        ///     <pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     <pre><code>
        ///     foo.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The method the event invokes</param>
        /// <param name="scope">(optional) The scope in which to execute the handler</param>
        /// <param name="options">(optional) An object containing handler configuration</param>
        /// <returns></returns>
        public static void addListener(System.String eventName, Delegate handler, object scope, object options) { return ; }

        /// <summary>Removes a listener</summary>
        /// <returns></returns>
        public static void removeListener() { return ; }

        /// <summary>Removes a listener</summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <returns></returns>
        public static void removeListener(System.String eventName) { return ; }

        /// <summary>Removes a listener</summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The handler to remove</param>
        /// <returns></returns>
        public static void removeListener(System.String eventName, Delegate handler) { return ; }

        /// <summary>Removes a listener</summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The handler to remove</param>
        /// <param name="scope">(optional) The scope (this object) for the handler</param>
        /// <returns></returns>
        public static void removeListener(System.String eventName, Delegate handler, object scope) { return ; }

        /// <summary>Removes all listeners for this object</summary>
        /// <returns></returns>
        public static void purgeListeners() { return ; }

        /// <summary>Used to define events on this Observable</summary>
        /// <returns></returns>
        public static void addEvents() { return ; }

        /// <summary>Used to define events on this Observable</summary>
        /// <param name="obj">The object with the events defined</param>
        /// <returns></returns>
        public static void addEvents(object obj) { return ; }

        /// <summary>Checks to see if this object has any listeners for a specified event</summary>
        /// <returns>Boolean</returns>
        public static bool hasListener() { return false; }

        /// <summary>Checks to see if this object has any listeners for a specified event</summary>
        /// <param name="eventName">The name of the event to check for</param>
        /// <returns>Boolean</returns>
        public static bool hasListener(System.String eventName) { return false; }

        /// <summary>Suspend the firing of all events. (see {@link #resumeEvents})</summary>
        /// <returns></returns>
        public static void suspendEvents() { return ; }

        /// <summary>Resume firing events. (see {@link #suspendEvents})</summary>
        /// <returns></returns>
        public static void resumeEvents() { return ; }

        /// <summary>
        ///     Appends an event handler to this element (shorthand for addListener)
        ///     function. The handler function's "this" context.
        /// </summary>
        /// <returns></returns>
        public static void on() { return ; }

        /// <summary>
        ///     Appends an event handler to this element (shorthand for addListener)
        ///     function. The handler function's "this" context.
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <returns></returns>
        public static void on(System.String eventName) { return ; }

        /// <summary>
        ///     Appends an event handler to this element (shorthand for addListener)
        ///     function. The handler function's "this" context.
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The method the event invokes</param>
        /// <returns></returns>
        public static void on(System.String eventName, Delegate handler) { return ; }

        /// <summary>
        ///     Appends an event handler to this element (shorthand for addListener)
        ///     function. The handler function's "this" context.
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The method the event invokes</param>
        /// <param name="scope">(optional) The scope in which to execute the handler</param>
        /// <returns></returns>
        public static void on(System.String eventName, Delegate handler, object scope) { return ; }

        /// <summary>
        ///     Appends an event handler to this element (shorthand for addListener)
        ///     function. The handler function's "this" context.
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The method the event invokes</param>
        /// <param name="scope">(optional) The scope in which to execute the handler</param>
        /// <param name="options">(optional)</param>
        /// <returns></returns>
        public static void on(System.String eventName, Delegate handler, object scope, object options) { return ; }

        /// <summary>Removes a listener (shorthand for removeListener)</summary>
        /// <returns></returns>
        public static void un() { return ; }

        /// <summary>Removes a listener (shorthand for removeListener)</summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <returns></returns>
        public static void un(System.String eventName) { return ; }

        /// <summary>Removes a listener (shorthand for removeListener)</summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The handler to remove</param>
        /// <returns></returns>
        public static void un(System.String eventName, Delegate handler) { return ; }

        /// <summary>Removes a listener (shorthand for removeListener)</summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="handler">The handler to remove</param>
        /// <param name="scope">(optional) The scope (this object) for the handler</param>
        /// <returns></returns>
        public static void un(System.String eventName, Delegate handler, object scope) { return ; }

    }
    [Anonymous]
    public class AjaxConfig {

        /// <summary> (Optional) The default URL to be used for requests to the server. (defaults to undefined)</summary>
        public System.String url { get { return null; } set { } }

        /// <summary> (Optional) An object containing properties which are used as extra parameters to each request made by this object. (defaults to undefined)</summary>
        public object extraParams { get { return null; } set { } }

        /// <summary> (Optional) An object containing request headers which are added to each request made by this object. (defaults to undefined)</summary>
        public object defaultHeaders { get { return null; } set { } }

        /// <summary> (Optional) The default HTTP method to be used for requests. (defaults to undefined; if not set, but {@link #request} params are present, POST will be used; otherwise, GET will be used.)</summary>
        public System.String method { get { return null; } set { } }

        /// <summary> (Optional) The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
        public double timeout { get { return 0; } set { } }

        /// <summary> (Optional) Whether this request should abort any pending requests. (defaults to false) @type Boolean</summary>
        public bool autoAbort { get { return false; } set { } }

        /// <summary> (Optional) True to add a unique cache-buster param to GET requests. (defaults to true) @type Boolean</summary>
        public bool disableCaching { get { return false; } set { } }

        /// <summary> (Optional) Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc' @type String</summary>
        public System.String disableCachingParam { get { return null; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }


}
