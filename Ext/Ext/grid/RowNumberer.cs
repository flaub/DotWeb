using System;
using DotWeb.Core;

namespace Ext.grid {
    /// <summary>
    ///     /**
    ///     This is a utility class that can be passed into a {@link Ext.grid.ColumnModel} as a column config that provides
    ///     an automatic row numbering column.
    ///     <br>Usage:<br>
    ///     <pre><code>
    ///     // This is a typical column config with the first column providing row numbers
    ///     var colModel = new Ext.grid.ColumnModel([
    ///     new Ext.grid.RowNumberer(),
    ///     {header: "Name", width: 80, sortable: true},
    ///     {header: "Code", width: 50, sortable: true},
    ///     {header: "Description", width: 200, sortable: true}
    ///     ]);
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\grid\RowNumberer.js</jssource>
    [Native]
    public class RowNumberer  {

        /// <summary></summary>
        /// <returns></returns>
        public RowNumberer() {}
        /// <summary></summary>
        /// <param name="config">The configuration options</param>
        /// <returns></returns>
        public RowNumberer(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static RowNumberer prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>Any valid text or HTML fragment to display in the header cell for the rownumber column (defaults to '').</summary>
        public System.String header { get { return null; } set { } }

        /// <summary>The default width in pixels of the row number column (defaults to 23).</summary>
        public double width { get { return 0; } set { } }

        /// <summary>True if the row number column is sortable (defaults to false).</summary>
        public bool sortable { get { return false; } set { } }




    }
    [Anonymous]
    public class RowNumbererConfig {

        /// <summary> Any valid text or HTML fragment to display in the header cell for the row number column (defaults to '').</summary>
        public System.String header { get { return null; } set { } }

        /// <summary> The default width in pixels of the row number column (defaults to 23).</summary>
        public double width { get { return 0; } set { } }

        /// <summary> True if the row number column is sortable (defaults to false).</summary>
        public bool sortable { get { return false; } set { } }

    }


}
