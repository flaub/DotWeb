using System;
using System.DotWeb;
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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\data\ArrayReader.js</jssource>
	public class ArrayReader : Ext.data.JsonReader {

		/// <summary>
		///     Create a new ArrayReader
		///     as specified to {@link Ext.data.Record#create},
		///     or a {@link Ext.data.Record Record} constructor
		///     created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <returns></returns>
		public extern ArrayReader();
		/// <summary>
		///     Create a new ArrayReader
		///     as specified to {@link Ext.data.Record#create},
		///     or a {@link Ext.data.Record Record} constructor
		///     created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options.</param>
		/// <returns></returns>
		public extern ArrayReader(object meta);
		/// <summary>
		///     Create a new ArrayReader
		///     as specified to {@link Ext.data.Record#create},
		///     or a {@link Ext.data.Record Record} constructor
		///     created using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options.</param>
		/// <param name="recordType">Either an Array of field definition objects</param>
		/// <returns></returns>
		public extern ArrayReader(object meta, object recordType);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ArrayReader prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.data.JsonReader superclass { get; set; }


		/// <summary>
		///     Create a data block containing Ext.data.Records from an Array.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void readRecords();

		/// <summary>
		///     Create a data block containing Ext.data.Records from an Array.
		///     a cache of Ext.data.Records.
		/// </summary>
		/// <param name="o">An Array of row objects which represents the dataset.</param>
		/// <returns>Object</returns>
		public extern virtual void readRecords(object o);



	}

	[JsAnonymous]
	public class ArrayReaderConfig : System.DotWeb.JsDynamic {
		/// <summary> (optional) The subscript within row Array that provides an ID for the Record</summary>
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }

		/// <summary> Name of the property from which to retrieve the total number of records</summary>
		public string totalProperty { get { return (string)this["totalProperty"]; } set { this["totalProperty"] = value; } }

		/// <summary> Name of the property from which to retrieve the success attribute used by forms.</summary>
		public string successProperty { get { return (string)this["successProperty"]; } set { this["successProperty"] = value; } }

		/// <summary> name of the property which contains the Array of row objects.</summary>
		public string root { get { return (string)this["root"]; } set { this["root"] = value; } }

	}
}
