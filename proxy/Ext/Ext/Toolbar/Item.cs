using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.Toolbar {
	/// <summary>
	///     /**
	///     The base class that other classes should extend in order to get some basic common toolbar item functionality.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Item : System.DotWeb.JsObject {

		/// <summary>Creates a new Item</summary>
		/// <returns></returns>
		public extern Item();
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public extern Item(DOMElement el);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Item prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Get this item's HTML Element</summary>
		/// <returns>HTMLElement</returns>
		public extern virtual void getEl();

		/// <summary>Removes and destroys this item.</summary>
		/// <returns></returns>
		public extern virtual void destroy();

		/// <summary>Shows this item.</summary>
		/// <returns></returns>
		public extern virtual void show();

		/// <summary>Hides this item.</summary>
		/// <returns></returns>
		public extern virtual void hide();

		/// <summary>Convenience function for boolean show/hide.</summary>
		/// <returns></returns>
		public extern virtual void setVisible();

		/// <summary>Convenience function for boolean show/hide.</summary>
		/// <param name="visible">true to show/false to hide</param>
		/// <returns></returns>
		public extern virtual void setVisible(bool visible);

		/// <summary>Try to focus this item</summary>
		/// <returns></returns>
		public extern virtual void focus();

		/// <summary>Disables this item.</summary>
		/// <returns></returns>
		public extern virtual void disable();

		/// <summary>Enables this item.</summary>
		/// <returns></returns>
		public extern virtual void enable();



	}
}
