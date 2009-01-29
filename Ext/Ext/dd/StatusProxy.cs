using System;
using DotWeb.Core;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     A specialized drag proxy that supports a drop status icon, {@link Ext.Layer} styles and auto-repair.  This is the
    ///     default drag proxy used by all Ext.dd components.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\StatusProxy.js</jssource>
    [Native]
    public class StatusProxy  {

        /// <summary></summary>
        /// <returns></returns>
        public StatusProxy() {}
        /// <summary></summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public StatusProxy(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static StatusProxy prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The CSS class to apply to the status element when drop is allowed (defaults to "x-dd-drop-ok").</summary>
        public System.String dropAllowed { get { return null; } set { } }

        /// <summary>The CSS class to apply to the status element when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
        public System.String dropNotAllowed { get { return null; } set { } }


        /// <summary>
        ///     Updates the proxy's visual element to indicate the status of whether or not drop is allowed
        ///     over the current target element.
        /// </summary>
        /// <returns></returns>
        public virtual void setStatus() { return ; }

        /// <summary>
        ///     Updates the proxy's visual element to indicate the status of whether or not drop is allowed
        ///     over the current target element.
        /// </summary>
        /// <param name="cssClass">The css class for the new drop status indicator image</param>
        /// <returns></returns>
        public virtual void setStatus(System.String cssClass) { return ; }

        /// <summary>Resets the status indicator to the default dropNotAllowed value</summary>
        /// <returns></returns>
        public virtual void reset() { return ; }

        /// <summary>Resets the status indicator to the default dropNotAllowed value</summary>
        /// <param name="clearGhost">True to also remove all content from the ghost, false to preserve it</param>
        /// <returns></returns>
        public virtual void reset(bool clearGhost) { return ; }

        /// <summary>
        ///     Updates the contents of the ghost element
        ///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
        /// </summary>
        /// <returns></returns>
        public virtual void update() { return ; }

        /// <summary>
        ///     Updates the contents of the ghost element
        ///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
        /// </summary>
        /// <param name="html">The html that will replace the current innerHTML of the ghost element, or a</param>
        /// <returns></returns>
        public virtual void update(System.String html) { return ; }

        /// <summary>
        ///     Updates the contents of the ghost element
        ///     DOM node to append as the child of the ghost element (in which case the innerHTML will be cleared first).
        /// </summary>
        /// <param name="html">The html that will replace the current innerHTML of the ghost element, or a</param>
        /// <returns></returns>
        public virtual void update(DOMElement html) { return ; }

        /// <summary>Returns the underlying proxy {@link Ext.Layer}</summary>
        /// <returns>Ext.Layer</returns>
        public virtual Ext.Layer getEl() { return null; }

        /// <summary>Returns the ghost element</summary>
        /// <returns>Ext.Element</returns>
        public virtual Ext.Element getGhost() { return null; }

        /// <summary>Hides the proxy</summary>
        /// <returns></returns>
        public virtual void hide() { return ; }

        /// <summary>Hides the proxy</summary>
        /// <param name="clear">True to reset the status and clear the ghost contents, false to preserve them</param>
        /// <returns></returns>
        public virtual void hide(bool clear) { return ; }

        /// <summary>Stops the repair animation if it's currently running</summary>
        /// <returns></returns>
        public virtual void stop() { return ; }

        /// <summary>Displays this proxy</summary>
        /// <returns></returns>
        public virtual void show() { return ; }

        /// <summary>Force the Layer to sync its shadow and shim positions to the element</summary>
        /// <returns></returns>
        public virtual void sync() { return ; }

        /// <summary>
        ///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
        ///     invalid drop operation by the item being dragged.
        /// </summary>
        /// <returns></returns>
        public virtual void repair() { return ; }

        /// <summary>
        ///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
        ///     invalid drop operation by the item being dragged.
        /// </summary>
        /// <param name="xy">The XY position of the element ([x, y])</param>
        /// <returns></returns>
        public virtual void repair(System.Array xy) { return ; }

        /// <summary>
        ///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
        ///     invalid drop operation by the item being dragged.
        /// </summary>
        /// <param name="xy">The XY position of the element ([x, y])</param>
        /// <param name="callback">The function to call after the repair is complete</param>
        /// <returns></returns>
        public virtual void repair(System.Array xy, Delegate callback) { return ; }

        /// <summary>
        ///     Causes the proxy to return to its position of origin via an animation.  Should be called after an
        ///     invalid drop operation by the item being dragged.
        /// </summary>
        /// <param name="xy">The XY position of the element ([x, y])</param>
        /// <param name="callback">The function to call after the repair is complete</param>
        /// <param name="scope">The scope in which to execute the callback</param>
        /// <returns></returns>
        public virtual void repair(System.Array xy, Delegate callback, object scope) { return ; }



    }
    [Anonymous]
    public class StatusProxyConfig {

        /// <summary>  The CSS class to apply to the status element when drop is allowed (defaults to "x-dd-drop-ok").</summary>
        public System.String dropAllowed { get { return null; } set { } }

        /// <summary>  The CSS class to apply to the status element when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
        public System.String dropNotAllowed { get { return null; } set { } }

    }


}
