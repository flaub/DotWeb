using System;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     A DragDrop implementation that does not move, but can be a drop
	///     target.  You would get the same result by simply omitting implementation
	///     for the event callbacks, but this way we reduce the processing cost of the
	///     event listener and the callbacks.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\dd\DDCore.js</jssource>
	public class DDTarget : Ext.dd.DragDrop {

		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <returns></returns>
		public DDTarget() { C_(); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <returns></returns>
		public DDTarget(string id) { C_(id); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public DDTarget(string id, string sGroup) { C_(id, sGroup); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public DDTarget(string id, string sGroup, object config) { C_(id, sGroup, config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DDTarget prototype { get { return S_<DDTarget>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.dd.DragDrop superclass { get { return S_<Ext.dd.DragDrop>(); } set { S_(value); } }




	}
}
