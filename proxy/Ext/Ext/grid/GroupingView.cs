using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     Adds the ability for single level grouping to the grid.
	///     <pre><code>var grid = new Ext.grid.GridPanel({
	///     // A groupingStore is required for a GroupingView
	///     store: new Ext.data.GroupingStore({
	///     reader: reader,
	///     data: xg.dummyData,
	///     sortInfo:{field: 'company', direction: "ASC"},
	///     groupField:'industry'
	///     }),
	///     columns: [
	///     {id:'company',header: "Company", width: 60, sortable: true, dataIndex: 'company'},
	///     {header: "Price", width: 20, sortable: true, renderer: Ext.util.Format.usMoney, dataIndex: 'price'},
	///     {header: "Change", width: 20, sortable: true, dataIndex: 'change', renderer: Ext.util.Format.usMoney},
	///     {header: "Industry", width: 20, sortable: true, dataIndex: 'industry'},
	///     {header: "Last Updated", width: 20, sortable: true, renderer: Ext.util.Format.dateRenderer('m/d/Y'), dataIndex: 'lastChange'}
	///     ],
	///     view: new Ext.grid.GroupingView({
	///     forceFit:true,
	///     // custom grouping text template to display the number of items per group
	///     groupTextTpl: '{text} ({[values.rs.length]} {[values.rs.length > 1 ? "Items" : "Item"]})'
	///     }),
	///     frame:true,
	///     width: 700,
	///     height: 450,
	///     collapsible: true,
	///     animCollapse: false,
	///     title: 'Grouping Example',
	///     iconCls: 'icon-grid',
	///     renderTo: document.body
	///     });</code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\GroupingView.js</jssource>
	public class GroupingView : Ext.grid.GridView {

		/// <summary></summary>
		/// <returns></returns>
		public extern GroupingView();
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern GroupingView(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static GroupingView prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.grid.GridView superclass { get; set; }

		/// <summary>True to hide the column that is currently grouped</summary>
		public extern bool hideGroupedColumn { get; set; }

		/// <summary>True to display the name for each set of grouped rows (defaults to true)</summary>
		public extern bool showGroupName { get; set; }

		/// <summary>True to start all groups collapsed</summary>
		public extern bool startCollapsed { get; set; }

		/// <summary>False to disable grouping functionality (defaults to true)</summary>
		public extern bool enableGrouping { get; set; }

		/// <summary>True to enable the grouping control in the column menu</summary>
		public extern bool enableGroupingMenu { get; set; }

		/// <summary>True to allow the user to turn off grouping</summary>
		public extern bool enableNoGroups { get; set; }

		/// <summary>The text to display when there is an empty group value</summary>
		public extern string emptyGroupText { get; set; }

		/// <summary>True to skip refreshing the view when new rows are added (defaults to false)</summary>
		public extern bool ignoreAdd { get; set; }

		/// <summary>
		///     The template used to render the group header. This is used toformat an object which contains the following properties:
		///     <div class="mdetail-params"><ul>
		///     <li><b>group</b> : String<p class="sub-desc">The <i>rendered</i> value of the group field.
		///     By default this is the unchanged value of the group field. If a {@link #groupRenderer}
		///     is specified, it is the result of a call to that.</p></li>
		///     <li><b>gvalue</b> : Object<p class="sub-desc">The <i>raw</i> value of the group field.</p></li>
		///     <li><b>text</b> : String<p class="sub-desc">The configured {@link #header} (If
		///     {@link #showGroupName} is true) plus the <i>rendered</i>group field value.</p></li>
		///     <li><b>groupId</b> : String<p class="sub-desc">A unique, generated ID which is applied to the
		///     View Element which contains the group.</p></li>
		///     <li><b>startRow</b> : Number<p class="sub-desc">The row index of the Record which caused group change.</p></li>
		///     <li><b>rs</b> : Array<p class="sub-desc">.Contains a single element: The Record providing the data
		///     for the row which caused group change.</p></li>
		///     <li><b>cls</b> : String<p class="sub-desc">The generated class name string to apply to the group header Element.</p></li>
		///     <li><b>style</b> : String<p class="sub-desc">The inline style rules to apply to the group header Element.</p></li>
		///     </ul></div></p>
		///     See {@link Ext.XTemplate} for information on how to format data using a template.
		/// </summary>
		public extern string groupTextTpl { get; set; }

		/// <summary>
		///     The function used to format the grouping field value fordisplay in the group header. Should return a string value. This takes the following parameters:
		///     <div class="mdetail-params"><ul>
		///     <li><b>v</b> : Object<p class="sub-desc">The new value of the group field.</p></li>
		///     <li><b>unused</b> : undefined<p class="sub-desc">Unused parameter.</p></li>
		///     <li><b>r</b> : Ext.data.Record<p class="sub-desc">The Record providing the data
		///     for the row which caused group change.</p></li>
		///     <li><b>rowIndex</b> : Number<p class="sub-desc">The row index of the Record which caused group change.</p></li>
		///     <li><b>colIndex</b> : Number<p class="sub-desc">The column index of the group field.</p></li>
		///     <li><b>ds</b> : Ext.data.Store<p class="sub-desc">The Store which is providing the data Model.</p></li>
		///     </ul></div></p>
		/// </summary>
		public extern Delegate groupRenderer { get; set; }

		/// <summary>The text with which to prefix the group field value in the group header line.</summary>
		public extern string header { get; set; }

		/// <summary>Text displayed in the grid header menu for grouping by a column(defaults to 'Group By This Field').</summary>
		public extern string groupByText { get; set; }

		/// <summary>Text displayed in the grid header for enabling/disabling grouping(defaults to 'Show in Groups').</summary>
		public extern string showGroupsText { get; set; }


		/// <summary>Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.</summary>
		/// <returns></returns>
		public extern virtual void toggleGroup();

		/// <summary>Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.</summary>
		/// <param name="groupId">The groupId assigned to the group (see getGroupId)</param>
		/// <returns></returns>
		public extern virtual void toggleGroup(string groupId);

		/// <summary>Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.</summary>
		/// <param name="groupId">The groupId assigned to the group (see getGroupId)</param>
		/// <param name="expanded">(optional)</param>
		/// <returns></returns>
		public extern virtual void toggleGroup(string groupId, bool expanded);

		/// <summary>Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.</summary>
		/// <returns></returns>
		public extern virtual void toggleAllGroups();

		/// <summary>Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.</summary>
		/// <param name="expanded">(optional)</param>
		/// <returns></returns>
		public extern virtual void toggleAllGroups(bool expanded);

		/// <summary>Expands all grouped rows.</summary>
		/// <returns></returns>
		public extern virtual void expandAllGroups();

		/// <summary>Collapses all grouped rows.</summary>
		/// <returns></returns>
		public extern virtual void collapseAllGroups();

		/// <summary>Dynamically tries to determine the groupId of a specific value</summary>
		/// <returns>String</returns>
		public extern virtual void getGroupId();

		/// <summary>Dynamically tries to determine the groupId of a specific value</summary>
		/// <param name="value"></param>
		/// <returns>String</returns>
		public extern virtual void getGroupId(string value);



	}

	[JsAnonymous]
	public class GroupingViewConfig : System.DotWeb.JsDynamic {
		/// <summary> True to hide the column that is currently grouped</summary>
		public bool hideGroupedColumn { get { return (bool)this["hideGroupedColumn"]; } set { this["hideGroupedColumn"] = value; } }

		/// <summary> True to display the name for each set of grouped rows (defaults to true)</summary>
		public bool showGroupName { get { return (bool)this["showGroupName"]; } set { this["showGroupName"] = value; } }

		/// <summary> True to start all groups collapsed</summary>
		public bool startCollapsed { get { return (bool)this["startCollapsed"]; } set { this["startCollapsed"] = value; } }

		/// <summary> False to disable grouping functionality (defaults to true)</summary>
		public bool enableGrouping { get { return (bool)this["enableGrouping"]; } set { this["enableGrouping"] = value; } }

		/// <summary> True to enable the grouping control in the column menu</summary>
		public bool enableGroupingMenu { get { return (bool)this["enableGroupingMenu"]; } set { this["enableGroupingMenu"] = value; } }

		/// <summary> True to allow the user to turn off grouping</summary>
		public bool enableNoGroups { get { return (bool)this["enableNoGroups"]; } set { this["enableNoGroups"] = value; } }

		/// <summary> The text to display when there is an empty group value</summary>
		public string emptyGroupText { get { return (string)this["emptyGroupText"]; } set { this["emptyGroupText"] = value; } }

		/// <summary> True to skip refreshing the view when new rows are added (defaults to false)</summary>
		public bool ignoreAdd { get { return (bool)this["ignoreAdd"]; } set { this["ignoreAdd"] = value; } }

		/// <summary> The template used to render the group header. This is used to format an object which contains the following properties: <div class="mdetail-params"><ul> <li><b>group</b> : String<p class="sub-desc">The <i>rendered</i> value of the group field. By default this is the unchanged value of the group field. If a {@link #groupRenderer} is specified, it is the result of a call to that.</p></li> <li><b>gvalue</b> : Object<p class="sub-desc">The <i>raw</i> value of the group field.</p></li> <li><b>text</b> : String<p class="sub-desc">The configured {@link #header} (If {@link #showGroupName} is true) plus the <i>rendered</i>group field value.</p></li> <li><b>groupId</b> : String<p class="sub-desc">A unique, generated ID which is applied to the View Element which contains the group.</p></li> <li><b>startRow</b> : Number<p class="sub-desc">The row index of the Record which caused group change.</p></li> <li><b>rs</b> : Array<p class="sub-desc">.Contains a single element: The Record providing the data for the row which caused group change.</p></li> <li><b>cls</b> : String<p class="sub-desc">The generated class name string to apply to the group header Element.</p></li> <li><b>style</b> : String<p class="sub-desc">The inline style rules to apply to the group header Element.</p></li> </ul></div></p> See {@link Ext.XTemplate} for information on how to format data using a template.</summary>
		public string groupTextTpl { get { return (string)this["groupTextTpl"]; } set { this["groupTextTpl"] = value; } }

		/// <summary> The function used to format the grouping field value for display in the group header. Should return a string value. This takes the following parameters: <div class="mdetail-params"><ul> <li><b>v</b> : Object<p class="sub-desc">The new value of the group field.</p></li> <li><b>unused</b> : undefined<p class="sub-desc">Unused parameter.</p></li> <li><b>r</b> : Ext.data.Record<p class="sub-desc">The Record providing the data for the row which caused group change.</p></li> <li><b>rowIndex</b> : Number<p class="sub-desc">The row index of the Record which caused group change.</p></li> <li><b>colIndex</b> : Number<p class="sub-desc">The column index of the group field.</p></li> <li><b>ds</b> : Ext.data.Store<p class="sub-desc">The Store which is providing the data Model.</p></li> </ul></div></p></summary>
		public Delegate groupRenderer { get { return (Delegate)this["groupRenderer"]; } set { this["groupRenderer"] = value; } }

		/// <summary> The text with which to prefix the group field value in the group header line.</summary>
		public string header { get { return (string)this["header"]; } set { this["header"] = value; } }

		/// <summary> Text displayed in the grid header menu for grouping by a column (defaults to 'Group By This Field').</summary>
		public string groupByText { get { return (string)this["groupByText"]; } set { this["groupByText"] = value; } }

		/// <summary> Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').</summary>
		public string showGroupsText { get { return (string)this["showGroupsText"]; } set { this["showGroupsText"] = value; } }

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
}
