using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>A class to provide basic animation and visual effects support.  <b>Note:</b> This class is automatically applied
	///     to the {@link Ext.Element} interface when included, so all effects calls should be performed via Element.
	///     Conversely, since the effects are not actually defined in Element, Ext.Fx <b>must</b> be included in order for the
	///     Element effects to work.</p><br/>
	///     <p>It is important to note that although the Fx methods and many non-Fx Element methods support "method chaining" in that
	///     they return the Element object itself as the method return value, it is not always possible to mix the two in a single
	///     method chain.  The Fx methods use an internal effects queue so that each effect can be properly timed and sequenced.
	///     Non-Fx methods, on the other hand, have no such internal queueing and will always execute immediately.  For this reason,
	///     while it may be possible to mix certain Fx and non-Fx method calls in a single chain, it may not always provide the
	///     expected results and should be done with care.</p><br/>
	///     <p>Motion effects support 8-way anchoring, meaning that you can choose one of 8 different anchor points on the Element
	///     that will serve as either the start or end point of the animation.  Following are all of the supported anchor positions:</p>
	///     <pre>
	///     Value  Description
	///     -----  -----------------------------
	///     tl     The top left corner
	///     t      The center of the top edge
	///     tr     The top right corner
	///     l      The center of the left edge
	///     r      The center of the right edge
	///     bl     The bottom left corner
	///     b      The center of the bottom edge
	///     br     The bottom right corner
	///     </pre>
	///     <b>Although some Fx methods accept specific custom config parameters, the ones shown in the Config Options section
	///     below are common options that can be passed to any Fx method.</b>
	///     @cfg {Function} callback A function called when the effect is finished.  Note that effects are queued internally by the
	///     Fx class, so do not need to use the callback parameter to specify another effect -- effects can simply be chained together
	///     and called in sequence (e.g., el.slideIn().highlight();).  The callback is intended for any additional code that should
	///     run once a particular effect has completed. The Element being operated upon is passed as the first parameter.
	///     @cfg {Object} scope The scope of the effect function
	///     @cfg {String} easing A valid Easing value for the effect
	///     @cfg {String} afterCls A css class to apply after the effect
	///     @cfg {Number} duration The length of time (in seconds) that the effect should last
	///     @cfg {Boolean} remove Whether the Element should be removed from the DOM and destroyed after the effect finishes
	///     @cfg {Boolean} useDisplay Whether to use the <i>display</i> CSS property instead of <i>visibility</i> when hiding Elements (only applies to
	///     effects that end with the element being visually hidden, ignored otherwise)
	///     @cfg {String/Object/Function} afterStyle A style specification string, e.g. "width:100px", or an object in the form {width:"100px"}, or
	///     a function which returns such a specification that will be applied to the Element after the effect finishes
	///     @cfg {Boolean} block Whether the effect should block other effects from queueing while it runs
	///     @cfg {Boolean} concurrent Whether to allow subsequently-queued effects to run at the same time as the current effect, or to ensure that they run in sequence
	///     @cfg {Boolean} stopFx Whether subsequent effects should be stopped and removed after the current effect finishes
	///     */
	///     Ext.Fx = {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\Fx.js</jssource>
	public class Fx : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern Fx();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Fx prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>
		///     Slides the element into view.  An anchor point can be optionally passed to set the point of
		///     origin for the slide effect.  This function automatically handles wrapping the element with
		///     a fixed-size container if needed.  See the Fx class overview for valid anchor point options.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element in from the top
		///     el.slideIn();
		///     // custom: slide the element in from the right with a 2-second duration
		///     el.slideIn('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.slideIn('t', {
		///     easing: 'easeOut',
		///     duration: .5
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void slideIn();

		/// <summary>
		///     Slides the element into view.  An anchor point can be optionally passed to set the point of
		///     origin for the slide effect.  This function automatically handles wrapping the element with
		///     a fixed-size container if needed.  See the Fx class overview for valid anchor point options.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element in from the top
		///     el.slideIn();
		///     // custom: slide the element in from the right with a 2-second duration
		///     el.slideIn('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.slideIn('t', {
		///     easing: 'easeOut',
		///     duration: .5
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to top: 't')</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void slideIn(string anchor);

		/// <summary>
		///     Slides the element into view.  An anchor point can be optionally passed to set the point of
		///     origin for the slide effect.  This function automatically handles wrapping the element with
		///     a fixed-size container if needed.  See the Fx class overview for valid anchor point options.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element in from the top
		///     el.slideIn();
		///     // custom: slide the element in from the right with a 2-second duration
		///     el.slideIn('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.slideIn('t', {
		///     easing: 'easeOut',
		///     duration: .5
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to top: 't')</param>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void slideIn(string anchor, object options);

		/// <summary>
		///     Slides the element out of view.  An anchor point can be optionally passed to set the end point
		///     for the slide effect.  When the effect is completed, the element will be hidden (visibility =
		///     'hidden') but block elements will still take up space in the document.  The element must be removed
		///     from the DOM using the 'remove' config option if desired.  This function automatically handles
		///     wrapping the element with a fixed-size container if needed.  See the Fx class overview for valid anchor point options.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element out to the top
		///     el.slideOut();
		///     // custom: slide the element out to the right with a 2-second duration
		///     el.slideOut('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.slideOut('t', {
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void slideOut();

		/// <summary>
		///     Slides the element out of view.  An anchor point can be optionally passed to set the end point
		///     for the slide effect.  When the effect is completed, the element will be hidden (visibility =
		///     'hidden') but block elements will still take up space in the document.  The element must be removed
		///     from the DOM using the 'remove' config option if desired.  This function automatically handles
		///     wrapping the element with a fixed-size container if needed.  See the Fx class overview for valid anchor point options.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element out to the top
		///     el.slideOut();
		///     // custom: slide the element out to the right with a 2-second duration
		///     el.slideOut('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.slideOut('t', {
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to top: 't')</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void slideOut(string anchor);

		/// <summary>
		///     Slides the element out of view.  An anchor point can be optionally passed to set the end point
		///     for the slide effect.  When the effect is completed, the element will be hidden (visibility =
		///     'hidden') but block elements will still take up space in the document.  The element must be removed
		///     from the DOM using the 'remove' config option if desired.  This function automatically handles
		///     wrapping the element with a fixed-size container if needed.  See the Fx class overview for valid anchor point options.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element out to the top
		///     el.slideOut();
		///     // custom: slide the element out to the right with a 2-second duration
		///     el.slideOut('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.slideOut('t', {
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to top: 't')</param>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void slideOut(string anchor, object options);

		/// <summary>
		///     Fades the element out while slowly expanding it in all directions.  When the effect is completed, the
		///     element will be hidden (visibility = 'hidden') but block elements will still take up space in the document.
		///     The element must be removed from the DOM using the 'remove' config option if desired.
		///     Usage:
		///     <pre><code>
		///     // default
		///     el.puff();
		///     // common config options shown with default values
		///     el.puff({
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void puff();

		/// <summary>
		///     Fades the element out while slowly expanding it in all directions.  When the effect is completed, the
		///     element will be hidden (visibility = 'hidden') but block elements will still take up space in the document.
		///     The element must be removed from the DOM using the 'remove' config option if desired.
		///     Usage:
		///     <pre><code>
		///     // default
		///     el.puff();
		///     // common config options shown with default values
		///     el.puff({
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void puff(object options);

		/// <summary>
		///     Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television).
		///     When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still
		///     take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.
		///     Usage:
		///     <pre><code>
		///     // default
		///     el.switchOff();
		///     // all config options shown with default values
		///     el.switchOff({
		///     easing: 'easeIn',
		///     duration: .3,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void switchOff();

		/// <summary>
		///     Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television).
		///     When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still
		///     take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.
		///     Usage:
		///     <pre><code>
		///     // default
		///     el.switchOff();
		///     // all config options shown with default values
		///     el.switchOff({
		///     easing: 'easeIn',
		///     duration: .3,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void switchOff(object options);

		/// <summary>
		///     Highlights the Element by setting a color (applies to the background-color by default, but can be
		///     changed using the "attr" config option) and then fading back to the original color. If no original
		///     color is available, you should provide the "endColor" config option which will be cleared after the animation.
		///     Usage:
		///     <pre><code>
		///     // default: highlight background to yellow
		///     el.highlight();
		///     // custom: highlight foreground text to blue for 2 seconds
		///     el.highlight("0000ff", { attr: 'color', duration: 2 });
		///     // common config options shown with default values
		///     el.highlight("ffff9c", {
		///     attr: "background-color", //can be any valid CSS property (attribute) that supports a color value
		///     endColor: (current color) or "ffffff",
		///     easing: 'easeIn',
		///     duration: 1
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void highlight();

		/// <summary>
		///     Highlights the Element by setting a color (applies to the background-color by default, but can be
		///     changed using the "attr" config option) and then fading back to the original color. If no original
		///     color is available, you should provide the "endColor" config option which will be cleared after the animation.
		///     Usage:
		///     <pre><code>
		///     // default: highlight background to yellow
		///     el.highlight();
		///     // custom: highlight foreground text to blue for 2 seconds
		///     el.highlight("0000ff", { attr: 'color', duration: 2 });
		///     // common config options shown with default values
		///     el.highlight("ffff9c", {
		///     attr: "background-color", //can be any valid CSS property (attribute) that supports a color value
		///     endColor: (current color) or "ffffff",
		///     easing: 'easeIn',
		///     duration: 1
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="color">(optional) The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void highlight(string color);

		/// <summary>
		///     Highlights the Element by setting a color (applies to the background-color by default, but can be
		///     changed using the "attr" config option) and then fading back to the original color. If no original
		///     color is available, you should provide the "endColor" config option which will be cleared after the animation.
		///     Usage:
		///     <pre><code>
		///     // default: highlight background to yellow
		///     el.highlight();
		///     // custom: highlight foreground text to blue for 2 seconds
		///     el.highlight("0000ff", { attr: 'color', duration: 2 });
		///     // common config options shown with default values
		///     el.highlight("ffff9c", {
		///     attr: "background-color", //can be any valid CSS property (attribute) that supports a color value
		///     endColor: (current color) or "ffffff",
		///     easing: 'easeIn',
		///     duration: 1
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="color">(optional) The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')</param>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void highlight(string color, object options);

		/// <summary>
		///     Shows a ripple of exploding, attenuating borders to draw attention to an Element.
		///     Usage:
		///     <pre><code>
		///     // default: a single light blue ripple
		///     el.frame();
		///     // custom: 3 red ripples lasting 3 seconds total
		///     el.frame("ff0000", 3, { duration: 3 });
		///     // common config options shown with default values
		///     el.frame("C3DAF9", 1, {
		///     duration: 1 //duration of entire animation (not each individual ripple)
		///     // Note: Easing is not configurable and will be ignored if included
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void frame();

		/// <summary>
		///     Shows a ripple of exploding, attenuating borders to draw attention to an Element.
		///     Usage:
		///     <pre><code>
		///     // default: a single light blue ripple
		///     el.frame();
		///     // custom: 3 red ripples lasting 3 seconds total
		///     el.frame("ff0000", 3, { duration: 3 });
		///     // common config options shown with default values
		///     el.frame("C3DAF9", 1, {
		///     duration: 1 //duration of entire animation (not each individual ripple)
		///     // Note: Easing is not configurable and will be ignored if included
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="color">(optional) The color of the border.  Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void frame(string color);

		/// <summary>
		///     Shows a ripple of exploding, attenuating borders to draw attention to an Element.
		///     Usage:
		///     <pre><code>
		///     // default: a single light blue ripple
		///     el.frame();
		///     // custom: 3 red ripples lasting 3 seconds total
		///     el.frame("ff0000", 3, { duration: 3 });
		///     // common config options shown with default values
		///     el.frame("C3DAF9", 1, {
		///     duration: 1 //duration of entire animation (not each individual ripple)
		///     // Note: Easing is not configurable and will be ignored if included
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="color">(optional) The color of the border.  Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
		/// <param name="count">(optional) The number of ripples to display (defaults to 1)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void frame(string color, double count);

		/// <summary>
		///     Shows a ripple of exploding, attenuating borders to draw attention to an Element.
		///     Usage:
		///     <pre><code>
		///     // default: a single light blue ripple
		///     el.frame();
		///     // custom: 3 red ripples lasting 3 seconds total
		///     el.frame("ff0000", 3, { duration: 3 });
		///     // common config options shown with default values
		///     el.frame("C3DAF9", 1, {
		///     duration: 1 //duration of entire animation (not each individual ripple)
		///     // Note: Easing is not configurable and will be ignored if included
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="color">(optional) The color of the border.  Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
		/// <param name="count">(optional) The number of ripples to display (defaults to 1)</param>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void frame(string color, double count, object options);

		/// <summary>
		///     Creates a pause before any subsequent queued effects begin.  If there are
		///     no effects queued after the pause it will have no effect.
		///     Usage:
		///     <pre><code>
		///     el.pause(1);
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void pause();

		/// <summary>
		///     Creates a pause before any subsequent queued effects begin.  If there are
		///     no effects queued after the pause it will have no effect.
		///     Usage:
		///     <pre><code>
		///     el.pause(1);
		///     </code></pre>
		/// </summary>
		/// <param name="seconds">The length of time to pause (in seconds)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void pause(double seconds);

		/// <summary>
		///     Fade an element in (from transparent to opaque).  The ending opacity can be specified
		///     using the "endOpacity" config option.
		///     Usage:
		///     <pre><code>
		///     // default: fade in from opacity 0 to 100%
		///     el.fadeIn();
		///     // custom: fade in from opacity 0 to 75% over 2 seconds
		///     el.fadeIn({ endOpacity: .75, duration: 2});
		///     // common config options shown with default values
		///     el.fadeIn({
		///     endOpacity: 1, //can be any value between 0 and 1 (e.g. .5)
		///     easing: 'easeOut',
		///     duration: .5
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void fadeIn();

		/// <summary>
		///     Fade an element in (from transparent to opaque).  The ending opacity can be specified
		///     using the "endOpacity" config option.
		///     Usage:
		///     <pre><code>
		///     // default: fade in from opacity 0 to 100%
		///     el.fadeIn();
		///     // custom: fade in from opacity 0 to 75% over 2 seconds
		///     el.fadeIn({ endOpacity: .75, duration: 2});
		///     // common config options shown with default values
		///     el.fadeIn({
		///     endOpacity: 1, //can be any value between 0 and 1 (e.g. .5)
		///     easing: 'easeOut',
		///     duration: .5
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void fadeIn(object options);

		/// <summary>
		///     Fade an element out (from opaque to transparent).  The ending opacity can be specified
		///     using the "endOpacity" config option.  Note that IE may require useDisplay:true in order
		///     to redisplay correctly.
		///     Usage:
		///     <pre><code>
		///     // default: fade out from the element's current opacity to 0
		///     el.fadeOut();
		///     // custom: fade out from the element's current opacity to 25% over 2 seconds
		///     el.fadeOut({ endOpacity: .25, duration: 2});
		///     // common config options shown with default values
		///     el.fadeOut({
		///     endOpacity: 0, //can be any value between 0 and 1 (e.g. .5)
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void fadeOut();

		/// <summary>
		///     Fade an element out (from opaque to transparent).  The ending opacity can be specified
		///     using the "endOpacity" config option.  Note that IE may require useDisplay:true in order
		///     to redisplay correctly.
		///     Usage:
		///     <pre><code>
		///     // default: fade out from the element's current opacity to 0
		///     el.fadeOut();
		///     // custom: fade out from the element's current opacity to 25% over 2 seconds
		///     el.fadeOut({ endOpacity: .25, duration: 2});
		///     // common config options shown with default values
		///     el.fadeOut({
		///     endOpacity: 0, //can be any value between 0 and 1 (e.g. .5)
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void fadeOut(object options);

		/// <summary>
		///     Animates the transition of an element's dimensions from a starting height/width
		///     to an ending height/width.
		///     Usage:
		///     <pre><code>
		///     // change height and width to 100x100 pixels
		///     el.scale(100, 100);
		///     // common config options shown with default values.  The height and width will default to
		///     // the element's existing values if passed as null.
		///     el.scale(
		///     [element's width],
		///     [element's height], {
		///     easing: 'easeOut',
		///     duration: .35
		///     }
		///     );
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void scale();

		/// <summary>
		///     Animates the transition of an element's dimensions from a starting height/width
		///     to an ending height/width.
		///     Usage:
		///     <pre><code>
		///     // change height and width to 100x100 pixels
		///     el.scale(100, 100);
		///     // common config options shown with default values.  The height and width will default to
		///     // the element's existing values if passed as null.
		///     el.scale(
		///     [element's width],
		///     [element's height], {
		///     easing: 'easeOut',
		///     duration: .35
		///     }
		///     );
		///     </code></pre>
		/// </summary>
		/// <param name="width">The new width (pass undefined to keep the original width)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void scale(double width);

		/// <summary>
		///     Animates the transition of an element's dimensions from a starting height/width
		///     to an ending height/width.
		///     Usage:
		///     <pre><code>
		///     // change height and width to 100x100 pixels
		///     el.scale(100, 100);
		///     // common config options shown with default values.  The height and width will default to
		///     // the element's existing values if passed as null.
		///     el.scale(
		///     [element's width],
		///     [element's height], {
		///     easing: 'easeOut',
		///     duration: .35
		///     }
		///     );
		///     </code></pre>
		/// </summary>
		/// <param name="width">The new width (pass undefined to keep the original width)</param>
		/// <param name="height">The new height (pass undefined to keep the original height)</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void scale(double width, double height);

		/// <summary>
		///     Animates the transition of an element's dimensions from a starting height/width
		///     to an ending height/width.
		///     Usage:
		///     <pre><code>
		///     // change height and width to 100x100 pixels
		///     el.scale(100, 100);
		///     // common config options shown with default values.  The height and width will default to
		///     // the element's existing values if passed as null.
		///     el.scale(
		///     [element's width],
		///     [element's height], {
		///     easing: 'easeOut',
		///     duration: .35
		///     }
		///     );
		///     </code></pre>
		/// </summary>
		/// <param name="width">The new width (pass undefined to keep the original width)</param>
		/// <param name="height">The new height (pass undefined to keep the original height)</param>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void scale(double width, double height, object options);

		/// <summary>
		///     Animates the transition of any combination of an element's dimensions, xy position and/or opacity.
		///     Any of these properties not specified in the config object will not be changed.  This effect
		///     requires that at least one new dimension, position or opacity setting must be passed in on
		///     the config object in order for the function to have any effect.
		///     Usage:
		///     <pre><code>
		///     // slide the element horizontally to x position 200 while changing the height and opacity
		///     el.shift({ x: 200, height: 50, opacity: .8 });
		///     // common config options shown with default values.
		///     el.shift({
		///     width: [element's width],
		///     height: [element's height],
		///     x: [element's x position],
		///     y: [element's y position],
		///     opacity: [element's opacity],
		///     easing: 'easeOut',
		///     duration: .35
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void shift();

		/// <summary>
		///     Animates the transition of any combination of an element's dimensions, xy position and/or opacity.
		///     Any of these properties not specified in the config object will not be changed.  This effect
		///     requires that at least one new dimension, position or opacity setting must be passed in on
		///     the config object in order for the function to have any effect.
		///     Usage:
		///     <pre><code>
		///     // slide the element horizontally to x position 200 while changing the height and opacity
		///     el.shift({ x: 200, height: 50, opacity: .8 });
		///     // common config options shown with default values.
		///     el.shift({
		///     width: [element's width],
		///     height: [element's height],
		///     x: [element's x position],
		///     y: [element's y position],
		///     opacity: [element's opacity],
		///     easing: 'easeOut',
		///     duration: .35
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="options">Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void shift(object options);

		/// <summary>
		///     Slides the element while fading it out of view.  An anchor point can be optionally passed to set the
		///     ending point of the effect.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element downward while fading out
		///     el.ghost();
		///     // custom: slide the element out to the right with a 2-second duration
		///     el.ghost('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.ghost('b', {
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void ghost();

		/// <summary>
		///     Slides the element while fading it out of view.  An anchor point can be optionally passed to set the
		///     ending point of the effect.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element downward while fading out
		///     el.ghost();
		///     // custom: slide the element out to the right with a 2-second duration
		///     el.ghost('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.ghost('b', {
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to bottom: 'b')</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void ghost(string anchor);

		/// <summary>
		///     Slides the element while fading it out of view.  An anchor point can be optionally passed to set the
		///     ending point of the effect.
		///     Usage:
		///     <pre><code>
		///     // default: slide the element downward while fading out
		///     el.ghost();
		///     // custom: slide the element out to the right with a 2-second duration
		///     el.ghost('r', { duration: 2 });
		///     // common config options shown with default values
		///     el.ghost('b', {
		///     easing: 'easeOut',
		///     duration: .5,
		///     remove: false,
		///     useDisplay: false
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="anchor">(optional) One of the valid Fx anchor positions (defaults to bottom: 'b')</param>
		/// <param name="options">(optional) Object literal with any of the Fx config options</param>
		/// <returns>Ext.Element</returns>
		public extern virtual void ghost(string anchor, object options);

		/// <summary>
		///     Ensures that all effects queued after syncFx is called on the element are
		///     run concurrently.  This is the opposite of {@link #sequenceFx}.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void syncFx();

		/// <summary>
		///     Ensures that all effects queued after sequenceFx is called on the element are
		///     run in sequence.  This is the opposite of {@link #syncFx}.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void sequenceFx();

		/// <summary>Returns true if the element has any effects actively running or queued, else returns false.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasActiveFx();

		/// <summary>
		///     Stops any running effects and clears the element's internal effects queue if it contains
		///     any additional effects that haven't started yet.
		/// </summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void stopFx();

		/// <summary>
		///     Returns true if the element is currently blocking so that no other effect can be queued
		///     until this effect is finished, else returns false if blocking is not set.  This is commonly
		///     used to ensure that an effect initiated by a user action runs to completion prior to the
		///     same effect being restarted (e.g., firing only one effect even if the user clicks several times).
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasFxBlock();



	}

	[JsAnonymous]
	public class FxConfig : System.DotWeb.JsDynamic {
		/// <summary> @class Ext.Fx <p>A class to provide basic animation and visual effects support.  <b>Note:</b> This class is automatically applied to the {@link Ext.Element} interface when included, so all effects calls should be performed via Element. Conversely, since the effects are not actually defined in Element, Ext.Fx <b>must</b> be included in order for the Element effects to work.</p><br/> <p>It is important to note that although the Fx methods and many non-Fx Element methods support "method chaining" in that they return the Element object itself as the method return value, it is not always possible to mix the two in a single method chain.  The Fx methods use an internal effects queue so that each effect can be properly timed and sequenced. Non-Fx methods, on the other hand, have no such internal queueing and will always execute immediately.  For this reason, while it may be possible to mix certain Fx and non-Fx method calls in a single chain, it may not always provide the expected results and should be done with care.</p><br/> <p>Motion effects support 8-way anchoring, meaning that you can choose one of 8 different anchor points on the Element that will serve as either the start or end point of the animation.  Following are all of the supported anchor positions:</p> <pre> Value  Description -----  ----------------------------- tl     The top left corner t      The center of the top edge tr     The top right corner l      The center of the left edge r      The center of the right edge bl     The bottom left corner b      The center of the bottom edge br     The bottom right corner </pre> <b>Although some Fx methods accept specific custom config parameters, the ones shown in the Config Options section below are common options that can be passed to any Fx method.</b>A function called when the effect is finished.  Note that effects are queued internally by the Fx class, so do not need to use the callback parameter to specify another effect -- effects can simply be chained together and called in sequence (e.g., el.slideIn().highlight();).  The callback is intended for any additional code that should run once a particular effect has completed. The Element being operated upon is passed as the first parameter.The scope of the effect functionA valid Easing value for the effectA css class to apply after the effectThe length of time (in seconds) that the effect should lastWhether the Element should be removed from the DOM and destroyed after the effect finishesWhether to use the <i>display</i> CSS property instead of <i>visibility</i> when hiding Elements (only applies to effects that end with the element being visually hidden, ignored otherwise)A style specification string, e.g. "width:100px", or an object in the form {width:"100px"}, or a function which returns such a specification that will be applied to the Element after the effect finishesWhether the effect should block other effects from queueing while it runsWhether to allow subsequently-queued effects to run at the same time as the current effect, or to ensure that they run in sequenceWhether subsequent effects should be stopped and removed after the current effect finishes</summary>
		public bool stopFx { get { return (bool)this["stopFx"]; } set { this["stopFx"] = value; } }

	}
}
