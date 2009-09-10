using System;
using DotWeb.Client;

namespace Ext.menu {
	/// <summary>
	///     /**
	///     Provides a common registry of all menu items on a page so that they can be easily accessed by id.
	///     */
	///     Ext.menu.MenuMgr = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\menu\MenuMgr.js</jssource>
	public class MenuMgr : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public MenuMgr() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static MenuMgr prototype { get { return S_<MenuMgr>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Hides all menus that are currently visible</summary>
		/// <returns></returns>
		public static void hideAll() { S_(); }

		/// <summary>
		///     Returns a {@link Ext.menu.Menu} object
		///     be used to generate and return a new Menu instance.
		/// </summary>
		/// <returns>Ext.menu.Menu</returns>
		public static void get() { S_(); }

		/// <summary>
		///     Returns a {@link Ext.menu.Menu} object
		///     be used to generate and return a new Menu instance.
		/// </summary>
		/// <param name="menu">The string menu id, an existing menu object reference, or a Menu config that will</param>
		/// <returns>Ext.menu.Menu</returns>
		public static void get(string menu) { S_(menu); }

		/// <summary>
		///     Returns a {@link Ext.menu.Menu} object
		///     be used to generate and return a new Menu instance.
		/// </summary>
		/// <param name="menu">The string menu id, an existing menu object reference, or a Menu config that will</param>
		/// <returns>Ext.menu.Menu</returns>
		public static void get(object menu) { S_(menu); }



	}
}
