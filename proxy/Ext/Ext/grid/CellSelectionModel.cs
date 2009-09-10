using System;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     This class provides the basic implementation for single cell selection in a grid. The object stored
	///     as the selection and returned by {@link getSelectedCell} contains the following properties:
	///     <div class="mdetail-params"><ul>
	///     <li><b>record</b> : Ext.data.record<p class="sub-desc">The {@link Ext.data.Record Record}
	///     which provides the data for the row containing the selection</p></li>
	///     <li><b>cell</b> : Ext.data.record<p class="sub-desc">An object containing the
	///     following properties:
	///     <div class="mdetail-params"><ul>
	///     <li><b>rowIndex</b> : Number<p class="sub-desc">The index of the selected row</p></li>
	///     <li><b>cellIndex</b> : Number<p class="sub-desc">The index of the selected cell<br>
	///     <b>Note that due to possible column reordering, the cellIndex should not be used as an index into
	///     the Record's data. Instead, the <i>name</i> of the selected field should be determined
	///     in order to retrieve the data value from the record by name:</b><pre><code>
	///     var fieldName = grid.getColumnModel().getDataIndex(cellIndex);
	///     var data = record.get(fieldName);
	///     </code></pre></p></li>
	///     </ul></div></p></li>
	///     </ul></div>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\CellSelectionModel.js</jssource>
	public class CellSelectionModel : Ext.grid.AbstractSelectionModel {

		/// <summary></summary>
		/// <returns></returns>
		public CellSelectionModel() { C_(); }
		/// <summary></summary>
		/// <param name="config">The object containing the configuration of this model.</param>
		/// <returns></returns>
		public CellSelectionModel(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static CellSelectionModel prototype { get { return S_<CellSelectionModel>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.grid.AbstractSelectionModel superclass { get { return S_<Ext.grid.AbstractSelectionModel>(); } set { S_(value); } }


		/// <summary>Returns the currently selected cell's row and column indexes as an array (e.g., [0, 0]).</summary>
		/// <returns>Array</returns>
		public virtual void getSelectedCell() { _(); }

		/// <summary>Clears all selections.</summary>
		/// <returns></returns>
		public virtual void clearSelections() { _(); }

		/// <summary>Clears all selections.</summary>
		/// <param name="b">to prevent the gridview from being notified about the change.</param>
		/// <returns></returns>
		public virtual void clearSelections(bool b) { _(b); }

		/// <summary>Returns true if there is a selection.</summary>
		/// <returns>Boolean</returns>
		public virtual void hasSelection() { _(); }

		/// <summary>Selects a cell.</summary>
		/// <returns></returns>
		public virtual void select() { _(); }

		/// <summary>Selects a cell.</summary>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		public virtual void select(double rowIndex) { _(rowIndex); }

		/// <summary>Selects a cell.</summary>
		/// <param name="rowIndex"></param>
		/// <param name="collIndex"></param>
		/// <returns></returns>
		public virtual void select(double rowIndex, double collIndex) { _(rowIndex, collIndex); }



	}

	[JsAnonymous]
	public class CellSelectionModelConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return _<object>(); } set { _(value); } }

	}

    public class CellSelectionModelEvents {
        /// <summary>Fires before a cell is selected.
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis, {Number} rowIndex, {Number} colIndex)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description>The selected row index</description></item>
        /// <item><term><b>colIndex</b></term><description>The selected cell index</description></item>
        /// </list>
        /// </summary>
        public static string beforecellselect { get { return "beforecellselect"; } }
        /// <summary>Fires when a cell is selected.
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis, {Number} rowIndex, {Number} colIndex)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description>The selected row index</description></item>
        /// <item><term><b>colIndex</b></term><description>The selected cell index</description></item>
        /// </list>
        /// </summary>
        public static string cellselect { get { return "cellselect"; } }
        /// <summary>
        ///     Fires when the active selection changes.
        ///     <ul>
        ///     <li>o.record: the record object for the row the selection is in</li>
        ///     <li>o.cell: An array of [rowIndex, columnIndex]</li>
        ///     </ul>
        /// 
        /// <pre><code>
        /// USAGE: ({SelectionModel} objthis, {Object} selection)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>selection</b></term><description>null for no selection or an object (o) with two properties</description></item>
        /// </list>
        /// </summary>
        public static string selectionchange { get { return "selectionchange"; } }
    }

    public delegate void CellSelectionModelBeforecellselectDelegate(object objthis, double rowIndex, double colIndex);
    public delegate void CellSelectionModelCellselectDelegate(object objthis, double rowIndex, double colIndex);
    public delegate void CellSelectionModelSelectionchangeDelegate(object objthis, object selection);
}
