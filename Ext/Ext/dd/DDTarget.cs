using System;
using H8.Support;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     A DragDrop implementation that does not move, but can be a drop
    ///     target.  You would get the same result by simply omitting implementation
    ///     for the event callbacks, but this way we reduce the processing cost of the
    ///     event listener and the callbacks.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\DDCore.js</jssource>
    [Native]
    public class DDTarget : Ext.dd.DragDrop {

        /// <summary>
        ///     Valid properties for DDTarget in addition to those in
        ///     DragDrop:
        ///     none
        /// </summary>
        /// <returns></returns>
        public DDTarget() {}
        /// <summary>
        ///     Valid properties for DDTarget in addition to those in
        ///     DragDrop:
        ///     none
        /// </summary>
        /// <param name="id">the id of the element that is a drop target</param>
        /// <returns></returns>
        public DDTarget(System.String id) {}
        /// <summary>
        ///     Valid properties for DDTarget in addition to those in
        ///     DragDrop:
        ///     none
        /// </summary>
        /// <param name="id">the id of the element that is a drop target</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <returns></returns>
        public DDTarget(System.String id, System.String sGroup) {}
        /// <summary>
        ///     Valid properties for DDTarget in addition to those in
        ///     DragDrop:
        ///     none
        /// </summary>
        /// <param name="id">the id of the element that is a drop target</param>
        /// <param name="sGroup">the group of related DragDrop objects</param>
        /// <param name="config">an object containing configurable attributes</param>
        /// <returns></returns>
        public DDTarget(System.String id, System.String sGroup, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DDTarget prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.dd.DragDrop superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class DDTargetConfig {

    }


}
