using System;
using H8.Support;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     A DragDrop implementation where the linked element follows the
    ///     mouse cursor during a drag.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\DDCore.js</jssource>
    [Native]
    public class DD : Ext.dd.DragDrop {

        /// <summary>
        ///     Valid properties for DD:
        ///     scroll
        /// </summary>
        /// <returns></returns>
        public DD() {}
        /// <summary>
        ///     Valid properties for DD:
        ///     scroll
        /// </summary>
        /// <param name="id">the id of the linked element</param>
        /// <returns></returns>
        public DD(System.String id) {}
        /// <summary>
        ///     Valid properties for DD:
        ///     scroll
        /// </summary>
        /// <param name="id">the id of the linked element</param>
        /// <param name="sGroup">the group of related DragDrop items</param>
        /// <returns></returns>
        public DD(System.String id, System.String sGroup) {}
        /// <summary>
        ///     Valid properties for DD:
        ///     scroll
        /// </summary>
        /// <param name="id">the id of the linked element</param>
        /// <param name="sGroup">the group of related DragDrop items</param>
        /// <param name="config">an object containing configurable attributes</param>
        /// <returns></returns>
        public DD(System.String id, System.String sGroup, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DD prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.dd.DragDrop superclass { get { return null; } set { } }

        /// <summary>
        ///     When set to true, the utility automatically tries to scroll the browser
        ///     window when a drag and drop element is dragged near the viewport boundary.
        ///     Defaults to true.
        /// </summary>
        public bool scroll { get { return false; } set { } }


        /// <summary>
        ///     Sets the pointer offset to the distance between the linked element's top
        ///     left corner and the location the element was clicked
        /// </summary>
        /// <returns></returns>
        public virtual void autoOffset() { return ; }

        /// <summary>
        ///     Sets the pointer offset to the distance between the linked element's top
        ///     left corner and the location the element was clicked
        /// </summary>
        /// <param name="iPageX">the X coordinate of the click</param>
        /// <returns></returns>
        public virtual void autoOffset(int iPageX) { return ; }

        /// <summary>
        ///     Sets the pointer offset to the distance between the linked element's top
        ///     left corner and the location the element was clicked
        /// </summary>
        /// <param name="iPageX">the X coordinate of the click</param>
        /// <param name="iPageY">the Y coordinate of the click</param>
        /// <returns></returns>
        public virtual void autoOffset(int iPageX, int iPageY) { return ; }

        /// <summary>
        ///     Sets the pointer offset.  You can call this directly to force the
        ///     offset to be in a particular location (e.g., pass in 0,0 to set it
        ///     to the center of the object)
        /// </summary>
        /// <returns></returns>
        public virtual void setDelta() { return ; }

        /// <summary>
        ///     Sets the pointer offset.  You can call this directly to force the
        ///     offset to be in a particular location (e.g., pass in 0,0 to set it
        ///     to the center of the object)
        /// </summary>
        /// <param name="iDeltaX">the distance from the left</param>
        /// <returns></returns>
        public virtual void setDelta(int iDeltaX) { return ; }

        /// <summary>
        ///     Sets the pointer offset.  You can call this directly to force the
        ///     offset to be in a particular location (e.g., pass in 0,0 to set it
        ///     to the center of the object)
        /// </summary>
        /// <param name="iDeltaX">the distance from the left</param>
        /// <param name="iDeltaY">the distance from the top</param>
        /// <returns></returns>
        public virtual void setDelta(int iDeltaX, int iDeltaY) { return ; }

        /// <summary>
        ///     Sets the drag element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <returns></returns>
        public virtual void setDragElPos() { return ; }

        /// <summary>
        ///     Sets the drag element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <param name="iPageX">the X coordinate of the mousedown or drag event</param>
        /// <returns></returns>
        public virtual void setDragElPos(int iPageX) { return ; }

        /// <summary>
        ///     Sets the drag element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <param name="iPageX">the X coordinate of the mousedown or drag event</param>
        /// <param name="iPageY">the Y coordinate of the mousedown or drag event</param>
        /// <returns></returns>
        public virtual void setDragElPos(int iPageX, int iPageY) { return ; }

        /// <summary>
        ///     Sets the element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <returns></returns>
        public virtual void alignElWithMouse() { return ; }

        /// <summary>
        ///     Sets the element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <param name="el">the element to move</param>
        /// <returns></returns>
        public virtual void alignElWithMouse(DOMElement el) { return ; }

        /// <summary>
        ///     Sets the element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <param name="el">the element to move</param>
        /// <param name="iPageX">the X coordinate of the mousedown or drag event</param>
        /// <returns></returns>
        public virtual void alignElWithMouse(DOMElement el, int iPageX) { return ; }

        /// <summary>
        ///     Sets the element to the location of the mousedown or click event,
        ///     maintaining the cursor location relative to the location on the element
        ///     that was clicked.  Override this if you want to place the element in a
        ///     location other than where the cursor is.
        /// </summary>
        /// <param name="el">the element to move</param>
        /// <param name="iPageX">the X coordinate of the mousedown or drag event</param>
        /// <param name="iPageY">the Y coordinate of the mousedown or drag event</param>
        /// <returns></returns>
        public virtual void alignElWithMouse(DOMElement el, int iPageX, int iPageY) { return ; }

        /// <summary>
        ///     Saves the most recent position so that we can reset the constraints and
        ///     tick marks on-demand.  We need to know this so that we can calculate the
        ///     number of pixels the element is offset from its original position.
        ///     don't have to look it up again)
        ///     don't have to look it up again)
        /// </summary>
        /// <returns></returns>
        public virtual void cachePosition() { return ; }

        /// <summary>
        ///     Saves the most recent position so that we can reset the constraints and
        ///     tick marks on-demand.  We need to know this so that we can calculate the
        ///     number of pixels the element is offset from its original position.
        ///     don't have to look it up again)
        ///     don't have to look it up again)
        /// </summary>
        /// <param name="iPageX">the current x position (optional, this just makes it so we</param>
        /// <returns></returns>
        public virtual void cachePosition(object iPageX) { return ; }

        /// <summary>
        ///     Saves the most recent position so that we can reset the constraints and
        ///     tick marks on-demand.  We need to know this so that we can calculate the
        ///     number of pixels the element is offset from its original position.
        ///     don't have to look it up again)
        ///     don't have to look it up again)
        /// </summary>
        /// <param name="iPageX">the current x position (optional, this just makes it so we</param>
        /// <param name="iPageY">the current y position (optional, this just makes it so we</param>
        /// <returns></returns>
        public virtual void cachePosition(object iPageX, object iPageY) { return ; }

        /// <summary>
        ///     Sets up config options specific to this class. Overrides
        ///     Ext.dd.DragDrop, but all versions of this method through the
        ///     inheritance chain are called
        /// </summary>
        /// <returns></returns>
        public virtual void applyConfig() { return ; }

        /// <summary>
        ///     Event that fires prior to the onMouseDown event.  Overrides
        ///     Ext.dd.DragDrop.
        /// </summary>
        /// <returns></returns>
        public virtual void b4MouseDown() { return ; }

        /// <summary>
        ///     Event that fires prior to the onDrag event.  Overrides
        ///     Ext.dd.DragDrop.
        /// </summary>
        /// <returns></returns>
        public virtual void b4Drag() { return ; }



    }
    [Anonymous]
    public class DDConfig {

    }


}
