using System;
using H8.Support;

namespace Ext.menu {
    /// <summary>
    ///     /**
    ///     A menu containing a {@link Ext.menu.DateItem} component (which provides a date picker).
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\menu\DateMenu.js</jssource>
    [Native]
    public class DateMenu : Ext.menu.Menu {

        /// <summary>Creates a new DateMenu</summary>
        /// <returns></returns>
        public DateMenu() {}
        /// <summary>Creates a new DateMenu</summary>
        /// <param name="config">Configuration options</param>
        /// <returns></returns>
        public DateMenu(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DateMenu prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.menu.Menu superclass { get { return null; } set { } }

        /// <summary>The {@link Ext.DatePicker} instance for this DateMenu</summary>
        public DatePicker picker { get { return null; } set { } }




    }
    [Anonymous]
    public class DateMenuConfig {

        /// <summary>  A config object that will be applied to all items added to this container either via the {@link #items} config or via the {@link #add} method.  The defaults config can contain any number of name/value property pairs to be added to each item, and should be valid for the types of items being added to the menu.</summary>
        public object defaults { get { return null; } set { } }

        /// <summary>  An array of items to be added to this menu.  See {@link #add} for a list of valid item types.</summary>
        public object items { get { return null; } set { } }

        /// <summary> The minimum width of the menu in pixels (defaults to 120)</summary>
        public double minWidth { get { return 0; } set { } }

        /// <summary>{Boolean/String} True or "sides" for the default effect, "frame" for 4-way shadow, and "drop" for bottom-right shadow (defaults to "sides")</summary>
        public object shadow { get { return null; } set { } }

        /// <summary> The {@link Ext.Element#alignTo} anchor position value to use for submenus of this menu (defaults to "tl-tr?")</summary>
        public System.String subMenuAlign { get { return null; } set { } }

        /// <summary> The default {@link Ext.Element#alignTo} anchor position value for this menu relative to its element of origin (defaults to "tl-bl?")</summary>
        public System.String defaultAlign { get { return null; } set { } }

        /// <summary> True to allow multiple menus to be displayed at the same time (defaults to false)</summary>
        public bool allowOtherMenus { get { return false; } set { } }

        /// <summary> True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).</summary>
        public bool ignoreParentClicks { get { return false; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

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
