using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     The Store class encapsulates a client side cache of {@link Ext.data.Record Record}
	///     objects which provide input data for Components such as the {@link Ext.grid.GridPanel GridPanel},
	///     the {@link Ext.form.ComboBox ComboBox}, or the {@link Ext.DataView DataView}</p>
	///     <p>A Store object uses its {@link #proxy configured} implementation of {@link Ext.data.DataProxy DataProxy}
	///     to access a data object unless you call {@link #loadData} directly and pass in your data.</p>
	///     <p>A Store object has no knowledge of the format of the data returned by the Proxy.</p>
	///     <p>A Store object uses its {@link #reader configured} implementation of {@link Ext.data.DataReader DataReader}
	///     to create {@link Ext.data.Record Record} instances from the data object. These Records
	///     are cached and made available through accessor functions.</p>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\Store.js</jssource>
	public class Store : Ext.util.Observable {

		/// <summary>
		///     Creates a new Store.
		///     and read the data into Records.
		/// </summary>
		/// <returns></returns>
		public extern Store();
		/// <summary>
		///     Creates a new Store.
		///     and read the data into Records.
		/// </summary>
		/// <param name="config">A config object containing the objects needed for the Store to access data,</param>
		/// <returns></returns>
		public extern Store(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Ext.data.Store prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>
		///     An object containing properties which are used as parameters on any HTTP request.
		///     This property can be changed after creating the Store to send different parameters.
		/// </summary>
		public extern object baseParams { get; set; }

		/// <summary>If passed, the id to use to register with the StoreMgr</summary>
		public extern string storeId { get; set; }

		/// <summary>If passed, an HttpProxy is created for the passed URL</summary>
		public extern string url { get; set; }

		/// <summary>If passed, this store's load method is automatically called after creation with the autoLoad object</summary>
		public extern object autoLoad { get; set; }

		/// <summary>The Proxy object which provides access to a data object.</summary>
		public extern Ext.data.DataProxy proxy { get; set; }

		/// <summary>Inline data to be loaded when the store is initialized.</summary>
		public extern System.Array data { get; set; }

		/// <summary>The DataReader object which processes the data object and returnsan Array of Ext.data.Record objects which are cached keyed by their <em>id</em> property.</summary>
		public extern Ext.data.DataReader reader { get; set; }

		/// <summary>A config object in the format: {field: "fieldName", direction: "ASC|DESC"}.  The directionproperty is case-sensitive.</summary>
		public extern object sortInfo { get; set; }

		/// <summary>
		///     True if sorting is to be handled by requesting theProxy to provide a refreshed version of the data object in sorted order, as
		///     opposed to sorting the Record cache in place (defaults to false).
		///     <p>If remote sorting is specified, then clicking on a column header causes the
		///     current page to be requested from the server with the addition of the following
		///     two parameters:
		///     <div class="mdetail-params"><ul>
		///     <li><b>sort</b> : String<p class="sub-desc">The name (as specified in
		///     the Record's Field definition) of the field to sort on.</p></li>
		///     <li><b>dir</b> : String<p class="sub-desc">The direction of the sort, "ASC" or "DESC" (case-sensitive).</p></li>
		///     </ul></div></p>
		/// </summary>
		public extern bool remoteSort { get; set; }

		/// <summary>True to clear all modified record information each time the store isloaded or when a record is removed. (defaults to false).</summary>
		public extern bool pruneModifiedRecords { get; set; }

		/// <summary>
		///     Contains the last options object used as the parameter to the load method. See {@link #load}
		///     for the details of what this may contain. This may be useful for accessing any params which
		///     were used to load the current Record cache.
		/// </summary>
		public extern object lastOptions { get; set; }


		/// <summary>Add Records to the Store and fires the {@link #add} event.</summary>
		/// <returns></returns>
		public extern virtual void add();

		/// <summary>Add Records to the Store and fires the {@link #add} event.</summary>
		/// <param name="records">An Array of Ext.data.Record objects to add to the cache.</param>
		/// <returns></returns>
		public extern virtual void add(Ext.data.Record[] records);

		/// <summary>
		///     (Local sort only) Inserts the passed Record into the Store at the index where it
		///     should go based on the current sort information.
		/// </summary>
		/// <returns></returns>
		public extern virtual void addSorted();

		/// <summary>
		///     (Local sort only) Inserts the passed Record into the Store at the index where it
		///     should go based on the current sort information.
		/// </summary>
		/// <param name="record"></param>
		/// <returns></returns>
		public extern virtual void addSorted(Ext.data.Record record);

		/// <summary>Remove a Record from the Store and fires the {@link #remove} event.</summary>
		/// <returns></returns>
		public extern virtual void remove();

		/// <summary>Remove a Record from the Store and fires the {@link #remove} event.</summary>
		/// <param name="record">Th Ext.data.Record object to remove from the cache.</param>
		/// <returns></returns>
		public extern virtual void remove(Ext.data.Record record);

		/// <summary>Remove all Records from the Store and fires the {@link #clear} event.</summary>
		/// <returns></returns>
		public extern virtual void removeAll();

		/// <summary>Inserts Records into the Store at the given index and fires the {@link #add} event.</summary>
		/// <returns></returns>
		public extern virtual void insert();

		/// <summary>Inserts Records into the Store at the given index and fires the {@link #add} event.</summary>
		/// <param name="index">The start index at which to insert the passed Records.</param>
		/// <returns></returns>
		public extern virtual void insert(double index);

		/// <summary>Inserts Records into the Store at the given index and fires the {@link #add} event.</summary>
		/// <param name="index">The start index at which to insert the passed Records.</param>
		/// <param name="records">An Array of Ext.data.Record objects to add to the cache.</param>
		/// <returns></returns>
		public extern virtual void insert(double index, Ext.data.Record[] records);

		/// <summary>Get the index within the cache of the passed Record.</summary>
		/// <returns>Number</returns>
		public extern virtual void indexOf();

		/// <summary>Get the index within the cache of the passed Record.</summary>
		/// <param name="record">The Ext.data.Record object to find.</param>
		/// <returns>Number</returns>
		public extern virtual void indexOf(Ext.data.Record record);

		/// <summary>Get the index within the cache of the Record with the passed id.</summary>
		/// <returns>Number</returns>
		public extern virtual void indexOfId();

		/// <summary>Get the index within the cache of the Record with the passed id.</summary>
		/// <param name="id">The id of the Record to find.</param>
		/// <returns>Number</returns>
		public extern virtual void indexOfId(string id);

		/// <summary>Get the Record with the specified id.</summary>
		/// <returns>Ext.data.Record</returns>
		public extern virtual void getById();

		/// <summary>Get the Record with the specified id.</summary>
		/// <param name="id">The id of the Record to find.</param>
		/// <returns>Ext.data.Record</returns>
		public extern virtual void getById(string id);

		/// <summary>Get the Record at the specified index.</summary>
		/// <returns>Ext.data.Record</returns>
		public extern virtual void getAt();

		/// <summary>Get the Record at the specified index.</summary>
		/// <param name="index">The index of the Record to find.</param>
		/// <returns>Ext.data.Record</returns>
		public extern virtual void getAt(double index);

		/// <summary>Returns a range of Records between specified indices.</summary>
		/// <returns>Ext.data.Record[]</returns>
		public extern virtual void getRange();

		/// <summary>Returns a range of Records between specified indices.</summary>
		/// <param name="startIndex">(optional) The starting index (defaults to 0)</param>
		/// <returns>Ext.data.Record[]</returns>
		public extern virtual void getRange(double startIndex);

		/// <summary>Returns a range of Records between specified indices.</summary>
		/// <param name="startIndex">(optional) The starting index (defaults to 0)</param>
		/// <param name="endIndex">(optional) The ending index (defaults to the last Record in the Store)</param>
		/// <returns>Ext.data.Record[]</returns>
		public extern virtual void getRange(double startIndex, double endIndex);

		/// <summary>
		///     Loads the Record cache from the configured Proxy using the configured Reader.
		///     <p>If using remote paging, then the first load call must specify the <tt>start</tt>
		///     and <tt>limit</tt> properties in the options.params property to establish the initial
		///     position within the dataset, and the number of Records to cache on each read from the Proxy.</p>
		///     <p><b>It is important to note that for remote data sources, loading is asynchronous,
		///     and this call will return before the new data has been loaded. Perform any post-processing
		///     in a callback function, or in a "load" event handler.</b></p>
		///     <li><b>params</b> :Object<p class="sub-desc">An object containing properties to pass as HTTP parameters to a remote data source.</p></li>
		///     <li><b>callback</b> : Function<p class="sub-desc">A function to be called after the Records have been loaded. The callback is
		///     passed the following arguments:<ul>
		///     <li>r : Ext.data.Record[]</li>
		///     <li>options: Options object from the load call</li>
		///     <li>success: Boolean success indicator</li></ul></p></li>
		///     <li><b>scope</b> : Object<p class="sub-desc">Scope with which to call the callback (defaults to the Store object)</p></li>
		///     <li><b>add</b> : Boolean<p class="sub-desc">Indicator to append loaded records rather than replace the current cache.</p></li>
		///     </ul>
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void load();

		/// <summary>
		///     Loads the Record cache from the configured Proxy using the configured Reader.
		///     <p>If using remote paging, then the first load call must specify the <tt>start</tt>
		///     and <tt>limit</tt> properties in the options.params property to establish the initial
		///     position within the dataset, and the number of Records to cache on each read from the Proxy.</p>
		///     <p><b>It is important to note that for remote data sources, loading is asynchronous,
		///     and this call will return before the new data has been loaded. Perform any post-processing
		///     in a callback function, or in a "load" event handler.</b></p>
		///     <li><b>params</b> :Object<p class="sub-desc">An object containing properties to pass as HTTP parameters to a remote data source.</p></li>
		///     <li><b>callback</b> : Function<p class="sub-desc">A function to be called after the Records have been loaded. The callback is
		///     passed the following arguments:<ul>
		///     <li>r : Ext.data.Record[]</li>
		///     <li>options: Options object from the load call</li>
		///     <li>success: Boolean success indicator</li></ul></p></li>
		///     <li><b>scope</b> : Object<p class="sub-desc">Scope with which to call the callback (defaults to the Store object)</p></li>
		///     <li><b>add</b> : Boolean<p class="sub-desc">Indicator to append loaded records rather than replace the current cache.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="options">An object containing properties which control loading options:<ul></param>
		/// <returns>Boolean</returns>
		public extern virtual void load(object options);

		/// <summary>
		///     Reloads the Record cache from the configured Proxy using the configured Reader and
		///     the options from the last load operation performed.
		///     used in the last load operation. See {@link #load} for details (defaults to null, in which case
		///     the most recently used options are reused).
		/// </summary>
		/// <returns></returns>
		public extern virtual void reload();

		/// <summary>
		///     Reloads the Record cache from the configured Proxy using the configured Reader and
		///     the options from the last load operation performed.
		///     used in the last load operation. See {@link #load} for details (defaults to null, in which case
		///     the most recently used options are reused).
		/// </summary>
		/// <param name="options">(optional) An object containing properties which may override the options</param>
		/// <returns></returns>
		public extern virtual void reload(object options);

		/// <summary>
		///     Loads data from a passed data block and fires the {@link #load} event. A Reader which understands the format of the data
		///     must have been configured in the constructor.
		///     is dependent on the type of Reader that is configured and should correspond to that Reader's readRecords parameter.
		/// </summary>
		/// <returns></returns>
		public extern virtual void loadData();

		/// <summary>
		///     Loads data from a passed data block and fires the {@link #load} event. A Reader which understands the format of the data
		///     must have been configured in the constructor.
		///     is dependent on the type of Reader that is configured and should correspond to that Reader's readRecords parameter.
		/// </summary>
		/// <param name="data">The data block from which to read the Records.  The format of the data expected</param>
		/// <returns></returns>
		public extern virtual void loadData(object data);

		/// <summary>
		///     Loads data from a passed data block and fires the {@link #load} event. A Reader which understands the format of the data
		///     must have been configured in the constructor.
		///     is dependent on the type of Reader that is configured and should correspond to that Reader's readRecords parameter.
		/// </summary>
		/// <param name="data">The data block from which to read the Records.  The format of the data expected</param>
		/// <param name="append">(Optional) True to append the new Records rather than replace the existing cache.</param>
		/// <returns></returns>
		public extern virtual void loadData(object data, bool append);

		/// <summary>
		///     Gets the number of cached records.
		///     <p>If using paging, this may not be the total size of the dataset. If the data object
		///     used by the Reader contains the dataset size, then the {@link #getTotalCount} function returns
		///     the dataset size.</p>
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getCount();

		/// <summary>
		///     Gets the total number of records in the dataset as returned by the server.
		///     <p>If using paging, for this to be accurate, the data object used by the Reader must contain
		///     the dataset size. For remote data sources, this is provided by a query on the server.</p>
		///     by the Proxy
		///     <p><b>This value is not updated when changing the contents of the Store locally.</b></p>
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getTotalCount();

		/// <summary>
		///     Returns an object describing the current sort state of this Store.
		///     <li><b>field : String<p class="sub-desc">The name of the field by which the Records are sorted.</p></li>
		///     <li><b>direction : String<p class="sub-desc">The sort order, "ASC" or "DESC" (case-sensitive).</p></li>
		///     </ul>
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getSortState();

		/// <summary>Sets the default sort column and order to be used by the next load operation.</summary>
		/// <returns></returns>
		public extern virtual void setDefaultSort();

		/// <summary>Sets the default sort column and order to be used by the next load operation.</summary>
		/// <param name="fieldName">The name of the field to sort by.</param>
		/// <returns></returns>
		public extern virtual void setDefaultSort(string fieldName);

		/// <summary>Sets the default sort column and order to be used by the next load operation.</summary>
		/// <param name="fieldName">The name of the field to sort by.</param>
		/// <param name="dir">(optional) The sort order, "ASC" or "DESC" (case-sensitive, defaults to "ASC")</param>
		/// <returns></returns>
		public extern virtual void setDefaultSort(string fieldName, string dir);

		/// <summary>
		///     Sort the Records.
		///     If remote sorting is used, the sort is performed on the server, and the cache is
		///     reloaded. If local sorting is used, the cache is sorted internally.
		/// </summary>
		/// <returns></returns>
		public extern virtual void sort();

		/// <summary>
		///     Sort the Records.
		///     If remote sorting is used, the sort is performed on the server, and the cache is
		///     reloaded. If local sorting is used, the cache is sorted internally.
		/// </summary>
		/// <param name="fieldName">The name of the field to sort by.</param>
		/// <returns></returns>
		public extern virtual void sort(string fieldName);

		/// <summary>
		///     Sort the Records.
		///     If remote sorting is used, the sort is performed on the server, and the cache is
		///     reloaded. If local sorting is used, the cache is sorted internally.
		/// </summary>
		/// <param name="fieldName">The name of the field to sort by.</param>
		/// <param name="dir">(optional) The sort order, "ASC" or "DESC" (case-sensitive, defaults to "ASC")</param>
		/// <returns></returns>
		public extern virtual void sort(string fieldName, string dir);

		/// <summary>
		///     Calls the specified function for each of the Records in the cache.
		///     Returning <tt>false</tt> aborts and exits the iteration.
		/// </summary>
		/// <returns></returns>
		public extern virtual void each();

		/// <summary>
		///     Calls the specified function for each of the Records in the cache.
		///     Returning <tt>false</tt> aborts and exits the iteration.
		/// </summary>
		/// <param name="fn">The function to call. The Record is passed as the first parameter.</param>
		/// <returns></returns>
		public extern virtual void each(Delegate fn);

		/// <summary>
		///     Calls the specified function for each of the Records in the cache.
		///     Returning <tt>false</tt> aborts and exits the iteration.
		/// </summary>
		/// <param name="fn">The function to call. The Record is passed as the first parameter.</param>
		/// <param name="scope">(optional) The scope in which to call the function (defaults to the Record).</param>
		/// <returns></returns>
		public extern virtual void each(Delegate fn, object scope);

		/// <summary>
		///     Gets all records modified since the last commit.  Modified records are persisted across load operations
		///     (e.g., during paging).
		/// </summary>
		/// <returns>Ext.data.Record[]</returns>
		public extern virtual void getModifiedRecords();

		/// <summary>Sums the value of <i>property</i> for each record between start and end and returns the result.</summary>
		/// <returns>Number</returns>
		public extern virtual void sum();

		/// <summary>Sums the value of <i>property</i> for each record between start and end and returns the result.</summary>
		/// <param name="property">A field on your records</param>
		/// <returns>Number</returns>
		public extern virtual void sum(string property);

		/// <summary>Sums the value of <i>property</i> for each record between start and end and returns the result.</summary>
		/// <param name="property">A field on your records</param>
		/// <param name="start">The record index to start at (defaults to 0)</param>
		/// <returns>Number</returns>
		public extern virtual void sum(string property, double start);

		/// <summary>Sums the value of <i>property</i> for each record between start and end and returns the result.</summary>
		/// <param name="property">A field on your records</param>
		/// <param name="start">The record index to start at (defaults to 0)</param>
		/// <param name="end">The last record index to include (defaults to length - 1)</param>
		/// <returns>Number</returns>
		public extern virtual void sum(string property, double start, double end);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <returns></returns>
		public extern virtual void filter();

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <returns></returns>
		public extern virtual void filter(string field);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <returns></returns>
		public extern virtual void filter(string field, string value);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <returns></returns>
		public extern virtual void filter(string field, string value, bool anyMatch);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <param name="caseSensitive">(optional) True for case sensitive comparison</param>
		/// <returns></returns>
		public extern virtual void filter(string field, string value, bool anyMatch, bool caseSensitive);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <returns></returns>
		public extern virtual void filter(string field, object value);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <returns></returns>
		public extern virtual void filter(string field, object value, bool anyMatch);

		/// <summary>
		///     Filter the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <param name="caseSensitive">(optional) True for case sensitive comparison</param>
		/// <returns></returns>
		public extern virtual void filter(string field, object value, bool anyMatch, bool caseSensitive);

		/// <summary>
		///     Filter by a function. The specified function will be called for each
		///     Record in this Store. If the function returns <tt>true</tt> the Record is included,
		///     otherwise it is filtered out.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <returns></returns>
		public extern virtual void filterBy();

		/// <summary>
		///     Filter by a function. The specified function will be called for each
		///     Record in this Store. If the function returns <tt>true</tt> the Record is included,
		///     otherwise it is filtered out.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <returns></returns>
		public extern virtual void filterBy(Delegate fn);

		/// <summary>
		///     Filter by a function. The specified function will be called for each
		///     Record in this Store. If the function returns <tt>true</tt> the Record is included,
		///     otherwise it is filtered out.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <param name="scope">(optional) The scope of the function (defaults to this)</param>
		/// <returns></returns>
		public extern virtual void filterBy(Delegate fn, object scope);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <returns>MixedCollection</returns>
		public extern virtual void query();

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field, string value);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field, string value, bool anyMatch);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <param name="caseSensitive">(optional) True for case sensitive comparison</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field, string value, bool anyMatch, bool caseSensitive);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field, object value);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field, object value, bool anyMatch);

		/// <summary>
		///     Query the records by a specified property.
		///     should begin with, or a RegExp to test against the field.
		/// </summary>
		/// <param name="field">A field on your records</param>
		/// <param name="value">Either a string that the field</param>
		/// <param name="anyMatch">(optional) True to match any part not just the beginning</param>
		/// <param name="caseSensitive">(optional) True for case sensitive comparison</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void query(string field, object value, bool anyMatch, bool caseSensitive);

		/// <summary>
		///     Query the cached records in this Store using a filtering function. The specified function
		///     will be called with each record in this Store. If the function returns <tt>true</tt> the record is
		///     included in the results.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <returns>MixedCollection</returns>
		public extern virtual void find();

		/// <summary>
		///     Query the cached records in this Store using a filtering function. The specified function
		///     will be called with each record in this Store. If the function returns <tt>true</tt> the record is
		///     included in the results.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <returns>MixedCollection</returns>
		public extern virtual void find(Delegate fn);

		/// <summary>
		///     Query the cached records in this Store using a filtering function. The specified function
		///     will be called with each record in this Store. If the function returns <tt>true</tt> the record is
		///     included in the results.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <param name="scope">(optional) The scope of the function (defaults to this)</param>
		/// <returns>MixedCollection</returns>
		public extern virtual void find(Delegate fn, object scope);

		/// <summary>
		///     Find the index of the first matching Record in this Store by a function.
		///     If the function returns <tt>true</tt> it is considered a match.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void findBy();

		/// <summary>
		///     Find the index of the first matching Record in this Store by a function.
		///     If the function returns <tt>true</tt> it is considered a match.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <returns>Number</returns>
		public extern virtual void findBy(Delegate fn);

		/// <summary>
		///     Find the index of the first matching Record in this Store by a function.
		///     If the function returns <tt>true</tt> it is considered a match.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <param name="scope">(optional) The scope of the function (defaults to this)</param>
		/// <returns>Number</returns>
		public extern virtual void findBy(Delegate fn, object scope);

		/// <summary>
		///     Find the index of the first matching Record in this Store by a function.
		///     If the function returns <tt>true</tt> it is considered a match.
		///     <li><b>record</b> : Ext.data.Record<p class="sub-desc">The {@link Ext.data.Record record}
		///     to test for filtering. Access field values using {@link Ext.data.Record#get}.</p></li>
		///     <li><b>id</b> : Object<p class="sub-desc">The ID of the Record passed.</p></li>
		///     </ul>
		/// </summary>
		/// <param name="fn">The function to be called. It will be passed the following parameters:<ul></param>
		/// <param name="scope">(optional) The scope of the function (defaults to this)</param>
		/// <param name="startIndex">(optional) The index to start searching at</param>
		/// <returns>Number</returns>
		public extern virtual void findBy(Delegate fn, object scope, double startIndex);

		/// <summary>Collects unique values for a particular dataIndex from this store.</summary>
		/// <returns>Array</returns>
		public extern virtual void clearFilter();

		/// <summary>Collects unique values for a particular dataIndex from this store.</summary>
		/// <param name="dataIndex">The property to collect</param>
		/// <returns>Array</returns>
		public extern virtual void clearFilter(string dataIndex);

		/// <summary>Collects unique values for a particular dataIndex from this store.</summary>
		/// <param name="dataIndex">The property to collect</param>
		/// <param name="allowNull">(optional) Pass true to allow null, undefined or empty string values</param>
		/// <returns>Array</returns>
		public extern virtual void clearFilter(string dataIndex, bool allowNull);

		/// <summary>Collects unique values for a particular dataIndex from this store.</summary>
		/// <param name="dataIndex">The property to collect</param>
		/// <param name="allowNull">(optional) Pass true to allow null, undefined or empty string values</param>
		/// <param name="bypassFilter">(optional) Pass true to collect from all records, even ones which are filtered</param>
		/// <returns>Array</returns>
		public extern virtual void clearFilter(string dataIndex, bool allowNull, bool bypassFilter);

		/// <summary>Returns true if this store is currently filtered</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isFiltered();

		/// <summary>
		///     Commit all Records with outstanding changes. To handle updates for changes, subscribe to the
		///     Store's "update" event, and perform updating when the third parameter is Ext.data.Record.COMMIT.
		/// </summary>
		/// <returns></returns>
		public extern virtual void commitChanges();

		/// <summary>Cancel outstanding changes on all changed records.</summary>
		/// <returns></returns>
		public extern virtual void rejectChanges();



	}

	[JsAnonymous]
	public class StoreConfig : System.DotWeb.JsDynamic {
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

    public class StoreEvents {
        /// <summary>
        ///     Fires when the data cache has changed, and a widget which is using this Store
        ///     as a Record cache should refresh its view.
        /// 
        /// <pre><code>
        /// USAGE: ({Store} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string datachanged { get { return "datachanged"; } }
        /// <summary>Fires when this store's reader provides new metadata (fields). This is currently only supported for JsonReaders.
        /// <pre><code>
        /// USAGE: ({Store} objthis, {Object} meta)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>meta</b></term><description>The JSON metadata</description></item>
        /// </list>
        /// </summary>
        public static string metachange { get { return "metachange"; } }
        /// <summary>Fires when Records have been added to the Store
        /// <pre><code>
        /// USAGE: ({Store} objthis, {Ext.data.Record[]} records, {Number} index)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>records</b></term><description>The array of Records added</description></item>
        /// <item><term><b>index</b></term><description>The index at which the record(s) were added</description></item>
        /// </list>
        /// </summary>
        public static string add { get { return "add"; } }
        /// <summary>Fires when a Record has been removed from the Store
        /// <pre><code>
        /// USAGE: ({Store} objthis, {Ext.data.Record} record, {Number} index)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>record</b></term><description>The Record that was removed</description></item>
        /// <item><term><b>index</b></term><description>The index at which the record was removed</description></item>
        /// </list>
        /// </summary>
        public static string remove { get { return "remove"; } }
        /// <summary>
        ///     Fires when a Record has been updated
        ///     <pre><code>
        ///     Ext.data.Record.EDIT
        ///     Ext.data.Record.REJECT
        ///     Ext.data.Record.COMMIT
        ///     </code></pre>
        /// 
        /// <pre><code>
        /// USAGE: ({Store} objthis, {Ext.data.Record} record, {String} operation)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>record</b></term><description>The Record that was updated</description></item>
        /// <item><term><b>operation</b></term><description>The update operation being performed.  Value may be one of:</description></item>
        /// </list>
        /// </summary>
        public static string update { get { return "update"; } }
        /// <summary>Fires when the data cache has been cleared.
        /// <pre><code>
        /// USAGE: ({Store} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string clear { get { return "clear"; } }
        /// <summary>
        ///     Fires before a request is made for a new data object.  If the beforeload handler returns false
        ///     the load action will be canceled.
        /// 
        /// <pre><code>
        /// USAGE: ({Store} objthis, {Object} options)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>options</b></term><description>The loading options that were specified (see {@link #load} for details)</description></item>
        /// </list>
        /// </summary>
        public static string beforeload { get { return "beforeload"; } }
        /// <summary>Fires after a new set of Records has been loaded.
        /// <pre><code>
        /// USAGE: ({Store} objthis, {Ext.data.Record[]} records, {Object} options)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>records</b></term><description>The Records that were loaded</description></item>
        /// <item><term><b>options</b></term><description>The loading options that were specified (see {@link #load} for details)</description></item>
        /// </list>
        /// </summary>
        public static string load { get { return "load"; } }
        /// <summary>
        ///     Fires if an exception occurs in the Proxy during loading.
        ///     Called with the signature of the Proxy's "loadexception" event.
        /// 
        /// <pre><code>
        /// USAGE: ()
        /// </code></pre>
        /// <list type="bullet">
        /// </list>
        /// </summary>
        public static string loadexception { get { return "loadexception"; } }
    }

    public delegate void StoreDatachangedDelegate(Ext.data.Store objthis);
    public delegate void StoreMetachangeDelegate(Ext.data.Store objthis, object meta);
    public delegate void StoreAddDelegate(Ext.data.Store objthis, Ext.data.Record[] records, double index);
    public delegate void StoreRemoveDelegate(Ext.data.Store objthis, Ext.data.Record record, double index);
    public delegate void StoreUpdateDelegate(Ext.data.Store objthis, Ext.data.Record record, string operation);
    public delegate void StoreClearDelegate(Ext.data.Store objthis);
    public delegate void StoreBeforeloadDelegate(Ext.data.Store objthis, object options);
    public delegate void StoreLoadDelegate(Ext.data.Store objthis, Ext.data.Record[] records, object options);
    public delegate void StoreLoadexceptionDelegate();
}
