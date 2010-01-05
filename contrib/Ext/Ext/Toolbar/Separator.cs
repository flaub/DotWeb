using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.Toolbar {
	/// <summary>
	///     /**
	///     A simple class that adds a vertical separator bar between toolbar items.  Example usage:
	///     <pre><code>
	///     new Ext.Panel({
	///     tbar : [
	///     'Item 1',
	///     {xtype: 'tbseparator'}, // or '-'
	///     'Item 2'
	///     ]
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Separator : Ext.Toolbar.Item {

		/// <summary>Creates a new Separator</summary>
		/// <returns></returns>
		public extern Separator();
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public extern Separator(DOMElement el);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Separator prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.Toolbar.Item superclass { get; set; }




	}
}
