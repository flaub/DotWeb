using System;
using DotWeb.Core;

namespace Ext {
    /// <summary>
    ///     /**
    ///     Represents an Element in the DOM.<br><br>
    ///     Usage:<br>
    ///     <pre><code>
    ///     // by id
    ///     var el = Ext.get("my-div");
    ///     // by DOM element reference
    ///     var el = Ext.get(myDivElement);
    ///     </code></pre>
    ///     <b>Animations</b><br />
    ///     Many of the functions for manipulating an element have an optional "animate" parameter. The animate parameter
    ///     should either be a boolean (true) or an object literal with animation options. Note that the supported Element animation
    ///     options are a subset of the {@link Ext.Fx} animation options specific to Fx effects.  The Element animation options are:
    ///     <pre>
    ///     Option    Default   Description
    ///     --------- --------  ---------------------------------------------
    ///     duration  .35       The duration of the animation in seconds
    ///     easing    easeOut   The easing method
    ///     callback  none      A function to execute when the anim completes
    ///     scope     this      The scope (this) of the callback function
    ///     </pre>
    ///     Also, the Anim object being used for the animation will be set on your options object as "anim", which allows you to stop or
    ///     manipulate the animation. Here's an example:
    ///     <pre><code>
    ///     var el = Ext.get("my-div");
    ///     // no animation
    ///     el.setWidth(100);
    ///     // default animation
    ///     el.setWidth(100, true);
    ///     // animation with some options set
    ///     el.setWidth(100, {
    ///     duration: 1,
    ///     callback: this.foo,
    ///     scope: this
    ///     });
    ///     // using the "anim" property to get the Anim object
    ///     var opt = {
    ///     duration: 1,
    ///     callback: this.foo,
    ///     scope: this
    ///     };
    ///     el.setWidth(100, opt);
    ///     ...
    ///     if(opt.anim.isAnimated()){
    ///     opt.anim.stop();
    ///     }
    ///     </code></pre>
    ///     <b> Composite (Collections of) Elements</b><br />
    ///     For working with collections of Elements, see {@link Ext.CompositeElement}
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\core\Element.js</jssource>
    [Native]
    public class Element  {

