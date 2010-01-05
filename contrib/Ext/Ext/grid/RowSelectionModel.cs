using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     The default SelectionModel used by {@link Ext.grid.GridPanel}.
	///     It supports multiple selections and keyboard selection/navigation. The objects stored
	///     as selections and returned by {@link #getSelected}, and {@link #getSelections} are
	///     the {@link Ext.data.Record Record}s which provide the data for the selected rows.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\RowSelectionModel.js</jssource>
	public class RowSelectionModel : Ext.grid.AbstractSelectionModel {

		/// <summary></summary>
		/// <returns></returns>
		public extern RowSelectionModel();
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern RowSelectionModel(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static RowSelectionModel prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.grid.AbstractSelectionModel superclass { get; set; }

		/// <summary>True to allow selection of only one row at a time (defaults to false)</summary>
		public extern bool singleSelect { get; set; }

		/// <summary>False to turn off moving the editor to the next cell when the enter key is pressed</summary>
		public extern bool moveEditorOnEnter { get; set; }


		/// <summary>Select records.</summary>
		/// <returns></returns>
		public extern virtual void selectRecords();

		/// <summary>Select records.</summary>
		/// <param name="records">The records to select</param>
		/// <returns></returns>
		public extern virtual void selectRecords(System.Array records);

		/// <summary>Select records.</summary>
		/// <param name="records">The records to select</param>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns></returns>
		public extern virtual void selectRecords(System.Array records, bool keepExisting);

		/// <summary>Gets the number of selected rows.</summary>
		/// <returns>Number</returns>
		public extern virtual void getCount();

		/// <summary>Selects the first row in the grid.</summary>
		/// <returns></returns>
		public extern virtual void selectFirstRow();

		/// <summary>Select the last row.</summary>
		/// <returns></returns>
		public extern virtual void selectLastRow();

		/// <summary>Select the last row.</summary>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns></returns>
		public extern virtual void selectLastRow(bool keepExisting);

		/// <summary>Selects the row immediately following the last selected row.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void selectNext();

		/// <summary>Selects the row immediately following the last selected row.</summary>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns>Boolean</returns>
		public extern virtual void selectNext(bool keepExisting);

		/// <summary>Selects the row that precedes the last selected row.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void selectPrevious();

		/// <summary>Selects the row that precedes the last selected row.</summary>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns>Boolean</returns>
		public extern virtual void selectPrevious(bool keepExisting);

		/// <summary>Returns true if there is a next record to select</summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasNext();

		/// <summary>Returns true if there is a previous record to select</summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasPrevious();

		/// <summary>Returns the selected records</summary>
		/// <returns>Array</returns>
		public extern virtual void getSelections();

		/// <summary>Returns the first selected record.</summary>
		/// <returns>Record</returns>
		public extern virtual void getSelected();

		/// <summary>
		///     Calls the passed function with each selection. If the function returns false, iteration is
		///     stopped and this function returns false. Otherwise it returns true.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void each();

		/// <summary>
		///     Calls the passed function with each selection. If the function returns false, iteration is
		///     stopped and this function returns false. Otherwise it returns true.
		/// </summary>
		/// <param name="fn"></param>
		/// <returns>Boolean</returns>
		public extern virtual void each(Delegate fn);

		/// <summary>
		///     Calls the passed function with each selection. If the function returns false, iteration is
		///     stopped and this function returns false. Otherwise it returns true.
		/// </summary>
		/// <param name="fn"></param>
		/// <param name="scope">(optional)</param>
		/// <returns>Boolean</returns>
		public extern virtual void each(Delegate fn, object scope);

		/// <summary>Clears all selections.</summary>
		/// <returns></returns>
		public extern virtual void clearSelections();

		/// <summary>Selects all rows.</summary>
		/// <returns></returns>
		public extern virtual void selectAll();

		/// <summary>Returns True if there is a selection.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasSelection();

		/// <summary>Returns True if the specified row is selected.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isSelected();

		/// <summary>Returns True if the specified row is selected.</summary>
		/// <param name="record">The record or index of the record to check</param>
		/// <returns>Boolean</returns>
		public extern virtual void isSelected(double record);

		/// <summary>Returns True if the specified row is selected.</summary>
		/// <param name="record">The record or index of the record to check</param>
		/// <returns>Boolean</returns>
		public extern virtual void isSelected(Ext.data.Record record);

		/// <summary>Returns True if the specified record id is selected.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isIdSelected();

		/// <summary>Returns True if the specified record id is selected.</summary>
		/// <param name="id">The id of record to check</param>
		/// <returns>Boolean</returns>
		public extern virtual void isIdSelected(string id);

		/// <summary>Selects multiple rows.</summary>
		/// <returns></returns>
		public extern virtual void selectRows();

		/// <summary>Selects multiple rows.</summary>
		/// <param name="rows">Array of the indexes of the row to select</param>
		/// <returns></returns>
		public extern virtual void selectRows(System.Array rows);

		/// <summary>Selects multiple rows.</summary>
		/// <param name="rows">Array of the indexes of the row to select</param>
		/// <param name="keepExisting">(optional) True to keep existing selections (defaults to false)</param>
		/// <returns></returns>
		public extern virtual void selectRows(System.Array rows, bool keepExisting);

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <returns></returns>
		public extern virtual void selectRange();

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <returns></returns>
		public extern virtual void selectRange(double startRow);

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <param name="endRow">The index of the last row in the range</param>
		/// <returns></returns>
		public extern virtual void selectRange(double startRow, double endRow);

		/// <summary>Selects a range of rows. All rows in between startRow and endRow are also selected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <param name="endRow">The index of the last row in the range</param>
		/// <param name="keepExisting">(optional) True to retain existing selections</param>
		/// <returns></returns>
		public extern virtual void selectRange(double startRow, double endRow, bool keepExisting);

		/// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
		/// <returns></returns>
		public extern virtual void deselectRange();

		/// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <returns></returns>
		public extern virtual void deselectRange(double startRow);

		/// <summary>Deselects a range of rows. All rows in between startRow and endRow are also deselected.</summary>
		/// <param name="startRow">The index of the first row in the range</param>
		/// <param name="endRow">The index of the last row in the range</param>
		/// <returns></returns>
		public extern virtual void deselectRange(double startRow, double endRow);

		/// <summary>Selects a row.</summary>
		/// <returns></returns>
		public extern virtual void selectRow();

		/// <summary>Selects a row.</summary>
		/// <param name="row">The index of the row to select</param>
		/// <returns></returns>
		public extern virtual void selectRow(double row);

		/// <summary>Selects a row.</summary>
		/// <param name="row">The index of the row to select</param>
		/// <param name="keepExisting">(optional) True to keep existing selections</param>
		/// <returns></returns>
		public extern virtual void selectRow(double row, bool keepExisting);

		/// <summary>Deselects a row.</summary>
		/// <returns></returns>
		public extern virtual void deselectRow();

		/// <summary>Deselects a row.</summary>
		/// <param name="row">The index of the row to deselect</param>
		/// <returns></returns>
		public extern virtual void deselectRow(double row);



	}

	[JsAnonymous]
	public class RowSelectionModelConfig : System.DotWeb.JsDynamic {
		/// <summary>  True to allow selection of only one row at a time (defaults to false)</summary>
		public bool singleSelect { get { return (bool)this["singleSelect"]; } set { this["singleSelect"] = value; } }

		/// <summary>  False to turn off moving the editor to the next cell when the enter key is pressed</summary>
		public bool moveEditorOnEnter { get { return (bool)this["moveEditorOnEnter"]; } set { this["moveEditorOnEnter"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

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
