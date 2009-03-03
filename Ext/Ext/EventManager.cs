using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Registers event handlers that want to receive a normalized EventObject instead of the standard browser event and provides
	///     several useful events directly.
	///     See {@link Ext.EventObject} for more details on normalized event objects.
	///     */
	///     Ext.EventManager = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\core\EventManager.js</jssource>
	public class EventManager : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public EventManager() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static EventManager prototype { get { return S_<EventManager>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>Url used for onDocumentReady with using SSL (defaults to Ext.SSL_SECURE_URL)</summary>
		public static object ieDeferSrc { get { return S_<object>(); } set { S_(value); } }

		/// <summary>The frequency, in milliseconds, to check for text resize events (defaults to 50)</summary>
		public static int textResizeInterval { get { return S_<int>(); } set { S_(value); } }


		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <returns></returns>
		public static void addListener() { S_(); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <returns></returns>
		public static void addListener(System.String el) { S_(el); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <returns></returns>
		public static void addListener(System.String el, System.String eventName) { S_(el, eventName); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler function the event invokes This function is passed</param>
		/// <returns></returns>
		public static void addListener(System.String el, System.String eventName, Delegate handler) { S_(el, eventName, handler); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler function the event invokes This function is passed</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <returns></returns>
		public static void addListener(System.String el, System.String eventName, Delegate handler, object scope) { S_(el, eventName, handler, scope); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler function the event invokes This function is passed</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <param name="options">(optional) An object containing handler configuration properties.</param>
		/// <returns></returns>
		public static void addListener(System.String el, System.String eventName, Delegate handler, object scope, object options) { S_(el, eventName, handler, scope, options); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <returns></returns>
		public static void addListener(DOMElement el) { S_(el); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <returns></returns>
		public static void addListener(DOMElement el, System.String eventName) { S_(el, eventName); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler function the event invokes This function is passed</param>
		/// <returns></returns>
		public static void addListener(DOMElement el, System.String eventName, Delegate handler) { S_(el, eventName, handler); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler function the event invokes This function is passed</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <returns></returns>
		public static void addListener(DOMElement el, System.String eventName, Delegate handler, object scope) { S_(el, eventName, handler, scope); }

		/// <summary>
		///     Appends an event handler to an element.  The shorthand version {@link #on} is equivalent.  Typically you will
		///     use {@link Ext.Element#addListener} directly on an Element in favor of calling this version.
		///     the following parameters:<ul>
		///     <li>evt : EventObject<div class="sub-desc">The {@link Ext.EventObject EventObject} describing the event.</div></li>
		///     <li>t : Element<div class="sub-desc">The {@link Ext.Element Element} which was the target of the event.
		///     Note that this may be filtered by using the <tt>delegate</tt> option.</div></li>
		///     <li>o : Object<div class="sub-desc">The options object from the addListener call.</div></li>
		///     </ul>
		///     function (the handler function's "this" context)
		///     This may contain any of the following properties:<ul>
		///     <li>scope {Object} : The scope in which to execute the handler function. The handler function's "this" context.</li>
		///     <li>delegate {String} : A simple selector to filter the target or look for a descendant of the target</li>
		///     <li>stopEvent {Boolean} : True to stop the event. That is stop propagation, and prevent the default action.</li>
		///     <li>preventDefault {Boolean} : True to prevent the default action</li>
		///     <li>stopPropagation {Boolean} : True to prevent event propagation</li>
		///     <li>normalized {Boolean} : False to pass a browser event to the handler function instead of an Ext.EventObject</li>
		///     <li>delay {Number} : The number of milliseconds to delay the invocation of the handler after te event fires.</li>
		///     <li>single {Boolean} : True to add a handler to handle just the next firing of the event, and then remove itself.</li>
		///     <li>buffer {Number} : Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</li>
		///     </ul><br>
		///     <p>See {@link Ext.Element#addListener} for examples of how to use these options.</p>
		/// </summary>
		/// <param name="el">The html element or id to assign the event handler to</param>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler function the event invokes This function is passed</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <param name="options">(optional) An object containing handler configuration properties.</param>
		/// <returns></returns>
		public static void addListener(DOMElement el, System.String eventName, Delegate handler, object scope, object options) { S_(el, eventName, handler, scope, options); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <returns></returns>
		public static void removeListener() { S_(); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <returns></returns>
		public static void removeListener(System.String el) { S_(el); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <param name="eventName">The type of event</param>
		/// <returns></returns>
		public static void removeListener(System.String el, System.String eventName) { S_(el, eventName); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <param name="eventName">The type of event</param>
		/// <param name="fn">The handler function to remove</param>
		/// <returns></returns>
		public static void removeListener(System.String el, System.String eventName, Delegate fn) { S_(el, eventName, fn); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <returns></returns>
		public static void removeListener(DOMElement el) { S_(el); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <param name="eventName">The type of event</param>
		/// <returns></returns>
		public static void removeListener(DOMElement el, System.String eventName) { S_(el, eventName); }

		/// <summary>
		///     Removes an event handler from an element.  The shorthand version {@link #un} is equivalent.  Typically
		///     you will use {@link Ext.Element#removeListener} directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <param name="eventName">The type of event</param>
		/// <param name="fn">The handler function to remove</param>
		/// <returns></returns>
		public static void removeListener(DOMElement el, System.String eventName, Delegate fn) { S_(el, eventName, fn); }

		/// <summary>
		///     Removes all event handers from an element.  Typically you will use {@link Ext.Element#removeAllListeners}
		///     directly on an Element in favor of calling this version.
		/// </summary>
		/// <returns></returns>
		public static void removeAll() { S_(); }

		/// <summary>
		///     Removes all event handers from an element.  Typically you will use {@link Ext.Element#removeAllListeners}
		///     directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <returns></returns>
		public static void removeAll(System.String el) { S_(el); }

		/// <summary>
		///     Removes all event handers from an element.  Typically you will use {@link Ext.Element#removeAllListeners}
		///     directly on an Element in favor of calling this version.
		/// </summary>
		/// <param name="el">The id or html element from which to remove the event</param>
		/// <returns></returns>
		public static void removeAll(DOMElement el) { S_(el); }

		/// <summary>
		///     Fires when the document is ready (before onload and before images are loaded). Can be
		///     accessed shorthanded as Ext.onReady().
		/// </summary>
		/// <returns></returns>
		public static void onDocumentReady() { S_(); }

		/// <summary>
		///     Fires when the document is ready (before onload and before images are loaded). Can be
		///     accessed shorthanded as Ext.onReady().
		/// </summary>
		/// <param name="fn">The method the event invokes</param>
		/// <returns></returns>
		public static void onDocumentReady(Delegate fn) { S_(fn); }

		/// <summary>
		///     Fires when the document is ready (before onload and before images are loaded). Can be
		///     accessed shorthanded as Ext.onReady().
		/// </summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">(optional) An object that becomes the scope of the handler</param>
		/// <returns></returns>
		public static void onDocumentReady(Delegate fn, object scope) { S_(fn, scope); }

		/// <summary>
		///     Fires when the document is ready (before onload and before images are loaded). Can be
		///     accessed shorthanded as Ext.onReady().
		/// </summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">(optional) An object that becomes the scope of the handler</param>
		/// <param name="options">(optional) An object containing standard {@link #addListener} options</param>
		/// <returns></returns>
		public static void onDocumentReady(Delegate fn, object scope, bool options) { S_(fn, scope, options); }

		/// <summary>Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.</summary>
		/// <returns></returns>
		public static void onWindowResize() { S_(); }

		/// <summary>Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <returns></returns>
		public static void onWindowResize(Delegate fn) { S_(fn); }

		/// <summary>Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">An object that becomes the scope of the handler</param>
		/// <returns></returns>
		public static void onWindowResize(Delegate fn, object scope) { S_(fn, scope); }

		/// <summary>Fires when the window is resized and provides resize event buffering (50 milliseconds), passes new viewport width and height to handlers.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">An object that becomes the scope of the handler</param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static void onWindowResize(Delegate fn, object scope, bool options) { S_(fn, scope, options); }

		/// <summary>Fires when the user changes the active text size. Handler gets called with 2 params, the old size and the new size.</summary>
		/// <returns></returns>
		public static void onTextResize() { S_(); }

		/// <summary>Fires when the user changes the active text size. Handler gets called with 2 params, the old size and the new size.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <returns></returns>
		public static void onTextResize(Delegate fn) { S_(fn); }

		/// <summary>Fires when the user changes the active text size. Handler gets called with 2 params, the old size and the new size.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">An object that becomes the scope of the handler</param>
		/// <returns></returns>
		public static void onTextResize(Delegate fn, object scope) { S_(fn, scope); }

		/// <summary>Fires when the user changes the active text size. Handler gets called with 2 params, the old size and the new size.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">An object that becomes the scope of the handler</param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static void onTextResize(Delegate fn, object scope, bool options) { S_(fn, scope, options); }

		/// <summary>Removes the passed window resize listener.</summary>
		/// <returns></returns>
		public static void removeResizeListener() { S_(); }

		/// <summary>Removes the passed window resize listener.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <returns></returns>
		public static void removeResizeListener(Delegate fn) { S_(fn); }

		/// <summary>Removes the passed window resize listener.</summary>
		/// <param name="fn">The method the event invokes</param>
		/// <param name="scope">The scope of handler</param>
		/// <returns></returns>
		public static void removeResizeListener(Delegate fn, object scope) { S_(fn, scope); }



	}
}