        /// <summary></summary>
        /// <returns></returns>
        public Element() {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Element(System.String element) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
        /// <returns></returns>
        public Element(System.String element, bool forceNew) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public Element(DOMElement element) {}
        /// <summary></summary>
        /// <param name="element"></param>
        /// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
        /// <returns></returns>
        public Element(DOMElement element, bool forceNew) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Element prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The DOM element</summary>
        public DOMElement dom { get { return null; } set { } }

        /// <summary>The DOM element ID</summary>
        public System.String id { get { return null; } set { } }

        /// <summary>The element's default display mode  (defaults to "")</summary>
        public System.String originalDisplay { get { return null; } set { } }

        /// <summary>The default unit to append to CSS values where a unit isn't provided (defaults to px).</summary>
        public System.String defaultUnit { get { return null; } set { } }

        /// <summary>true to automatically adjust width and height settings for box-model issues (default to true)</summary>
        public object autoBoxAdjust { get { return null; } set { } }

        /// <summary>Visibility mode constant - Use visibility to hide element</summary>
        public static double VISIBILITY { get { return 0; } set { } }

        /// <summary>Visibility mode constant - Use display to hide element</summary>
        public static double DISPLAY { get { return 0; } set { } }


        /// <summary>
        ///     Sets the element's visibility mode. When setVisible() is called it
        ///     will use this to determine whether to set the visibility or the display property.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setVisibilityMode() { return null; }

        /// <summary>
        ///     Sets the element's visibility mode. When setVisible() is called it
        ///     will use this to determine whether to set the visibility or the display property.
        /// </summary>
        /// <param name="visMode">Element.VISIBILITY or Element.DISPLAY</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setVisibilityMode(object visMode) { return null; }

        /// <summary>Convenience method for setVisibilityMode(Element.DISPLAY)</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element enableDisplayMode() { return null; }

        /// <summary>Convenience method for setVisibilityMode(Element.DISPLAY)</summary>
        /// <param name="display">(optional) What to set display to when visible</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element enableDisplayMode(System.String display) { return null; }

        /// <summary>
        ///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParent() { return null; }

        /// <summary>
        ///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParent(System.String selector) { return null; }

        /// <summary>
        ///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParent(System.String selector, double maxDepth) { return null; }

        /// <summary>
        ///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParent(System.String selector, double maxDepth, bool returnEl) { return null; }

        /// <summary>
        ///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParent(System.String selector, object maxDepth) { return null; }

        /// <summary>
        ///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParent(System.String selector, object maxDepth, bool returnEl) { return null; }

        /// <summary>
        ///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParentNode() { return null; }

        /// <summary>
        ///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParentNode(System.String selector) { return null; }

        /// <summary>
        ///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParentNode(System.String selector, double maxDepth) { return null; }

        /// <summary>
        ///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParentNode(System.String selector, double maxDepth, bool returnEl) { return null; }

        /// <summary>
        ///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParentNode(System.String selector, object maxDepth) { return null; }

        /// <summary>
        ///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement findParentNode(System.String selector, object maxDepth, bool returnEl) { return null; }

        /// <summary>
        ///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
        ///     This is a shortcut for findParentNode() that always returns an Ext.Element.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element up() { return null; }

        /// <summary>
        ///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
        ///     This is a shortcut for findParentNode() that always returns an Ext.Element.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element up(System.String selector) { return null; }

        /// <summary>
        ///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
        ///     This is a shortcut for findParentNode() that always returns an Ext.Element.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element up(System.String selector, double maxDepth) { return null; }

        /// <summary>
        ///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
        ///     This is a shortcut for findParentNode() that always returns an Ext.Element.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element up(System.String selector, object maxDepth) { return null; }

        /// <summary>Returns true if this element matches the passed simple selector (e.g. div.some-class or span:first-child)</summary>
        /// <returns>Boolean</returns>
        public virtual bool is_() { return false; }

        /// <summary>Returns true if this element matches the passed simple selector (e.g. div.some-class or span:first-child)</summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>Boolean</returns>
        public virtual bool is_(System.String selector) { return false; }

        /// <summary>Perform animation on this element.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element animate() { return null; }

        /// <summary>Perform animation on this element.</summary>
        /// <param name="args">The animation control args</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element animate(object args) { return null; }

        /// <summary>Perform animation on this element.</summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element animate(object args, double duration) { return null; }

        /// <summary>Perform animation on this element.</summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
        /// <param name="onComplete">(optional) Function to call when animation completes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element animate(object args, double duration, Delegate onComplete) { return null; }

        /// <summary>Perform animation on this element.</summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
        /// <param name="onComplete">(optional) Function to call when animation completes</param>
        /// <param name="easing">(optional) Easing method to use (defaults to 'easeOut')</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element animate(object args, double duration, Delegate onComplete, System.String easing) { return null; }

        /// <summary>Perform animation on this element.</summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
        /// <param name="onComplete">(optional) Function to call when animation completes</param>
        /// <param name="easing">(optional) Easing method to use (defaults to 'easeOut')</param>
        /// <param name="animType">(optional) 'run' is the default. Can also be 'color', 'motion', or 'scroll'</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element animate(object args, double duration, Delegate onComplete, System.String easing, System.String animType) { return null; }

        /// <summary>
        ///     Removes worthless text nodes
        ///     keeps track if it has been cleaned already so
        ///     you can call this over and over. However, if you update the element and
        ///     need to force a reclean, you can pass true.
        /// </summary>
        /// <returns></returns>
        public virtual void clean() { return ; }

        /// <summary>
        ///     Removes worthless text nodes
        ///     keeps track if it has been cleaned already so
        ///     you can call this over and over. However, if you update the element and
        ///     need to force a reclean, you can pass true.
        /// </summary>
        /// <param name="forceReclean">(optional) By default the element</param>
        /// <returns></returns>
        public virtual void clean(bool forceReclean) { return ; }

        /// <summary>
        ///     Scrolls this element into view within the passed container.
        ///     string (id), dom node, or Ext.Element.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element scrollIntoView() { return null; }

        /// <summary>
        ///     Scrolls this element into view within the passed container.
        ///     string (id), dom node, or Ext.Element.
        /// </summary>
        /// <param name="container">(optional) The container element to scroll (defaults to document.body).  Should be a</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element scrollIntoView(object container) { return null; }

        /// <summary>
        ///     Scrolls this element into view within the passed container.
        ///     string (id), dom node, or Ext.Element.
        /// </summary>
        /// <param name="container">(optional) The container element to scroll (defaults to document.body).  Should be a</param>
        /// <param name="hscroll">(optional) False to disable horizontal scroll (defaults to true)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element scrollIntoView(object container, bool hscroll) { return null; }

        /// <summary>
        ///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
        ///     the new height may not be available immediately.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element autoHeight() { return null; }

        /// <summary>
        ///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
        ///     the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">(optional) Animate the transition (defaults to false)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element autoHeight(bool animate) { return null; }

        /// <summary>
        ///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
        ///     the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">(optional) Animate the transition (defaults to false)</param>
        /// <param name="duration">(optional) Length of the animation in seconds (defaults to .35)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element autoHeight(bool animate, double duration) { return null; }

        /// <summary>
        ///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
        ///     the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">(optional) Animate the transition (defaults to false)</param>
        /// <param name="duration">(optional) Length of the animation in seconds (defaults to .35)</param>
        /// <param name="onComplete">(optional) Function to call when animation completes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element autoHeight(bool animate, double duration, Delegate onComplete) { return null; }

        /// <summary>
        ///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
        ///     the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">(optional) Animate the transition (defaults to false)</param>
        /// <param name="duration">(optional) Length of the animation in seconds (defaults to .35)</param>
        /// <param name="onComplete">(optional) Function to call when animation completes</param>
        /// <param name="easing">(optional) Easing method to use (defaults to easeOut)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element autoHeight(bool animate, double duration, Delegate onComplete, System.String easing) { return null; }

        /// <summary>Returns true if this element is an ancestor of the passed element</summary>
        /// <returns>Boolean</returns>
        public virtual bool contains() { return false; }

        /// <summary>Returns true if this element is an ancestor of the passed element</summary>
        /// <param name="el">The element to check</param>
        /// <returns>Boolean</returns>
        public virtual bool contains(DOMElement el) { return false; }

        /// <summary>Returns true if this element is an ancestor of the passed element</summary>
        /// <param name="el">The element to check</param>
        /// <returns>Boolean</returns>
        public virtual bool contains(System.String el) { return false; }

        /// <summary>Checks whether the element is currently visible using both visibility and display properties.</summary>
        /// <returns>Boolean</returns>
        public virtual bool isVisible() { return false; }

        /// <summary>Checks whether the element is currently visible using both visibility and display properties.</summary>
        /// <param name="deep">(optional) True to walk the dom and see if parent elements are hidden (defaults to false)</param>
        /// <returns>Boolean</returns>
        public virtual bool isVisible(bool deep) { return false; }

        /// <summary>Creates a {@link Ext.CompositeElement} for child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public virtual object select() { return null; }

        /// <summary>Creates a {@link Ext.CompositeElement} for child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public virtual object select(System.String selector) { return null; }

        /// <summary>Creates a {@link Ext.CompositeElement} for child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
        /// <returns>CompositeElement/CompositeElementLite</returns>
        public virtual object select(System.String selector, bool unique) { return null; }

        /// <summary>Selects child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <returns>Array</returns>
        public virtual System.Array query() { return null; }

        /// <summary>Selects child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>Array</returns>
        public virtual System.Array query(System.String selector) { return null; }

        /// <summary>Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object child() { return null; }

        /// <summary>Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object child(System.String selector) { return null; }

        /// <summary>Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <param name="returnDom">(optional) True to return the DOM node instead of Ext.Element (defaults to false)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object child(System.String selector, bool returnDom) { return null; }

        /// <summary>Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object down() { return null; }

        /// <summary>Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object down(System.String selector) { return null; }

        /// <summary>Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).</summary>
        /// <param name="selector">The CSS selector</param>
        /// <param name="returnDom">(optional) True to return the DOM node instead of Ext.Element (defaults to false)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object down(System.String selector, bool returnDom) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
        /// <returns>Ext.dd.DD</returns>
        public virtual Ext.dd.DD initDD() { return null; }

        /// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
        /// <param name="group">The group the DD object is member of</param>
        /// <returns>Ext.dd.DD</returns>
        public virtual Ext.dd.DD initDD(System.String group) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
        /// <param name="group">The group the DD object is member of</param>
        /// <param name="config">The DD config object</param>
        /// <returns>Ext.dd.DD</returns>
        public virtual Ext.dd.DD initDD(System.String group, object config) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
        /// <param name="group">The group the DD object is member of</param>
        /// <param name="config">The DD config object</param>
        /// <param name="overrides">An object containing methods to override/implement on the DD object</param>
        /// <returns>Ext.dd.DD</returns>
        public virtual Ext.dd.DD initDD(System.String group, object config, object overrides) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
        /// <returns>Ext.dd.DDProxy</returns>
        public virtual Ext.dd.DDProxy initDDProxy() { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
        /// <param name="group">The group the DDProxy object is member of</param>
        /// <returns>Ext.dd.DDProxy</returns>
        public virtual Ext.dd.DDProxy initDDProxy(System.String group) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
        /// <param name="group">The group the DDProxy object is member of</param>
        /// <param name="config">The DDProxy config object</param>
        /// <returns>Ext.dd.DDProxy</returns>
        public virtual Ext.dd.DDProxy initDDProxy(System.String group, object config) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
        /// <param name="group">The group the DDProxy object is member of</param>
        /// <param name="config">The DDProxy config object</param>
        /// <param name="overrides">An object containing methods to override/implement on the DDProxy object</param>
        /// <returns>Ext.dd.DDProxy</returns>
        public virtual Ext.dd.DDProxy initDDProxy(System.String group, object config, object overrides) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
        /// <returns>Ext.dd.DDTarget</returns>
        public virtual Ext.dd.DDTarget initDDTarget() { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
        /// <param name="group">The group the DDTarget object is member of</param>
        /// <returns>Ext.dd.DDTarget</returns>
        public virtual Ext.dd.DDTarget initDDTarget(System.String group) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
        /// <param name="group">The group the DDTarget object is member of</param>
        /// <param name="config">The DDTarget config object</param>
        /// <returns>Ext.dd.DDTarget</returns>
        public virtual Ext.dd.DDTarget initDDTarget(System.String group, object config) { return null; }

        /// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
        /// <param name="group">The group the DDTarget object is member of</param>
        /// <param name="config">The DDTarget config object</param>
        /// <param name="overrides">An object containing methods to override/implement on the DDTarget object</param>
        /// <returns>Ext.dd.DDTarget</returns>
        public virtual Ext.dd.DDTarget initDDTarget(System.String group, object config, object overrides) { return null; }

        /// <summary>
        ///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
        ///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setVisible() { return null; }

        /// <summary>
        ///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
        ///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
        /// </summary>
        /// <param name="visible">Whether the element is visible</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setVisible(bool visible) { return null; }

        /// <summary>
        ///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
        ///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
        /// </summary>
        /// <param name="visible">Whether the element is visible</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setVisible(bool visible, bool animate) { return null; }

        /// <summary>
        ///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
        ///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
        /// </summary>
        /// <param name="visible">Whether the element is visible</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setVisible(bool visible, object animate) { return null; }

        /// <summary>Returns true if display is not "none"</summary>
        /// <returns>Boolean</returns>
        public virtual bool isDisplayed() { return false; }

        /// <summary>Toggles the element's visibility or display, depending on visibility mode.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element toggle() { return null; }

        /// <summary>Toggles the element's visibility or display, depending on visibility mode.</summary>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element toggle(bool animate) { return null; }

        /// <summary>Toggles the element's visibility or display, depending on visibility mode.</summary>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element toggle(object animate) { return null; }

        /// <summary>Sets the CSS display property. Uses originalDisplay if the specified value is a boolean true.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setDisplayed() { return null; }

        /// <summary>Sets the CSS display property. Uses originalDisplay if the specified value is a boolean true.</summary>
        /// <param name="value">Boolean value to display the element using its default display, or a string to set the display directly.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setDisplayed(object value) { return null; }

        /// <summary>Tries to focus the element. Any exceptions are caught and ignored.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element focus() { return null; }

        /// <summary>Tries to blur the element. Any exceptions are caught and ignored.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element blur() { return null; }

        /// <summary>Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClass() { return null; }

        /// <summary>Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.</summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClass(System.String className) { return null; }

        /// <summary>Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.</summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClass(System.Array className) { return null; }

        /// <summary>Adds one or more CSS classes to this element and removes the same class(es) from all siblings.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element radioClass() { return null; }

        /// <summary>Adds one or more CSS classes to this element and removes the same class(es) from all siblings.</summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element radioClass(System.String className) { return null; }

        /// <summary>Adds one or more CSS classes to this element and removes the same class(es) from all siblings.</summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element radioClass(System.Array className) { return null; }

        /// <summary>Removes one or more CSS classes from the element.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeClass() { return null; }

        /// <summary>Removes one or more CSS classes from the element.</summary>
        /// <param name="className">The CSS class to remove, or an array of classes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeClass(System.String className) { return null; }

        /// <summary>Removes one or more CSS classes from the element.</summary>
        /// <param name="className">The CSS class to remove, or an array of classes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeClass(System.Array className) { return null; }

        /// <summary>Toggles the specified CSS class on this element (removes it if it already exists, otherwise adds it).</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element toggleClass() { return null; }

        /// <summary>Toggles the specified CSS class on this element (removes it if it already exists, otherwise adds it).</summary>
        /// <param name="className">The CSS class to toggle</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element toggleClass(System.String className) { return null; }

        /// <summary>Checks if the specified CSS class exists on this element's DOM node.</summary>
        /// <returns>Boolean</returns>
        public virtual bool hasClass() { return false; }

        /// <summary>Checks if the specified CSS class exists on this element's DOM node.</summary>
        /// <param name="className">The CSS class to check for</param>
        /// <returns>Boolean</returns>
        public virtual bool hasClass(System.String className) { return false; }

        /// <summary>Replaces a CSS class on the element with another.  If the old name does not exist, the new name will simply be added.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replaceClass() { return null; }

        /// <summary>Replaces a CSS class on the element with another.  If the old name does not exist, the new name will simply be added.</summary>
        /// <param name="oldClassName">The CSS class to replace</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replaceClass(System.String oldClassName) { return null; }

        /// <summary>Replaces a CSS class on the element with another.  If the old name does not exist, the new name will simply be added.</summary>
        /// <param name="oldClassName">The CSS class to replace</param>
        /// <param name="newClassName">The replacement CSS class</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replaceClass(System.String oldClassName, System.String newClassName) { return null; }

        /// <summary>
        ///     Returns an object with properties matching the styles requested.
        ///     For example, el.getStyles('color', 'font-size', 'width') might return
        ///     {'color': '#FFFFFF', 'font-size': '13px', 'width': '100px'}.
        /// </summary>
        /// <returns>Object</returns>
        public virtual object getStyles() { return null; }

        /// <summary>
        ///     Returns an object with properties matching the styles requested.
        ///     For example, el.getStyles('color', 'font-size', 'width') might return
        ///     {'color': '#FFFFFF', 'font-size': '13px', 'width': '100px'}.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Object</returns>
        public virtual object getStyles(params System.String[] args) { return null; }

        /// <summary>Normalizes currentStyle and computedStyle.</summary>
        /// <returns>String</returns>
        public virtual System.String getStyle() { return null; }

        /// <summary>Normalizes currentStyle and computedStyle.</summary>
        /// <param name="property">The style property whose value is returned.</param>
        /// <returns>String</returns>
        public virtual System.String getStyle(System.String property) { return null; }

        /// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setStyle() { return null; }

        /// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
        /// <param name="property">The style property to be set, or an object of multiple styles.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setStyle(System.String property) { return null; }

        /// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
        /// <param name="property">The style property to be set, or an object of multiple styles.</param>
        /// <param name="value">(optional) The value to apply to the given property, or null if an object was passed.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setStyle(System.String property, System.String value) { return null; }

        /// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
        /// <param name="property">The style property to be set, or an object of multiple styles.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setStyle(object property) { return null; }

        /// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
        /// <param name="property">The style property to be set, or an object of multiple styles.</param>
        /// <param name="value">(optional) The value to apply to the given property, or null if an object was passed.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setStyle(object property, System.String value) { return null; }

        /// <summary>
        ///     More flexible version of {@link #setStyle} for setting style properties.
        ///     a function which returns such a specification.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element applyStyles() { return null; }

        /// <summary>
        ///     More flexible version of {@link #setStyle} for setting style properties.
        ///     a function which returns such a specification.
        /// </summary>
        /// <param name="styles">A style specification string, e.g. "width:100px", or object in the form {width:"100px"}, or</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element applyStyles(System.String styles) { return null; }

        /// <summary>
        ///     More flexible version of {@link #setStyle} for setting style properties.
        ///     a function which returns such a specification.
        /// </summary>
        /// <param name="styles">A style specification string, e.g. "width:100px", or object in the form {width:"100px"}, or</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element applyStyles(object styles) { return null; }

        /// <summary>
        ///     More flexible version of {@link #setStyle} for setting style properties.
        ///     a function which returns such a specification.
        /// </summary>
        /// <param name="styles">A style specification string, e.g. "width:100px", or object in the form {width:"100px"}, or</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element applyStyles(Delegate styles) { return null; }

        /// <summary>Gets the current X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <returns>Number</returns>
        public virtual double getX() { return 0; }

        /// <summary>Gets the current Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <returns>Number</returns>
        public virtual double getY() { return 0; }

        /// <summary>Gets the current position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <returns>Array</returns>
        public virtual System.Array getXY() { return null; }

        /// <summary>Returns the offsets of this element from the passed element. Both element must be part of the DOM tree and not have display:none to have page coordinates.</summary>
        /// <returns>Array</returns>
        public virtual System.Array getOffsetsTo() { return null; }

        /// <summary>Returns the offsets of this element from the passed element. Both element must be part of the DOM tree and not have display:none to have page coordinates.</summary>
        /// <param name="element">The element to get the offsets from.</param>
        /// <returns>Array</returns>
        public virtual System.Array getOffsetsTo(object element) { return null; }

        /// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setX() { return null; }

        /// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <param name="The">X position of the element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setX(double The) { return null; }

        /// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <param name="The">X position of the element</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setX(double The, bool animate) { return null; }

        /// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <param name="The">X position of the element</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setX(double The, object animate) { return null; }

        /// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setY() { return null; }

        /// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <param name="The">Y position of the element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setY(double The) { return null; }

        /// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <param name="The">Y position of the element</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setY(double The, bool animate) { return null; }

        /// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
        /// <param name="The">Y position of the element</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setY(double The, object animate) { return null; }

        /// <summary>Sets the element's left position directly using CSS style (instead of {@link #setX}).</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLeft() { return null; }

        /// <summary>Sets the element's left position directly using CSS style (instead of {@link #setX}).</summary>
        /// <param name="left">The left CSS property value</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLeft(System.String left) { return null; }

        /// <summary>Sets the element's top position directly using CSS style (instead of {@link #setY}).</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setTop() { return null; }

        /// <summary>Sets the element's top position directly using CSS style (instead of {@link #setY}).</summary>
        /// <param name="top">The top CSS property value</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setTop(System.String top) { return null; }

        /// <summary>Sets the element's CSS right style.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setRight() { return null; }

        /// <summary>Sets the element's CSS right style.</summary>
        /// <param name="right">The right CSS property value</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setRight(System.String right) { return null; }

        /// <summary>Sets the element's CSS bottom style.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBottom() { return null; }

        /// <summary>Sets the element's CSS bottom style.</summary>
        /// <param name="bottom">The bottom CSS property value</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBottom(System.String bottom) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setXY() { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="pos">Contains X & Y [x, y] values for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setXY(System.Array pos) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="pos">Contains X & Y [x, y] values for new position (coordinates are page-based)</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setXY(System.Array pos, bool animate) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="pos">Contains X & Y [x, y] values for new position (coordinates are page-based)</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setXY(System.Array pos, object animate) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLocation() { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLocation(double x) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLocation(double x, double y) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLocation(double x, double y, bool animate) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLocation(double x, double y, object animate) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element moveTo() { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element moveTo(double x) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element moveTo(double x, double y) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element moveTo(double x, double y, bool animate) { return null; }

        /// <summary>
        ///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
        ///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element moveTo(double x, double y, object animate) { return null; }

        /// <summary>
        ///     Returns the region of the given element.
        ///     The element must be part of the DOM tree to have a region (display:none or elements not appended return false).
        /// </summary>
        /// <returns>Region</returns>
        public virtual object getRegion() { return null; }

        /// <summary>Returns the offset height of the element</summary>
        /// <returns>Number</returns>
        public virtual double getHeight() { return 0; }

        /// <summary>Returns the offset height of the element</summary>
        /// <param name="contentHeight">(optional) true to get the height minus borders and padding</param>
        /// <returns>Number</returns>
        public virtual double getHeight(bool contentHeight) { return 0; }

        /// <summary>Returns the offset width of the element</summary>
        /// <returns>Number</returns>
        public virtual double getWidth() { return 0; }

        /// <summary>Returns the offset width of the element</summary>
        /// <param name="contentWidth">(optional) true to get the width minus borders and padding</param>
        /// <returns>Number</returns>
        public virtual double getWidth(bool contentWidth) { return 0; }

        /// <summary>
        ///     Returns either the offsetHeight or the height of this element based on CSS height adjusted by padding or borders
        ///     when needed to simulate offsetHeight when offsets aren't available. This may not work on display:none elements
        ///     if a height has not been set using CSS.
        /// </summary>
        /// <returns>Number</returns>
        public virtual double getComputedHeight() { return 0; }

        /// <summary>
        ///     Returns either the offsetWidth or the width of this element based on CSS width adjusted by padding or borders
        ///     when needed to simulate offsetWidth when offsets aren't available. This may not work on display:none elements
        ///     if a width has not been set using CSS.
        /// </summary>
        /// <returns>Number</returns>
        public virtual double getComputedWidth() { return 0; }

        /// <summary>Returns the size of the element.</summary>
        /// <returns>Object</returns>
        public virtual object getSize() { return null; }

        /// <summary>Returns the size of the element.</summary>
        /// <param name="contentSize">(optional) true to get the width/size minus borders and padding</param>
        /// <returns>Object</returns>
        public virtual object getSize(bool contentSize) { return null; }

        /// <summary>Returns the width and height of the viewport.</summary>
        /// <returns>Object</returns>
        public virtual object getViewSize() { return null; }

        /// <summary>Returns the value of the "value" attribute</summary>
        /// <returns>String/Number</returns>
        public virtual object getValue() { return null; }

        /// <summary>Returns the value of the "value" attribute</summary>
        /// <param name="asNumber">true to parse the value as a number</param>
        /// <returns>String/Number</returns>
        public virtual object getValue(bool asNumber) { return null; }

        /// <summary>Set the width of the element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setWidth() { return null; }

        /// <summary>Set the width of the element</summary>
        /// <param name="width">The new width</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setWidth(double width) { return null; }

        /// <summary>Set the width of the element</summary>
        /// <param name="width">The new width</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setWidth(double width, bool animate) { return null; }

        /// <summary>Set the width of the element</summary>
        /// <param name="width">The new width</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setWidth(double width, object animate) { return null; }

        /// <summary>Set the height of the element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setHeight() { return null; }

        /// <summary>Set the height of the element</summary>
        /// <param name="height">The new height</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setHeight(double height) { return null; }

        /// <summary>Set the height of the element</summary>
        /// <param name="height">The new height</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setHeight(double height, bool animate) { return null; }

        /// <summary>Set the height of the element</summary>
        /// <param name="height">The new height</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setHeight(double height, object animate) { return null; }

        /// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setSize() { return null; }

        /// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
        /// <param name="width">The new width</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setSize(double width) { return null; }

        /// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setSize(double width, double height) { return null; }

        /// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setSize(double width, double height, bool animate) { return null; }

        /// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setSize(double width, double height, object animate) { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds() { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds(double x) { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds(double x, double y) { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds(double x, double y, double width) { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds(double x, double y, double width, double height) { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds(double x, double y, double width, double height, bool animate) { return null; }

        /// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBounds(double x, double y, double width, double height, object animate) { return null; }

        /// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setRegion() { return null; }

        /// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="region">The region to fill</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setRegion(object region) { return null; }

        /// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="region">The region to fill</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setRegion(object region, bool animate) { return null; }

        /// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="region">The region to fill</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setRegion(object region, object animate) { return null; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     the following parameters:<ul>
        ///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
        ///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
        ///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
        ///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
        ///     </ul>
        ///     to this Element.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and adds a custom argument (forumId) to the
        ///     options object. The options object is available as the third parameter in the handler function.<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre></p>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.</p>
        ///     <p>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <returns></returns>
        public virtual void addListener() { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     the following parameters:<ul>
        ///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
        ///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
        ///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
        ///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
        ///     </ul>
        ///     to this Element.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and adds a custom argument (forumId) to the
        ///     options object. The options object is available as the third parameter in the handler function.<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre></p>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.</p>
        ///     <p>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <returns></returns>
        public virtual void addListener(System.String eventName) { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     the following parameters:<ul>
        ///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
        ///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
        ///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
        ///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
        ///     </ul>
        ///     to this Element.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and adds a custom argument (forumId) to the
        ///     options object. The options object is available as the third parameter in the handler function.<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre></p>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.</p>
        ///     <p>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes. This function is passed</param>
        /// <returns></returns>
        public virtual void addListener(System.String eventName, Delegate fn) { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     the following parameters:<ul>
        ///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
        ///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
        ///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
        ///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
        ///     </ul>
        ///     to this Element.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and adds a custom argument (forumId) to the
        ///     options object. The options object is available as the third parameter in the handler function.<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre></p>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.</p>
        ///     <p>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes. This function is passed</param>
        /// <param name="scope">(optional) The scope (The <tt>this</tt> reference) of the handler function. Defaults</param>
        /// <returns></returns>
        public virtual void addListener(System.String eventName, Delegate fn, object scope) { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     the following parameters:<ul>
        ///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
        ///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
        ///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
        ///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
        ///     </ul>
        ///     to this Element.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and adds a custom argument (forumId) to the
        ///     options object. The options object is available as the third parameter in the handler function.<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre></p>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.</p>
        ///     <p>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick,
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver,
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut,
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code></p>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut,
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes. This function is passed</param>
        /// <param name="scope">(optional) The scope (The <tt>this</tt> reference) of the handler function. Defaults</param>
        /// <param name="options">(optional) An object containing handler configuration properties.</param>
        /// <returns></returns>
        public virtual void addListener(System.String eventName, Delegate fn, object scope, object options) { return ; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        ///     to this Element.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeListener() { return null; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        ///     to this Element.
        /// </summary>
        /// <param name="eventName">the type of event to remove</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeListener(System.String eventName) { return null; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        ///     to this Element.
        /// </summary>
        /// <param name="eventName">the type of event to remove</param>
        /// <param name="fn">the method the event invokes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeListener(System.String eventName, Delegate fn) { return null; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        ///     to this Element.
        /// </summary>
        /// <param name="eventName">the type of event to remove</param>
        /// <param name="fn">the method the event invokes</param>
        /// <param name="scope">(optional) The scope (The <tt>this</tt> reference) of the handler function. Defaults</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeListener(System.String eventName, Delegate fn, object scope) { return null; }

        /// <summary>Removes all previous added listeners from this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element removeAllListeners() { return null; }

        /// <summary>
        ///     Create an event handler on this element such that when the event fires and is handled by this element,
        ///     it will be relayed to another object (i.e., fired again as if it originated from that object instead).
        ///     for firing the relayed event
        /// </summary>
        /// <returns></returns>
        public virtual void relayEvent() { return ; }

        /// <summary>
        ///     Create an event handler on this element such that when the event fires and is handled by this element,
        ///     it will be relayed to another object (i.e., fired again as if it originated from that object instead).
        ///     for firing the relayed event
        /// </summary>
        /// <param name="eventName">The type of event to relay</param>
        /// <returns></returns>
        public virtual void relayEvent(System.String eventName) { return ; }

        /// <summary>
        ///     Create an event handler on this element such that when the event fires and is handled by this element,
        ///     it will be relayed to another object (i.e., fired again as if it originated from that object instead).
        ///     for firing the relayed event
        /// </summary>
        /// <param name="eventName">The type of event to relay</param>
        /// <param name="obj">Any object that extends {@link Ext.util.Observable} that will provide the context</param>
        /// <returns></returns>
        public virtual void relayEvent(System.String eventName, object obj) { return ; }

        /// <summary>Set the opacity of the element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setOpacity() { return null; }

        /// <summary>Set the opacity of the element</summary>
        /// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setOpacity(double opacity) { return null; }

        /// <summary>Set the opacity of the element</summary>
        /// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setOpacity(double opacity, bool animate) { return null; }

        /// <summary>Set the opacity of the element</summary>
        /// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setOpacity(double opacity, object animate) { return null; }

        /// <summary>Gets the left X coordinate</summary>
        /// <returns>Number</returns>
        public virtual double getLeft() { return 0; }

        /// <summary>Gets the left X coordinate</summary>
        /// <param name="local">True to get the local css position instead of page coordinate</param>
        /// <returns>Number</returns>
        public virtual double getLeft(bool local) { return 0; }

        /// <summary>Gets the right X coordinate of the element (element X position + element width)</summary>
        /// <returns>Number</returns>
        public virtual double getRight() { return 0; }

        /// <summary>Gets the right X coordinate of the element (element X position + element width)</summary>
        /// <param name="local">True to get the local css position instead of page coordinate</param>
        /// <returns>Number</returns>
        public virtual double getRight(bool local) { return 0; }

        /// <summary>Gets the top Y coordinate</summary>
        /// <returns>Number</returns>
        public virtual double getTop() { return 0; }

        /// <summary>Gets the top Y coordinate</summary>
        /// <param name="local">True to get the local css position instead of page coordinate</param>
        /// <returns>Number</returns>
        public virtual double getTop(bool local) { return 0; }

        /// <summary>Gets the bottom Y coordinate of the element (element Y position + element height)</summary>
        /// <returns>Number</returns>
        public virtual double getBottom() { return 0; }

        /// <summary>Gets the bottom Y coordinate of the element (element Y position + element height)</summary>
        /// <param name="local">True to get the local css position instead of page coordinate</param>
        /// <returns>Number</returns>
        public virtual double getBottom(bool local) { return 0; }

        /// <summary>
        ///     Initializes positioning on this element. If a desired position is not passed, it will make the
        ///     the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <returns></returns>
        public virtual void position() { return ; }

        /// <summary>
        ///     Initializes positioning on this element. If a desired position is not passed, it will make the
        ///     the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
        /// <returns></returns>
        public virtual void position(System.String pos) { return ; }

        /// <summary>
        ///     Initializes positioning on this element. If a desired position is not passed, it will make the
        ///     the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
        /// <param name="zIndex">(optional) The zIndex to apply</param>
        /// <returns></returns>
        public virtual void position(System.String pos, double zIndex) { return ; }

        /// <summary>
        ///     Initializes positioning on this element. If a desired position is not passed, it will make the
        ///     the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
        /// <param name="zIndex">(optional) The zIndex to apply</param>
        /// <param name="x">(optional) Set the page X position</param>
        /// <returns></returns>
        public virtual void position(System.String pos, double zIndex, double x) { return ; }

        /// <summary>
        ///     Initializes positioning on this element. If a desired position is not passed, it will make the
        ///     the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
        /// <param name="zIndex">(optional) The zIndex to apply</param>
        /// <param name="x">(optional) Set the page X position</param>
        /// <param name="y">(optional) Set the page Y position</param>
        /// <returns></returns>
        public virtual void position(System.String pos, double zIndex, double x, double y) { return ; }

        /// <summary>Clear positioning back to the default when the document was loaded</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element clearPositioning() { return null; }

        /// <summary>Clear positioning back to the default when the document was loaded</summary>
        /// <param name="value">(optional) The value to use for the left,right,top,bottom, defaults to '' (empty string). You could use 'auto'.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element clearPositioning(System.String value) { return null; }

        /// <summary>
        ///     Gets an object with all CSS positioning properties. Useful along with setPostioning to get
        ///     snapshot before performing an update and then restoring the element.
        /// </summary>
        /// <returns>Object</returns>
        public virtual object getPositioning() { return null; }

        /// <summary>
        ///     Gets the width of the border(s) for the specified side(s)
        ///     passing lr would get the border (l)eft width + the border (r)ight width.
        /// </summary>
        /// <returns>Number</returns>
        public virtual double getBorderWidth() { return 0; }

        /// <summary>
        ///     Gets the width of the border(s) for the specified side(s)
        ///     passing lr would get the border (l)eft width + the border (r)ight width.
        /// </summary>
        /// <param name="side">Can be t, l, r, b or any combination of those to add multiple values. For example,</param>
        /// <returns>Number</returns>
        public virtual double getBorderWidth(System.String side) { return 0; }

        /// <summary>
        ///     Gets the width of the padding(s) for the specified side(s)
        ///     passing lr would get the padding (l)eft + the padding (r)ight.
        /// </summary>
        /// <returns>Number</returns>
        public virtual double getPadding() { return 0; }

        /// <summary>
        ///     Gets the width of the padding(s) for the specified side(s)
        ///     passing lr would get the padding (l)eft + the padding (r)ight.
        /// </summary>
        /// <param name="side">Can be t, l, r, b or any combination of those to add multiple values. For example,</param>
        /// <returns>Number</returns>
        public virtual double getPadding(System.String side) { return 0; }

        /// <summary>Set positioning with an object returned by getPositioning().</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setPositioning() { return null; }

        /// <summary>Set positioning with an object returned by getPositioning().</summary>
        /// <param name="posCfg"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setPositioning(object posCfg) { return null; }

        /// <summary>Quick set left and top adding default units</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLeftTop() { return null; }

        /// <summary>Quick set left and top adding default units</summary>
        /// <param name="left">The left CSS property value</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLeftTop(System.String left) { return null; }

        /// <summary>Quick set left and top adding default units</summary>
        /// <param name="left">The left CSS property value</param>
        /// <param name="top">The top CSS property value</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setLeftTop(System.String left, System.String top) { return null; }

        /// <summary>Move this element relative to its current position.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element move() { return null; }

        /// <summary>Move this element relative to its current position.</summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element move(System.String direction) { return null; }

        /// <summary>Move this element relative to its current position.</summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <param name="distance">How far to move the element in pixels</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element move(System.String direction, double distance) { return null; }

        /// <summary>Move this element relative to its current position.</summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <param name="distance">How far to move the element in pixels</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element move(System.String direction, double distance, bool animate) { return null; }

        /// <summary>Move this element relative to its current position.</summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <param name="distance">How far to move the element in pixels</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element move(System.String direction, double distance, object animate) { return null; }

        /// <summary>Store the current overflow setting and clip overflow on the element - use {@link #unclip} to remove</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element clip() { return null; }

        /// <summary>Return clipping (overflow) to original clipping before clip() was called</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element unclip() { return null; }

        /// <summary>
        ///     Gets the x,y coordinates specified by the anchor position on the element.
        ///     for details on supported anchor positions.
        ///     of page coordinates
        ///     {width: (target width), height: (target height)} (defaults to the element's current size)
        /// </summary>
        /// <returns>Array</returns>
        public virtual System.Array getAnchorXY() { return null; }

        /// <summary>
        ///     Gets the x,y coordinates specified by the anchor position on the element.
        ///     for details on supported anchor positions.
        ///     of page coordinates
        ///     {width: (target width), height: (target height)} (defaults to the element's current size)
        /// </summary>
        /// <param name="anchor">(optional) The specified anchor position (defaults to "c").  See {@link #alignTo}</param>
        /// <returns>Array</returns>
        public virtual System.Array getAnchorXY(System.String anchor) { return null; }

        /// <summary>
        ///     Gets the x,y coordinates specified by the anchor position on the element.
        ///     for details on supported anchor positions.
        ///     of page coordinates
        ///     {width: (target width), height: (target height)} (defaults to the element's current size)
        /// </summary>
        /// <param name="anchor">(optional) The specified anchor position (defaults to "c").  See {@link #alignTo}</param>
        /// <param name="local">(optional) True to get the local (element top/left-relative) anchor position instead</param>
        /// <returns>Array</returns>
        public virtual System.Array getAnchorXY(System.String anchor, bool local) { return null; }

        /// <summary>
        ///     Gets the x,y coordinates specified by the anchor position on the element.
        ///     for details on supported anchor positions.
        ///     of page coordinates
        ///     {width: (target width), height: (target height)} (defaults to the element's current size)
        /// </summary>
        /// <param name="anchor">(optional) The specified anchor position (defaults to "c").  See {@link #alignTo}</param>
        /// <param name="local">(optional) True to get the local (element top/left-relative) anchor position instead</param>
        /// <param name="size">(optional) An object containing the size to use for calculating anchor position</param>
        /// <returns>Array</returns>
        public virtual System.Array getAnchorXY(System.String anchor, bool local, object size) { return null; }

        /// <summary>
        ///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
        ///     supported position values.
        /// </summary>
        /// <returns>Array</returns>
        public virtual System.Array getAlignToXY() { return null; }

        /// <summary>
        ///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
        ///     supported position values.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <returns>Array</returns>
        public virtual System.Array getAlignToXY(object element) { return null; }

        /// <summary>
        ///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
        ///     supported position values.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <returns>Array</returns>
        public virtual System.Array getAlignToXY(object element, System.String position) { return null; }

        /// <summary>
        ///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
        ///     supported position values.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <returns>Array</returns>
        public virtual System.Array getAlignToXY(object element, System.String position, System.Array offsets) { return null; }

        /// <summary>
        ///     Aligns this element with another element relative to the specified anchor points. If the other element is the
        ///     document it aligns it to the viewport.
        ///     The position parameter is optional, and can be specified in any one of the following formats:
        ///     <ul>
        ///     <li><b>Blank</b>: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").</li>
        ///     <li><b>One anchor (deprecated)</b>: The passed anchor position is used as the target element's anchor point.
        ///     The element being aligned will position its top-left corner (tl) to that point.  <i>This method has been
        ///     deprecated in favor of the newer two anchor syntax below</i>.</li>
        ///     <li><b>Two anchors</b>: If two values from the table below are passed separated by a dash, the first value is used as the
        ///     element's anchor point, and the second value is used as the target's anchor point.</li>
        ///     </ul>
        ///     In addition to the anchor points, the position parameter also supports the "?" character.  If "?" is passed at the end of
        ///     the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to
        ///     the viewport if necessary.  Note that the element being aligned might be swapped to align to a different position than
        ///     that specified in order to enforce the viewport constraints.
        ///     Following are all of the supported anchor positions:
        ///     <pre>
        ///     Value  Description
        ///     -----  -----------------------------
        ///     tl     The top left corner (default)
        ///     t      The center of the top edge
        ///     tr     The top right corner
        ///     l      The center of the left edge
        ///     c      In the center of the element
        ///     r      The center of the right edge
        ///     bl     The bottom left corner
        ///     b      The center of the bottom edge
        ///     br     The bottom right corner
        ///     </pre>
        ///     Example Usage:
        ///     <pre><code>
        ///     // align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///     el.alignTo("other-el");
        ///     // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///     el.alignTo("other-el", "tr?");
        ///     // align the bottom right corner of el with the center left edge of other-el
        ///     el.alignTo("other-el", "br-l?");
        ///     // align the center of el with the bottom left corner of other-el and
        ///     // adjust the x position by -6 pixels (and the y position by 0)
        ///     el.alignTo("other-el", "c-bl", [-6, 0]);
        ///     </code></pre>
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element alignTo() { return null; }

        /// <summary>
        ///     Aligns this element with another element relative to the specified anchor points. If the other element is the
        ///     document it aligns it to the viewport.
        ///     The position parameter is optional, and can be specified in any one of the following formats:
        ///     <ul>
        ///     <li><b>Blank</b>: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").</li>
        ///     <li><b>One anchor (deprecated)</b>: The passed anchor position is used as the target element's anchor point.
        ///     The element being aligned will position its top-left corner (tl) to that point.  <i>This method has been
        ///     deprecated in favor of the newer two anchor syntax below</i>.</li>
        ///     <li><b>Two anchors</b>: If two values from the table below are passed separated by a dash, the first value is used as the
        ///     element's anchor point, and the second value is used as the target's anchor point.</li>
        ///     </ul>
        ///     In addition to the anchor points, the position parameter also supports the "?" character.  If "?" is passed at the end of
        ///     the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to
        ///     the viewport if necessary.  Note that the element being aligned might be swapped to align to a different position than
        ///     that specified in order to enforce the viewport constraints.
        ///     Following are all of the supported anchor positions:
        ///     <pre>
        ///     Value  Description
        ///     -----  -----------------------------
        ///     tl     The top left corner (default)
        ///     t      The center of the top edge
        ///     tr     The top right corner
        ///     l      The center of the left edge
        ///     c      In the center of the element
        ///     r      The center of the right edge
        ///     bl     The bottom left corner
        ///     b      The center of the bottom edge
        ///     br     The bottom right corner
        ///     </pre>
        ///     Example Usage:
        ///     <pre><code>
        ///     // align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///     el.alignTo("other-el");
        ///     // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///     el.alignTo("other-el", "tr?");
        ///     // align the bottom right corner of el with the center left edge of other-el
        ///     el.alignTo("other-el", "br-l?");
        ///     // align the center of el with the bottom left corner of other-el and
        ///     // adjust the x position by -6 pixels (and the y position by 0)
        ///     el.alignTo("other-el", "c-bl", [-6, 0]);
        ///     </code></pre>
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element alignTo(object element) { return null; }

        /// <summary>
        ///     Aligns this element with another element relative to the specified anchor points. If the other element is the
        ///     document it aligns it to the viewport.
        ///     The position parameter is optional, and can be specified in any one of the following formats:
        ///     <ul>
        ///     <li><b>Blank</b>: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").</li>
        ///     <li><b>One anchor (deprecated)</b>: The passed anchor position is used as the target element's anchor point.
        ///     The element being aligned will position its top-left corner (tl) to that point.  <i>This method has been
        ///     deprecated in favor of the newer two anchor syntax below</i>.</li>
        ///     <li><b>Two anchors</b>: If two values from the table below are passed separated by a dash, the first value is used as the
        ///     element's anchor point, and the second value is used as the target's anchor point.</li>
        ///     </ul>
        ///     In addition to the anchor points, the position parameter also supports the "?" character.  If "?" is passed at the end of
        ///     the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to
        ///     the viewport if necessary.  Note that the element being aligned might be swapped to align to a different position than
        ///     that specified in order to enforce the viewport constraints.
        ///     Following are all of the supported anchor positions:
        ///     <pre>
        ///     Value  Description
        ///     -----  -----------------------------
        ///     tl     The top left corner (default)
        ///     t      The center of the top edge
        ///     tr     The top right corner
        ///     l      The center of the left edge
        ///     c      In the center of the element
        ///     r      The center of the right edge
        ///     bl     The bottom left corner
        ///     b      The center of the bottom edge
        ///     br     The bottom right corner
        ///     </pre>
        ///     Example Usage:
        ///     <pre><code>
        ///     // align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///     el.alignTo("other-el");
        ///     // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///     el.alignTo("other-el", "tr?");
        ///     // align the bottom right corner of el with the center left edge of other-el
        ///     el.alignTo("other-el", "br-l?");
        ///     // align the center of el with the bottom left corner of other-el and
        ///     // adjust the x position by -6 pixels (and the y position by 0)
        ///     el.alignTo("other-el", "c-bl", [-6, 0]);
        ///     </code></pre>
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element alignTo(object element, System.String position) { return null; }

        /// <summary>
        ///     Aligns this element with another element relative to the specified anchor points. If the other element is the
        ///     document it aligns it to the viewport.
        ///     The position parameter is optional, and can be specified in any one of the following formats:
        ///     <ul>
        ///     <li><b>Blank</b>: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").</li>
        ///     <li><b>One anchor (deprecated)</b>: The passed anchor position is used as the target element's anchor point.
        ///     The element being aligned will position its top-left corner (tl) to that point.  <i>This method has been
        ///     deprecated in favor of the newer two anchor syntax below</i>.</li>
        ///     <li><b>Two anchors</b>: If two values from the table below are passed separated by a dash, the first value is used as the
        ///     element's anchor point, and the second value is used as the target's anchor point.</li>
        ///     </ul>
        ///     In addition to the anchor points, the position parameter also supports the "?" character.  If "?" is passed at the end of
        ///     the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to
        ///     the viewport if necessary.  Note that the element being aligned might be swapped to align to a different position than
        ///     that specified in order to enforce the viewport constraints.
        ///     Following are all of the supported anchor positions:
        ///     <pre>
        ///     Value  Description
        ///     -----  -----------------------------
        ///     tl     The top left corner (default)
        ///     t      The center of the top edge
        ///     tr     The top right corner
        ///     l      The center of the left edge
        ///     c      In the center of the element
        ///     r      The center of the right edge
        ///     bl     The bottom left corner
        ///     b      The center of the bottom edge
        ///     br     The bottom right corner
        ///     </pre>
        ///     Example Usage:
        ///     <pre><code>
        ///     // align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///     el.alignTo("other-el");
        ///     // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///     el.alignTo("other-el", "tr?");
        ///     // align the bottom right corner of el with the center left edge of other-el
        ///     el.alignTo("other-el", "br-l?");
        ///     // align the center of el with the bottom left corner of other-el and
        ///     // adjust the x position by -6 pixels (and the y position by 0)
        ///     el.alignTo("other-el", "c-bl", [-6, 0]);
        ///     </code></pre>
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element alignTo(object element, System.String position, System.Array offsets) { return null; }

        /// <summary>
        ///     Aligns this element with another element relative to the specified anchor points. If the other element is the
        ///     document it aligns it to the viewport.
        ///     The position parameter is optional, and can be specified in any one of the following formats:
        ///     <ul>
        ///     <li><b>Blank</b>: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").</li>
        ///     <li><b>One anchor (deprecated)</b>: The passed anchor position is used as the target element's anchor point.
        ///     The element being aligned will position its top-left corner (tl) to that point.  <i>This method has been
        ///     deprecated in favor of the newer two anchor syntax below</i>.</li>
        ///     <li><b>Two anchors</b>: If two values from the table below are passed separated by a dash, the first value is used as the
        ///     element's anchor point, and the second value is used as the target's anchor point.</li>
        ///     </ul>
        ///     In addition to the anchor points, the position parameter also supports the "?" character.  If "?" is passed at the end of
        ///     the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to
        ///     the viewport if necessary.  Note that the element being aligned might be swapped to align to a different position than
        ///     that specified in order to enforce the viewport constraints.
        ///     Following are all of the supported anchor positions:
        ///     <pre>
        ///     Value  Description
        ///     -----  -----------------------------
        ///     tl     The top left corner (default)
        ///     t      The center of the top edge
        ///     tr     The top right corner
        ///     l      The center of the left edge
        ///     c      In the center of the element
        ///     r      The center of the right edge
        ///     bl     The bottom left corner
        ///     b      The center of the bottom edge
        ///     br     The bottom right corner
        ///     </pre>
        ///     Example Usage:
        ///     <pre><code>
        ///     // align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///     el.alignTo("other-el");
        ///     // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///     el.alignTo("other-el", "tr?");
        ///     // align the bottom right corner of el with the center left edge of other-el
        ///     el.alignTo("other-el", "br-l?");
        ///     // align the center of el with the bottom left corner of other-el and
        ///     // adjust the x position by -6 pixels (and the y position by 0)
        ///     el.alignTo("other-el", "c-bl", [-6, 0]);
        ///     </code></pre>
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element alignTo(object element, System.String position, System.Array offsets, bool animate) { return null; }

        /// <summary>
        ///     Aligns this element with another element relative to the specified anchor points. If the other element is the
        ///     document it aligns it to the viewport.
        ///     The position parameter is optional, and can be specified in any one of the following formats:
        ///     <ul>
        ///     <li><b>Blank</b>: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").</li>
        ///     <li><b>One anchor (deprecated)</b>: The passed anchor position is used as the target element's anchor point.
        ///     The element being aligned will position its top-left corner (tl) to that point.  <i>This method has been
        ///     deprecated in favor of the newer two anchor syntax below</i>.</li>
        ///     <li><b>Two anchors</b>: If two values from the table below are passed separated by a dash, the first value is used as the
        ///     element's anchor point, and the second value is used as the target's anchor point.</li>
        ///     </ul>
        ///     In addition to the anchor points, the position parameter also supports the "?" character.  If "?" is passed at the end of
        ///     the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to
        ///     the viewport if necessary.  Note that the element being aligned might be swapped to align to a different position than
        ///     that specified in order to enforce the viewport constraints.
        ///     Following are all of the supported anchor positions:
        ///     <pre>
        ///     Value  Description
        ///     -----  -----------------------------
        ///     tl     The top left corner (default)
        ///     t      The center of the top edge
        ///     tr     The top right corner
        ///     l      The center of the left edge
        ///     c      In the center of the element
        ///     r      The center of the right edge
        ///     bl     The bottom left corner
        ///     b      The center of the bottom edge
        ///     br     The bottom right corner
        ///     </pre>
        ///     Example Usage:
        ///     <pre><code>
        ///     // align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///     el.alignTo("other-el");
        ///     // align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///     el.alignTo("other-el", "tr?");
        ///     // align the bottom right corner of el with the center left edge of other-el
        ///     el.alignTo("other-el", "br-l?");
        ///     // align the center of el with the bottom left corner of other-el and
        ///     // adjust the x position by -6 pixels (and the y position by 0)
        ///     el.alignTo("other-el", "c-bl", [-6, 0]);
        ///     </code></pre>
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element alignTo(object element, System.String position, System.Array offsets, object animate) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo() { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, bool animate) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, bool animate, bool monitorScroll) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, bool animate, bool monitorScroll, Delegate callback) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, object animate) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, object animate, bool monitorScroll) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, object animate, bool monitorScroll, Delegate callback) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, bool animate, double monitorScroll) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, bool animate, double monitorScroll, Delegate callback) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, object animate, double monitorScroll) { return null; }

