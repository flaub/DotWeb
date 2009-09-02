using System;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     The default SelectionModel used by {@link Ext.grid.GridPanel}.
	///     It supports multiple selections and keyboard selection/navigation. The objects stored
	///     as selections and returned by {@link #getSelected}, and {@link #getSelections} are
	///     the {@link Ext.data.Record Record}s which provide the data for the selected rows.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\grid\RowSelectionModel.js</jssource>
	public class RowSelectionModel : Ext.grid.AbstractSelectionModel {

		/// <summary></summary>
		/// <returns></returns>
		public RowSelectionModel() { C_(); }
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public RowSelectionModel(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static RowSelectionModel prototype { get { return S_<RowSelectionModel>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.grid.AbstractSelectionModel superclass { get { return S_<Ext.grid.AbstractSelectionModel>(); } set { S_(value); } }

		/// <summary>True to allow selection of only one row at a time (defaults to false)</summary>
		public bool singleSelect { get { return _<bool>(); } set { _(value); } }

		/// <summary>False to turn off moving the editor to the next cell when the enter key is pressed</summary>
		public bool moveEditorOnEnter { get { return _<bool>(); } set { _(value); } }


		/// <summary>Select records.</summary>
		/// <returns></returns>
		public virtual void selectRecords() { _(); }

		/// <summary>Select records.</summary>
		/// <param name="records">The records to select</param>
		/// <returns></returns>
		public virtual void selectRecords(System.Array records) { _(records); }

		/// <summary>Select records.</summary>
		/// <param name="records">The records to select</param>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns></returns>
		public virtual void selectRecords(System.Array records, bool keepExisting) { _(records, keepExisting); }

		/// <summary>Gets the number of selected rows.</summary>
		/// <returns>Number</returns>
		public virtual void getCount() { _(); }

		/// <summary>Selects the first row in the grid.</summary>
		/// <returns></returns>
		public virtual void selectFirstRow() { _(); }

		/// <summary>Select the last row.</summary>
		/// <returns></returns>
		public virtual void selectLastRow() { _(); }

		/// <summary>Select the last row.</summary>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns></returns>
		public virtual void selectLastRow(bool keepExisting) { _(keepExisting); }

		/// <summary>Selects the row immediately following the last selected row.</summary>
		/// <returns>Boolean</returns>
		public virtual void selectNext() { _(); }

		/// <summary>Selects the row immediately following the last selected row.</summary>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns>Boolean</returns>
		public virtual void selectNext(bool keepExisting) { _(keepExisting); }

		/// <summary>Selects the row that precedes the last selected row.</summary>
		/// <returns>Boolean</returns>
		public virtual void selectPrevious() { _(); }

		/// <summary>Selects the row that precedes the last selected row.</summary>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns>Boolean</returns>
		public virtual void selectPrevious(bool keepExisting) { _(keepExisting); }

		/// <summary>Returns true if there is a next record to select</summary>
		/// <returns>Boolean</returns>
		public virtual void hasNext() { _(); }

		/// <summary>Returns true if there is a previous record to select</summary>
		/// <returns>Boolean</returns>
		public virtual void hasPrevious() { _(); }

		/// <summary>Returns the selected records</summary>
		/// <returns>Array</returns>
		public virtual void getSelections() { _(); }

		/// <summary>Returns the first selected record.</summary>
		/// <returns>Record</returns>
		public virtual void getSelected() { _(); }

		/// <summary>
		///     Calls the passed function with each selection. If the function returns false, iteration is
		///     stopped and this function returns false. Otherwise it returns true.
		/// </summary>
		/// <returns>Boolean</returns>
		public virtual void each() { _(); }

		/// <summary>
		///     Calls the passed function with each selection. If the function returns false, iteration is
		///     stopped and this function returns false. Otherwise it returns true.
		/// </summary>
		/// <param name="fn"></param>
		/// <returns>Boolean</returns>
		public virtual void each(Delegate fn) { _(fn); }

		/// <summary>
		///     Calls the passed function with each selection. If the function returns false, iteration is
		///     stopped and this function returns false. Otherwise it returns true.
		/// </summary>
		/// <param name="fn"></param>
		/// <param name="scope">(optional)</param>
		/// <returns>Boolean</returns>
		public virtual void each(Delegate fn, object scope) { _(fn, scope); }

		/// <summary>Clears all selections.</summary>
		/// <returns></returns>
		public virtual void clearSelections() { _(); }

		/// <summary>Selects all rows.</summary>
		/// <returns></returns>
		public virtual void selectAll() { _(); }

		/// <summary>Returns True if there is a selection.</summary>
		/// <returns>Boolean</returns>
		public virtual void hasSelection() { _(); }

		/// <summary>Returns True if the specified row is selected.</summary>
		/// <returns>Boolean</returns>
		public virtual void isSelected() { _(); }

		/// <summary>Returns True if the specified row is selected.</summary>
		/// <param name="record">The record or index of the record to check</param>
		/// <returns>Boolean</returns>
		public virtual void isSelected(double record) { _(record); }

		/// <summary>Returns True if the specified row is selected.</summary>
		/// <param name="record">The record or index of the record to check</param>
		/// <returns>Boolean</returns>
		public virtual void isSelected(Ext.data.Record record) { _(record); }

		/// <summary>Returns True if the specified record id is selected.</summary>
		/// <returns>Boolean</returns>
		public virtual void isIdSelected() { _(); }

		/// <summary>Returns True if the specified record id is selected.</summary>
		/// <param name="id">The id of record to check</param>
		/// <returns>Boolean</returns>
		public virtual void isIdSelected(System.String id) { _(id); }

		/// <summary>Selects multiple rows.</summary>
		/// <returns></returns>
		public virtual void selectRows() { _(); }

		/// <summary>Selects multiple rows.</summary>
		/// <param name="rows">Array of the indexes of the row to select</param>
		/// <returns></returns>
		public virtual void selectRows(System.Array rows) { _(rows); }

		/// <summary>Selects multiple rows.</summary>
		/// <param name="rows">Array of the indexes of the row to select</param>
		/// <param name="keepExisting">(optional) True to keep existing selections (defaults to false)</param>
		/// <returns></returns>
		public virtual void selectRows(System.Array rows, bool keepExisting) { _(rows, keepExisting); }

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <returns></returns>
		public virtual void selectRange() { _(); }

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <returns></returns>
		public virtual void selectRange(double startRow) { _(startRow); }

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <param name="endRow">The index of the last row in the range</param>
		/// <returns></returns>
		public virtual void selectRange(double startRow, double endRow) { _(startRow, endRow); }

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <param name="endRow">The index of the last row in the range</param>
		/// <param name="keepExisting">(optional) True to retain existing selections</param>
		/// <returns></returns>
		public virtual void selectRange(double startRow, double endRow, bool keepExisting) { _(startRow, endRow, keepExisting); }

		/// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
		/// <returns></returns>
		public virtual void deselectRange() { _(); }

		/// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <returns></returns>
		public virtual void deselectRange(double startRow) { _(startRow); }

		/// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <param name="endRow">The index of the last row in the range</param>
		/// <returns></returns>
		public virtual void deselectRange(double startRow, double endRow) { _(startRow, endRow); }

		/// <summary>Selects a row.</summary>
		/// <returns></returns>
		public virtual void selectRow() { _(); }

		/// <summary>Selects a row.</summary>
		/// <param name="row">The index of the row to select</param>
		/// <returns></returns>
		public virtual void selectRow(double row) { _(row); }

		/// <summary>Selects a row.</summary>
		/// <param name="row">The index of the row to select</param>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns></returns>
		public virtual void selectRow(double row, bool keepExisting) { _(row, keepExisting); }

		/// <summary>Deselects a row.</summary>
		/// <returns></returns>
		public virtual void deselectRow() { _(); }

		/// <summary>Deselects a row.</summary>
		/// <param name="row">The index of the row to deselect</param>
		/// <returns></returns>
		public virtual void deselectRow(double row) { _(row); }



	}

	[JsAnonymous]
	public class RowSelectionModelConfig : DotWeb.Client.JsAccessible {
		/// <summary>  True to allow selection of only one row at a time (defaults to false)</summary>
		public bool singleSelect { get; set; }

		/// <summary>  False to turn off moving the editor to the next cell when the enter key is pressed</summary>
		public bool moveEditorOnEnter { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

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
