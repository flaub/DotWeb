using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.SplitBar {
	/// <summary>
	///     /**
	///     Adapter that  moves the splitter element to align with the resized sizing element.
	///     Used with an absolute positioned SplitBar.
	///     @param {Mixed} container The container that wraps around the absolute positioned content. If it's
	///     document.body, make sure you assign an id to the body element.
	///     */
	///     Ext.SplitBar.AbsoluteLayoutAdapter = function(container){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\SplitBar.js</jssource>
	public class AbsoluteLayoutAdapter : Ext.SplitBar.BasicLayoutAdapter {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern AbsoluteLayoutAdapter();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static AbsoluteLayoutAdapter prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.SplitBar.BasicLayoutAdapter superclass { get; set; }

		/// <summary>Orientation constant - Create a vertical SplitBar</summary>
		public extern static double VERTICAL { get; set; }

		/// <summary>Orientation constant - Create a horizontal SplitBar</summary>
		public extern static double HORIZONTAL { get; set; }

		/// <summary>Placement constant - The resizing element is to the left of the splitter element</summary>
		public extern static double LEFT { get; set; }

		/// <summary>Placement constant - The resizing element is to the right of the splitter element</summary>
		public extern static double RIGHT { get; set; }

		/// <summary>Placement constant - The resizing element is positioned above the splitter element</summary>
		public extern static double TOP { get; set; }

		/// <summary>Placement constant - The resizing element is positioned under splitter element</summary>
		public extern static double BOTTOM { get; set; }




	}
}
