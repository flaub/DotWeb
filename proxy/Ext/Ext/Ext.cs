using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Ext core utilities and functions.
	///     */
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\Ext.js</jssource>
	[JsNamespace()]
	public class ExtClass : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern ExtClass();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ExtClass prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>True if the browser is in strict (standards-compliant) mode, as opposed to quirks mode</summary>
		public extern static bool isStrict { get; set; }

		/// <summary>True if the page is running over SSL</summary>
		public extern static bool isSecure { get; set; }

		/// <summary>True when the document is fully initialized and ready for action</summary>
		public extern static bool isReady { get; set; }

		/// <summary>True to automatically uncache orphaned Ext.Elements periodically (defaults to true)</summary>
		public extern static bool enableGarbageCollector { get; set; }

		/// <summary>
		///     True to automatically purge event listeners after uncaching an element (defaults to false).
		///     Note: this only happens if enableGarbageCollector is true.
		/// </summary>
		public extern static bool enableListenerCollection { get; set; }

		/// <summary>
		///     URL to a blank file used by Ext when in secure mode for iframe src and onReady src to prevent
		///     the IE insecure content warning (defaults to javascript:false).
		/// </summary>
		public extern static string SSL_SECURE_URL { get; set; }

		/// <summary>
		///     URL to a 1x1 transparent gif image used by Ext to create inline icons with CSS background images. (Defaults to
		///     "http://extjs.com/s.gif" and you should change this to a URL on your server).
		/// </summary>
		public extern static string BLANK_IMAGE_URL { get; set; }

		/// <summary>True if the detected browser is Opera.</summary>
		public extern static bool isOpera { get; set; }

		/// <summary>True if the detected browser is Safari.</summary>
		public extern static bool isSafari { get; set; }

		/// <summary>True if the detected browser is Safari 3.x.</summary>
		public extern static bool isSafari3 { get; set; }

		/// <summary>True if the detected browser is Safari 2.x.</summary>
		public extern static bool isSafari2 { get; set; }

		/// <summary>True if the detected browser is Internet Explorer.</summary>
		public extern static bool isIE { get; set; }

		/// <summary>True if the detected browser is Internet Explorer 6.x.</summary>
		public extern static bool isIE6 { get; set; }

		/// <summary>True if the detected browser is Internet Explorer 7.x.</summary>
		public extern static bool isIE7 { get; set; }

		/// <summary>True if the detected browser uses the Gecko layout engine (e.g. Mozilla, Firefox).</summary>
		public extern static bool isGecko { get; set; }

		/// <summary>True if the detected browser uses a pre-Gecko 1.9 layout engine (e.g. Firefox 2.x).</summary>
		public extern static bool isGecko2 { get; set; }

		/// <summary>True if the detected browser uses a Gecko 1.9+ layout engine (e.g. Firefox 3.x).</summary>
		public extern static bool isGecko3 { get; set; }

		/// <summary>True if the detected browser is Internet Explorer running in non-strict mode.</summary>
		public extern static bool isBorderBox { get; set; }

		/// <summary>True if the detected platform is Linux.</summary>
		public extern static bool isLinux { get; set; }

		/// <summary>True if the detected platform is Windows.</summary>
		public extern static bool isWindows { get; set; }

		/// <summary>True if the detected platform is Mac OS.</summary>
		public extern static bool isMac { get; set; }

		/// <summary>True if the detected platform is Adobe Air.</summary>
		public extern static bool isAir { get; set; }

		/// <summary>
		///     By default, Ext intelligently decides whether floating elements should be shimmed. If you are using flash,
		///     you may want to set this to true.
		/// </summary>
		public extern static bool useShims { get; set; }


		/// <summary>
		///     A reusable empty function
		///     @property
		///     @type Function
		/// </summary>
		/// <returns></returns>
		public extern static void emptyFn();

		/// <summary>Copies all the properties of config to obj if they don't already exist.</summary>
		/// <returns>Object</returns>
		public extern static void applyIf();

		/// <summary>Copies all the properties of config to obj if they don't already exist.</summary>
		/// <param name="obj">The receiver of the properties</param>
		/// <returns>Object</returns>
		public extern static void applyIf(object obj);

		/// <summary>Copies all the properties of config to obj if they don't already exist.</summary>
		/// <param name="obj">The receiver of the properties</param>
		/// <param name="config">The source of the properties</param>
		/// <returns>Object</returns>
		public extern static void applyIf(object obj, object config);

		/// <summary>
		///     Applies event listeners to elements by selectors when the document is ready.
		///     The event name is specified with an @ suffix.
		///     <pre><code>
		///     Ext.addBehaviors({
		///     // add a listener for click on all anchors in element with id foo
		///     '#foo a@click' : function(e, t){
		///     // do something
		///     },
		///     // add the same listener to multiple selectors (separated by comma BEFORE the @)
		///     '#foo a, #bar span.some-class@mouseover' : function(){
		///     // do something
		///     }
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns></returns>
		public extern static void addBehaviors();

		/// <summary>
		///     Applies event listeners to elements by selectors when the document is ready.
		///     The event name is specified with an @ suffix.
		///     <pre><code>
		///     Ext.addBehaviors({
		///     // add a listener for click on all anchors in element with id foo
		///     '#foo a@click' : function(e, t){
		///     // do something
		///     },
		///     // add the same listener to multiple selectors (separated by comma BEFORE the @)
		///     '#foo a, #bar span.some-class@mouseover' : function(){
		///     // do something
		///     }
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="obj">The list of behaviors to apply</param>
		/// <returns></returns>
		public extern static void addBehaviors(object obj);

		/// <summary>Generates unique ids. If the element already has an id, it is unchanged</summary>
		/// <returns>String</returns>
		public extern static void id();

		/// <summary>Generates unique ids. If the element already has an id, it is unchanged</summary>
		/// <param name="el">(optional) The element to generate an id for</param>
		/// <returns>String</returns>
		public extern static void id(object el);

		/// <summary>Generates unique ids. If the element already has an id, it is unchanged</summary>
		/// <param name="el">(optional) The element to generate an id for</param>
		/// <param name="prefix">(optional) Id prefix (defaults "ext-gen")</param>
		/// <returns>String</returns>
		public extern static void id(object el, string prefix);

		/// <summary>
		///     Extends one class with another class and optionally overrides members with the passed literal. This class
		///     also adds the function "override()" to the class that can be used to override
		///     members on an instance.
		///     * <p>
		///     This function also supports a 2-argument call in which the subclass's constructor is
		///     not passed as an argument. In this form, the parameters are as follows:</p><p>
		///     <div class="mdetail-params"><ul>
		///     <li><code>superclass</code>
		///     <div class="sub-desc">The class being extended</div></li>
		///     <li><code>overrides</code>
		///     <div class="sub-desc">A literal with members which are copied into the subclass's
		///     prototype, and are therefore shared among all instances of the new class.<p>
		///     This may contain a special member named <tt><b>constructor</b></tt>. This is used
		///     to define the constructor of the new class, and is returned. If this property is
		///     <i>not</i> specified, a constructor is generated and returned which just calls the
		///     superclass's constructor passing on its parameters.</p></div></li>
		///     </ul></div></p><p>
		///     For example, to create a subclass of the Ext GridPanel:
		///     <pre><code>
		///     MyGridPanel = Ext.extend(Ext.grid.GridPanel, {
		///     constructor: function(config) {
		///     // Your preprocessing here
		///     MyGridPanel.superclass.constructor.apply(this, arguments);
		///     // Your postprocessing here
		///     },
		///     yourMethod: function() {
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     </p>
		///     prototype, and are therefore shared between all instances of the new class.
		/// </summary>
		/// <returns>Function</returns>
		public extern static void extend();

		/// <summary>
		///     Extends one class with another class and optionally overrides members with the passed literal. This class
		///     also adds the function "override()" to the class that can be used to override
		///     members on an instance.
		///     * <p>
		///     This function also supports a 2-argument call in which the subclass's constructor is
		///     not passed as an argument. In this form, the parameters are as follows:</p><p>
		///     <div class="mdetail-params"><ul>
		///     <li><code>superclass</code>
		///     <div class="sub-desc">The class being extended</div></li>
		///     <li><code>overrides</code>
		///     <div class="sub-desc">A literal with members which are copied into the subclass's
		///     prototype, and are therefore shared among all instances of the new class.<p>
		///     This may contain a special member named <tt><b>constructor</b></tt>. This is used
		///     to define the constructor of the new class, and is returned. If this property is
		///     <i>not</i> specified, a constructor is generated and returned which just calls the
		///     superclass's constructor passing on its parameters.</p></div></li>
		///     </ul></div></p><p>
		///     For example, to create a subclass of the Ext GridPanel:
		///     <pre><code>
		///     MyGridPanel = Ext.extend(Ext.grid.GridPanel, {
		///     constructor: function(config) {
		///     // Your preprocessing here
		///     MyGridPanel.superclass.constructor.apply(this, arguments);
		///     // Your postprocessing here
		///     },
		///     yourMethod: function() {
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     </p>
		///     prototype, and are therefore shared between all instances of the new class.
		/// </summary>
		/// <param name="subclass">The class inheriting the functionality</param>
		/// <returns>Function</returns>
		public extern static void extend(Delegate subclass);

		/// <summary>
		///     Extends one class with another class and optionally overrides members with the passed literal. This class
		///     also adds the function "override()" to the class that can be used to override
		///     members on an instance.
		///     * <p>
		///     This function also supports a 2-argument call in which the subclass's constructor is
		///     not passed as an argument. In this form, the parameters are as follows:</p><p>
		///     <div class="mdetail-params"><ul>
		///     <li><code>superclass</code>
		///     <div class="sub-desc">The class being extended</div></li>
		///     <li><code>overrides</code>
		///     <div class="sub-desc">A literal with members which are copied into the subclass's
		///     prototype, and are therefore shared among all instances of the new class.<p>
		///     This may contain a special member named <tt><b>constructor</b></tt>. This is used
		///     to define the constructor of the new class, and is returned. If this property is
		///     <i>not</i> specified, a constructor is generated and returned which just calls the
		///     superclass's constructor passing on its parameters.</p></div></li>
		///     </ul></div></p><p>
		///     For example, to create a subclass of the Ext GridPanel:
		///     <pre><code>
		///     MyGridPanel = Ext.extend(Ext.grid.GridPanel, {
		///     constructor: function(config) {
		///     // Your preprocessing here
		///     MyGridPanel.superclass.constructor.apply(this, arguments);
		///     // Your postprocessing here
		///     },
		///     yourMethod: function() {
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     </p>
		///     prototype, and are therefore shared between all instances of the new class.
		/// </summary>
		/// <param name="subclass">The class inheriting the functionality</param>
		/// <param name="superclass">The class being extended</param>
		/// <returns>Function</returns>
		public extern static void extend(Delegate subclass, Delegate superclass);

		/// <summary>
		///     Extends one class with another class and optionally overrides members with the passed literal. This class
		///     also adds the function "override()" to the class that can be used to override
		///     members on an instance.
		///     * <p>
		///     This function also supports a 2-argument call in which the subclass's constructor is
		///     not passed as an argument. In this form, the parameters are as follows:</p><p>
		///     <div class="mdetail-params"><ul>
		///     <li><code>superclass</code>
		///     <div class="sub-desc">The class being extended</div></li>
		///     <li><code>overrides</code>
		///     <div class="sub-desc">A literal with members which are copied into the subclass's
		///     prototype, and are therefore shared among all instances of the new class.<p>
		///     This may contain a special member named <tt><b>constructor</b></tt>. This is used
		///     to define the constructor of the new class, and is returned. If this property is
		///     <i>not</i> specified, a constructor is generated and returned which just calls the
		///     superclass's constructor passing on its parameters.</p></div></li>
		///     </ul></div></p><p>
		///     For example, to create a subclass of the Ext GridPanel:
		///     <pre><code>
		///     MyGridPanel = Ext.extend(Ext.grid.GridPanel, {
		///     constructor: function(config) {
		///     // Your preprocessing here
		///     MyGridPanel.superclass.constructor.apply(this, arguments);
		///     // Your postprocessing here
		///     },
		///     yourMethod: function() {
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     </p>
		///     prototype, and are therefore shared between all instances of the new class.
		/// </summary>
		/// <param name="subclass">The class inheriting the functionality</param>
		/// <param name="superclass">The class being extended</param>
		/// <param name="overrides">(optional) A literal with members which are copied into the subclass's</param>
		/// <returns>Function</returns>
		public extern static void extend(Delegate subclass, Delegate superclass, object overrides);

		/// <summary>
		///     Adds a list of functions to the prototype of an existing class, overwriting any existing methods with the same name.
		///     Usage:<pre><code>
		///     Ext.override(MyClass, {
		///     newMethod1: function(){
		///     // etc.
		///     },
		///     newMethod2: function(foo){
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     containing one or more methods.
		/// </summary>
		/// <returns></returns>
		public extern static void override_();

		/// <summary>
		///     Adds a list of functions to the prototype of an existing class, overwriting any existing methods with the same name.
		///     Usage:<pre><code>
		///     Ext.override(MyClass, {
		///     newMethod1: function(){
		///     // etc.
		///     },
		///     newMethod2: function(foo){
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     containing one or more methods.
		/// </summary>
		/// <param name="origclass">The class to override</param>
		/// <returns></returns>
		public extern static void override_(object origclass);

		/// <summary>
		///     Adds a list of functions to the prototype of an existing class, overwriting any existing methods with the same name.
		///     Usage:<pre><code>
		///     Ext.override(MyClass, {
		///     newMethod1: function(){
		///     // etc.
		///     },
		///     newMethod2: function(foo){
		///     // etc.
		///     }
		///     });
		///     </code></pre>
		///     containing one or more methods.
		/// </summary>
		/// <param name="origclass">The class to override</param>
		/// <param name="overrides">The list of functions to add to origClass.  This should be specified as an object literal</param>
		/// <returns></returns>
		public extern static void override_(object origclass, object overrides);

		/// <summary>
		///     Creates namespaces to be used for scoping variables and classes so that they are not global.  Usage:
		///     <pre><code>
		///     Ext.namespace('Company', 'Company.data');
		///     Company.Widget = function() { ... }
		///     Company.data.CustomStore = function(config) { ... }
		///     </code></pre>
		/// </summary>
		/// <returns></returns>
		public extern static void namespace_();

		/// <summary>
		///     Creates namespaces to be used for scoping variables and classes so that they are not global.  Usage:
		///     <pre><code>
		///     Ext.namespace('Company', 'Company.data');
		///     Company.Widget = function() { ... }
		///     Company.data.CustomStore = function(config) { ... }
		///     </code></pre>
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public extern static void namespace_(params string[] args);

		/// <summary>Takes an object and converts it to an encoded URL. e.g. Ext.urlEncode({foo: 1, bar: 2}); would return "foo=1&bar=2".  Optionally, property values can be arrays, instead of keys and the resulting string that's returned will contain a name/value pair for each array value.</summary>
		/// <returns>String</returns>
		public extern static void urlEncode();

		/// <summary>Takes an object and converts it to an encoded URL. e.g. Ext.urlEncode({foo: 1, bar: 2}); would return "foo=1&bar=2".  Optionally, property values can be arrays, instead of keys and the resulting string that's returned will contain a name/value pair for each array value.</summary>
		/// <param name="o"></param>
		/// <returns>String</returns>
		public extern static void urlEncode(object o);

		/// <summary>Takes an encoded URL and and converts it to an object. e.g. Ext.urlDecode("foo=1&bar=2"); would return {foo: 1, bar: 2} or Ext.urlDecode("foo=1&bar=2&bar=3&bar=4", true); would return {foo: 1, bar: [2, 3, 4]}.</summary>
		/// <returns>Object</returns>
		public extern static void urlDecode();

		/// <summary>Takes an encoded URL and and converts it to an object. e.g. Ext.urlDecode("foo=1&bar=2"); would return {foo: 1, bar: 2} or Ext.urlDecode("foo=1&bar=2&bar=3&bar=4", true); would return {foo: 1, bar: [2, 3, 4]}.</summary>
		/// <param name="str"></param>
		/// <returns>Object</returns>
		public extern static void urlDecode(string str);

		/// <summary>Takes an encoded URL and and converts it to an object. e.g. Ext.urlDecode("foo=1&bar=2"); would return {foo: 1, bar: 2} or Ext.urlDecode("foo=1&bar=2&bar=3&bar=4", true); would return {foo: 1, bar: [2, 3, 4]}.</summary>
		/// <param name="str"></param>
		/// <param name="overwrite">(optional) Items of the same name will overwrite previous values instead of creating an an array (Defaults to false).</param>
		/// <returns>Object</returns>
		public extern static void urlDecode(string str, bool overwrite);

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <returns></returns>
		public extern static void each();

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public extern static void each(System.Array array);

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <param name="array"></param>
		/// <param name="fn"></param>
		/// <returns></returns>
		public extern static void each(System.Array array, Delegate fn);

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <param name="array"></param>
		/// <param name="fn"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		public extern static void each(System.Array array, Delegate fn, object scope);

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public extern static void each(object array);

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <param name="array"></param>
		/// <param name="fn"></param>
		/// <returns></returns>
		public extern static void each(object array, Delegate fn);

		/// <summary>
		///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
		///     passed array is not really an array, your function is called once with it.
		///     The supplied function is called with (Object item, Number index, Array allItems).
		/// </summary>
		/// <param name="array"></param>
		/// <param name="fn"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		public extern static void each(object array, Delegate fn, object scope);

		/// <summary>Escapes the passed string for use in a regular expression</summary>
		/// <returns>String</returns>
		public extern static void escapeRe();

		/// <summary>Escapes the passed string for use in a regular expression</summary>
		/// <param name="str"></param>
		/// <returns>String</returns>
		public extern static void escapeRe(string str);

		/// <summary>Return the dom node for the passed string (id), dom node, or Ext.Element</summary>
		/// <returns>HTMLElement</returns>
		public extern static void getDom();

		/// <summary>Return the dom node for the passed string (id), dom node, or Ext.Element</summary>
		/// <param name="el"></param>
		/// <returns>HTMLElement</returns>
		public extern static void getDom(object el);

		/// <summary>Returns the current HTML document object as an {@link Ext.Element}.</summary>
		/// <returns>Ext.Element</returns>
		public extern static void getDoc();

		/// <summary>Returns the current document body as an {@link Ext.Element}.</summary>
		/// <returns>Ext.Element</returns>
		public extern static void getBody();

		/// <summary>Shorthand for {@link Ext.ComponentMgr#get}</summary>
		/// <returns>Ext.Component</returns>
		public extern static void getCmp();

		/// <summary>Shorthand for {@link Ext.ComponentMgr#get}</summary>
		/// <param name="id"></param>
		/// <returns>Ext.Component</returns>
		public extern static void getCmp(string id);

		/// <summary>Utility method for validating that a value is numeric, returning the specified default value if it is not.</summary>
		/// <returns>Number</returns>
		public extern static void num();

		/// <summary>Utility method for validating that a value is numeric, returning the specified default value if it is not.</summary>
		/// <param name="value">Should be a number, but any type will be handled appropriately</param>
		/// <returns>Number</returns>
		public extern static void num(object value);

		/// <summary>Utility method for validating that a value is numeric, returning the specified default value if it is not.</summary>
		/// <param name="value">Should be a number, but any type will be handled appropriately</param>
		/// <param name="defaultValue">The value to return if the original value is non-numeric</param>
		/// <returns>Number</returns>
		public extern static void num(object value, double defaultValue);

		/// <summary>
		///     Attempts to destroy any objects passed to it by removing all event listeners, removing them from the
		///     DOM (if applicable) and calling their destroy functions (if available).  This method is primarily
		///     intended for arguments of type {@link Ext.Element} and {@link Ext.Component}, but any subclass of
		///     {@link Ext.util.Observable} can be passed in.  Any number of elements and/or components can be
		///     passed into this function in a single call as separate arguments.
		/// </summary>
		/// <returns></returns>
		public extern static void destroy();

		/// <summary>
		///     Attempts to destroy any objects passed to it by removing all event listeners, removing them from the
		///     DOM (if applicable) and calling their destroy functions (if available).  This method is primarily
		///     intended for arguments of type {@link Ext.Element} and {@link Ext.Component}, but any subclass of
		///     {@link Ext.util.Observable} can be passed in.  Any number of elements and/or components can be
		///     passed into this function in a single call as separate arguments.
		/// </summary>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void destroy(params object[] args);

		/// <summary>Removes a DOM node from the document.  The body node will be ignored if passed in.</summary>
		/// <returns></returns>
		public extern static void removeNode();

		/// <summary>Removes a DOM node from the document.  The body node will be ignored if passed in.</summary>
		/// <param name="node">The node to remove</param>
		/// <returns></returns>
		public extern static void removeNode(DOMElement node);

		/// <summary>
		///     Returns the type of object that is passed in. If the object passed in is null or undefined it
		///     return false otherwise it returns one of the following values:<ul>
		///     <li><b>string</b>: If the object passed is a string</li>
		///     <li><b>number</b>: If the object passed is a number</li>
		///     <li><b>boolean</b>: If the object passed is a boolean value</li>
		///     <li><b>function</b>: If the object passed is a function reference</li>
		///     <li><b>object</b>: If the object passed is an object</li>
		///     <li><b>array</b>: If the object passed is an array</li>
		///     <li><b>regexp</b>: If the object passed is a regular expression</li>
		///     <li><b>element</b>: If the object passed is a DOM Element</li>
		///     <li><b>nodelist</b>: If the object passed is a DOM NodeList</li>
		///     <li><b>textnode</b>: If the object passed is a DOM text node and contains something other than whitespace</li>
		///     <li><b>whitespace</b>: If the object passed is a DOM text node and contains only whitespace</li>
		/// </summary>
		/// <returns>String</returns>
		public extern static void type();

		/// <summary>
		///     Returns the type of object that is passed in. If the object passed in is null or undefined it
		///     return false otherwise it returns one of the following values:<ul>
		///     <li><b>string</b>: If the object passed is a string</li>
		///     <li><b>number</b>: If the object passed is a number</li>
		///     <li><b>boolean</b>: If the object passed is a boolean value</li>
		///     <li><b>function</b>: If the object passed is a function reference</li>
		///     <li><b>object</b>: If the object passed is an object</li>
		///     <li><b>array</b>: If the object passed is an array</li>
		///     <li><b>regexp</b>: If the object passed is a regular expression</li>
		///     <li><b>element</b>: If the object passed is a DOM Element</li>
		///     <li><b>nodelist</b>: If the object passed is a DOM NodeList</li>
		///     <li><b>textnode</b>: If the object passed is a DOM text node and contains something other than whitespace</li>
		///     <li><b>whitespace</b>: If the object passed is a DOM text node and contains only whitespace</li>
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>String</returns>
		public extern static void type(object obj);

		/// <summary>Returns true if the passed value is null, undefined or an empty string (optional).</summary>
		/// <returns>Boolean</returns>
		public extern static void isEmpty();

		/// <summary>Returns true if the passed value is null, undefined or an empty string (optional).</summary>
		/// <param name="value">The value to test</param>
		/// <returns>Boolean</returns>
		public extern static void isEmpty(object value);

		/// <summary>Returns true if the passed value is null, undefined or an empty string (optional).</summary>
		/// <param name="value">The value to test</param>
		/// <param name="allowBlank">(optional) Pass true if an empty string is not considered empty</param>
		/// <returns>Boolean</returns>
		public extern static void isEmpty(object value, bool allowBlank);

		/// <summary>Returns true if the passed object is a JavaScript array, otherwise false.</summary>
		/// <returns>Boolean</returns>
		public extern static void isArray();

		/// <summary>Returns true if the passed object is a JavaScript array, otherwise false.</summary>
		/// <param name="The">object to test</param>
		/// <returns>Boolean</returns>
		public extern static void isArray(object The);

		/// <summary>Returns true if the passed object is a JavaScript date object, otherwise false.</summary>
		/// <returns>Boolean</returns>
		public extern static void isDate();

		/// <summary>Returns true if the passed object is a JavaScript date object, otherwise false.</summary>
		/// <param name="The">object to test</param>
		/// <returns>Boolean</returns>
		public extern static void isDate(object The);



	}
}
