using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.Updater {
	/// <summary>
	///     /**
	///     The defaults collection enables customizing the default properties of Updater
	///     */
	///     Ext.Updater.defaults = {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\UpdateManager.js</jssource>
	public class defaults : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern defaults();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static defaults prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>Timeout for requests or form posts in seconds (defaults to 30 seconds).</summary>
		public extern double timeout { get; set; }

		/// <summary>True to process scripts by default (defaults to false).</summary>
		public extern bool loadScripts { get; set; }

		/// <summary>Blank page URL to use with SSL file uploads (defaults to {@link Ext#SSL_SECURE_URL} if set, or "javascript:false").</summary>
		public extern string sslBlankUrl { get; set; }

		/// <summary>True to append a unique parameter to GET requests to disable caching (defaults to false).</summary>
		public extern bool disableCaching { get; set; }

		/// <summary>Whether or not to show {@link #indicatorText} during loading (defaults to true).</summary>
		public extern bool showLoadIndicator { get; set; }

		/// <summary>Text for loading indicator (defaults to '&lt;div class="loading-indicator"&gt;Loading...&lt;/div&gt;').</summary>
		public extern string indicatorText { get; set; }




	}
}
