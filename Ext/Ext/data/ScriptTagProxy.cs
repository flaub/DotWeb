using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     An implementation of Ext.data.DataProxy that reads a data object from a URL which may be in a domain
	///     other than the originating domain of the running page.<br>
	///     <p>
	///     <b>Note that if you are retrieving data from a page that is in a domain that is NOT the same as the originating domain
	///     of the running page, you must use this class, rather than HttpProxy.</b><br>
	///     <p>
	///     The content passed back from a server resource requested by a ScriptTagProxy <b>must</b> be executable JavaScript
	///     source code because it is used as the source inside a &lt;script> tag.<br>
	///     <p>
	///     In order for the browser to process the returned data, the server must wrap the data object
	///     with a call to a callback function, the name of which is passed as a parameter by the ScriptTagProxy.
	///     Below is a Java example for a servlet which returns data for either a ScriptTagProxy, or an HttpProxy
	///     depending on whether the callback name was passed:
	///     <p>
	///     <pre><code>
	///     boolean scriptTag = false;
	///     String cb = request.getParameter("callback");
	///     if (cb != null) {
	///     scriptTag = true;
	///     response.setContentType("text/javascript");
	///     } else {
	///     response.setContentType("application/x-json");
	///     }
	///     Writer out = response.getWriter();
	///     if (scriptTag) {
	///     out.write(cb + "(");
	///     }
	///     out.print(dataBlock.toJsonString());
	///     if (scriptTag) {
	///     out.write(");");
	///     }
	///     </code></pre>
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\ScriptTagProxy.js</jssource>
	public class ScriptTagProxy : Ext.data.DataProxy {

		/// <summary></summary>
		/// <returns></returns>
		public ScriptTagProxy() { C_(); }
		/// <summary></summary>
		/// <param name="config">A configuration object.</param>
		/// <returns></returns>
		public ScriptTagProxy(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static ScriptTagProxy prototype { get { return S_<ScriptTagProxy>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.DataProxy superclass { get { return S_<Ext.data.DataProxy>(); } set { S_(value); } }

		/// <summary>The URL from which to request the data object.</summary>
		public System.String url { get { return _<System.String>(); } set { _(value); } }

		/// <summary>(optional) The number of milliseconds to wait for a response. Defaults to 30 seconds.</summary>
		public double timeout { get { return _<double>(); } set { _(value); } }

		/// <summary>
		///     (Optional) The name of the parameter to pass to the server which tellsthe server the name of the callback function set up by the load call to process the returned data object.
		///     Defaults to "callback".<p>The server-side processing must read this parameter value, and generate
		///     javascript output which calls this named function passing the data object as its only parameter.
		/// </summary>
		public System.String callbackParam { get { return _<System.String>(); } set { _(value); } }

		/// <summary>(optional) Defaults to true. Disable caching by adding a unique parametername to the request.</summary>
		public bool nocache { get { return _<bool>(); } set { _(value); } }


		/// <summary>
		///     Load data from the configured URL, read the data object into
		///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
		///     process that block using the passed callback.
		///     for the request to the remote server.
		///     object into a block of Ext.data.Records.
		///     The function must be passed <ul>
		///     <li>The Record block object</li>
		///     <li>The "arg" argument from the load function</li>
		///     <li>A boolean success indicator</li>
		///     </ul>
		/// </summary>
		/// <returns></returns>
		public virtual void load() { _(); }

		/// <summary>
		///     Load data from the configured URL, read the data object into
		///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
		///     process that block using the passed callback.
		///     for the request to the remote server.
		///     object into a block of Ext.data.Records.
		///     The function must be passed <ul>
		///     <li>The Record block object</li>
		///     <li>The "arg" argument from the load function</li>
		///     <li>A boolean success indicator</li>
		///     </ul>
		/// </summary>
		/// <param name="prms">An object containing properties which are to be used as HTTP parameters</param>
		/// <returns></returns>
		public virtual void load(object prms) { _(prms); }

		/// <summary>
		///     Load data from the configured URL, read the data object into
		///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
		///     process that block using the passed callback.
		///     for the request to the remote server.
		///     object into a block of Ext.data.Records.
		///     The function must be passed <ul>
		///     <li>The Record block object</li>
		///     <li>The "arg" argument from the load function</li>
		///     <li>A boolean success indicator</li>
		///     </ul>
		/// </summary>
		/// <param name="prms">An object containing properties which are to be used as HTTP parameters</param>
		/// <param name="reader">The Reader object which converts the data</param>
		/// <returns></returns>
		public virtual void load(object prms, Ext.data.DataReader reader) { _(prms, reader); }

		/// <summary>
		///     Load data from the configured URL, read the data object into
		///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
		///     process that block using the passed callback.
		///     for the request to the remote server.
		///     object into a block of Ext.data.Records.
		///     The function must be passed <ul>
		///     <li>The Record block object</li>
		///     <li>The "arg" argument from the load function</li>
		///     <li>A boolean success indicator</li>
		///     </ul>
		/// </summary>
		/// <param name="prms">An object containing properties which are to be used as HTTP parameters</param>
		/// <param name="reader">The Reader object which converts the data</param>
		/// <param name="callback">The function into which to pass the block of Ext.data.Records.</param>
		/// <returns></returns>
		public virtual void load(object prms, Ext.data.DataReader reader, Delegate callback) { _(prms, reader, callback); }

		/// <summary>
		///     Load data from the configured URL, read the data object into
		///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
		///     process that block using the passed callback.
		///     for the request to the remote server.
		///     object into a block of Ext.data.Records.
		///     The function must be passed <ul>
		///     <li>The Record block object</li>
		///     <li>The "arg" argument from the load function</li>
		///     <li>A boolean success indicator</li>
		///     </ul>
		/// </summary>
		/// <param name="prms">An object containing properties which are to be used as HTTP parameters</param>
		/// <param name="reader">The Reader object which converts the data</param>
		/// <param name="callback">The function into which to pass the block of Ext.data.Records.</param>
		/// <param name="scope">The scope in which to call the callback</param>
		/// <returns></returns>
		public virtual void load(object prms, Ext.data.DataReader reader, Delegate callback, object scope) { _(prms, reader, callback, scope); }

		/// <summary>
		///     Load data from the configured URL, read the data object into
		///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
		///     process that block using the passed callback.
		///     for the request to the remote server.
		///     object into a block of Ext.data.Records.
		///     The function must be passed <ul>
		///     <li>The Record block object</li>
		///     <li>The "arg" argument from the load function</li>
		///     <li>A boolean success indicator</li>
		///     </ul>
		/// </summary>
		/// <param name="prms">An object containing properties which are to be used as HTTP parameters</param>
		/// <param name="reader">The Reader object which converts the data</param>
		/// <param name="callback">The function into which to pass the block of Ext.data.Records.</param>
		/// <param name="scope">The scope in which to call the callback</param>
		/// <param name="arg">An optional argument which is passed to the callback as its second parameter.</param>
		/// <returns></returns>
		public virtual void load(object prms, Ext.data.DataReader reader, Delegate callback, object scope, object arg) { _(prms, reader, callback, scope, arg); }

		/// <summary>Abort the current server request.</summary>
		/// <returns></returns>
		public virtual void abort() { _(); }



	}

	[JsAnonymous]
	public class ScriptTagProxyConfig : DotWeb.Client.JsAccessible {
		/// <summary> The URL from which to request the data object.</summary>
		public System.String url { get; set; }

		/// <summary> (optional) The number of milliseconds to wait for a response. Defaults to 30 seconds.</summary>
		public double timeout { get; set; }

		/// <summary> (Optional) The name of the parameter to pass to the server which tells the server the name of the callback function set up by the load call to process the returned data object. Defaults to "callback".<p>The server-side processing must read this parameter value, and generate javascript output which calls this named function passing the data object as its only parameter.</summary>
		public System.String callbackParam { get; set; }

		/// <summary> (optional) Defaults to true. Disable caching by adding a unique parameter name to the request.</summary>
		public bool nocache { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class ScriptTagProxyEvents {
        /// <summary>
        ///     Fires if an exception occurs in the Proxy during data loading.  This event can be fired for one of two reasons:
        ///     <ul><li><b>The load call timed out.</b>  This means the load callback did not execute within the time limit
        ///     specified by {@link #timeout}.  In this case, this event will be raised and the
        ///     fourth parameter (read error) will be null.</li>
        ///     <li><b>The load succeeded but the reader could not read the response.</b>  This means the server returned
        ///     data, but the configured Reader threw an error while reading the data.  In this case, this event will be
        ///     raised and the caught error will be passed along as the fourth parameter of this event.</li></ul>
        ///     Note that this event is also relayed through {@link Ext.data.Store}, so you can listen for it directly
        ///     on any Store instance.
        ///     call timed out, this parameter will be null.
        ///     If the load call returned success: false, this parameter will be null.
        /// 
        /// <pre><code>
        /// USAGE: ({Object} objthis, {Object} options, {Object} arg, {Error} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>options</b></term><description>The loading options that were specified (see {@link #load} for details).  If the load</description></item>
        /// <item><term><b>arg</b></term><description>The callback's arg object passed to the {@link #load} function</description></item>
        /// <item><term><b>e</b></term><description>The JavaScript Error object caught if the configured Reader could not read the data.</description></item>
        /// </list>
        /// </summary>
        public static string loadexception { get { return "loadexception"; } }
    }

    public delegate void ScriptTagProxyLoadexceptionDelegate(object objthis, object options, object arg, object e);
}
