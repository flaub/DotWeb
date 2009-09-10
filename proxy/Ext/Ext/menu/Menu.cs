using System;
using DotWeb.Client;

namespace Ext.menu {
	/// <summary>
	///     /**
	///     A menu object.  This is the container to which you add all other menu items.  Menu can also serve as a base class
	///     when you want a specialized menu based off of another component (like {@link Ext.menu.DateMenu} for example).
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\menu\Menu.js</jssource>
	public class Menu : Ext.util.Observable {

		/// <summary>Creates a new Menu</summary>
		/// <returns></returns>
		public Menu() { C_(); }
		/// <summary>Creates a new Menu</summary>
		/// <param name="config">Configuration options</param>
		/// <returns></returns>
		public Menu(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Ext.menu.Menu prototype { get { return S_<Ext.menu.Menu>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.util.Observable superclass { get { return S_<Ext.util.Observable>(); } set { S_(value); } }

		/// <summary>A MixedCollection of this Menu's items</summary>
		public Ext.util.MixedCollection items { get { return _<Ext.util.MixedCollection>(); } set { _(value); } }

		/// <summary>
		///     A config object that will be applied to all items added to this container either via the {@link #items}
		///     config or via the {@link #add} method.  The defaults config can contain any number of
		///     name/value property pairs to be added to each item, and should be valid for the types of items
		///     being added to the menu.
		/// </summary>
		public object defaults { get { return _<object>(); } set { _(value); } }

		/// <summary>The minimum width of the menu in pixels (defaults to 120)</summary>
		public double minWidth { get { return _<double>(); } set { _(value); } }

		/// <summary>True or "sides" for the default effect, "frame" for 4-way shadow, and "drop"for bottom-right shadow (defaults to "sides")</summary>
		public object shadow { get { return _<object>(); } set { _(value); } }

		/// <summary>The {@link Ext.Element#alignTo} anchor position value to use for submenus ofthis menu (defaults to "tl-tr?")</summary>
		public string subMenuAlign { get { return _<string>(); } set { _(value); } }

		/// <summary>The default {@link Ext.Element#alignTo} anchor position value for this menurelative to its element of origin (defaults to "tl-bl?")</summary>
		public string defaultAlign { get { return _<string>(); } set { _(value); } }

		/// <summary>True to allow multiple menus to be displayed at the same time (defaults to false)</summary>
		public bool allowOtherMenus { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to ignore clicks on any item in this menu that is a parent item (displaysa submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).</summary>
		public bool ignoreParentClicks { get { return _<bool>(); } set { _(value); } }


		/// <summary>
		///     Read-only.  Returns true if the menu is currently displayed, else false.
		///     @type Boolean
		/// </summary>
		/// <returns></returns>
		public virtual void isVisible() { _(); }

		/// <summary>
		///     Displays this menu relative to another element
		///     the element (defaults to this.defaultAlign)
		/// </summary>
		/// <returns></returns>
		public virtual void show() { _(); }

		/// <summary>
		///     Displays this menu relative to another element
		///     the element (defaults to this.defaultAlign)
		/// </summary>
		/// <param name="element">The element to align to</param>
		/// <returns></returns>
		public virtual void show(object element) { _(element); }

		/// <summary>
		///     Displays this menu relative to another element
		///     the element (defaults to this.defaultAlign)
		/// </summary>
		/// <param name="element">The element to align to</param>
		/// <param name="position">(optional) The {@link Ext.Element#alignTo} anchor position to use in aligning to</param>
		/// <returns></returns>
		public virtual void show(object element, string position) { _(element, position); }

		/// <summary>
		///     Displays this menu relative to another element
		///     the element (defaults to this.defaultAlign)
		/// </summary>
		/// <param name="element">The element to align to</param>
		/// <param name="position">(optional) The {@link Ext.Element#alignTo} anchor position to use in aligning to</param>
		/// <param name="parentMenu">(optional) This menu's parent menu, if applicable (defaults to undefined)</param>
		/// <returns></returns>
		public virtual void show(object element, string position, Ext.menu.Menu parentMenu) { _(element, position, parentMenu); }

		/// <summary>Displays this menu at a specific xy position</summary>
		/// <returns></returns>
		public virtual void showAt() { _(); }

		/// <summary>Displays this menu at a specific xy position</summary>
		/// <param name="xyPosition">Contains X & Y [x, y] values for the position at which to show the menu (coordinates are page-based)</param>
		/// <returns></returns>
		public virtual void showAt(System.Array xyPosition) { _(xyPosition); }

		/// <summary>Displays this menu at a specific xy position</summary>
		/// <param name="xyPosition">Contains X & Y [x, y] values for the position at which to show the menu (coordinates are page-based)</param>
		/// <param name="parentMenu">(optional) This menu's parent menu, if applicable (defaults to undefined)</param>
		/// <returns></returns>
		public virtual void showAt(System.Array xyPosition, Ext.menu.Menu parentMenu) { _(xyPosition, parentMenu); }

		/// <summary>Hides this menu and optionally all parent menus</summary>
		/// <returns></returns>
		public virtual void hide() { _(); }

		/// <summary>Hides this menu and optionally all parent menus</summary>
		/// <param name="deep">(optional) True to hide all parent menus recursively, if any (defaults to false)</param>
		/// <returns></returns>
		public virtual void hide(bool deep) { _(deep); }

		/// <summary>
		///     Addds one or more items of any type supported by the Menu class, or that can be converted into menu items.
		///     Any of the following are valid:
		///     <ul>
		///     <li>Any menu item object based on {@link Ext.menu.BaseItem}</li>
		///     <li>An HTMLElement object which will be converted to a menu item</li>
		///     <li>A menu item config object that will be created as a new menu item</li>
		///     <li>A string, which can either be '-' or 'separator' to add a menu separator, otherwise
		///     it will be converted into a {@link Ext.menu.TextItem} and added</li>
		///     </ul>
		///     Usage:
		///     <pre><code>
		///     // Create the menu
		///     var menu = new Ext.menu.Menu();
		///     // Create a menu item to add by reference
		///     var menuItem = new Ext.menu.Item({ text: 'New Item!' });
		///     // Add a bunch of items at once using different methods.
		///     // Only the last item added will be returned.
		///     var item = menu.add(
		///     menuItem,                // add existing item by ref
		///     'Dynamic Item',          // new TextItem
		///     '-',                     // new separator
		///     { text: 'Config Item' }  // new item by config
		///     );
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void add() { _(); }

		/// <summary>
		///     Addds one or more items of any type supported by the Menu class, or that can be converted into menu items.
		///     Any of the following are valid:
		///     <ul>
		///     <li>Any menu item object based on {@link Ext.menu.BaseItem}</li>
		///     <li>An HTMLElement object which will be converted to a menu item</li>
		///     <li>A menu item config object that will be created as a new menu item</li>
		///     <li>A string, which can either be '-' or 'separator' to add a menu separator, otherwise
		///     it will be converted into a {@link Ext.menu.TextItem} and added</li>
		///     </ul>
		///     Usage:
		///     <pre><code>
		///     // Create the menu
		///     var menu = new Ext.menu.Menu();
		///     // Create a menu item to add by reference
		///     var menuItem = new Ext.menu.Item({ text: 'New Item!' });
		///     // Add a bunch of items at once using different methods.
		///     // Only the last item added will be returned.
		///     var item = menu.add(
		///     menuItem,                // add existing item by ref
		///     'Dynamic Item',          // new TextItem
		///     '-',                     // new separator
		///     { text: 'Config Item' }  // new item by config
		///     );
		///     </code></pre>
		/// </summary>
		/// <param name="args">One or more menu items, menu item configs or other objects that can be converted to menu items</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void add(object args) { _(args); }

		/// <summary>Returns this menu's underlying {@link Ext.Element} object</summary>
		/// <returns>Ext.Element</returns>
		public virtual void getEl() { _(); }

		/// <summary>Adds a separator bar to the menu</summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addSeparator() { _(); }

		/// <summary>Adds an {@link Ext.Element} object to the menu</summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addElement() { _(); }

		/// <summary>Adds an {@link Ext.Element} object to the menu</summary>
		/// <param name="el">The element or DOM node to add, or its id</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addElement(object el) { _(el); }

		/// <summary>Adds an existing object based on {@link Ext.menu.BaseItem} to the menu</summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addItem() { _(); }

		/// <summary>Adds an existing object based on {@link Ext.menu.BaseItem} to the menu</summary>
		/// <param name="item">The menu item to add</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addItem(Ext.menu.Item item) { _(item); }

		/// <summary>Creates a new {@link Ext.menu.Item} based an the supplied config object and adds it to the menu</summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addMenuItem() { _(); }

		/// <summary>Creates a new {@link Ext.menu.Item} based an the supplied config object and adds it to the menu</summary>
		/// <param name="config">A MenuItem config object</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addMenuItem(object config) { _(config); }

		/// <summary>Creates a new {@link Ext.menu.TextItem} with the supplied text and adds it to the menu</summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addText() { _(); }

		/// <summary>Creates a new {@link Ext.menu.TextItem} with the supplied text and adds it to the menu</summary>
		/// <param name="text">The text to display in the menu item</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void addText(string text) { _(text); }

		/// <summary>Inserts an existing object based on {@link Ext.menu.BaseItem} to the menu at a specified index</summary>
		/// <returns>Ext.menu.Item</returns>
		public virtual void insert() { _(); }

		/// <summary>Inserts an existing object based on {@link Ext.menu.BaseItem} to the menu at a specified index</summary>
		/// <param name="index">The index in the menu's list of current items where the new item should be inserted</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void insert(double index) { _(index); }

		/// <summary>Inserts an existing object based on {@link Ext.menu.BaseItem} to the menu at a specified index</summary>
		/// <param name="index">The index in the menu's list of current items where the new item should be inserted</param>
		/// <param name="item">The menu item to add</param>
		/// <returns>Ext.menu.Item</returns>
		public virtual void insert(double index, Ext.menu.Item item) { _(index, item); }

		/// <summary>Removes an {@link Ext.menu.Item} from the menu and destroys the object</summary>
		/// <returns></returns>
		public virtual void remove() { _(); }

		/// <summary>Removes an {@link Ext.menu.Item} from the menu and destroys the object</summary>
		/// <param name="item">The menu item to remove</param>
		/// <returns></returns>
		public virtual void remove(Ext.menu.Item item) { _(item); }

		/// <summary>Removes and destroys all items in the menu</summary>
		/// <returns></returns>
		public virtual void removeAll() { _(); }

		/// <summary>
		///     Destroys the menu by  unregistering it from {@link Ext.menu.MenuMgr}, purging event listeners,
		///     removing all of the menus items, then destroying the underlying {@link Ext.Element}
		/// </summary>
		/// <returns></returns>
		public virtual void destroy() { _(); }



	}

	[JsAnonymous]
	public class MenuConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>  A config object that will be applied to all items added to this container either via the {@link #items} config or via the {@link #add} method.  The defaults config can contain any number of name/value property pairs to be added to each item, and should be valid for the types of items being added to the menu.</summary>
		public object defaults { get { return _<object>(); } set { _(value); } }

		/// <summary>  An array of items to be added to this menu.  See {@link #add} for a list of valid item types.</summary>
		public object items { get { return _<object>(); } set { _(value); } }

		/// <summary> The minimum width of the menu in pixels (defaults to 120)</summary>
		public double minWidth { get { return _<double>(); } set { _(value); } }

		/// <summary>{Boolean/String} True or "sides" for the default effect, "frame" for 4-way shadow, and "drop" for bottom-right shadow (defaults to "sides")</summary>
		public object shadow { get { return _<object>(); } set { _(value); } }

		/// <summary> The {@link Ext.Element#alignTo} anchor position value to use for submenus of this menu (defaults to "tl-tr?")</summary>
		public string subMenuAlign { get { return _<string>(); } set { _(value); } }

		/// <summary> The default {@link Ext.Element#alignTo} anchor position value for this menu relative to its element of origin (defaults to "tl-bl?")</summary>
		public string defaultAlign { get { return _<string>(); } set { _(value); } }

		/// <summary> True to allow multiple menus to be displayed at the same time (defaults to false)</summary>
		public bool allowOtherMenus { get { return _<bool>(); } set { _(value); } }

		/// <summary> True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).</summary>
		public bool ignoreParentClicks { get { return _<bool>(); } set { _(value); } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return _<object>(); } set { _(value); } }

	}

    public class MenuEvents {
        /// <summary>Fires before this menu is displayed
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforeshow { get { return "beforeshow"; } }
        /// <summary>Fires before this menu is hidden
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforehide { get { return "beforehide"; } }
        /// <summary>Fires after this menu is displayed
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string show { get { return "show"; } }
        /// <summary>Fires after this menu is hidden
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string hide { get { return "hide"; } }
        /// <summary>Fires when this menu is clicked (or when the enter key is pressed while it is active)
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis, {Ext.menu.Item} menuItem, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>menuItem</b></term><description>The menu item that was clicked</description></item>
        /// <item><term><b>e</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string click { get { return "click"; } }
        /// <summary>Fires when the mouse is hovering over this menu
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis, {Ext.EventObject} e, {Ext.menu.Item} menuItem)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description></description></item>
        /// <item><term><b>menuItem</b></term><description>The menu item that was clicked</description></item>
        /// </list>
        /// </summary>
        public static string mouseover { get { return "mouseover"; } }
        /// <summary>Fires when the mouse exits this menu
        /// <pre><code>
        /// USAGE: ({Ext.menu.Menu} objthis, {Ext.EventObject} e, {Ext.menu.Item} menuItem)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description></description></item>
        /// <item><term><b>menuItem</b></term><description>The menu item that was clicked</description></item>
        /// </list>
        /// </summary>
        public static string mouseout { get { return "mouseout"; } }
        /// <summary>Fires when a menu item contained in this menu is clicked
        /// <pre><code>
        /// USAGE: ({Ext.menu.BaseItem} baseItem, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>baseItem</b></term><description>The BaseItem that was clicked</description></item>
        /// <item><term><b>e</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string itemclick { get { return "itemclick"; } }
    }

    public delegate void MenuBeforeshowDelegate(Ext.menu.Menu objthis);
    public delegate void MenuBeforehideDelegate(Ext.menu.Menu objthis);
    public delegate void MenuShowDelegate(Ext.menu.Menu objthis);
    public delegate void MenuHideDelegate(Ext.menu.Menu objthis);
    public delegate void MenuClickDelegate(Ext.menu.Menu objthis, Ext.menu.Item menuItem, Ext.EventObject e);
    public delegate void MenuMouseoverDelegate(Ext.menu.Menu objthis, Ext.EventObject e, Ext.menu.Item menuItem);
    public delegate void MenuMouseoutDelegate(Ext.menu.Menu objthis, Ext.EventObject e, Ext.menu.Item menuItem);
    public delegate void MenuItemclickDelegate(Ext.menu.BaseItem baseItem, Ext.EventObject e);
}
