using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     Data reader class to create an Array of {@link Ext.data.Record} objects from an Array.
	///     Each element of that Array represents a row of data fields. The
	///     fields are pulled into a Record object using as a subscript, the <em>mapping</em> property
	///     of the field definition if it exists, or the field's ordinal position in the definition.<br>
	///     <p>
	///     Example code:.
	///     <pre><code>
	///     var Employee = Ext.data.Record.create([
	///     {name: 'name', mapping: 1},         // "mapping" only needed if an "id" field is present which
	///     {name: 'occupation', mapping: 2}    // precludes using the ordinal position as the index.
	///     ]);
	///     var myReader = new Ext.data.ArrayReader({
	///     id: 0                     // The subscript within row Array that provides an ID for the Record (optional)
	///     }, Employee);
	///     </code></pre>
	///     <p>
	///     This would consume an Array like this:
	///     <pre><code>
	///     [ [1, 'Bill', 'Gardener'], [2, 'Ben', 'Horticulturalist'] ]
	///     </code></pre>
	///     @cfg {String} id (optional) The subscript within row Array that provides an ID for the Record
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\ArrayReader.js</jssource>
	public class ArrayReader : Ext.data.JsonReader {

		/// <summary>
		///     Create a new ArrayReader
		///     as specified to {@link Ext.data.Record#create},
		///     or a {@link Ext.data.Record Record} constructor
		///     created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <returns></returns>
		public ArrayReader() { C_(); }
		/// <summary>
		///     Create a new ArrayReader
		///     as specified to {@link Ext.data.Record#create},
		///     or a {@link Ext.data.Record Record} constructor
		///     created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options.</param>
		/// <returns></returns>
		public ArrayReader(object meta) { C_(meta); }
		/// <summary>
		///     Create a new ArrayReader
		///     as specified to {@link Ext.data.Record#create},
		///     or a {@link Ext.data.Record Record} constructor
		///     created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options.</param>
		/// <param name="recordType">Either an Array of field definition objects</param>
		/// <returns></returns>
		public ArrayReader(object meta, object recordType) { C_(meta, recordType); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static ArrayReader prototype { get { return S_<ArrayReader>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.data.JsonReader superclass { get { return S_<Ext.data.JsonReader>(); } set { S_(value); } }


		/// <summary>
		///     Create a data block containing Ext.data.Records from an Array.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <returns>Object</returns>
		public virtual void readRecords() { _(); }

		/// <summary>
		///     Create a data block containing Ext.data.Records from an Array.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <param name="o">An Array of row objects which represents the dataset.</param>
		/// <returns>Object</returns>
		public virtual void readRecords(object o) { _(o); }



	}

	[JsAnonymous]
	public class ArrayReaderConfig : DotWeb.Client.JsAccessible {
		/// <summary> (optional) The subscript within row Array that provides an ID for the Record</summary>
		public System.String id { get; set; }

		/// <summary> Name of the property from which to retrieve the total number of records</summary>
		public System.String totalProperty { get; set; }

		/// <summary> Name of the property from which to retrieve the success attribute used by forms.</summary>
		public System.String successProperty { get; set; }

		/// <summary> name of the property which contains the Array of row objects.</summary>
		public System.String root { get; set; }

	}
}
