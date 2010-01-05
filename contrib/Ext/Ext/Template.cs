using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Represents an HTML fragment template. Templates can be precompiled for greater performance.
	///     For a list of available format functions, see {@link Ext.util.Format}.<br />
	///     Usage:
	///     <pre><code>
	///     var t = new Ext.Template(
	///     '&lt;div name="{id}"&gt;',
	///     '&lt;span class="{cls}"&gt;{name:trim} {value:ellipsis(10)}&lt;/span&gt;',
	///     '&lt;/div&gt;'
	///     );
	///     t.append('some-element', {id: 'myid', cls: 'myclass', name: 'foo', value: 'bar'});
	///     </code></pre>
	///     For more information see this blog post with examples: <a href="http://www.jackslocum.com/blog/2006/10/06/domhelper-create-elements-using-dom-html-fragments-or-templates/">DomHelper - Create Elements using DOM, HTML fragments and Templates</a>.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\Template.js</jssource>
	public class Template : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern Template();
		/// <summary></summary>
		/// <param name="html">The HTML fragment or an array of fragments to join("") or multiple arguments to join("")</param>
		/// <returns></returns>
		public extern Template(string html);
		/// <summary></summary>
		/// <param name="html">The HTML fragment or an array of fragments to join("") or multiple arguments to join("")</param>
		/// <returns></returns>
		public extern Template(System.Array html);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Template prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>True to disable format functions (defaults to false)</summary>
		public extern bool disableFormats { get; set; }

		/// <summary>The regular expression used to match template variables</summary>
		public extern object re { get; set; }


		/// <summary>Returns an HTML fragment of this template with the specified values applied.</summary>
		/// <returns>String</returns>
		public extern virtual void applyTemplate();

		/// <summary>Returns an HTML fragment of this template with the specified values applied.</summary>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>String</returns>
		public extern virtual void applyTemplate(object values);

		/// <summary>Returns an HTML fragment of this template with the specified values applied.</summary>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>String</returns>
		public extern virtual void applyTemplate(System.Array values);

		/// <summary>Sets the HTML used as the template and optionally compiles it.</summary>
		/// <returns>Ext.Template</returns>
		public extern virtual void set();

		/// <summary>Sets the HTML used as the template and optionally compiles it.</summary>
		/// <param name="html"></param>
		/// <returns>Ext.Template</returns>
		public extern virtual void set(string html);

		/// <summary>Sets the HTML used as the template and optionally compiles it.</summary>
		/// <param name="html"></param>
		/// <param name="compile">(optional) True to compile the template (defaults to undefined)</param>
		/// <returns>Ext.Template</returns>
		public extern virtual void set(string html, bool compile);

		/// <summary>Compiles the template into an internal function, eliminating the RegEx overhead.</summary>
		/// <returns>Ext.Template</returns>
		public extern virtual void compile();

		/// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertFirst();

		/// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertFirst(object el);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertFirst(object el, object values);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertFirst(object el, object values, bool returnElement);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertFirst(object el, System.Array values);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertFirst(object el, System.Array values, bool returnElement);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertBefore();

		/// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertBefore(object el);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertBefore(object el, object values);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertBefore(object el, object values, bool returnElement);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertBefore(object el, System.Array values);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertBefore(object el, System.Array values, bool returnElement);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertAfter();

		/// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertAfter(object el);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertAfter(object el, object values);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertAfter(object el, object values, bool returnElement);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertAfter(object el, System.Array values);

		/// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertAfter(object el, System.Array values, bool returnElement);

		/// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void append();

		/// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void append(object el);

		/// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void append(object el, object values);

		/// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void append(object el, object values, bool returnElement);

		/// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void append(object el, System.Array values);

		/// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void append(object el, System.Array values, bool returnElement);

		/// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void overwrite();

		/// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
		/// <param name="el">The context element</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void overwrite(object el);

		/// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void overwrite(object el, object values);

		/// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void overwrite(object el, object values, bool returnElement);

		/// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void overwrite(object el, System.Array values);

		/// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
		/// <param name="el">The context element</param>
		/// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
		/// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void overwrite(object el, System.Array values, bool returnElement);

		/// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
		/// <returns>Ext.Template</returns>
		public extern static void from();

		/// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
		/// <param name="el">A DOM element or its id</param>
		/// <returns>Ext.Template</returns>
		public extern static void from(string el);

		/// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
		/// <param name="el">A DOM element or its id</param>
		/// <param name="config">A configuration object</param>
		/// <returns>Ext.Template</returns>
		public extern static void from(string el, object config);

		/// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
		/// <param name="el">A DOM element or its id</param>
		/// <returns>Ext.Template</returns>
		public extern static void from(DOMElement el);

		/// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
		/// <param name="el">A DOM element or its id</param>
		/// <param name="config">A configuration object</param>
		/// <returns>Ext.Template</returns>
		public extern static void from(DOMElement el, object config);



	}
}
