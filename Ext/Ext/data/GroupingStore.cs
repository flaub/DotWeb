using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     A specialized store implementation that provides for grouping records by one of the available fields.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\GroupingStore.js</jssource>
	public class GroupingStore : Ext.data.Store {

		/// <summary>
		///     Creates a new GroupingStore.
		///     and read the data into Records.
		/// </summary>
		/// <returns></returns>
		public GroupingStore() { C_(); }
		/// <summary>
		///     Creates a new GroupingStore.
		///     and read the data into Records.
		/// </summary>
		/// <param name="config">A config object containing the objects needed for the Store to access data,</param>
		/// <returns></returns>
		public GroupingStore(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static GroupingStore prototype { get { return S_<GroupingStore>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.Store superclass { get { return S_<Ext.data.Store>(); } set { S_(value); } }

		/// <summary>The field name by which to sort the store's data (defaults to '').</summary>
		public System.String groupField { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     True if the grouping should apply on the server side, false if it is local only (defaults to false).  If the
		///     grouping is local, it can be applied immediately to the data.  If it is remote, then it will simply act as a
		///     helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.
		/// </summary>
		public bool remoteGroup { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the
		///     existing sort info (defaults to false).
		/// </summary>
		public bool groupOnSort { get { return _<bool>(); } set { _(value); } }


		/// <summary>Clears any existing grouping and refreshes the data using the default sort.</summary>
		/// <returns></returns>
		public virtual void clearGrouping() { _(); }

		/// <summary>
		///     Groups the data by the specified field.
		///     in is the same as the current grouping field, false to skip grouping on the same field (defaults to false)
		/// </summary>
		/// <returns></returns>
		public virtual void groupBy() { _(); }

		/// <summary>
		///     Groups the data by the specified field.
		///     in is the same as the current grouping field, false to skip grouping on the same field (defaults to false)
		/// </summary>
		/// <param name="field">The field name by which to sort the store's data</param>
		/// <returns></returns>
		public virtual void groupBy(System.String field) { _(field); }

		/// <summary>
		///     Groups the data by the specified field.
		///     in is the same as the current grouping field, false to skip grouping on the same field (defaults to false)
		/// </summary>
		/// <param name="field">The field name by which to sort the store's data</param>
		/// <param name="forceRegroup">(optional) True to force the group to be refreshed even if the field passed</param>
		/// <returns></returns>
		public virtual void groupBy(System.String field, bool forceRegroup) { _(field, forceRegroup); }



	}

	[JsAnonymous]
	public class GroupingStoreConfig : DotWeb.Client.JsAccessible {
		/// <summary>  The field name by which to sort the store's data (defaults to '').</summary>
		public System.String groupField { get; set; }

		/// <summary>  True if the grouping should apply on the server side, false if it is local only (defaults to false).  If the grouping is local, it can be applied immediately to the data.  If it is remote, then it will simply act as a helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.</summary>
		public bool remoteGroup { get; set; }

		/// <summary>  True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the existing sort info (defaults to false).</summary>
		public bool groupOnSort { get; set; }

		/// <summary> If passed, the id to use to register with the StoreMgr</summary>
		public System.String storeId { get; set; }

		/// <summary> If passed, an HttpProxy is created for the passed URL</summary>
		public System.String url { get; set; }

		/// <summary>{Boolean/Object} If passed, this store's load method is automatically called after creation with the autoLoad object</summary>
		public object autoLoad { get; set; }

		/// <summary> The Proxy object which provides access to a data object.</summary>
		public Ext.data.DataProxy proxy { get; set; }

		/// <summary> Inline data to be loaded when the store is initialized.</summary>
		public System.Array data { get; set; }

		/// <summary> The DataReader object which processes the data object and returns an Array of Ext.data.Record objects which are cached keyed by their <em>id</em> property.</summary>
		public Ext.data.DataReader reader { get; set; }

		/// <summary> An object containing properties which are to be sent as parameters on any HTTP request</summary>
		public object baseParams { get; set; }

		/// <summary> A config object in the format: {field: "fieldName", direction: "ASC|DESC"}.  The direction property is case-sensitive.</summary>
		public object sortInfo { get; set; }

		/// <summary> True if sorting is to be handled by requesting the Proxy to provide a refreshed version of the data object in sorted order, as opposed to sorting the Record cache in place (defaults to false). <p>If remote sorting is specified, then clicking on a column header causes the current page to be requested from the server with the addition of the following two parameters: <div class="mdetail-params"><ul> <li><b>sort</b> : String<p class="sub-desc">The name (as specified in the Record's Field definition) of the field to sort on.</p></li> <li><b>dir</b> : String<p class="sub-desc">The direction of the sort, "ASC" or "DESC" (case-sensitive).</p></li> </ul></div></p></summary>
		public bool remoteSort { get; set; }

		/// <summary> True to clear all modified record information each time the store is loaded or when a record is removed. (defaults to false).</summary>
		public bool pruneModifiedRecords { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}
}
