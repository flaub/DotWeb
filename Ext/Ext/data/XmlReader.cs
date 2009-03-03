using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     Data reader class to create an Array of {@link Ext.data.Record} objects from an XML document
	///     based on mappings in a provided {@link Ext.data.Record} constructor.<br><br>
	///     <p>
	///     <em>Note that in order for the browser to parse a returned XML document, the Content-Type
	///     header in the HTTP response must be set to "text/xml" or "application/xml".</em>
	///     <p>
	///     Example code:
	///     <pre><code>
	///     var Employee = Ext.data.Record.create([
	///     {name: 'name', mapping: 'name'},     // "mapping" property not needed if it's the same as "name"
	///     {name: 'occupation'}                 // This field will use "occupation" as the mapping.
	///     ]);
	///     var myReader = new Ext.data.XmlReader({
	///     totalRecords: "results", // The element which contains the total dataset size (optional)
	///     record: "row",           // The repeated element which contains row information
	///     id: "id"                 // The element within the row that provides an ID for the record (optional)
	///     }, Employee);
	///     </code></pre>
	///     <p>
	///     This would consume an XML file like this:
	///     <pre><code>
	///     &lt;?xml version="1.0" encoding="UTF-8"?>
	///     &lt;dataset>
	///     &lt;results>2&lt;/results>
	///     &lt;row>
	///     &lt;id>1&lt;/id>
	///     &lt;name>Bill&lt;/name>
	///     &lt;occupation>Gardener&lt;/occupation>
	///     &lt;/row>
	///     &lt;row>
	///     &lt;id>2&lt;/id>
	///     &lt;name>Ben&lt;/name>
	///     &lt;occupation>Horticulturalist&lt;/occupation>
	///     &lt;/row>
	///     &lt;/dataset>
	///     </code></pre>
	///     @cfg {String} totalRecords The DomQuery path from which to retrieve the total number of records
	///     in the dataset. This is only needed if the whole dataset is not passed in one go, but is being
	///     paged from the remote server.
	///     @cfg {String} record The DomQuery path to the repeated element which contains record information.
	///     @cfg {String} success The DomQuery path to the success attribute used by forms.
	///     @cfg {String} id The DomQuery path relative from the record element to the element that contains
	///     a record identifier value.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\XmlReader.js</jssource>
	public class XmlReader : Ext.data.DataReader {

		/// <summary>
		///     Create a new XmlReader.
		///     {@link Ext.data.Record#create}, or a Record constructor object created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <returns></returns>
		public XmlReader() { C_(); }
		/// <summary>
		///     Create a new XmlReader.
		///     {@link Ext.data.Record#create}, or a Record constructor object created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options</param>
		/// <returns></returns>
		public XmlReader(object meta) { C_(meta); }
		/// <summary>
		///     Create a new XmlReader.
		///     {@link Ext.data.Record#create}, or a Record constructor object created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options</param>
		/// <param name="recordType">Either an Array of field definition objects as passed to</param>
		/// <returns></returns>
		public XmlReader(object meta, object recordType) { C_(meta, recordType); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static XmlReader prototype { get { return S_<XmlReader>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.DataReader superclass { get { return S_<Ext.data.DataReader>(); } set { S_(value); } }

		/// <summary>After any data loads/reads, the raw XML Document is available for further custom processing.</summary>
		public object xmlData { get { return _<object>(); } set { _(value); } }


		/// <summary>
		///     This method is only used by a DataProxy which has retrieved data from a remote server.
		///     to contain a property called <tt>responseXML</tt> which refers to an XML document object.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <returns>Object</returns>
		public virtual void read() { _(); }

		/// <summary>
		///     This method is only used by a DataProxy which has retrieved data from a remote server.
		///     to contain a property called <tt>responseXML</tt> which refers to an XML document object.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <param name="response">The XHR object which contains the parsed XML document.  The response is expected</param>
		/// <returns>Object</returns>
		public virtual void read(object response) { _(response); }

		/// <summary>
		///     Create a data block containing Ext.data.Records from an XML document.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <returns>Object</returns>
		public virtual void readRecords() { _(); }

		/// <summary>
		///     Create a data block containing Ext.data.Records from an XML document.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <param name="doc">A parsed XML document.</param>
		/// <returns>Object</returns>
		public virtual void readRecords(object doc) { _(doc); }



	}

	[JsAnonymous]
	public class XmlReaderConfig : DotWeb.Client.JsAccessible {
		/// <summary> The DomQuery path from which to retrieve the total number of records</summary>
		public System.String totalRecords { get; set; }

		/// <summary> The DomQuery path to the repeated element which contains record information.</summary>
		public System.String record { get; set; }

		/// <summary> The DomQuery path to the success attribute used by forms.</summary>
		public System.String success { get; set; }

		/// <summary> The DomQuery path relative from the record element to the element that contains</summary>
		public System.String id { get; set; }

	}
}
