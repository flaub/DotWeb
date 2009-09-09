using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     An implementation of {@link Ext.data.DataProxy} that reads a data object from a {@link Ext.data.Connection Connection} object
	///     configured to reference a certain URL.<br>
	///     <p>
	///     <b>Note that this class cannot be used to retrieve data from a domain other than the domain
	///     from which the running page was served.<br>
	///     <p>
	///     For cross-domain access to remote data, use a {@link Ext.data.ScriptTagProxy ScriptTagProxy}.</b><br>
	///     <p>
	///     Be aware that to enable the browser to parse an XML document, the server must set
	///     the Content-Type header in the HTTP response to "text/xml".
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\HttpProxy.js</jssource>
	public class HttpProxy : Ext.data.DataProxy {

		/// <summary>If an options parameter is passed, the singleton {@link Ext.Ajax} object will be used to make the request.</summary>
		/// <returns></returns>
		public HttpProxy() { C_(); }
		/// <summary>If an options parameter is passed, the singleton {@link Ext.Ajax} object will be used to make the request.</summary>
		/// <param name="conn">an {@link Ext.data.Connection} object, or options parameter to {@link Ext.Ajax#request}.</param>
		/// <returns></returns>
		public HttpProxy(object conn) { C_(conn); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static HttpProxy prototype { get { return S_<HttpProxy>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.DataProxy superclass { get { return S_<Ext.data.DataProxy>(); } set { S_(value); } }

		/// <summary>
		///     The Connection object (Or options parameter to {@link Ext.Ajax#request}) which this HttpProxy uses to make requests to the server.
		///     Properties of this object may be changed dynamically to change the way data is requested.
		/// </summary>
		public object conn { get { return _<object>(); } set { _(value); } }


		/// <summary>
		///     Return the {@link Ext.data.Connection} object being used by this Proxy.
		///     a finer-grained basis than the DataProxy events.
		/// </summary>
		/// <returns>Connection</returns>
		public virtual void getConnection() { _(); }

		/// <summary>
		///     Load data from the configured {@link Ext.data.Connection}, read the data object into
		///     a block of Ext.data.Records using the passed {@link Ext.data.DataReader} implementation, and
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
		///     Load data from the configured {@link Ext.data.Connection}, read the data object into
		///     a block of Ext.data.Records using the passed {@link Ext.data.DataReader} implementation, and
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
		///     Load data from the configured {@link Ext.data.Connection}, read the data object into
		///     a block of Ext.data.Records using the passed {@link Ext.data.DataReader} implementation, and
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
		///     Load data from the configured {@link Ext.data.Connection}, read the data object into
		///     a block of Ext.data.Records using the passed {@link Ext.data.DataReader} implementation, and
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
		///     Load data from the configured {@link Ext.data.Connection}, read the data object into
		///     a block of Ext.data.Records using the passed {@link Ext.data.DataReader} implementation, and
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
		///     Load data from the configured {@link Ext.data.Connection}, read the data object into
		///     a block of Ext.data.Records using the passed {@link Ext.data.DataReader} implementation, and
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



	}

	[JsAnonymous]
	public class HttpProxyConfig : DotWeb.Client.JsAccessible {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class HttpProxyEvents {
        /// <summary>
        ///     Fires if an exception occurs in the Proxy during data loading.  This event can be fired for one of two reasons:
        ///     <ul><li><b>The load call returned success: false.</b>  This means the server logic returned a failure
        ///     status and there is no data to read.  In this case, this event will be raised and the
        ///     fourth parameter (read error) will be null.</li>
        ///     <li><b>The load succeeded but the reader could not read the response.</b>  This means the server returned
        ///     data, but the configured Reader threw an error while reading the data.  In this case, this event will be
        ///     raised and the caught error will be passed along as the fourth parameter of this event.</li></ul>
        ///     Note that this event is also relayed through {@link Ext.data.Store}, so you can listen for it directly
        ///     on any Store instance.
        ///     If the load call returned success: false, this parameter will be null.
        /// 
        /// <pre><code>
        /// USAGE: ({Object} objthis, {Object} options, {Object} response, {Error} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>options</b></term><description>The loading options that were specified (see {@link #load} for details)</description></item>
        /// <item><term><b>response</b></term><description>The XMLHttpRequest object containing the response data</description></item>
        /// <item><term><b>e</b></term><description>The JavaScript Error object caught if the configured Reader could not read the data.</description></item>
        /// </list>
        /// </summary>
        public static string loadexception { get { return "loadexception"; } }
    }

    public delegate void HttpProxyLoadexceptionDelegate(object objthis, object options, object response, object e);
}
