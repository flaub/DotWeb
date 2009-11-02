using System;
using System.DotWeb;
using DotWeb.Client;

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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\Element.js</jssource>
	public class Element : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern Element();
		/// <summary></summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public extern Element(string element);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
		/// <returns></returns>
		public extern Element(string element, bool forceNew);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public extern Element(DOMElement element);
		/// <summary></summary>
		/// <param name="element"></param>
		/// <param name="forceNew">(optional) By default the constructor checks to see if there is already an instance of this element in the cache and if there is it returns the same instance. This will skip that check (useful for extending this class).</param>
		/// <returns></returns>
		public extern Element(DOMElement element, bool forceNew);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Element prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The DOM element</summary>
		public extern DOMElement dom { get; set; }

		/// <summary>The DOM element ID</summary>
		public extern string id { get; set; }

		/// <summary>The element's default display mode  (defaults to "")</summary>
		public extern string originalDisplay { get; set; }

		/// <summary>The default unit to append to CSS values where a unit isn't provided (defaults to px).</summary>
		public extern string defaultUnit { get; set; }

		/// <summary>true to automatically adjust width and height settings for box-model issues (default to true)</summary>
		public extern object autoBoxAdjust { get; set; }

		/// <summary>Visibility mode constant - Use visibility to hide element</summary>
		public extern static double VISIBILITY { get; set; }

		/// <summary>Visibility mode constant - Use display to hide element</summary>
		public extern static double DISPLAY { get; set; }


		/// <summary>
		///     Sets the element's visibility mode. When setVisible() is called it
		///     will use this to determine whether to set the visibility or the display property.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setVisibilityMode();

		/// <summary>
		///     Sets the element's visibility mode. When setVisible() is called it
		///     will use this to determine whether to set the visibility or the display property.
		/// </summary>
		/// <param name="visMode">Element.VISIBILITY or Element.DISPLAY</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setVisibilityMode(object visMode);

		/// <summary>Convenience method for setVisibilityMode(Element.DISPLAY)</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void enableDisplayMode();

		/// <summary>Convenience method for setVisibilityMode(Element.DISPLAY)</summary>
		/// <param name="display">(optional) What to set display to when visible</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void enableDisplayMode(string display);

		/// <summary>
		///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParent();

		/// <summary>
		///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParent(string selector);

		/// <summary>
		///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParent(string selector, double maxDepth);

		/// <summary>
		///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParent(string selector, double maxDepth, bool returnEl);

		/// <summary>
		///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParent(string selector, object maxDepth);

		/// <summary>
		///     Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParent(string selector, object maxDepth, bool returnEl);

		/// <summary>
		///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParentNode();

		/// <summary>
		///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParentNode(string selector);

		/// <summary>
		///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParentNode(string selector, double maxDepth);

		/// <summary>
		///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParentNode(string selector, double maxDepth, bool returnEl);

		/// <summary>
		///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParentNode(string selector, object maxDepth);

		/// <summary>
		///     Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLElement</returns>
		public extern virtual void findParentNode(string selector, object maxDepth, bool returnEl);

		/// <summary>
		///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
		///     This is a shortcut for findParentNode() that always returns an Ext.Element.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void up();

		/// <summary>
		///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
		///     This is a shortcut for findParentNode() that always returns an Ext.Element.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void up(string selector);

		/// <summary>
		///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
		///     This is a shortcut for findParentNode() that always returns an Ext.Element.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void up(string selector, double maxDepth);

		/// <summary>
		///     Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child).
		///     This is a shortcut for findParentNode() that always returns an Ext.Element.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">The simple selector to test</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void up(string selector, object maxDepth);

		/// <summary>Returns true if this element matches the passed simple selector (e.g. div.some-class or span:first-child)</summary>
		/// <returns>Boolean</returns>
		public extern virtual void is_();

		/// <summary>Returns true if this element matches the passed simple selector (e.g. div.some-class or span:first-child)</summary>
		/// <param name="selector">The simple selector to test</param>
		/// <returns>Boolean</returns>
		public extern virtual void is_(string selector);

		/// <summary>Perform animation on this element.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void animate();

		/// <summary>Perform animation on this element.</summary>
		/// <param name="args">The animation control args</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void animate(object args);

		/// <summary>Perform animation on this element.</summary>
		/// <param name="args">The animation control args</param>
		/// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void animate(object args, double duration);

		/// <summary>Perform animation on this element.</summary>
		/// <param name="args">The animation control args</param>
		/// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
		/// <param name="onComplete">(optional) Function to call when animation completes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void animate(object args, double duration, Delegate onComplete);

		/// <summary>Perform animation on this element.</summary>
		/// <param name="args">The animation control args</param>
		/// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
		/// <param name="onComplete">(optional) Function to call when animation completes</param>
		/// <param name="easing">(optional) Easing method to use (defaults to 'easeOut')</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void animate(object args, double duration, Delegate onComplete, string easing);

		/// <summary>Perform animation on this element.</summary>
		/// <param name="args">The animation control args</param>
		/// <param name="duration">(optional) How long the animation lasts in seconds (defaults to .35)</param>
		/// <param name="onComplete">(optional) Function to call when animation completes</param>
		/// <param name="easing">(optional) Easing method to use (defaults to 'easeOut')</param>
		/// <param name="animType">(optional) 'run' is the default. Can also be 'color', 'motion', or 'scroll'</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void animate(object args, double duration, Delegate onComplete, string easing, string animType);

		/// <summary>
		///     Removes worthless text nodes
		///     keeps track if it has been cleaned already so
		///     you can call this over and over. However, if you update the element and
		///     need to force a reclean, you can pass true.
		/// </summary>
		/// <returns></returns>
		public extern virtual void clean();

		/// <summary>
		///     Removes worthless text nodes
		///     keeps track if it has been cleaned already so
		///     you can call this over and over. However, if you update the element and
		///     need to force a reclean, you can pass true.
		/// </summary>
		/// <param name="forceReclean">(optional) By default the element</param>
		/// <returns></returns>
		public extern virtual void clean(bool forceReclean);

		/// <summary>
		///     Scrolls this element into view within the passed container.
		///     string (id), dom node, or Ext.Element.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void scrollIntoView();

		/// <summary>
		///     Scrolls this element into view within the passed container.
		///     string (id), dom node, or Ext.Element.
		/// </summary>
		/// <param name="container">(optional) The container element to scroll (defaults to document.body).  Should be a</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void scrollIntoView(object container);

		/// <summary>
		///     Scrolls this element into view within the passed container.
		///     string (id), dom node, or Ext.Element.
		/// </summary>
		/// <param name="container">(optional) The container element to scroll (defaults to document.body).  Should be a</param>
		/// <param name="hscroll">(optional) False to disable horizontal scroll (defaults to true)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void scrollIntoView(object container, bool hscroll);

		/// <summary>
		///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
		///     the new height may not be available immediately.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void autoHeight();

		/// <summary>
		///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
		///     the new height may not be available immediately.
		/// </summary>
		/// <param name="animate">(optional) Animate the transition (defaults to false)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void autoHeight(bool animate);

		/// <summary>
		///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
		///     the new height may not be available immediately.
		/// </summary>
		/// <param name="animate">(optional) Animate the transition (defaults to false)</param>
		/// <param name="duration">(optional) Length of the animation in seconds (defaults to .35)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void autoHeight(bool animate, double duration);

		/// <summary>
		///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
		///     the new height may not be available immediately.
		/// </summary>
		/// <param name="animate">(optional) Animate the transition (defaults to false)</param>
		/// <param name="duration">(optional) Length of the animation in seconds (defaults to .35)</param>
		/// <param name="onComplete">(optional) Function to call when animation completes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void autoHeight(bool animate, double duration, Delegate onComplete);

		/// <summary>
		///     Measures the element's content height and updates height to match. Note: this function uses setTimeout so
		///     the new height may not be available immediately.
		/// </summary>
		/// <param name="animate">(optional) Animate the transition (defaults to false)</param>
		/// <param name="duration">(optional) Length of the animation in seconds (defaults to .35)</param>
		/// <param name="onComplete">(optional) Function to call when animation completes</param>
		/// <param name="easing">(optional) Easing method to use (defaults to easeOut)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void autoHeight(bool animate, double duration, Delegate onComplete, string easing);

		/// <summary>Returns true if this element is an ancestor of the passed element</summary>
		/// <returns>Boolean</returns>
		public extern virtual void contains();

		/// <summary>Returns true if this element is an ancestor of the passed element</summary>
		/// <param name="el">The element to check</param>
		/// <returns>Boolean</returns>
		public extern virtual void contains(DOMElement el);

		/// <summary>Returns true if this element is an ancestor of the passed element</summary>
		/// <param name="el">The element to check</param>
		/// <returns>Boolean</returns>
		public extern virtual void contains(string el);

		/// <summary>Checks whether the element is currently visible using both visibility and display properties.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isVisible();

		/// <summary>Checks whether the element is currently visible using both visibility and display properties.</summary>
		/// <param name="deep">(optional) True to walk the dom and see if parent elements are hidden (defaults to false)</param>
		/// <returns>Boolean</returns>
		public extern virtual void isVisible(bool deep);

		/// <summary>Creates a {@link Ext.CompositeElement} for child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <returns>CompositeElement/CompositeElementLite</returns>
		public extern virtual void select();

		/// <summary>Creates a {@link Ext.CompositeElement} for child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <returns>CompositeElement/CompositeElementLite</returns>
		public extern virtual void select(string selector);

		/// <summary>Creates a {@link Ext.CompositeElement} for child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <param name="unique">(optional) True to create a unique Ext.Element for each child (defaults to false, which creates a single shared flyweight object)</param>
		/// <returns>CompositeElement/CompositeElementLite</returns>
		public extern virtual void select(string selector, bool unique);

		/// <summary>Selects child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <returns>Array</returns>
		public extern virtual void query();

		/// <summary>Selects child nodes based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <returns>Array</returns>
		public extern virtual void query(string selector);

		/// <summary>Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void child();

		/// <summary>Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void child(string selector);

		/// <summary>Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <param name="returnDom">(optional) True to return the DOM node instead of Ext.Element (defaults to false)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void child(string selector, bool returnDom);

		/// <summary>Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void down();

		/// <summary>Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void down(string selector);

		/// <summary>Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).</summary>
		/// <param name="selector">The CSS selector</param>
		/// <param name="returnDom">(optional) True to return the DOM node instead of Ext.Element (defaults to false)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void down(string selector, bool returnDom);

		/// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
		/// <returns>Ext.dd.DD</returns>
		public extern virtual void initDD();

		/// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
		/// <param name="group">The group the DD object is member of</param>
		/// <returns>Ext.dd.DD</returns>
		public extern virtual void initDD(string group);

		/// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
		/// <param name="group">The group the DD object is member of</param>
		/// <param name="config">The DD config object</param>
		/// <returns>Ext.dd.DD</returns>
		public extern virtual void initDD(string group, object config);

		/// <summary>Initializes a {@link Ext.dd.DD} drag drop object for this element.</summary>
		/// <param name="group">The group the DD object is member of</param>
		/// <param name="config">The DD config object</param>
		/// <param name="overrides">An object containing methods to override/implement on the DD object</param>
		/// <returns>Ext.dd.DD</returns>
		public extern virtual void initDD(string group, object config, object overrides);

		/// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
		/// <returns>Ext.dd.DDProxy</returns>
		public extern virtual void initDDProxy();

		/// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
		/// <param name="group">The group the DDProxy object is member of</param>
		/// <returns>Ext.dd.DDProxy</returns>
		public extern virtual void initDDProxy(string group);

		/// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
		/// <param name="group">The group the DDProxy object is member of</param>
		/// <param name="config">The DDProxy config object</param>
		/// <returns>Ext.dd.DDProxy</returns>
		public extern virtual void initDDProxy(string group, object config);

		/// <summary>Initializes a {@link Ext.dd.DDProxy} object for this element.</summary>
		/// <param name="group">The group the DDProxy object is member of</param>
		/// <param name="config">The DDProxy config object</param>
		/// <param name="overrides">An object containing methods to override/implement on the DDProxy object</param>
		/// <returns>Ext.dd.DDProxy</returns>
		public extern virtual void initDDProxy(string group, object config, object overrides);

		/// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
		/// <returns>Ext.dd.DDTarget</returns>
		public extern virtual void initDDTarget();

		/// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
		/// <param name="group">The group the DDTarget object is member of</param>
		/// <returns>Ext.dd.DDTarget</returns>
		public extern virtual void initDDTarget(string group);

		/// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
		/// <param name="group">The group the DDTarget object is member of</param>
		/// <param name="config">The DDTarget config object</param>
		/// <returns>Ext.dd.DDTarget</returns>
		public extern virtual void initDDTarget(string group, object config);

		/// <summary>Initializes a {@link Ext.dd.DDTarget} object for this element.</summary>
		/// <param name="group">The group the DDTarget object is member of</param>
		/// <param name="config">The DDTarget config object</param>
		/// <param name="overrides">An object containing methods to override/implement on the DDTarget object</param>
		/// <returns>Ext.dd.DDTarget</returns>
		public extern virtual void initDDTarget(string group, object config, object overrides);

		/// <summary>
		///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
		///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setVisible();

		/// <summary>
		///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
		///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
		/// </summary>
		/// <param name="visible">Whether the element is visible</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setVisible(bool visible);

		/// <summary>
		///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
		///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
		/// </summary>
		/// <param name="visible">Whether the element is visible</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setVisible(bool visible, bool animate);

		/// <summary>
		///     Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use
		///     the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
		/// </summary>
		/// <param name="visible">Whether the element is visible</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setVisible(bool visible, object animate);

		/// <summary>Returns true if display is not "none"</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isDisplayed();

		/// <summary>Toggles the element's visibility or display, depending on visibility mode.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void toggle();

		/// <summary>Toggles the element's visibility or display, depending on visibility mode.</summary>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void toggle(bool animate);

		/// <summary>Toggles the element's visibility or display, depending on visibility mode.</summary>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void toggle(object animate);

		/// <summary>Sets the CSS display property. Uses originalDisplay if the specified value is a boolean true.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setDisplayed();

		/// <summary>Sets the CSS display property. Uses originalDisplay if the specified value is a boolean true.</summary>
		/// <param name="value">Boolean value to display the element using its default display, or a string to set the display directly.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setDisplayed(object value);

		/// <summary>Tries to focus the element. Any exceptions are caught and ignored.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void focus();

		/// <summary>Tries to blur the element. Any exceptions are caught and ignored.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void blur();

		/// <summary>Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClass();

		/// <summary>Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.</summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClass(string className);

		/// <summary>Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.</summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClass(System.Array className);

		/// <summary>Adds one or more CSS classes to this element and removes the same class(es) from all siblings.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void radioClass();

		/// <summary>Adds one or more CSS classes to this element and removes the same class(es) from all siblings.</summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void radioClass(string className);

		/// <summary>Adds one or more CSS classes to this element and removes the same class(es) from all siblings.</summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void radioClass(System.Array className);

		/// <summary>Removes one or more CSS classes from the element.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void removeClass();

		/// <summary>Removes one or more CSS classes from the element.</summary>
		/// <param name="className">The CSS class to remove, or an array of classes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void removeClass(string className);

		/// <summary>Removes one or more CSS classes from the element.</summary>
		/// <param name="className">The CSS class to remove, or an array of classes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void removeClass(System.Array className);

		/// <summary>Toggles the specified CSS class on this element (removes it if it already exists, otherwise adds it).</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void toggleClass();

		/// <summary>Toggles the specified CSS class on this element (removes it if it already exists, otherwise adds it).</summary>
		/// <param name="className">The CSS class to toggle</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void toggleClass(string className);

		/// <summary>Checks if the specified CSS class exists on this element's DOM node.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasClass();

		/// <summary>Checks if the specified CSS class exists on this element's DOM node.</summary>
		/// <param name="className">The CSS class to check for</param>
		/// <returns>Boolean</returns>
		public extern virtual void hasClass(string className);

		/// <summary>Replaces a CSS class on the element with another.  If the old name does not exist, the new name will simply be added.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void replaceClass();

		/// <summary>Replaces a CSS class on the element with another.  If the old name does not exist, the new name will simply be added.</summary>
		/// <param name="oldClassName">The CSS class to replace</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void replaceClass(string oldClassName);

		/// <summary>Replaces a CSS class on the element with another.  If the old name does not exist, the new name will simply be added.</summary>
		/// <param name="oldClassName">The CSS class to replace</param>
		/// <param name="newClassName">The replacement CSS class</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void replaceClass(string oldClassName, string newClassName);

		/// <summary>
		///     Returns an object with properties matching the styles requested.
		///     For example, el.getStyles('color', 'font-size', 'width') might return
		///     {'color': '#FFFFFF', 'font-size': '13px', 'width': '100px'}.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getStyles();

		/// <summary>
		///     Returns an object with properties matching the styles requested.
		///     For example, el.getStyles('color', 'font-size', 'width') might return
		///     {'color': '#FFFFFF', 'font-size': '13px', 'width': '100px'}.
		/// </summary>
		/// <param name="args"></param>
		/// <returns>Object</returns>
		public extern virtual void getStyles(params string[] args);

		/// <summary>Normalizes currentStyle and computedStyle.</summary>
		/// <returns>String</returns>
		public extern virtual void getStyle();

		/// <summary>Normalizes currentStyle and computedStyle.</summary>
		/// <param name="property">The style property whose value is returned.</param>
		/// <returns>String</returns>
		public extern virtual void getStyle(string property);

		/// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setStyle();

		/// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
		/// <param name="property">The style property to be set, or an object of multiple styles.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setStyle(string property);

		/// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
		/// <param name="property">The style property to be set, or an object of multiple styles.</param>
		/// <param name="value">(optional) The value to apply to the given property, or null if an object was passed.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setStyle(string property, string value);

		/// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
		/// <param name="property">The style property to be set, or an object of multiple styles.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setStyle(object property);

		/// <summary>Wrapper for setting style properties, also takes single object parameter of multiple styles.</summary>
		/// <param name="property">The style property to be set, or an object of multiple styles.</param>
		/// <param name="value">(optional) The value to apply to the given property, or null if an object was passed.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setStyle(object property, string value);

		/// <summary>
		///     More flexible version of {@link #setStyle} for setting style properties.
		///     a function which returns such a specification.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void applyStyles();

		/// <summary>
		///     More flexible version of {@link #setStyle} for setting style properties.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="styles">A style specification string, e.g. "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void applyStyles(string styles);

		/// <summary>
		///     More flexible version of {@link #setStyle} for setting style properties.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="styles">A style specification string, e.g. "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void applyStyles(object styles);

		/// <summary>
		///     More flexible version of {@link #setStyle} for setting style properties.
		///     a function which returns such a specification.
		/// </summary>
		/// <param name="styles">A style specification string, e.g. "width:100px", or object in the form {width:"100px"}, or</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void applyStyles(Delegate styles);

		/// <summary>Gets the current X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <returns>Number</returns>
		public extern virtual void getX();

		/// <summary>Gets the current Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <returns>Number</returns>
		public extern virtual void getY();

		/// <summary>Gets the current position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <returns>Array</returns>
		public extern virtual void getXY();

		/// <summary>Returns the offsets of this element from the passed element. Both element must be part of the DOM tree and not have display:none to have page coordinates.</summary>
		/// <returns>Array</returns>
		public extern virtual void getOffsetsTo();

		/// <summary>Returns the offsets of this element from the passed element. Both element must be part of the DOM tree and not have display:none to have page coordinates.</summary>
		/// <param name="element">The element to get the offsets from.</param>
		/// <returns>Array</returns>
		public extern virtual void getOffsetsTo(object element);

		/// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setX();

		/// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <param name="The">X position of the element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setX(double The);

		/// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <param name="The">X position of the element</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setX(double The, bool animate);

		/// <summary>Sets the X position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <param name="The">X position of the element</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setX(double The, object animate);

		/// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setY();

		/// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <param name="The">Y position of the element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setY(double The);

		/// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <param name="The">Y position of the element</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setY(double The, bool animate);

		/// <summary>Sets the Y position of the element based on page coordinates.  Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).</summary>
		/// <param name="The">Y position of the element</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setY(double The, object animate);

		/// <summary>Sets the element's left position directly using CSS style (instead of {@link #setX}).</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLeft();

		/// <summary>Sets the element's left position directly using CSS style (instead of {@link #setX}).</summary>
		/// <param name="left">The left CSS property value</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLeft(string left);

		/// <summary>Sets the element's top position directly using CSS style (instead of {@link #setY}).</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setTop();

		/// <summary>Sets the element's top position directly using CSS style (instead of {@link #setY}).</summary>
		/// <param name="top">The top CSS property value</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setTop(string top);

		/// <summary>Sets the element's CSS right style.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setRight();

		/// <summary>Sets the element's CSS right style.</summary>
		/// <param name="right">The right CSS property value</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setRight(string right);

		/// <summary>Sets the element's CSS bottom style.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBottom();

		/// <summary>Sets the element's CSS bottom style.</summary>
		/// <param name="bottom">The bottom CSS property value</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBottom(string bottom);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setXY();

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="pos">Contains X & Y [x, y] values for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setXY(System.Array pos);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="pos">Contains X & Y [x, y] values for new position (coordinates are page-based)</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setXY(System.Array pos, bool animate);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="pos">Contains X & Y [x, y] values for new position (coordinates are page-based)</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setXY(System.Array pos, object animate);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLocation();

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLocation(double x);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLocation(double x, double y);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLocation(double x, double y, bool animate);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLocation(double x, double y, object animate);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void moveTo();

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void moveTo(double x);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void moveTo(double x, double y);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void moveTo(double x, double y, bool animate);

		/// <summary>
		///     Sets the position of the element in page coordinates, regardless of how the element is positioned.
		///     The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
		/// </summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="animate">(optional) True for the default animation, or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void moveTo(double x, double y, object animate);

		/// <summary>
		///     Returns the region of the given element.
		///     The element must be part of the DOM tree to have a region (display:none or elements not appended return false).
		/// </summary>
		/// <returns>Region</returns>
		public extern virtual void getRegion();

		/// <summary>Returns the offset height of the element</summary>
		/// <returns>Number</returns>
		public extern virtual void getHeight();

		/// <summary>Returns the offset height of the element</summary>
		/// <param name="contentHeight">(optional) true to get the height minus borders and padding</param>
		/// <returns>Number</returns>
		public extern virtual void getHeight(bool contentHeight);

		/// <summary>Returns the offset width of the element</summary>
		/// <returns>Number</returns>
		public extern virtual void getWidth();

		/// <summary>Returns the offset width of the element</summary>
		/// <param name="contentWidth">(optional) true to get the width minus borders and padding</param>
		/// <returns>Number</returns>
		public extern virtual void getWidth(bool contentWidth);

		/// <summary>
		///     Returns either the offsetHeight or the height of this element based on CSS height adjusted by padding or borders
		///     when needed to simulate offsetHeight when offsets aren't available. This may not work on display:none elements
		///     if a height has not been set using CSS.
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getComputedHeight();

		/// <summary>
		///     Returns either the offsetWidth or the width of this element based on CSS width adjusted by padding or borders
		///     when needed to simulate offsetWidth when offsets aren't available. This may not work on display:none elements
		///     if a width has not been set using CSS.
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getComputedWidth();

		/// <summary>Returns the size of the element.</summary>
		/// <returns>Object</returns>
		public extern virtual void getSize();

		/// <summary>Returns the size of the element.</summary>
		/// <param name="contentSize">(optional) true to get the width/size minus borders and padding</param>
		/// <returns>Object</returns>
		public extern virtual void getSize(bool contentSize);

		/// <summary>Returns the width and height of the viewport.</summary>
		/// <returns>Object</returns>
		public extern virtual void getViewSize();

		/// <summary>Returns the value of the "value" attribute</summary>
		/// <returns>String/Number</returns>
		public extern virtual void getValue();

		/// <summary>Returns the value of the "value" attribute</summary>
		/// <param name="asNumber">true to parse the value as a number</param>
		/// <returns>String/Number</returns>
		public extern virtual void getValue(bool asNumber);

		/// <summary>Set the width of the element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setWidth();

		/// <summary>Set the width of the element</summary>
		/// <param name="width">The new width</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setWidth(double width);

		/// <summary>Set the width of the element</summary>
		/// <param name="width">The new width</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setWidth(double width, bool animate);

		/// <summary>Set the width of the element</summary>
		/// <param name="width">The new width</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setWidth(double width, object animate);

		/// <summary>Set the height of the element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setHeight();

		/// <summary>Set the height of the element</summary>
		/// <param name="height">The new height</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setHeight(double height);

		/// <summary>Set the height of the element</summary>
		/// <param name="height">The new height</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setHeight(double height, bool animate);

		/// <summary>Set the height of the element</summary>
		/// <param name="height">The new height</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setHeight(double height, object animate);

		/// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setSize();

		/// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
		/// <param name="width">The new width</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setSize(double width);

		/// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
		/// <param name="width">The new width</param>
		/// <param name="height">The new height</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setSize(double width, double height);

		/// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
		/// <param name="width">The new width</param>
		/// <param name="height">The new height</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setSize(double width, double height, bool animate);

		/// <summary>Set the size of the element. If animation is true, both width an height will be animated concurrently.</summary>
		/// <param name="width">The new width</param>
		/// <param name="height">The new height</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setSize(double width, double height, object animate);

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds();

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds(double x);

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds(double x, double y);

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="width">The new width</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds(double x, double y, double width);

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="width">The new width</param>
		/// <param name="height">The new height</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds(double x, double y, double width, double height);

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="width">The new width</param>
		/// <param name="height">The new height</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds(double x, double y, double width, double height, bool animate);

		/// <summary>Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="x">X value for new position (coordinates are page-based)</param>
		/// <param name="y">Y value for new position (coordinates are page-based)</param>
		/// <param name="width">The new width</param>
		/// <param name="height">The new height</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBounds(double x, double y, double width, double height, object animate);

		/// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setRegion();

		/// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="region">The region to fill</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setRegion(object region);

		/// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="region">The region to fill</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setRegion(object region, bool animate);

		/// <summary>Sets the element's position and size the specified region. If animation is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="region">The region to fill</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setRegion(object region, object animate);

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
		public extern virtual void addListener();

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
		public extern virtual void addListener(string eventName);

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
		public extern virtual void addListener(string eventName, Delegate fn);

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
		public extern virtual void addListener(string eventName, Delegate fn, object scope);

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
		public extern virtual void addListener(string eventName, Delegate fn, object scope, object options);

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
		public extern virtual void removeListener();

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
		public extern virtual void removeListener(string eventName);

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
		public extern virtual void removeListener(string eventName, Delegate fn);

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
		public extern virtual void removeListener(string eventName, Delegate fn, object scope);

		/// <summary>Removes all previous added listeners from this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void removeAllListeners();

		/// <summary>
		///     Create an event handler on this element such that when the event fires and is handled by this element,
		///     it will be relayed to another object (i.e., fired again as if it originated from that object instead).
		///     for firing the relayed event
		/// </summary>
		/// <returns></returns>
		public extern virtual void relayEvent();

		/// <summary>
		///     Create an event handler on this element such that when the event fires and is handled by this element,
		///     it will be relayed to another object (i.e., fired again as if it originated from that object instead).
		///     for firing the relayed event
		/// </summary>
		/// <param name="eventName">The type of event to relay</param>
		/// <returns></returns>
		public extern virtual void relayEvent(string eventName);

		/// <summary>
		///     Create an event handler on this element such that when the event fires and is handled by this element,
		///     it will be relayed to another object (i.e., fired again as if it originated from that object instead).
		///     for firing the relayed event
		/// </summary>
		/// <param name="eventName">The type of event to relay</param>
		/// <param name="obj">Any object that extends {@link Ext.util.Observable} that will provide the context</param>
		/// <returns></returns>
		public extern virtual void relayEvent(string eventName, object obj);

		/// <summary>Set the opacity of the element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setOpacity();

		/// <summary>Set the opacity of the element</summary>
		/// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setOpacity(double opacity);

		/// <summary>Set the opacity of the element</summary>
		/// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setOpacity(double opacity, bool animate);

		/// <summary>Set the opacity of the element</summary>
		/// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setOpacity(double opacity, object animate);

		/// <summary>Gets the left X coordinate</summary>
		/// <returns>Number</returns>
		public extern virtual void getLeft();

		/// <summary>Gets the left X coordinate</summary>
		/// <param name="local">True to get the local css position instead of page coordinate</param>
		/// <returns>Number</returns>
		public extern virtual void getLeft(bool local);

		/// <summary>Gets the right X coordinate of the element (element X position + element width)</summary>
		/// <returns>Number</returns>
		public extern virtual void getRight();

		/// <summary>Gets the right X coordinate of the element (element X position + element width)</summary>
		/// <param name="local">True to get the local css position instead of page coordinate</param>
		/// <returns>Number</returns>
		public extern virtual void getRight(bool local);

		/// <summary>Gets the top Y coordinate</summary>
		/// <returns>Number</returns>
		public extern virtual void getTop();

		/// <summary>Gets the top Y coordinate</summary>
		/// <param name="local">True to get the local css position instead of page coordinate</param>
		/// <returns>Number</returns>
		public extern virtual void getTop(bool local);

		/// <summary>Gets the bottom Y coordinate of the element (element Y position + element height)</summary>
		/// <returns>Number</returns>
		public extern virtual void getBottom();

		/// <summary>Gets the bottom Y coordinate of the element (element Y position + element height)</summary>
		/// <param name="local">True to get the local css position instead of page coordinate</param>
		/// <returns>Number</returns>
		public extern virtual void getBottom(bool local);

		/// <summary>
		///     Initializes positioning on this element. If a desired position is not passed, it will make the
		///     the element positioned relative IF it is not already positioned.
		/// </summary>
		/// <returns></returns>
		public extern virtual void position();

		/// <summary>
		///     Initializes positioning on this element. If a desired position is not passed, it will make the
		///     the element positioned relative IF it is not already positioned.
		/// </summary>
		/// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
		/// <returns></returns>
		public extern virtual void position(string pos);

		/// <summary>
		///     Initializes positioning on this element. If a desired position is not passed, it will make the
		///     the element positioned relative IF it is not already positioned.
		/// </summary>
		/// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
		/// <param name="zIndex">(optional) The zIndex to apply</param>
		/// <returns></returns>
		public extern virtual void position(string pos, double zIndex);

		/// <summary>
		///     Initializes positioning on this element. If a desired position is not passed, it will make the
		///     the element positioned relative IF it is not already positioned.
		/// </summary>
		/// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
		/// <param name="zIndex">(optional) The zIndex to apply</param>
		/// <param name="x">(optional) Set the page X position</param>
		/// <returns></returns>
		public extern virtual void position(string pos, double zIndex, double x);

		/// <summary>
		///     Initializes positioning on this element. If a desired position is not passed, it will make the
		///     the element positioned relative IF it is not already positioned.
		/// </summary>
		/// <param name="pos">(optional) Positioning to use "relative", "absolute" or "fixed"</param>
		/// <param name="zIndex">(optional) The zIndex to apply</param>
		/// <param name="x">(optional) Set the page X position</param>
		/// <param name="y">(optional) Set the page Y position</param>
		/// <returns></returns>
		public extern virtual void position(string pos, double zIndex, double x, double y);

		/// <summary>Clear positioning back to the default when the document was loaded</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void clearPositioning();

		/// <summary>Clear positioning back to the default when the document was loaded</summary>
		/// <param name="value">(optional) The value to use for the left,right,top,bottom, defaults to '' (empty string). You could use 'auto'.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void clearPositioning(string value);

		/// <summary>
		///     Gets an object with all CSS positioning properties. Useful along with setPostioning to get
		///     snapshot before performing an update and then restoring the element.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getPositioning();

		/// <summary>
		///     Gets the width of the border(s) for the specified side(s)
		///     passing lr would get the border (l)eft width + the border (r)ight width.
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getBorderWidth();

		/// <summary>
		///     Gets the width of the border(s) for the specified side(s)
		///     passing lr would get the border (l)eft width + the border (r)ight width.
		/// </summary>
		/// <param name="side">Can be t, l, r, b or any combination of those to add multiple values. For example,</param>
		/// <returns>Number</returns>
		public extern virtual void getBorderWidth(string side);

		/// <summary>
		///     Gets the width of the padding(s) for the specified side(s)
		///     passing lr would get the padding (l)eft + the padding (r)ight.
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getPadding();

		/// <summary>
		///     Gets the width of the padding(s) for the specified side(s)
		///     passing lr would get the padding (l)eft + the padding (r)ight.
		/// </summary>
		/// <param name="side">Can be t, l, r, b or any combination of those to add multiple values. For example,</param>
		/// <returns>Number</returns>
		public extern virtual void getPadding(string side);

		/// <summary>Set positioning with an object returned by getPositioning().</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setPositioning();

		/// <summary>Set positioning with an object returned by getPositioning().</summary>
		/// <param name="posCfg"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setPositioning(object posCfg);

		/// <summary>Quick set left and top adding default units</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLeftTop();

		/// <summary>Quick set left and top adding default units</summary>
		/// <param name="left">The left CSS property value</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLeftTop(string left);

		/// <summary>Quick set left and top adding default units</summary>
		/// <param name="left">The left CSS property value</param>
		/// <param name="top">The top CSS property value</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setLeftTop(string left, string top);

		/// <summary>Move this element relative to its current position.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void move();

		/// <summary>Move this element relative to its current position.</summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void move(string direction);

		/// <summary>Move this element relative to its current position.</summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <param name="distance">How far to move the element in pixels</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void move(string direction, double distance);

		/// <summary>Move this element relative to its current position.</summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <param name="distance">How far to move the element in pixels</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void move(string direction, double distance, bool animate);

		/// <summary>Move this element relative to its current position.</summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <param name="distance">How far to move the element in pixels</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void move(string direction, double distance, object animate);

		/// <summary>Store the current overflow setting and clip overflow on the element - use {@link #unclip} to remove</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void clip();

		/// <summary>Return clipping (overflow) to original clipping before clip() was called</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void unclip();

		/// <summary>
		///     Gets the x,y coordinates specified by the anchor position on the element.
		///     for details on supported anchor positions.
		///     of page coordinates
		///     {width: (target width), height: (target height)} (defaults to the element's current size)
		/// </summary>
		/// <returns>Array</returns>
		public extern virtual void getAnchorXY();

		/// <summary>
		///     Gets the x,y coordinates specified by the anchor position on the element.
		///     for details on supported anchor positions.
		///     of page coordinates
		///     {width: (target width), height: (target height)} (defaults to the element's current size)
		/// </summary>
		/// <param name="anchor">(optional) The specified anchor position (defaults to "c").  See {@link #alignTo}</param>
		/// <returns>Array</returns>
		public extern virtual void getAnchorXY(string anchor);

		/// <summary>
		///     Gets the x,y coordinates specified by the anchor position on the element.
		///     for details on supported anchor positions.
		///     of page coordinates
		///     {width: (target width), height: (target height)} (defaults to the element's current size)
		/// </summary>
		/// <param name="anchor">(optional) The specified anchor position (defaults to "c").  See {@link #alignTo}</param>
		/// <param name="local">(optional) True to get the local (element top/left-relative) anchor position instead</param>
		/// <returns>Array</returns>
		public extern virtual void getAnchorXY(string anchor, bool local);

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
		public extern virtual void getAnchorXY(string anchor, bool local, object size);

		/// <summary>
		///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
		///     supported position values.
		/// </summary>
		/// <returns>Array</returns>
		public extern virtual void getAlignToXY();

		/// <summary>
		///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
		///     supported position values.
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <returns>Array</returns>
		public extern virtual void getAlignToXY(object element);

		/// <summary>
		///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
		///     supported position values.
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <param name="position">The position to align to.</param>
		/// <returns>Array</returns>
		public extern virtual void getAlignToXY(object element, string position);

		/// <summary>
		///     Gets the x,y coordinates to align this element with another element. See {@link #alignTo} for more info on the
		///     supported position values.
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <param name="position">The position to align to.</param>
		/// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
		/// <returns>Array</returns>
		public extern virtual void getAlignToXY(object element, string position, System.Array offsets);

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
		public extern virtual void alignTo();

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
		public extern virtual void alignTo(object element);

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
		public extern virtual void alignTo(object element, string position);

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
		public extern virtual void alignTo(object element, string position, System.Array offsets);

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
		public extern virtual void alignTo(object element, string position, System.Array offsets, bool animate);

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
		public extern virtual void alignTo(object element, string position, System.Array offsets, object animate);

		/// <summary>
		///     Anchors an element to another element and realigns it when the window is resized.
		///     is a number, it is used as the buffer delay (defaults to 50ms).
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void anchorTo();

		/// <summary>
		///     Anchors an element to another element and realigns it when the window is resized.
		///     is a number, it is used as the buffer delay (defaults to 50ms).
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void anchorTo(object element);

		/// <summary>
		///     Anchors an element to another element and realigns it when the window is resized.
		///     is a number, it is used as the buffer delay (defaults to 50ms).
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <param name="position">The position to align to.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void anchorTo(object element, string position);

		/// <summary>
		///     Anchors an element to another element and realigns it when the window is resized.
		///     is a number, it is used as the buffer delay (defaults to 50ms).
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <param name="position">The position to align to.</param>
		/// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void anchorTo(object element, string position, System.Array offsets);

		/// <summary>
		///     Anchors an element to another element and realigns it when the window is resized.
		///     is a number, it is used as the buffer delay (defaults to 50ms).
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <param name="position">The position to align to.</param>
		/// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
		/// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void anchorTo(object element, string position, System.Array offsets, bool animate);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, bool animate, bool monitorScroll);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, bool animate, bool monitorScroll, Delegate callback);

		/// <summary>
		///     Anchors an element to another element and realigns it when the window is resized.
		///     is a number, it is used as the buffer delay (defaults to 50ms).
		/// </summary>
		/// <param name="element">The element to align to.</param>
		/// <param name="position">The position to align to.</param>
		/// <param name="offsets">(optional) Offset the positioning by [x, y]</param>
		/// <param name="animate">(optional) True for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void anchorTo(object element, string position, System.Array offsets, object animate);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, object animate, bool monitorScroll);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, object animate, bool monitorScroll, Delegate callback);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, bool animate, double monitorScroll);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, bool animate, double monitorScroll, Delegate callback);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, object animate, double monitorScroll);

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
		public extern virtual void anchorTo(object element, string position, System.Array offsets, object animate, double monitorScroll, Delegate callback);

		/// <summary>Clears any opacity settings from this element. Required in some cases for IE.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void clearOpacity();

		/// <summary>Hide this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void hide();

		/// <summary>Hide this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void hide(bool animate);

		/// <summary>Hide this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void hide(object animate);

		/// <summary>Show this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void show();

		/// <summary>Show this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void show(bool animate);

		/// <summary>Show this element - Uses display mode to determine whether to use "display" or "visibility". See {@link #setVisible}.</summary>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void show(object animate);

		/// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void update();

		/// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
		/// <param name="html">The new HTML</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void update(string html);

		/// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
		/// <param name="html">The new HTML</param>
		/// <param name="loadScripts">(optional) True to look for and process scripts (defaults to false)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void update(string html, bool loadScripts);

		/// <summary>Update the innerHTML of this element, optionally searching for and processing scripts</summary>
		/// <param name="html">The new HTML</param>
		/// <param name="loadScripts">(optional) True to look for and process scripts (defaults to false)</param>
		/// <param name="callback">(optional) For async script loading you can be notified when the update completes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void update(string html, bool loadScripts, Delegate callback);

		/// <summary>
		///     Direct access to the Updater {@link Ext.Updater#update} method. The method takes the same object
		///     parameter as {@link Ext.Updater#update}
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void load();

		/// <summary>Gets this element's Updater</summary>
		/// <returns>Ext.Updater</returns>
		public extern virtual void getUpdater();

		/// <summary>Disables text selection for this element (normalized across browsers)</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void unselectable();

		/// <summary>Calculates the x, y to center this element on the screen</summary>
		/// <returns>Array</returns>
		public extern virtual void getCenterXY();

		/// <summary>Centers the Element in either the viewport, or another Element.</summary>
		/// <returns></returns>
		public extern virtual void center();

		/// <summary>Centers the Element in either the viewport, or another Element.</summary>
		/// <param name="centerIn">(optional) The element in which to center the element.</param>
		/// <returns></returns>
		public extern virtual void center(object centerIn);

		/// <summary>Tests various css rules/browsers to determine if this element uses a border box</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isBorderBox();

		/// <summary>
		///     Return a box {x, y, width, height} that can be used to set another elements
		///     size/location to match this element.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getBox();

		/// <summary>
		///     Return a box {x, y, width, height} that can be used to set another elements
		///     size/location to match this element.
		/// </summary>
		/// <param name="contentBox">(optional) If true a box for the content of the element is returned.</param>
		/// <returns>Object</returns>
		public extern virtual void getBox(bool contentBox);

		/// <summary>
		///     Return a box {x, y, width, height} that can be used to set another elements
		///     size/location to match this element.
		/// </summary>
		/// <param name="contentBox">(optional) If true a box for the content of the element is returned.</param>
		/// <param name="local">(optional) If true the element's left and top are returned instead of page x/y.</param>
		/// <returns>Object</returns>
		public extern virtual void getBox(bool contentBox, bool local);

		/// <summary>
		///     Returns the sum width of the padding and borders for the passed "sides". See getBorderWidth()
		///     for more information about the sides.
		/// </summary>
		/// <returns>Number</returns>
		public extern virtual void getFrameWidth();

		/// <summary>
		///     Returns the sum width of the padding and borders for the passed "sides". See getBorderWidth()
		///     for more information about the sides.
		/// </summary>
		/// <param name="sides"></param>
		/// <returns>Number</returns>
		public extern virtual void getFrameWidth(string sides);

		/// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBox();

		/// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="box">The box to fill {x, y, width, height}</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBox(object box);

		/// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="box">The box to fill {x, y, width, height}</param>
		/// <param name="adjust">(optional) Whether to adjust for box-model issues automatically</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBox(object box, bool adjust);

		/// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="box">The box to fill {x, y, width, height}</param>
		/// <param name="adjust">(optional) Whether to adjust for box-model issues automatically</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBox(object box, bool adjust, bool animate);

		/// <summary>Sets the element's box. Use getBox() on another element to get a box obj. If animate is true then width, height, x and y will be animated concurrently.</summary>
		/// <param name="box">The box to fill {x, y, width, height}</param>
		/// <param name="adjust">(optional) Whether to adjust for box-model issues automatically</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void setBox(object box, bool adjust, object animate);

		/// <summary>Forces the browser to repaint this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void repaint();

		/// <summary>
		///     Returns an object with properties top, left, right and bottom representing the margins of this element unless sides is passed,
		///     then it returns the calculated width of the sides (see getPadding)
		/// </summary>
		/// <returns>Object/Number</returns>
		public extern virtual void getMargins();

		/// <summary>
		///     Returns an object with properties top, left, right and bottom representing the margins of this element unless sides is passed,
		///     then it returns the calculated width of the sides (see getPadding)
		/// </summary>
		/// <param name="sides">(optional) Any combination of l, r, t, b to get the sum of those sides</param>
		/// <returns>Object/Number</returns>
		public extern virtual void getMargins(string sides);

		/// <summary>Creates a proxy element of this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy();

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(string config);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(string config, string renderTo);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(string config, string renderTo, bool matchBox);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(object config);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(object config, string renderTo);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(object config, string renderTo, bool matchBox);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(string config, DOMElement renderTo);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(string config, DOMElement renderTo, bool matchBox);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(object config, DOMElement renderTo);

		/// <summary>Creates a proxy element of this element</summary>
		/// <param name="config">The class name of the proxy element or a DomHelper config object</param>
		/// <param name="renderTo">(optional) The element or element id to render the proxy to (defaults to document.body)</param>
		/// <param name="matchBox">(optional) True to align and size the proxy to this element now (defaults to false)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createProxy(object config, DOMElement renderTo, bool matchBox);

		/// <summary>
		///     Puts a mask over this element to disable user interaction. Requires core.css.
		///     This method can only be applied to elements which accept child nodes.
		/// </summary>
		/// <returns>Element</returns>
		public extern virtual void mask();

		/// <summary>
		///     Puts a mask over this element to disable user interaction. Requires core.css.
		///     This method can only be applied to elements which accept child nodes.
		/// </summary>
		/// <param name="msg">(optional) A message to display in the mask</param>
		/// <returns>Element</returns>
		public extern virtual void mask(string msg);

		/// <summary>
		///     Puts a mask over this element to disable user interaction. Requires core.css.
		///     This method can only be applied to elements which accept child nodes.
		/// </summary>
		/// <param name="msg">(optional) A message to display in the mask</param>
		/// <param name="msgCls">(optional) A css class to apply to the msg element</param>
		/// <returns>Element</returns>
		public extern virtual void mask(string msg, string msgCls);

		/// <summary>Removes a previously applied mask.</summary>
		/// <returns></returns>
		public extern virtual void unmask();

		/// <summary>Returns true if this element is masked</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isMasked();

		/// <summary>
		///     Creates an iframe shim for this element to keep selects and other windowed objects from
		///     showing through.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void createShim();

		/// <summary>Removes this element from the DOM and deletes it from the cache</summary>
		/// <returns></returns>
		public extern virtual void remove();

		/// <summary>
		///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
		///     filters child element mouse events.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void hover();

		/// <summary>
		///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
		///     filters child element mouse events.
		/// </summary>
		/// <param name="overFn"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void hover(Delegate overFn);

		/// <summary>
		///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
		///     filters child element mouse events.
		/// </summary>
		/// <param name="overFn"></param>
		/// <param name="outFn"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void hover(Delegate overFn, Delegate outFn);

		/// <summary>
		///     Sets up event handlers to call the passed functions when the mouse is over this element. Automatically
		///     filters child element mouse events.
		/// </summary>
		/// <param name="overFn"></param>
		/// <param name="outFn"></param>
		/// <param name="scope">(optional)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void hover(Delegate overFn, Delegate outFn, object scope);

		/// <summary>Sets up event handlers to add and remove a css class when the mouse is over this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClassOnOver();

		/// <summary>Sets up event handlers to add and remove a css class when the mouse is over this element</summary>
		/// <param name="className"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClassOnOver(string className);

		/// <summary>Sets up event handlers to add and remove a css class when this element has the focus</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClassOnFocus();

		/// <summary>Sets up event handlers to add and remove a css class when this element has the focus</summary>
		/// <param name="className"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClassOnFocus(string className);

		/// <summary>Sets up event handlers to add and remove a css class when the mouse is down and then up on this element (a click effect)</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClassOnClick();

		/// <summary>Sets up event handlers to add and remove a css class when the mouse is down and then up on this element (a click effect)</summary>
		/// <param name="className"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void addClassOnClick(string className);

		/// <summary>Stops the specified event from bubbling and optionally prevents the default action</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void swallowEvent();

		/// <summary>Stops the specified event from bubbling and optionally prevents the default action</summary>
		/// <param name="eventName"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void swallowEvent(string eventName);

		/// <summary>Stops the specified event from bubbling and optionally prevents the default action</summary>
		/// <param name="eventName"></param>
		/// <param name="preventDefault">(optional) true to prevent the default action too</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void swallowEvent(string eventName, bool preventDefault);

		/// <summary>Gets the parent node for this element, optionally chaining up trying to match a selector</summary>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void parent();

		/// <summary>Gets the parent node for this element, optionally chaining up trying to match a selector</summary>
		/// <param name="selector">(optional) Find a parent node that matches the passed simple selector</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void parent(string selector);

		/// <summary>Gets the parent node for this element, optionally chaining up trying to match a selector</summary>
		/// <param name="selector">(optional) Find a parent node that matches the passed simple selector</param>
		/// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void parent(string selector, bool returnDom);

		/// <summary>Gets the next sibling, skipping text nodes</summary>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void next();

		/// <summary>Gets the next sibling, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void next(string selector);

		/// <summary>Gets the next sibling, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
		/// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void next(string selector, bool returnDom);

		/// <summary>Gets the previous sibling, skipping text nodes</summary>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void prev();

		/// <summary>Gets the previous sibling, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void prev(string selector);

		/// <summary>Gets the previous sibling, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
		/// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void prev(string selector, bool returnDom);

		/// <summary>Gets the first child, skipping text nodes</summary>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void first();

		/// <summary>Gets the first child, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void first(string selector);

		/// <summary>Gets the first child, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the next sibling that matches the passed simple selector</param>
		/// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void first(string selector, bool returnDom);

		/// <summary>Gets the last child, skipping text nodes</summary>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void last();

		/// <summary>Gets the last child, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void last(string selector);

		/// <summary>Gets the last child, skipping text nodes</summary>
		/// <param name="selector">(optional) Find the previous sibling that matches the passed simple selector</param>
		/// <param name="returnDom">(optional) True to return a raw dom node instead of an Ext.Element</param>
		/// <returns>Ext.Element/HTMLElement</returns>
		public extern virtual void last(string selector, bool returnDom);

		/// <summary>Appends the passed element(s) to this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendChild();

		/// <summary>Appends the passed element(s) to this element</summary>
		/// <param name="el"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendChild(string el);

		/// <summary>Appends the passed element(s) to this element</summary>
		/// <param name="el"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendChild(DOMElement el);

		/// <summary>Appends the passed element(s) to this element</summary>
		/// <param name="el"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendChild(System.Array el);

		/// <summary>Appends the passed element(s) to this element</summary>
		/// <param name="el"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendChild(Element el);

		/// <summary>Appends the passed element(s) to this element</summary>
		/// <param name="el"></param>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendChild(CompositeElement el);

		/// <summary>
		///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
		///     automatically generated with the specified attributes.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void createChild();

		/// <summary>
		///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
		///     automatically generated with the specified attributes.
		/// </summary>
		/// <param name="config">DomHelper element config object.  If no tag is specified (e.g., {tag:'input'}) then a div will be</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createChild(object config);

		/// <summary>
		///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
		///     automatically generated with the specified attributes.
		/// </summary>
		/// <param name="config">DomHelper element config object.  If no tag is specified (e.g., {tag:'input'}) then a div will be</param>
		/// <param name="insertBefore">(optional) a child element of this element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createChild(object config, DOMElement insertBefore);

		/// <summary>
		///     Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
		///     automatically generated with the specified attributes.
		/// </summary>
		/// <param name="config">DomHelper element config object.  If no tag is specified (e.g., {tag:'input'}) then a div will be</param>
		/// <param name="insertBefore">(optional) a child element of this element</param>
		/// <param name="returnDom">(optional) true to return the dom node instead of creating an Element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void createChild(object config, DOMElement insertBefore, bool returnDom);

		/// <summary>Appends this element to the passed element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendTo();

		/// <summary>Appends this element to the passed element</summary>
		/// <param name="el">The new parent element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void appendTo(object el);

		/// <summary>Inserts this element before the passed element in the DOM</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertBefore();

		/// <summary>Inserts this element before the passed element in the DOM</summary>
		/// <param name="el">The element before which this element will be inserted</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertBefore(object el);

		/// <summary>Inserts this element after the passed element in the DOM</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertAfter();

		/// <summary>Inserts this element after the passed element in the DOM</summary>
		/// <param name="el">The element to insert after</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertAfter(object el);

		/// <summary>Inserts (or creates) an element (or DomHelper config) as the first child of this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertFirst();

		/// <summary>Inserts (or creates) an element (or DomHelper config) as the first child of this element</summary>
		/// <param name="el">The id or element to insert or a DomHelper config to create and insert</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertFirst(object el);

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling();

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling(object el);

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
		/// <param name="where">(optional) 'before' or 'after' defaults to before</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling(object el, string where);

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
		/// <param name="where">(optional) 'before' or 'after' defaults to before</param>
		/// <param name="returnDom">(optional) True to return the raw DOM element instead of Ext.Element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling(object el, string where, bool returnDom);

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling(System.Array el);

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
		/// <param name="where">(optional) 'before' or 'after' defaults to before</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling(System.Array el, string where);

		/// <summary>Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element</summary>
		/// <param name="el">The id, element to insert or a DomHelper config to create and insert *or* an array of any of those.</param>
		/// <param name="where">(optional) 'before' or 'after' defaults to before</param>
		/// <param name="returnDom">(optional) True to return the raw DOM element instead of Ext.Element</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void insertSibling(System.Array el, string where, bool returnDom);

		/// <summary>Creates and wraps this element with another element</summary>
		/// <returns>HTMLElement/Element</returns>
		public extern virtual void wrap();

		/// <summary>Creates and wraps this element with another element</summary>
		/// <param name="config">(optional) DomHelper element config object for the wrapper element or null for an empty div</param>
		/// <returns>HTMLElement/Element</returns>
		public extern virtual void wrap(object config);

		/// <summary>Creates and wraps this element with another element</summary>
		/// <param name="config">(optional) DomHelper element config object for the wrapper element or null for an empty div</param>
		/// <param name="returnDom">(optional) True to return the raw DOM element instead of Ext.Element</param>
		/// <returns>HTMLElement/Element</returns>
		public extern virtual void wrap(object config, bool returnDom);

		/// <summary>Replaces the passed element with this element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void replace();

		/// <summary>Replaces the passed element with this element</summary>
		/// <param name="el">The element to replace</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void replace(object el);

		/// <summary>Replaces this element with the passed element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void replaceWith();

		/// <summary>Replaces this element with the passed element</summary>
		/// <param name="el">The new element or a DomHelper config of an element to create</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void replaceWith(object el);

		/// <summary>Inserts an html fragment into this element</summary>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertHtml();

		/// <summary>Inserts an html fragment into this element</summary>
		/// <param name="where">Where to insert the html in relation to this element - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertHtml(string where);

		/// <summary>Inserts an html fragment into this element</summary>
		/// <param name="where">Where to insert the html in relation to this element - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
		/// <param name="html">The HTML fragment</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertHtml(string where, string html);

		/// <summary>Inserts an html fragment into this element</summary>
		/// <param name="where">Where to insert the html in relation to this element - beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
		/// <param name="html">The HTML fragment</param>
		/// <param name="returnEl">(optional) True to return an Ext.Element (defaults to false)</param>
		/// <returns>HTMLElement/Ext.Element</returns>
		public extern virtual void insertHtml(string where, string html, bool returnEl);

		/// <summary>Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void set();

		/// <summary>Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)</summary>
		/// <param name="o">The object with the attributes</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void set(object o);

		/// <summary>Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)</summary>
		/// <param name="o">The object with the attributes</param>
		/// <param name="useSet">(optional) false to override the default setAttribute to use expandos.</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void set(object o, bool useSet);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener();

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(double key);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(double key, Delegate fn);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(double key, Delegate fn, object scope);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(System.Array key);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(System.Array key, Delegate fn);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(System.Array key, Delegate fn, object scope);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(object key);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(object key, Delegate fn);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(object key, Delegate fn, object scope);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(string key);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(string key, Delegate fn);

		/// <summary>
		///     Convenience method for constructing a KeyMap
		///     {key: (number or array), shift: (true/false), ctrl: (true/false), alt: (true/false)}
		/// </summary>
		/// <param name="key">Either a string with the keys to listen for, the numeric key code, array of key codes or an object with the following options:</param>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyListener(string key, Delegate fn, object scope);

		/// <summary>Creates a KeyMap for this element</summary>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyMap();

		/// <summary>Creates a KeyMap for this element</summary>
		/// <param name="config">The KeyMap config. See {@link Ext.KeyMap} for more details</param>
		/// <returns>Ext.KeyMap</returns>
		public extern virtual void addKeyMap(object config);

		/// <summary>Returns true if this element is scrollable.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isScrollable();

		/// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
		/// <returns>Element</returns>
		public extern virtual void scrollTo();

		/// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
		/// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
		/// <returns>Element</returns>
		public extern virtual void scrollTo(string side);

		/// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
		/// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
		/// <param name="value">The new scroll value</param>
		/// <returns>Element</returns>
		public extern virtual void scrollTo(string side, double value);

		/// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
		/// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
		/// <param name="value">The new scroll value</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Element</returns>
		public extern virtual void scrollTo(string side, double value, bool animate);

		/// <summary>Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().</summary>
		/// <param name="side">Either "left" for scrollLeft values or "top" for scrollTop values.</param>
		/// <param name="value">The new scroll value</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Element</returns>
		public extern virtual void scrollTo(string side, double value, object animate);

		/// <summary>
		///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
		///     within this element's scrollable range.
		///     was scrolled as far as it could go.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void scroll();

		/// <summary>
		///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
		///     within this element's scrollable range.
		///     was scrolled as far as it could go.
		/// </summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <returns>Boolean</returns>
		public extern virtual void scroll(string direction);

		/// <summary>
		///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
		///     within this element's scrollable range.
		///     was scrolled as far as it could go.
		/// </summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <param name="distance">How far to scroll the element in pixels</param>
		/// <returns>Boolean</returns>
		public extern virtual void scroll(string direction, double distance);

		/// <summary>
		///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
		///     within this element's scrollable range.
		///     was scrolled as far as it could go.
		/// </summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <param name="distance">How far to scroll the element in pixels</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Boolean</returns>
		public extern virtual void scroll(string direction, double distance, bool animate);

		/// <summary>
		///     Scrolls this element the specified direction. Does bounds checking to make sure the scroll is
		///     within this element's scrollable range.
		///     was scrolled as far as it could go.
		/// </summary>
		/// <param name="direction">Possible values are: "l" (or "left"), "r" (or "right"), "t" (or "top", or "up"), "b" (or "bottom", or "down").</param>
		/// <param name="distance">How far to scroll the element in pixels</param>
		/// <param name="animate">(optional) true for the default animation or a standard Element animation config object</param>
		/// <returns>Boolean</returns>
		public extern virtual void scroll(string direction, double distance, object animate);

		/// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
		/// <returns>Object</returns>
		public extern virtual void translatePoints();

		/// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
		/// <param name="x">The page x or an array containing [x, y]</param>
		/// <returns>Object</returns>
		public extern virtual void translatePoints(double x);

		/// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
		/// <param name="x">The page x or an array containing [x, y]</param>
		/// <param name="y">(optional) The page y, required if x is not an array</param>
		/// <returns>Object</returns>
		public extern virtual void translatePoints(double x, double y);

		/// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
		/// <param name="x">The page x or an array containing [x, y]</param>
		/// <returns>Object</returns>
		public extern virtual void translatePoints(System.Array x);

		/// <summary>Translates the passed page coordinates into left/top css values for this element</summary>
		/// <param name="x">The page x or an array containing [x, y]</param>
		/// <param name="y">(optional) The page y, required if x is not an array</param>
		/// <returns>Object</returns>
		public extern virtual void translatePoints(System.Array x, double y);

		/// <summary>Returns the current scroll position of the element.</summary>
		/// <returns>Object</returns>
		public extern virtual void getScroll();

		/// <summary>
		///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
		///     are convert to standard 6 digit hex color.
		///     color anims.
		/// </summary>
		/// <returns></returns>
		public extern virtual void getColor();

		/// <summary>
		///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
		///     are convert to standard 6 digit hex color.
		///     color anims.
		/// </summary>
		/// <param name="attr">The css attribute</param>
		/// <returns></returns>
		public extern virtual void getColor(string attr);

		/// <summary>
		///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
		///     are convert to standard 6 digit hex color.
		///     color anims.
		/// </summary>
		/// <param name="attr">The css attribute</param>
		/// <param name="defaultValue">The default value to use when a valid color isn't found</param>
		/// <returns></returns>
		public extern virtual void getColor(string attr, string defaultValue);

		/// <summary>
		///     Return the CSS color for the specified CSS attribute. rgb, 3 digit (like #fff) and valid values
		///     are convert to standard 6 digit hex color.
		///     color anims.
		/// </summary>
		/// <param name="attr">The css attribute</param>
		/// <param name="defaultValue">The default value to use when a valid color isn't found</param>
		/// <param name="prefix">(optional) defaults to #. Use an empty string when working with</param>
		/// <returns></returns>
		public extern virtual void getColor(string attr, string defaultValue, string prefix);

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
		public extern virtual void boxWrap();

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
		public extern virtual void boxWrap(string cls);

		/// <summary>Returns the value of a namespaced attribute from the element's underlying DOM node.</summary>
		/// <returns>String</returns>
		public extern virtual void getAttributeNS();

		/// <summary>Returns the value of a namespaced attribute from the element's underlying DOM node.</summary>
		/// <param name="ns">The namespace in which to look for the attribute</param>
		/// <returns>String</returns>
		public extern virtual void getAttributeNS(string ns);

		/// <summary>Returns the value of a namespaced attribute from the element's underlying DOM node.</summary>
		/// <param name="ns">The namespace in which to look for the attribute</param>
		/// <param name="name">The attribute name</param>
		/// <returns>String</returns>
		public extern virtual void getAttributeNS(string ns, string name);

		/// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
		/// <returns>Number</returns>
		public extern virtual void getTextWidth();

		/// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
		/// <param name="text">The text to measure. Defaults to the innerHTML of the element.</param>
		/// <returns>Number</returns>
		public extern virtual void getTextWidth(string text);

		/// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
		/// <param name="text">The text to measure. Defaults to the innerHTML of the element.</param>
		/// <param name="min">(Optional) The minumum value to return.</param>
		/// <returns>Number</returns>
		public extern virtual void getTextWidth(string text, double min);

		/// <summary>Returns the width in pixels of the passed text, or the width of the text in this Element.</summary>
		/// <param name="text">The text to measure. Defaults to the innerHTML of the element.</param>
		/// <param name="min">(Optional) The minumum value to return.</param>
		/// <param name="max">(Optional) The maximum value to return.</param>
		/// <returns>Number</returns>
		public extern virtual void getTextWidth(string text, double min, double max);

		/// <summary>
		///     Static method to retrieve Ext.Element objects.
		///     <p><b>This method does not retrieve {@link Ext.Component Component}s.</b> This method
		///     retrieves Ext.Element objects which encapsulate DOM elements. To retrieve a Component by
		///     its ID, use {@link Ext.ComponentMgr#get}.</p>
		///     <p>Uses simple caching to consistently return the same object.
		///     Automatically fixes if an object was recreated with the same id via AJAX or DOM.</p>
		/// </summary>
		/// <returns>Element</returns>
		public extern static void get();

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
		public extern static void get(object el);

		/// <summary>
		///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
		///     the dom node can be overwritten by other code.
		///     prevent conflicts (e.g. internally Ext uses "_internal")
		/// </summary>
		/// <returns>Element</returns>
		public extern static void fly();

		/// <summary>
		///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
		///     the dom node can be overwritten by other code.
		///     prevent conflicts (e.g. internally Ext uses "_internal")
		/// </summary>
		/// <param name="el">The dom node or id</param>
		/// <returns>Element</returns>
		public extern static void fly(string el);

		/// <summary>
		///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
		///     the dom node can be overwritten by other code.
		///     prevent conflicts (e.g. internally Ext uses "_internal")
		/// </summary>
		/// <param name="el">The dom node or id</param>
		/// <param name="named">(optional) Allows for creation of named reusable flyweights to</param>
		/// <returns>Element</returns>
		public extern static void fly(string el, string named);

		/// <summary>
		///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
		///     the dom node can be overwritten by other code.
		///     prevent conflicts (e.g. internally Ext uses "_internal")
		/// </summary>
		/// <param name="el">The dom node or id</param>
		/// <returns>Element</returns>
		public extern static void fly(DOMElement el);

		/// <summary>
		///     Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element -
		///     the dom node can be overwritten by other code.
		///     prevent conflicts (e.g. internally Ext uses "_internal")
		/// </summary>
		/// <param name="el">The dom node or id</param>
		/// <param name="named">(optional) Allows for creation of named reusable flyweights to</param>
		/// <returns>Element</returns>
		public extern static void fly(DOMElement el, string named);



	}
}
