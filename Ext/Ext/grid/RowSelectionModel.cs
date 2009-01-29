using System;
using DotWeb.Core;

namespace Ext.grid {
    /// <summary>
    ///     /**
    ///     The default SelectionModel used by {@link Ext.grid.GridPanel}.
    ///     It supports multiple selections and keyboard selection/navigation. The objects stored
    ///     as selections and returned by {@link #getSelected}, and {@link #getSelections} are
    ///     the {@link Ext.data.Record Record}s which provide the data for the selected rows.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\grid\RowSelectionModel.js</jssource>
    [Native]
    public class RowSelectionModel : Ext.grid.AbstractSelectionModel {

        /// <summary></summary>
        /// <returns></returns>
        public RowSelectionModel() {}
        /// <summary></summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public RowSelectionModel(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static RowSelectionModel prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.grid.AbstractSelectionModel superclass { get { return null; } set { } }

        /// <summary>True to allow selection of only one row at a time (defaults to false)</summary>
        public bool singleSelect { get { return false; } set { } }

        /// <summary>False to turn off moving the editor to the next cell when the enter key is pressed</summary>
        public bool moveEditorOnEnter { get { return false; } set { } }


        /// <summary>Select records.</summary>
        /// <returns></returns>
        public virtual void selectRecords() { return ; }

        /// <summary>Select records.</summary>
        /// <param name="records">The records to select</param>
        /// <returns></returns>
        public virtual void selectRecords(System.Array records) { return ; }

        /// <summary>Select records.</summary>
        /// <param name="records">The records to select</param>
        /// <param name="keepExisting">(optional) True to keep existing selections</param>
        /// <returns></returns>
        public virtual void selectRecords(System.Array records, bool keepExisting) { return ; }

        /// <summary>Gets the number of selected rows.</summary>
        /// <returns>Number</returns>
        public virtual double getCount() { return 0; }

        /// <summary>Selects the first row in the grid.</summary>
        /// <returns></returns>
        public virtual void selectFirstRow() { return ; }

        /// <summary>Select the last row.</summary>
        /// <returns></returns>
        public virtual void selectLastRow() { return ; }

        /// <summary>Select the last row.</summary>
        /// <param name="keepExisting">(optional) True to keep existing selections</param>
        /// <returns></returns>
        public virtual void selectLastRow(bool keepExisting) { return ; }

        /// <summary>Selects the row immediately following the last selected row.</summary>
        /// <returns>Boolean</returns>
        public virtual bool selectNext() { return false; }

        /// <summary>Selects the row immediately following the last selected row.</summary>
        /// <param name="keepExisting">(optional) True to keep existing selections</param>
        /// <returns>Boolean</returns>
        public virtual bool selectNext(bool keepExisting) { return false; }

        /// <summary>Selects the row that precedes the last selected row.</summary>
        /// <returns>Boolean</returns>
        public virtual bool selectPrevious() { return false; }

        /// <summary>Selects the row that precedes the last selected row.</summary>
        /// <param name="keepExisting">(optional) True to keep existing selections</param>
        /// <returns>Boolean</returns>
        public virtual bool selectPrevious(bool keepExisting) { return false; }

        /// <summary>Returns true if there is a next record to select</summary>
        /// <returns>Boolean</returns>
        public virtual bool hasNext() { return false; }

        /// <summary>Returns true if there is a previous record to select</summary>
        /// <returns>Boolean</returns>
        public virtual bool hasPrevious() { return false; }

        /// <summary>Returns the selected records</summary>
        /// <returns>Array</returns>
        public virtual System.Array getSelections() { return null; }

        /// <summary>Returns the first selected record.</summary>
        /// <returns>Record</returns>
        public virtual Ext.data.Record getSelected() { return null; }

        /// <summary>
        ///     Calls the passed function with each selection. If the function returns false, iteration is
        ///     stopped and this function returns false. Otherwise it returns true.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool each() { return false; }

        /// <summary>
        ///     Calls the passed function with each selection. If the function returns false, iteration is
        ///     stopped and this function returns false. Otherwise it returns true.
        /// </summary>
        /// <param name="fn"></param>
        /// <returns>Boolean</returns>
        public virtual bool each(Delegate fn) { return false; }

        /// <summary>
        ///     Calls the passed function with each selection. If the function returns false, iteration is
        ///     stopped and this function returns false. Otherwise it returns true.
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="scope">(optional)</param>
        /// <returns>Boolean</returns>
        public virtual bool each(Delegate fn, object scope) { return false; }

        /// <summary>Clears all selections.</summary>
        /// <returns></returns>
        public virtual void clearSelections() { return ; }

        /// <summary>Selects all rows.</summary>
        /// <returns></returns>
        public virtual void selectAll() { return ; }

        /// <summary>Returns True if there is a selection.</summary>
        /// <returns>Boolean</returns>
        public virtual bool hasSelection() { return false; }

        /// <summary>Returns True if the specified row is selected.</summary>
        /// <returns>Boolean</returns>
        public virtual bool isSelected() { return false; }

