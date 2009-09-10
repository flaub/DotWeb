using System;
using DotWeb.Client;

namespace Ext.state {
	/// <summary>
	///     /**
	///     Abstract base class for state provider implementations. This class provides methods
	///     for encoding and decoding <b>typed</b> variables including dates and defines the
	///     Provider interface.
	///     */
	///     Ext.state.Provider = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\state\Provider.js</jssource>
	public class Provider : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Provider() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Provider prototype { get { return S_<Provider>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Returns the current value for a key</summary>
		/// <returns>Mixed</returns>
		public virtual void get() { _(); }

		/// <summary>Returns the current value for a key</summary>
		/// <param name="name">The key name</param>
		/// <returns>Mixed</returns>
		public virtual void get(string name) { _(name); }

		/// <summary>Returns the current value for a key</summary>
		/// <param name="name">The key name</param>
		/// <param name="defaultValue">A default value to return if the key's value is not found</param>
		/// <returns>Mixed</returns>
		public virtual void get(string name, object defaultValue) { _(name, defaultValue); }

		/// <summary>Clears a value from the state</summary>
		/// <returns></returns>
		public virtual void clear() { _(); }

		/// <summary>Clears a value from the state</summary>
		/// <param name="name">The key name</param>
		/// <returns></returns>
		public virtual void clear(string name) { _(name); }

		/// <summary>Sets the value for a key</summary>
		/// <returns></returns>
		public virtual void set() { _(); }

		/// <summary>Sets the value for a key</summary>
		/// <param name="name">The key name</param>
		/// <returns></returns>
		public virtual void set(string name) { _(name); }

		/// <summary>Sets the value for a key</summary>
		/// <param name="name">The key name</param>
		/// <param name="value">The value to set</param>
		/// <returns></returns>
		public virtual void set(string name, object value) { _(name, value); }

		/// <summary>Decodes a string previously encoded with {@link #encodeValue}.</summary>
		/// <returns>Mixed</returns>
		public virtual void decodeValue() { _(); }

		/// <summary>Decodes a string previously encoded with {@link #encodeValue}.</summary>
		/// <param name="value">The value to decode</param>
		/// <returns>Mixed</returns>
		public virtual void decodeValue(string value) { _(value); }

		/// <summary>Encodes a value including type information.  Decode with {@link #decodeValue}.</summary>
		/// <returns>String</returns>
		public virtual void encodeValue() { _(); }

		/// <summary>Encodes a value including type information.  Decode with {@link #decodeValue}.</summary>
		/// <param name="value">The value to encode</param>
		/// <returns>String</returns>
		public virtual void encodeValue(object value) { _(value); }



	}

    public class ProviderEvents {
        /// <summary>Fires when a state change occurs.
        /// <pre><code>
        /// USAGE: ({Provider} objthis, {String} key, {String} value)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description>This state provider</description></item>
        /// <item><term><b>key</b></term><description>The state key which was changed</description></item>
        /// <item><term><b>value</b></term><description>The encoded value for the state</description></item>
        /// </list>
        /// </summary>
        public static string statechange { get { return "statechange"; } }
    }

    public delegate void ProviderStatechangeDelegate(Provider objthis, string key, string value);
}
