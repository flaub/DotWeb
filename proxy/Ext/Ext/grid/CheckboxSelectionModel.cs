using System;
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
		public CheckboxSelectionModel() { C_(); }
		/// <summary></summary>
		/// <param name="config">The configuration options</param>
		/// <returns></returns>
		public CheckboxSelectionModel(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static CheckboxSelectionModel prototype { get { return S_<CheckboxSelectionModel>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.grid.RowSelectionModel superclass { get { return S_<Ext.grid.RowSelectionModel>(); } set { S_(value); } }

		/// <summary>
		///     Any valid text or HTML fragment to display in the header cell for the checkbox column(defaults to '&lt;div class="x-grid3-hd-checker">&#160;&lt;/div>').  The default CSS class of 'x-grid3-hd-checker'
		///     displays a checkbox in the header and provides support for automatic check all/none behavior on header click.
		///     This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but
		///     the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.
		/// </summary>
		public string header { get { return _<string>(); } set { _(value); } }

		/// <summary>The default width in pixels of the checkbox column (defaults to 20).</summary>
		public double width { get { return _<double>(); } set { _(value); } }

		/// <summary>True if the checkbox column is sortable (defaults to false).</summary>
		public bool sortable { get { return _<bool>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class CheckboxSelectionModelConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> Any valid text or HTML fragment to display in the header cell for the checkbox column (defaults to '&lt;div class="x-grid3-hd-checker">&#160;&lt;/div>').  The default CSS class of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for automatic check all/none behavior on header click. This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.</summary>
		public string header { get { return _<string>(); } set { _(value); } }

		/// <summary> The default width in pixels of the checkbox column (defaults to 20).</summary>
		public double width { get { return _<double>(); } set { _(value); } }

		/// <summary> True if the checkbox column is sortable (defaults to false).</summary>
		public bool sortable { get { return _<bool>(); } set { _(value); } }

		/// <summary>  True to allow selection of only one row at a time (defaults to false)</summary>
		public bool singleSelect { get { return _<bool>(); } set { _(value); } }

		/// <summary>  False to turn off moving the editor to the next cell when the enter key is pressed</summary>
		public bool moveEditorOnEnter { get { return _<bool>(); } set { _(value); } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return _<object>(); } set { _(value); } }

	}
}
