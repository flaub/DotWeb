using System;
using System.DotWeb;
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
		public extern DDTarget();
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <returns></returns>
		public extern DDTarget(string id);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public extern DDTarget(string id, string sGroup);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public extern DDTarget(string id, string sGroup, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static DDTarget prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.dd.DragDrop superclass { get; set; }




	}
}
