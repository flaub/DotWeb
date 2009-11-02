using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     This is the default implementation of a ColumnModel used by the Grid. This class is initialized
	///     with an Array of column config objects.
	///     <br><br>
	///     An individual column's config object defines the header string, the {@link Ext.data.Record}
	///     field the column draws its data from, an optional rendering function to provide customized
	///     data formatting, and the ability to apply a CSS class to all cells in a column through its
	///     {@link #id} config option.<br>
	///     <br>Usage:<br>
	///     <pre><code>
	///     var colModel = new Ext.grid.ColumnModel([
	///     {header: "Ticker", width: 60, sortable: true},
	///     {header: "Company Name", width: 150, sortable: true},
	///     {header: "Market Cap.", width: 100, sortable: true},
	///     {header: "$ Sales", width: 100, sortable: true, renderer: money},
	///     {header: "Employees", width: 100, sortable: true, resizable: false}
	///     ]);
	///     </code></pre>
	///     <p>
	///     The config options <b>defined by</b< this class are options which may appear in each
	///     individual column definition.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\ColumnModel.js</jssource>
	public class ColumnModel : Ext.util.Observable {

		/// <summary>config objects for details.</summary>
		/// <returns></returns>
		public extern ColumnModel();
		/// <summary>config objects for details.</summary>
		/// <param name="config">An Array of column config objects. See this class's</param>
		/// <returns></returns>
		public extern ColumnModel(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ColumnModel prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>The width of columns which have no width specified (defaults to 100)</summary>
		public extern double defaultWidth { get; set; }

		/// <summary>Default sortable of columns which have no sortable specified (defaults to false)</summary>
		public extern bool defaultSortable { get; set; }

		/// <summary>The config passed into the constructor</summary>
		public extern System.Array config { get; set; }

		/// <summary>
		///     (optional) Defaults to the column's initial ordinal position.A name which identifies this column. The id is used to create a CSS class name which
		///     is applied to all table cells (including headers) in that column. The class name
		///     takes the form of <pre>x-grid3-td-<b>id</b></pre>
		///     <br><br>
		///     Header cells will also recieve this class name, but will also have the class <pr>x-grid3-hd</pre>,
		///     so to target header cells, use CSS selectors such as:<pre>.x-grid3-hd.x-grid3-td-<b>id</b></pre>
		///     The {@link Ext.grid.GridPanel#autoExpandColumn} grid config option references the column
		///     via this identifier.
		/// </summary>
		public extern string id { get; set; }

		/// <summary>The header text to display in the Grid view.</summary>
		public extern string header { get; set; }

		/// <summary>
		///     (optional) The name of the field in the grid's {@link Ext.data.Store}'s{@link Ext.data.Record} definition from which to draw the column's value. If not
		///     specified, the column's index is used as an index into the Record's data Array.
		/// </summary>
		public extern string dataIndex { get; set; }

		/// <summary>(optional) The initial width in pixels of the column.</summary>
		public extern double width { get; set; }

		/// <summary>
		///     (optional) True if sorting is to be allowed on this column.Defaults to the value of the {@link #defaultSortable} property.
		///     Whether local/remote sorting is used is specified in {@link Ext.data.Store#remoteSort}.
		/// </summary>
		public extern bool sortable { get; set; }

		/// <summary>(optional) True if the column width cannot be changed.  Defaults to false.</summary>
		public extern bool fixed_ { get; set; }

		/// <summary>(optional) False to disable column resizing. Defaults to true.</summary>
		public extern bool resizable { get; set; }

		/// <summary>(optional) True to disable the column menu. Defaults to false.</summary>
		public extern bool menuDisabled { get; set; }

		/// <summary>(optional) True to hide the column. Defaults to false.</summary>
		public extern bool hidden { get; set; }

		/// <summary>
		///     (optional) A text string to use as the column header's tooltip.  If Quicktips are enabled, thisvalue will be used as the text of the quick tip, otherwise it will be set as the header's HTML title attribute.
		///     Defaults to ''.
		/// </summary>
		public extern string tooltip { get; set; }

		/// <summary>
		///     (optional) A function used to generate HTML markup for a cellgiven the cell's data value. See {@link #setRenderer}. If not specified, the
		///     default renderer uses the raw data value.
		/// </summary>
		public extern Delegate renderer { get; set; }

		/// <summary>(optional) Set the CSS text-align property of the column.  Defaults to undefined.</summary>
		public extern string align { get; set; }

		/// <summary>(optional) Set custom CSS for all table cells in the column (excluding headers).  Defaults to undefined.</summary>
		public extern string css { get; set; }

		/// <summary>
		///     (optional) Specify as <tt>false</tt> to prevent the user from hiding this column(defaults to true).  To disallow column hiding globally for all columns in the grid, use
		///     {@link Ext.grid.GridPanel#enableColumnHide} instead.
		/// </summary>
		public extern bool hideable { get; set; }

		/// <summary>(optional) The {@link Ext.form.Field} to use when editing values in this column ifediting is supported by the grid.</summary>
		public extern Ext.form.Field editor { get; set; }


		/// <summary>Returns the id of the column at the specified index.</summary>
		/// <returns>String</returns>
		public extern virtual void getColumnId();

		/// <summary>Returns the id of the column at the specified index.</summary>
		/// <param name="index">The column index</param>
		/// <returns>String</returns>
		public extern virtual void getColumnId(double index);

		/// <summary>Reconfigures this column model</summary>
		/// <returns></returns>
		public extern virtual void setConfig();

		/// <summary>Reconfigures this column model</summary>
		/// <param name="config">Array of Column configs</param>
		/// <returns></returns>
		public extern virtual void setConfig(System.Array config);

		/// <summary>Returns the column for a specified id.</summary>
		/// <returns>Object</returns>
		public extern virtual void getColumnById();

		/// <summary>Returns the column for a specified id.</summary>
		/// <param name="id">The column id</param>
		/// <returns>Object</returns>
		public extern virtual void getColumnById(string id);

		/// <summary>Returns the index for a specified column id.</summary>
		/// <returns>Number</returns>
		public extern virtual void getIndexById();

		/// <summary>Returns the index for a specified column id.</summary>
		/// <param name="id">The column id</param>
		/// <returns>Number</returns>
		public extern virtual void getIndexById(string id);

		/// <summary>Moves a column from one position to another.</summary>
		/// <returns></returns>
		public extern virtual void moveColumn();

		/// <summary>Moves a column from one position to another.</summary>
		/// <param name="oldIndex">The index of the column to move.</param>
		/// <returns></returns>
		public extern virtual void moveColumn(double oldIndex);

		/// <summary>Moves a column from one position to another.</summary>
		/// <param name="oldIndex">The index of the column to move.</param>
		/// <param name="newIndex">The position at which to reinsert the coolumn.</param>
		/// <returns></returns>
		public extern virtual void moveColumn(double oldIndex, double newIndex);

		/// <summary>Returns the number of columns.</summary>
		/// <returns>Number</returns>
		public extern virtual void getColumnCount();

		/// <summary>Returns the column configs that return true by the passed function that is called with (columnConfig, index)</summary>
		/// <returns>Array</returns>
		public extern virtual void getColumnsBy();

		/// <summary>Returns the column configs that return true by the passed function that is called with (columnConfig, index)</summary>
		/// <param name="fn"></param>
		/// <returns>Array</returns>
		public extern virtual void getColumnsBy(Delegate fn);

		/// <summary>Returns the column configs that return true by the passed function that is called with (columnConfig, index)</summary>
		/// <param name="fn"></param>
		/// <param name="scope">(optional)</param>
		/// <returns>Array</returns>
		public extern virtual void getColumnsBy(Delegate fn, object scope);

		/// <summary>Returns true if the specified column is sortable.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isSortable();

		/// <summary>Returns true if the specified column is sortable.</summary>
		/// <param name="col">The column index</param>
		/// <returns>Boolean</returns>
		public extern virtual void isSortable(double col);

		/// <summary>Returns true if the specified column menu is disabled.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isMenuDisabled();

		/// <summary>Returns true if the specified column menu is disabled.</summary>
		/// <param name="col">The column index</param>
		/// <returns>Boolean</returns>
		public extern virtual void isMenuDisabled(double col);

		/// <summary>Returns the rendering (formatting) function defined for the column.</summary>
		/// <returns>Function</returns>
		public extern virtual void getRenderer();

		/// <summary>Returns the rendering (formatting) function defined for the column.</summary>
		/// <param name="col">The column index.</param>
		/// <returns>Function</returns>
		public extern virtual void getRenderer(double col);

		/// <summary>
		///     Sets the rendering (formatting) function for a column.  See {@link Ext.util.Format} for some
		///     default formatting functions.
		///     to return HTML markup for the grid view. The render function is called with
		///     the following parameters:<ul>
		///     <li><b>value</b> : Object<p class="sub-desc">The data value for the cell.</p></li>
		///     <li><b>metadata</b> : Object<p class="sub-desc">An object in which you may set the following attributes:<ul>
		///     <li><b>css</b> : String<p class="sub-desc">A CSS class name to add to the cell's TD element.</p></li>
		///     <li><b>attr</b> : String<p class="sub-desc">An HTML attribute definition string to apply to the data container element <i>within</i> the table cell
		///     (e.g. 'style="color:red;"').</p></li></ul></p></li>
		///     <li><b>record</b> : Ext.data.record<p class="sub-desc">The {@link Ext.data.Record} from which the data was extracted.</p></li>
		///     <li><b>rowIndex</b> : Number<p class="sub-desc">Row index</p></li>
		///     <li><b>colIndex</b> : Number<p class="sub-desc">Column index</p></li>
		///     <li><b>store</b> : Ext.data.Store<p class="sub-desc">The {@link Ext.data.Store} object from which the Record was extracted.</p></li></ul>
		/// </summary>
		/// <returns></returns>
		public extern virtual void setRenderer();

		/// <summary>
		///     Sets the rendering (formatting) function for a column.  See {@link Ext.util.Format} for some
		///     default formatting functions.
		///     to return HTML markup for the grid view. The render function is called with
		///     the following parameters:<ul>
		///     <li><b>value</b> : Object<p class="sub-desc">The data value for the cell.</p></li>
		///     <li><b>metadata</b> : Object<p class="sub-desc">An object in which you may set the following attributes:<ul>
		///     <li><b>css</b> : String<p class="sub-desc">A CSS class name to add to the cell's TD element.</p></li>
		///     <li><b>attr</b> : String<p class="sub-desc">An HTML attribute definition string to apply to the data container element <i>within</i> the table cell
		///     (e.g. 'style="color:red;"').</p></li></ul></p></li>
		///     <li><b>record</b> : Ext.data.record<p class="sub-desc">The {@link Ext.data.Record} from which the data was extracted.</p></li>
		///     <li><b>rowIndex</b> : Number<p class="sub-desc">Row index</p></li>
		///     <li><b>colIndex</b> : Number<p class="sub-desc">Column index</p></li>
		///     <li><b>store</b> : Ext.data.Store<p class="sub-desc">The {@link Ext.data.Store} object from which the Record was extracted.</p></li></ul>
		/// </summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setRenderer(double col);

		/// <summary>
		///     Sets the rendering (formatting) function for a column.  See {@link Ext.util.Format} for some
		///     default formatting functions.
		///     to return HTML markup for the grid view. The render function is called with
		///     the following parameters:<ul>
		///     <li><b>value</b> : Object<p class="sub-desc">The data value for the cell.</p></li>
		///     <li><b>metadata</b> : Object<p class="sub-desc">An object in which you may set the following attributes:<ul>
		///     <li><b>css</b> : String<p class="sub-desc">A CSS class name to add to the cell's TD element.</p></li>
		///     <li><b>attr</b> : String<p class="sub-desc">An HTML attribute definition string to apply to the data container element <i>within</i> the table cell
		///     (e.g. 'style="color:red;"').</p></li></ul></p></li>
		///     <li><b>record</b> : Ext.data.record<p class="sub-desc">The {@link Ext.data.Record} from which the data was extracted.</p></li>
		///     <li><b>rowIndex</b> : Number<p class="sub-desc">Row index</p></li>
		///     <li><b>colIndex</b> : Number<p class="sub-desc">Column index</p></li>
		///     <li><b>store</b> : Ext.data.Store<p class="sub-desc">The {@link Ext.data.Store} object from which the Record was extracted.</p></li></ul>
		/// </summary>
		/// <param name="col">The column index</param>
		/// <param name="fn">The function to use to process the cell's raw data</param>
		/// <returns></returns>
		public extern virtual void setRenderer(double col, Delegate fn);

		/// <summary>Returns the width for the specified column.</summary>
		/// <returns>Number</returns>
		public extern virtual void getColumnWidth();

		/// <summary>Returns the width for the specified column.</summary>
		/// <param name="col">The column index</param>
		/// <returns>Number</returns>
		public extern virtual void getColumnWidth(double col);

		/// <summary>Sets the width for a column.</summary>
		/// <returns></returns>
		public extern virtual void setColumnWidth();

		/// <summary>Sets the width for a column.</summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setColumnWidth(double col);

		/// <summary>Sets the width for a column.</summary>
		/// <param name="col">The column index</param>
		/// <param name="width">The new width</param>
		/// <returns></returns>
		public extern virtual void setColumnWidth(double col, double width);

		/// <summary>Returns the total width of all columns.</summary>
		/// <returns>Number</returns>
		public extern virtual void getTotalWidth();

		/// <summary>Returns the total width of all columns.</summary>
		/// <param name="includeHidden">True to include hidden column widths</param>
		/// <returns>Number</returns>
		public extern virtual void getTotalWidth(bool includeHidden);

		/// <summary>Returns the header for the specified column.</summary>
		/// <returns>String</returns>
		public extern virtual void getColumnHeader();

		/// <summary>Returns the header for the specified column.</summary>
		/// <param name="col">The column index</param>
		/// <returns>String</returns>
		public extern virtual void getColumnHeader(double col);

		/// <summary>Sets the header for a column.</summary>
		/// <returns></returns>
		public extern virtual void setColumnHeader();

		/// <summary>Sets the header for a column.</summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setColumnHeader(double col);

		/// <summary>Sets the header for a column.</summary>
		/// <param name="col">The column index</param>
		/// <param name="header">The new header</param>
		/// <returns></returns>
		public extern virtual void setColumnHeader(double col, string header);

		/// <summary>Returns the tooltip for the specified column.</summary>
		/// <returns>String</returns>
		public extern virtual void getColumnTooltip();

		/// <summary>Returns the tooltip for the specified column.</summary>
		/// <param name="col">The column index</param>
		/// <returns>String</returns>
		public extern virtual void getColumnTooltip(double col);

		/// <summary>Sets the tooltip for a column.</summary>
		/// <returns></returns>
		public extern virtual void setColumnTooltip();

		/// <summary>Sets the tooltip for a column.</summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setColumnTooltip(double col);

		/// <summary>Sets the tooltip for a column.</summary>
		/// <param name="col">The column index</param>
		/// <param name="tooltip">The new tooltip</param>
		/// <returns></returns>
		public extern virtual void setColumnTooltip(double col, string tooltip);

		/// <summary>Returns the dataIndex for the specified column.</summary>
		/// <returns>String</returns>
		public extern virtual void getDataIndex();

		/// <summary>Returns the dataIndex for the specified column.</summary>
		/// <param name="col">The column index</param>
		/// <returns>String</returns>
		public extern virtual void getDataIndex(double col);

		/// <summary>Sets the dataIndex for a column.</summary>
		/// <returns></returns>
		public extern virtual void setDataIndex();

		/// <summary>Sets the dataIndex for a column.</summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setDataIndex(double col);

		/// <summary>Sets the dataIndex for a column.</summary>
		/// <param name="col">The column index</param>
		/// <param name="dataIndex">The new dataIndex</param>
		/// <returns></returns>
		public extern virtual void setDataIndex(double col, string dataIndex);

		/// <summary>Finds the index of the first matching column for the given dataIndex.</summary>
		/// <returns>Number</returns>
		public extern virtual void findColumnIndex();

		/// <summary>Finds the index of the first matching column for the given dataIndex.</summary>
		/// <param name="col">The dataIndex to find</param>
		/// <returns>Number</returns>
		public extern virtual void findColumnIndex(string col);

		/// <summary>Returns true if the cell is editable.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isCellEditable();

		/// <summary>Returns true if the cell is editable.</summary>
		/// <param name="colIndex">The column index</param>
		/// <returns>Boolean</returns>
		public extern virtual void isCellEditable(double colIndex);

		/// <summary>Returns true if the cell is editable.</summary>
		/// <param name="colIndex">The column index</param>
		/// <param name="rowIndex">The row index</param>
		/// <returns>Boolean</returns>
		public extern virtual void isCellEditable(double colIndex, double rowIndex);

		/// <summary>Returns the editor defined for the cell/column.</summary>
		/// <returns>Object</returns>
		public extern virtual void getCellEditor();

		/// <summary>Returns the editor defined for the cell/column.</summary>
		/// <param name="colIndex">The column index</param>
		/// <returns>Object</returns>
		public extern virtual void getCellEditor(double colIndex);

		/// <summary>Returns the editor defined for the cell/column.</summary>
		/// <param name="colIndex">The column index</param>
		/// <param name="rowIndex">The row index</param>
		/// <returns>Object</returns>
		public extern virtual void getCellEditor(double colIndex, double rowIndex);

		/// <summary>Sets if a column is editable.</summary>
		/// <returns></returns>
		public extern virtual void setEditable();

		/// <summary>Sets if a column is editable.</summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setEditable(double col);

		/// <summary>Sets if a column is editable.</summary>
		/// <param name="col">The column index</param>
		/// <param name="editable">True if the column is editable</param>
		/// <returns></returns>
		public extern virtual void setEditable(double col, bool editable);

		/// <summary>Returns true if the column is hidden.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isHidden();

		/// <summary>Returns true if the column is hidden.</summary>
		/// <param name="colIndex">The column index</param>
		/// <returns>Boolean</returns>
		public extern virtual void isHidden(double colIndex);

		/// <summary>Returns true if the column width cannot be changed</summary>
		/// <returns></returns>
		public extern virtual void isFixed();

		/// <summary>Returns true if the column can be resized</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isResizable();

		/// <summary>Sets if a column is hidden.</summary>
		/// <returns></returns>
		public extern virtual void setHidden();

		/// <summary>Sets if a column is hidden.</summary>
		/// <param name="colIndex">The column index</param>
		/// <returns></returns>
		public extern virtual void setHidden(double colIndex);

		/// <summary>Sets if a column is hidden.</summary>
		/// <param name="colIndex">The column index</param>
		/// <param name="hidden">True if the column is hidden</param>
		/// <returns></returns>
		public extern virtual void setHidden(double colIndex, bool hidden);

		/// <summary>Sets the editor for a column.</summary>
		/// <returns></returns>
		public extern virtual void setEditor();

		/// <summary>Sets the editor for a column.</summary>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void setEditor(double col);

		/// <summary>Sets the editor for a column.</summary>
		/// <param name="col">The column index</param>
		/// <param name="editor">The editor object</param>
		/// <returns></returns>
		public extern virtual void setEditor(double col, object editor);



	}

	[JsAnonymous]
	public class ColumnModelConfig : System.DotWeb.JsDynamic {
		/// <summary> (optional) Defaults to the column's initial ordinal position. A name which identifies this column. The id is used to create a CSS class name which is applied to all table cells (including headers) in that column. The class name takes the form of <pre>x-grid3-td-<b>id</b></pre> <br><br> Header cells will also recieve this class name, but will also have the class <pr>x-grid3-hd</pre>, so to target header cells, use CSS selectors such as:<pre>.x-grid3-hd.x-grid3-td-<b>id</b></pre> The {@link Ext.grid.GridPanel#autoExpandColumn} grid config option references the column via this identifier.</summary>
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }

		/// <summary> The header text to display in the Grid view.</summary>
		public string header { get { return (string)this["header"]; } set { this["header"] = value; } }

		/// <summary> (optional) The name of the field in the grid's {@link Ext.data.Store}'s {@link Ext.data.Record} definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.</summary>
		public string dataIndex { get { return (string)this["dataIndex"]; } set { this["dataIndex"] = value; } }

		/// <summary> (optional) The initial width in pixels of the column.</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary> (optional) True if sorting is to be allowed on this column. Defaults to the value of the {@link #defaultSortable} property. Whether local/remote sorting is used is specified in {@link Ext.data.Store#remoteSort}.</summary>
		public bool sortable { get { return (bool)this["sortable"]; } set { this["sortable"] = value; } }

		/// <summary> (optional) True if the column width cannot be changed.  Defaults to false.</summary>
		public bool fixed_ { get { return (bool)this["fixed_"]; } set { this["fixed_"] = value; } }

		/// <summary> (optional) False to disable column resizing. Defaults to true.</summary>
		public bool resizable { get { return (bool)this["resizable"]; } set { this["resizable"] = value; } }

		/// <summary> (optional) True to disable the column menu. Defaults to false.</summary>
		public bool menuDisabled { get { return (bool)this["menuDisabled"]; } set { this["menuDisabled"] = value; } }

		/// <summary> (optional) True to hide the column. Defaults to false.</summary>
		public bool hidden { get { return (bool)this["hidden"]; } set { this["hidden"] = value; } }

		/// <summary> (optional) A text string to use as the column header's tooltip.  If Quicktips are enabled, this value will be used as the text of the quick tip, otherwise it will be set as the header's HTML title attribute. Defaults to ''.</summary>
		public string tooltip { get { return (string)this["tooltip"]; } set { this["tooltip"] = value; } }

		/// <summary> (optional) A function used to generate HTML markup for a cell given the cell's data value. See {@link #setRenderer}. If not specified, the default renderer uses the raw data value.</summary>
		public Delegate renderer { get { return (Delegate)this["renderer"]; } set { this["renderer"] = value; } }

		/// <summary> (optional) Set the CSS text-align property of the column.  Defaults to undefined.</summary>
		public string align { get { return (string)this["align"]; } set { this["align"] = value; } }

		/// <summary> (optional) Set custom CSS for all table cells in the column (excluding headers).  Defaults to undefined.</summary>
		public string css { get { return (string)this["css"]; } set { this["css"] = value; } }

		/// <summary> (optional) Specify as <tt>false</tt> to prevent the user from hiding this column (defaults to true).  To disallow column hiding globally for all columns in the grid, use {@link Ext.grid.GridPanel#enableColumnHide} instead.</summary>
		public bool hideable { get { return (bool)this["hideable"]; } set { this["hideable"] = value; } }

		/// <summary> (optional) The {@link Ext.form.Field} to use when editing values in this column if editing is supported by the grid.</summary>
		public Ext.form.Field editor { get { return (Ext.form.Field)this["editor"]; } set { this["editor"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class ColumnModelEvents {
        /// <summary>Fires when the width of a column changes.
        /// <pre><code>
        /// USAGE: ({ColumnModel} objthis, {Number} columnIndex, {Number} newWidth)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>columnIndex</b></term><description>The column index</description></item>
        /// <item><term><b>newWidth</b></term><description>The new width</description></item>
        /// </list>
        /// </summary>
        public static string widthchange { get { return "widthchange"; } }
        /// <summary>Fires when the text of a header changes.
        /// <pre><code>
        /// USAGE: ({ColumnModel} objthis, {Number} columnIndex, {String} newText)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>columnIndex</b></term><description>The column index</description></item>
        /// <item><term><b>newText</b></term><description>The new header text</description></item>
        /// </list>
        /// </summary>
        public static string headerchange { get { return "headerchange"; } }
        /// <summary>Fires when a column is hidden or "unhidden".
        /// <pre><code>
        /// USAGE: ({ColumnModel} objthis, {Number} columnIndex, {Boolean} hidden)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>columnIndex</b></term><description>The column index</description></item>
        /// <item><term><b>hidden</b></term><description>true if hidden, false otherwise</description></item>
        /// </list>
        /// </summary>
        public static string hiddenchange { get { return "hiddenchange"; } }
        /// <summary>Fires when a column is moved.
        /// <pre><code>
        /// USAGE: ({ColumnModel} objthis, {Number} oldIndex, {Number} newIndex)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>oldIndex</b></term><description></description></item>
        /// <item><term><b>newIndex</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string columnmoved { get { return "columnmoved"; } }
        /// <summary>Fires when the configuration is changed
        /// <pre><code>
        /// USAGE: ({ColumnModel} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string configchange { get { return "configchange"; } }
    }

    public delegate void ColumnModelWidthchangeDelegate(ColumnModel objthis, double columnIndex, double newWidth);
    public delegate void ColumnModelHeaderchangeDelegate(ColumnModel objthis, double columnIndex, string newText);
    public delegate void ColumnModelHiddenchangeDelegate(ColumnModel objthis, double columnIndex, bool hidden);
    public delegate void ColumnModelColumnmovedDelegate(ColumnModel objthis, double oldIndex, double newIndex);
    public delegate void ColumnModelConfigchangeDelegate(ColumnModel objthis);
}
