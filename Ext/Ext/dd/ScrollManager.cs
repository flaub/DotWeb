using System;
using H8.Support;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     <p>Provides automatic scrolling of overflow regions in the page during drag operations.</p>
    ///     <p>The ScrollManager configs will be used as the defaults for any scroll container registered with it,
    ///     but you can also override most of the configs per scroll container by adding a
    ///     <tt>ddScrollConfig</tt> object to the target element that contains these properties: {@link #hthresh},
    ///     {@link #vthresh}, {@link #increment} and {@link #frequency}.  Example usage:
    ///     <pre><code>
    ///     var el = Ext.get('scroll-ct');
    ///     el.ddScrollConfig = {
    ///     vthresh: 50,
    ///     hthresh: -1,
    ///     frequency: 100,
    ///     increment: 200
    ///     };
    ///     Ext.dd.ScrollManager.register(el);
    ///     </code></pre>
    ///     <b>Note: This class uses "Point Mode" and is untested in "Intersect Mode".</b>
    ///     */
    ///     Ext.dd.ScrollManager = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\ScrollManager.js</jssource>
    [Native]
    public class ScrollManager  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public ScrollManager() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static ScrollManager prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>
        ///     The number of pixels from the top or bottom edge of a container the pointer needs to be to
        ///     trigger scrolling (defaults to 25)
        /// </summary>
        public static double vthresh { get { return 0; } set { } }

        /// <summary>
        ///     The number of pixels from the right or left edge of a container the pointer needs to be to
        ///     trigger scrolling (defaults to 25)
        /// </summary>
        public static double hthresh { get { return 0; } set { } }

        /// <summary>The number of pixels to scroll in each scroll increment (defaults to 50)</summary>
        public static double increment { get { return 0; } set { } }

        /// <summary>The frequency of scrolls in milliseconds (defaults to 500)</summary>
        public static double frequency { get { return 0; } set { } }

        /// <summary>True to animate the scroll (defaults to true)</summary>
        public static bool animate { get { return false; } set { } }

        /// <summary>
        ///     The animation duration in seconds -
        ///     MUST BE less than Ext.dd.ScrollManager.frequency! (defaults to .4)
        /// </summary>
        public static double animDuration { get { return 0; } set { } }


        /// <summary>Registers new overflow element(s) to auto scroll</summary>
        /// <returns></returns>
        public static void register() { return ; }

        /// <summary>Registers new overflow element(s) to auto scroll</summary>
        /// <param name="el">The id of or the element to be scrolled or an array of either</param>
        /// <returns></returns>
        public static void register(object el) { return ; }

        /// <summary>Registers new overflow element(s) to auto scroll</summary>
        /// <param name="el">The id of or the element to be scrolled or an array of either</param>
        /// <returns></returns>
        public static void register(System.Array el) { return ; }

        /// <summary>Unregisters overflow element(s) so they are no longer scrolled</summary>
        /// <returns></returns>
        public static void unregister() { return ; }

        /// <summary>Unregisters overflow element(s) so they are no longer scrolled</summary>
        /// <param name="el">The id of or the element to be removed or an array of either</param>
        /// <returns></returns>
        public static void unregister(object el) { return ; }

        /// <summary>Unregisters overflow element(s) so they are no longer scrolled</summary>
        /// <param name="el">The id of or the element to be removed or an array of either</param>
        /// <returns></returns>
        public static void unregister(System.Array el) { return ; }

        /// <summary>Manually trigger a cache refresh.</summary>
        /// <returns></returns>
        public static void refreshCache() { return ; }



    }
    [Anonymous]
    public class ScrollManagerConfig {

    }


}