        /// <summary>
        ///     Anchors an element to another element and realigns it when the window is resized.
        ///     is a number, it is used as the buffer delay (defaults to 50ms).
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
        /// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
        /// <param name="monitorScroll">(optional) True to monitor body scroll and reposition. If this parameter</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element anchorTo(object element, System.String position, System.Array offsets, object animate, double monitorScroll, Delegate callback) { return null; }

        /// <summary>Clears any opacity settings from this element. Required in some cases for IE.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element clearOpacity() { return null; }

        /// <summary>Hide this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hide() { return null; }

        /// <summary>Hide this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hide(bool animate) { return null; }

        /// <summary>Hide this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hide(object animate) { return null; }

        /// <summary>Show this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element show() { return null; }

        /// <summary>Show this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element show(bool animate) { return null; }

        /// <summary>Show this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element show(object animate) { return null; }

        /// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element update() { return null; }

        /// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
        /// <param name="html">The new HTML</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element update(System.String html) { return null; }

        /// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
        /// <param name="html">The new HTML</param>
        /// <param name="loadScripts">(optional) True to look for and process scripts (defaults to false)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element update(System.String html, bool loadScripts) { return null; }

        /// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
        /// <param name="html">The new HTML</param>
        /// <param name="loadScripts">(optional) True to look for and process scripts (defaults to false)</param>
        /// <param name="callback">(optional) For async script loading you can be notified when the update completes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element update(System.String html, bool loadScripts, Delegate callback) { return null; }

