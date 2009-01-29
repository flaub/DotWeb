using System;
using DotWeb.Core;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     This class provides a container DD instance that proxies for multiple child node sources.<br />
    ///     By default, this class requires that draggable child nodes are registered with {@link Ext.dd.Registry}.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\DragZone.js</jssource>
    [Native]
    public class DragZone : Ext.dd.DragSource {

        /// <summary></summary>
        /// <returns></returns>
        public DragZone() {}
        /// <summary></summary>
        /// <param name="el">The container element</param>
        /// <returns></returns>
        public DragZone(object el) {}
        /// <summary></summary>
        /// <param name="el">The container element</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public DragZone(object el, object config) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <returns></returns>
        public DragZone(System.String id) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <returns></returns>
        public DragZone(System.String id, System.String sGroup) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <param name="config">an object containing configurable attributes</param>
        /// <returns></returns>
        public DragZone(System.String id, System.String sGroup, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DragZone prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.dd.DragSource superclass { get { return null; } set { } }

        /// <summary>True to register this container with the Scrollmanagerfor auto scrolling during drag operations.</summary>
        public bool containerScroll { get { return false; } set { } }

        /// <summary>The color to use when visually highlighting the drag source in the afterRepairmethod after a failed drop (defaults to "c3daf9" - light blue)</summary>
        public System.String hlColor { get { return null; } set { } }


        /// <summary>
        ///     Called when a mousedown occurs in this container. Looks in {@link Ext.dd.Registry}
        ///     for a valid target to drag based on the mouse down. Override this method
        ///     to provide your own lookup logic (e.g. finding a child by class name). Make sure your returned
        ///     object has a "ddel" attribute (with an HTML Element) for other functions to work.
        /// </summary>
        /// <returns>Object</returns>
        public virtual object getDragData() { return null; }

        /// <summary>
        ///     Called when a mousedown occurs in this container. Looks in {@link Ext.dd.Registry}
        ///     for a valid target to drag based on the mouse down. Override this method
        ///     to provide your own lookup logic (e.g. finding a child by class name). Make sure your returned
        ///     object has a "ddel" attribute (with an HTML Element) for other functions to work.
        /// </summary>
        /// <param name="e">The mouse down event</param>
        /// <returns>Object</returns>
        public virtual object getDragData(EventObject e) { return null; }

        /// <summary>
        ///     Called once drag threshold has been reached to initialize the proxy element. By default, it clones the
        ///     this.dragData.ddel
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool onInitDrag() { return false; }

        /// <summary>
        ///     Called once drag threshold has been reached to initialize the proxy element. By default, it clones the
        ///     this.dragData.ddel
        /// </summary>
        /// <param name="x">The x position of the click on the dragged object</param>
        /// <returns>Boolean</returns>
        public virtual bool onInitDrag(double x) { return false; }

        /// <summary>
        ///     Called once drag threshold has been reached to initialize the proxy element. By default, it clones the
        ///     this.dragData.ddel
        /// </summary>
        /// <param name="x">The x position of the click on the dragged object</param>
        /// <param name="y">The y position of the click on the dragged object</param>
        /// <returns>Boolean</returns>
        public virtual bool onInitDrag(double x, double y) { return false; }

        /// <summary>Called after a repair of an invalid drop. By default, highlights this.dragData.ddel</summary>
        /// <returns></returns>
        public virtual void afterRepair() { return ; }

        /// <summary>
        ///     Called before a repair of an invalid drop to get the XY to animate to. By default returns
        ///     the XY of this.dragData.ddel
        /// </summary>
        /// <returns>Array</returns>
        public virtual System.Array getRepairXY() { return null; }

        /// <summary>
        ///     Called before a repair of an invalid drop to get the XY to animate to. By default returns
        ///     the XY of this.dragData.ddel
        /// </summary>
        /// <param name="e">The mouse up event</param>
        /// <returns>Array</returns>
        public virtual System.Array getRepairXY(EventObject e) { return null; }



    }
    [Anonymous]
    public class DragZoneConfig {

        /// <summary> True to register this container with the Scrollmanager for auto scrolling during drag operations.</summary>
        public bool containerScroll { get { return false; } set { } }

        /// <summary> The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to "c3daf9" - light blue)</summary>
        public System.String hlColor { get { return null; } set { } }

        /// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
        public System.String ddGroup { get { return null; } set { } }

        /// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
        public System.String dropAllowed { get { return null; } set { } }

        /// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
        public System.String dropNotAllowed { get { return null; } set { } }

    }


}