        /// <summary>Returns True if the specified row is selected.</summary>
        /// <param name="record">The record or index of the record to check</param>
        /// <returns>Boolean</returns>
        public virtual bool isSelected(double record) { return false; }

        /// <summary>Returns True if the specified row is selected.</summary>
        /// <param name="record">The record or index of the record to check</param>
        /// <returns>Boolean</returns>
        public virtual bool isSelected(Ext.data.Record record) { return false; }

        /// <summary>Returns True if the specified record id is selected.</summary>
        /// <returns>Boolean</returns>
        public virtual bool isIdSelected() { return false; }

        /// <summary>Returns True if the specified record id is selected.</summary>
        /// <param name="id">The id of record to check</param>
        /// <returns>Boolean</returns>
        public virtual bool isIdSelected(System.String id) { return false; }

        /// <summary>Selects multiple rows.</summary>
        /// <returns></returns>
        public virtual void selectRows() { return ; }

        /// <summary>Selects multiple rows.</summary>
        /// <param name="rows">Array of the indexes of the row to select</param>
        /// <returns></returns>
        public virtual void selectRows(System.Array rows) { return ; }

        /// <summary>Selects multiple rows.</summary>
        /// <param name="rows">Array of the indexes of the row to select</param>
        /// <param name="keepExisting">(optional) True to keep existing selections (defaults to false)</param>
        /// <returns></returns>
        public virtual void selectRows(System.Array rows, bool keepExisting) { return ; }

        /// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
        /// <returns></returns>
        public virtual void selectRange() { return ; }

        /// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <returns></returns>
        public virtual void selectRange(double startRow) { return ; }

        /// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <param name="endRow">The index of the last row in the range</param>
        /// <returns></returns>
        public virtual void selectRange(double startRow, double endRow) { return ; }

        /// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <param name="endRow">The index of the last row in the range</param>
        /// <param name="keepExisting">(optional) True to retain existing selections</param>
        /// <returns></returns>
        public virtual void selectRange(double startRow, double endRow, bool keepExisting) { return ; }

        /// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
        /// <returns></returns>
        public virtual void deselectRange() { return ; }

        /// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <returns></returns>
        public virtual void deselectRange(double startRow) { return ; }

        /// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
        /// <param name="startRow">The index of the first row in the range</param>
        /// <param name="endRow">The index of the last row in the range</param>
        /// <returns></returns>
        public virtual void deselectRange(double startRow, double endRow) { return ; }

        /// <summary>Selects a row.</summary>
        /// <returns></returns>
        public virtual void selectRow() { return ; }

        /// <summary>Selects a row.</summary>
        /// <param name="row">The index of the row to select</param>
        /// <returns></returns>
        public virtual void selectRow(double row) { return ; }

        /// <summary>Selects a row.</summary>
        /// <param name="row">The index of the row to select</param>
        /// <param name="keepExisting">(optional) True to keep existing selections</param>
        /// <returns></returns>
        public virtual void selectRow(double row, bool keepExisting) { return ; }

        /// <summary>Deselects a row.</summary>
        /// <returns></returns>
        public virtual void deselectRow() { return ; }

        /// <summary>Deselects a row.</summary>
        /// <param name="row">The index of the row to deselect</param>
        /// <returns></returns>
        public virtual void deselectRow(double row) { return ; }



    }
    [Anonymous]
    public class RowSelectionModelConfig {

        /// <summary>  True to allow selection of only one row at a time (defaults to false)</summary>
        public bool singleSelect { get { return false; } set { } }

        /// <summary>  False to turn off moving the editor to the next cell when the enter key is pressed</summary>
        public bool moveEditorOnEnter { get { return false; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }

    public class RowSelectionModelEvents {
        /// <summary>Fires when the selection changes
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string selectionchange { get { return "selectionchange"; } }
        /// <summary>Fires when a row is being selected, return false to cancel.
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis, {Number} rowIndex, {Boolean} keepExisting, {Record} record)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description>The index to be selected</description></item>
        /// <item><term><b>keepExisting</b></term><description>False if other selections will be cleared</description></item>
        /// <item><term><b>record</b></term><description>The record to be selected</description></item>
        /// </list>
        /// </summary>
        public static string beforerowselect { get { return "beforerowselect"; } }
        /// <summary>Fires when a row is selected.
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis, {Number} rowIndex, {Ext.data.Record} r)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description>The selected index</description></item>
        /// <item><term><b>r</b></term><description>The selected record</description></item>
        /// </list>
        /// </summary>
        public static string rowselect { get { return "rowselect"; } }
        /// <summary>Fires when a row is deselected.
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis, {Number} rowIndex, {Record} record)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description></description></item>
        /// <item><term><b>record</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string rowdeselect { get { return "rowdeselect"; } }
    }

    public delegate void RowSelectionModelSelectionchangeDelegate(object objthis);
    public delegate void RowSelectionModelBeforerowselectDelegate(object objthis, double rowIndex, bool keepExisting, Ext.data.Record record);
    public delegate void RowSelectionModelRowselectDelegate(object objthis, double rowIndex, Ext.data.Record r);
    public delegate void RowSelectionModelRowdeselectDelegate(object objthis, double rowIndex, Ext.data.Record record);
}
