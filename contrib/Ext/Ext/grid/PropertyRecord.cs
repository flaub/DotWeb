using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     A specific {@link Ext.data.Record} type that represents a name/value pair and is made to work with the
	///     {@link Ext.grid.PropertyGrid}.  Typically, PropertyRecords do not need to be created directly as they can be
	///     created implicitly by simply using the appropriate data configs either via the {@link Ext.grid.PropertyGrid#source}
	///     config property or by calling {@link Ext.grid.PropertyGrid#setSource}.  However, if the need arises, these records
	///     can also be created explicitly as shwon below.  Example usage:
	///     <pre><code>
	///     var rec = new Ext.grid.PropertyRecord({
	///     name: 'Birthday',
	///     value: new Date(Date.parse('05/26/1972'))
	///     });
	///     // Add record to an already populated grid
	///     grid.store.addSorted(rec);
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\grid\PropertyGrid.js</jssource>
	public class PropertyRecord : System.DotWeb.JsObject {

		/// <summary>will be read automatically by the grid to determine the type of editor to use when displaying it.</summary>
		/// <returns></returns>
		public extern PropertyRecord();
		/// <summary>will be read automatically by the grid to determine the type of editor to use when displaying it.</summary>
		/// <param name="config">A data object in the format: {name: [name], value: [value]}.  The specified value's type</param>
		/// <returns></returns>
		public extern PropertyRecord(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static PropertyRecord prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }




	}
}
