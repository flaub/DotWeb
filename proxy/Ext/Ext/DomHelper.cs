using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Utility class for working with DOM and/or Templates. It transparently supports using HTML fragments or DOM.<br>
	///     This is an example, where an unordered list with 5 children items is appended to an existing element with id 'my-div':<br>
	///     <pre><code>
	///     var dh = Ext.DomHelper;
	///     var list = dh.append('my-div', {
	///     id: 'my-ul', tag: 'ul', cls: 'my-list', children: [
	///     {tag: 'li', id: 'item0', html: 'List Item 0'},
	///     {tag: 'li', id: 'item1', html: 'List Item 1'},
	///     {tag: 'li', id: 'item2', html: 'List Item 2'},
	///     {tag: 'li', id: 'item3', html: 'List Item 3'},
	///     {tag: 'li', id: 'item4', html: 'List Item 4'}
	///     ]
	///     });
	///     </code></pre>
	///     <p>Element creation specification parameters in this class may also be passed as an Array of
	///     specification objects. This can be used to insert multiple sibling nodes into an existing
	///     container very efficiently. For example, to add more list items to the example above:<pre><code>
	///     dh.append('my-ul', [
	///     {tag: 'li', id: 'item5', html: 'List Item 5'},
	///     {tag: 'li', id: 'item6', html: 'List Item 6'} ]);
	///     </code></pre></p>
	///     <p>Element creation specification parameters may also be strings. If {@link useDom} is false, then the string is used
	///     as innerHTML. If {@link useDom} is true, a string specification results in the creation of a text node.</p>
	///     For more information and examples, see <a href="http://www.jackslocum.com/blog/2006/10/06/domhelper-create-elements-using-dom-html-fragments-or-templates/">the original blog post</a>.
	///     */
	///     Ext.DomHelper = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\DomHelper.js</jssource>
	public class DomHelper : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public DomHelper() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DomHelper prototype { get { return S_<DomHelper>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>True to force the use of DOM instead of html fragments</summary>
		public static bool useDom { get { return S_<bool>(); } set { S_(value); } }


		/// <summary>Returns the markup for the passed Element(s) config.</summary>
		/// <returns>String</returns>
		public static void markup() { S_(); }

		/// <summary>Returns the markup for the passed Element(s) config.</summary>
		/// <param name="o">The DOM object spec (and children)</param>
		/// <returns>String</returns>
		public static void markup(object o) { S_(o); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <returns></returns>
		public static void applyStyles() { S_(); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <returns></returns>
		public static void applyStyles(string el) { S_(el); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <param name="styles">A style specification string eg "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns></returns>
		public static void applyStyles(string el, string styles) { S_(el, styles); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <returns></returns>
		public static void applyStyles(DOMElement el) { S_(el); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <param name="styles">A style specification string eg "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns></returns>
		public static void applyStyles(DOMElement el, string styles) { S_(el, styles); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <param name="styles">A style specification string eg "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns></returns>
		public static void applyStyles(string el, object styles) { S_(el, styles); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <param name="styles">A style specification string eg "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns></returns>
		public static void applyStyles(DOMElement el, object styles) { S_(el, styles); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <param name="styles">A style specification string eg "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns></returns>
		public static void applyStyles(string el, Delegate styles) { S_(el, styles); }

		/// <summary>
		///     Applies a style specification to an element.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="el">The element to apply styles to</param>
		/// <param name="styles">A style specification string eg "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns></returns>
		public static void applyStyles(DOMElement el, Delegate styles) { S_(el, styles); }

		/// <summary>Inserts an HTML fragment into the DOM.</summary>
		/// <returns>HTMLElement</returns>
		public static void insertHtml() { S_(); }

		/// <summary>Inserts an HTML fragment into the DOM.</summary>
		/// <param name="where">Where to insert the html in relation to el - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
		/// <returns>HTMLElement</returns>
		public static void insertHtml(string where) { S_(where); }

		/// <summary>Inserts an HTML fragment into the DOM.</summary>
		/// <param name="where">Where to insert the html in relation to el - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement</returns>
		public static void insertHtml(string where, DOMElement el) { S_(where, el); }

		/// <summary>Inserts an HTML fragment into the DOM.</summary>
		/// <param name="where">Where to insert the html in relation to el - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
		/// <param name="el">The context element</param>
		/// <param name="html">The HTML fragmenet</param>
		/// <returns>HTMLElement</returns>
		public static void insertHtml(string where, DOMElement el, string html) { S_(where, el, html); }

		/// <summary>Creates new DOM element(s) and inserts them before el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertBefore() { S_(); }

		/// <summary>Creates new DOM element(s) and inserts them before el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertBefore(object el) { S_(el); }

		/// <summary>Creates new DOM element(s) and inserts them before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertBefore(object el, object o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and inserts them before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertBefore(object el, object o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and inserts them before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertBefore(object el, string o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and inserts them before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertBefore(object el, string o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and inserts them after el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertAfter() { S_(); }

		/// <summary>Creates new DOM element(s) and inserts them after el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertAfter(object el) { S_(el); }

		/// <summary>Creates new DOM element(s) and inserts them after el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertAfter(object el, object o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and inserts them after el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children)</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertAfter(object el, object o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and inserts them as the first child of el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertFirst() { S_(); }

		/// <summary>Creates new DOM element(s) and inserts them as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertFirst(object el) { S_(el); }

		/// <summary>Creates new DOM element(s) and inserts them as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertFirst(object el, object o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and inserts them as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertFirst(object el, object o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and inserts them as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertFirst(object el, string o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and inserts them as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void insertFirst(object el, string o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and appends them to el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void append() { S_(); }

		/// <summary>Creates new DOM element(s) and appends them to el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void append(object el) { S_(el); }

		/// <summary>Creates new DOM element(s) and appends them to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void append(object el, object o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and appends them to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void append(object el, object o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and appends them to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void append(object el, string o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and appends them to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void append(object el, string o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and overwrites the contents of el with them.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void overwrite() { S_(); }

		/// <summary>Creates new DOM element(s) and overwrites the contents of el with them.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void overwrite(object el) { S_(el); }

		/// <summary>Creates new DOM element(s) and overwrites the contents of el with them.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void overwrite(object el, object o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and overwrites the contents of el with them.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void overwrite(object el, object o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates new DOM element(s) and overwrites the contents of el with them.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void overwrite(object el, string o) { S_(el, o); }

		/// <summary>Creates new DOM element(s) and overwrites the contents of el with them.</summary>
		/// <param name="el">The context element</param>
		/// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public static void overwrite(object el, string o, bool returnElement) { S_(el, o, returnElement); }

		/// <summary>Creates a new Ext.Template from the DOM object spec.</summary>
		/// <returns>Ext.Template</returns>
		public static void createTemplate() { S_(); }

		/// <summary>Creates a new Ext.Template from the DOM object spec.</summary>
		/// <param name="o">The DOM object spec (and children)</param>
		/// <returns>Ext.Template</returns>
		public static void createTemplate(object o) { S_(o); }



	}
}
