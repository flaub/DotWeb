using System;
using H8.Support;

namespace Ext.dd {
    /// <summary>
    ///     /**
    ///     Provides easy access to all drag drop components that are registered on a page.  Items can be retrieved either
    ///     directly by DOM node id, or by passing in the drag drop event that occurred and looking up the event target.
    ///     */
    ///     Ext.dd.Registry = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\dd\Registry.js</jssource>
    [Native]
    public class Registry  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public Registry() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static Registry prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


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
        public static void register() { return ; }

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
        public static void register(System.String element) { return ; }

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
        public static void register(System.String element, object data) { return ; }

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
        public static void register(DOMElement element) { return ; }

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
        public static void register(DOMElement element, object data) { return ; }

        /// <summary>Unregister a drag drop element</summary>
        /// <returns></returns>
        public static void unregister() { return ; }

        /// <summary>Unregister a drag drop element</summary>
        /// <param name="element">The id or DOM node to unregister</param>
        /// <returns></returns>
        public static void unregister(System.String element) { return ; }

        /// <summary>Unregister a drag drop element</summary>
        /// <param name="element">The id or DOM node to unregister</param>
        /// <returns></returns>
        public static void unregister(DOMElement element) { return ; }

        /// <summary>Returns the handle registered for a DOM Node by id</summary>
        /// <returns>Object</returns>
        public static object getHandle() { return null; }

        /// <summary>Returns the handle registered for a DOM Node by id</summary>
        /// <param name="id">The DOM node or id to look up</param>
        /// <returns>Object</returns>
        public static object getHandle(System.String id) { return null; }

        /// <summary>Returns the handle registered for a DOM Node by id</summary>
        /// <param name="id">The DOM node or id to look up</param>
        /// <returns>Object</returns>
        public static object getHandle(DOMElement id) { return null; }

        /// <summary>Returns the handle that is registered for the DOM node that is the target of the event</summary>
        /// <returns>Object</returns>
        public static object getHandleFromEvent() { return null; }

        /// <summary>Returns the handle that is registered for the DOM node that is the target of the event</summary>
        /// <param name="e">The event</param>
        /// <returns>Object</returns>
        public static object getHandleFromEvent(Event e) { return null; }

        /// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
        /// <returns>Object</returns>
        public static object getTarget() { return null; }

        /// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
        /// <param name="id">The DOM node or id to look up</param>
        /// <returns>Object</returns>
        public static object getTarget(System.String id) { return null; }

        /// <summary>Returns a custom data object that is registered for a DOM node by id</summary>
        /// <param name="id">The DOM node or id to look up</param>
        /// <returns>Object</returns>
        public static object getTarget(DOMElement id) { return null; }

        /// <summary>Returns a custom data object that is registered for the DOM node that is the target of the event</summary>
        /// <returns>Object</returns>
        public static object getTargetFromEvent() { return null; }

        /// <summary>Returns a custom data object that is registered for the DOM node that is the target of the event</summary>
        /// <param name="e">The event</param>
        /// <returns>Object</returns>
        public static object getTargetFromEvent(Event e) { return null; }



    }
    [Anonymous]
    public class RegistryConfig {

    }


}
