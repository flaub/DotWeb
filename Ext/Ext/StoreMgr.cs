using System;
using DotWeb.Core;

namespace Ext {
    /// <summary>
    ///     /**
    ///     The default global group of stores.
    ///     */
    ///     Ext.StoreMgr = Ext.apply(new Ext.util.MixedCollection(), {
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\data\StoreMgr.js</jssource>
    public class StoreMgr : Ext.util.MixedCollection {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public StoreMgr() {}
        /// <summary>
        ///     collection (defaults to false)
        ///     and return the key value for that item.  This is used when available to look up the key on items that
        ///     were passed without an explicit key parameter to a MixedCollection method.  Passing this parameter is
        ///     equivalent to providing an implementation for the {@link #getKey} method.
        /// </summary>
        /// <param name="allowFunctions">True if the addAll function should add function references to the</param>
        /// <returns></returns>
        public StoreMgr(bool allowFunctions) {}
        /// <summary>
        ///     collection (defaults to false)
        ///     and return the key value for that item.  This is used when available to look up the key on items that
        ///     were passed without an explicit key parameter to a MixedCollection method.  Passing this parameter is
        ///     equivalent to providing an implementation for the {@link #getKey} method.
        /// </summary>
        /// <param name="allowFunctions">True if the addAll function should add function references to the</param>
        /// <param name="keyFn">A function that can accept an item of the type(s) stored in this MixedCollection</param>
        /// <returns></returns>
        public StoreMgr(bool allowFunctions, Delegate keyFn) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static StoreMgr prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.util.MixedCollection superclass { get { return null; } set { } }


        /// <summary>
        ///     Registers one or more Stores with the StoreMgr. You do not normally need to register stores
        ///     manually.  Any store initialized with a {@link Ext.data.Store#storeId} will be auto-registered.
        /// </summary>
        /// <returns></returns>
        public static void register() { return ; }

        /// <summary>
        ///     Registers one or more Stores with the StoreMgr. You do not normally need to register stores
        ///     manually.  Any store initialized with a {@link Ext.data.Store#storeId} will be auto-registered.
        /// </summary>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void register(params Ext.data.Store[] args) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <returns></returns>
        public static void unregister() { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void unregister(params System.String[] args) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <returns></returns>
        public static void unregister(object id1) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void unregister(object id1, params System.String[] args) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <returns></returns>
        public static void unregister(System.String id1, object id2) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void unregister(System.String id1, object id2, params System.String[] args) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <returns></returns>
        public static void unregister(object id1, object id2) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void unregister(object id1, object id2, params System.String[] args) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <returns></returns>
        public static void unregister(System.String id1, System.String id2) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void unregister(System.String id1, System.String id2, params object[] args) { return ; }

        /// <summary>Unregisters one or more Stores with the StoreMgr</summary>
        /// <param name="id1">The id of the Store, or a Store instance</param>
        /// <param name="id2">(optional)</param>
        /// <param name="args">(optional)</param>
        /// <returns></returns>
        public static void unregister(object id1, System.String id2, params object[] args) { return ; }

        /// <summary>Gets a registered Store by id</summary>
        /// <returns>Ext.data.Store</returns>
        public static Ext.data.Store lookup() { return null; }

        /// <summary>Gets a registered Store by id</summary>
        /// <param name="id">The id of the Store, or a Store instance</param>
        /// <returns>Ext.data.Store</returns>
        public static Ext.data.Store lookup(System.String id) { return null; }

        /// <summary>Gets a registered Store by id</summary>
        /// <param name="id">The id of the Store, or a Store instance</param>
        /// <returns>Ext.data.Store</returns>
        public static Ext.data.Store lookup(object id) { return null; }



    }
    [Anonymous]
    public class StoreMgrConfig {

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }


}
