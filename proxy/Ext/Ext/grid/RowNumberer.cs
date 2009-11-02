using System;
using System.DotWeb;
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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\RowNumberer.js</jssource>
	public class RowNumberer : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern RowNumberer();
		/// <summary></summary>
		/// <param name="config">The configuration options</param>
		/// <returns></returns>
		public extern RowNumberer(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static RowNumberer prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>Any valid text or HTML fragment to display in the header cell for the rownumber column (defaults to '').</summary>
		public extern string header { get; set; }

		/// <summary>The default width in pixels of the row number column (defaults to 23).</summary>
		public extern double width { get; set; }

		/// <summary>True if the row number column is sortable (defaults to false).</summary>
		public extern bool sortable { get; set; }




	}

	[JsAnonymous]
	public class RowNumbererConfig : System.DotWeb.JsDynamic {
		/// <summary> Any valid text or HTML fragment to display in the header cell for the row number column (defaults to '').</summary>
		public string header { get { return (string)this["header"]; } set { this["header"] = value; } }

		/// <summary> The default width in pixels of the row number column (defaults to 23).</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary> True if the row number column is sortable (defaults to false).</summary>
		public bool sortable { get { return (bool)this["sortable"]; } set { this["sortable"] = value; } }

	}
}
