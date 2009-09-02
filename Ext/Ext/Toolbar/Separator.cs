using System;
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
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Separator : Ext.Toolbar.Item {

		/// <summary>Creates a new Separator</summary>
		/// <returns></returns>
		public Separator() { C_(); }
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public Separator(DOMElement el) { C_(el); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Separator prototype { get { return S_<Separator>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.Toolbar.Item superclass { get { return S_<Ext.Toolbar.Item>(); } set { S_(value); } }




	}
}
