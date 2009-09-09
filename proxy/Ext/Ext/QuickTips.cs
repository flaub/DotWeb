using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Provides attractive and customizable tooltips for any element. The QuickTips
	///     singleton is used to configure and manage tooltips globally for multiple elements
	///     in a generic manner.  To create individual tooltips with maximum customizability,
	///     you should consider either {@link Ext.Tip} or {@link Ext.ToolTip}.</p>
	///     <p>Quicktips can be configured via tag attributes directly in markup, or by
	///     registering quick tips programmatically via the {@link #register} method.</p>
	///     <p>The singleton's instance of {@link Ext.QuickTip} is available via
	///     {@link #getQuickTip}, and supports all the methods, and all the all the
	///     configuration properties of Ext.QuickTip. These settings will apply to all
	///     tooltips shown by the singleton.</p>
	///     <p>Below is the summary of the configuration properties which can be used.
	///     For detailed descriptions see {@link #getQuickTip}</p>
	///     <p><b>QuickTips singleton configs (all are optional)</b></p>
	///     <div class="mdetail-params"><ul><li>dismissDelay</li>
	///     <li>hideDelay</li>
	///     <li>maxWidth</li>
	///     <li>minWidth</li>
	///     <li>showDelay</li>
	///     <li>trackMouse</li></ul></div>
	///     <p><b>Target element configs (optional unless otherwise noted)</b></p>
	///     <div class="mdetail-params"><ul><li>autoHide</li>
	///     <li>cls</li>
	///     <li>dismissDelay (overrides singleton value)</li>
	///     <li>target (required)</li>
	///     <li>text (required)</li>
	///     <li>title</li>
	///     <li>width</li></ul></div>
	///     <p>Here is an example showing how some of these config options could be used:</p>
	///     <pre><code>
	///     // Init the singleton.  Any tag-based quick tips will start working.
	///     Ext.QuickTips.init();
	///     // Apply a set of config properties to the singleton
	///     Ext.apply(Ext.QuickTips.getQuickTip(), {
	///     maxWidth: 200,
	///     minWidth: 100,
	///     showDelay: 50,
	///     trackMouse: true
	///     });
	///     // Manually register a quick tip for a specific element
	///     q.register({
	///     target: 'my-div',
	///     title: 'My Tooltip',
	///     text: 'This tooltip was added in code',
	///     width: 100,
	///     dismissDelay: 20
	///     });
	///     </code></pre>
	///     <p>To register a quick tip in markup, you simply add one or more of the valid QuickTip attributes prefixed with
	///     the <b>ext:</b> namespace.  The HTML element itself is automatically set as the quick tip target. Here is the summary
	///     of supported attributes (optional unless otherwise noted):</p>
	///     <ul><li><b>hide</b>: Specifying "user" is equivalent to setting autoHide = false.  Any other value will be the
	///     same as autoHide = true.</li>
	///     <li><b>qclass</b>: A CSS class to be applied to the quick tip (equivalent to the 'cls' target element config).</li>
	///     <li><b>qtip (required)</b>: The quick tip text (equivalent to the 'text' target element config).</li>
	///     <li><b>qtitle</b>: The quick tip title (equivalent to the 'title' target element config).</li>
	///     <li><b>qwidth</b>: The quick tip width (equivalent to the 'width' target element config).</li></ul>
	///     <p>Here is an example of configuring an HTML element to display a tooltip from markup:</p>
	///     <pre><code>
	///     // Add a quick tip to an HTML button
	///     &lt;input type="button" value="OK" ext:qtitle="OK Button" ext:qwidth="100"
	///     ext:qtip="This is a quick tip from markup!">&lt;/input>
	///     </code></pre>
	///     */
	///     Ext.QuickTips = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\tips\QuickTips.js</jssource>
	public class QuickTips : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public QuickTips() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static QuickTips prototype { get { return S_<QuickTips>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Initialize the global QuickTips instance and prepare any quick tips.</summary>
		/// <returns></returns>
		public static void init() { S_(); }

		/// <summary>Initialize the global QuickTips instance and prepare any quick tips.</summary>
		/// <param name="autoRender">True to render the QuickTips container immediately to preload images. (Defaults to true)</param>
		/// <returns></returns>
		public static void init(bool autoRender) { S_(autoRender); }

		/// <summary>Enable quick tips globally.</summary>
		/// <returns></returns>
		public static void enable() { S_(); }

		/// <summary>Disable quick tips globally.</summary>
		/// <returns></returns>
		public static void disable() { S_(); }

		/// <summary>Returns true if quick tips are enabled, else false.</summary>
		/// <returns>Boolean</returns>
		public static void isEnabled() { S_(); }

		/// <summary>Gets the global QuickTips instance.</summary>
		/// <returns></returns>
		public static void getQuickTip() { S_(); }

		/// <summary>
		///     Configures a new quick tip instance and assigns it to a target element.  See
		///     {@link Ext.QuickTip#register} for details.
		/// </summary>
		/// <returns></returns>
		public static void register() { S_(); }

		/// <summary>
		///     Configures a new quick tip instance and assigns it to a target element.  See
		///     {@link Ext.QuickTip#register} for details.
		/// </summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public static void register(object config) { S_(config); }

		/// <summary>Removes any registered quick tip from the target element and destroys it.</summary>
		/// <returns></returns>
		public static void unregister() { S_(); }

		/// <summary>Removes any registered quick tip from the target element and destroys it.</summary>
		/// <param name="el">The element from which the quick tip is to be removed.</param>
		/// <returns></returns>
		public static void unregister(System.String el) { S_(el); }

		/// <summary>Removes any registered quick tip from the target element and destroys it.</summary>
		/// <param name="el">The element from which the quick tip is to be removed.</param>
		/// <returns></returns>
		public static void unregister(DOMElement el) { S_(el); }

		/// <summary>Removes any registered quick tip from the target element and destroys it.</summary>
		/// <param name="el">The element from which the quick tip is to be removed.</param>
		/// <returns></returns>
		public static void unregister(Element el) { S_(el); }

		/// <summary>Alias of {@link #register}.</summary>
		/// <returns></returns>
		public static void tips() { S_(); }

		/// <summary>Alias of {@link #register}.</summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public static void tips(object config) { S_(config); }



	}
}