        /// <summary>
        ///     Direct access to the Updater {@link Ext.Updater#update} method. The method takes the same object
        ///     parameter as {@link Ext.Updater#update}
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element load() { return null; }

        /// <summary>Gets this element's Updater</summary>
        /// <returns>Ext.Updater</returns>
        public virtual Ext.UpdaterClass getUpdater() { return null; }

        /// <summary>Disables text selection for this element (normalized across browsers)</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element unselectable() { return null; }

        /// <summary>Calculates the x, y to center this element on the screen</summary>
        /// <returns>Array</returns>
        public virtual System.Array getCenterXY() { return null; }

        /// <summary>Centers the Element in either the viewport, or another Element.</summary>
        /// <returns></returns>
        public virtual void center() { return ; }

        /// <summary>Centers the Element in either the viewport, or another Element.</summary>
        /// <param name="centerIn">(optional) The element in which to center the element.</param>
        /// <returns></returns>
        public virtual void center(object centerIn) { return ; }

        /// <summary>Tests various css rules/browsers to determine if this element uses a border box</summary>
        /// <returns>Boolean</returns>
        public virtual bool isBorderBox() { return false; }

        /// <summary>
        ///     Return a box {x, y, width, height} that can be used to set another elements
        ///     size/location to match this element.
        /// </summary>
        /// <returns>Object</returns>
        public virtual object getBox() { return null; }

