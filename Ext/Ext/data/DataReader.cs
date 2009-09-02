using System;
using DotWeb.Client;

namespace Ext.data {
	/// <summary>
	///     /**
	///     Abstract base class for reading structured data from a data source and converting
	///     it into an object containing {@link Ext.data.Record} objects and metadata for use
	///     by an {@link Ext.data.Store}.  This class is intended to be extended and should not
	///     be created directly. For existing implementations, see {@link Ext.data.ArrayReader},
	///     {@link Ext.data.JsonReader} and {@link Ext.data.XmlReader}.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\data\DataReader.js</jssource>
	public class DataReader : DotWeb.Client.JsNativeBase {

		/// <summary>
		///     in {@link Ext.data.Record#create}, or an {@link Ext.data.Record} object created
		///     using {@link Ext.data.Record#create}.
		/// </summary>
		/// <returns></returns>
		public DataReader() { C_(); }
		/// <summary>
		///     in {@link Ext.data.Record#create}, or an {@link Ext.data.Record} object created
		///     using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options (implementation-specific)</param>
		/// <returns></returns>
		public DataReader(object meta) { C_(meta); }
		/// <summary>
		///     in {@link Ext.data.Record#create}, or an {@link Ext.data.Record} object created
		///     using {@link Ext.data.Record#create}.
		/// </summary>
		/// <param name="meta">Metadata configuration options (implementation-specific)</param>
		/// <param name="recordType">Either an Array of field definition objects as specified</param>
		/// <returns></returns>
		public DataReader(object meta, object recordType) { C_(meta, recordType); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Ext.data.DataReader prototype { get { return S_<Ext.data.DataReader>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>This DataReader's configured metadata as passed to the constructor.</summary>
		public object meta { get { return _<object>(); } set { _(value); } }




	}
}
