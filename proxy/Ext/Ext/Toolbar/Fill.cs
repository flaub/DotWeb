using System;
using System.DotWeb;
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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class Fill : Ext.Toolbar.Spacer {

		/// <summary>Creates a new Spacer</summary>
		/// <returns></returns>
		public extern Fill();
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public extern Fill(DOMElement el);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Fill prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.Toolbar.Spacer superclass { get; set; }




	}
}
