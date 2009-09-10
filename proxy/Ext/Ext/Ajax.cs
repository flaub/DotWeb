using System;
using DotWeb.Client;

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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\Connection.js</jssource>
	public class Ajax : Ext.data.Connection {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Ajax() { C_(); }
		/// <summary></summary>
		/// <param name="config">a configuration object.</param>
		/// <returns></returns>
		public Ajax(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Ajax prototype { get { return S_<Ajax>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.Connection superclass { get { return S_<Ext.data.Connection>(); } set { S_(value); } }

		/// <summary>True to add a unique cache-buster param to GET requests. (defaults to true)</summary>
		public static bool disableCaching { get { return S_<bool>(); } set { S_(value); } }

		/// <summary>The default URL to be used for requests to the server. (defaults to undefined)</summary>
		public static string url { get { return S_<string>(); } set { S_(value); } }

		/// <summary>
		///     An object containing properties which are used as
		///     extra parameters to each request made by this object. (defaults to undefined)
		/// </summary>
		public static object extraParams { get { return S_<object>(); } set { S_(value); } }

		/// <summary>An object containing request headers which are added to each request made by this object. (defaults to undefined)</summary>
		public static object defaultHeaders { get { return S_<object>(); } set { S_(value); } }

		/// <summary>
		///     The default HTTP method to be used for requests. Note that this is case-sensitive and should be all caps (defaults
		///     to undefined; if not set but parms are present will use "POST," otherwise "GET.")
		/// </summary>
		public static string method { get { return S_<string>(); } set { S_(value); } }

		/// <summary>The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
		public static double timeout { get { return S_<double>(); } set { S_(value); } }

		/// <summary>Whether a new request should abort any pending requests. (defaults to false)</summary>
		public static bool autoAbort { get { return S_<bool>(); } set { S_(value); } }


		/// <summary>Serialize the passed form into a url encoded string</summary>
		/// <returns>String</returns>
		public static void serializeForm() { S_(); }

		/// <summary>Serialize the passed form into a url encoded string</summary>
		/// <param name="form"></param>
		/// <returns>String</returns>
		public static void serializeForm(string form) { S_(form); }

		/// <summary>Serialize the passed form into a url encoded string</summary>
		/// <param name="form"></param>
		/// <returns>String</returns>
		public static void serializeForm(DOMElement form) { S_(form); }



	}

	[JsAnonymous]
	public class AjaxConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> (Optional) The default URL to be used for requests to the server. (defaults to undefined)</summary>
		public string url { get { return _<string>(); } set { _(value); } }

		/// <summary> (Optional) An object containing properties which are used as extra parameters to each request made by this object. (defaults to undefined)</summary>
		public object extraParams { get { return _<object>(); } set { _(value); } }

		/// <summary> (Optional) An object containing request headers which are added to each request made by this object. (defaults to undefined)</summary>
		public object defaultHeaders { get { return _<object>(); } set { _(value); } }

		/// <summary> (Optional) The default HTTP method to be used for requests. (defaults to undefined; if not set, but {@link #request} params are present, POST will be used; otherwise, GET will be used.)</summary>
		public string method { get { return _<string>(); } set { _(value); } }

		/// <summary> (Optional) The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
		public double timeout { get { return _<double>(); } set { _(value); } }

		/// <summary> (Optional) Whether this request should abort any pending requests. (defaults to false) @type Boolean</summary>
		public bool autoAbort { get { return _<bool>(); } set { _(value); } }

		/// <summary> (Optional) True to add a unique cache-buster param to GET requests. (defaults to true) @type Boolean</summary>
		public bool disableCaching { get { return _<bool>(); } set { _(value); } }

		/// <summary> (Optional) Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc' @type String</summary>
		public string disableCachingParam { get { return _<string>(); } set { _(value); } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return _<object>(); } set { _(value); } }

	}
}
