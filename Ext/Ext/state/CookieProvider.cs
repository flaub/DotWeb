using System;
using H8.Support;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\state\CookieProvider.js</jssource>
    [Native]
    public class CookieProvider : Ext.state.Provider {

        /// <summary>Create a new CookieProvider</summary>
        /// <returns></returns>
        public CookieProvider() {}
        /// <summary>Create a new CookieProvider</summary>
        /// <param name="config">The configuration object</param>
        /// <returns></returns>
        public CookieProvider(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static CookieProvider prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.state.Provider superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class CookieProviderConfig {

        /// <summary> The path for which the cookie is active (defaults to root '/' which makes it active for all pages in the site)</summary>
        public System.String path { get { return null; } set { } }

        /// <summary> The cookie expiration date (defaults to 7 days from now)</summary>
        public System.DateTime expires { get { return DateTime.MinValue; } set { } }

        /// <summary> The domain to save the cookie for.  Note that you cannot specify a different domain than</summary>
        public System.String domain { get { return null; } set { } }

        /// <summary> True if the site is using SSL (defaults to false)</summary>
        public bool secure { get { return false; } set { } }

    }


}
