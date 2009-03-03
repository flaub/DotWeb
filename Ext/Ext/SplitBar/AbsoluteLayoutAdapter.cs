using System;
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
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\SplitBar.js</jssource>
	public class AbsoluteLayoutAdapter : Ext.SplitBar.BasicLayoutAdapter {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public AbsoluteLayoutAdapter() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static AbsoluteLayoutAdapter prototype { get { return S_<AbsoluteLayoutAdapter>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.SplitBar.BasicLayoutAdapter superclass { get { return S_<Ext.SplitBar.BasicLayoutAdapter>(); } set { S_(value); } }

		/// <summary>Orientation constant - Create a vertical SplitBar</summary>
		public static double VERTICAL { get { return S_<double>(); } set { S_(value); } }

		/// <summary>Orientation constant - Create a horizontal SplitBar</summary>
		public static double HORIZONTAL { get { return S_<double>(); } set { S_(value); } }

		/// <summary>Placement constant - The resizing element is to the left of the splitter element</summary>
		public static double LEFT { get { return S_<double>(); } set { S_(value); } }

		/// <summary>Placement constant - The resizing element is to the right of the splitter element</summary>
		public static double RIGHT { get { return S_<double>(); } set { S_(value); } }

		/// <summary>Placement constant - The resizing element is positioned above the splitter element</summary>
		public static double TOP { get { return S_<double>(); } set { S_(value); } }

		/// <summary>Placement constant - The resizing element is positioned under splitter element</summary>
		public static double BOTTOM { get { return S_<double>(); } set { S_(value); } }




	}
}
