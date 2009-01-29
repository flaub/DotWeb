using System;
using DotWeb.Core;

namespace Ext.Toolbar {
    /// <summary>
    ///     /**
    ///     A simple element that adds a greedy (100% width) horizontal space between items in a toolbar.
    ///     <pre><code>
    ///     new Ext.Panel({
    ///     tbar : [
    ///     'Item 1',
    ///     {xtype: 'tbfill'}, // or '->'
    ///     'Item 2'
    ///     ]
    ///     });
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\Toolbar.js</jssource>
    [Native]
    public class Fill : Ext.Toolbar.Spacer {

        /// <summary>Creates a new Spacer</summary>
        /// <returns></returns>
        public Fill() {}
        /// <summary>Creates a new Item</summary>
        /// <param name="el"></param>
        /// <returns></returns>
        public Fill(DOMElement el) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Fill prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.Toolbar.Spacer superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class FillConfig {

    }


}
