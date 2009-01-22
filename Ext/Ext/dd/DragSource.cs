using System;
using H8.Support;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     A simple class that provides the basic implementation needed to make any element draggable.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\DragSource.js</jssource>
    [Native]
    public class DragSource : Ext.dd.DDProxy {

        /// <summary></summary>
        /// <returns></returns>
        public DragSource() {}
        /// <summary></summary>
        /// <param name="el">The container element</param>
        /// <returns></returns>
        public DragSource(object el) {}
        /// <summary></summary>
        /// <param name="el">The container element</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public DragSource(object el, object config) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <returns></returns>
        public DragSource(System.String id) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <returns></returns>
        public DragSource(System.String id, System.String sGroup) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <param name="config">an object containing configurable attributes</param>
        /// <returns></returns>
        public DragSource(System.String id, System.String sGroup, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DragSource prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.dd.DDProxy superclass { get { return null; } set { } }

        /// <summary>
        ///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
        ///     interact with other drag drop objects in the same group (defaults to undefined).
        /// </summary>
        public System.String ddGroup { get { return null; } set { } }

        /// <summary>The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
        public System.String dropAllowed { get { return null; } set { } }

        /// <summary>The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
        public System.String dropNotAllowed { get { return null; } set { } }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action once the initial
        ///     drag event has begun.  The drag cannot be canceled from this function.
        ///     @param {Number} x The x position of the click on the dragged object
        ///     @param {Number} y The y position of the click on the dragged object
        /// </summary>
        public object onStartDrag { get { return null; } set { } }


        /// <summary>Returns the data object associated with this drag source</summary>
        /// <returns>Object</returns>
        public virtual object getDragData() { return null; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     when the dragged item enters the drop target by providing an implementation.
        /// </summary>
        /// <returns></returns>
        public virtual void afterDragEnter() { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     when the dragged item enters the drop target by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns></returns>
        public virtual void afterDragEnter(Ext.dd.DragDrop target) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     when the dragged item enters the drop target by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns></returns>
        public virtual void afterDragEnter(Ext.dd.DragDrop target, Event e) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     when the dragged item enters the drop target by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns></returns>
        public virtual void afterDragEnter(Ext.dd.DragDrop target, Event e, System.String id) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragEnter() { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragEnter(Ext.dd.DragDrop target) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragEnter(Ext.dd.DragDrop target, Event e) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragEnter(Ext.dd.DragDrop target, Event e, System.String id) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target by providing an implementation.
        /// </summary>
        /// <returns></returns>
        public virtual void afterDragOver() { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns></returns>
        public virtual void afterDragOver(Ext.dd.DragDrop target) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns></returns>
        public virtual void afterDragOver(Ext.dd.DragDrop target, Event e) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns></returns>
        public virtual void afterDragOver(Ext.dd.DragDrop target, Event e, System.String id) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target and optionally cancel the onDragOver.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOver() { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target and optionally cancel the onDragOver.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOver(Ext.dd.DragDrop target) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target and optionally cancel the onDragOver.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOver(Ext.dd.DragDrop target, Event e) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     while the dragged item is over the drop target and optionally cancel the onDragOver.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOver(Ext.dd.DragDrop target, Event e, System.String id) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after the dragged item is dragged out of the target without dropping.
        /// </summary>
        /// <returns></returns>
        public virtual void afterDragOut() { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after the dragged item is dragged out of the target without dropping.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns></returns>
        public virtual void afterDragOut(Ext.dd.DragDrop target) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after the dragged item is dragged out of the target without dropping.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns></returns>
        public virtual void afterDragOut(Ext.dd.DragDrop target, Event e) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after the dragged item is dragged out of the target without dropping.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns></returns>
        public virtual void afterDragOut(Ext.dd.DragDrop target, Event e, System.String id) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOut() { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOut(Ext.dd.DragDrop target) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOut(Ext.dd.DragDrop target, Event e) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragOut(Ext.dd.DragDrop target, Event e, System.String id) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drag drop has occurred by providing an implementation.
        /// </summary>
        /// <returns></returns>
        public virtual void afterDragDrop() { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drag drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns></returns>
        public virtual void afterDragDrop(Ext.dd.DragDrop target) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drag drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns></returns>
        public virtual void afterDragDrop(Ext.dd.DragDrop target, Event e) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drag drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dropped element</param>
        /// <returns></returns>
        public virtual void afterDragDrop(Ext.dd.DragDrop target, Event e, System.String id) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dropped onto the target and optionally cancel the onDragDrop.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragDrop() { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dropped onto the target and optionally cancel the onDragDrop.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragDrop(Ext.dd.DragDrop target) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dropped onto the target and optionally cancel the onDragDrop.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragDrop(Ext.dd.DragDrop target, Event e) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the dragged
        ///     item is dropped onto the target and optionally cancel the onDragDrop.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeDragDrop(Ext.dd.DragDrop target, Event e, System.String id) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drop has occurred by providing an implementation.
        /// </summary>
        /// <returns></returns>
        public virtual void afterInvalidDrop() { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="target">The target DD</param>
        /// <returns></returns>
        public virtual void afterInvalidDrop(object target) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="target">The target DD</param>
        /// <param name="e">The event object</param>
        /// <returns></returns>
        public virtual void afterInvalidDrop(object target, Event e) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after a valid drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="target">The target DD</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dropped element</param>
        /// <returns></returns>
        public virtual void afterInvalidDrop(object target, Event e, System.String id) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after an invalid drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="e">The event object</param>
        /// <returns></returns>
        public virtual void afterInvalidDrop(Event e) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action
        ///     after an invalid drop has occurred by providing an implementation.
        /// </summary>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dropped element</param>
        /// <returns></returns>
        public virtual void afterInvalidDrop(Event e, System.String id) { return ; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action after an invalid
        ///     drop has occurred.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool beforeInvalidDrop() { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action after an invalid
        ///     drop has occurred.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeInvalidDrop(Ext.dd.DragDrop target) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action after an invalid
        ///     drop has occurred.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeInvalidDrop(Ext.dd.DragDrop target, Event e) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action after an invalid
        ///     drop has occurred.
        /// </summary>
        /// <param name="target">The drop target</param>
        /// <param name="e">The event object</param>
        /// <param name="id">The id of the dragged element</param>
        /// <returns>Boolean</returns>
        public virtual bool beforeInvalidDrop(Ext.dd.DragDrop target, Event e, System.String id) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the initial
        ///     drag event begins and optionally cancel it.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool onBeforeDrag() { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the initial
        ///     drag event begins and optionally cancel it.
        /// </summary>
        /// <param name="data">An object containing arbitrary data to be shared with drop targets</param>
        /// <returns>Boolean</returns>
        public virtual bool onBeforeDrag(object data) { return false; }

        /// <summary>
        ///     An empty function by default, but provided so that you can perform a custom action before the initial
        ///     drag event begins and optionally cancel it.
        /// </summary>
        /// <param name="data">An object containing arbitrary data to be shared with drop targets</param>
        /// <param name="e">The event object</param>
        /// <returns>Boolean</returns>
        public virtual bool onBeforeDrag(object data, Event e) { return false; }

        /// <summary>Returns the drag source's underlying {@link Ext.dd.StatusProxy}</summary>
        /// <returns>Ext.dd.StatusProxy</returns>
        public virtual Ext.dd.StatusProxy getProxy() { return null; }

        /// <summary>Hides the drag source's {@link Ext.dd.StatusProxy}</summary>
        /// <returns></returns>
        public virtual void hideProxy() { return ; }



    }
    [Anonymous]
    public class DragSourceConfig {

        /// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
        public System.String ddGroup { get { return null; } set { } }

        /// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
        public System.String dropAllowed { get { return null; } set { } }

        /// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
        public System.String dropNotAllowed { get { return null; } set { } }

    }


}
