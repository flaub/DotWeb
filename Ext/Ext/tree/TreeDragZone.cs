using System;
using DotWeb.Core;

namespace Ext.tree {
    /// <summary>
    ///     /**
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\tree\TreeDragZone.js</jssource>
    [Native]
    public class TreeDragZone : Ext.dd.DragZone {

        /// <summary></summary>
        /// <returns></returns>
        public TreeDragZone() {}
        /// <summary></summary>
        /// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
        /// <returns></returns>
        public TreeDragZone(System.String tree) {}
        /// <summary></summary>
        /// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public TreeDragZone(System.String tree, object config) {}
        /// <summary></summary>
        /// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
        /// <returns></returns>
        public TreeDragZone(DOMElement tree) {}
        /// <summary></summary>
        /// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public TreeDragZone(DOMElement tree, object config) {}
        /// <summary></summary>
        /// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
        /// <returns></returns>
        public TreeDragZone(Element tree) {}
        /// <summary></summary>
        /// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public TreeDragZone(Element tree, object config) {}
        /// <summary></summary>
        /// <param name="el">The container element</param>
        /// <returns></returns>
        public TreeDragZone(object el) {}
        /// <summary></summary>
        /// <param name="el">The container element</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public TreeDragZone(object el, object config) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <returns></returns>
        public TreeDragZone(System.String id, System.String sGroup) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <param name="config">an object containing configurable attributes</param>
        /// <returns></returns>
        public TreeDragZone(System.String id, System.String sGroup, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TreeDragZone prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.dd.DragZone superclass { get { return null; } set { } }

        /// <summary>The TreePanel for this drag zone</summary>
        public Ext.tree.TreePanel tree { get { return null; } set { } }

        /// <summary>
        ///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
        ///     interact with other drag drop objects in the same group (defaults to 'TreeDD').
        /// </summary>
        public System.String ddGroup { get { return null; } set { } }




    }
    [Anonymous]
    public class TreeDragZoneConfig {

        /// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to 'TreeDD').</summary>
        public System.String ddGroup { get { return null; } set { } }

        /// <summary> True to register this container with the Scrollmanager for auto scrolling during drag operations.</summary>
        public bool containerScroll { get { return false; } set { } }

        /// <summary> The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to "c3daf9" - light blue)</summary>
        public System.String hlColor { get { return null; } set { } }

        /// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
        public System.String dropAllowed { get { return null; } set { } }

        /// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
        public System.String dropNotAllowed { get { return null; } set { } }

    }


}
