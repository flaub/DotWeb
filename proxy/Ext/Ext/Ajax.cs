using System;
using System.DotWeb;
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
		public extern Ajax();
		/// <summary></summary>
		/// <param name="config">a configuration object.</param>
		/// <returns></returns>
		public extern Ajax(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Ajax prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.data.Connection superclass { get; set; }

		/// <summary>True to add a unique cache-buster param to GET requests. (defaults to true)</summary>
		public extern static bool disableCaching { get; set; }

		/// <summary>The default URL to be used for requests to the server. (defaults to undefined)</summary>
		public extern static string url { get; set; }

		/// <summary>
		///     An object containing properties which are used as
		///     extra parameters to each request made by this object. (defaults to undefined)
		/// </summary>
		public extern static object extraParams { get; set; }

		/// <summary>An object containing request headers which are added to each request made by this object. (defaults to undefined)</summary>
		public extern static object defaultHeaders { get; set; }

		/// <summary>
		///     The default HTTP method to be used for requests. Note that this is case-sensitive and should be all caps (defaults
		///     to undefined; if not set but parms are present will use "POST," otherwise "GET.")
		/// </summary>
		public extern static string method { get; set; }

		/// <summary>The timeout in milliseconds to be used for requests. (defaults to 30000)</summary>
		public extern static double timeout { get; set; }

		/// <summary>Whether a new request should abort any pending requests. (defaults to false)</summary>
		public extern static bool autoAbort { get; set; }


		/// <summary>Serialize the passed form into a url encoded string</summary>
		/// <returns>String</returns>
		public extern static void serializeForm();

		/// <summary>Serialize the passed form into a url encoded string</summary>
		/// <param name="form"></param>
		/// <returns>String</returns>
		public extern static void serializeForm(string form);

		/// <summary>Serialize the passed form into a url encoded string</summary>
		/// <param name="form"></param>
		/// <returns>String</returns>
		public extern static void serializeForm(DOMElement form);



	}

	[JsAnonymous]
	public class AjaxConfig : System.DotWeb.JsDynamic {
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
}
