using System;
using H8.Support;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\core\Template.js</jssource>
    [Native]
    public class Template  {

        /// <summary></summary>
        /// <returns></returns>
        public Template() {}
        /// <summary></summary>
        /// <param name="html">The HTML fragment or an array of fragments to join("") or multiple arguments to join("")</param>
        /// <returns></returns>
        public Template(System.String html) {}
        /// <summary></summary>
        /// <param name="html">The HTML fragment or an array of fragments to join("") or multiple arguments to join("")</param>
        /// <returns></returns>
        public Template(System.Array html) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Template prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>True to disable format functions (defaults to false)</summary>
        public bool disableFormats { get { return false; } set { } }

        /// <summary>The regular expression used to match template variables</summary>
        public object re { get { return null; } set { } }


        /// <summary>Returns an HTML fragment of this template with the specified values applied.</summary>
        /// <returns>String</returns>
        public virtual System.String applyTemplate() { return null; }

        /// <summary>Returns an HTML fragment of this template with the specified values applied.</summary>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>String</returns>
        public virtual System.String applyTemplate(object values) { return null; }

        /// <summary>Returns an HTML fragment of this template with the specified values applied.</summary>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>String</returns>
        public virtual System.String applyTemplate(System.Array values) { return null; }

        /// <summary>Sets the HTML used as the template and optionally compiles it.</summary>
        /// <returns>Ext.Template</returns>
        public virtual Ext.Template set() { return null; }

        /// <summary>Sets the HTML used as the template and optionally compiles it.</summary>
        /// <param name="html"></param>
        /// <returns>Ext.Template</returns>
        public virtual Ext.Template set(System.String html) { return null; }

        /// <summary>Sets the HTML used as the template and optionally compiles it.</summary>
        /// <param name="html"></param>
        /// <param name="compile">(optional) True to compile the template (defaults to undefined)</param>
        /// <returns>Ext.Template</returns>
        public virtual Ext.Template set(System.String html, bool compile) { return null; }

        /// <summary>Compiles the template into an internal function, eliminating the RegEx overhead.</summary>
        /// <returns>Ext.Template</returns>
        public virtual Ext.Template compile() { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertFirst() { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
        /// <param name="el">The context element</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertFirst(object el) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertFirst(object el, object values) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertFirst(object el, object values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertFirst(object el, System.Array values) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) as the first child of el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertFirst(object el, System.Array values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertBefore() { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
        /// <param name="el">The context element</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertBefore(object el) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertBefore(object el, object values) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertBefore(object el, object values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertBefore(object el, System.Array values) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) before el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertBefore(object el, System.Array values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertAfter() { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
        /// <param name="el">The context element</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertAfter(object el) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertAfter(object el, object values) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertAfter(object el, object values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertAfter(object el, System.Array values) { return null; }

        /// <summary>Applies the supplied values to the template and inserts the new node(s) after el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertAfter(object el, System.Array values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object append() { return null; }

        /// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
        /// <param name="el">The context element</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object append(object el) { return null; }

        /// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object append(object el, object values) { return null; }

        /// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object append(object el, object values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object append(object el, System.Array values) { return null; }

        /// <summary>Applies the supplied values to the template and appends the new node(s) to el.</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object append(object el, System.Array values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object overwrite() { return null; }

        /// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
        /// <param name="el">The context element</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object overwrite(object el) { return null; }

        /// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object overwrite(object el, object values) { return null; }

        /// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object overwrite(object el, object values, bool returnElement) { return null; }

        /// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object overwrite(object el, System.Array values) { return null; }

        /// <summary>Applies the supplied values to the template and overwrites the content of el with the new node(s).</summary>
        /// <param name="el">The context element</param>
        /// <param name="values">The template values. Can be an array if your params are numeric (i.e. {0}) or an object (i.e. {foo: 'bar'})</param>
        /// <param name="returnElement">(optional) true to return a Ext.Element (defaults to undefined)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object overwrite(object el, System.Array values, bool returnElement) { return null; }

        /// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
        /// <returns>Ext.Template</returns>
        public static Ext.Template from() { return null; }

        /// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
        /// <param name="el">A DOM element or its id</param>
        /// <returns>Ext.Template</returns>
        public static Ext.Template from(System.String el) { return null; }

        /// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
        /// <param name="el">A DOM element or its id</param>
        /// <param name="config">A configuration object</param>
        /// <returns>Ext.Template</returns>
        public static Ext.Template from(System.String el, object config) { return null; }

        /// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
        /// <param name="el">A DOM element or its id</param>
        /// <returns>Ext.Template</returns>
        public static Ext.Template from(DOMElement el) { return null; }

        /// <summary>Creates a template from the passed element's value (<i>display:none</i> textarea, preferred) or innerHTML.</summary>
        /// <param name="el">A DOM element or its id</param>
        /// <param name="config">A configuration object</param>
        /// <returns>Ext.Template</returns>
        public static Ext.Template from(DOMElement el, object config) { return null; }



    }
    [Anonymous]
    public class TemplateConfig {

    }


}
