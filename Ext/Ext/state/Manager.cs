using System;
using H8.Support;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\state\StateManager.js</jssource>
    [Native]
    public class Manager  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public Manager() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Manager prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Configures the default state provider for your application</summary>
        /// <returns></returns>
        public static void setProvider() { return ; }

        /// <summary>Configures the default state provider for your application</summary>
        /// <param name="stateProvider">The state provider to set</param>
        /// <returns></returns>
        public static void setProvider(Provider stateProvider) { return ; }

        /// <summary>Returns the current value for a key</summary>
        /// <returns>Mixed</returns>
        public static object get() { return null; }

        /// <summary>Returns the current value for a key</summary>
        /// <param name="name">The key name</param>
        /// <returns>Mixed</returns>
        public static object get(System.String name) { return null; }

        /// <summary>Returns the current value for a key</summary>
        /// <param name="name">The key name</param>
        /// <param name="defaultValue">The default value to return if the key lookup does not match</param>
        /// <returns>Mixed</returns>
        public static object get(System.String name, object defaultValue) { return null; }

        /// <summary>Sets the value for a key</summary>
        /// <returns></returns>
        public static void set() { return ; }

        /// <summary>Sets the value for a key</summary>
        /// <param name="name">The key name</param>
        /// <returns></returns>
        public static void set(System.String name) { return ; }

        /// <summary>Sets the value for a key</summary>
        /// <param name="name">The key name</param>
        /// <param name="value">The state data</param>
        /// <returns></returns>
        public static void set(System.String name, object value) { return ; }

        /// <summary>Clears a value from the state</summary>
        /// <returns></returns>
        public static void clear() { return ; }

        /// <summary>Clears a value from the state</summary>
        /// <param name="name">The key name</param>
        /// <returns></returns>
        public static void clear(System.String name) { return ; }

        /// <summary>Gets the currently configured state provider</summary>
        /// <returns>Provider</returns>
        public static Provider getProvider() { return null; }



    }
    [Anonymous]
    public class ManagerConfig {

    }


}
