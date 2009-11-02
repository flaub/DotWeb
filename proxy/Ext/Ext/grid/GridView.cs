using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     <p>This class encapsulates the user interface of an {@link Ext.grid.GridPanel}.
	///     Methods of this class may be used to access user interface elements to enable
	///     special display effects. Do not change the DOM structure of the user interface.</p>
	///     <p>This class does not provide ways to manipulate the underlying data. The data
	///     model of a Grid is held in an {@link Ext.data.Store}.</p>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\GridView.js</jssource>
	public class GridView : Ext.util.Observable {

		/// <summary></summary>
		/// <returns></returns>
		public extern GridView();
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern GridView(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static GridView prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>True to add a second TR element per row that can be used to provide a row bodythat spans beneath the data row.  Use the {@link #getRowClass} method's rowParams config to customize the row body.</summary>
		public extern bool enableRowBody { get; set; }

		/// <summary>Default text to display in the grid body when no rows are available (defaults to '').</summary>
		public extern string emptyText { get; set; }

		/// <summary>
		///     <p><b>This will only be present if the owning GridPanel was configured with {@link Ext.grid.GridPanel#enableDragDrop enableDragDrop}<b> <tt>true</tt></b>.</p>
		///     <p><b>This will only be present after the owning GridPanel has been rendered</b>.</p>
		///     <p>A customized implementation of a {@link Ext.dd.DragZone DragZone} which provides default implementations of the
		///     template methods of DragZone to enable dragging of the selected rows of a GridPanel. See {@link Ext.grid.GridDragZone} for details.</p>
		/// </summary>
		public extern Ext.grid.GridDragZone dragZone { get; set; }

		/// <summary>True to defer emptyText being applied until the store's first load</summary>
		public extern bool deferEmptyText { get; set; }

		/// <summary>The amount of space to reserve for the scrollbar (defaults to 19 pixels)</summary>
		public extern double scrollOffset { get; set; }

		/// <summary>True to auto expand the columns to fit the grid <b>when the grid is created</b>.</summary>
		public extern bool autoFill { get; set; }

		/// <summary>True to auto expand/contract the size of the columns to fit the grid width and prevent horizontal scrolling.</summary>
		public extern bool forceFit { get; set; }

		/// <summary>The CSS classes applied to a header when it is sorted. (defaults to ["sort-asc", "sort-desc"])</summary>
		public extern System.Array sortClasses { get; set; }

		/// <summary>The text displayed in the "Sort Ascending" menu item</summary>
		public extern string sortAscText { get; set; }

		/// <summary>The text displayed in the "Sort Descending" menu item</summary>
		public extern string sortDescText { get; set; }

		/// <summary>The text displayed in the "Columns" menu item</summary>
		public extern string columnsText { get; set; }

		/// <summary>The number of levels to search for cells in event delegation (defaults to 4)</summary>
		public extern double cellSelectorDepth { get; set; }

		/// <summary>The number of levels to search for rows in event delegation (defaults to 10)</summary>
		public extern double rowSelectorDepth { get; set; }

		/// <summary>The selector used to find cells internally</summary>
		public extern string cellSelector { get; set; }

		/// <summary>The selector used to find rows internally</summary>
		public extern string rowSelector { get; set; }


		/// <summary>
		///     Override this function to apply custom CSS classes to rows during rendering.  You can also supply custom
		///     parameters to the row template for the current row to customize how it is rendered using the <b>rowParams</b>
		///     parameter.  This function should return the CSS class name (or empty string '' for none) that will be added
		///     to the row's wrapping div.  To apply multiple class names, simply return them space-delimited within the string
		///     (e.g., 'my-class another-class').
		///     customization of various aspects of a body row, if applicable.  Note that this object will only be applied if
		///     {@link #enableRowBody} = true, otherwise it will be ignored. The object may contain any of these properties:<ul>
		///     <li><code>body</code> : String <div class="sub-desc">An HTML fragment to be rendered as the cell's body content (defaults to '').</div></li>
		///     <li><code>bodyStyle</code> : String <div class="sub-desc">A CSS style string that will be applied to the row's TR style attribute (defaults to '').</div></li>
		///     <li><code>cols</code> : Number <div class="sub-desc">The column count to apply to the body row's TD colspan attribute (defaults to the current
		///     column count of the grid).</div></li>
		///     </ul>
		/// </summary>
		/// <returns>String</returns>
		public extern virtual void getRowClass();

		/// <summary>
		///     Override this function to apply custom CSS classes to rows during rendering.  You can also supply custom
		///     parameters to the row template for the current row to customize how it is rendered using the <b>rowParams</b>
		///     parameter.  This function should return the CSS class name (or empty string '' for none) that will be added
		///     to the row's wrapping div.  To apply multiple class names, simply return them space-delimited within the string
		///     (e.g., 'my-class another-class').
		///     customization of various aspects of a body row, if applicable.  Note that this object will only be applied if
		///     {@link #enableRowBody} = true, otherwise it will be ignored. The object may contain any of these properties:<ul>
		///     <li><code>body</code> : String <div class="sub-desc">An HTML fragment to be rendered as the cell's body content (defaults to '').</div></li>
		///     <li><code>bodyStyle</code> : String <div class="sub-desc">A CSS style string that will be applied to the row's TR style attribute (defaults to '').</div></li>
		///     <li><code>cols</code> : Number <div class="sub-desc">The column count to apply to the body row's TD colspan attribute (defaults to the current
		///     column count of the grid).</div></li>
		///     </ul>
		/// </summary>
		/// <param name="record">The {@link Ext.data.Record} corresponding to the current row</param>
		/// <returns>String</returns>
		public extern virtual void getRowClass(Ext.data.Record record);

		/// <summary>
		///     Override this function to apply custom CSS classes to rows during rendering.  You can also supply custom
		///     parameters to the row template for the current row to customize how it is rendered using the <b>rowParams</b>
		///     parameter.  This function should return the CSS class name (or empty string '' for none) that will be added
		///     to the row's wrapping div.  To apply multiple class names, simply return them space-delimited within the string
		///     (e.g., 'my-class another-class').
		///     customization of various aspects of a body row, if applicable.  Note that this object will only be applied if
		///     {@link #enableRowBody} = true, otherwise it will be ignored. The object may contain any of these properties:<ul>
		///     <li><code>body</code> : String <div class="sub-desc">An HTML fragment to be rendered as the cell's body content (defaults to '').</div></li>
		///     <li><code>bodyStyle</code> : String <div class="sub-desc">A CSS style string that will be applied to the row's TR style attribute (defaults to '').</div></li>
		///     <li><code>cols</code> : Number <div class="sub-desc">The column count to apply to the body row's TD colspan attribute (defaults to the current
		///     column count of the grid).</div></li>
		///     </ul>
		/// </summary>
		/// <param name="record">The {@link Ext.data.Record} corresponding to the current row</param>
		/// <param name="index">The row index</param>
		/// <returns>String</returns>
		public extern virtual void getRowClass(Ext.data.Record record, double index);

		/// <summary>
		///     Override this function to apply custom CSS classes to rows during rendering.  You can also supply custom
		///     parameters to the row template for the current row to customize how it is rendered using the <b>rowParams</b>
		///     parameter.  This function should return the CSS class name (or empty string '' for none) that will be added
		///     to the row's wrapping div.  To apply multiple class names, simply return them space-delimited within the string
		///     (e.g., 'my-class another-class').
		///     customization of various aspects of a body row, if applicable.  Note that this object will only be applied if
		///     {@link #enableRowBody} = true, otherwise it will be ignored. The object may contain any of these properties:<ul>
		///     <li><code>body</code> : String <div class="sub-desc">An HTML fragment to be rendered as the cell's body content (defaults to '').</div></li>
		///     <li><code>bodyStyle</code> : String <div class="sub-desc">A CSS style string that will be applied to the row's TR style attribute (defaults to '').</div></li>
		///     <li><code>cols</code> : Number <div class="sub-desc">The column count to apply to the body row's TD colspan attribute (defaults to the current
		///     column count of the grid).</div></li>
		///     </ul>
		/// </summary>
		/// <param name="record">The {@link Ext.data.Record} corresponding to the current row</param>
		/// <param name="index">The row index</param>
		/// <param name="rowParams">A config object that is passed to the row template during rendering that allows</param>
		/// <returns>String</returns>
		public extern virtual void getRowClass(Ext.data.Record record, double index, object rowParams);

		/// <summary>
		///     Override this function to apply custom CSS classes to rows during rendering.  You can also supply custom
		///     parameters to the row template for the current row to customize how it is rendered using the <b>rowParams</b>
		///     parameter.  This function should return the CSS class name (or empty string '' for none) that will be added
		///     to the row's wrapping div.  To apply multiple class names, simply return them space-delimited within the string
		///     (e.g., 'my-class another-class').
		///     customization of various aspects of a body row, if applicable.  Note that this object will only be applied if
		///     {@link #enableRowBody} = true, otherwise it will be ignored. The object may contain any of these properties:<ul>
		///     <li><code>body</code> : String <div class="sub-desc">An HTML fragment to be rendered as the cell's body content (defaults to '').</div></li>
		///     <li><code>bodyStyle</code> : String <div class="sub-desc">A CSS style string that will be applied to the row's TR style attribute (defaults to '').</div></li>
		///     <li><code>cols</code> : Number <div class="sub-desc">The column count to apply to the body row's TD colspan attribute (defaults to the current
		///     column count of the grid).</div></li>
		///     </ul>
		/// </summary>
		/// <param name="record">The {@link Ext.data.Record} corresponding to the current row</param>
		/// <param name="index">The row index</param>
		/// <param name="rowParams">A config object that is passed to the row template during rendering that allows</param>
		/// <param name="store">The {@link Ext.data.Store} this grid is bound to</param>
		/// <returns>String</returns>
		public extern virtual void getRowClass(Ext.data.Record record, double index, object rowParams, Ext.data.Store store);

		/// <summary>Return the &lt;TR> HtmlElement which represents a Grid row for the specified index.</summary>
		/// <returns>HtmlElement</returns>
		public extern virtual void getRow();

		/// <summary>Return the &lt;TR> HtmlElement which represents a Grid row for the specified index.</summary>
		/// <param name="index">The row index</param>
		/// <returns>HtmlElement</returns>
		public extern virtual void getRow(double index);

		/// <summary>Returns the grid's &lt;TD> HtmlElement at the specified coordinates.</summary>
		/// <returns>HtmlElement</returns>
		public extern virtual void getCell();

		/// <summary>Returns the grid's &lt;TD> HtmlElement at the specified coordinates.</summary>
		/// <param name="row">The row index in which to find the cell.</param>
		/// <returns>HtmlElement</returns>
		public extern virtual void getCell(double row);

		/// <summary>Returns the grid's &lt;TD> HtmlElement at the specified coordinates.</summary>
		/// <param name="row">The row index in which to find the cell.</param>
		/// <param name="col">The column index of the cell.</param>
		/// <returns>HtmlElement</returns>
		public extern virtual void getCell(double row, double col);

		/// <summary>Return the &lt;TD> HtmlElement which represents the Grid's header cell for the specified column index.</summary>
		/// <returns>HtmlElement</returns>
		public extern virtual void getHeaderCell();

		/// <summary>Return the &lt;TD> HtmlElement which represents the Grid's header cell for the specified column index.</summary>
		/// <param name="index">The column index</param>
		/// <returns>HtmlElement</returns>
		public extern virtual void getHeaderCell(double index);

		/// <summary>Scrolls the grid to the top</summary>
		/// <returns></returns>
		public extern virtual void scrollToTop();

		/// <summary>Focuses the specified row.</summary>
		/// <returns></returns>
		public extern virtual void focusRow();

		/// <summary>Focuses the specified row.</summary>
		/// <param name="row">The row index</param>
		/// <returns></returns>
		public extern virtual void focusRow(double row);

		/// <summary>Focuses the specified cell.</summary>
		/// <returns></returns>
		public extern virtual void focusCell();

		/// <summary>Focuses the specified cell.</summary>
		/// <param name="row">The row index</param>
		/// <returns></returns>
		public extern virtual void focusCell(double row);

		/// <summary>Focuses the specified cell.</summary>
		/// <param name="row">The row index</param>
		/// <param name="col">The column index</param>
		/// <returns></returns>
		public extern virtual void focusCell(double row, double col);

		/// <summary>Refreshs the grid UI</summary>
		/// <returns></returns>
		public extern virtual void refresh();

		/// <summary>Refreshs the grid UI</summary>
		/// <param name="headersToo">(optional) True to also refresh the headers</param>
		/// <returns></returns>
		public extern virtual void refresh(bool headersToo);



	}

	[JsAnonymous]
	public class GridViewConfig : System.DotWeb.JsDynamic {
		/// <summary> True to add a second TR element per row that can be used to provide a row body that spans beneath the data row.  Use the {@link #getRowClass} method's rowParams config to customize the row body.</summary>
		public bool enableRowBody { get { return (bool)this["enableRowBody"]; } set { this["enableRowBody"] = value; } }

		/// <summary> Default text to display in the grid body when no rows are available (defaults to '').</summary>
		public string emptyText { get { return (string)this["emptyText"]; } set { this["emptyText"] = value; } }

		/// <summary> True to defer emptyText being applied until the store's first load</summary>
		public bool deferEmptyText { get { return (bool)this["deferEmptyText"]; } set { this["deferEmptyText"] = value; } }

		/// <summary> True to auto expand the columns to fit the grid <b>when the grid is created</b>.</summary>
		public bool autoFill { get { return (bool)this["autoFill"]; } set { this["autoFill"] = value; } }

		/// <summary> True to auto expand/contract the size of the columns to fit the grid width and prevent horizontal scrolling.</summary>
		public bool forceFit { get { return (bool)this["forceFit"]; } set { this["forceFit"] = value; } }

		/// <summary> The number of levels to search for cells in event delegation (defaults to 4)</summary>
		public double cellSelectorDepth { get { return (double)this["cellSelectorDepth"]; } set { this["cellSelectorDepth"] = value; } }

		/// <summary> The number of levels to search for rows in event delegation (defaults to 10)</summary>
		public double rowSelectorDepth { get { return (double)this["rowSelectorDepth"]; } set { this["rowSelectorDepth"] = value; } }

		/// <summary> The selector used to find cells internally</summary>
		public string cellSelector { get { return (string)this["cellSelector"]; } set { this["cellSelector"] = value; } }

		/// <summary> The selector used to find rows internally</summary>
		public string rowSelector { get { return (string)this["rowSelector"]; } set { this["rowSelector"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class GridViewEvents {
        /// <summary>Internal UI Event. Fired before a row is removed.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view, {Number} rowIndex, {Ext.data.Record} record)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description>The index of the row to be removed.</description></item>
        /// <item><term><b>record</b></term><description>The Record to be removed</description></item>
        /// </list>
        /// </summary>
        public static string beforerowremoved { get { return "beforerowremoved"; } }
        /// <summary>Internal UI Event. Fired before rows are inserted.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view, {Number} firstRow, {Number} lastRow)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// <item><term><b>firstRow</b></term><description>The index of the first row to be inserted.</description></item>
        /// <item><term><b>lastRow</b></term><description>The index of the last row to be inserted.</description></item>
        /// </list>
        /// </summary>
        public static string beforerowsinserted { get { return "beforerowsinserted"; } }
        /// <summary>Internal UI Event. Fired before the view is refreshed.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string beforerefresh { get { return "beforerefresh"; } }
        /// <summary>Internal UI Event. Fired after a row is removed.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view, {Number} rowIndex, {Ext.data.Record} record)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// <item><term><b>rowIndex</b></term><description>The index of the row that was removed.</description></item>
        /// <item><term><b>record</b></term><description>The Record that was removed</description></item>
        /// </list>
        /// </summary>
        public static string rowremoved { get { return "rowremoved"; } }
        /// <summary>Internal UI Event. Fired after rows are inserted.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view, {Number} firstRow, {Number} lastRow)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// <item><term><b>firstRow</b></term><description>The index of the first inserted.</description></item>
        /// <item><term><b>lastRow</b></term><description>The index of the last row inserted.</description></item>
        /// </list>
        /// </summary>
        public static string rowsinserted { get { return "rowsinserted"; } }
        /// <summary>Internal UI Event. Fired after a row has been updated.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view, {Number} firstRow, {Ext.data.record} record)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// <item><term><b>firstRow</b></term><description>The index of the row updated.</description></item>
        /// <item><term><b>record</b></term><description>The Record backing the row updated.</description></item>
        /// </list>
        /// </summary>
        public static string rowupdated { get { return "rowupdated"; } }
        /// <summary>Internal UI Event. Fired after the GridView's body has been refreshed.
        /// <pre><code>
        /// USAGE: ({Ext.grid.GridView} view)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>view</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string refresh { get { return "refresh"; } }
    }

    public delegate void GridViewBeforerowremovedDelegate(Ext.grid.GridView view, double rowIndex, Ext.data.Record record);
    public delegate void GridViewBeforerowsinsertedDelegate(Ext.grid.GridView view, double firstRow, double lastRow);
    public delegate void GridViewBeforerefreshDelegate(Ext.grid.GridView view);
    public delegate void GridViewRowremovedDelegate(Ext.grid.GridView view, double rowIndex, Ext.data.Record record);
    public delegate void GridViewRowsinsertedDelegate(Ext.grid.GridView view, double firstRow, double lastRow);
    public delegate void GridViewRowupdatedDelegate(Ext.grid.GridView view, double firstRow, Ext.data.Record record);
    public delegate void GridViewRefreshDelegate(Ext.grid.GridView view);
}