        /// <summary>
        ///     Return a box {x, y, width, height} that can be used to set another elements
        ///     size/location to match this element.
        /// </summary>
        /// <param name="contentBox">(optional) If true a box for the content of the element is returned.</param>
        /// <returns>Object</returns>
        public virtual object getBox(bool contentBox) { return null; }

        /// <summary>
        ///     Return a box {x, y, width, height} that can be used to set another elements
        ///     size/location to match this element.
        /// </summary>
        /// <param name="contentBox">(optional) If true a box for the content of the element is returned.</param>
        /// <param name="local">(optional) If true the element's left and top are returned instead of page x/y.</param>
        /// <returns>Object</returns>
        public virtual object getBox(bool contentBox, bool local) { return null; }

        /// <summary>
        ///     Returns the sum width of the padding and borders for the passed "sides". See getBorderWidth()
        ///     for more information about the sides.
        /// </summary>
        /// <returns>Number</returns>
        public virtual double getFrameWidth() { return 0; }

        /// <summary>
        ///     Returns the sum width of the padding and borders for the passed "sides". See getBorderWidth()
        ///     for more information about the sides.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns>Number</returns>
        public virtual double getFrameWidth(System.String sides) { return 0; }

        /// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBox() { return null; }

        /// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBox(object box) { return null; }

