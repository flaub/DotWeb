using System;
using DotWeb.Core;

namespace Ext {
    /// <summary>
    ///     /**
    ///     Ext core utilities and functions.
    ///     */
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\core\Ext.js</jssource>
    [Native]
    public class ExtClass  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public ExtClass() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static ExtClass prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>True if the browser is in strict (standards-compliant) mode, as opposed to quirks mode</summary>
        public static bool isStrict { get { return false; } set { } }

        /// <summary>True if the page is running over SSL</summary>
        public static bool isSecure { get { return false; } set { } }

        /// <summary>True when the document is fully initialized and ready for action</summary>
        public static bool isReady { get { return false; } set { } }

        /// <summary>True to automatically uncache orphaned Ext.Elements periodically (defaults to true)</summary>
        public static bool enableGarbageCollector { get { return false; } set { } }

        /// <summary>
        ///     True to automatically purge event listeners after uncaching an element (defaults to false).
        ///     Note: this only happens if enableGarbageCollector is true.
        /// </summary>
        public static bool enableListenerCollection { get { return false; } set { } }

        /// <summary>
        ///     URL to a blank file used by Ext when in secure mode for iframe src and onReady src to prevent
        ///     the IE insecure content warning (defaults to javascript:false).
        /// </summary>
        public static System.String SSL_SECURE_URL { get { return null; } set { } }

        /// <summary>
        ///     URL to a 1x1 transparent gif image used by Ext to create inline icons with CSS background images. (Defaults to
        ///     "http://extjs.com/s.gif" and you should change this to a URL on your server).
        /// </summary>
        public static System.String BLANK_IMAGE_URL { get { return null; } set { } }

        /// <summary>True if the detected browser is Opera.</summary>
        public static bool isOpera { get { return false; } set { } }

        /// <summary>True if the detected browser is Safari.</summary>
        public static bool isSafari { get { return false; } set { } }

        /// <summary>True if the detected browser is Safari 3.x.</summary>
        public static bool isSafari3 { get { return false; } set { } }

        /// <summary>True if the detected browser is Safari 2.x.</summary>
        public static bool isSafari2 { get { return false; } set { } }

        /// <summary>True if the detected browser is Internet Explorer.</summary>
        public static bool isIE { get { return false; } set { } }

        /// <summary>True if the detected browser is Internet Explorer 6.x.</summary>
        public static bool isIE6 { get { return false; } set { } }

        /// <summary>True if the detected browser is Internet Explorer 7.x.</summary>
        public static bool isIE7 { get { return false; } set { } }

        /// <summary>True if the detected browser uses the Gecko layout engine (e.g. Mozilla, Firefox).</summary>
        public static bool isGecko { get { return false; } set { } }

        /// <summary>True if the detected browser uses a pre-Gecko 1.9 layout engine (e.g. Firefox 2.x).</summary>
        public static bool isGecko2 { get { return false; } set { } }

        /// <summary>True if the detected browser uses a Gecko 1.9+ layout engine (e.g. Firefox 3.x).</summary>
        public static bool isGecko3 { get { return false; } set { } }

        /// <summary>True if the detected browser is Internet Explorer running in non-strict mode.</summary>
        public static bool isBorderBox { get { return false; } set { } }

        /// <summary>True if the detected platform is Linux.</summary>
        public static bool isLinux { get { return false; } set { } }

        /// <summary>True if the detected platform is Windows.</summary>
        public static bool isWindows { get { return false; } set { } }

        /// <summary>True if the detected platform is Mac OS.</summary>
        public static bool isMac { get { return false; } set { } }

        /// <summary>True if the detected platform is Adobe Air.</summary>
        public static bool isAir { get { return false; } set { } }

        /// <summary>
        ///     By default, Ext intelligently decides whether floating elements should be shimmed. If you are using flash,
        ///     you may want to set this to true.
        /// </summary>
        public static bool useShims { get { return false; } set { } }


        /// <summary>
        ///     A reusable empty function
        ///     @property
        ///     @type Function
        /// </summary>
        /// <returns></returns>
        public static void emptyFn() { return ; }

        /// <summary>Copies all the properties of config to obj if they don't already exist.</summary>
        /// <returns>Object</returns>
        public static object applyIf() { return null; }

        /// <summary>Copies all the properties of config to obj if they don't already exist.</summary>
        /// <param name="obj">The receiver of the properties</param>
        /// <returns>Object</returns>
        public static object applyIf(object obj) { return null; }

