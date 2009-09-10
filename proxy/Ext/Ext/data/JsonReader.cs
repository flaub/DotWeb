using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     Data reader class to create an Array of {@link Ext.data.Record} objects from a JSON response
	///     based on mappings in a provided {@link Ext.data.Record} constructor.<br>
	///     <p>
	///     Example code:
	///     <pre><code>
	///     var Employee = Ext.data.Record.create([
	///     {name: 'firstname'},                  // Map the Record's "firstname" field to the row object's key of the same name
	///     {name: 'job', mapping: 'occupation'}  // Map the "job" field to the row object's "occupation" key
	///     ]);
	///     var myReader = new Ext.data.JsonReader({
	///     totalProperty: "results",             // The property which contains the total dataset size (optional)
	///     root: "rows",                         // The property which contains an Array of row objects
	///     id: "id"                              // The property within each row object that provides an ID for the record (optional)
	///     }, Employee);
	///     </code></pre>
	///     <p>
	///     This would consume a JSON object of the form:
	///     <pre><code>
	///     {
	///     'results': 2,
	///     'rows': [
	///     { 'id': 1, 'firstname': 'Bill', occupation: 'Gardener' },         // a row object
	///     { 'id': 2, 'firstname': 'Ben' , occupation: 'Horticulturalist' }  // another row object
	///     ]
	///     }
	///     </code></pre>
	///     <p>It is possible to change a JsonReader's metadata at any time by including a
	///     <b><tt>metaData</tt></b> property in the data object. If this is detected in the
	///     object, a {@link Ext.data.Store Store} object using this Reader will fire its
	///     {@link Ext.data.Store#metachange metachange} event.</p>
	///     <p>The <b><tt>metaData</tt></b> property may contain any of the configuration
	///     options for this class. Additionally, it may contain a <b><tt>fields</tt></b>
	///     property which the JsonReader will use as an argument to {@link Ext.data.Record#create}
	///     to configure the layout of the Records which it will produce.<p>
	///     Using the <b><tt>metaData</tt></b> property, and the Store's {@link Ext.data.Store#metachange metachange} event,
	///     it is possible to have a Store-driven control initialize itself. The metachange
	///     event handler may interrogate the <b><tt>metaData</tt></b> property (which
	///     may contain any user-defined properties needed) and the <b><tt>metaData.fields</tt></b>
	///     property to perform any configuration required.</p>
	///     <p>To use this facility to send the same data as the above example without
	///     having to code the creation of the Record constructor, you would create the
	///     JsonReader like this:</p><pre><code>
	///     var myReader = new Ext.data.JsonReader();
	///     </code></pre>
	///     <p>The first data packet from the server would configure the reader by
	///     containing a metaData property as well as the data:</p><pre><code>
	///     {
	///     'metaData': {
	///     totalProperty: 'results',
	///     root: 'rows',
	///     id: 'id',
	///     fields: [
	///     {name: 'name'},
	///     {name: 'occupation'} ]
	///     },
	///     'results': 2, 'rows': [
	///     { 'id': 1, 'name': 'Bill', occupation: 'Gardener' },
	///     { 'id': 2, 'name': 'Ben', occupation: 'Horticulturalist' } ]
	///     }
	///     </code></pre>
	///     @cfg {String} totalProperty Name of the property from which to retrieve the total number of records
	///     in the dataset. This is only needed if the whole dataset is not passed in one go, but is being
	///     paged from the remote server.
	///     @cfg {String} successProperty Name of the property from which to retrieve the success attribute used by forms.
	///     @cfg {String} root name of the property which contains the Array of row objects.
	///     @cfg {String} id Name of the property within a row object that contains a record identifier value.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\JsonReader.js</jssource>
	public class JsonReader : Ext.data.DataReader {

		/// <summary>
		///     Create a new JsonReader
		///     {@link Ext.data.Record#create}, or a {@link Ext.data.Record Record} constructor created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <returns></returns>
		public JsonReader() { C_(); }
		/// <summary>
		///     Create a new JsonReader
		///     {@link Ext.data.Record#create}, or a {@link Ext.data.Record Record} constructor created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options.</param>
		/// <returns></returns>
		public JsonReader(object meta) { C_(meta); }
		/// <summary>
		///     Create a new JsonReader
		///     {@link Ext.data.Record#create}, or a {@link Ext.data.Record Record} constructor created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options.</param>
		/// <param name="recordType">Either an Array of field definition objects as passed to</param>
		/// <returns></returns>
		public JsonReader(object meta, object recordType) { C_(meta, recordType); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static JsonReader prototype { get { return S_<JsonReader>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.DataReader superclass { get { return S_<Ext.data.DataReader>(); } set { S_(value); } }

		/// <summary>
		///     This JsonReader's metadata as passed to the constructor, or as passed in
		///     the last data packet's <b><tt>metaData</tt></b> property.
		/// </summary>
		public object meta { get { return _<object>(); } set { _(value); } }

		/// <summary>
		///     After any data loads, the raw JSON data is available for further custom processing.  If no data is
		///     loaded or there is a load exception this property will be undefined.
		/// </summary>
		public object jsonData { get { return _<object>(); } set { _(value); } }


		/// <summary>
		///     This method is only used by a DataProxy which has retrieved data from a remote server.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <returns>Object</returns>
		public virtual void read() { _(); }

		/// <summary>
		///     This method is only used by a DataProxy which has retrieved data from a remote server.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <param name="response">The XHR object which contains the JSON data in its responseText.</param>
		/// <returns>Object</returns>
		public virtual void read(object response) { _(response); }

		/// <summary>
		///     Create a data block containing Ext.data.Records from a JSON object.
		///     in the config as 'root, and optionally a property, specified in the config as 'totalProperty'
		///     which contains the total size of the dataset.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <returns>Object</returns>
		public virtual void readRecords() { _(); }

		/// <summary>
		///     Create a data block containing Ext.data.Records from a JSON object.
		///     in the config as 'root, and optionally a property, specified in the config as 'totalProperty'
		///     which contains the total size of the dataset.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <param name="o">An object which contains an Array of row objects in the property specified</param>
		/// <returns>Object</returns>
		public virtual void readRecords(object o) { _(o); }



	}

	[JsAnonymous]
	public class JsonReaderConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> Name of the property from which to retrieve the total number of records</summary>
		public string totalProperty { get { return _<string>(); } set { _(value); } }

		/// <summary> Name of the property from which to retrieve the success attribute used by forms.</summary>
		public string successProperty { get { return _<string>(); } set { _(value); } }

		/// <summary> name of the property which contains the Array of row objects.</summary>
		public string root { get { return _<string>(); } set { _(value); } }

		/// <summary> Name of the property within a row object that contains a record identifier value.</summary>
		public string id { get { return _<string>(); } set { _(value); } }

	}
}
