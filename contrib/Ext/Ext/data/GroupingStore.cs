using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     A specialized store implementation that provides for grouping records by one of the available fields.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\GroupingStore.js</jssource>
	public class GroupingStore : Ext.data.Store {

		/// <summary>
		///     Creates a new GroupingStore.
		///     and read the data into Records.
		/// </summary>
		/// <returns></returns>
		public extern GroupingStore();
		/// <summary>
		///     Creates a new GroupingStore.
		///     and read the data into Records.
		/// </summary>
		/// <param name="config">A config object containing the objects needed for the Store to access data,</param>
		/// <returns></returns>
		public extern GroupingStore(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static GroupingStore prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.data.Store superclass { get; set; }

		/// <summary>The field name by which to sort the store's data (defaults to '').</summary>
		public extern string groupField { get; set; }

		/// <summary>
		///     True if the grouping should apply on the server side, false if it is local only (defaults to false).  If the
		///     grouping is local, it can be applied immediately to the data.  If it is remote, then it will simply act as a
		///     helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.
		/// </summary>
		public extern bool remoteGroup { get; set; }

		/// <summary>
		///     True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the
		///     existing sort info (defaults to false).
		/// </summary>
		public extern bool groupOnSort { get; set; }


		/// <summary>Clears any existing grouping and refreshes the data using the default sort.</summary>
		/// <returns></returns>
		public extern virtual void clearGrouping();

		/// <summary>
		///     Groups the data by the specified field.
		///     in is the same as the current grouping field, false to skip grouping on the same field (defaults to false)
		/// </summary>
		/// <returns></returns>
		public extern virtual void groupBy();

		/// <summary>
		///     Groups the data by the specified field.
		///     in is the same as the current grouping field, false to skip grouping on the same field (defaults to false)
		/// </summary>
		/// <param name="field">The field name by which to sort the store's data</param>
		/// <returns></returns>
		public extern virtual void groupBy(string field);

		/// <summary>
		///     Groups the data by the specified field.
		///     in is the same as the current grouping field, false to skip grouping on the same field (defaults to false)
		/// </summary>
		/// <param name="field">The field name by which to sort the store's data</param>
		/// <param name="forceRegroup">(optional) True to force the group to be refreshed even if the field passed</param>
		/// <returns></returns>
		public extern virtual void groupBy(string field, bool forceRegroup);



	}

	[JsAnonymous]
	public class GroupingStoreConfig : System.DotWeb.JsDynamic {
		/// <summary>  The field name by which to sort the store's data (defaults to '').</summary>
		public string groupField { get { return (string)this["groupField"]; } set { this["groupField"] = value; } }

		/// <summary>  True if the grouping should apply on the server side, false if it is local only (defaults to false).  If the grouping is local, it can be applied immediately to the data.  If it is remote, then it will simply act as a helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.</summary>
		public bool remoteGroup { get { return (bool)this["remoteGroup"]; } set { this["remoteGroup"] = value; } }

		/// <summary>  True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the existing sort info (defaults to false).</summary>
		public bool groupOnSort { get { return (bool)this["groupOnSort"]; } set { this["groupOnSort"] = value; } }

		/// <summary> If passed, the id to use to register with the StoreMgr</summary>
		public string storeId { get { return (string)this["storeId"]; } set { this["storeId"] = value; } }

		/// <summary> If passed, an HttpProxy is created for the passed URL</summary>
		public string url { get { return (string)this["url"]; } set { this["url"] = value; } }

		/// <summary>{Boolean/Object} If passed, this store's load method is automatically called after creation with the autoLoad object</summary>
		public object autoLoad { get { return (object)this["autoLoad"]; } set { this["autoLoad"] = value; } }

		/// <summary> The Proxy object which provides access to a data object.</summary>
		public Ext.data.DataProxy proxy { get { return (Ext.data.DataProxy)this["proxy"]; } set { this["proxy"] = value; } }

		/// <summary> Inline data to be loaded when the store is initialized.</summary>
		public System.Array data { get { return (System.Array)this["data"]; } set { this["data"] = value; } }

		/// <summary> The DataReader object which processes the data object and returns an Array of Ext.data.Record objects which are cached keyed by their <em>id</em> property.</summary>
		public Ext.data.DataReader reader { get { return (Ext.data.DataReader)this["reader"]; } set { this["reader"] = value; } }

		/// <summary> An object containing properties which are to be sent as parameters on any HTTP request</summary>
		public object baseParams { get { return (object)this["baseParams"]; } set { this["baseParams"] = value; } }

		/// <summary> A config object in the format: {field: "fieldName", direction: "ASC|DESC"}.  The direction property is case-sensitive.</summary>
		public object sortInfo { get { return (object)this["sortInfo"]; } set { this["sortInfo"] = value; } }

		/// <summary> True if sorting is to be handled by requesting the Proxy to provide a refreshed version of the data object in sorted order, as opposed to sorting the Record cache in place (defaults to false). <p>If remote sorting is specified, then clicking on a column header causes the current page to be requested from the server with the addition of the following two parameters: <div class="mdetail-params"><ul> <li><b>sort</b> : String<p class="sub-desc">The name (as specified in the Record's Field definition) of the field to sort on.</p></li> <li><b>dir</b> : String<p class="sub-desc">The direction of the sort, "ASC" or "DESC" (case-sensitive).</p></li> </ul></div></p></summary>
		public bool remoteSort { get { return (bool)this["remoteSort"]; } set { this["remoteSort"] = value; } }

		/// <summary> True to clear all modified record information each time the store is loaded or when a record is removed. (defaults to false).</summary>
		public bool pruneModifiedRecords { get { return (bool)this["pruneModifiedRecords"]; } set { this["pruneModifiedRecords"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}
}
