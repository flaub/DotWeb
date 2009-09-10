using System;
using DotWeb.Client;

namespace Ext.layout {
	/// <summary>
	///     /**
	///     <p>Inherits the anchoring of {@link Ext.layout.AnchorLayout} and adds the ability for x/y positioning using the
	///     standard x and y component config options.</p>
	///     */
	///     Ext.layout.AbsoluteLayout = Ext.extend(Ext.layout.AnchorLayout, {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\layout\AbsoluteLayout.js</jssource>
	public class AbsoluteLayout : Ext.layout.AnchorLayout {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public AbsoluteLayout() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static AbsoluteLayout prototype { get { return S_<AbsoluteLayout>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.layout.AnchorLayout superclass { get { return S_<Ext.layout.AnchorLayout>(); } set { S_(value); } }




	}

	[JsAnonymous]
	public class AbsoluteLayoutConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>  An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string extraCls { get { return _<string>(); } set { _(value); } }

		/// <summary>  True to hide each contained item on render (defaults to false).</summary>
		public bool renderHidden { get { return _<bool>(); } set { _(value); } }

	}
}
