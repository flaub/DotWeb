using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.menu {
	/// <summary>
	///     /**
	///     Provides a common registry of all menu items on a page so that they can be easily accessed by id.
	///     */
	///     Ext.menu.MenuMgr = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\menu\MenuMgr.js</jssource>
	public class MenuMgr : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern MenuMgr();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static MenuMgr prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Hides all menus that are currently visible</summary>
		/// <returns></returns>
		public extern static void hideAll();

		/// <summary>
		///     Returns a {@link Ext.menu.Menu} object
		///     be used to generate and return a new Menu instance.
		/// </summary>
		/// <returns>Ext.menu.Menu</returns>
		public extern static void get();

		/// <summary>
		///     Returns a {@link Ext.menu.Menu} object
		///     be used to generate and return a new Menu instance.
		/// </summary>
		/// <param name="menu">The string menu id, an existing menu object reference, or a Menu config that will</param>
		/// <returns>Ext.menu.Menu</returns>
		public extern static void get(string menu);

		/// <summary>
		///     Returns a {@link Ext.menu.Menu} object
		///     be used to generate and return a new Menu instance.
		/// </summary>
		/// <param name="menu">The string menu id, an existing menu object reference, or a Menu config that will</param>
		/// <returns>Ext.menu.Menu</returns>
		public extern static void get(object menu);



	}
}
