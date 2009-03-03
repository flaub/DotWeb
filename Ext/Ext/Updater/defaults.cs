using System;
using DotWeb.Client;

namespace Ext.Updater {
	/// <summary>
	///     /**
	///     The defaults collection enables customizing the default properties of Updater
	///     */
	///     Ext.Updater.defaults = {
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\core\UpdateManager.js</jssource>
	public class defaults : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public defaults() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static defaults prototype { get { return S_<defaults>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>Timeout for requests or form posts in seconds (defaults to 30 seconds).</summary>
		public double timeout { get { return _<double>(); } set { _(value); } }

		/// <summary>True to process scripts by default (defaults to false).</summary>
		public bool loadScripts { get { return _<bool>(); } set { _(value); } }

		/// <summary>Blank page URL to use with SSL file uploads (defaults to {@link Ext#SSL_SECURE_URL} if set, or "javascript:false").</summary>
		public System.String sslBlankUrl { get { return _<System.String>(); } set { _(value); } }

		/// <summary>True to append a unique parameter to GET requests to disable caching (defaults to false).</summary>
		public bool disableCaching { get { return _<bool>(); } set { _(value); } }

		/// <summary>Whether or not to show {@link #indicatorText} during loading (defaults to true).</summary>
		public bool showLoadIndicator { get { return _<bool>(); } set { _(value); } }

		/// <summary>Text for loading indicator (defaults to '&lt;div class="loading-indicator"&gt;Loading...&lt;/div&gt;').</summary>
		public System.String indicatorText { get { return _<System.String>(); } set { _(value); } }




	}
}
