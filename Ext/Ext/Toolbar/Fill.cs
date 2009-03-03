using System;
using DotWeb.Client;

namespace Ext.Toolbar {
	/// <summary>
	///     /**
	///     A simple element that adds a greedy (100% width) horizontal space between items in a toolbar.
	///     <pre><code>
	///     new Ext.Panel({
	///     tbar : [
	///     'Item 1',
	///     {xtype: 'tbfill'}, // or '->'
	///     'Item 2'
	///     ]
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Fill : Ext.Toolbar.Spacer {

		/// <summary>Creates a new Spacer</summary>
		/// <returns></returns>
		public Fill() { C_(); }
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public Fill(DOMElement el) { C_(el); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Fill prototype { get { return S_<Fill>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.Toolbar.Spacer superclass { get { return S_<Ext.Toolbar.Spacer>(); } set { S_(value); } }




	}
}
