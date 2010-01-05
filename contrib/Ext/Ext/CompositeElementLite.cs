using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Flyweight composite class. Reuses the same Ext.Element for element operations.
	///     <pre><code>
	///     var els = Ext.select("#some-el div.some-class");
	///     // or select directly from an existing element
	///     var el = Ext.get('some-el');
	///     el.select('div.some-class');
	///     els.setWidth(100); // all elements become 100 width
	///     els.hide(true); // all elements fade out and hide
	///     // or
	///     els.setWidth(100).hide(true);
	///     </code></pre><br><br>
	///     <b>NOTE: Although they are not listed, this class supports all of the set/update methods of Ext.Element. All Ext.Element
	///     actions will be performed on all the elements in this collection.</b>
	///     */
	///     Ext.CompositeElementLite = function(els){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\CompositeElement.js</jssource>
	public class CompositeElementLite : Ext.CompositeElement {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern CompositeElementLite();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static CompositeElementLite prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.CompositeElement superclass { get; set; }


		/// <summary>Returns a flyweight Element of the dom element object at the specified index</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void item();

		/// <summary>Returns a flyweight Element of the dom element object at the specified index</summary>
		/// <param name="index"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void item(double index);

		/// <summary>
		///     Calls the passed function passing (el, this, index) for each element in this composite. <b>The element
		///     passed is the flyweight (shared) Ext.Element instance, so if you require a
		///     a reference to the dom node, use el.dom.</b>
		/// </summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void each();

		/// <summary>
		///     Calls the passed function passing (el, this, index) for each element in this composite. <b>The element
		///     passed is the flyweight (shared) Ext.Element instance, so if you require a
		///     a reference to the dom node, use el.dom.</b>
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void each(Delegate fn);

		/// <summary>
		///     Calls the passed function passing (el, this, index) for each element in this composite. <b>The element
		///     passed is the flyweight (shared) Ext.Element instance, so if you require a
		///     a reference to the dom node, use el.dom.</b>
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The <i>this</i> object (defaults to the element)</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void each(Delegate fn, object scope);



	}
}
