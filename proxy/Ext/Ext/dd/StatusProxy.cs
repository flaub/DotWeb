using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     A specialized drag proxy that supports a drop status icon, {@link Ext.Layer} styles and auto-repair.  This is the
	///     default drag proxy used by all Ext.dd components.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\dd\StatusProxy.js</jssource>
	public class StatusProxy : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern StatusProxy();
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern StatusProxy(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static StatusProxy prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The CSS class to apply to the status element when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public extern string dropAllowed { get; set; }

		/// <summary>The CSS class to apply to the status element when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public extern string dropNotAllowed { get; set; }


		/// <summary>
		///     Updates the proxy's visual element to indicate the status of whether or not drop is allowed
		///     over the current target element.
		/// </summary>
		/// <returns></returns>
		public extern virtual void setStatus();

		/// <summary>
		///     Updates the proxy's visual element to indicate the status of whether or not drop is allowed
		///     over the current target element.
		/// </summary>
		/// <param name="cssClass">The css class for the new drop status indicator image</param>
		/// <returns></returns>
		public extern virtual void setStatus(string cssClass);

		/// <summary>Resets the status indicator to the default dropNotAllowed value</summary>
		/// <returns></returns>
		public extern virtual void reset();

		/// <summary>Resets the status indicator to the default dropNotAllowed value</summary>
		/// <param name="clearGhost">True to also remove all content from the ghost, false to preserve it</param>
		/// <returns></returns>
		public extern virtual void reset(bool clearGhost);

		/// <summary>
		///     Updates the contents of the ghost element
		///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
		/// </summary>
		/// <returns></returns>
		public extern virtual void update();

		/// <summary>
		///     Updates the contents of the ghost element
		///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
		/// </summary>
		/// <param name="html">The html that will replace the current innerHTML of the ghost element, or a</param>
		/// <returns></returns>
		public extern virtual void update(string html);

		/// <summary>
		///     Updates the contents of the ghost element
		///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
		/// </summary>
		/// <param name="html">The html that will replace the current innerHTML of the ghost element, or a</param>
		/// <returns></returns>
		public extern virtual void update(DOMElement html);

		/// <summary>Returns the underlying proxy {@link Ext.Layer}</summary>
		/// <returns>Ext.Layer</returns>
		public extern virtual void getEl();

		/// <summary>Returns the ghost element</summary>
		/// <returns>Ext.Element</returns>
		public extern virtual void getGhost();

		/// <summary>Hides the proxy</summary>
		/// <returns></returns>
		public extern virtual void hide();

		/// <summary>Hides the proxy</summary>
		/// <param name="clear">True to reset the status and clear the ghost contents, false to preserve them</param>
		/// <returns></returns>
		public extern virtual void hide(bool clear);

		/// <summary>Stops the repair animation if it's currently running</summary>
		/// <returns></returns>
		public extern virtual void stop();

		/// <summary>Displays this proxy</summary>
		/// <returns></returns>
		public extern virtual void show();

		/// <summary>Force the Layer to sync its shadow and shim positions to the element</summary>
		/// <returns></returns>
		public extern virtual void sync();

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <returns></returns>
		public extern virtual void repair();

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <param name="xy">The XY position of the element ([x, y])</param>
		/// <returns></returns>
		public extern virtual void repair(System.Array xy);

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <param name="xy">The XY position of the element ([x, y])</param>
		/// <param name="callback">The function to call after the repair is complete</param>
		/// <returns></returns>
		public extern virtual void repair(System.Array xy, Delegate callback);

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <param name="xy">The XY position of the element ([x, y])</param>
		/// <param name="callback">The function to call after the repair is complete</param>
		/// <param name="scope">The scope in which to execute the callback</param>
		/// <returns></returns>
		public extern virtual void repair(System.Array xy, Delegate callback, object scope);



	}

	[JsAnonymous]
	public class StatusProxyConfig : System.DotWeb.JsDynamic {
		/// <summary>  The CSS class to apply to the status element when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return (string)this["dropAllowed"]; } set { this["dropAllowed"] = value; } }

		/// <summary>  The CSS class to apply to the status element when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return (string)this["dropNotAllowed"]; } set { this["dropNotAllowed"] = value; } }

	}
}
