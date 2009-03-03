using System;
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
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\grid\GroupingView.js</jssource>
	public class GroupingView : Ext.grid.GridView {

		/// <summary></summary>
		/// <returns></returns>
		public GroupingView() { C_(); }
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public GroupingView(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static GroupingView prototype { get { return S_<GroupingView>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.grid.GridView superclass { get { return S_<Ext.grid.GridView>(); } set { S_(value); } }

		/// <summary>True to hide the column that is currently grouped</summary>
		public bool hideGroupedColumn { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to display the name for each set of grouped rows (defaults to true)</summary>
		public bool showGroupName { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to start all groups collapsed</summary>
		public bool startCollapsed { get { return _<bool>(); } set { _(value); } }

		/// <summary>False to disable grouping functionality (defaults to true)</summary>
		public bool enableGrouping { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to enable the grouping control in the column menu</summary>
		public bool enableGroupingMenu { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to allow the user to turn off grouping</summary>
		public bool enableNoGroups { get { return _<bool>(); } set { _(value); } }

		/// <summary>The text to display when there is an empty group value</summary>
		public System.String emptyGroupText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>True to skip refreshing the view when new rows are added (defaults to false)</summary>
		public bool ignoreAdd { get { return _<bool>(); } set { _(value); } }

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
		public System.String groupTextTpl { get { return _<System.String>(); } set { _(value); } }

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
		public Delegate groupRenderer { get { return _<Delegate>(); } set { _(value); } }

		/// <summary>The text with which to prefix the group field value in the group header line.</summary>
		public System.String header { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Text displayed in the grid header menu for grouping by a column(defaults to 'Group By This Field').</summary>
		public System.String groupByText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>Text displayed in the grid header for enabling/disabling grouping(defaults to 'Show in Groups').</summary>
		public System.String showGroupsText { get { return _<System.String>(); } set { _(value); } }


		/// <summary>Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.</summary>
		/// <returns></returns>
		public virtual void toggleGroup() { _(); }

		/// <summary>Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.</summary>
		/// <param name="groupId">The groupId assigned to the group (see getGroupId)</param>
		/// <returns></returns>
		public virtual void toggleGroup(System.String groupId) { _(groupId); }

		/// <summary>Toggles the specified group if no value is passed, otherwise sets the expanded state of the group to the value passed.</summary>
		/// <param name="groupId">The groupId assigned to the group (see getGroupId)</param>
		/// <param name="expanded">(optional)</param>
		/// <returns></returns>
		public virtual void toggleGroup(System.String groupId, bool expanded) { _(groupId, expanded); }

		/// <summary>Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.</summary>
		/// <returns></returns>
		public virtual void toggleAllGroups() { _(); }

		/// <summary>Toggles all groups if no value is passed, otherwise sets the expanded state of all groups to the value passed.</summary>
		/// <param name="expanded">(optional)</param>
		/// <returns></returns>
		public virtual void toggleAllGroups(bool expanded) { _(expanded); }

		/// <summary>Expands all grouped rows.</summary>
		/// <returns></returns>
		public virtual void expandAllGroups() { _(); }

		/// <summary>Collapses all grouped rows.</summary>
		/// <returns></returns>
		public virtual void collapseAllGroups() { _(); }

		/// <summary>Dynamically tries to determine the groupId of a specific value</summary>
		/// <returns>String</returns>
		public virtual void getGroupId() { _(); }

		/// <summary>Dynamically tries to determine the groupId of a specific value</summary>
		/// <param name="value"></param>
		/// <returns>String</returns>
		public virtual void getGroupId(System.String value) { _(value); }



	}

	[JsAnonymous]
	public class GroupingViewConfig : DotWeb.Client.JsAccessible {
		/// <summary> True to hide the column that is currently grouped</summary>
		public bool hideGroupedColumn { get; set; }

		/// <summary> True to display the name for each set of grouped rows (defaults to true)</summary>
		public bool showGroupName { get; set; }

		/// <summary> True to start all groups collapsed</summary>
		public bool startCollapsed { get; set; }

		/// <summary> False to disable grouping functionality (defaults to true)</summary>
		public bool enableGrouping { get; set; }

		/// <summary> True to enable the grouping control in the column menu</summary>
		public bool enableGroupingMenu { get; set; }

		/// <summary> True to allow the user to turn off grouping</summary>
		public bool enableNoGroups { get; set; }

		/// <summary> The text to display when there is an empty group value</summary>
		public System.String emptyGroupText { get; set; }

		/// <summary> True to skip refreshing the view when new rows are added (defaults to false)</summary>
		public bool ignoreAdd { get; set; }

		/// <summary> The template used to render the group header. This is used to format an object which contains the following properties: <div class="mdetail-params"><ul> <li><b>group</b> : String<p class="sub-desc">The <i>rendered</i> value of the group field. By default this is the unchanged value of the group field. If a {@link #groupRenderer} is specified, it is the result of a call to that.</p></li> <li><b>gvalue</b> : Object<p class="sub-desc">The <i>raw</i> value of the group field.</p></li> <li><b>text</b> : String<p class="sub-desc">The configured {@link #header} (If {@link #showGroupName} is true) plus the <i>rendered</i>group field value.</p></li> <li><b>groupId</b> : String<p class="sub-desc">A unique, generated ID which is applied to the View Element which contains the group.</p></li> <li><b>startRow</b> : Number<p class="sub-desc">The row index of the Record which caused group change.</p></li> <li><b>rs</b> : Array<p class="sub-desc">.Contains a single element: The Record providing the data for the row which caused group change.</p></li> <li><b>cls</b> : String<p class="sub-desc">The generated class name string to apply to the group header Element.</p></li> <li><b>style</b> : String<p class="sub-desc">The inline style rules to apply to the group header Element.</p></li> </ul></div></p> See {@link Ext.XTemplate} for information on how to format data using a template.</summary>
		public System.String groupTextTpl { get; set; }

		/// <summary> The function used to format the grouping field value for display in the group header. Should return a string value. This takes the following parameters: <div class="mdetail-params"><ul> <li><b>v</b> : Object<p class="sub-desc">The new value of the group field.</p></li> <li><b>unused</b> : undefined<p class="sub-desc">Unused parameter.</p></li> <li><b>r</b> : Ext.data.Record<p class="sub-desc">The Record providing the data for the row which caused group change.</p></li> <li><b>rowIndex</b> : Number<p class="sub-desc">The row index of the Record which caused group change.</p></li> <li><b>colIndex</b> : Number<p class="sub-desc">The column index of the group field.</p></li> <li><b>ds</b> : Ext.data.Store<p class="sub-desc">The Store which is providing the data Model.</p></li> </ul></div></p></summary>
		public Delegate groupRenderer { get; set; }

		/// <summary> The text with which to prefix the group field value in the group header line.</summary>
		public System.String header { get; set; }

		/// <summary> Text displayed in the grid header menu for grouping by a column (defaults to 'Group By This Field').</summary>
		public System.String groupByText { get; set; }

		/// <summary> Text displayed in the grid header for enabling/disabling grouping (defaults to 'Show in Groups').</summary>
		public System.String showGroupsText { get; set; }

		/// <summary> True to add a second TR element per row that can be used to provide a row body that spans beneath the data row.  Use the {@link #getRowClass} method's rowParams config to customize the row body.</summary>
		public bool enableRowBody { get; set; }

		/// <summary> Default text to display in the grid body when no rows are available (defaults to '').</summary>
		public System.String emptyText { get; set; }

		/// <summary> True to defer emptyText being applied until the store's first load</summary>
		public bool deferEmptyText { get; set; }

		/// <summary> True to auto expand the columns to fit the grid <b>when the grid is created</b>.</summary>
		public bool autoFill { get; set; }

		/// <summary> True to auto expand/contract the size of the columns to fit the grid width and prevent horizontal scrolling.</summary>
		public bool forceFit { get; set; }

		/// <summary> The number of levels to search for cells in event delegation (defaults to 4)</summary>
		public double cellSelectorDepth { get; set; }

		/// <summary> The number of levels to search for rows in event delegation (defaults to 10)</summary>
		public double rowSelectorDepth { get; set; }

		/// <summary> The selector used to find cells internally</summary>
		public System.String cellSelector { get; set; }

		/// <summary> The selector used to find rows internally</summary>
		public System.String rowSelector { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}
}
