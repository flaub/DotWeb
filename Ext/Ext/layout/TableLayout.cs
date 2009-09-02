using System;
using DotWeb.Client;

namespace Ext.layout {
	/// <summary>
	///     /**
	///     <p>This layout allows you to easily render content into an HTML table.  The total number of columns can be
	///     specified, and rowspan and colspan can be used to create complex layouts within the table.
	///     This class is intended to be extended or created via the layout:'table' {@link Ext.Container#layout} config,
	///     and should generally not need to be created directly via the new keyword.</p>
	///     <p>Note that when creating a layout via config, the layout-specific config properties must be passed in via
	///     the {@link Ext.Container#layoutConfig} object which will then be applied internally to the layout.  In the
	///     case of TableLayout, the only valid layout config property is {@link #columns}.  However, the items added to a
	///     TableLayout can supply the following table-specific config properties:</p>
	///     <ul>
	///     <li><b>rowspan</b> Applied to the table cell containing the item.</li>
	///     <li><b>colspan</b> Applied to the table cell containing the item.</li>
	///     <li><b>cellId</b> An id applied to the table cell containing the item.</li>
	///     <li><b>cellCls</b> A CSS class name added to the table cell containing the item.</li>
	///     </ul>
	///     <p>The basic concept of building up a TableLayout is conceptually very similar to building up a standard
	///     HTML table.  You simply add each panel (or "cell") that you want to include along with any span attributes
	///     specified as the special config properties of rowspan and colspan which work exactly like their HTML counterparts.
	///     Rather than explicitly creating and nesting rows and columns as you would in HTML, you simply specify the
	///     total column count in the layoutConfig and start adding panels in their natural order from left to right,
	///     top to bottom.  The layout will automatically figure out, based on the column count, rowspans and colspans,
	///     how to position each panel within the table.  Just like with HTML tables, your rowspans and colspans must add
	///     up correctly in your overall layout or you'll end up with missing and/or extra cells!  Example usage:</p>
	///     <pre><code>
	///     // This code will generate a layout table that is 3 columns by 2 rows
	///     // with some spanning included.  The basic layout will be:
	///     // +--------+-----------------+
	///     // |   A    |   B             |
	///     // |        |--------+--------|
	///     // |        |   C    |   D    |
	///     // +--------+--------+--------+
	///     var table = new Ext.Panel({
	///     title: 'Table Layout',
	///     layout:'table',
	///     defaults: {
	///     // applied to each contained panel
	///     bodyStyle:'padding:20px'
	///     },
	///     layoutConfig: {
	///     // The total column count must be specified here
	///     columns: 3
	///     },
	///     items: [{
	///     html: '&lt;p&gt;Cell A content&lt;/p&gt;',
	///     rowspan: 2
	///     },{
	///     html: '&lt;p&gt;Cell B content&lt;/p&gt;',
	///     colspan: 2
	///     },{
	///     html: '&lt;p&gt;Cell C content&lt;/p&gt;',
	///     cellCls: 'highlight'
	///     },{
	///     html: '&lt;p&gt;Cell D content&lt;/p&gt;'
	///     }]
	///     });
	///     </code></pre>
	///     */
	///     Ext.layout.TableLayout = Ext.extend(Ext.layout.ContainerLayout, {
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\layout\TableLayout.js</jssource>
	public class TableLayout : Ext.layout.ContainerLayout {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public TableLayout() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TableLayout prototype { get { return S_<TableLayout>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.layout.ContainerLayout superclass { get { return S_<Ext.layout.ContainerLayout>(); } set { S_(value); } }

		/// <summary>
		///     The total number of columns to create in the table for this layout.  If not specified, all panels added to
		///     this layout will be rendered into a single row using a column per panel.
		/// </summary>
		public double columns { get { return _<double>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class TableLayoutConfig : DotWeb.Client.JsAccessible {
		/// <summary>  The total number of columns to create in the table for this layout.  If not specified, all panels added to this layout will be rendered into a single row using a column per panel.</summary>
		public double columns { get; set; }

		/// <summary>  An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public System.String extraCls { get; set; }

		/// <summary>  True to hide each contained item on render (defaults to false).</summary>
		public bool renderHidden { get; set; }

	}
}
