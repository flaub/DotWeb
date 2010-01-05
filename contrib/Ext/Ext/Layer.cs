using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     An extended {@link Ext.Element} object that supports a shadow and shim, constrain to viewport and
	///     automatic maintaining of shadow/shim positions.
	///     @cfg {Boolean} shim False to disable the iframe shim in browsers which need one (defaults to true)
	///     @cfg {String/Boolean} shadow True to create a shadow element with default class "x-layer-shadow", or
	///     you can pass a string with a CSS class name. False turns off the shadow.
	///     @cfg {Object} dh DomHelper object config to create element with (defaults to {tag: "div", cls: "x-layer"}).
	///     @cfg {Boolean} constrain False to disable constrain to viewport (defaults to true)
	///     @cfg {String} cls CSS class to add to the element
	///     @cfg {Number} zindex Starting z-index (defaults to 11000)
	///     @cfg {Number} shadowOffset Number of pixels to offset the shadow (defaults to 3)
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Layer.js</jssource>
	public class Layer : Ext.Element {

		/// <summary></summary>
		/// <returns></returns>
		public extern Layer();
		/// <summary></summary>
		/// <param name="config">An object with config options.</param>
		/// <returns></returns>
		public extern Layer(object config);
		/// <summary></summary>
		/// <param name="config">An object with config options.</param>
		/// <param name="existingEl">(optional) Uses an existing DOM element. If the element is not found it creates it.</param>
		/// <returns></returns>
		public extern Layer(object config, string existingEl);
		/// <summary></summary>
		/// <param name="config">An object with config options.</param>
		/// <param name="existingEl">(optional) Uses an existing DOM element. If the element is not found it creates it.</param>
		/// <returns></returns>
		public extern Layer(object config, DOMElement existingEl);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public extern Layer(string element);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
		/// <returns></returns>
		public extern Layer(string element, bool forceNew);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public extern Layer(DOMElement element);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
		/// <returns></returns>
		public extern Layer(DOMElement element, bool forceNew);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Layer prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.Element superclass { get; set; }


		/// <summary>
		///     Sets the z-index of this layer and adjusts any shadow and shim z-indexes. The layer z-index is automatically
		///     incremented by two more than the value passed in so that it always shows above any shadow or shim (the shadow
		///     element, if any, will be assigned z-index + 1, and the shim element, if any, will be assigned the unmodified z-index).
		/// </summary>
		/// <returns>Layer</returns>
		public extern virtual void setZIndex();

		/// <summary>
		///     Sets the z-index of this layer and adjusts any shadow and shim z-indexes. The layer z-index is automatically
		///     incremented by two more than the value passed in so that it always shows above any shadow or shim (the shadow
		///     element, if any, will be assigned z-index + 1, and the shim element, if any, will be assigned the unmodified z-index).
		/// </summary>
		/// <param name="zindex">The new z-index to set</param>
		/// <returns>Layer</returns>
		public extern virtual void setZIndex(double zindex);



	}

	[JsAnonymous]
	public class LayerConfig : System.DotWeb.JsDynamic {
		/// <summary> False to disable the iframe shim in browsers which need one (defaults to true)</summary>
		public bool shim { get { return (bool)this["shim"]; } set { this["shim"] = value; } }

		/// <summary>{String/Boolean} True to create a shadow element with default class "x-layer-shadow", or</summary>
		public object shadow { get { return (object)this["shadow"]; } set { this["shadow"] = value; } }

		/// <summary> DomHelper object config to create element with (defaults to {tag: "div", cls: "x-layer"}).</summary>
		public object dh { get { return (object)this["dh"]; } set { this["dh"] = value; } }

		/// <summary> False to disable constrain to viewport (defaults to true)</summary>
		public bool constrain { get { return (bool)this["constrain"]; } set { this["constrain"] = value; } }

		/// <summary> CSS class to add to the element</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

		/// <summary> Starting z-index (defaults to 11000)</summary>
		public double zindex { get { return (double)this["zindex"]; } set { this["zindex"] = value; } }

		/// <summary> Number of pixels to offset the shadow (defaults to 3)</summary>
		public double shadowOffset { get { return (double)this["shadowOffset"]; } set { this["shadowOffset"] = value; } }

	}
}
