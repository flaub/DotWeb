using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.SplitBar {
	/// <summary>
	///     /**
	///     Default Adapter. It assumes the splitter and resizing element are not positioned
	///     elements and only gets/sets the width of the element. Generally used for table based layouts.
	///     */
	///     Ext.SplitBar.BasicLayoutAdapter = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\SplitBar.js</jssource>
	public class BasicLayoutAdapter : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern BasicLayoutAdapter();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static BasicLayoutAdapter prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Called before drag operations to get the current size of the resizing element.</summary>
		/// <returns></returns>
		public extern virtual void getElementSize();

		/// <summary>Called before drag operations to get the current size of the resizing element.</summary>
		/// <param name="s">The SplitBar using this adapter</param>
		/// <returns></returns>
		public extern virtual void getElementSize(Ext.SplitBarClass s);

		/// <summary>Called after drag operations to set the size of the resizing element.</summary>
		/// <returns></returns>
		public extern virtual void setElementSize();

		/// <summary>Called after drag operations to set the size of the resizing element.</summary>
		/// <param name="s">The SplitBar using this adapter</param>
		/// <returns></returns>
		public extern virtual void setElementSize(Ext.SplitBarClass s);

		/// <summary>Called after drag operations to set the size of the resizing element.</summary>
		/// <param name="s">The SplitBar using this adapter</param>
		/// <param name="newSize">The new size to set</param>
		/// <returns></returns>
		public extern virtual void setElementSize(Ext.SplitBarClass s, double newSize);

		/// <summary>Called after drag operations to set the size of the resizing element.</summary>
		/// <param name="s">The SplitBar using this adapter</param>
		/// <param name="newSize">The new size to set</param>
		/// <param name="onComplete">A function to be invoked when resizing is complete</param>
		/// <returns></returns>
		public extern virtual void setElementSize(Ext.SplitBarClass s, double newSize, Delegate onComplete);



	}
}
