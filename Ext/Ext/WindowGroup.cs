using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     An object that represents a group of {@link Ext.Window} instances and provides z-order management
	///     and window activation behavior.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\WindowManager.js</jssource>
	public class WindowGroup : DotWeb.Client.JsNativeBase {

		/// <summary></summary>
		/// <returns></returns>
		public WindowGroup() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static WindowGroup prototype { get { return S_<WindowGroup>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The starting z-index for windows (defaults to 9000)</summary>
		public double zseed { get { return _<double>(); } set { _(value); } }


		/// <summary>Gets a registered window by id.</summary>
		/// <returns>Ext.Window</returns>
		public virtual void get() { _(); }

		/// <summary>Gets a registered window by id.</summary>
		/// <param name="id">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public virtual void get(System.String id) { _(id); }

		/// <summary>Gets a registered window by id.</summary>
		/// <param name="id">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public virtual void get(object id) { _(id); }

		/// <summary>
		///     Brings the specified window to the front of any other active windows.
		///     if it was already in front
		/// </summary>
		/// <returns>Boolean</returns>
		public virtual void bringToFront() { _(); }

		/// <summary>
		///     Brings the specified window to the front of any other active windows.
		///     if it was already in front
		/// </summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Boolean</returns>
		public virtual void bringToFront(System.String win) { _(win); }

		/// <summary>
		///     Brings the specified window to the front of any other active windows.
		///     if it was already in front
		/// </summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Boolean</returns>
		public virtual void bringToFront(object win) { _(win); }

		/// <summary>Sends the specified window to the back of other active windows.</summary>
		/// <returns>Ext.Window</returns>
		public virtual void sendToBack() { _(); }

		/// <summary>Sends the specified window to the back of other active windows.</summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public virtual void sendToBack(System.String win) { _(win); }

		/// <summary>Sends the specified window to the back of other active windows.</summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public virtual void sendToBack(object win) { _(win); }

		/// <summary>Hides all windows in the group.</summary>
		/// <returns></returns>
		public virtual void hideAll() { _(); }

		/// <summary>Gets the currently-active window in the group.</summary>
		/// <returns>Ext.Window</returns>
		public virtual void getActive() { _(); }

		/// <summary>
		///     Returns zero or more windows in the group using the custom search function passed to this method.
		///     The function should accept a single {@link Ext.Window} reference as its only argument and should
		///     return true if the window matches the search criteria, otherwise it should return false.
		///     that gets passed to the function if not specified)
		/// </summary>
		/// <returns>Array</returns>
		public virtual void getBy() { _(); }

		/// <summary>
		///     Returns zero or more windows in the group using the custom search function passed to this method.
		///     The function should accept a single {@link Ext.Window} reference as its only argument and should
		///     return true if the window matches the search criteria, otherwise it should return false.
		///     that gets passed to the function if not specified)
		/// </summary>
		/// <param name="fn">The search function</param>
		/// <returns>Array</returns>
		public virtual void getBy(Delegate fn) { _(fn); }

		/// <summary>
		///     Returns zero or more windows in the group using the custom search function passed to this method.
		///     The function should accept a single {@link Ext.Window} reference as its only argument and should
		///     return true if the window matches the search criteria, otherwise it should return false.
		///     that gets passed to the function if not specified)
		/// </summary>
		/// <param name="fn">The search function</param>
		/// <param name="scope">(optional) The scope in which to execute the function (defaults to the window</param>
		/// <returns>Array</returns>
		public virtual void getBy(Delegate fn, object scope) { _(fn, scope); }

		/// <summary>
		///     Executes the specified function once for every window in the group, passing each
		///     window as the only parameter. Returning false from the function will stop the iteration.
		/// </summary>
		/// <returns></returns>
		public virtual void each() { _(); }

		/// <summary>
		///     Executes the specified function once for every window in the group, passing each
		///     window as the only parameter. Returning false from the function will stop the iteration.
		/// </summary>
		/// <param name="fn">The function to execute for each item</param>
		/// <returns></returns>
		public virtual void each(Delegate fn) { _(fn); }

		/// <summary>
		///     Executes the specified function once for every window in the group, passing each
		///     window as the only parameter. Returning false from the function will stop the iteration.
		/// </summary>
		/// <param name="fn">The function to execute for each item</param>
		/// <param name="scope">(optional) The scope in which to execute the function</param>
		/// <returns></returns>
		public virtual void each(Delegate fn, object scope) { _(fn, scope); }



	}
}
