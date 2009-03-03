using System;
using DotWeb.Client;

namespace Ext.Toolbar {
	/// <summary>
	///     /**
	///     The base class that other classes should extend in order to get some basic common toolbar item functionality.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Item : DotWeb.Client.JsNativeBase {

		/// <summary>Creates a new Item</summary>
		/// <returns></returns>
		public Item() { C_(); }
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public Item(DOMElement el) { C_(el); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Item prototype { get { return S_<Item>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Get this item's HTML Element</summary>
		/// <returns>HTMLElement</returns>
		public virtual void getEl() { _(); }

		/// <summary>Removes and destroys this item.</summary>
		/// <returns></returns>
		public virtual void destroy() { _(); }

		/// <summary>Shows this item.</summary>
		/// <returns></returns>
		public virtual void show() { _(); }

		/// <summary>Hides this item.</summary>
		/// <returns></returns>
		public virtual void hide() { _(); }

		/// <summary>Convenience function for boolean show/hide.</summary>
		/// <returns></returns>
		public virtual void setVisible() { _(); }

		/// <summary>Convenience function for boolean show/hide.</summary>
		/// <param name="visible">true to show/false to hide</param>
		/// <returns></returns>
		public virtual void setVisible(bool visible) { _(visible); }

		/// <summary>Try to focus this item</summary>
		/// <returns></returns>
		public virtual void focus() { _(); }

		/// <summary>Disables this item.</summary>
		/// <returns></returns>
		public virtual void disable() { _(); }

		/// <summary>Enables this item.</summary>
		/// <returns></returns>
		public virtual void enable() { _(); }



	}
}
