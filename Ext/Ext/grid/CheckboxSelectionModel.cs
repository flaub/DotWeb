using System;
using DotWeb.Core;

namespace Ext.grid {
    /// <summary>
    ///     /**
    ///     A custom selection model that renders a column of checkboxes that can be toggled to select or deselect rows.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\grid\CheckboxSelectionModel.js</jssource>
    [Native]
    public class CheckboxSelectionModel : Ext.grid.RowSelectionModel {

        /// <summary></summary>
        /// <returns></returns>
        public CheckboxSelectionModel() {}
        /// <summary></summary>
        /// <param name="config">The configuration options</param>
        /// <returns></returns>
        public CheckboxSelectionModel(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static CheckboxSelectionModel prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.grid.RowSelectionModel superclass { get { return null; } set { } }

        /// <summary>
        ///     Any valid text or HTML fragment to display in the header cell for the checkbox column(defaults to '&lt;div class="x-grid3-hd-checker">&#160;&lt;/div>').  The default CSS class of 'x-grid3-hd-checker'
        ///     displays a checkbox in the header and provides support for automatic check all/none behavior on header click.
        ///     This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but
        ///     the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.
        /// </summary>
        public System.String header { get { return null; } set { } }

        /// <summary>The default width in pixels of the checkbox column (defaults to 20).</summary>
        public double width { get { return 0; } set { } }

        /// <summary>True if the checkbox column is sortable (defaults to false).</summary>
        public bool sortable { get { return false; } set { } }




    }
    [Anonymous]
    public class CheckboxSelectionModelConfig {

        /// <summary> Any valid text or HTML fragment to display in the header cell for the checkbox column (defaults to '&lt;div class="x-grid3-hd-checker">&#160;&lt;/div>').  The default CSS class of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for automatic check all/none behavior on header click. This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.</summary>
        public System.String header { get { return null; } set { } }

        /// <summary> The default width in pixels of the checkbox column (defaults to 20).</summary>
        public double width { get { return 0; } set { } }

        /// <summary> True if the checkbox column is sortable (defaults to false).</summary>
        public bool sortable { get { return false; } set { } }

        /// <summary>  True to allow selection of only one row at a time (defaults to false)</summary>
        public bool singleSelect { get { return false; } set { } }

        /// <summary>  False to turn off moving the editor to the next cell when the enter key is pressed</summary>
        public bool moveEditorOnEnter { get { return false; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }


}
