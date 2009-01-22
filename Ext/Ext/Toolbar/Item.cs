using System;
using H8.Support;

namespace Ext.Toolbar {
    /// <summary>
    ///     /**
    ///     The base class that other classes should extend in order to get some basic common toolbar item functionality.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\Toolbar.js</jssource>
    [Native]
    public class Item  {

        /// <summary>Creates a new Item</summary>
        /// <returns></returns>
        public Item() {}
        /// <summary>Creates a new Item</summary>
        /// <param name="el"></param>
        /// <returns></returns>
        public Item(DOMElement el) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Item prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Get this item's HTML Element</summary>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement getEl() { return null; }

        /// <summary>Removes and destroys this item.</summary>
        /// <returns></returns>
        public virtual void destroy() { return ; }

        /// <summary>Shows this item.</summary>
        /// <returns></returns>
        public virtual void show() { return ; }

        /// <summary>Hides this item.</summary>
        /// <returns></returns>
        public virtual void hide() { return ; }

        /// <summary>Convenience function for boolean show/hide.</summary>
        /// <returns></returns>
        public virtual void setVisible() { return ; }

        /// <summary>Convenience function for boolean show/hide.</summary>
        /// <param name="visible">true to show/false to hide</param>
        /// <returns></returns>
        public virtual void setVisible(bool visible) { return ; }

        /// <summary>Try to focus this item</summary>
        /// <returns></returns>
        public virtual void focus() { return ; }

        /// <summary>Disables this item.</summary>
        /// <returns></returns>
        public virtual void disable() { return ; }

        /// <summary>Enables this item.</summary>
        /// <returns></returns>
        public virtual void enable() { return ; }



    }
    [Anonymous]
    public class ItemConfig {

    }


}
