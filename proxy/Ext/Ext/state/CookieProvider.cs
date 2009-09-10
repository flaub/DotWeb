using System;
using DotWeb.Client;

namespace Ext.state {
	/// <summary>
	///     /**
	///     The default Provider implementation which saves state via cookies.
	///     <br />Usage:
	///     <pre><code>
	///     var cp = new Ext.state.CookieProvider({
	///     path: "/cgi-bin/",
	///     expires: new Date(new Date().getTime()+(1000*60*60*24*30)), //30 days
	///     domain: "extjs.com"
	///     });
	///     Ext.state.Manager.setProvider(cp);
	///     </code></pre>
	///     @cfg {String} path The path for which the cookie is active (defaults to root '/' which makes it active for all pages in the site)
	///     @cfg {Date} expires The cookie expiration date (defaults to 7 days from now)
	///     @cfg {String} domain The domain to save the cookie for.  Note that you cannot specify a different domain than
	///     your page is on, but you can specify a sub-domain, or simply the domain itself like 'extjs.com' to include
	///     all sub-domains if you need to access cookies across different sub-domains (defaults to null which uses the same
	///     domain the page is running on including the 'www' like 'www.extjs.com')
	///     @cfg {Boolean} secure True if the site is using SSL (defaults to false)
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\state\CookieProvider.js</jssource>
	public class CookieProvider : Ext.state.Provider {

		/// <summary>Create a new CookieProvider</summary>
		/// <returns></returns>
		public CookieProvider() { C_(); }
		/// <summary>Create a new CookieProvider</summary>
		/// <param name="config">The configuration object</param>
		/// <returns></returns>
		public CookieProvider(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static CookieProvider prototype { get { return S_<CookieProvider>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.state.Provider superclass { get { return S_<Ext.state.Provider>(); } set { S_(value); } }




	}

	[JsAnonymous]
	public class CookieProviderConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> The path for which the cookie is active (defaults to root '/' which makes it active for all pages in the site)</summary>
		public string path { get { return _<string>(); } set { _(value); } }

		/// <summary> The cookie expiration date (defaults to 7 days from now)</summary>
		public System.DateTime expires { get { return _<System.DateTime>(); } set { _(value); } }

		/// <summary> The domain to save the cookie for.  Note that you cannot specify a different domain than</summary>
		public string domain { get { return _<string>(); } set { _(value); } }

		/// <summary> True if the site is using SSL (defaults to false)</summary>
		public bool secure { get { return _<bool>(); } set { _(value); } }

	}
}
