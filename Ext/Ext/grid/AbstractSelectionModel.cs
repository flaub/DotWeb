using System;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     Abstract base class for grid SelectionModels.  It provides the interface that should be
	///     implemented by descendant classes.  This class should not be directly instantiated.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\grid\AbstractSelectionModel.js</jssource>
	public class AbstractSelectionModel : Ext.util.Observable {

		/// <summary></summary>
		/// <returns></returns>
		public AbstractSelectionModel() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static AbstractSelectionModel prototype { get { return S_<AbstractSelectionModel>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.util.Observable superclass { get { return S_<Ext.util.Observable>(); } set { S_(value); } }


		/// <summary>Locks the selections.</summary>
		/// <returns></returns>
		public virtual void lock_() { _(); }

		/// <summary>Unlocks the selections.</summary>
		/// <returns></returns>
		public virtual void unlock() { _(); }

		/// <summary>Returns true if the selections are locked.</summary>
		/// <returns>Boolean</returns>
		public virtual void isLocked() { _(); }



	}

	[JsAnonymous]
	public class AbstractSelectionModelConfig : DotWeb.Client.JsAccessible {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}
}
