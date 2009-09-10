using System;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     Provides easy access to all drag drop components that are registered on a page.  Items can be retrieved either
	///     directly by DOM node id, or by passing in the drag drop event that occurred and looking up the event target.
	///     */
	///     Ext.dd.Registry = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\dd\Registry.js</jssource>
	public class Registry : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Registry() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Registry prototype { get { return S_<Registry>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>
		///     Resgister a drag drop element
		///     in drag drop operations.  You can populate this object with any arbitrary properties that your own code
		///     knows how to interpret, plus there are some specific properties known to the Registry that should be
		///     populated in the data object (if applicable):
		///     <pre>
		///     Value      Description<br />
		///     ---------  ------------------------------------------<br />
		///     handles    Array of DOM nodes that trigger dragging<br />
		///     for the element being registered<br />
		///     isHandle   True if the element passed in triggers<br />
		///     dragging itself, else false
		///     </pre>
		/// </summary>
		/// <returns></returns>
		public static void register() { S_(); }

		/// <summary>
		///     Resgister a drag drop element
		///     in drag drop operations.  You can populate this object with any arbitrary properties that your own code
		///     knows how to interpret, plus there are some specific properties known to the Registry that should be
		///     populated in the data object (if applicable):
		///     <pre>
		///     Value      Description<br />
		///     ---------  ------------------------------------------<br />
		///     handles    Array of DOM nodes that trigger dragging<br />
		///     for the element being registered<br />
		///     isHandle   True if the element passed in triggers<br />
		///     dragging itself, else false
		///     </pre>
		/// </summary>
		/// <param name="element">The id or DOM node to register</param>
		/// <returns></returns>
		public static void register(string element) { S_(element); }

		/// <summary>
		///     Resgister a drag drop element
		///     in drag drop operations.  You can populate this object with any arbitrary properties that your own code
		///     knows how to interpret, plus there are some specific properties known to the Registry that should be
		///     populated in the data object (if applicable):
		///     <pre>
		///     Value      Description<br />
		///     ---------  ------------------------------------------<br />
		///     handles    Array of DOM nodes that trigger dragging<br />
		///     for the element being registered<br />
		///     isHandle   True if the element passed in triggers<br />
		///     dragging itself, else false
		///     </pre>
		/// </summary>
		/// <param name="element">The id or DOM node to register</param>
		/// <param name="data">(optional) An custom data object that will be passed between the elements that are involved</param>
		/// <returns></returns>
		public static void register(string element, object data) { S_(element, data); }

		/// <summary>
		///     Resgister a drag drop element
		///     in drag drop operations.  You can populate this object with any arbitrary properties that your own code
		///     knows how to interpret, plus there are some specific properties known to the Registry that should be
		///     populated in the data object (if applicable):
		///     <pre>
		///     Value      Description<br />
		///     ---------  ------------------------------------------<br />
		///     handles    Array of DOM nodes that trigger dragging<br />
		///     for the element being registered<br />
		///     isHandle   True if the element passed in triggers<br />
		///     dragging itself, else false
		///     </pre>
		/// </summary>
		/// <param name="element">The id or DOM node to register</param>
		/// <returns></returns>
		public static void register(DOMElement element) { S_(element); }

		/// <summary>
		///     Resgister a drag drop element
		///     in drag drop operations.  You can populate this object with any arbitrary properties that your own code
		///     knows how to interpret, plus there are some specific properties known to the Registry that should be
		///     populated in the data object (if applicable):
		///     <pre>
		///     Value      Description<br />
		///     ---------  ------------------------------------------<br />
		///     handles    Array of DOM nodes that trigger dragging<br />
		///     for the element being registered<br />
		///     isHandle   True if the element passed in triggers<br />
		///     dragging itself, else false
		///     </pre>
		/// </summary>
		/// <param name="element">The id or DOM node to register</param>
		/// <param name="data">(optional) An custom data object that will be passed between the elements that are involved</param>
		/// <returns></returns>
		public static void register(DOMElement element, object data) { S_(element, data); }

		/// <summary>Unregister a drag drop element</summary>
		/// <returns></returns>
		public static void unregister() { S_(); }

		/// <summary>Unregister a drag drop element</summary>
		/// <param name="element">The id or DOM node to unregister</param>
		/// <returns></returns>
		public static void unregister(string element) { S_(element); }

		/// <summary>Unregister a drag drop element</summary>
		/// <param name="element">The id or DOM node to unregister</param>
		/// <returns></returns>
		public static void unregister(DOMElement element) { S_(element); }

		/// <summary>Returns the handle registered for a DOM Node by id</summary>
		/// <returns>Object</returns>
		public static void getHandle() { S_(); }

		/// <summary>Returns the handle registered for a DOM Node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public static void getHandle(string id) { S_(id); }

		/// <summary>Returns the handle registered for a DOM Node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public static void getHandle(DOMElement id) { S_(id); }

		/// <summary>Returns the handle that is registered for the DOM node that is the target of the event</summary>
		/// <returns>Object</returns>
		public static void getHandleFromEvent() { S_(); }

		/// <summary>Returns the handle that is registered for the DOM node that is the target of the event</summary>
		/// <param name="e">The event</param>
		/// <returns>Object</returns>
		public static void getHandleFromEvent(Event e) { S_(e); }

		/// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
		/// <returns>Object</returns>
		public static void getTarget() { S_(); }

		/// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public static void getTarget(string id) { S_(id); }

		/// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public static void getTarget(DOMElement id) { S_(id); }

		/// <summary>Returns a custom data object that is registered for the DOM node that is the target of the event</summary>
		/// <returns>Object</returns>
		public static void getTargetFromEvent() { S_(); }

		/// <summary>Returns a custom data object that is registered for the DOM node that is the target of the event</summary>
		/// <param name="e">The event</param>
		/// <returns>Object</returns>
		public static void getTargetFromEvent(Event e) { S_(e); }



	}
}
