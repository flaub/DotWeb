using System;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     A specialized drag proxy that supports a drop status icon, {@link Ext.Layer} styles and auto-repair.  This is the
	///     default drag proxy used by all Ext.dd components.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\dd\StatusProxy.js</jssource>
	public class StatusProxy : DotWeb.Client.JsNativeBase {

		/// <summary></summary>
		/// <returns></returns>
		public StatusProxy() { C_(); }
		/// <summary></summary>
		/// <param name="config"></param>
		/// <returns></returns>
		public StatusProxy(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static StatusProxy prototype { get { return S_<StatusProxy>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The CSS class to apply to the status element when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public System.String dropAllowed { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The CSS class to apply to the status element when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public System.String dropNotAllowed { get { return _<System.String>(); } set { _(value); } }


		/// <summary>
		///     Updates the proxy's visual element to indicate the status of whether or not drop is allowed
		///     over the current target element.
		/// </summary>
		/// <returns></returns>
		public virtual void setStatus() { _(); }

		/// <summary>
		///     Updates the proxy's visual element to indicate the status of whether or not drop is allowed
		///     over the current target element.
		/// </summary>
		/// <param name="cssClass">The css class for the new drop status indicator image</param>
		/// <returns></returns>
		public virtual void setStatus(System.String cssClass) { _(cssClass); }

		/// <summary>Resets the status indicator to the default dropNotAllowed value</summary>
		/// <returns></returns>
		public virtual void reset() { _(); }

		/// <summary>Resets the status indicator to the default dropNotAllowed value</summary>
		/// <param name="clearGhost">True to also remove all content from the ghost, false to preserve it</param>
		/// <returns></returns>
		public virtual void reset(bool clearGhost) { _(clearGhost); }

		/// <summary>
		///     Updates the contents of the ghost element
		///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
		/// </summary>
		/// <returns></returns>
		public virtual void update() { _(); }

		/// <summary>
		///     Updates the contents of the ghost element
		///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
		/// </summary>
		/// <param name="html">The html that will replace the current innerHTML of the ghost element, or a</param>
		/// <returns></returns>
		public virtual void update(System.String html) { _(html); }

		/// <summary>
		///     Updates the contents of the ghost element
		///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
		/// </summary>
		/// <param name="html">The html that will replace the current innerHTML of the ghost element, or a</param>
		/// <returns></returns>
		public virtual void update(DOMElement html) { _(html); }

		/// <summary>Returns the underlying proxy {@link Ext.Layer}</summary>
		/// <returns>Ext.Layer</returns>
		public virtual void getEl() { _(); }

		/// <summary>Returns the ghost element</summary>
		/// <returns>Ext.Element</returns>
		public virtual void getGhost() { _(); }

		/// <summary>Hides the proxy</summary>
		/// <returns></returns>
		public virtual void hide() { _(); }

		/// <summary>Hides the proxy</summary>
		/// <param name="clear">True to reset the status and clear the ghost contents, false to preserve them</param>
		/// <returns></returns>
		public virtual void hide(bool clear) { _(clear); }

		/// <summary>Stops the repair animation if it's currently running</summary>
		/// <returns></returns>
		public virtual void stop() { _(); }

		/// <summary>Displays this proxy</summary>
		/// <returns></returns>
		public virtual void show() { _(); }

		/// <summary>Force the Layer to sync its shadow and shim positions to the element</summary>
		/// <returns></returns>
		public virtual void sync() { _(); }

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <returns></returns>
		public virtual void repair() { _(); }

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <param name="xy">The XY position of the element ([x, y])</param>
		/// <returns></returns>
		public virtual void repair(System.Array xy) { _(xy); }

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <param name="xy">The XY position of the element ([x, y])</param>
		/// <param name="callback">The function to call after the repair is complete</param>
		/// <returns></returns>
		public virtual void repair(System.Array xy, Delegate callback) { _(xy, callback); }

		/// <summary>
		///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
		///     invalid drop operation by the item being dragged.
		/// </summary>
		/// <param name="xy">The XY position of the element ([x, y])</param>
		/// <param name="callback">The function to call after the repair is complete</param>
		/// <param name="scope">The scope in which to execute the callback</param>
		/// <returns></returns>
		public virtual void repair(System.Array xy, Delegate callback, object scope) { _(xy, callback, scope); }



	}

	[JsAnonymous]
	public class StatusProxyConfig : DotWeb.Client.JsAccessible {
		/// <summary>  The CSS class to apply to the status element when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public System.String dropAllowed { get; set; }

		/// <summary>  The CSS class to apply to the status element when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public System.String dropNotAllowed { get; set; }

	}
}
