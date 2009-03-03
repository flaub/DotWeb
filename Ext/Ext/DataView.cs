using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     A mechanism for displaying data using custom layout templates and formatting. DataView uses an {@link Ext.XTemplate}
	///     as its internal templating mechanism, and is bound to an {@link Ext.data.Store}
	///     so that as the data in the store changes the view is automatically updated to reflect the changes.  The view also
	///     provides built-in behavior for many common events that can occur for its contained items including click, doubleclick,
	///     mouseover, mouseout, etc. as well as a built-in selection model. <b>In order to use these features, an {@link #itemSelector}
	///     config must be provided for the DataView to determine what nodes it will be working with.</b>
	///     <p>The example below binds a DataView to a {@link Ext.data.Store} and renders it into an {@link Ext.Panel}.</p>
	///     <pre><code>
	///     var store = new Ext.data.JsonStore({
	///     url: 'get-images.php',
	///     root: 'images',
	///     fields: [
	///     'name', 'url',
	///     {name:'size', type: 'float'},
	///     {name:'lastmod', type:'date', dateFormat:'timestamp'}
	///     ]
	///     });
	///     store.load();
	///     var tpl = new Ext.XTemplate(
	///     '&lt;tpl for="."&gt;',
	///     '&lt;div class="thumb-wrap" id="{name}"&gt;',
	///     '&lt;div class="thumb"&gt;&lt;img src="{url}" title="{name}"&gt;&lt;/div&gt;',
	///     '&lt;span class="x-editable"&gt;{shortName}&lt;/span&gt;&lt;/div&gt;',
	///     '&lt;/tpl&gt;',
	///     '&lt;div class="x-clear"&gt;&lt;/div&gt;'
	///     );
	///     var panel = new Ext.Panel({
	///     id:'images-view',
	///     frame:true,
	///     width:535,
	///     autoHeight:true,
	///     collapsible:true,
	///     layout:'fit',
	///     title:'Simple DataView',
	///     items: new Ext.DataView({
	///     store: store,
	///     tpl: tpl,
	///     autoHeight:true,
	///     multiSelect: true,
	///     overClass:'x-view-over',
	///     itemSelector:'div.thumb-wrap',
	///     emptyText: 'No images to display'
	///     })
	///     });
	///     panel.render(document.body);
	///     </code></pre>
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\DataView.js</jssource>
	public class DataView : Ext.BoxComponent {

		/// <summary>Create a new DataView</summary>
		/// <returns></returns>
		public DataView() { C_(); }
		/// <summary>Create a new DataView</summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public DataView(object config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public DataView(Ext.Element config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public DataView(System.String config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DataView prototype { get { return S_<DataView>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.BoxComponent superclass { get { return S_<Ext.BoxComponent>(); } set { S_(value); } }

		/// <summary>
		///     The HTML fragment or an array of fragments that will make up the template used by this DataView.  This should
		///     be specified in the same format expected by the constructor of {@link Ext.XTemplate}.
		/// </summary>
		public object tpl { get { return _<object>(); } set { _(value); } }

		/// <summary>The {@link Ext.data.Store} to bind this DataView to.</summary>
		public Ext.data.Store store { get { return _<Ext.data.Store>(); } set { _(value); } }

		/// <summary>
		///     <b>This is a required setting</b>. A simple CSS selector (e.g. div.some-class or span:first-child) that will be
		///     used to determine what nodes this DataView will be working with.
		/// </summary>
		public System.String itemSelector { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     True to allow selection of more than one item at a time, false to allow selection of only a single item
		///     at a time or no selection at all, depending on the value of {@link #singleSelect} (defaults to false).
		/// </summary>
		public bool multiSelect { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false).
		///     Note that if {@link #multiSelect} = true, this value will be ignored.
		/// </summary>
		public bool singleSelect { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl,
		///     false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
		/// </summary>
		public bool simpleSelect { get { return _<bool>(); } set { _(value); } }

		/// <summary>A CSS class to apply to each item in the view on mouseover (defaults to undefined).</summary>
		public System.String overClass { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     A string to display during data load operations (defaults to undefined).  If specified, this text will be
		///     displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's
		///     contents will continue to display normally until the new data is loaded and the contents are replaced.
		/// </summary>
		public System.String loadingText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').</summary>
		public System.String selectedClass { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The text to display in the view when there is no data to display (defaults to '').</summary>
		public System.String emptyText { get { return _<System.String>(); } set { _(value); } }

		/// <summary>True to defer emptyText being applied until the store's first load</summary>
		public bool deferEmptyText { get { return _<bool>(); } set { _(value); } }

		/// <summary>True to enable mouseenter and mouseleave events</summary>
		public bool trackOver { get { return _<bool>(); } set { _(value); } }


		/// <summary>Refreshes the view by reloading the data from the store and re-rendering the template.</summary>
		/// <returns></returns>
		public virtual void refresh() { _(); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <returns>Array/Object</returns>
		public virtual void prepareData() { _(); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <param name="data">The raw data object that was used to create the Record.</param>
		/// <returns>Array/Object</returns>
		public virtual void prepareData(System.Array data) { _(data); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <param name="data">The raw data object that was used to create the Record.</param>
		/// <param name="recordIndex">the index number of the Record being prepared for rendering.</param>
		/// <returns>Array/Object</returns>
		public virtual void prepareData(System.Array data, double recordIndex) { _(data, recordIndex); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <param name="data">The raw data object that was used to create the Record.</param>
		/// <param name="recordIndex">the index number of the Record being prepared for rendering.</param>
		/// <param name="record">The Record being prepared for rendering.</param>
		/// <returns>Array/Object</returns>
		public virtual void prepareData(System.Array data, double recordIndex, Ext.data.Record record) { _(data, recordIndex, record); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <param name="data">The raw data object that was used to create the Record.</param>
		/// <returns>Array/Object</returns>
		public virtual void prepareData(object data) { _(data); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <param name="data">The raw data object that was used to create the Record.</param>
		/// <param name="recordIndex">the index number of the Record being prepared for rendering.</param>
		/// <returns>Array/Object</returns>
		public virtual void prepareData(object data, double recordIndex) { _(data, recordIndex); }

		/// <summary>
		///     Function which can be overridden to provide custom formatting for each Record that is used by this
		///     DataView's {@link #tpl template} to render each node.
		///     (either an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'}))
		/// </summary>
		/// <param name="data">The raw data object that was used to create the Record.</param>
		/// <param name="recordIndex">the index number of the Record being prepared for rendering.</param>
		/// <param name="record">The Record being prepared for rendering.</param>
		/// <returns>Array/Object</returns>
		public virtual void prepareData(object data, double recordIndex, Ext.data.Record record) { _(data, recordIndex, record); }

		/// <summary>
		///     <p>Function which can be overridden which returns the data object passed to this
		///     DataView's {@link #tpl template} to render the whole DataView.</p>
		///     <p>This is usually an Array of data objects, each element of which is processed by an
		///     {@link Ext.XTemplate XTemplate} which uses <tt>'&lt;tpl for="."&gt;'</tt> to iterate over its supplied
		///     data object as an Array. However, <i>named</i> properties may be placed into the data object to
		///     provide non-repeating data such as headings, totals etc.</p>
		///     contain <i>named</i> properties.
		/// </summary>
		/// <returns>Array</returns>
		public virtual void collectData() { _(); }

		/// <summary>
		///     <p>Function which can be overridden which returns the data object passed to this
		///     DataView's {@link #tpl template} to render the whole DataView.</p>
		///     <p>This is usually an Array of data objects, each element of which is processed by an
		///     {@link Ext.XTemplate XTemplate} which uses <tt>'&lt;tpl for="."&gt;'</tt> to iterate over its supplied
		///     data object as an Array. However, <i>named</i> properties may be placed into the data object to
		///     provide non-repeating data such as headings, totals etc.</p>
		///     contain <i>named</i> properties.
		/// </summary>
		/// <param name="records">{Array} An Array of {@link Ext.data.Record}s to be rendered into the DataView.</param>
		/// <returns>Array</returns>
		public virtual void collectData(object records) { _(records); }

		/// <summary>Refreshes an individual node's data from the store.</summary>
		/// <returns></returns>
		public virtual void refreshNode() { _(); }

		/// <summary>Refreshes an individual node's data from the store.</summary>
		/// <param name="index">The item's data index in the store</param>
		/// <returns></returns>
		public virtual void refreshNode(double index) { _(index); }

		/// <summary>Changes the data store bound to this view and refreshes it.</summary>
		/// <returns></returns>
		public virtual void setStore() { _(); }

		/// <summary>Changes the data store bound to this view and refreshes it.</summary>
		/// <param name="store">The store to bind to this view</param>
		/// <returns></returns>
		public virtual void setStore(Ext.data.Store store) { _(store); }

		/// <summary>Returns the template node the passed child belongs to, or null if it doesn't belong to one.</summary>
		/// <returns>HTMLElement</returns>
		public virtual void findItemFromChild() { _(); }

		/// <summary>Returns the template node the passed child belongs to, or null if it doesn't belong to one.</summary>
		/// <param name="node"></param>
		/// <returns>HTMLElement</returns>
		public virtual void findItemFromChild(DOMElement node) { _(node); }

		/// <summary>Gets the number of selected nodes.</summary>
		/// <returns>Number</returns>
		public virtual void getSelectionCount() { _(); }

		/// <summary>Gets the currently selected nodes.</summary>
		/// <returns>Array</returns>
		public virtual void getSelectedNodes() { _(); }

		/// <summary>Gets the indexes of the selected nodes.</summary>
		/// <returns>Array</returns>
		public virtual void getSelectedIndexes() { _(); }

		/// <summary>Gets an array of the selected records</summary>
		/// <returns>Array</returns>
		public virtual void getSelectedRecords() { _(); }

		/// <summary>Gets an array of the records from an array of nodes</summary>
		/// <returns>Array</returns>
		public virtual void getRecords() { _(); }

		/// <summary>Gets an array of the records from an array of nodes</summary>
		/// <param name="nodes">The nodes to evaluate</param>
		/// <returns>Array</returns>
		public virtual void getRecords(System.Array nodes) { _(nodes); }

		/// <summary>Gets a record from a node</summary>
		/// <returns>Record</returns>
		public virtual void getRecord() { _(); }

		/// <summary>Gets a record from a node</summary>
		/// <param name="node">The node to evaluate</param>
		/// <returns>Record</returns>
		public virtual void getRecord(DOMElement node) { _(node); }

		/// <summary>Clears all selections.</summary>
		/// <returns></returns>
		public virtual void clearSelections() { _(); }

		/// <summary>Clears all selections.</summary>
		/// <param name="suppressEvent">(optional) True to skip firing of the selectionchange event</param>
		/// <returns></returns>
		public virtual void clearSelections(bool suppressEvent) { _(suppressEvent); }

		/// <summary>Returns true if the passed node is selected, else false.</summary>
		/// <returns>Boolean</returns>
		public virtual void isSelected() { _(); }

		/// <summary>Returns true if the passed node is selected, else false.</summary>
		/// <param name="node">The node or node index to check</param>
		/// <returns>Boolean</returns>
		public virtual void isSelected(DOMElement node) { _(node); }

		/// <summary>Returns true if the passed node is selected, else false.</summary>
		/// <param name="node">The node or node index to check</param>
		/// <returns>Boolean</returns>
		public virtual void isSelected(double node) { _(node); }

		/// <summary>Deselects a node.</summary>
		/// <returns></returns>
		public virtual void deselect() { _(); }

		/// <summary>Deselects a node.</summary>
		/// <param name="node">The node to deselect</param>
		/// <returns></returns>
		public virtual void deselect(DOMElement node) { _(node); }

		/// <summary>Deselects a node.</summary>
		/// <param name="node">The node to deselect</param>
		/// <returns></returns>
		public virtual void deselect(double node) { _(node); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <returns></returns>
		public virtual void select() { _(); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <returns></returns>
		public virtual void select(System.Array nodeInfo) { _(nodeInfo); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <returns></returns>
		public virtual void select(System.Array nodeInfo, bool keepExisting) { _(nodeInfo, keepExisting); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <param name="suppressEvent">(optional) true to skip firing of the selectionchange vent</param>
		/// <returns></returns>
		public virtual void select(System.Array nodeInfo, bool keepExisting, bool suppressEvent) { _(nodeInfo, keepExisting, suppressEvent); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <returns></returns>
		public virtual void select(DOMElement nodeInfo) { _(nodeInfo); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <returns></returns>
		public virtual void select(DOMElement nodeInfo, bool keepExisting) { _(nodeInfo, keepExisting); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <param name="suppressEvent">(optional) true to skip firing of the selectionchange vent</param>
		/// <returns></returns>
		public virtual void select(DOMElement nodeInfo, bool keepExisting, bool suppressEvent) { _(nodeInfo, keepExisting, suppressEvent); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <returns></returns>
		public virtual void select(System.String nodeInfo) { _(nodeInfo); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <returns></returns>
		public virtual void select(System.String nodeInfo, bool keepExisting) { _(nodeInfo, keepExisting); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <param name="suppressEvent">(optional) true to skip firing of the selectionchange vent</param>
		/// <returns></returns>
		public virtual void select(System.String nodeInfo, bool keepExisting, bool suppressEvent) { _(nodeInfo, keepExisting, suppressEvent); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <returns></returns>
		public virtual void select(double nodeInfo) { _(nodeInfo); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <returns></returns>
		public virtual void select(double nodeInfo, bool keepExisting) { _(nodeInfo, keepExisting); }

		/// <summary>
		///     Selects a set of nodes.
		///     id of a template node or an array of any of those to select
		/// </summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node,</param>
		/// <param name="keepExisting">(optional) true to keep existing selections</param>
		/// <param name="suppressEvent">(optional) true to skip firing of the selectionchange vent</param>
		/// <returns></returns>
		public virtual void select(double nodeInfo, bool keepExisting, bool suppressEvent) { _(nodeInfo, keepExisting, suppressEvent); }

		/// <summary>Selects a range of nodes. All nodes between start and end are selected.</summary>
		/// <returns></returns>
		public virtual void selectRange() { _(); }

		/// <summary>Selects a range of nodes. All nodes between start and end are selected.</summary>
		/// <param name="start">The index of the first node in the range</param>
		/// <returns></returns>
		public virtual void selectRange(double start) { _(start); }

		/// <summary>Selects a range of nodes. All nodes between start and end are selected.</summary>
		/// <param name="start">The index of the first node in the range</param>
		/// <param name="end">The index of the last node in the range</param>
		/// <returns></returns>
		public virtual void selectRange(double start, double end) { _(start, end); }

		/// <summary>Selects a range of nodes. All nodes between start and end are selected.</summary>
		/// <param name="start">The index of the first node in the range</param>
		/// <param name="end">The index of the last node in the range</param>
		/// <param name="keepExisting">(optional) True to retain existing selections</param>
		/// <returns></returns>
		public virtual void selectRange(double start, double end, bool keepExisting) { _(start, end, keepExisting); }

		/// <summary>Gets a template node.</summary>
		/// <returns>HTMLElement</returns>
		public virtual void getNode() { _(); }

		/// <summary>Gets a template node.</summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node or the id of a template node</param>
		/// <returns>HTMLElement</returns>
		public virtual void getNode(DOMElement nodeInfo) { _(nodeInfo); }

		/// <summary>Gets a template node.</summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node or the id of a template node</param>
		/// <returns>HTMLElement</returns>
		public virtual void getNode(System.String nodeInfo) { _(nodeInfo); }

		/// <summary>Gets a template node.</summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node or the id of a template node</param>
		/// <returns>HTMLElement</returns>
		public virtual void getNode(double nodeInfo) { _(nodeInfo); }

		/// <summary>Gets a range nodes.</summary>
		/// <returns>Array</returns>
		public virtual void getNodes() { _(); }

		/// <summary>Gets a range nodes.</summary>
		/// <param name="start">(optional) The index of the first node in the range</param>
		/// <returns>Array</returns>
		public virtual void getNodes(double start) { _(start); }

		/// <summary>Gets a range nodes.</summary>
		/// <param name="start">(optional) The index of the first node in the range</param>
		/// <param name="end">(optional) The index of the last node in the range</param>
		/// <returns>Array</returns>
		public virtual void getNodes(double start, double end) { _(start, end); }

		/// <summary>Finds the index of the passed node.</summary>
		/// <returns>Number</returns>
		public virtual void indexOf() { _(); }

		/// <summary>Finds the index of the passed node.</summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node or the id of a template node</param>
		/// <returns>Number</returns>
		public virtual void indexOf(DOMElement nodeInfo) { _(nodeInfo); }

		/// <summary>Finds the index of the passed node.</summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node or the id of a template node</param>
		/// <returns>Number</returns>
		public virtual void indexOf(System.String nodeInfo) { _(nodeInfo); }

		/// <summary>Finds the index of the passed node.</summary>
		/// <param name="nodeInfo">An HTMLElement template node, index of a template node or the id of a template node</param>
		/// <returns>Number</returns>
		public virtual void indexOf(double nodeInfo) { _(nodeInfo); }



	}

	[JsAnonymous]
	public class DataViewConfig : DotWeb.Client.JsAccessible {
		/// <summary>{String/Array}  The HTML fragment or an array of fragments that will make up the template used by this DataView.  This should be specified in the same format expected by the constructor of {@link Ext.XTemplate}.</summary>
		public object tpl { get; set; }

		/// <summary>  The {@link Ext.data.Store} to bind this DataView to.</summary>
		public Ext.data.Store store { get; set; }

		/// <summary>  <b>This is a required setting</b>. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with.</summary>
		public System.String itemSelector { get; set; }

		/// <summary>  True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of {@link #singleSelect} (defaults to false).</summary>
		public bool multiSelect { get; set; }

		/// <summary>  True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if {@link #multiSelect} = true, this value will be ignored.</summary>
		public bool singleSelect { get; set; }

		/// <summary>  True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).</summary>
		public bool simpleSelect { get; set; }

		/// <summary>  A CSS class to apply to each item in the view on mouseover (defaults to undefined).</summary>
		public System.String overClass { get; set; }

		/// <summary>  A string to display during data load operations (defaults to undefined).  If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.</summary>
		public System.String loadingText { get; set; }

		/// <summary>  A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').</summary>
		public System.String selectedClass { get; set; }

		/// <summary>  The text to display in the view when there is no data to display (defaults to '').</summary>
		public System.String emptyText { get; set; }

		/// <summary> True to defer emptyText being applied until the store's first load</summary>
		public bool deferEmptyText { get; set; }

		/// <summary> True to enable mouseenter and mouseleave events</summary>
		public bool trackOver { get; set; }

		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get; set; }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get; set; }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get; set; }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get; set; }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get; set; }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get; set; }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get; set; }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get; set; }

		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get; set; }

		/// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
		public System.String id { get; set; }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public System.String cls { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public System.String overCls { get; set; }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public System.String style { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public System.String ctCls { get; set; }

		/// <summary>  Render this component disabled (default is false).</summary>
		public bool disabled { get; set; }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get; set; }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get; set; }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
		public object applyTo { get; set; }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get; set; }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get; set; }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public System.String stateId { get; set; }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public System.String disabledClass { get; set; }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get; set; }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get; set; }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public System.String hideMode { get; set; }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class DataViewEvents {
        /// <summary>Fires before a click is processed. Returns false to cancel the default action.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Number} index, {HTMLElement} node, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>index</b></term><description>The index of the target node</description></item>
        /// <item><term><b>node</b></term><description>The target node</description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string beforeclick { get { return "beforeclick"; } }
        /// <summary>Fires when a template node is clicked.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Number} index, {HTMLElement} node, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>index</b></term><description>The index of the target node</description></item>
        /// <item><term><b>node</b></term><description>The target node</description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string click { get { return "click"; } }
        /// <summary>Fires when the mouse enters a template node. trackOver:true or an overCls must be set to enable this event.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Number} index, {HTMLElement} node, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>index</b></term><description>The index of the target node</description></item>
        /// <item><term><b>node</b></term><description>The target node</description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string mouseenter { get { return "mouseenter"; } }
        /// <summary>Fires when the mouse leaves a template node. trackOver:true or an overCls must be set to enable this event.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Number} index, {HTMLElement} node, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>index</b></term><description>The index of the target node</description></item>
        /// <item><term><b>node</b></term><description>The target node</description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string mouseleave { get { return "mouseleave"; } }
        /// <summary>Fires when a click occurs and it is not on a template node.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string containerclick { get { return "containerclick"; } }
        /// <summary>Fires when a template node is double clicked.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Number} index, {HTMLElement} node, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>index</b></term><description>The index of the target node</description></item>
        /// <item><term><b>node</b></term><description>The target node</description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string dblclick { get { return "dblclick"; } }
        /// <summary>Fires when a template node is right clicked.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Number} index, {HTMLElement} node, {Ext.EventObject} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>index</b></term><description>The index of the target node</description></item>
        /// <item><term><b>node</b></term><description>The target node</description></item>
        /// <item><term><b>e</b></term><description>The raw event object</description></item>
        /// </list>
        /// </summary>
        public static string contextmenu { get { return "contextmenu"; } }
        /// <summary>Fires when the selected nodes change.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {Array} selections)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>selections</b></term><description>Array of the selected nodes</description></item>
        /// </list>
        /// </summary>
        public static string selectionchange { get { return "selectionchange"; } }
        /// <summary>Fires before a selection is made. If any handlers return false, the selection is cancelled.
        /// <pre><code>
        /// USAGE: ({Ext.DataView} objthis, {HTMLElement} node, {Array} selections)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>node</b></term><description>The node to be selected</description></item>
        /// <item><term><b>selections</b></term><description>Array of currently selected nodes</description></item>
        /// </list>
        /// </summary>
        public static string beforeselect { get { return "beforeselect"; } }
    }

    public delegate void DataViewBeforeclickDelegate(Ext.DataView objthis, double index, DOMElement node, Ext.EventObject e);
    public delegate void DataViewClickDelegate(Ext.DataView objthis, double index, DOMElement node, Ext.EventObject e);
    public delegate void DataViewMouseenterDelegate(Ext.DataView objthis, double index, DOMElement node, Ext.EventObject e);
    public delegate void DataViewMouseleaveDelegate(Ext.DataView objthis, double index, DOMElement node, Ext.EventObject e);
    public delegate void DataViewContainerclickDelegate(Ext.DataView objthis, Ext.EventObject e);
    public delegate void DataViewDblclickDelegate(Ext.DataView objthis, double index, DOMElement node, Ext.EventObject e);
    public delegate void DataViewContextmenuDelegate(Ext.DataView objthis, double index, DOMElement node, Ext.EventObject e);
    public delegate void DataViewSelectionchangeDelegate(Ext.DataView objthis, System.Array selections);
    public delegate void DataViewBeforeselectDelegate(Ext.DataView objthis, DOMElement node, System.Array selections);
}
