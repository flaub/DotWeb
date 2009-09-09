using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     History management component that allows you to register arbitrary tokens that signify application
	///     history state on navigation actions.  You can then handle the history {@link #change} event in order
	///     to reset your application UI to the appropriate state when the user navigates forward or backward through
	///     the browser history stack.
	///     */
	///     Ext.History = (function () {
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\util\History.js</jssource>
	public class History : Ext.util.Observable {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public History() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static History prototype { get { return S_<History>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.util.Observable superclass { get { return S_<Ext.util.Observable>(); } set { S_(value); } }

		/// <summary>The id of the hidden field required for storing the current history token.</summary>
		public static System.String fieldId { get { return S_<System.String>(); } set { S_(value); } }

		/// <summary>The id of the iframe required by IE to manage the history stack.</summary>
		public static System.String iframeId { get { return S_<System.String>(); } set { S_(value); } }


		/// <summary>
		///     Initialize the global History instance.
		///     component is fully initialized.
		/// </summary>
		/// <returns></returns>
		public static void init() { S_(); }

		/// <summary>
		///     Initialize the global History instance.
		///     component is fully initialized.
		/// </summary>
		/// <param name="onReady">(optional) A callback function that will be called once the history</param>
		/// <returns></returns>
		public static void init(bool onReady) { S_(onReady); }

		/// <summary>
		///     Initialize the global History instance.
		///     component is fully initialized.
		/// </summary>
		/// <param name="onReady">(optional) A callback function that will be called once the history</param>
		/// <param name="scope">(optional) The callback scope</param>
		/// <returns></returns>
		public static void init(bool onReady, object scope) { S_(onReady, scope); }

		/// <summary>
		///     Add a new token to the history stack. This can be any arbitrary value, although it would
		///     commonly be the concatenation of a component id and another id marking the specifc history
		///     state of that component.  Example usage:
		///     <pre><code>
		///     // Handle tab changes on a TabPanel
		///     tabPanel.on('tabchange', function(tabPanel, tab){
		///     Ext.History.add(tabPanel.id + ':' + tab.id);
		///     });
		///     </code></pre>
		///     it will not save a new history step. Set to false if the same state can be saved more than once
		///     at the same history stack location (defaults to true).
		/// </summary>
		/// <returns></returns>
		public static void add() { S_(); }

		/// <summary>
		///     Add a new token to the history stack. This can be any arbitrary value, although it would
		///     commonly be the concatenation of a component id and another id marking the specifc history
		///     state of that component.  Example usage:
		///     <pre><code>
		///     // Handle tab changes on a TabPanel
		///     tabPanel.on('tabchange', function(tabPanel, tab){
		///     Ext.History.add(tabPanel.id + ':' + tab.id);
		///     });
		///     </code></pre>
		///     it will not save a new history step. Set to false if the same state can be saved more than once
		///     at the same history stack location (defaults to true).
		/// </summary>
		/// <param name="token">The value that defines a particular application-specific history state</param>
		/// <returns></returns>
		public static void add(System.String token) { S_(token); }

		/// <summary>
		///     Add a new token to the history stack. This can be any arbitrary value, although it would
		///     commonly be the concatenation of a component id and another id marking the specifc history
		///     state of that component.  Example usage:
		///     <pre><code>
		///     // Handle tab changes on a TabPanel
		///     tabPanel.on('tabchange', function(tabPanel, tab){
		///     Ext.History.add(tabPanel.id + ':' + tab.id);
		///     });
		///     </code></pre>
		///     it will not save a new history step. Set to false if the same state can be saved more than once
		///     at the same history stack location (defaults to true).
		/// </summary>
		/// <param name="token">The value that defines a particular application-specific history state</param>
		/// <param name="preventDuplicates">When true, if the passed token matches the current token</param>
		/// <returns></returns>
		public static void add(System.String token, bool preventDuplicates) { S_(token, preventDuplicates); }

		/// <summary>Programmatically steps back one step in browser history (equivalent to the user pressing the Back button).</summary>
		/// <returns></returns>
		public static void back() { S_(); }

		/// <summary>Programmatically steps forward one step in browser history (equivalent to the user pressing the Forward button).</summary>
		/// <returns></returns>
		public static void forward() { S_(); }

		/// <summary>Retrieves the currently-active history token.</summary>
		/// <returns>String</returns>
		public static void getToken() { S_(); }



	}

	[JsAnonymous]
	public class HistoryConfig : DotWeb.Client.JsAccessible {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}
}
