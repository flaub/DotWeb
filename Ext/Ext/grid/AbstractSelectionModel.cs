using System;
using DotWeb.Core;

namespace Ext.grid {
    /// <summary>
    ///     /**
    ///     Abstract base class for grid SelectionModels.  It provides the interface that should be
    ///     implemented by descendant classes.  This class should not be directly instantiated.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\grid\AbstractSelectionModel.js</jssource>
    [Native]
    public class AbstractSelectionModel : Ext.util.Observable {

        /// <summary></summary>
        /// <returns></returns>
        public AbstractSelectionModel() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static AbstractSelectionModel prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.util.Observable superclass { get { return null; } set { } }


        /// <summary>Locks the selections.</summary>
        /// <returns></returns>
        public virtual void lock_() { return ; }

        /// <summary>Unlocks the selections.</summary>
        /// <returns></returns>
        public virtual void unlock() { return ; }

        /// <summary>Returns true if the selections are locked.</summary>
        /// <returns>Boolean</returns>
        public virtual bool isLocked() { return false; }



    }
    [Anonymous]
    public class AbstractSelectionModelConfig {

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }


}
