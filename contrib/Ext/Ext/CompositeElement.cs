using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Standard composite class. Creates a Ext.Element for every element in the collection.
	///     <br><br>
	///     <b>NOTE: Although they are not listed, this class supports all of the set/update methods of Ext.Element. All Ext.Element
	///     actions will be performed on all the elements in this collection.</b>
	///     <br><br>
	///     All methods return <i>this</i> and can be chained.
	///     <pre><code>
	///     var els = Ext.select("#some-el div.some-class", true);
	///     // or select directly from an existing element
	///     var el = Ext.get('some-el');
	///     el.select('div.some-class', true);
	///     els.setWidth(100); // all elements become 100 width
	///     els.hide(true); // all elements fade out and hide
	///     // or
	///     els.setWidth(100).hide(true);
	///     </code></pre>
	///     */
	///     Ext.CompositeElement = function(els){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\CompositeElement.js</jssource>
	public class CompositeElement : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern CompositeElement();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static CompositeElement prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>Clears this composite and adds the elements returned by the passed selector.</summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void fill();

		/// <summary>Clears this composite and adds the elements returned by the passed selector.</summary>
		/// <param name="els">A string CSS selector, an array of elements or an element</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void fill(string els);

		/// <summary>Clears this composite and adds the elements returned by the passed selector.</summary>
		/// <param name="els">A string CSS selector, an array of elements or an element</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void fill(System.Array els);

		/// <summary>Filters this composite to only elements that match the passed selector.</summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void filter();

		/// <summary>Filters this composite to only elements that match the passed selector.</summary>
		/// <param name="selector">A string CSS selector</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void filter(string selector);

		/// <summary>Adds elements to this composite.</summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void add();

		/// <summary>Adds elements to this composite.</summary>
		/// <param name="els">A string CSS selector, an array of elements or an element</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void add(string els);

		/// <summary>Adds elements to this composite.</summary>
		/// <param name="els">A string CSS selector, an array of elements or an element</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void add(System.Array els);

		/// <summary>Calls the passed function passing (el, this, index) for each element in this composite.</summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void each();

		/// <summary>Calls the passed function passing (el, this, index) for each element in this composite.</summary>
		/// <param name="fn">The function to call</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void each(Delegate fn);

		/// <summary>Calls the passed function passing (el, this, index) for each element in this composite.</summary>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The <i>this</i> object (defaults to the element)</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void each(Delegate fn, object scope);

		/// <summary>Returns the Element object at the specified index</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void item();

		/// <summary>Returns the Element object at the specified index</summary>
		/// <param name="index"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void item(double index);

		/// <summary>Returns the first Element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void first();

		/// <summary>Returns the last Element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void last();

		/// <summary>Returns the number of elements in this composite</summary>
		/// <returns>Number</returns>
		public extern virtual void getCount();

		/// <summary>Returns true if this composite contains the passed element</summary>
		/// <returns>Boolean</returns>
		public extern virtual void contains();

		/// <summary>Returns true if this composite contains the passed element</summary>
		/// <param name="el">{Mixed} The id of an element, or an Ext.Element, or an HtmlElement to find within the composite collection.</param>
		/// <returns>Boolean</returns>
		public extern virtual void contains(object el);

		/// <summary>Find the index of the passed element within the composite collection.</summary>
		/// <returns>Number</returns>
		public extern virtual void indexOf();

		/// <summary>Find the index of the passed element within the composite collection.</summary>
		/// <param name="el">{Mixed} The id of an element, or an Ext.Element, or an HtmlElement to find within the composite collection.</param>
		/// <returns>Number</returns>
		public extern virtual void indexOf(object el);

		/// <summary>
		///     Removes the specified element(s).
		///     or an array of any of those.
		/// </summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void removeElement();

		/// <summary>
		///     Removes the specified element(s).
		///     or an array of any of those.
		/// </summary>
		/// <param name="el">The id of an element, the Element itself, the index of the element in this composite</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void removeElement(object el);

		/// <summary>
		///     Removes the specified element(s).
		///     or an array of any of those.
		/// </summary>
		/// <param name="el">The id of an element, the Element itself, the index of the element in this composite</param>
		/// <param name="removeDom">(optional) True to also remove the element from the document</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void removeElement(object el, bool removeDom);

		/// <summary>
		///     Replaces the specified element with the passed element.
		///     to replace.
		/// </summary>
		/// <returns>CompositeElement</returns>
		public extern virtual void replaceElement();

		/// <summary>
		///     Replaces the specified element with the passed element.
		///     to replace.
		/// </summary>
		/// <param name="el">The id of an element, the Element itself, the index of the element in this composite</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void replaceElement(object el);

		/// <summary>
		///     Replaces the specified element with the passed element.
		///     to replace.
		/// </summary>
		/// <param name="el">The id of an element, the Element itself, the index of the element in this composite</param>
		/// <param name="replacement">The id of an element or the Element itself.</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void replaceElement(object el, object replacement);

		/// <summary>
		///     Replaces the specified element with the passed element.
		///     to replace.
		/// </summary>
		/// <param name="el">The id of an element, the Element itself, the index of the element in this composite</param>
		/// <param name="replacement">The id of an element or the Element itself.</param>
		/// <param name="domReplace">(Optional) True to remove and replace the element in the document too.</param>
		/// <returns>CompositeElement</returns>
		public extern virtual void replaceElement(object el, object replacement, bool domReplace);

		/// <summary>Removes all elements.</summary>
		/// <returns></returns>
		public extern virtual void clear();



	}
}
