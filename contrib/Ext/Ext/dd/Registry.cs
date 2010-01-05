using System;
using System.DotWeb;
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
	public class Registry : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern Registry();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Registry prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


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
		public extern static void register();

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
		public extern static void register(string element);

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
		public extern static void register(string element, object data);

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
		public extern static void register(DOMElement element);

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
		public extern static void register(DOMElement element, object data);

		/// <summary>Unregister a drag drop element</summary>
		/// <returns></returns>
		public extern static void unregister();

		/// <summary>Unregister a drag drop element</summary>
		/// <param name="element">The id or DOM node to unregister</param>
		/// <returns></returns>
		public extern static void unregister(string element);

		/// <summary>Unregister a drag drop element</summary>
		/// <param name="element">The id or DOM node to unregister</param>
		/// <returns></returns>
		public extern static void unregister(DOMElement element);

		/// <summary>Returns the handle registered for a DOM Node by id</summary>
		/// <returns>Object</returns>
		public extern static void getHandle();

		/// <summary>Returns the handle registered for a DOM Node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public extern static void getHandle(string id);

		/// <summary>Returns the handle registered for a DOM Node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public extern static void getHandle(DOMElement id);

		/// <summary>Returns the handle that is registered for the DOM node that is the target of the event</summary>
		/// <returns>Object</returns>
		public extern static void getHandleFromEvent();

		/// <summary>Returns the handle that is registered for the DOM node that is the target of the event</summary>
		/// <param name="e">The event</param>
		/// <returns>Object</returns>
		public extern static void getHandleFromEvent(Event e);

		/// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
		/// <returns>Object</returns>
		public extern static void getTarget();

		/// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public extern static void getTarget(string id);

		/// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
		/// <param name="id">The DOM node or id to look up</param>
		/// <returns>Object</returns>
		public extern static void getTarget(DOMElement id);

		/// <summary>Returns a custom data object that is registered for the DOM node that is the target of the event</summary>
		/// <returns>Object</returns>
		public extern static void getTargetFromEvent();

		/// <summary>Returns a custom data object that is registered for the DOM node that is the target of the event</summary>
		/// <param name="e">The event</param>
		/// <returns>Object</returns>
		public extern static void getTargetFromEvent(Event e);



	}
}
