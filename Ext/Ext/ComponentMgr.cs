using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     <p>Provides a registry of all Components (specifically subclasses of
    ///     {@link Ext.Component}) on a page so that they can be easily accessed by
    ///     component id (see {@link Ext.getCmp}).</p>
    ///     <p>This object also provides a registry of available Component <i>classes</i>
    ///     indexed by a mnemonic code known as the Component's {@link Ext.Component#xtype}.
    ///     The <tt>xtype</tt> provides a way to avoid instantiating child Components
    ///     when creating a full, nested config object for a complete Ext page.</p>
    ///     <p>
    ///     A child Component may be specified simply as a <i>config object</i>
    ///     as long as the correct xtype is specified so that if and when the Component
    ///     needs rendering, the correct type can be looked up for lazy instantiation.</p>
    ///     <p>For a list of all available xtypes, see {@link Ext.Component}.</p>
    ///     */
    ///     Ext.ComponentMgr = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\ComponentMgr.js</jssource>
    [Native]
    public class ComponentMgr  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public ComponentMgr() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static ComponentMgr prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>
        ///     The MixedCollection used internally for the component cache. An example usage may be subscribing to
        ///     events on the MixedCollection to monitor addition or removal.  Read-only.
        /// </summary>
        public static Ext.util.MixedCollection all { get { return null; } set { } }


        /// <summary>Registers a component.</summary>
        /// <returns></returns>
        public static void register() { return ; }

        /// <summary>Registers a component.</summary>
        /// <param name="c">The component</param>
        /// <returns></returns>
        public static void register(Ext.Component c) { return ; }

        /// <summary>Unregisters a component.</summary>
        /// <returns></returns>
        public static void unregister() { return ; }

        /// <summary>Unregisters a component.</summary>
        /// <param name="c">The component</param>
        /// <returns></returns>
        public static void unregister(Ext.Component c) { return ; }

        /// <summary>Returns a component by id</summary>
        /// <returns>Ext.Component</returns>
        public static Ext.Component get() { return null; }

        /// <summary>Returns a component by id</summary>
        /// <param name="id">The component id</param>
        /// <returns>Ext.Component</returns>
        public static Ext.Component get(System.String id) { return null; }

        /// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
        /// <returns></returns>
        public static void onAvailable() { return ; }

        /// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
        /// <param name="id">The component id</param>
        /// <returns></returns>
        public static void onAvailable(System.String id) { return ; }

        /// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
        /// <param name="id">The component id</param>
        /// <param name="fn">The callback function</param>
        /// <returns></returns>
        public static void onAvailable(System.String id, Delegate fn) { return ; }

        /// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
        /// <param name="id">The component id</param>
        /// <param name="fn">The callback function</param>
        /// <param name="scope">The scope of the callback</param>
        /// <returns></returns>
        public static void onAvailable(System.String id, Delegate fn, object scope) { return ; }

        /// <summary>
        ///     <p>Registers a new Component constructor, keyed by a new
        ///     {@link Ext.Component#xtype}.</p>
        ///     <p>Use this method to register new subclasses of {@link Ext.Component} so
        ///     that lazy instantiation may be used when specifying child Components.
        ///     see {@link Ext.Container#items}</p>
        ///     may be looked up.
        /// </summary>
        /// <returns></returns>
        public static void registerType() { return ; }

        /// <summary>
        ///     <p>Registers a new Component constructor, keyed by a new
        ///     {@link Ext.Component#xtype}.</p>
        ///     <p>Use this method to register new subclasses of {@link Ext.Component} so
        ///     that lazy instantiation may be used when specifying child Components.
        ///     see {@link Ext.Container#items}</p>
        ///     may be looked up.
        /// </summary>
        /// <param name="xtype">The mnemonic string by which the Component class</param>
        /// <returns></returns>
        public static void registerType(System.String xtype) { return ; }

        /// <summary>
        ///     <p>Registers a new Component constructor, keyed by a new
        ///     {@link Ext.Component#xtype}.</p>
        ///     <p>Use this method to register new subclasses of {@link Ext.Component} so
        ///     that lazy instantiation may be used when specifying child Components.
        ///     see {@link Ext.Container#items}</p>
        ///     may be looked up.
        /// </summary>
        /// <param name="xtype">The mnemonic string by which the Component class</param>
        /// <param name="cls">The new Component class.</param>
        /// <returns></returns>
        public static void registerType(System.String xtype, Delegate cls) { return ; }

        /// <summary>
        ///     Creates a new Component from the specified config object using the
        ///     config object's {@link Ext.component#xtype xtype} to determine the class to instantiate.
        ///     the config object does not contain an xtype. (Optional if the config contains an xtype).
        /// </summary>
        /// <returns></returns>
        public static void create() { return ; }

        /// <summary>
        ///     Creates a new Component from the specified config object using the
        ///     config object's {@link Ext.component#xtype xtype} to determine the class to instantiate.
        ///     the config object does not contain an xtype. (Optional if the config contains an xtype).
        /// </summary>
        /// <param name="config">{Object} A configuration object for the Component you wish to create.</param>
        /// <returns></returns>
        public static void create(object config) { return ; }

        /// <summary>
        ///     Creates a new Component from the specified config object using the
        ///     config object's {@link Ext.component#xtype xtype} to determine the class to instantiate.
        ///     the config object does not contain an xtype. (Optional if the config contains an xtype).
        /// </summary>
        /// <param name="config">{Object} A configuration object for the Component you wish to create.</param>
        /// <param name="defaultType">{Constructor} The constructor to provide the default Component type if</param>
        /// <returns></returns>
        public static void create(object config, object defaultType) { return ; }



    }
    [Anonymous]
    public class ComponentMgrConfig {

    }


}
