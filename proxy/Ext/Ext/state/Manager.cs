using System;
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
	public class Manager : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Manager() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Manager prototype { get { return S_<Manager>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Configures the default state provider for your application</summary>
		/// <returns></returns>
		public static void setProvider() { S_(); }

		/// <summary>Configures the default state provider for your application</summary>
		/// <param name="stateProvider">The state provider to set</param>
		/// <returns></returns>
		public static void setProvider(Provider stateProvider) { S_(stateProvider); }

		/// <summary>Returns the current value for a key</summary>
		/// <returns>Mixed</returns>
		public static void get() { S_(); }

		/// <summary>Returns the current value for a key</summary>
		/// <param name="name">The key name</param>
		/// <returns>Mixed</returns>
		public static void get(string name) { S_(name); }

		/// <summary>Returns the current value for a key</summary>
		/// <param name="name">The key name</param>
		/// <param name="defaultValue">The default value to return if the key lookup does not match</param>
		/// <returns>Mixed</returns>
		public static void get(string name, object defaultValue) { S_(name, defaultValue); }

		/// <summary>Sets the value for a key</summary>
		/// <returns></returns>
		public static void set() { S_(); }

		/// <summary>Sets the value for a key</summary>
		/// <param name="name">The key name</param>
		/// <returns></returns>
		public static void set(string name) { S_(name); }

		/// <summary>Sets the value for a key</summary>
		/// <param name="name">The key name</param>
		/// <param name="value">The state data</param>
		/// <returns></returns>
		public static void set(string name, object value) { S_(name, value); }

		/// <summary>Clears a value from the state</summary>
		/// <returns></returns>
		public static void clear() { S_(); }

		/// <summary>Clears a value from the state</summary>
		/// <param name="name">The key name</param>
		/// <returns></returns>
		public static void clear(string name) { S_(name); }

		/// <summary>Gets the currently configured state provider</summary>
		/// <returns>Provider</returns>
		public static void getProvider() { S_(); }



	}
}
