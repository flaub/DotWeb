using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     A custom wrapper for the {@link Ext.grid.PropertyGrid}'s {@link Ext.data.Store}. This class handles the mapping
	///     between the custom data source objects supported by the grid and the {@link Ext.grid.PropertyRecord} format
	///     required for compatibility with the underlying store. Generally this class should not need to be used directly --
	///     the grid's data should be accessed from the underlying store via the {@link #store} property.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\PropertyGrid.js</jssource>
	public class PropertyStore : Ext.util.Observable {

		/// <summary></summary>
		/// <returns></returns>
		public extern PropertyStore();
		/// <summary></summary>
		/// <param name="grid">The grid this store will be bound to</param>
		/// <returns></returns>
		public extern PropertyStore(object grid);
		/// <summary></summary>
		/// <param name="grid">The grid this store will be bound to</param>
		/// <param name="source">The source data config object</param>
		/// <returns></returns>
		public extern PropertyStore(object grid, object source);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static PropertyStore prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }




	}

	[JsAnonymous]
	public class PropertyStoreConfig : System.DotWeb.JsDynamic {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}
}
