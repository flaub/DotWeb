using System;
using H8.Support;

namespace Ext.Toolbar {
    /// <summary>
    ///     /**
    ///     A simple class that renders text directly into a toolbar.
    ///     <pre><code>
    ///     new Ext.Panel({
    ///     tbar : [
    ///     {xtype: 'tbtext', text: 'Item 1'} // or simply 'Item 1'
    ///     ]
    ///     });
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\Toolbar.js</jssource>
    [Native]
    public class TextItem : Ext.Toolbar.Item {

        /// <summary>Creates a new TextItem</summary>
        /// <returns></returns>
        public TextItem() {}
        /// <summary>Creates a new TextItem</summary>
        /// <param name="text">A text string, or a config object containing a <tt>text</tt> property</param>
        /// <returns></returns>
        public TextItem(System.String text) {}
        /// <summary>Creates a new TextItem</summary>
        /// <param name="text">A text string, or a config object containing a <tt>text</tt> property</param>
        /// <returns></returns>
        public TextItem(object text) {}
        /// <summary>Creates a new Item</summary>
        /// <param name="el"></param>
        /// <returns></returns>
        public TextItem(DOMElement el) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TextItem prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.Toolbar.Item superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class TextItemConfig {

    }


}
