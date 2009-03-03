using System;
using DotWeb.Client;

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
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\grid\RowNumberer.js</jssource>
	public class RowNumberer : DotWeb.Client.JsNativeBase {

		/// <summary></summary>
		/// <returns></returns>
		public RowNumberer() { C_(); }
		/// <summary></summary>
		/// <param name="config">The configuration options</param>
		/// <returns></returns>
		public RowNumberer(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static RowNumberer prototype { get { return S_<RowNumberer>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>Any valid text or HTML fragment to display in the header cell for the rownumber column (defaults to '').</summary>
		public System.String header { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The default width in pixels of the row number column (defaults to 23).</summary>
		public double width { get { return _<double>(); } set { _(value); } }

		/// <summary>True if the row number column is sortable (defaults to false).</summary>
		public bool sortable { get { return _<bool>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class RowNumbererConfig : DotWeb.Client.JsAccessible {
		/// <summary> Any valid text or HTML fragment to display in the header cell for the row number column (defaults to '').</summary>
		public System.String header { get; set; }

		/// <summary> The default width in pixels of the row number column (defaults to 23).</summary>
		public double width { get; set; }

		/// <summary> True if the row number column is sortable (defaults to false).</summary>
		public bool sortable { get; set; }

	}
}
