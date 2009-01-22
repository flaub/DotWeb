using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     An object that represents a group of {@link Ext.Window} instances and provides z-order management
    ///     and window activation behavior.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\WindowManager.js</jssource>
    [Native]
    public class WindowGroup  {

        /// <summary></summary>
        /// <returns></returns>
        public WindowGroup() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static WindowGroup prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The starting z-index for windows (defaults to 9000)</summary>
        public double zseed { get { return 0; } set { } }


        /// <summary>Gets a registered window by id.</summary>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass get() { return null; }

        /// <summary>Gets a registered window by id.</summary>
        /// <param name="id">The id of the window or a {@link Ext.Window} instance</param>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass get(System.String id) { return null; }

        /// <summary>Gets a registered window by id.</summary>
        /// <param name="id">The id of the window or a {@link Ext.Window} instance</param>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass get(object id) { return null; }

        /// <summary>
        ///     Brings the specified window to the front of any other active windows.
        ///     if it was already in front
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool bringToFront() { return false; }

        /// <summary>
        ///     Brings the specified window to the front of any other active windows.
        ///     if it was already in front
        /// </summary>
        /// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
        /// <returns>Boolean</returns>
        public virtual bool bringToFront(System.String win) { return false; }

        /// <summary>
        ///     Brings the specified window to the front of any other active windows.
        ///     if it was already in front
        /// </summary>
        /// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
        /// <returns>Boolean</returns>
        public virtual bool bringToFront(object win) { return false; }

        /// <summary>Sends the specified window to the back of other active windows.</summary>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass sendToBack() { return null; }

        /// <summary>Sends the specified window to the back of other active windows.</summary>
        /// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass sendToBack(System.String win) { return null; }

        /// <summary>Sends the specified window to the back of other active windows.</summary>
        /// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass sendToBack(object win) { return null; }

        /// <summary>Hides all windows in the group.</summary>
        /// <returns></returns>
        public virtual void hideAll() { return ; }

        /// <summary>Gets the currently-active window in the group.</summary>
        /// <returns>Ext.Window</returns>
        public virtual Ext.WindowClass getActive() { return null; }

        /// <summary>
        ///     Returns zero or more windows in the group using the custom search function passed to this method.
        ///     The function should accept a single {@link Ext.Window} reference as its only argument and should
        ///     return true if the window matches the search criteria, otherwise it should return false.
        ///     that gets passed to the function if not specified)
        /// </summary>
        /// <returns>Array</returns>
        public virtual System.Array getBy() { return null; }

        /// <summary>
        ///     Returns zero or more windows in the group using the custom search function passed to this method.
        ///     The function should accept a single {@link Ext.Window} reference as its only argument and should
        ///     return true if the window matches the search criteria, otherwise it should return false.
        ///     that gets passed to the function if not specified)
        /// </summary>
        /// <param name="fn">The search function</param>
        /// <returns>Array</returns>
        public virtual System.Array getBy(Delegate fn) { return null; }

        /// <summary>
        ///     Returns zero or more windows in the group using the custom search function passed to this method.
        ///     The function should accept a single {@link Ext.Window} reference as its only argument and should
        ///     return true if the window matches the search criteria, otherwise it should return false.
        ///     that gets passed to the function if not specified)
        /// </summary>
        /// <param name="fn">The search function</param>
        /// <param name="scope">(optional) The scope in which to execute the function (defaults to the window</param>
        /// <returns>Array</returns>
        public virtual System.Array getBy(Delegate fn, object scope) { return null; }

        /// <summary>
        ///     Executes the specified function once for every window in the group, passing each
        ///     window as the only parameter. Returning false from the function will stop the iteration.
        /// </summary>
        /// <returns></returns>
        public virtual void each() { return ; }

        /// <summary>
        ///     Executes the specified function once for every window in the group, passing each
        ///     window as the only parameter. Returning false from the function will stop the iteration.
        /// </summary>
        /// <param name="fn">The function to execute for each item</param>
        /// <returns></returns>
        public virtual void each(Delegate fn) { return ; }

        /// <summary>
        ///     Executes the specified function once for every window in the group, passing each
        ///     window as the only parameter. Returning false from the function will stop the iteration.
        /// </summary>
        /// <param name="fn">The function to execute for each item</param>
        /// <param name="scope">(optional) The scope in which to execute the function</param>
        /// <returns></returns>
        public virtual void each(Delegate fn, object scope) { return ; }



    }
    [Anonymous]
    public class WindowGroupConfig {

    }


}
