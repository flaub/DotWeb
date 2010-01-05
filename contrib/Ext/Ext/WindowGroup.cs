using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     An object that represents a group of {@link Ext.Window} instances and provides z-order management
	///     and window activation behavior.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\WindowManager.js</jssource>
	public class WindowGroup : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern WindowGroup();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static WindowGroup prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The starting z-index for windows (defaults to 9000)</summary>
		public extern double zseed { get; set; }


		/// <summary>Gets a registered window by id.</summary>
		/// <returns>Ext.Window</returns>
		public extern virtual void get();

		/// <summary>Gets a registered window by id.</summary>
		/// <param name="id">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public extern virtual void get(string id);

		/// <summary>Gets a registered window by id.</summary>
		/// <param name="id">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public extern virtual void get(object id);

		/// <summary>
		///     Brings the specified window to the front of any other active windows.
		///     if it was already in front
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void bringToFront();

		/// <summary>
		///     Brings the specified window to the front of any other active windows.
		///     if it was already in front
		/// </summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Boolean</returns>
		public extern virtual void bringToFront(string win);

		/// <summary>
		///     Brings the specified window to the front of any other active windows.
		///     if it was already in front
		/// </summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Boolean</returns>
		public extern virtual void bringToFront(object win);

		/// <summary>Sends the specified window to the back of other active windows.</summary>
		/// <returns>Ext.Window</returns>
		public extern virtual void sendToBack();

		/// <summary>Sends the specified window to the back of other active windows.</summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public extern virtual void sendToBack(string win);

		/// <summary>Sends the specified window to the back of other active windows.</summary>
		/// <param name="win">The id of the window or a {@link Ext.Window} instance</param>
		/// <returns>Ext.Window</returns>
		public extern virtual void sendToBack(object win);

		/// <summary>Hides all windows in the group.</summary>
		/// <returns></returns>
		public extern virtual void hideAll();

		/// <summary>Gets the currently-active window in the group.</summary>
		/// <returns>Ext.Window</returns>
		public extern virtual void getActive();

		/// <summary>
		///     Returns zero or more windows in the group using the custom search function passed to this method.
		///     The function should accept a single {@link Ext.Window} reference as its only argument and should
		///     return true if the window matches the search criteria, otherwise it should return false.
		///     that gets passed to the function if not specified)
		/// </summary>
		/// <returns>Array</returns>
		public extern virtual void getBy();

		/// <summary>
		///     Returns zero or more windows in the group using the custom search function passed to this method.
		///     The function should accept a single {@link Ext.Window} reference as its only argument and should
		///     return true if the window matches the search criteria, otherwise it should return false.
		///     that gets passed to the function if not specified)
		/// </summary>
		/// <param name="fn">The search function</param>
		/// <returns>Array</returns>
		public extern virtual void getBy(Delegate fn);

		/// <summary>
		///     Returns zero or more windows in the group using the custom search function passed to this method.
		///     The function should accept a single {@link Ext.Window} reference as its only argument and should
		///     return true if the window matches the search criteria, otherwise it should return false.
		///     that gets passed to the function if not specified)
		/// </summary>
		/// <param name="fn">The search function</param>
		/// <param name="scope">(optional) The scope in which to execute the function (defaults to the window</param>
		/// <returns>Array</returns>
		public extern virtual void getBy(Delegate fn, object scope);

		/// <summary>
		///     Executes the specified function once for every window in the group, passing each
		///     window as the only parameter. Returning false from the function will stop the iteration.
		/// </summary>
		/// <returns></returns>
		public extern virtual void each();

		/// <summary>
		///     Executes the specified function once for every window in the group, passing each
		///     window as the only parameter. Returning false from the function will stop the iteration.
		/// </summary>
		/// <param name="fn">The function to execute for each item</param>
		/// <returns></returns>
		public extern virtual void each(Delegate fn);

		/// <summary>
		///     Executes the specified function once for every window in the group, passing each
		///     window as the only parameter. Returning false from the function will stop the iteration.
		/// </summary>
		/// <param name="fn">The function to execute for each item</param>
		/// <param name="scope">(optional) The scope in which to execute the function</param>
		/// <returns></returns>
		public extern virtual void each(Delegate fn, object scope);



	}
}
