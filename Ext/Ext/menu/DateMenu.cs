using System;
using DotWeb.Client;

namespace Ext.menu {
	/// <summary>
	///     /**
	///     A menu containing a {@link Ext.menu.DateItem} component (which provides a date picker).
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\menu\DateMenu.js</jssource>
	public class DateMenu : Ext.menu.Menu {

		/// <summary>Creates a new DateMenu</summary>
		/// <returns></returns>
		public DateMenu() { C_(); }
		/// <summary>Creates a new DateMenu</summary>
		/// <param name="config">Configuration options</param>
		/// <returns></returns>
		public DateMenu(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DateMenu prototype { get { return S_<DateMenu>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.menu.Menu superclass { get { return S_<Ext.menu.Menu>(); } set { S_(value); } }

		/// <summary>The {@link Ext.DatePicker} instance for this DateMenu</summary>
		public DatePicker picker { get { return _<DatePicker>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class DateMenuConfig : DotWeb.Client.JsAccessible {
		/// <summary>  A config object that will be applied to all items added to this container either via the {@link #items} config or via the {@link #add} method.  The defaults config can contain any number of name/value property pairs to be added to each item, and should be valid for the types of items being added to the menu.</summary>
		public object defaults { get; set; }

		/// <summary>  An array of items to be added to this menu.  See {@link #add} for a list of valid item types.</summary>
		public object items { get; set; }

		/// <summary> The minimum width of the menu in pixels (defaults to 120)</summary>
		public double minWidth { get; set; }

		/// <summary>{Boolean/String} True or "sides" for the default effect, "frame" for 4-way shadow, and "drop" for bottom-right shadow (defaults to "sides")</summary>
		public object shadow { get; set; }

		/// <summary> The {@link Ext.Element#alignTo} anchor position value to use for submenus of this menu (defaults to "tl-tr?")</summary>
		public System.String subMenuAlign { get; set; }

		/// <summary> The default {@link Ext.Element#alignTo} anchor position value for this menu relative to its element of origin (defaults to "tl-bl?")</summary>
		public System.String defaultAlign { get; set; }

		/// <summary> True to allow multiple menus to be displayed at the same time (defaults to false)</summary>
		public bool allowOtherMenus { get; set; }

		/// <summary> True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).</summary>
		public bool ignoreParentClicks { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class DateMenuEvents {
        /// <summary>
        /// <pre><code>
        /// USAGE: ({DatePicker} picker, {Date} date)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>picker</b></term><description></description></item>
        /// <item><term><b>date</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string select { get { return "select"; } }
    }

    public delegate void DateMenuSelectDelegate(DatePicker picker, System.DateTime date);
}
