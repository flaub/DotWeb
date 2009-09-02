using System;
using DotWeb.Client;

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
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\dd\ScrollManager.js</jssource>
	public class ScrollManager : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public ScrollManager() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static ScrollManager prototype { get { return S_<ScrollManager>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>
		///     The number of pixels from the top or bottom edge of a container the pointer needs to be to
		///     trigger scrolling (defaults to 25)
		/// </summary>
		public static double vthresh { get { return S_<double>(); } set { S_(value); } }

		/// <summary>
		///     The number of pixels from the right or left edge of a container the pointer needs to be to
		///     trigger scrolling (defaults to 25)
		/// </summary>
		public static double hthresh { get { return S_<double>(); } set { S_(value); } }

		/// <summary>The number of pixels to scroll in each scroll increment (defaults to 50)</summary>
		public static double increment { get { return S_<double>(); } set { S_(value); } }

		/// <summary>The frequency of scrolls in milliseconds (defaults to 500)</summary>
		public static double frequency { get { return S_<double>(); } set { S_(value); } }

		/// <summary>True to animate the scroll (defaults to true)</summary>
		public static bool animate { get { return S_<bool>(); } set { S_(value); } }

		/// <summary>
		///     The animation duration in seconds -
		///     MUST BE less than Ext.dd.ScrollManager.frequency! (defaults to .4)
		/// </summary>
		public static double animDuration { get { return S_<double>(); } set { S_(value); } }


		/// <summary>Registers new overflow element(s) to auto scroll</summary>
		/// <returns></returns>
		public static void register() { S_(); }

		/// <summary>Registers new overflow element(s) to auto scroll</summary>
		/// <param name="el">The id of or the element to be scrolled or an array of either</param>
		/// <returns></returns>
		public static void register(object el) { S_(el); }

		/// <summary>Registers new overflow element(s) to auto scroll</summary>
		/// <param name="el">The id of or the element to be scrolled or an array of either</param>
		/// <returns></returns>
		public static void register(System.Array el) { S_(el); }

		/// <summary>Unregisters overflow element(s) so they are no longer scrolled</summary>
		/// <returns></returns>
		public static void unregister() { S_(); }

		/// <summary>Unregisters overflow element(s) so they are no longer scrolled</summary>
		/// <param name="el">The id of or the element to be removed or an array of either</param>
		/// <returns></returns>
		public static void unregister(object el) { S_(el); }

		/// <summary>Unregisters overflow element(s) so they are no longer scrolled</summary>
		/// <param name="el">The id of or the element to be removed or an array of either</param>
		/// <returns></returns>
		public static void unregister(System.Array el) { S_(el); }

		/// <summary>Manually trigger a cache refresh.</summary>
		/// <returns></returns>
		public static void refreshCache() { S_(); }



	}
}
