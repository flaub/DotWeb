using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     The default global group of stores.
	///     */
	///     Ext.StoreMgr = Ext.apply(new Ext.util.MixedCollection(), {
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\StoreMgr.js</jssource>
	public class StoreMgr : Ext.util.MixedCollection {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public StoreMgr() { C_(); }
		/// <summary>
		///     collection (defaults to false)
		///     and return the key value for that item.  This is used when available to look up the key on items that
		///     were passed without an explicit key parameter to a MixedCollection method.  Passing this parameter is
		///     equivalent to providing an implementation for the {@link #getKey} method.
		/// </summary>
		/// <param name="allowFunctions">True if the addAll function should add function references to the</param>
		/// <returns></returns>
		public StoreMgr(bool allowFunctions) { C_(allowFunctions); }
		/// <summary>
		///     collection (defaults to false)
		///     and return the key value for that item.  This is used when available to look up the key on items that
		///     were passed without an explicit key parameter to a MixedCollection method.  Passing this parameter is
		///     equivalent to providing an implementation for the {@link #getKey} method.
		/// </summary>
		/// <param name="allowFunctions">True if the addAll function should add function references to the</param>
		/// <param name="keyFn">A function that can accept an item of the type(s) stored in this MixedCollection</param>
		/// <returns></returns>
		public StoreMgr(bool allowFunctions, Delegate keyFn) { C_(allowFunctions, keyFn); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static StoreMgr prototype { get { return S_<StoreMgr>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.util.MixedCollection superclass { get { return S_<Ext.util.MixedCollection>(); } set { S_(value); } }


		/// <summary>
		///     Registers one or more Stores with the StoreMgr. You do not normally need to register stores
		///     manually.  Any store initialized with a {@link Ext.data.Store#storeId} will be auto-registered.
		/// </summary>
		/// <returns></returns>
		public static void register() { S_(); }

		/// <summary>
		///     Registers one or more Stores with the StoreMgr. You do not normally need to register stores
		///     manually.  Any store initialized with a {@link Ext.data.Store#storeId} will be auto-registered.
		/// </summary>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void register(params Ext.data.Store[] args) { S_(args); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <returns></returns>
		public static void unregister() { S_(); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void unregister(params System.String[] args) { S_(args); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <returns></returns>
		public static void unregister(object id1) { S_(id1); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void unregister(object id1, params System.String[] args) { S_(id1, args); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <returns></returns>
		public static void unregister(System.String id1, object id2) { S_(id1, id2); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void unregister(System.String id1, object id2, params System.String[] args) { S_(id1, id2, args); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <returns></returns>
		public static void unregister(object id1, object id2) { S_(id1, id2); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void unregister(object id1, object id2, params System.String[] args) { S_(id1, id2, args); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <returns></returns>
		public static void unregister(System.String id1, System.String id2) { S_(id1, id2); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void unregister(System.String id1, System.String id2, params object[] args) { S_(id1, id2, args); }

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public static void unregister(object id1, System.String id2, params object[] args) { S_(id1, id2, args); }

		/// <summary>Gets a registered Store by id</summary>
		/// <returns>Ext.data.Store</returns>
		public static void lookup() { S_(); }

		/// <summary>Gets a registered Store by id</summary>
		/// <param name="id">The id of the Store, or a Store instance</param>
		/// <returns>Ext.data.Store</returns>
		public static void lookup(System.String id) { S_(id); }

		/// <summary>Gets a registered Store by id</summary>
		/// <param name="id">The id of the Store, or a Store instance</param>
		/// <returns>Ext.data.Store</returns>
		public static void lookup(object id) { S_(id); }



	}

	[JsAnonymous]
	public class StoreMgrConfig : DotWeb.Client.JsAccessible {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}
}
