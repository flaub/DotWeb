using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.layout {
	/// <summary>
	///     /**
	///     Every layout is composed of one or more {@link Ext.Container} elements internally, and ContainerLayout provides
	///     the basic foundation for all other layout classes in Ext.  It is a non-visual class that simply provides the
	///     base logic required for a Container to function as a layout.  This class is intended to be extended and should
	///     generally not need to be created directly via the new keyword.
	///     */
	///     Ext.layout.ContainerLayout = function(config){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\layout\ContainerLayout.js</jssource>
	public class ContainerLayout : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern ContainerLayout();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Ext.layout.ContainerLayout prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>
		///     An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for
		///     adding customized styles to the container or any of its children using standard CSS rules.
		/// </summary>
		public extern string extraCls { get; set; }

		/// <summary>True to hide each contained item on render (defaults to false).</summary>
		public extern bool renderHidden { get; set; }

		/// <summary>
		///     A reference to the {@link Ext.Component} that is active.  For example,
		///     if(myPanel.layout.activeItem.id == 'item-1') { ... }.  activeItem only applies to layout styles that can
		///     display items one at a time (like {@link Ext.layout.Accordion}, {@link Ext.layout.CardLayout}
		///     and {@link Ext.layout.FitLayout}).  Read-only.  Related to {@link Ext.Container#activeItem}.
		/// </summary>
		public extern Ext.Component activeItem { get; set; }




	}

	[JsAnonymous]
	public class ContainerLayoutConfig : System.DotWeb.JsDynamic {
		/// <summary>  An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string extraCls { get { return (string)this["extraCls"]; } set { this["extraCls"] = value; } }

		/// <summary>  True to hide each contained item on render (defaults to false).</summary>
		public bool renderHidden { get { return (bool)this["renderHidden"]; } set { this["renderHidden"] = value; } }

	}
}
