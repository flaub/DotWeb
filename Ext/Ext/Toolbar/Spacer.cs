using System;
using DotWeb.Core;

namespace Ext.Toolbar {
    /// <summary>
    ///     /**
    ///     A simple element that adds extra horizontal space between items in a toolbar.
    ///     <pre><code>
    ///     new Ext.Panel({
    ///     tbar : [
    ///     'Item 1',
    ///     {xtype: 'tbspacer'}, // or ' '
    ///     'Item 2'
    ///     ]
    ///     });
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\Toolbar.js</jssource>
    [Native]
    public class Spacer : Ext.Toolbar.Item {

        /// <summary>Creates a new Spacer</summary>
        /// <returns></returns>
        public Spacer() {}
        /// <summary>Creates a new Item</summary>
        /// <param name="el"></param>
        /// <returns></returns>
        public Spacer(DOMElement el) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Spacer prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.Toolbar.Item superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class SpacerConfig {

    }


}
