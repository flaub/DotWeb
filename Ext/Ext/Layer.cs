using System;
using H8.Support;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\Layer.js</jssource>
    [Native]
    public class Layer : Ext.Element {

        /// <summary></summary>
        /// <returns></returns>
        public Layer() {}
        /// <summary></summary>
        /// <param name="config">An object with config options.</param>
        /// <returns></returns>
        public Layer(object config) {}
        /// <summary></summary>
        /// <param name="config">An object with config options.</param>
        /// <param name="existingEl">(optional) Uses an existing DOM element. If the element is not found it creates it.</param>
        /// <returns></returns>
        public Layer(object config, System.String existingEl) {}
        /// <summary></summary>
        /// <param name="config">An object with config options.</param>
        /// <param name="existingEl">(optional) Uses an existing DOM element. If the element is not found it creates it.</param>
        /// <returns></returns>
        public Layer(object config, DOMElement existingEl) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Layer(System.String element) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
        /// <returns></returns>
        public Layer(System.String element, bool forceNew) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Layer(DOMElement element) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
        /// <returns></returns>
        public Layer(DOMElement element, bool forceNew) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Layer prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.Element superclass { get { return null; } set { } }


        /// <summary>
        ///     Sets the z-index of this layer and adjusts any shadow and shim z-indexes. The layer z-index is automatically
        ///     incremented by two more than the value passed in so that it always shows above any shadow or shim (the shadow
        ///     element, if any, will be assigned z-index + 1, and the shim element, if any, will be assigned the unmodified z-index).
        /// </summary>
        /// <returns>Layer</returns>
        public virtual Layer setZIndex() { return null; }

        /// <summary>
        ///     Sets the z-index of this layer and adjusts any shadow and shim z-indexes. The layer z-index is automatically
        ///     incremented by two more than the value passed in so that it always shows above any shadow or shim (the shadow
        ///     element, if any, will be assigned z-index + 1, and the shim element, if any, will be assigned the unmodified z-index).
        /// </summary>
        /// <param name="zindex">The new z-index to set</param>
        /// <returns>Layer</returns>
        public virtual Layer setZIndex(double zindex) { return null; }



    }
    [Anonymous]
    public class LayerConfig {

        /// <summary> False to disable the iframe shim in browsers which need one (defaults to true)</summary>
        public bool shim { get { return false; } set { } }

        /// <summary>{String/Boolean} True to create a shadow element with default class "x-layer-shadow", or</summary>
        public object shadow { get { return null; } set { } }

        /// <summary> DomHelper object config to create element with (defaults to {tag: "div", cls: "x-layer"}).</summary>
        public object dh { get { return null; } set { } }

        /// <summary> False to disable constrain to viewport (defaults to true)</summary>
        public bool constrain { get { return false; } set { } }

        /// <summary> CSS class to add to the element</summary>
        public System.String cls { get { return null; } set { } }

        /// <summary> Starting z-index (defaults to 11000)</summary>
        public double zindex { get { return 0; } set { } }

        /// <summary> Number of pixels to offset the shadow (defaults to 3)</summary>
        public double shadowOffset { get { return 0; } set { } }

    }


}