        /// <summary>Copies all the properties of config to obj if they don't already exist.</summary>
        /// <param name="obj">The receiver of the properties</param>
        /// <param name="config">The source of the properties</param>
        /// <returns>Object</returns>
        public static object applyIf(object obj, object config) { return null; }

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
        public static void addBehaviors() { return ; }

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
        public static void addBehaviors(object obj) { return ; }

        /// <summary>Generates unique ids. If the element already has an id, it is unchanged</summary>
        /// <returns>String</returns>
        public static System.String id() { return null; }

        /// <summary>Generates unique ids. If the element already has an id, it is unchanged</summary>
        /// <param name="el">(optional) The element to generate an id for</param>
        /// <returns>String</returns>
        public static System.String id(object el) { return null; }

        /// <summary>Generates unique ids. If the element already has an id, it is unchanged</summary>
        /// <param name="el">(optional) The element to generate an id for</param>
        /// <param name="prefix">(optional) Id prefix (defaults "ext-gen")</param>
        /// <returns>String</returns>
        public static System.String id(object el, System.String prefix) { return null; }

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
        public static Delegate extend() { return null; }

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
        public static Delegate extend(Delegate subclass) { return null; }

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
        public static Delegate extend(Delegate subclass, Delegate superclass) { return null; }

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
        public static Delegate extend(Delegate subclass, Delegate superclass, object overrides) { return null; }

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
        public static void override_() { return ; }

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
        public static void override_(object origclass) { return ; }

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
        public static void override_(object origclass, object overrides) { return ; }

        /// <summary>
        ///     Creates namespaces to be used for scoping variables and classes so that they are not global.  Usage:
        ///     <pre><code>
        ///     Ext.namespace('Company', 'Company.data');
        ///     Company.Widget = function() { ... }
        ///     Company.data.CustomStore = function(config) { ... }
        ///     </code></pre>
        /// </summary>
        /// <returns></returns>
        public static void namespace_() { return ; }

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
        public static void namespace_(params System.String[] args) { return ; }

        /// <summary>Takes an object and converts it to an encoded URL. e.g. Ext.urlEncode({foo: 1, bar: 2}); would return "foo=1&bar=2".  Optionally, property values can be arrays, instead of keys and the resulting string that's returned will contain a name/value pair for each array value.</summary>
        /// <returns>String</returns>
        public static System.String urlEncode() { return null; }

        /// <summary>Takes an object and converts it to an encoded URL. e.g. Ext.urlEncode({foo: 1, bar: 2}); would return "foo=1&bar=2".  Optionally, property values can be arrays, instead of keys and the resulting string that's returned will contain a name/value pair for each array value.</summary>
        /// <param name="o"></param>
        /// <returns>String</returns>
        public static System.String urlEncode(object o) { return null; }

        /// <summary>Takes an encoded URL and and converts it to an object. e.g. Ext.urlDecode("foo=1&bar=2"); would return {foo: 1, bar: 2} or Ext.urlDecode("foo=1&bar=2&bar=3&bar=4", true); would return {foo: 1, bar: [2, 3, 4]}.</summary>
        /// <returns>Object</returns>
        public static object urlDecode() { return null; }

        /// <summary>Takes an encoded URL and and converts it to an object. e.g. Ext.urlDecode("foo=1&bar=2"); would return {foo: 1, bar: 2} or Ext.urlDecode("foo=1&bar=2&bar=3&bar=4", true); would return {foo: 1, bar: [2, 3, 4]}.</summary>
        /// <param name="str"></param>
        /// <returns>Object</returns>
        public static object urlDecode(System.String str) { return null; }

