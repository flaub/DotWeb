using System;
using System.DotWeb;
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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\History.js</jssource>
	public class History : Ext.util.Observable {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern History();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static History prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>The id of the hidden field required for storing the current history token.</summary>
		public extern static string fieldId { get; set; }

		/// <summary>The id of the iframe required by IE to manage the history stack.</summary>
		public extern static string iframeId { get; set; }


		/// <summary>
		///     Initialize the global History instance.
		///     component is fully initialized.
		/// </summary>
		/// <returns></returns>
		public extern static void init();

		/// <summary>
		///     Initialize the global History instance.
		///     component is fully initialized.
		/// </summary>
		/// <param name="onReady">(optional) A callback function that will be called once the history</param>
		/// <returns></returns>
		public extern static void init(bool onReady);

		/// <summary>
		///     Initialize the global History instance.
		///     component is fully initialized.
		/// </summary>
		/// <param name="onReady">(optional) A callback function that will be called once the history</param>
		/// <param name="scope">(optional) The callback scope</param>
		/// <returns></returns>
		public extern static void init(bool onReady, object scope);

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
		public extern static void add();

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
		public extern static void add(string token);

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
		public extern static void add(string token, bool preventDuplicates);

		/// <summary>Programmatically steps back one step in browser history (equivalent to the user pressing the Back button).</summary>
		/// <returns></returns>
		public extern static void back();

		/// <summary>Programmatically steps forward one step in browser history (equivalent to the user pressing the Forward button).</summary>
		/// <returns></returns>
		public extern static void forward();

		/// <summary>Retrieves the currently-active history token.</summary>
		/// <returns>String</returns>
		public extern static void getToken();



	}

	[JsAnonymous]
	public class HistoryConfig : System.DotWeb.JsDynamic {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}
}
