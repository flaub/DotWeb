using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Provides AJAX-style update capabilities for Element objects.  Updater can be used to {@link #update} an Element once,
	///     or you can use {@link #startAutoRefresh} to set up an auto-updating Element on a specific interval.<br><br>
	///     Usage:<br>
	///     <pre><code>
	///     // Get it from a Ext.Element object
	///     var el = Ext.get("foo");
	///     var mgr = el.getUpdater();
	///     mgr.update({
	///     url: "http://myserver.com/index.php",
	///     params: {
	///     param1: "foo",
	///     param2: "bar"
	///     }
	///     });
	///     ...
	///     mgr.formUpdate("myFormId", "http://myserver.com/index.php");
	///     <br>
	///     // or directly (returns the same Updater instance)
	///     var mgr = new Ext.Updater("myElementId");
	///     mgr.startAutoRefresh(60, "http://myserver.com/index.php");
	///     mgr.on("update", myFcnNeedsToKnow);
	///     <br>
	///     // short handed call directly from the element object
	///     Ext.get("foo").load({
	///     url: "bar.php",
	///     scripts: true,
	///     params: "param1=foo&amp;param2=bar",
	///     text: "Loading Foo..."
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\UpdateManager.js</jssource>
	public class UpdaterClass : Ext.util.Observable {

		/// <summary>
		///     Create new Updater directly.
		///     has an Updater and if it does it returns the same instance. This will skip that check (useful for extending this class).
		/// </summary>
		/// <returns></returns>
		public extern UpdaterClass();
		/// <summary>
		///     Create new Updater directly.
		///     has an Updater and if it does it returns the same instance. This will skip that check (useful for extending this class).
		/// </summary>
		/// <param name="el">The element to update</param>
		/// <returns></returns>
		public extern UpdaterClass(object el);
		/// <summary>
		///     Create new Updater directly.
		///     has an Updater and if it does it returns the same instance. This will skip that check (useful for extending this class).
		/// </summary>
		/// <param name="el">The element to update</param>
		/// <param name="forceNew">(optional) By default the constructor checks to see if the passed element already</param>
		/// <returns></returns>
		public extern UpdaterClass(object el, bool forceNew);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static UpdaterClass prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>The Element object</summary>
		public extern Ext.Element el { get; set; }

		/// <summary>Cached url to use for refreshes. Overwritten every time update() is called unless "discardUrl" param is set to true.</summary>
		public extern string defaultUrl { get; set; }

		/// <summary>Blank page URL to use with SSL file uploads (defaults to {@link Ext.Updater.defaults#sslBlankUrl}).</summary>
		public extern string sslBlankUrl { get; set; }

		/// <summary>Whether to append unique parameter on get request to disable caching (defaults to {@link Ext.Updater.defaults#disableCaching}).</summary>
		public extern bool disableCaching { get; set; }

		/// <summary>Text for loading indicator (defaults to {@link Ext.Updater.defaults#indicatorText}).</summary>
		public extern string indicatorText { get; set; }

		/// <summary>Whether to show indicatorText when loading (defaults to {@link Ext.Updater.defaults#showLoadIndicator}).</summary>
		public extern string showLoadIndicator { get; set; }

		/// <summary>Timeout for requests or form posts in seconds (defaults to {@link Ext.Updater.defaults#timeout}).</summary>
		public extern double timeout { get; set; }

		/// <summary>True to process scripts in the output (defaults to {@link Ext.Updater.defaults#loadScripts}).</summary>
		public extern bool loadScripts { get; set; }

		/// <summary>Transaction object of the current executing transaction, or null if there is no active transaction.</summary>
		public extern object transaction { get; set; }

		/// <summary>Delegate for refresh() prebound to "this", use myUpdater.refreshDelegate.createCallback(arg1, arg2) to bind arguments</summary>
		public extern Delegate refreshDelegate { get; set; }

		/// <summary>Delegate for update() prebound to "this", use myUpdater.updateDelegate.createCallback(arg1, arg2) to bind arguments</summary>
		public extern Delegate updateDelegate { get; set; }

		/// <summary>Delegate for formUpdate() prebound to "this", use myUpdater.formUpdateDelegate.createCallback(arg1, arg2) to bind arguments</summary>
		public extern Delegate formUpdateDelegate { get; set; }

		/// <summary>The renderer for this Updater (defaults to {@link Ext.Updater.BasicRenderer}).</summary>
		public extern object renderer { get; set; }


		/// <summary>
		///     This is an overrideable method which returns a reference to a default
		///     renderer class if none is specified when creating the Ext.Updater.
		///     Defaults to {@link Ext.Updater.BasicRenderer}
		/// </summary>
		/// <returns></returns>
		public extern virtual void getDefaultRenderer();

		/// <summary>Get the Element this Updater is bound to</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void getEl();

		/// <summary>
		///     Performs an <b>asynchronous</b> request, updating this element with the response.
		///     If params are specified it uses POST, otherwise it uses GET.<br><br>
		///     <b>Note:</b> Due to the asynchronous nature of remote server requests, the Element
		///     will not have been fully updated when the function returns. To post-process the returned
		///     data, use the callback option, or an <b><tt>update</tt></b> event handler.
		///     <li>url : <b>String/Function</b><p class="sub-desc">The URL to request or a function which
		///     <i>returns</i> the URL (defaults to the value of {@link Ext.Ajax#url} if not specified).</p></li>
		///     <li>method : <b>String</b><p class="sub-desc">The HTTP method to
		///     use. Defaults to POST if the <tt>params</tt> argument is present, otherwise GET.</p></li>
		///     <li>params : <b>String/Object/Function</b><p class="sub-desc">The
		///     parameters to pass to the server (defaults to none). These may be specified as a url-encoded
		///     string, or as an object containing properties which represent parameters,
		///     or as a function, which returns such an object.</p></li>
		///     <li>scripts : <b>Boolean</b><p class="sub-desc">If <tt>true</tt>
		///     any &lt;script&gt; tags embedded in the response text will be extracted
		///     and executed (defaults to {@link Ext.Updater.defaults#loadScripts}). If this option is specified,
		///     the callback will be called <i>after</i> the execution of the scripts.</p></li>
		///     <li>callback : <b>Function</b><p class="sub-desc">A function to
		///     be called when the response from the server arrives. The following
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li>
		///     <li><b>options</b> : Object<p class="sub-desc">The config object passed to the update call.</p></li></ul>
		///     </p></li>
		///     <li>scope : <b>Object</b><p class="sub-desc">The scope in which
		///     to execute the callback (The callback's <tt>this</tt> reference.) If the
		///     <tt>params</tt> argument is a function, this scope is used for that function also.</p></li>
		///     <li>discardUrl : <b>Boolean</b><p class="sub-desc">By default, the URL of this request becomes
		///     the default URL for this Updater object, and will be subsequently used in {@link #refresh}
		///     calls.  To bypass this behavior, pass <tt>discardUrl:true</tt> (defaults to false).</p></li>
		///     <li>timeout : <b>Number</b><p class="sub-desc">The number of seconds to wait for a response before
		///     timing out (defaults to {@link Ext.Updater.defaults#timeout}).</p></li>
		///     <li>text : <b>String</b><p class="sub-desc">The text to use as the innerHTML of the
		///     {@link Ext.Updater.defaults#indicatorText} div (defaults to 'Loading...').  To replace the entire div, not
		///     just the text, override {@link Ext.Updater.defaults#indicatorText} directly.</p></li>
		///     <li>nocache : <b>Boolean</b><p class="sub-desc">Only needed for GET
		///     requests, this option causes an extra, auto-generated parameter to be appended to the request
		///     to defeat caching (defaults to {@link Ext.Updater.defaults#disableCaching}).</p></li></ul>
		///     <p>
		///     For example:
		///     <pre><code>
		///     um.update({
		///     url: "your-url.php",
		///     params: {param1: "foo", param2: "bar"}, // or a URL encoded string
		///     callback: yourFunction,
		///     scope: yourObject, //(optional scope)
		///     discardUrl: true,
		///     nocache: true,
		///     text: "Loading...",
		///     timeout: 60,
		///     scripts: false // Save time by avoiding RegExp execution.
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns></returns>
		public extern virtual void update();

		/// <summary>
		///     Performs an <b>asynchronous</b> request, updating this element with the response.
		///     If params are specified it uses POST, otherwise it uses GET.<br><br>
		///     <b>Note:</b> Due to the asynchronous nature of remote server requests, the Element
		///     will not have been fully updated when the function returns. To post-process the returned
		///     data, use the callback option, or an <b><tt>update</tt></b> event handler.
		///     <li>url : <b>String/Function</b><p class="sub-desc">The URL to request or a function which
		///     <i>returns</i> the URL (defaults to the value of {@link Ext.Ajax#url} if not specified).</p></li>
		///     <li>method : <b>String</b><p class="sub-desc">The HTTP method to
		///     use. Defaults to POST if the <tt>params</tt> argument is present, otherwise GET.</p></li>
		///     <li>params : <b>String/Object/Function</b><p class="sub-desc">The
		///     parameters to pass to the server (defaults to none). These may be specified as a url-encoded
		///     string, or as an object containing properties which represent parameters,
		///     or as a function, which returns such an object.</p></li>
		///     <li>scripts : <b>Boolean</b><p class="sub-desc">If <tt>true</tt>
		///     any &lt;script&gt; tags embedded in the response text will be extracted
		///     and executed (defaults to {@link Ext.Updater.defaults#loadScripts}). If this option is specified,
		///     the callback will be called <i>after</i> the execution of the scripts.</p></li>
		///     <li>callback : <b>Function</b><p class="sub-desc">A function to
		///     be called when the response from the server arrives. The following
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li>
		///     <li><b>options</b> : Object<p class="sub-desc">The config object passed to the update call.</p></li></ul>
		///     </p></li>
		///     <li>scope : <b>Object</b><p class="sub-desc">The scope in which
		///     to execute the callback (The callback's <tt>this</tt> reference.) If the
		///     <tt>params</tt> argument is a function, this scope is used for that function also.</p></li>
		///     <li>discardUrl : <b>Boolean</b><p class="sub-desc">By default, the URL of this request becomes
		///     the default URL for this Updater object, and will be subsequently used in {@link #refresh}
		///     calls.  To bypass this behavior, pass <tt>discardUrl:true</tt> (defaults to false).</p></li>
		///     <li>timeout : <b>Number</b><p class="sub-desc">The number of seconds to wait for a response before
		///     timing out (defaults to {@link Ext.Updater.defaults#timeout}).</p></li>
		///     <li>text : <b>String</b><p class="sub-desc">The text to use as the innerHTML of the
		///     {@link Ext.Updater.defaults#indicatorText} div (defaults to 'Loading...').  To replace the entire div, not
		///     just the text, override {@link Ext.Updater.defaults#indicatorText} directly.</p></li>
		///     <li>nocache : <b>Boolean</b><p class="sub-desc">Only needed for GET
		///     requests, this option causes an extra, auto-generated parameter to be appended to the request
		///     to defeat caching (defaults to {@link Ext.Updater.defaults#disableCaching}).</p></li></ul>
		///     <p>
		///     For example:
		///     <pre><code>
		///     um.update({
		///     url: "your-url.php",
		///     params: {param1: "foo", param2: "bar"}, // or a URL encoded string
		///     callback: yourFunction,
		///     scope: yourObject, //(optional scope)
		///     discardUrl: true,
		///     nocache: true,
		///     text: "Loading...",
		///     timeout: 60,
		///     scripts: false // Save time by avoiding RegExp execution.
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="options">A config object containing any of the following options:<ul></param>
		/// <returns></returns>
		public extern virtual void update(object options);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <returns></returns>
		public extern virtual void formUpdate();

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <returns></returns>
		public extern virtual void formUpdate(string form);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <param name="url">(optional) The url to pass the form to. If omitted the action attribute on the form will be used.</param>
		/// <returns></returns>
		public extern virtual void formUpdate(string form, string url);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <param name="url">(optional) The url to pass the form to. If omitted the action attribute on the form will be used.</param>
		/// <param name="reset">(optional) Whether to try to reset the form after the update</param>
		/// <returns></returns>
		public extern virtual void formUpdate(string form, string url, bool reset);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <param name="url">(optional) The url to pass the form to. If omitted the action attribute on the form will be used.</param>
		/// <param name="reset">(optional) Whether to try to reset the form after the update</param>
		/// <param name="callback">(optional) Callback when transaction is complete. The following</param>
		/// <returns></returns>
		public extern virtual void formUpdate(string form, string url, bool reset, Delegate callback);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <returns></returns>
		public extern virtual void formUpdate(DOMElement form);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <param name="url">(optional) The url to pass the form to. If omitted the action attribute on the form will be used.</param>
		/// <returns></returns>
		public extern virtual void formUpdate(DOMElement form, string url);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <param name="url">(optional) The url to pass the form to. If omitted the action attribute on the form will be used.</param>
		/// <param name="reset">(optional) Whether to try to reset the form after the update</param>
		/// <returns></returns>
		public extern virtual void formUpdate(DOMElement form, string url, bool reset);

		/// <summary>
		///     Performs an async form post, updating this element with the response. If the form has the attribute
		///     enctype="multipart/form-data", it assumes it's a file upload.
		///     Uses this.sslBlankUrl for SSL file uploads to prevent IE security warning.
		///     parameters are passed:<ul>
		///     <li><b>el</b> : Ext.Element<p class="sub-desc">The Element being updated.</p></li>
		///     <li><b>success</b> : Boolean<p class="sub-desc">True for success, false for failure.</p></li>
		///     <li><b>response</b> : XMLHttpRequest<p class="sub-desc">The XMLHttpRequest which processed the update.</p></li></ul>
		/// </summary>
		/// <param name="form">The form Id or form element</param>
		/// <param name="url">(optional) The url to pass the form to. If omitted the action attribute on the form will be used.</param>
		/// <param name="reset">(optional) Whether to try to reset the form after the update</param>
		/// <param name="callback">(optional) Callback when transaction is complete. The following</param>
		/// <returns></returns>
		public extern virtual void formUpdate(DOMElement form, string url, bool reset, Delegate callback);

		/// <summary>Refresh the element with the last used url or defaultUrl. If there is no url, it returns immediately</summary>
		/// <returns></returns>
		public extern virtual void refresh();

		/// <summary>Refresh the element with the last used url or defaultUrl. If there is no url, it returns immediately</summary>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void refresh(Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <returns></returns>
		public extern virtual void startAutoRefresh();

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url, string prms);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url, string prms, Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <param name="refreshNow">(optional) Whether to execute the refresh now, or wait the interval</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url, string prms, Delegate callback, bool refreshNow);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url, string prms);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url, string prms, Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <param name="refreshNow">(optional) Whether to execute the refresh now, or wait the interval</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url, string prms, Delegate callback, bool refreshNow);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url, string prms);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url, string prms, Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <param name="refreshNow">(optional) Whether to execute the refresh now, or wait the interval</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url, string prms, Delegate callback, bool refreshNow);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url, object prms);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url, object prms, Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <param name="refreshNow">(optional) Whether to execute the refresh now, or wait the interval</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, string url, object prms, Delegate callback, bool refreshNow);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url, object prms);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url, object prms, Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <param name="refreshNow">(optional) Whether to execute the refresh now, or wait the interval</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, object url, object prms, Delegate callback, bool refreshNow);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url, object prms);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url, object prms, Delegate callback);

		/// <summary>
		///     Set this element to auto refresh.  Can be canceled by calling {@link #stopAutoRefresh}.
		///     supported by {@link #load}, or a function to call to get the url (defaults to the last used url).  Note that while
		///     the url used in a load call can be reused by this method, other load config options will not be reused and must be
		///     sepcified as part of a config object passed as this paramter if needed.
		///     "&param1=1&param2=2" or as an object {param1: 1, param2: 2}
		/// </summary>
		/// <param name="interval">How often to update (in seconds).</param>
		/// <param name="url">(optional) The url for this request, a config object in the same format</param>
		/// <param name="prms">(optional) The parameters to pass as either a url encoded string</param>
		/// <param name="callback">(optional) Callback when transaction is complete - called with signature (oElement, bSuccess)</param>
		/// <param name="refreshNow">(optional) Whether to execute the refresh now, or wait the interval</param>
		/// <returns></returns>
		public extern virtual void startAutoRefresh(double interval, Delegate url, object prms, Delegate callback, bool refreshNow);

		/// <summary>Stop auto refresh on this element.</summary>
		/// <returns></returns>
		public extern virtual void stopAutoRefresh();

		/// <summary>Returns true if the Updater is currently set to auto refresh its content (see {@link #startAutoRefresh}), otherwise false.</summary>
		/// <returns></returns>
		public extern virtual void isAutoRefreshing();

		/// <summary>
		///     Display the element's "loading" state. By default, the element is updated with {@link #indicatorText}. This
		///     method may be overridden to perform a custom action while this Updater is actively updating its contents.
		/// </summary>
		/// <returns></returns>
		public extern virtual void showLoading();

		/// <summary>Sets the content renderer for this Updater. See {@link Ext.Updater.BasicRenderer#render} for more details.</summary>
		/// <returns></returns>
		public extern virtual void setRenderer();

		/// <summary>Sets the content renderer for this Updater. See {@link Ext.Updater.BasicRenderer#render} for more details.</summary>
		/// <param name="renderer">The object implementing the render() method</param>
		/// <returns></returns>
		public extern virtual void setRenderer(object renderer);

		/// <summary>Returns the content renderer for this Updater. See {@link Ext.Updater.BasicRenderer#render} for more details.</summary>
		/// <returns>Object</returns>
		public extern virtual void getRenderer();

		/// <summary>Sets the default URL used for updates.</summary>
		/// <returns></returns>
		public extern virtual void setDefaultUrl();

		/// <summary>Sets the default URL used for updates.</summary>
		/// <param name="defaultUrl">The url or a function to call to get the url</param>
		/// <returns></returns>
		public extern virtual void setDefaultUrl(string defaultUrl);

		/// <summary>Sets the default URL used for updates.</summary>
		/// <param name="defaultUrl">The url or a function to call to get the url</param>
		/// <returns></returns>
		public extern virtual void setDefaultUrl(Delegate defaultUrl);

		/// <summary>Aborts the currently executing transaction, if any.</summary>
		/// <returns></returns>
		public extern virtual void abort();

		/// <summary>Returns true if an update is in progress, otherwise false.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isUpdating();



	}

	[JsAnonymous]
	public class UpdaterConfig : System.DotWeb.JsDynamic {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class UpdaterEvents {
        /// <summary>Fired before an update is made, return false from your handler and the update is cancelled.
        /// <pre><code>
        /// USAGE: ({Ext.Element} el, {String/Object/Function} url, {String/Object} prms)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>el</b></term><description></description></item>
        /// <item><term><b>url</b></term><description></description></item>
        /// <item><term><b>prms</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforeupdate { get { return "beforeupdate"; } }
        /// <summary>Fired after successful update is made.
        /// <pre><code>
        /// USAGE: ({Ext.Element} el, {Object} oResponseObject)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>el</b></term><description></description></item>
        /// <item><term><b>oResponseObject</b></term><description>The response Object</description></item>
        /// </list>
        /// </summary>
        public static string update { get { return "update"; } }
        /// <summary>Fired on update failure.
        /// <pre><code>
        /// USAGE: ({Ext.Element} el, {Object} oResponseObject)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>el</b></term><description></description></item>
        /// <item><term><b>oResponseObject</b></term><description>The response Object</description></item>
        /// </list>
        /// </summary>
        public static string failure { get { return "failure"; } }
    }

    public delegate void UpdaterBeforeupdateDelegate(Ext.Element el, object url, object prms);
    public delegate void UpdaterUpdateDelegate(Ext.Element el, object oResponseObject);
    public delegate void UpdaterFailureDelegate(Ext.Element el, object oResponseObject);
}
