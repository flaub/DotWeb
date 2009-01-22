using System;
using H8.Support;

namespace Ext.state {
    /// <summary>
    ///     /**
    ///     Abstract base class for state provider implementations. This class provides methods
    ///     for encoding and decoding <b>typed</b> variables including dates and defines the
    ///     Provider interface.
    ///     */
    ///     Ext.state.Provider = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\state\Provider.js</jssource>
    [Native]
    public class Provider  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public Provider() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Provider prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Returns the current value for a key</summary>
        /// <returns>Mixed</returns>
        public virtual object get() { return null; }

        /// <summary>Returns the current value for a key</summary>
        /// <param name="name">The key name</param>
        /// <returns>Mixed</returns>
        public virtual object get(System.String name) { return null; }

        /// <summary>Returns the current value for a key</summary>
        /// <param name="name">The key name</param>
        /// <param name="defaultValue">A default value to return if the key's value is not found</param>
        /// <returns>Mixed</returns>
        public virtual object get(System.String name, object defaultValue) { return null; }

        /// <summary>Clears a value from the state</summary>
        /// <returns></returns>
        public virtual void clear() { return ; }

        /// <summary>Clears a value from the state</summary>
        /// <param name="name">The key name</param>
        /// <returns></returns>
        public virtual void clear(System.String name) { return ; }

        /// <summary>Sets the value for a key</summary>
        /// <returns></returns>
        public virtual void set() { return ; }

        /// <summary>Sets the value for a key</summary>
        /// <param name="name">The key name</param>
        /// <returns></returns>
        public virtual void set(System.String name) { return ; }

        /// <summary>Sets the value for a key</summary>
        /// <param name="name">The key name</param>
        /// <param name="value">The value to set</param>
        /// <returns></returns>
        public virtual void set(System.String name, object value) { return ; }

        /// <summary>Decodes a string previously encoded with {@link #encodeValue}.</summary>
        /// <returns>Mixed</returns>
        public virtual object decodeValue() { return null; }

        /// <summary>Decodes a string previously encoded with {@link #encodeValue}.</summary>
        /// <param name="value">The value to decode</param>
        /// <returns>Mixed</returns>
        public virtual object decodeValue(System.String value) { return null; }

        /// <summary>Encodes a value including type information.  Decode with {@link #decodeValue}.</summary>
        /// <returns>String</returns>
        public virtual System.String encodeValue() { return null; }

        /// <summary>Encodes a value including type information.  Decode with {@link #decodeValue}.</summary>
        /// <param name="value">The value to encode</param>
        /// <returns>String</returns>
        public virtual System.String encodeValue(object value) { return null; }



    }
    [Anonymous]
    public class ProviderConfig {

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

    public delegate void ProviderStatechangeDelegate(Provider objthis, System.String key, System.String value);
}
