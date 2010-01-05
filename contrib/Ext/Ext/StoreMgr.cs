using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     The default global group of stores.
	///     */
	///     Ext.StoreMgr = Ext.apply(new Ext.util.MixedCollection(), {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\StoreMgr.js</jssource>
	public class StoreMgr : Ext.util.MixedCollection {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern StoreMgr();
		/// <summary>
		///     collection (defaults to false)
		///     and return the key value for that item.  This is used when available to look up the key on items that
		///     were passed without an explicit key parameter to a MixedCollection method.  Passing this parameter is
		///     equivalent to providing an implementation for the {@link #getKey} method.
		/// </summary>
		/// <param name="allowFunctions">True if the addAll function should add function references to the</param>
		/// <returns></returns>
		public extern StoreMgr(bool allowFunctions);
		/// <summary>
		///     collection (defaults to false)
		///     and return the key value for that item.  This is used when available to look up the key on items that
		///     were passed without an explicit key parameter to a MixedCollection method.  Passing this parameter is
		///     equivalent to providing an implementation for the {@link #getKey} method.
		/// </summary>
		/// <param name="allowFunctions">True if the addAll function should add function references to the</param>
		/// <param name="keyFn">A function that can accept an item of the type(s) stored in this MixedCollection</param>
		/// <returns></returns>
		public extern StoreMgr(bool allowFunctions, Delegate keyFn);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static StoreMgr prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.MixedCollection superclass { get; set; }


		/// <summary>
		///     Registers one or more Stores with the StoreMgr. You do not normally need to register stores
		///     manually.  Any store initialized with a {@link Ext.data.Store#storeId} will be auto-registered.
		/// </summary>
		/// <returns></returns>
		public extern static void register();

		/// <summary>
		///     Registers one or more Stores with the StoreMgr. You do not normally need to register stores
		///     manually.  Any store initialized with a {@link Ext.data.Store#storeId} will be auto-registered.
		/// </summary>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void register(params Ext.data.Store[] args);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <returns></returns>
		public extern static void unregister();

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(params string[] args);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <returns></returns>
		public extern static void unregister(object id1);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(object id1, params string[] args);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(string id1, object id2);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(string id1, object id2, params string[] args);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(object id1, object id2);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(object id1, object id2, params string[] args);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(string id1, string id2);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(string id1, string id2, params object[] args);

		/// <summary>Unregisters one or more Stores with the StoreMgr</summary>
		/// <param name="id1">The id of the Store, or a Store instance</param>
		/// <param name="id2">(optional)</param>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern static void unregister(object id1, string id2, params object[] args);

		/// <summary>Gets a registered Store by id</summary>
		/// <returns>Ext.data.Store</returns>
		public extern static void lookup();

		/// <summary>Gets a registered Store by id</summary>
		/// <param name="id">The id of the Store, or a Store instance</param>
		/// <returns>Ext.data.Store</returns>
		public extern static void lookup(string id);

		/// <summary>Gets a registered Store by id</summary>
		/// <param name="id">The id of the Store, or a Store instance</param>
		/// <returns>Ext.data.Store</returns>
		public extern static void lookup(object id);



	}

	[JsAnonymous]
	public class StoreMgrConfig : System.DotWeb.JsDynamic {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}
}
