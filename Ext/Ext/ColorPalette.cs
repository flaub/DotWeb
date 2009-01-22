using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     Simple color palette class for choosing colors.  The palette can be rendered to any container.<br />
    ///     Here's an example of typical usage:
    ///     <pre><code>
    ///     var cp = new Ext.ColorPalette({value:'993300'});  // initial selected color
    ///     cp.render('my-div');
    ///     cp.on('select', function(palette, selColor){
    ///     // do something with selColor
    ///     });
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\ColorPalette.js</jssource>
    [Native]
    public class ColorPalette : Ext.Component {

        /// <summary>Create a new ColorPalette</summary>
        /// <returns></returns>
        public ColorPalette() {}
        /// <summary>Create a new ColorPalette</summary>
        /// <param name="config">The config object</param>
        /// <returns></returns>
        public ColorPalette(object config) {}
        /// <summary>
        ///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
        ///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
        /// </summary>
        /// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
        /// <returns></returns>
        public ColorPalette(Ext.Element config) {}
        /// <summary>
        ///     element and its id used as the component id.  If a string is passed, it is assumed to be the id of an existing element
        ///     and is used as the component id.  Otherwise, it is assumed to be a standard config object and is applied to the component.
        /// </summary>
        /// <param name="config">The configuration options.  If an element is passed, it is set as the internal</param>
        /// <returns></returns>
        public ColorPalette(System.String config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static ColorPalette prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.Component superclass { get { return null; } set { } }

        /// <summary>An existing XTemplate instance to be used in place of the default template for rendering the component.</summary>
        public System.String tpl { get { return null; } set { } }

        /// <summary>The CSS class to apply to the containing element (defaults to "x-color-palette")</summary>
        public System.String itemCls { get { return null; } set { } }

        /// <summary>
        ///     The initial color to highlight (should be a valid 6-digit color hex code without the # symbol).  Note that
        ///     the hex codes are case-sensitive.
        /// </summary>
        public System.String value { get { return null; } set { } }

        /// <summary>If set to true then reselecting a color that is already selected fires the {@link #select} event</summary>
        public bool allowReselect { get { return false; } set { } }

        /// <summary>
        ///     <p>An array of 6-digit color hex code strings (without the # symbol).  This array can contain any number
        ///     of colors, and each hex code should be unique.  The width of the palette is controlled via CSS by adjusting
        ///     the width property of the 'x-color-palette' class (or assigning a custom class), so you can balance the number
        ///     of colors with the width setting until the box is symmetrical.</p>
        ///     <p>You can override individual colors if needed:</p>
        ///     <pre><code>
        ///     var cp = new Ext.ColorPalette();
        ///     cp.colors[0] = "FF0000";  // change the first box to red
        ///     </code></pre>
        ///     Or you can provide a custom array of your own for complete control:
        ///     <pre><code>
        ///     var cp = new Ext.ColorPalette();
        ///     cp.colors = ["000000", "993300", "333300"];
        ///     </code></pre>
        /// </summary>
        public System.Array colors { get { return null; } set { } }


        /// <summary>Selects the specified color in the palette (fires the {@link #select} event)</summary>
        /// <returns></returns>
        public virtual void select() { return ; }

        /// <summary>Selects the specified color in the palette (fires the {@link #select} event)</summary>
        /// <param name="color">A valid 6-digit color hex code (# will be stripped if included)</param>
        /// <returns></returns>
        public virtual void select(System.String color) { return ; }



    }
    [Anonymous]
    public class ColorPaletteConfig {

        /// <summary> An existing XTemplate instance to be used in place of the default template for rendering the component.</summary>
        public System.String tpl { get { return null; } set { } }

        /// <summary>  The CSS class to apply to the containing element (defaults to "x-color-palette")</summary>
        public System.String itemCls { get { return null; } set { } }

        /// <summary>  The initial color to highlight (should be a valid 6-digit color hex code without the # symbol).  Note that the hex codes are case-sensitive.</summary>
        public System.String value { get { return null; } set { } }

        /// <summary> If set to true then reselecting a color that is already selected fires the {@link #select} event</summary>
        public bool allowReselect { get { return false; } set { } }

        /// <summary> 
        ///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
        ///     The predefined xtypes are listed at the top of this document.
        ///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
        /// </summary>
        public string xtype { get { return null; } set { } }

        /// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
        public System.String id { get { return null; } set { } }

        /// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
        public object autoEl { get { return null; } set { } }

        /// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
        public System.String cls { get { return null; } set { } }

        /// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
        public System.String overCls { get { return null; } set { } }

        /// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
        public System.String style { get { return null; } set { } }

        /// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
        public System.String ctCls { get { return null; } set { } }

        /// <summary>  Render this component disabled (default is false).</summary>
        public bool disabled { get { return false; } set { } }

        /// <summary>  Render this component hidden (default is false).</summary>
        public bool hidden { get { return false; } set { } }

        /// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
        public object plugins { get { return null; } set { } }

        /// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
        public object applyTo { get { return null; } set { } }

        /// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
        public object renderTo { get { return null; } set { } }

        /// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
        public bool stateful { get { return false; } set { } }

        /// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
        public System.String stateId { get { return null; } set { } }

        /// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
        public System.String disabledClass { get { return null; } set { } }

        /// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
        public bool allowDomMove { get { return false; } set { } }

        /// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
        public bool autoShow { get { return false; } set { } }

        /// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
        public System.String hideMode { get { return null; } set { } }

        /// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
        public bool hideParent { get { return false; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }

    public class ColorPaletteEvents {
        /// <summary>Fires when a color is selected
        /// <pre><code>
        /// USAGE: ({ColorPalette} objthis, {String} color)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>color</b></term><description>The 6-digit color hex code (without the # symbol)</description></item>
        /// </list>
        /// </summary>
        public static string select { get { return "select"; } }
    }

    public delegate void ColorPaletteSelectDelegate(ColorPalette objthis, System.String color);
}
