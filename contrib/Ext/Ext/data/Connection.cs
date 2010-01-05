using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     <p>The class encapsulates a connection to the page's originating domain, allowing requests to be made
	///     either to a configured URL, or to a URL specified at request time.</p>
	///     <p>Requests made by this class are asynchronous, and will return immediately. No data from
	///     the server will be available to the statement immediately following the {@link #request} call.
	///     To process returned data, use a {@link #request-option-success callback} in the request options object,
	///     or an {@link #requestcomplete event listener}.</p>
	///     <p>{@link #request-option-isUpload File uploads} are not performed using normal "Ajax" techniques, that
	///     is they are <b>not</b> performed using XMLHttpRequests. Instead the form is submitted in the standard
	///     manner with the DOM <tt>&lt;form></tt> element temporarily modified to have its
	///     <a href="http://www.w3.org/TR/REC-html40/present/frames.html#adef-target">target</a> set to refer
	///     to a dynamically generated, hidden <tt>&lt;iframe></tt> which is inserted into the document
	///     but removed after the return data has been gathered.</p>
	///     <p>The server response is parsed by the browser to create the document for the IFRAME. If the
	///     server is using JSON to send the return object, then the
	///     <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.17">Content-Type</a> header
	///     must be set to "text/html" in order to tell the browser to insert the text unchanged into the document body.</p>
	///     <p>The response text is retrieved from the document, and a fake XMLHttpRequest object
	///     is created containing a <tt>responseText</tt> property in order to conform to the
	///     requirements of event handlers and callbacks.</p>
	///     <p>Be aware that file upload packets are sent with the content type <a href="http://www.faqs.org/rfcs/rfc2388.html">multipart/form</a>
	///     and some server technologies (notably JEE) may require some custom processing in order to
	///     retrieve parameter names and parameter values from the packet content.</p>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\Connection.js</jssource>
	public class Connection : Ext.util.Observable {

		/// <summary></summary>
		/// <returns></returns>
		public extern Connection();
		/// <summary></summary>
		/// <param name="config">a configuration object.</param>
		/// <returns></returns>
		public extern Connection(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Connection prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>(Optional) The default URL to be used for requests to the server. (defaults to undefined)</summary>
		public extern string url { get; set; }

		/// <summary>(Optional) An object containing properties which are used asextra parameters to each request made by this object. (defaults to undefined)</summary>
		public extern object extraParams { get; set; }

		/// <summary>(Optional) An object containing request headers which are addedto each request made by this object. (defaults to undefined)</summary>
		public extern object defaultHeaders { get; set; }

		/// <summary>
		///     (Optional) The default HTTP method to be used for requests.(defaults to undefined; if not set, but {@link #request} params are present, POST will be used;
		///     otherwise, GET will be used.)
		/// </summary>
		public extern string method { get; set; }

		/// <summary>(Optional) The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
		public extern double timeout { get; set; }

		/// <summary>(Optional) Whether this request should abort any pending requests. (defaults to false)</summary>
		public extern bool autoAbort { get; set; }

		/// <summary>(Optional) True to add a unique cache-buster param to GET requests. (defaults to true)</summary>
		public extern bool disableCaching { get; set; }

		/// <summary>(Optional) Change the parameter which is sent went disabling cachingthrough a cache buster. Defaults to '_dc'</summary>
		public extern string disableCachingParam { get; set; }


		/// <summary>
		///     <p>Sends an HTTP request to a remote server.</p>
		///     <p><b>Important:</b> Ajax server requests are asynchronous, and this call will
		///     return before the response has been received. Process any returned data
		///     in a callback function.</p>
		///     <p>To execute a callback function in the correct scope, use the <tt>scope</tt> option.</p>
		///     <li><b>url</b> : String/Function (Optional)<div class="sub-desc">The URL to
		///     which to send the request, or a function to call which returns a URL string. The scope of the
		///     function is specified by the <tt>scope</tt> option. Defaults to configured URL.</div></li>
		///     <li><b>params</b> : Object/String/Function (Optional)<div class="sub-desc">
		///     An object containing properties which are used as parameters to the
		///     request, a url encoded string or a function to call to get either. The scope of the function
		///     is specified by the <tt>scope</tt> option.</div></li>
		///     <li><b>method</b> : String (Optional)<div class="sub-desc">The HTTP method to use
		///     for the request. Defaults to the configured method, or if no method was configured,
		///     "GET" if no parameters are being sent, and "POST" if parameters are being sent.  Note that
		///     the method name is case-sensitive and should be all caps.</div></li>
		///     <li><b>callback</b> : Function (Optional)<div class="sub-desc">The
		///     function to be called upon receipt of the HTTP response. The callback is
		///     called regardless of success or failure and is passed the following
		///     parameters:<ul>
		///     <li><b>options</b> : Object<div class="sub-desc">The parameter to the request call.</div></li>
		///     <li><b>success</b> : Boolean<div class="sub-desc">True if the request succeeded.</div></li>
		///     <li><b>response</b> : Object<div class="sub-desc">The XMLHttpRequest object containing the response data.
		///     See <a href="http://www.w3.org/TR/XMLHttpRequest/">http://www.w3.org/TR/XMLHttpRequest/</a> for details about
		///     accessing elements of the response.</div></li>
		///     </ul></div></li>
		///     <a id="request-option-success"></a><li><b>success</b> : Function (Optional)<div class="sub-desc">The function
		///     to be called upon success of the request. The callback is passed the following
		///     parameters:<ul>
		///     <li><b>response</b> : Object<div class="sub-desc">The XMLHttpRequest object containing the response data.</div></li>
		///     <li><b>options</b> : Object<div class="sub-desc">The parameter to the request call.</div></li>
		///     </ul></div></li>
		///     <li><b>failure</b> : Function (Optional)<div class="sub-desc">The function
		///     to be called upon failure of the request. The callback is passed the
		///     following parameters:<ul>
		///     <li><b>response</b> : Object<div class="sub-desc">The XMLHttpRequest object containing the response data.</div></li>
		///     <li><b>options</b> : Object<div class="sub-desc">The parameter to the request call.</div></li>
		///     </ul></div></li>
		///     <li><b>scope</b> : Object (Optional)<div class="sub-desc">The scope in
		///     which to execute the callbacks: The "this" object for the callback function. If the <tt>url</tt>, or <tt>params</tt> options were
		///     specified as functions from which to draw values, then this also serves as the scope for those function calls.
		///     Defaults to the browser window.</div></li>
		///     <li><b>form</b> : Element/HTMLElement/String (Optional)<div class="sub-desc">The <tt>&lt;form&gt;</tt>
		///     Element or the id of the <tt>&lt;form&gt;</tt> to pull parameters from.</div></li>
		///     <a id="request-option-isUpload"></a><li><b>isUpload</b> : Boolean (Optional)<div class="sub-desc">True if the form object is a
		///     file upload (will usually be automatically detected).
		///     <p>File uploads are not performed using normal "Ajax" techniques, that is they are <b>not</b>
		///     performed using XMLHttpRequests. Instead the form is submitted in the standard manner with the
		///     DOM <tt>&lt;form></tt> element temporarily modified to have its
		///     <a href="http://www.w3.org/TR/REC-html40/present/frames.html#adef-target">target</a> set to refer
		///     to a dynamically generated, hidden <tt>&lt;iframe></tt> which is inserted into the document
		///     but removed after the return data has been gathered.</p>
		///     <p>The server response is parsed by the browser to create the document for the IFRAME. If the
		///     server is using JSON to send the return object, then the
		///     <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.17">Content-Type</a> header
		///     must be set to "text/html" in order to tell the browser to insert the text unchanged into the document body.</p>
		///     <p>The response text is retrieved from the document, and a fake XMLHttpRequest object
		///     is created containing a <tt>responseText</tt> property in order to conform to the
		///     requirements of event handlers and callbacks.</p>
		///     <p>Be aware that file upload packets are sent with the content type <a href="http://www.faqs.org/rfcs/rfc2388.html">multipart/form</a>
		///     and some server technologies (notably JEE) may require some custom processing in order to
		///     retrieve parameter names and parameter values from the packet content.</p>
		///     </div></li>
		///     <li><b>headers</b> : Object (Optional)<div class="sub-desc">Request
		///     headers to set for the request.</div></li>
		///     <li><b>xmlData</b> : Object (Optional)<div class="sub-desc">XML document
		///     to use for the post. Note: This will be used instead of params for the post
		///     data. Any params will be appended to the URL.</div></li>
		///     <li><b>jsonData</b> : Object/String (Optional)<div class="sub-desc">JSON
		///     data to use as the post. Note: This will be used instead of params for the post
		///     data. Any params will be appended to the URL.</div></li>
		///     <li><b>disableCaching</b> : Boolean (Optional)<div class="sub-desc">True
		///     to add a unique cache-buster param to GET requests.</div></li>
		///     </ul></p>
		///     <p>The options object may also contain any other property which might be needed to perform
		///     postprocessing in a callback because it is passed to callback functions.</p>
		///     to cancel the request.
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void request();

		/// <summary>
		///     <p>Sends an HTTP request to a remote server.</p>
		///     <p><b>Important:</b> Ajax server requests are asynchronous, and this call will
		///     return before the response has been received. Process any returned data
		///     in a callback function.</p>
		///     <p>To execute a callback function in the correct scope, use the <tt>scope</tt> option.</p>
		///     <li><b>url</b> : String/Function (Optional)<div class="sub-desc">The URL to
		///     which to send the request, or a function to call which returns a URL string. The scope of the
		///     function is specified by the <tt>scope</tt> option. Defaults to configured URL.</div></li>
		///     <li><b>params</b> : Object/String/Function (Optional)<div class="sub-desc">
		///     An object containing properties which are used as parameters to the
		///     request, a url encoded string or a function to call to get either. The scope of the function
		///     is specified by the <tt>scope</tt> option.</div></li>
		///     <li><b>method</b> : String (Optional)<div class="sub-desc">The HTTP method to use
		///     for the request. Defaults to the configured method, or if no method was configured,
		///     "GET" if no parameters are being sent, and "POST" if parameters are being sent.  Note that
		///     the method name is case-sensitive and should be all caps.</div></li>
		///     <li><b>callback</b> : Function (Optional)<div class="sub-desc">The
		///     function to be called upon receipt of the HTTP response. The callback is
		///     called regardless of success or failure and is passed the following
		///     parameters:<ul>
		///     <li><b>options</b> : Object<div class="sub-desc">The parameter to the request call.</div></li>
		///     <li><b>success</b> : Boolean<div class="sub-desc">True if the request succeeded.</div></li>
		///     <li><b>response</b> : Object<div class="sub-desc">The XMLHttpRequest object containing the response data.
		///     See <a href="http://www.w3.org/TR/XMLHttpRequest/">http://www.w3.org/TR/XMLHttpRequest/</a> for details about
		///     accessing elements of the response.</div></li>
		///     </ul></div></li>
		///     <a id="request-option-success"></a><li><b>success</b> : Function (Optional)<div class="sub-desc">The function
		///     to be called upon success of the request. The callback is passed the following
		///     parameters:<ul>
		///     <li><b>response</b> : Object<div class="sub-desc">The XMLHttpRequest object containing the response data.</div></li>
		///     <li><b>options</b> : Object<div class="sub-desc">The parameter to the request call.</div></li>
		///     </ul></div></li>
		///     <li><b>failure</b> : Function (Optional)<div class="sub-desc">The function
		///     to be called upon failure of the request. The callback is passed the
		///     following parameters:<ul>
		///     <li><b>response</b> : Object<div class="sub-desc">The XMLHttpRequest object containing the response data.</div></li>
		///     <li><b>options</b> : Object<div class="sub-desc">The parameter to the request call.</div></li>
		///     </ul></div></li>
		///     <li><b>scope</b> : Object (Optional)<div class="sub-desc">The scope in
		///     which to execute the callbacks: The "this" object for the callback function. If the <tt>url</tt>, or <tt>params</tt> options were
		///     specified as functions from which to draw values, then this also serves as the scope for those function calls.
		///     Defaults to the browser window.</div></li>
		///     <li><b>form</b> : Element/HTMLElement/String (Optional)<div class="sub-desc">The <tt>&lt;form&gt;</tt>
		///     Element or the id of the <tt>&lt;form&gt;</tt> to pull parameters from.</div></li>
		///     <a id="request-option-isUpload"></a><li><b>isUpload</b> : Boolean (Optional)<div class="sub-desc">True if the form object is a
		///     file upload (will usually be automatically detected).
		///     <p>File uploads are not performed using normal "Ajax" techniques, that is they are <b>not</b>
		///     performed using XMLHttpRequests. Instead the form is submitted in the standard manner with the
		///     DOM <tt>&lt;form></tt> element temporarily modified to have its
		///     <a href="http://www.w3.org/TR/REC-html40/present/frames.html#adef-target">target</a> set to refer
		///     to a dynamically generated, hidden <tt>&lt;iframe></tt> which is inserted into the document
		///     but removed after the return data has been gathered.</p>
		///     <p>The server response is parsed by the browser to create the document for the IFRAME. If the
		///     server is using JSON to send the return object, then the
		///     <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.17">Content-Type</a> header
		///     must be set to "text/html" in order to tell the browser to insert the text unchanged into the document body.</p>
		///     <p>The response text is retrieved from the document, and a fake XMLHttpRequest object
		///     is created containing a <tt>responseText</tt> property in order to conform to the
		///     requirements of event handlers and callbacks.</p>
		///     <p>Be aware that file upload packets are sent with the content type <a href="http://www.faqs.org/rfcs/rfc2388.html">multipart/form</a>
		///     and some server technologies (notably JEE) may require some custom processing in order to
		///     retrieve parameter names and parameter values from the packet content.</p>
		///     </div></li>
		///     <li><b>headers</b> : Object (Optional)<div class="sub-desc">Request
		///     headers to set for the request.</div></li>
		///     <li><b>xmlData</b> : Object (Optional)<div class="sub-desc">XML document
		///     to use for the post. Note: This will be used instead of params for the post
		///     data. Any params will be appended to the URL.</div></li>
		///     <li><b>jsonData</b> : Object/String (Optional)<div class="sub-desc">JSON
		///     data to use as the post. Note: This will be used instead of params for the post
		///     data. Any params will be appended to the URL.</div></li>
		///     <li><b>disableCaching</b> : Boolean (Optional)<div class="sub-desc">True
		///     to add a unique cache-buster param to GET requests.</div></li>
		///     </ul></p>
		///     <p>The options object may also contain any other property which might be needed to perform
		///     postprocessing in a callback because it is passed to callback functions.</p>
		///     to cancel the request.
		/// </summary>
		/// <param name="options">An object which may contain the following properties:<ul></param>
		/// <returns>Number</returns>
		public extern virtual void request(object options);

		/// <summary>Determine whether this object has a request outstanding.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isLoading();

		/// <summary>Determine whether this object has a request outstanding.</summary>
		/// <param name="transactionId">(Optional) defaults to the last transaction</param>
		/// <returns>Boolean</returns>
		public extern virtual void isLoading(double transactionId);

		/// <summary>Aborts any outstanding request.</summary>
		/// <returns></returns>
		public extern virtual void abort();

		/// <summary>Aborts any outstanding request.</summary>
		/// <param name="transactionId">(Optional) defaults to the last transaction</param>
		/// <returns></returns>
		public extern virtual void abort(double transactionId);



	}

	[JsAnonymous]
	public class ConnectionConfig : System.DotWeb.JsDynamic {
		/// <summary> (Optional) The default URL to be used for requests to the server. (defaults to undefined)</summary>
		public string url { get { return (string)this["url"]; } set { this["url"] = value; } }

		/// <summary> (Optional) An object containing properties which are used as extra parameters to each request made by this object. (defaults to undefined)</summary>
		public object extraParams { get { return (object)this["extraParams"]; } set { this["extraParams"] = value; } }

		/// <summary> (Optional) An object containing request headers which are added to each request made by this object. (defaults to undefined)</summary>
		public object defaultHeaders { get { return (object)this["defaultHeaders"]; } set { this["defaultHeaders"] = value; } }

		/// <summary> (Optional) The default HTTP method to be used for requests. (defaults to undefined; if not set, but {@link #request} params are present, POST will be used; otherwise, GET will be used.)</summary>
		public string method { get { return (string)this["method"]; } set { this["method"] = value; } }

		/// <summary> (Optional) The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
		public double timeout { get { return (double)this["timeout"]; } set { this["timeout"] = value; } }

		/// <summary> (Optional) Whether this request should abort any pending requests. (defaults to false) @type Boolean</summary>
		public bool autoAbort { get { return (bool)this["autoAbort"]; } set { this["autoAbort"] = value; } }

		/// <summary> (Optional) True to add a unique cache-buster param to GET requests. (defaults to true) @type Boolean</summary>
		public bool disableCaching { get { return (bool)this["disableCaching"]; } set { this["disableCaching"] = value; } }

		/// <summary> (Optional) Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc' @type String</summary>
		public string disableCachingParam { get { return (string)this["disableCachingParam"]; } set { this["disableCachingParam"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class ConnectionEvents {
        /// <summary>Fires before a network request is made to retrieve a data object.
        /// <pre><code>
        /// USAGE: ({Connection} conn, {Object} options)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>conn</b></term><description>This Connection object.</description></item>
        /// <item><term><b>options</b></term><description>The options config object passed to the {@link #request} method.</description></item>
        /// </list>
        /// </summary>
        public static string beforerequest { get { return "beforerequest"; } }
        /// <summary>
        ///     Fires if the request was successfully completed.
        ///     See <a href="http://www.w3.org/TR/XMLHttpRequest/">The XMLHttpRequest Object</a>
        ///     for details.
        /// 
        /// <pre><code>
        /// USAGE: ({Connection} conn, {Object} response, {Object} options)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>conn</b></term><description>This Connection object.</description></item>
        /// <item><term><b>response</b></term><description>The XHR object containing the response data.</description></item>
        /// <item><term><b>options</b></term><description>The options config object passed to the {@link #request} method.</description></item>
        /// </list>
        /// </summary>
        public static string requestcomplete { get { return "requestcomplete"; } }
        /// <summary>
        ///     Fires if an error HTTP status was returned from the server.
        ///     See <a href="http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html">HTTP Status Code Definitions</a>
        ///     for details of HTTP status codes.
        ///     See <a href="http://www.w3.org/TR/XMLHttpRequest/">The XMLHttpRequest Object</a>
        ///     for details.
        /// 
        /// <pre><code>
        /// USAGE: ({Connection} conn, {Object} response, {Object} options)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>conn</b></term><description>This Connection object.</description></item>
        /// <item><term><b>response</b></term><description>The XHR object containing the response data.</description></item>
        /// <item><term><b>options</b></term><description>The options config object passed to the {@link #request} method.</description></item>
        /// </list>
        /// </summary>
        public static string requestexception { get { return "requestexception"; } }
    }

    public delegate void ConnectionBeforerequestDelegate(Connection conn, object options);
    public delegate void ConnectionRequestcompleteDelegate(Connection conn, object response, object options);
    public delegate void ConnectionRequestexceptionDelegate(Connection conn, object response, object options);
}