        /// <summary>Takes an encoded URL and and converts it to an object. e.g. Ext.urlDecode("foo=1&bar=2"); would return {foo: 1, bar: 2} or Ext.urlDecode("foo=1&bar=2&bar=3&bar=4", true); would return {foo: 1, bar: [2, 3, 4]}.</summary>
        /// <param name="str"></param>
        /// <param name="overwrite">(optional) Items of the same name will overwrite previous values instead of creating an an array (Defaults to false).</param>
        /// <returns>Object</returns>
        public static object urlDecode(System.String str, bool overwrite) { return null; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <returns></returns>
        public static void each() { return ; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void each(System.Array array) { return ; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <param name="array"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static void each(System.Array array, Delegate fn) { return ; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <param name="array"></param>
        /// <param name="fn"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static void each(System.Array array, Delegate fn, object scope) { return ; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void each(object array) { return ; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <param name="array"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static void each(object array, Delegate fn) { return ; }

        /// <summary>
        ///     Iterates an array calling the passed function with each item, stopping if your function returns false. If the
        ///     passed array is not really an array, your function is called once with it.
        ///     The supplied function is called with (Object item, Number index, Array allItems).
        /// </summary>
        /// <param name="array"></param>
        /// <param name="fn"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static void each(object array, Delegate fn, object scope) { return ; }

        /// <summary>Escapes the passed string for use in a regular expression</summary>
        /// <returns>String</returns>
        public static System.String escapeRe() { return null; }

        /// <summary>Escapes the passed string for use in a regular expression</summary>
        /// <param name="str"></param>
        /// <returns>String</returns>
        public static System.String escapeRe(System.String str) { return null; }

        /// <summary>Return the dom node for the passed string (id), dom node, or Ext.Element</summary>
        /// <returns>HTMLElement</returns>
        public static DOMElement getDom() { return null; }

        /// <summary>Return the dom node for the passed string (id), dom node, or Ext.Element</summary>
        /// <param name="el"></param>
        /// <returns>HTMLElement</returns>
        public static DOMElement getDom(object el) { return null; }

        /// <summary>Returns the current HTML document object as an {@link Ext.Element}.</summary>
        /// <returns>Ext.Element</returns>
        public static Ext.Element getDoc() { return null; }

        /// <summary>Returns the current document body as an {@link Ext.Element}.</summary>
        /// <returns>Ext.Element</returns>
        public static Ext.Element getBody() { return null; }

        /// <summary>Shorthand for {@link Ext.ComponentMgr#get}</summary>
        /// <returns>Ext.Component</returns>
        public static Ext.Component getCmp() { return null; }

        /// <summary>Shorthand for {@link Ext.ComponentMgr#get}</summary>
        /// <param name="id"></param>
        /// <returns>Ext.Component</returns>
        public static Ext.Component getCmp(System.String id) { return null; }

        /// <summary>Utility method for validating that a value is numeric, returning the specified default value if it is not.</summary>
        /// <returns>Number</returns>
        public static double num() { return 0; }

        /// <summary>Utility method for validating that a value is numeric, returning the specified default value if it is not.</summary>
        /// <param name="value">Should be a number, but any type will be handled appropriately</param>
        /// <returns>Number</returns>
        public static double num(object value) { return 0; }

        /// <summary>Utility method for validating that a value is numeric, returning the specified default value if it is not.</summary>
        /// <param name="value">Should be a number, but any type will be handled appropriately</param>
        /// <param name="defaultValue">The value to return if the original value is non-numeric</param>
        /// <returns>Number</returns>
        public static double num(object value, double defaultValue) { return 0; }

        /// <summary>
        ///     Attempts to destroy any objects passed to it by removing all event listeners, removing them from the
        ///     DOM (if applicable) and calling their destroy functions (if available).  This method is primarily
        ///     intended for arguments of type {@link Ext.Element} and {@link Ext.Component}, but any subclass of
        ///     {@link Ext.util.Observable} can be passed in.  Any number of elements and/or components can be
        ///     passed into this function in a single call as separate arguments.
        /// </summary>
        /// <returns></returns>
        public static void destroy() { return ; }

        /// <summary>
        ///     Attempts to destroy any objects passed to it by removing all event listeners, removing them from the
        ///     DOM (if applicable) and calling their destroy functions (if available).  This method is primarily
        ///     intended for arguments of type {@link Ext.Element} and {@link Ext.Component}, but any subclass of
        ///     {@link Ext.util.Observable} can be passed in.  Any number of elements and/or components can be
        ///     passed into this function in a single call as separate arguments.
        /// </summary>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void destroy(params object[] args) { return ; }

        /// <summary>Removes a DOM node from the document.  The body node will be ignored if passed in.</summary>
        /// <returns></returns>
        public static void removeNode() { return ; }

        /// <summary>Removes a DOM node from the document.  The body node will be ignored if passed in.</summary>
        /// <param name="node">The node to remove</param>
        /// <returns></returns>
        public static void removeNode(DOMElement node) { return ; }

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
        public static System.String type() { return null; }

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
        public static System.String type(object obj) { return null; }

        /// <summary>Returns true if the passed value is null, undefined or an empty string (optional).</summary>
        /// <returns>Boolean</returns>
        public static bool isEmpty() { return false; }

        /// <summary>Returns true if the passed value is null, undefined or an empty string (optional).</summary>
        /// <param name="value">The value to test</param>
        /// <returns>Boolean</returns>
        public static bool isEmpty(object value) { return false; }

        /// <summary>Returns true if the passed value is null, undefined or an empty string (optional).</summary>
        /// <param name="value">The value to test</param>
        /// <param name="allowBlank">(optional) Pass true if an empty string is not considered empty</param>
        /// <returns>Boolean</returns>
        public static bool isEmpty(object value, bool allowBlank) { return false; }

        /// <summary>Returns true if the passed object is a JavaScript array, otherwise false.</summary>
        /// <returns>Boolean</returns>
        public static bool isArray() { return false; }

        /// <summary>Returns true if the passed object is a JavaScript array, otherwise false.</summary>
        /// <param name="The">object to test</param>
        /// <returns>Boolean</returns>
        public static bool isArray(object The) { return false; }

        /// <summary>Returns true if the passed object is a JavaScript date object, otherwise false.</summary>
        /// <returns>Boolean</returns>
        public static bool isDate() { return false; }

        /// <summary>Returns true if the passed object is a JavaScript date object, otherwise false.</summary>
        /// <param name="The">object to test</param>
        /// <returns>Boolean</returns>
        public static bool isDate(object The) { return false; }


        /// <summary></summary>
        /// <param name="fn">The method the event invokes</param>
        /// <returns></returns>
        public static void onReady(Delegate fn) { return; }

        /// <summary></summary>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">An  object that becomes the scope of the handler</param>
        /// <returns></returns>
        public static void onReady(Delegate fn, object scope) { return; }

        /// <summary></summary>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">An  object that becomes the scope of the handler</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static void onReady(Delegate fn, object scope, bool options) { return; }

        /// <summary></summary>
        /// <param name="el">The id of the node, a DOM Node or an existing Element.</param>
        /// <returns>Element</returns>
        public static Element get(string el) { return null;}

        /// <summary></summary>
        /// <param name="el">The id of the node, a DOM Node or an existing Element.</param>
        /// <returns>Element</returns>
        public static Element get(DOMElement el) { return null;}

        /// <summary></summary>
        /// <param name="el">The id of the node, a DOM Node or an existing Element.</param>
        /// <returns>Element</returns>
        public static Element get(Element el) { return null;}

        /// <summary></summary>
        /// <param name="el">The dom node or id</param>
        /// <returns>Element</returns>
        public static Element fly(string el) { return null;}

        /// <summary></summary>
        /// <param name="el">The dom node or id</param>
        /// <param name="named">(optional) Allows for creation of named reusable flyweights to</param>
        /// <returns>Element</returns>
        public static Element fly(string el, string named) { return null;}

        /// <summary></summary>
        /// <param name="el">The dom node or id</param>
        /// <returns>Element</returns>
        public static Element fly(DOMElement el) { return null;}
        
        /// <summary></summary>
        /// <param name="el">The dom node or id</param>
        /// <param name="named">(optional) Allows for creation of named reusable flyweights to</param>
        /// <returns>Element</returns>
        public static Element fly(DOMElement el, string named) { return null;}

        /// <summary></summary>
        /// <param name="obj">The receiver of the properties</param>
        /// <param name="config">The source of the properties</param>
        /// <param name="defaults">A different object that will also be applied for default values</param>        
        /// <returns>object</returns>
        public static object apply(object obj, object config, object defaults) { return null ; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(String selector) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(String selector, bool unique) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <param name="root">(optional) The root element of the query or id of the root</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(String selector, bool unique, String root) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <param name="root">(optional) The root element of the query or id of the root</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(String selector, bool unique, DOMElement root) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(Array selector) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(Array selector, bool unique) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <param name="root">(optional) The root element of the query or id of the root</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(Array selector, bool unique, String root) { return null; }

        /// <summary>Selects elements based on the passed CSS selector to enable working on them as 1.</summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <param name="root">(optional) The root element of the query or id of the root</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public static Ext.CompositeElement select(Array selector, bool unique, DOMElement root) { return null; }

    }
    [Anonymous]
    public class ExtConfig {

    }


}
