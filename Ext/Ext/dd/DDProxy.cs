using System;
using H8.Support;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     A DragDrop implementation that inserts an empty, bordered div into
    ///     the document that follows the cursor during drag operations.  At the time of
    ///     the click, the frame div is resized to the dimensions of the linked html
    ///     element, and moved to the exact location of the linked element.
    ///     References to the "frame" element refer to the single proxy element that
    ///     was created to be dragged in place of all DDProxy elements on the
    ///     page.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\DDCore.js</jssource>
    [Native]
    public class DDProxy : Ext.dd.DD {

        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <returns></returns>
        public DDProxy() {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <returns></returns>
        public DDProxy(System.String id) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <returns></returns>
        public DDProxy(System.String id, System.String sGroup) {}
        /// <summary>
        ///     Valid properties for DDProxy in addition to those in DragDrop:
        ///     resizeFrame, centerFrame, dragElId
        /// </summary>
        /// <param name="id">the id of the linked html element</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <param name="config">an object containing configurable attributes</param>
        /// <returns></returns>
        public DDProxy(System.String id, System.String sGroup, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DDProxy prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.dd.DD superclass { get { return null; } set { } }

        /// <summary>The default drag frame div id</summary>
        public static System.String Ext { get { return null; } set { } }

        /// <summary>
        ///     By default we resize the drag frame to be the same size as the element
        ///     we want to drag (this is to get the frame effect).  We can turn it off
        ///     if we want a different behavior.
        /// </summary>
        public bool resizeFrame { get { return false; } set { } }

        /// <summary>
        ///     By default the frame is positioned exactly where the drag element is, so
        ///     we use the cursor offset provided by Ext.dd.DD.  Another option that works only if
        ///     you do not have constraints on the obj is to have the drag frame centered
        ///     around the cursor.  Set centerFrame to true for this effect.
        /// </summary>
        public bool centerFrame { get { return false; } set { } }


        /// <summary>Creates the proxy element if it does not yet exist</summary>
        /// <returns></returns>
        public virtual void createFrame() { return ; }

        /// <summary>
        ///     Initialization for the drag frame element.  Must be called in the
        ///     constructor of all subclasses
        /// </summary>
        /// <returns></returns>
        public virtual void initFrame() { return ; }



    }
    [Anonymous]
    public class DDProxyConfig {

    }


}
