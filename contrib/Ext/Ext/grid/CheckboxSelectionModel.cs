using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     A custom selection model that renders a column of checkboxes that can be toggled to select or deselect rows.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\CheckboxSelectionModel.js</jssource>
	public class CheckboxSelectionModel : Ext.grid.RowSelectionModel {

		/// <summary></summary>
		/// <returns></returns>
		public extern CheckboxSelectionModel();
		/// <summary></summary>
		/// <param name="config">The configuration options</param>
		/// <returns></returns>
		public extern CheckboxSelectionModel(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static CheckboxSelectionModel prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.grid.RowSelectionModel superclass { get; set; }

		/// <summary>
		///     Any valid text or HTML fragment to display in the header cell for the checkbox column(defaults to '&lt;div class="x-grid3-hd-checker">&#160;&lt;/div>').  The default CSS class of 'x-grid3-hd-checker'
		///     displays a checkbox in the header and provides support for automatic check all/none behavior on header click.
		///     This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but
		///     the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.
		/// </summary>
		public extern string header { get; set; }

		/// <summary>The default width in pixels of the checkbox column (defaults to 20).</summary>
		public extern double width { get; set; }

		/// <summary>True if the checkbox column is sortable (defaults to false).</summary>
		public extern bool sortable { get; set; }




	}

	[JsAnonymous]
	public class CheckboxSelectionModelConfig : System.DotWeb.JsDynamic {
		/// <summary> Any valid text or HTML fragment to display in the header cell for the checkbox column (defaults to '&lt;div class="x-grid3-hd-checker">&#160;&lt;/div>').  The default CSS class of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for automatic check all/none behavior on header click. This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.</summary>
		public string header { get { return (string)this["header"]; } set { this["header"] = value; } }

		/// <summary> The default width in pixels of the checkbox column (defaults to 20).</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary> True if the checkbox column is sortable (defaults to false).</summary>
		public bool sortable { get { return (bool)this["sortable"]; } set { this["sortable"] = value; } }

		/// <summary>  True to allow selection of only one row at a time (defaults to false)</summary>
		public bool singleSelect { get { return (bool)this["singleSelect"]; } set { this["singleSelect"] = value; } }

		/// <summary>  False to turn off moving the editor to the next cell when the enter key is pressed</summary>
		public bool moveEditorOnEnter { get { return (bool)this["moveEditorOnEnter"]; } set { this["moveEditorOnEnter"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}
}
