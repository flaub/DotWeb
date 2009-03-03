using System;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     DragDropMgr is a singleton that tracks the element interaction for
	///     all DragDrop items in the window.  Generally, you will not call
	///     this class directly, but it does have helper methods that could
	///     be useful in your DragDrop implementations.
	///     */
	///     Ext.dd.DragDropMgr = function() {
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\dd\DDCore.js</jssource>
	public class DragDropMgr : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public DragDropMgr() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DragDropMgr prototype { get { return S_<DragDropMgr>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>
		///     Flag to determine if we should prevent the default behavior of the
		///     events we define. By default this is true, but this can be set to
		///     false if you need the default behavior (not recommended)
		/// </summary>
		public static bool preventDefault { get { return S_<bool>(); } set { S_(value); } }

		/// <summary>
		///     Flag to determine if we should stop the propagation of the events
		///     we generate. This is true by default but you may want to set it to
		///     false if the html element contains other features that require the
		///     mouse click.
		/// </summary>
		public static bool stopPropagation { get { return S_<bool>(); } set { S_(value); } }

		/// <summary>
		///     In point mode, drag and drop interaction is defined by the
		///     location of the cursor during the drag/drop
		/// </summary>
		public static int POINT { get { return S_<int>(); } set { S_(value); } }

		/// <summary>
		///     In intersect mode, drag and drop interaction is defined by the
		///     overlap of two or more drag and drop objects.
		/// </summary>
		public static int INTERSECT { get { return S_<int>(); } set { S_(value); } }

		/// <summary>The current drag and drop mode.  Default: POINT</summary>
		public static int mode { get { return S_<int>(); } set { S_(value); } }

		/// <summary>
		///     Set useCache to false if you want to force object the lookup of each
		///     drag and drop linked element constantly during a drag.
		/// </summary>
		public static bool useCache { get { return S_<bool>(); } set { S_(value); } }

		/// <summary>
		///     The number of pixels that the mouse needs to move after the
		///     mousedown before the drag is initiated.  Default=3;
		/// </summary>
		public static int clickPixelThresh { get { return S_<int>(); } set { S_(value); } }

		/// <summary>
		///     The number of milliseconds after the mousedown event to initiate the
		///     drag if we don't get a mouseup event. Default=1000
		/// </summary>
		public static int clickTimeThresh { get { return S_<int>(); } set { S_(value); } }


		/// <summary>Lock all drag and drop functionality</summary>
		/// <returns></returns>
		public static void lock_() { S_(); }

		/// <summary>Unlock all drag and drop functionality</summary>
		/// <returns></returns>
		public static void unlock() { S_(); }

		/// <summary>Is drag and drop locked?</summary>
		/// <returns>boolean</returns>
		public static void isLocked() { S_(); }

		/// <summary>
		///     Each DragDrop instance must be registered with the DragDropMgr.
		///     This is executed in DragDrop.init()
		/// </summary>
		/// <returns></returns>
		public static void regDragDrop() { S_(); }

		/// <summary>
		///     Each DragDrop instance must be registered with the DragDropMgr.
		///     This is executed in DragDrop.init()
		/// </summary>
		/// <param name="oDD">the DragDrop object to register</param>
		/// <returns></returns>
		public static void regDragDrop(DragDrop oDD) { S_(oDD); }

		/// <summary>
		///     Each DragDrop instance must be registered with the DragDropMgr.
		///     This is executed in DragDrop.init()
		/// </summary>
		/// <param name="oDD">the DragDrop object to register</param>
		/// <param name="sGroup">the name of the group this element belongs to</param>
		/// <returns></returns>
		public static void regDragDrop(DragDrop oDD, System.String sGroup) { S_(oDD, sGroup); }

		/// <summary>
		///     Each DragDrop handle element must be registered.  This is done
		///     automatically when executing DragDrop.setHandleElId()
		///     handle
		/// </summary>
		/// <returns></returns>
		public static void regHandle() { S_(); }

		/// <summary>
		///     Each DragDrop handle element must be registered.  This is done
		///     automatically when executing DragDrop.setHandleElId()
		///     handle
		/// </summary>
		/// <param name="sDDId">the DragDrop id this element is a handle for</param>
		/// <returns></returns>
		public static void regHandle(System.String sDDId) { S_(sDDId); }

		/// <summary>
		///     Each DragDrop handle element must be registered.  This is done
		///     automatically when executing DragDrop.setHandleElId()
		///     handle
		/// </summary>
		/// <param name="sDDId">the DragDrop id this element is a handle for</param>
		/// <param name="sHandleId">the id of the element that is the drag</param>
		/// <returns></returns>
		public static void regHandle(System.String sDDId, System.String sHandleId) { S_(sDDId, sHandleId); }

		/// <summary>
		///     Utility function to determine if a given element has been
		///     registered as a drag drop item.
		///     false otherwise
		/// </summary>
		/// <returns>boolean</returns>
		public static void isDragDrop() { S_(); }

		/// <summary>
		///     Utility function to determine if a given element has been
		///     registered as a drag drop item.
		///     false otherwise
		/// </summary>
		/// <param name="id">the element id to check</param>
		/// <returns>boolean</returns>
		public static void isDragDrop(System.String id) { S_(id); }

		/// <summary>
		///     Returns the drag and drop instances that are in all groups the
		///     passed in instance belongs to.
		/// </summary>
		/// <returns>DragDrop[]</returns>
		public static void getRelated() { S_(); }

		/// <summary>
		///     Returns the drag and drop instances that are in all groups the
		///     passed in instance belongs to.
		/// </summary>
		/// <param name="p_oDD">the obj to get related data for</param>
		/// <returns>DragDrop[]</returns>
		public static void getRelated(DragDrop p_oDD) { S_(p_oDD); }

		/// <summary>
		///     Returns the drag and drop instances that are in all groups the
		///     passed in instance belongs to.
		/// </summary>
		/// <param name="p_oDD">the obj to get related data for</param>
		/// <param name="bTargetsOnly">if true, only return targetable objs</param>
		/// <returns>DragDrop[]</returns>
		public static void getRelated(DragDrop p_oDD, bool bTargetsOnly) { S_(p_oDD, bTargetsOnly); }

		/// <summary>
		///     Returns true if the specified dd target is a legal target for
		///     the specifice drag obj
		///     dd obj
		/// </summary>
		/// <returns>boolean</returns>
		public static void isLegalTarget() { S_(); }

		/// <summary>
		///     Returns true if the specified dd target is a legal target for
		///     the specifice drag obj
		///     dd obj
		/// </summary>
		/// <param name="the">drag obj</param>
		/// <returns>boolean</returns>
		public static void isLegalTarget(DragDrop the) { S_(the); }

		/// <summary>
		///     Returns true if the specified dd target is a legal target for
		///     the specifice drag obj
		///     dd obj
		/// </summary>
		/// <param name="the">drag obj</param>
		/// <param name="the2">target</param>
		/// <returns>boolean</returns>
		public static void isLegalTarget(DragDrop the, DragDrop the2) { S_(the, the2); }

		/// <summary>
		///     My goal is to be able to transparently determine if an object is
		///     typeof DragDrop, and the exact subclass of DragDrop.  typeof
		///     returns "object", oDD.constructor.toString() always returns
		///     "DragDrop" and not the name of the subclass.  So for now it just
		///     evaluates a well-known variable in DragDrop.
		/// </summary>
		/// <returns>boolean</returns>
		public static void isTypeOfDD() { S_(); }

		/// <summary>
		///     My goal is to be able to transparently determine if an object is
		///     typeof DragDrop, and the exact subclass of DragDrop.  typeof
		///     returns "object", oDD.constructor.toString() always returns
		///     "DragDrop" and not the name of the subclass.  So for now it just
		///     evaluates a well-known variable in DragDrop.
		/// </summary>
		/// <param name="the">object to evaluate</param>
		/// <returns>boolean</returns>
		public static void isTypeOfDD(object the) { S_(the); }

		/// <summary>
		///     Utility function to determine if a given element has been
		///     registered as a drag drop handle for the given Drag Drop object.
		///     otherwise
		/// </summary>
		/// <returns>boolean</returns>
		public static void isHandle() { S_(); }

		/// <summary>
		///     Utility function to determine if a given element has been
		///     registered as a drag drop handle for the given Drag Drop object.
		///     otherwise
		/// </summary>
		/// <param name="id">the element id to check</param>
		/// <returns>boolean</returns>
		public static void isHandle(System.String id) { S_(id); }

		/// <summary>Returns the DragDrop instance for a given id</summary>
		/// <returns>DragDrop</returns>
		public static void getDDById() { S_(); }

		/// <summary>Returns the DragDrop instance for a given id</summary>
		/// <param name="id">the id of the DragDrop object</param>
		/// <returns>DragDrop</returns>
		public static void getDDById(System.String id) { S_(id); }

		/// <summary>
		///     Fired when either the drag pixel threshol or the mousedown hold
		///     time threshold has been met.
		/// </summary>
		/// <returns></returns>
		public static void startDrag() { S_(); }

		/// <summary>
		///     Fired when either the drag pixel threshol or the mousedown hold
		///     time threshold has been met.
		/// </summary>
		/// <param name="x">{int} the X position of the original mousedown</param>
		/// <returns></returns>
		public static void startDrag(object x) { S_(x); }

		/// <summary>
		///     Fired when either the drag pixel threshol or the mousedown hold
		///     time threshold has been met.
		/// </summary>
		/// <param name="x">{int} the X position of the original mousedown</param>
		/// <param name="y">{int} the Y position of the original mousedown</param>
		/// <returns></returns>
		public static void startDrag(object x, object y) { S_(x, y); }

		/// <summary>
		///     Utility to stop event propagation and event default, if these
		///     features are turned on.
		/// </summary>
		/// <returns></returns>
		public static void stopEvent() { S_(); }

		/// <summary>
		///     Utility to stop event propagation and event default, if these
		///     features are turned on.
		/// </summary>
		/// <param name="e">the event as returned by this.getEvent()</param>
		/// <returns></returns>
		public static void stopEvent(Event e) { S_(e); }

		/// <summary>
		///     Helper function for getting the best match from the list of drag
		///     and drop objects returned by the drag and drop events when we are
		///     in INTERSECT mode.  It returns either the first object that the
		///     cursor is over, or the object that has the greatest overlap with
		///     the dragged element.
		///     targeted
		/// </summary>
		/// <returns>DragDrop</returns>
		public static void getBestMatch() { S_(); }

		/// <summary>
		///     Helper function for getting the best match from the list of drag
		///     and drop objects returned by the drag and drop events when we are
		///     in INTERSECT mode.  It returns either the first object that the
		///     cursor is over, or the object that has the greatest overlap with
		///     the dragged element.
		///     targeted
		/// </summary>
		/// <param name="dds">The array of drag and drop objects</param>
		/// <returns>DragDrop</returns>
		public static void getBestMatch(DragDrop[] dds) { S_(dds); }

		/// <summary>
		///     Refreshes the cache of the top-left and bottom-right points of the
		///     drag and drop objects in the specified group(s).  This is in the
		///     format that is stored in the drag and drop instance, so typical
		///     usage is:
		///     <code>
		///     Ext.dd.DragDropMgr.refreshCache(ddinstance.groups);
		///     </code>
		///     Alternatively:
		///     <code>
		///     Ext.dd.DragDropMgr.refreshCache({group1:true, group2:true});
		///     </code>
		///     @TODO this really should be an indexed array.  Alternatively this
		///     method could accept both.
		/// </summary>
		/// <returns></returns>
		public static void refreshCache() { S_(); }

		/// <summary>
		///     Refreshes the cache of the top-left and bottom-right points of the
		///     drag and drop objects in the specified group(s).  This is in the
		///     format that is stored in the drag and drop instance, so typical
		///     usage is:
		///     <code>
		///     Ext.dd.DragDropMgr.refreshCache(ddinstance.groups);
		///     </code>
		///     Alternatively:
		///     <code>
		///     Ext.dd.DragDropMgr.refreshCache({group1:true, group2:true});
		///     </code>
		///     @TODO this really should be an indexed array.  Alternatively this
		///     method could accept both.
		/// </summary>
		/// <param name="groups">an associative array of groups to refresh</param>
		/// <returns></returns>
		public static void refreshCache(object groups) { S_(groups); }

		/// <summary>
		///     This checks to make sure an element exists and is in the DOM.  The
		///     main purpose is to handle cases where innerHTML is used to remove
		///     drag and drop objects from the DOM.  IE provides an 'unspecified
		///     error' when trying to access the offsetParent of such an element
		/// </summary>
		/// <returns>boolean</returns>
		public static void verifyEl() { S_(); }

		/// <summary>
		///     This checks to make sure an element exists and is in the DOM.  The
		///     main purpose is to handle cases where innerHTML is used to remove
		///     drag and drop objects from the DOM.  IE provides an 'unspecified
		///     error' when trying to access the offsetParent of such an element
		/// </summary>
		/// <param name="el">the element to check</param>
		/// <returns>boolean</returns>
		public static void verifyEl(DOMElement el) { S_(el); }

		/// <summary>
		///     Returns a Region object containing the drag and drop element's position
		///     and size, including the padding configured for it
		///     location for
		///     the element occupies, including any padding
		///     the instance is configured for.
		/// </summary>
		/// <returns>Ext.lib.Region</returns>
		public static void getLocation() { S_(); }

		/// <summary>
		///     Returns a Region object containing the drag and drop element's position
		///     and size, including the padding configured for it
		///     location for
		///     the element occupies, including any padding
		///     the instance is configured for.
		/// </summary>
		/// <param name="oDD">the drag and drop object to get the</param>
		/// <returns>Ext.lib.Region</returns>
		public static void getLocation(DragDrop oDD) { S_(oDD); }

		/// <summary>
		///     Returns the actual DOM element
		///     @deprecated use Ext.lib.Ext.getDom instead
		/// </summary>
		/// <returns>Object</returns>
		public static void getElement() { S_(); }

		/// <summary>
		///     Returns the actual DOM element
		///     @deprecated use Ext.lib.Ext.getDom instead
		/// </summary>
		/// <param name="id">the id of the elment to get</param>
		/// <returns>Object</returns>
		public static void getElement(System.String id) { S_(id); }

		/// <summary>
		///     Returns the style property for the DOM element (i.e.,
		///     document.getElById(id).style)
		///     @deprecated use Ext.lib.Dom instead
		/// </summary>
		/// <returns>Object</returns>
		public static void getCss() { S_(); }

		/// <summary>
		///     Returns the style property for the DOM element (i.e.,
		///     document.getElById(id).style)
		///     @deprecated use Ext.lib.Dom instead
		/// </summary>
		/// <param name="id">the id of the elment to get</param>
		/// <returns>Object</returns>
		public static void getCss(System.String id) { S_(id); }



	}
}
