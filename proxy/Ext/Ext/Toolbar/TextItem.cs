using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.Toolbar {
	/// <summary>
	///     /**
	///     A simple class that renders text directly into a toolbar.
	///     <pre><code>
	///     new Ext.Panel({
	///     tbar : [
	///     {xtype: 'tbtext', text: 'Item 1'} // or simply 'Item 1'
	///     ]
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Toolbar.js</jssource>
	public class TextItem : Ext.Toolbar.Item {

		/// <summary>Creates a new TextItem</summary>
		/// <returns></returns>
		public extern TextItem();
		/// <summary>Creates a new TextItem</summary>
		/// <param name="text">A text string, or a config object containing a <tt>text</tt> property</param>
		/// <returns></returns>
		public extern TextItem(string text);
		/// <summary>Creates a new TextItem</summary>
		/// <param name="text">A text string, or a config object containing a <tt>text</tt> property</param>
		/// <returns></returns>
		public extern TextItem(object text);
		/// <summary>Creates a new Item</summary>
		/// <param name="el"></param>
		/// <returns></returns>
		public extern TextItem(DOMElement el);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TextItem prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.Toolbar.Item superclass { get; set; }




	}
}
