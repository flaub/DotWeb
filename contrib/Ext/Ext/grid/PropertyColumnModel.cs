using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     A custom column model for the {@link Ext.grid.PropertyGrid}.  Generally it should not need to be used directly.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\PropertyGrid.js</jssource>
	public class PropertyColumnModel : Ext.grid.ColumnModel {

		/// <summary></summary>
		/// <returns></returns>
		public extern PropertyColumnModel();
		/// <summary></summary>
		/// <param name="grid">The grid this store will be bound to</param>
		/// <returns></returns>
		public extern PropertyColumnModel(object grid);
		/// <summary></summary>
		/// <param name="grid">The grid this store will be bound to</param>
		/// <param name="source">The source data config object</param>
		/// <returns></returns>
		public extern PropertyColumnModel(object grid, object source);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static PropertyColumnModel prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.grid.ColumnModel superclass { get; set; }




	}

	[JsAnonymous]
	public class PropertyColumnModelConfig : System.DotWeb.JsDynamic {
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
}