        /// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <param name="adjust">(optional) Whether to adjust for box-model issues automatically</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBox(object box, bool adjust) { return null; }

        /// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <param name="adjust">(optional) Whether to adjust for box-model issues automatically</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBox(object box, bool adjust, bool animate) { return null; }

        /// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <param name="adjust">(optional) Whether to adjust for box-model issues automatically</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element setBox(object box, bool adjust, object animate) { return null; }

        /// <summary>Forces the browser to repaint this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element repaint() { return null; }

        /// <summary>
        ///     Returns an object with properties top, left, right and bottom representing the margins of this element unless sides is passed,
        ///     then it returns the calculated width of the sides (see getPadding)
        /// </summary>
        /// <returns>Object/Number</returns>
        public virtual object getMargins() { return null; }

        /// <summary>
        ///     Returns an object with properties top, left, right and bottom representing the margins of this element unless sides is passed,
        ///     then it returns the calculated width of the sides (see getPadding)
        /// </summary>
        /// <param name="sides">(optional) Any combination of l, r, t, b to get the sum of those sides</param>
        /// <returns>Object/Number</returns>
        public virtual object getMargins(System.String sides) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy() { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(System.String config) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(System.String config, System.String renderTo) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(System.String config, System.String renderTo, bool matchBox) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(object config) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(object config, System.String renderTo) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(object config, System.String renderTo, bool matchBox) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(System.String config, DOMElement renderTo) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(System.String config, DOMElement renderTo, bool matchBox) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(object config, DOMElement renderTo) { return null; }

        /// <summary>Creates a proxy element of this element</summary>
        /// <param name="config">The class name of the proxy element or a DomHelper config object</param>
        /// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createProxy(object config, DOMElement renderTo, bool matchBox) { return null; }

        /// <summary>
        ///     Puts a mask over this element to disable user interaction. Requires core.css.
        ///     This method can only be applied to elements which accept child nodes.
        /// </summary>
        /// <returns>Element</returns>
        public virtual Element mask() { return null; }

        /// <summary>
        ///     Puts a mask over this element to disable user interaction. Requires core.css.
        ///     This method can only be applied to elements which accept child nodes.
        /// </summary>
        /// <param name="msg">(optional) A message to display in the mask</param>
        /// <returns>Element</returns>
        public virtual Element mask(System.String msg) { return null; }

        /// <summary>
        ///     Puts a mask over this element to disable user interaction. Requires core.css.
        ///     This method can only be applied to elements which accept child nodes.
        /// </summary>
        /// <param name="msg">(optional) A message to display in the mask</param>
        /// <param name="msgCls">(optional) A css class to apply to the msg element</param>
        /// <returns>Element</returns>
        public virtual Element mask(System.String msg, System.String msgCls) { return null; }

        /// <summary>Removes a previously applied mask.</summary>
        /// <returns></returns>
        public virtual void unmask() { return ; }

        /// <summary>Returns true if this element is masked</summary>
        /// <returns>Boolean</returns>
        public virtual bool isMasked() { return false; }

        /// <summary>
        ///     Creates an iframe shim for this element to keep selects and other windowed objects from
        ///     showing through.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createShim() { return null; }

        /// <summary>Removes this element from the DOM and deletes it from the cache</summary>
        /// <returns></returns>
        public virtual void remove() { return ; }

        /// <summary>
        ///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
        ///     filters child element mouse events.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hover() { return null; }

        /// <summary>
        ///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
        ///     filters child element mouse events.
        /// </summary>
        /// <param name="overFn"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hover(Delegate overFn) { return null; }

        /// <summary>
        ///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
        ///     filters child element mouse events.
        /// </summary>
        /// <param name="overFn"></param>
        /// <param name="outFn"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hover(Delegate overFn, Delegate outFn) { return null; }

        /// <summary>
        ///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
        ///     filters child element mouse events.
        /// </summary>
        /// <param name="overFn"></param>
        /// <param name="outFn"></param>
        /// <param name="scope">(optional)</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element hover(Delegate overFn, Delegate outFn, object scope) { return null; }

        /// <summary>Sets up event handlers to add and remove a css class when the mouse is over this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClassOnOver() { return null; }

        /// <summary>Sets up event handlers to add and remove a css class when the mouse is over this element</summary>
        /// <param name="className"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClassOnOver(System.String className) { return null; }

        /// <summary>Sets up event handlers to add and remove a css class when this element has the focus</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClassOnFocus() { return null; }

        /// <summary>Sets up event handlers to add and remove a css class when this element has the focus</summary>
        /// <param name="className"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClassOnFocus(System.String className) { return null; }

        /// <summary>Sets up event handlers to add and remove a css class when the mouse is down and then up on this element (a click effect)</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClassOnClick() { return null; }

        /// <summary>Sets up event handlers to add and remove a css class when the mouse is down and then up on this element (a click effect)</summary>
        /// <param name="className"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element addClassOnClick(System.String className) { return null; }

        /// <summary>Stops the specified event from bubbling and optionally prevents the default action</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element swallowEvent() { return null; }

        /// <summary>Stops the specified event from bubbling and optionally prevents the default action</summary>
        /// <param name="eventName"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element swallowEvent(System.String eventName) { return null; }

        /// <summary>Stops the specified event from bubbling and optionally prevents the default action</summary>
        /// <param name="eventName"></param>
        /// <param name="preventDefault">(optional) true to prevent the default action too</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element swallowEvent(System.String eventName, bool preventDefault) { return null; }

        /// <summary>Gets the parent node for this element, optionally chaining up trying to match a selector</summary>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object parent() { return null; }

        /// <summary>Gets the parent node for this element, optionally chaining up trying to match a selector</summary>
        /// <param name="selector">(optional) Find a parent node that matches the passed simple selector</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object parent(System.String selector) { return null; }

        /// <summary>Gets the parent node for this element, optionally chaining up trying to match a selector</summary>
        /// <param name="selector">(optional) Find a parent node that matches the passed simple selector</param>
        /// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object parent(System.String selector, bool returnDom) { return null; }

        /// <summary>Gets the next sibling, skipping text nodes</summary>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object next() { return null; }

        /// <summary>Gets the next sibling, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object next(System.String selector) { return null; }

        /// <summary>Gets the next sibling, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
        /// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object next(System.String selector, bool returnDom) { return null; }

        /// <summary>Gets the previous sibling, skipping text nodes</summary>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object prev() { return null; }

        /// <summary>Gets the previous sibling, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object prev(System.String selector) { return null; }

        /// <summary>Gets the previous sibling, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
        /// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object prev(System.String selector, bool returnDom) { return null; }

        /// <summary>Gets the first child, skipping text nodes</summary>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object first() { return null; }

        /// <summary>Gets the first child, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object first(System.String selector) { return null; }

        /// <summary>Gets the first child, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
        /// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object first(System.String selector, bool returnDom) { return null; }

        /// <summary>Gets the last child, skipping text nodes</summary>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object last() { return null; }

        /// <summary>Gets the last child, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object last(System.String selector) { return null; }

        /// <summary>Gets the last child, skipping text nodes</summary>
        /// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
        /// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
        /// <returns>Ext.Element/HTMLElement</returns>
        public virtual object last(System.String selector, bool returnDom) { return null; }

        /// <summary>Appends the passed element(s) to this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendChild() { return null; }

        /// <summary>Appends the passed element(s) to this element</summary>
        /// <param name="el"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendChild(System.String el) { return null; }

        /// <summary>Appends the passed element(s) to this element</summary>
        /// <param name="el"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendChild(DOMElement el) { return null; }

        /// <summary>Appends the passed element(s) to this element</summary>
        /// <param name="el"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendChild(System.Array el) { return null; }

        /// <summary>Appends the passed element(s) to this element</summary>
        /// <param name="el"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendChild(Element el) { return null; }

        /// <summary>Appends the passed element(s) to this element</summary>
        /// <param name="el"></param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendChild(CompositeElement el) { return null; }

        /// <summary>
        ///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
        ///     automatically generated with the specified attributes.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createChild() { return null; }

        /// <summary>
        ///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
        ///     automatically generated with the specified attributes.
        /// </summary>
        /// <param name="config">DomHelper element config object.  If no tag is specified (e.g., {tag:'input'}) then a div will be</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createChild(object config) { return null; }

        /// <summary>
        ///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
        ///     automatically generated with the specified attributes.
        /// </summary>
        /// <param name="config">DomHelper element config object.  If no tag is specified (e.g., {tag:'input'}) then a div will be</param>
        /// <param name="insertBefore">(optional) a child element of this element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createChild(object config, DOMElement insertBefore) { return null; }

        /// <summary>
        ///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
        ///     automatically generated with the specified attributes.
        /// </summary>
        /// <param name="config">DomHelper element config object.  If no tag is specified (e.g., {tag:'input'}) then a div will be</param>
        /// <param name="insertBefore">(optional) a child element of this element</param>
        /// <param name="returnDom">(optional) true to return the dom node instead of creating an Element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element createChild(object config, DOMElement insertBefore, bool returnDom) { return null; }

        /// <summary>Appends this element to the passed element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendTo() { return null; }

        /// <summary>Appends this element to the passed element</summary>
        /// <param name="el">The new parent element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element appendTo(object el) { return null; }

        /// <summary>Inserts this element before the passed element in the DOM</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertBefore() { return null; }

        /// <summary>Inserts this element before the passed element in the DOM</summary>
        /// <param name="el">The element before which this element will be inserted</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertBefore(object el) { return null; }

        /// <summary>Inserts this element after the passed element in the DOM</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertAfter() { return null; }

        /// <summary>Inserts this element after the passed element in the DOM</summary>
        /// <param name="el">The element to insert after</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertAfter(object el) { return null; }

        /// <summary>Inserts (or creates) an element (or DomHelper config) as the first child of this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertFirst() { return null; }

        /// <summary>Inserts (or creates) an element (or DomHelper config) as the first child of this element</summary>
        /// <param name="el">The id or element to insert or a DomHelper config to create and insert</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertFirst(object el) { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling() { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling(object el) { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
        /// <param name="where">(optional) 'before' or 'after' defaults to before</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling(object el, System.String where) { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
        /// <param name="where">(optional) 'before' or 'after' defaults to before</param>
        /// <param name="returnDom">(optional) True to return the raw DOM element instead of Ext.Element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling(object el, System.String where, bool returnDom) { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling(System.Array el) { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
        /// <param name="where">(optional) 'before' or 'after' defaults to before</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling(System.Array el, System.String where) { return null; }

        /// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
        /// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
        /// <param name="where">(optional) 'before' or 'after' defaults to before</param>
        /// <param name="returnDom">(optional) True to return the raw DOM element instead of Ext.Element</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element insertSibling(System.Array el, System.String where, bool returnDom) { return null; }

        /// <summary>Creates and wraps this element with another element</summary>
        /// <returns>HTMLElement/Element</returns>
        public virtual object wrap() { return null; }

        /// <summary>Creates and wraps this element with another element</summary>
        /// <param name="config">(optional) DomHelper element config object for the wrapper element or null for an empty div</param>
        /// <returns>HTMLElement/Element</returns>
        public virtual object wrap(object config) { return null; }

        /// <summary>Creates and wraps this element with another element</summary>
        /// <param name="config">(optional) DomHelper element config object for the wrapper element or null for an empty div</param>
        /// <param name="returnDom">(optional) True to return the raw DOM element instead of Ext.Element</param>
        /// <returns>HTMLElement/Element</returns>
        public virtual object wrap(object config, bool returnDom) { return null; }

        /// <summary>Replaces the passed element with this element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replace() { return null; }

        /// <summary>Replaces the passed element with this element</summary>
        /// <param name="el">The element to replace</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replace(object el) { return null; }

        /// <summary>Replaces this element with the passed element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replaceWith() { return null; }

        /// <summary>Replaces this element with the passed element</summary>
        /// <param name="el">The new element or a DomHelper config of an element to create</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element replaceWith(object el) { return null; }

        /// <summary>Inserts an html fragment into this element</summary>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertHtml() { return null; }

        /// <summary>Inserts an html fragment into this element</summary>
        /// <param name="where">Where to insert the html in relation to this element - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertHtml(System.String where) { return null; }

        /// <summary>Inserts an html fragment into this element</summary>
        /// <param name="where">Where to insert the html in relation to this element - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
        /// <param name="html">The HTML fragment</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertHtml(System.String where, System.String html) { return null; }

        /// <summary>Inserts an html fragment into this element</summary>
        /// <param name="where">Where to insert the html in relation to this element - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
        /// <param name="html">The HTML fragment</param>
        /// <param name="returnEl">(optional) True to return an Ext.Element (defaults to false)</param>
        /// <returns>HTMLElement/Ext.Element</returns>
        public virtual object insertHtml(System.String where, System.String html, bool returnEl) { return null; }

        /// <summary>Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element set() { return null; }

        /// <summary>Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)</summary>
        /// <param name="o">The object with the attributes</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element set(object o) { return null; }

        /// <summary>Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)</summary>
        /// <param name="o">The object with the attributes</param>
        /// <param name="useSet">(optional) false to override the default setAttribute to use expandos.</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element set(object o, bool useSet) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener() { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(double key) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(double key, Delegate fn) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">(optional) The scope of the function</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(double key, Delegate fn, object scope) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(System.Array key) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(System.Array key, Delegate fn) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">(optional) The scope of the function</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(System.Array key, Delegate fn, object scope) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(object key) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(object key, Delegate fn) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">(optional) The scope of the function</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(object key, Delegate fn, object scope) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(System.String key) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(System.String key, Delegate fn) { return null; }

        /// <summary>
        ///     Convenience method for constructing a KeyMap
        ///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
        /// </summary>
        /// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">(optional) The scope of the function</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyListener(System.String key, Delegate fn, object scope) { return null; }

        /// <summary>Creates a KeyMap for this element</summary>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyMap() { return null; }

        /// <summary>Creates a KeyMap for this element</summary>
        /// <param name="config">The KeyMap config. See {@link Ext.KeyMap} for more details</param>
        /// <returns>Ext.KeyMap</returns>
        public virtual Ext.KeyMap addKeyMap(object config) { return null; }

        /// <summary>Returns true if this element is scrollable.</summary>
        /// <returns>Boolean</returns>
        public virtual bool isScrollable() { return false; }

        /// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
        /// <returns>Element</returns>
        public virtual Element scrollTo() { return null; }

        /// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
        /// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
        /// <returns>Element</returns>
        public virtual Element scrollTo(System.String side) { return null; }

        /// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
        /// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
        /// <param name="value">The new scroll value</param>
        /// <returns>Element</returns>
        public virtual Element scrollTo(System.String side, double value) { return null; }

        /// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
        /// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
        /// <param name="value">The new scroll value</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Element</returns>
        public virtual Element scrollTo(System.String side, double value, bool animate) { return null; }

        /// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
        /// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
        /// <param name="value">The new scroll value</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Element</returns>
        public virtual Element scrollTo(System.String side, double value, object animate) { return null; }

        /// <summary>
        ///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
        ///     within this element's scrollable range.
        ///     was scrolled as far as it could go.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool scroll() { return false; }

        /// <summary>
        ///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
        ///     within this element's scrollable range.
        ///     was scrolled as far as it could go.
        /// </summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <returns>Boolean</returns>
        public virtual bool scroll(System.String direction) { return false; }

        /// <summary>
        ///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
        ///     within this element's scrollable range.
        ///     was scrolled as far as it could go.
        /// </summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <param name="distance">How far to scroll the element in pixels</param>
        /// <returns>Boolean</returns>
        public virtual bool scroll(System.String direction, double distance) { return false; }

        /// <summary>
        ///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
        ///     within this element's scrollable range.
        ///     was scrolled as far as it could go.
        /// </summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <param name="distance">How far to scroll the element in pixels</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Boolean</returns>
        public virtual bool scroll(System.String direction, double distance, bool animate) { return false; }

        /// <summary>
        ///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
        ///     within this element's scrollable range.
        ///     was scrolled as far as it could go.
        /// </summary>
        /// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
        /// <param name="distance">How far to scroll the element in pixels</param>
        /// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
        /// <returns>Boolean</returns>
        public virtual bool scroll(System.String direction, double distance, object animate) { return false; }

        /// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
        /// <returns>Object</returns>
        public virtual object translatePoints() { return null; }

        /// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
        /// <param name="x">The page x or an array containing [x, y]</param>
        /// <returns>Object</returns>
        public virtual object translatePoints(double x) { return null; }

        /// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
        /// <param name="x">The page x or an array containing [x, y]</param>
        /// <param name="y">(optional) The page y, required if x is not an array</param>
        /// <returns>Object</returns>
        public virtual object translatePoints(double x, double y) { return null; }

        /// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
        /// <param name="x">The page x or an array containing [x, y]</param>
        /// <returns>Object</returns>
        public virtual object translatePoints(System.Array x) { return null; }

        /// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
        /// <param name="x">The page x or an array containing [x, y]</param>
        /// <param name="y">(optional) The page y, required if x is not an array</param>
        /// <returns>Object</returns>
        public virtual object translatePoints(System.Array x, double y) { return null; }

        /// <summary>Returns the current scroll position of the element.</summary>
        /// <returns>Object</returns>
        public virtual object getScroll() { return null; }

        /// <summary>
        ///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
        ///     are convert to standard 6 digit hex color.
        ///     color anims.
        /// </summary>
        /// <returns></returns>
        public virtual void getColor() { return ; }

        /// <summary>
        ///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
        ///     are convert to standard 6 digit hex color.
        ///     color anims.
        /// </summary>
        /// <param name="attr">The css attribute</param>
        /// <returns></returns>
        public virtual void getColor(System.String attr) { return ; }

        /// <summary>
        ///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
        ///     are convert to standard 6 digit hex color.
        ///     color anims.
        /// </summary>
        /// <param name="attr">The css attribute</param>
        /// <param name="defaultValue">The default value to use when a valid color isn't found</param>
        /// <returns></returns>
        public virtual void getColor(System.String attr, System.String defaultValue) { return ; }

        /// <summary>
        ///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
        ///     are convert to standard 6 digit hex color.
        ///     color anims.
        /// </summary>
        /// <param name="attr">The css attribute</param>
        /// <param name="defaultValue">The default value to use when a valid color isn't found</param>
        /// <param name="prefix">(optional) defaults to #. Use an empty string when working with</param>
        /// <returns></returns>
        public virtual void getColor(System.String attr, System.String defaultValue, System.String prefix) { return ; }

        /// <summary>
        ///     Wraps the specified element with a special markup/CSS block that renders by default as a gray container with a
        ///     gradient background, rounded corners and a 4-way shadow.  Example usage:
        ///     <pre><code>
        ///     // Basic box wrap
        ///     Ext.get("foo").boxWrap();
        ///     // You can also add a custom class and use CSS inheritance rules to customize the box look.
        ///     // 'x-box-blue' is a built-in alternative -- look at the related CSS definitions as an example
        ///     // for how to create a custom box wrap style.
        ///     Ext.get("foo").boxWrap().addClass("x-box-blue");
        ///     </pre></code>
        ///     Note that there are a number of CSS rules that are dependent on this name to make the overall effect work,
        ///     so if you supply an alternate base class, make sure you also supply all of the necessary rules.
        /// </summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element boxWrap() { return null; }

        /// <summary>
        ///     Wraps the specified element with a special markup/CSS block that renders by default as a gray container with a
        ///     gradient background, rounded corners and a 4-way shadow.  Example usage:
        ///     <pre><code>
        ///     // Basic box wrap
        ///     Ext.get("foo").boxWrap();
        ///     // You can also add a custom class and use CSS inheritance rules to customize the box look.
        ///     // 'x-box-blue' is a built-in alternative -- look at the related CSS definitions as an example
        ///     // for how to create a custom box wrap style.
        ///     Ext.get("foo").boxWrap().addClass("x-box-blue");
        ///     </pre></code>
        ///     Note that there are a number of CSS rules that are dependent on this name to make the overall effect work,
        ///     so if you supply an alternate base class, make sure you also supply all of the necessary rules.
        /// </summary>
        /// <param name="cls">(optional) A base CSS class to apply to the containing wrapper element (defaults to 'x-box').</param>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element boxWrap(System.String cls) { return null; }

        /// <summary>Returns the value of a namespaced attribute from the element's underlying DOM node.</summary>
        /// <returns>String</returns>
        public virtual System.String getAttributeNS() { return null; }

        /// <summary>Returns the value of a namespaced attribute from the element's underlying DOM node.</summary>
        /// <param name="ns">The namespace in which to look for the attribute</param>
        /// <returns>String</returns>
        public virtual System.String getAttributeNS(System.String ns) { return null; }

        /// <summary>Returns the value of a namespaced attribute from the element's underlying DOM node.</summary>
        /// <param name="ns">The namespace in which to look for the attribute</param>
        /// <param name="name">The attribute name</param>
        /// <returns>String</returns>
        public virtual System.String getAttributeNS(System.String ns, System.String name) { return null; }

        /// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
        /// <returns>Number</returns>
        public virtual double getTextWidth() { return 0; }

        /// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
        /// <param name="text">The text to measure. Defaults to the innerHTML of the element.</param>
        /// <returns>Number</returns>
        public virtual double getTextWidth(System.String text) { return 0; }

        /// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
        /// <param name="text">The text to measure. Defaults to the innerHTML of the element.</param>
        /// <param name="min">(Optional) The minumum value to return.</param>
        /// <returns>Number</returns>
        public virtual double getTextWidth(System.String text, double min) { return 0; }

        /// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
        /// <param name="text">The text to measure. Defaults to the innerHTML of the element.</param>
        /// <param name="min">(Optional) The minumum value to return.</param>
        /// <param name="max">(Optional) The maximum value to return.</param>
        /// <returns>Number</returns>
        public virtual double getTextWidth(System.String text, double min, double max) { return 0; }

        /// <summary>
        ///     Static method to retrieve Ext.Element objects.
        ///     <p><b>This method does not retrieve {@link Ext.Component Component}s.</b> This method
        ///     retrieves Ext.Element objects which encapsulate DOM elements. To retrieve a Component by
        ///     its ID, use {@link Ext.ComponentMgr#get}.</p>
        ///     <p>Uses simple caching to consistently return the same object.
        ///     Automatically fixes if an object was recreated with the same id via AJAX or DOM.</p>
        /// </summary>
        /// <returns>Element</returns>
        public static Element get() { return null; }

        /// <summary>
        ///     Static method to retrieve Ext.Element objects.
        ///     <p><b>This method does not retrieve {@link Ext.Component Component}s.</b> This method
        ///     retrieves Ext.Element objects which encapsulate DOM elements. To retrieve a Component by
        ///     its ID, use {@link Ext.ComponentMgr#get}.</p>
        ///     <p>Uses simple caching to consistently return the same object.
        ///     Automatically fixes if an object was recreated with the same id via AJAX or DOM.</p>
        /// </summary>
        /// <param name="el">The id of the node, a DOM Node or an existing Element.</param>
        /// <returns>Element</returns>
        public static Element get(object el) { return null; }

        /// <summary>
        ///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
        ///     the dom node can be overwritten by other code.
        ///     prevent conflicts (e.g. internally Ext uses "_internal")
        /// </summary>
        /// <returns>Element</returns>
        public static Element fly() { return null; }

        /// <summary>
        ///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
        ///     the dom node can be overwritten by other code.
        ///     prevent conflicts (e.g. internally Ext uses "_internal")
        /// </summary>
        /// <param name="el">The dom node or id</param>
        /// <returns>Element</returns>
        public static Element fly(System.String el) { return null; }

        /// <summary>
        ///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
        ///     the dom node can be overwritten by other code.
        ///     prevent conflicts (e.g. internally Ext uses "_internal")
        /// </summary>
        /// <param name="el">The dom node or id</param>
        /// <param name="named">(optional) Allows for creation of named reusable flyweights to</param>
        /// <returns>Element</returns>
        public static Element fly(System.String el, System.String named) { return null; }

        /// <summary>
        ///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
        ///     the dom node can be overwritten by other code.
        ///     prevent conflicts (e.g. internally Ext uses "_internal")
        /// </summary>
        /// <param name="el">The dom node or id</param>
        /// <returns>Element</returns>
        public static Element fly(DOMElement el) { return null; }

        /// <summary>
        ///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
        ///     the dom node can be overwritten by other code.
        ///     prevent conflicts (e.g. internally Ext uses "_internal")
        /// </summary>
        /// <param name="el">The dom node or id</param>
        /// <param name="named">(optional) Allows for creation of named reusable flyweights to</param>
        /// <returns>Element</returns>
        public static Element fly(DOMElement el, System.String named) { return null; }


		/*
		 * The methods below are applied by the Fx class
		 */

        /// <summary></summary>
        /// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to top: 't')</param>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element slideIn(string anchor, object options) { return null;}

        /// <summary></summary>
        /// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to top: 't')</param>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element slideOut(string anchor, object options) { return null;}

        /// <summary></summary>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element puff(object options) { return null;}

        /// <summary></summary>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element switchOff(object options) { return null;}

        /// <summary></summary>
        /// <param name="color">(optional) The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')</param>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element highlight(string color, object options) { return null;}

        /// <summary></summary>
        /// <param name="color">(optional) The color of the border.  Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
        /// <param name="count">(optional) The number of ripples to display (defaults to 1)</param>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element frame(string color, int count, object options) { return null;}

        /// <summary></summary>
        /// <param name="seconds">The length of time to pause (in seconds)</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element pause(int seconds) { return null;}

        /// <summary></summary>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element fadeIn(object options) { return null;}

        /// <summary></summary>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element fadeOut(object options) { return null;}

        /// <summary></summary>
        /// <param name="width">The new width (pass undefined to keep the original width)</param>
        /// <param name="height">The new height (pass undefined to keep the original height)</param>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element scale(int width, int height, object options) { return null;}

        /// <summary></summary>
        /// <param name="options">Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element shift(object options) { return null;}

        /// <summary></summary>
        /// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to bottom: 'b')</param>
        /// <param name="options">(optional) Object literal with any of the Fx config options</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element ghost(string anchor, object options) { return null;}

        /// <summary></summary>
        /// <returns>Ext.Element</returns>
        public Ext.Element syncFx() { return null;}

        /// <summary></summary>
        /// <returns>Ext.Element</returns>
        public Ext.Element sequenceFx() { return null;}

        /// <summary></summary>
        /// <returns>Boolean</returns>
        public bool hasActiveFx() { return false;}

        /// <summary></summary>
        /// <returns>Ext.Element</returns>
        public Ext.Element stopFx() { return null;}

        /// <summary></summary>
        /// <returns>Boolean</returns>
        public bool hasFxBlock() { return false;}


        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <returns></returns>
        public void on() { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <returns></returns>
        public void on(System.String eventName) { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes</param>
        /// <returns></returns>
        public void on(System.String eventName, Delegate fn) { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes</param>
        /// <param name="scope">(optional) The scope (this element) of the handler function</param>
        /// <returns></returns>
        public void on(System.String eventName, Delegate fn, object scope) { return ; }

        /// <summary>
        ///     Appends an event handler to this element.  The shorthand version {@link #on} is equivalent.
        ///     This may contain any of the following properties:<ul>
        ///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
        ///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
        ///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
        ///     <li>preventDefault {Boolean} : True to prevent the default action</li>
        ///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
        ///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
        ///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
        ///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
        ///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
        ///     by the specified number of milliseconds. If the event fires again within that time, the original
        ///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
        ///     </ul><br>
        ///     <p>
        ///     <b>Combining Options</b><br>
        ///     In the following examples, the shorthand form {@link #on} is used rather than the more verbose
        ///     addListener.  The two are equivalent.  Using the options argument, it is possible to combine different
        ///     types of listeners:<br>
        ///     <br>
        ///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)<div style="margin: 5px 20px 20px;">
        ///     Code:<pre><code>
        ///     el.on('click', this.onClick, this, {
        ///     single: true,
        ///     delay: 100,
        ///     stopEvent : true,
        ///     forumId: 4
        ///     });</code></pre>
        ///     <p>
        ///     <b>Attaching multiple handlers in 1 call</b><br>
        ///     The method also allows for a single argument to be passed which is a config object containing properties
        ///     which specify multiple handlers.
        ///     <p>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : {
        ///     fn: this.onClick
        ///     scope: this,
        ///     delay: 100
        ///     },
        ///     'mouseover' : {
        ///     fn: this.onMouseOver
        ///     scope: this
        ///     },
        ///     'mouseout' : {
        ///     fn: this.onMouseOut
        ///     scope: this
        ///     }
        ///     });</code></pre>
        ///     <p>
        ///     Or a shorthand syntax:<br>
        ///     Code:<pre><code>
        ///     el.on({
        ///     'click' : this.onClick,
        ///     'mouseover' : this.onMouseOver,
        ///     'mouseout' : this.onMouseOut
        ///     scope: this
        ///     });</code></pre>
        /// </summary>
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes</param>
        /// <param name="scope">(optional) The scope (this element) of the handler function</param>
        /// <param name="options">(optional) An object containing handler configuration properties.</param>
        /// <returns></returns>
        public void on(System.String eventName, Delegate fn, object scope, object options) { return ; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        /// </summary>
        /// <returns>Ext.Element</returns>
        public Ext.Element un() { return null; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        /// </summary>
        /// <param name="eventName">the type of event to remove</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element un(System.String eventName) { return null; }

        /// <summary>
        ///     Removes an event handler from this element.  The shorthand version {@link #un} is equivalent.  Example:
        ///     <pre><code>
        ///     el.removeListener('click', this.handlerFn);
        ///     // or
        ///     el.un('click', this.handlerFn);
        ///     </code></pre>
        /// </summary>
        /// <param name="eventName">the type of event to remove</param>
        /// <param name="fn">the method the event invokes</param>
        /// <returns>Ext.Element</returns>
        public Ext.Element un(System.String eventName, Delegate fn) { return null; }

    }
    [Anonymous]
    public class ElementConfig {

    }


}
