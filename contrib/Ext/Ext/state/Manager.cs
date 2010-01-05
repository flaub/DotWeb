using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.state {
	/// <summary>
	///     /**
	///     This is the global state manager. By default all components that are "state aware" check this class
	///     for state information if you don't pass them a custom state provider. In order for this class
	///     to be useful, it must be initialized with a provider when your application initializes. Example usage:
	///     <pre><code>
	///     // in your initialization function
	///     init : function(){
	///     Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
	///     var win = new Window(...);
	///     win.restoreState();
	///     }
	///     </code></pre>
	///     */
	///     Ext.state.Manager = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\state\StateManager.js</jssource>
	public class Manager : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern Manager();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Manager prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Configures the default state provider for your application</summary>
		/// <returns></returns>
		public extern static void setProvider();

		/// <summary>Configures the default state provider for your application</summary>
		/// <param name="stateProvider">The state provider to set</param>
		/// <returns></returns>
		public extern static void setProvider(Provider stateProvider);

		/// <summary>Returns the current value for a key</summary>
		/// <returns>Mixed</returns>
		public extern static void get();

		/// <summary>Returns the current value for a key</summary>
		/// <param name="name">The key name</param>
		/// <returns>Mixed</returns>
		public extern static void get(string name);

		/// <summary>Returns the current value for a key</summary>
		/// <param name="name">The key name</param>
		/// <param name="defaultValue">The default value to return if the key lookup does not match</param>
		/// <returns>Mixed</returns>
		public extern static void get(string name, object defaultValue);

		/// <summary>Sets the value for a key</summary>
		/// <returns></returns>
		public extern static void set();

		/// <summary>Sets the value for a key</summary>
		/// <param name="name">The key name</param>
		/// <returns></returns>
		public extern static void set(string name);

		/// <summary>Sets the value for a key</summary>
		/// <param name="name">The key name</param>
		/// <param name="value">The state data</param>
		/// <returns></returns>
		public extern static void set(string name, object value);

		/// <summary>Clears a value from the state</summary>
		/// <returns></returns>
		public extern static void clear();

		/// <summary>Clears a value from the state</summary>
		/// <param name="name">The key name</param>
		/// <returns></returns>
		public extern static void clear(string name);

		/// <summary>Gets the currently configured state provider</summary>
		/// <returns>Provider</returns>
		public extern static void getProvider();



	}
}
