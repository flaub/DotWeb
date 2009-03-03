using System;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Abstract base class that provides a common interface for publishing events. Subclasses are expected to
	///     to have a property "events" with all the events defined.<br>
	///     For example:
	///     <pre><code>
	///     Employee = function(name){
	///     this.name = name;
	///     this.addEvents({
	///     "fired" : true,
	///     "quit" : true
	///     });
	///     }
	///     Ext.extend(Employee, Ext.util.Observable);
	///     </code></pre>
	///     */
	///     Ext.util.Observable = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\util\Observable.js</jssource>
	public class Observable : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public Observable() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Observable prototype { get { return S_<Observable>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>
		///     A config object containing one or more event handlers to be added to thisobject during initialization.  This should be a valid listeners config object as specified in the
		///     {@link #addListener} example for attaching multiple handlers at once.
		/// </summary>
		public object listeners { get { return _<object>(); } set { _(value); } }


		/// <summary>Fires the specified event with the passed parameters (minus the event name).</summary>
		/// <returns>Boolean</returns>
		public virtual void fireEvent() { _(); }

		/// <summary>Fires the specified event with the passed parameters (minus the event name).</summary>
		/// <param name="eventName"></param>
		/// <returns>Boolean</returns>
		public virtual void fireEvent(System.String eventName) { _(eventName); }

		/// <summary>Fires the specified event with the passed parameters (minus the event name).</summary>
		/// <param name="eventName"></param>
		/// <param name="args">Variable number of parameters are passed to handlers</param>
		/// <returns>Boolean</returns>
		public virtual void fireEvent(System.String eventName, params object[] args) { _(eventName, args); }

		/// <summary>
		///     Appends an event handler to this component
		///     function. The handler function's "this" context.
		///     properties. This may contain any of the following properties:<ul>
		///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
		///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
		///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
		///     <li><b>buffer</b> : Number<p class="sub-desc">Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</p></li>
		///     </ul><br>
		///     <p>
		///     <b>Combining Options</b><br>
		///     Using the options argument, it is possible to combine different types of listeners:<br>
		///     <br>
		///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
		///     <pre><code>
		///     el.on('click', this.onClick, this, {
		///     single: true,
		///     delay: 100,
		///     forumId: 4
		///     });</code></pre>
		///     <p>
		///     <b>Attaching multiple handlers in 1 call</b><br>
		///     The method also allows for a single argument to be passed which is a config object containing properties
		///     which specify multiple handlers.
		///     <p>
		///     <pre><code>
		///     foo.on({
		///     'click' : {
		///     fn: this.onClick,
		///     scope: this,
		///     delay: 100
		///     },
		///     'mouseover' : {
		///     fn: this.onMouseOver,
		///     scope: this
		///     },
		///     'mouseout' : {
		///     fn: this.onMouseOut,
		///     scope: this
		///     }
		///     });</code></pre>
		///     <p>
		///     Or a shorthand syntax:<br>
		///     <pre><code>
		///     foo.on({
		///     'click' : this.onClick,
		///     'mouseover' : this.onMouseOver,
		///     'mouseout' : this.onMouseOut,
		///     scope: this
		///     });</code></pre>
		/// </summary>
		/// <returns></returns>
		public virtual void addListener() { _(); }

		/// <summary>
		///     Appends an event handler to this component
		///     function. The handler function's "this" context.
		///     properties. This may contain any of the following properties:<ul>
		///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
		///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
		///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
		///     <li><b>buffer</b> : Number<p class="sub-desc">Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</p></li>
		///     </ul><br>
		///     <p>
		///     <b>Combining Options</b><br>
		///     Using the options argument, it is possible to combine different types of listeners:<br>
		///     <br>
		///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
		///     <pre><code>
		///     el.on('click', this.onClick, this, {
		///     single: true,
		///     delay: 100,
		///     forumId: 4
		///     });</code></pre>
		///     <p>
		///     <b>Attaching multiple handlers in 1 call</b><br>
		///     The method also allows for a single argument to be passed which is a config object containing properties
		///     which specify multiple handlers.
		///     <p>
		///     <pre><code>
		///     foo.on({
		///     'click' : {
		///     fn: this.onClick,
		///     scope: this,
		///     delay: 100
		///     },
		///     'mouseover' : {
		///     fn: this.onMouseOver,
		///     scope: this
		///     },
		///     'mouseout' : {
		///     fn: this.onMouseOut,
		///     scope: this
		///     }
		///     });</code></pre>
		///     <p>
		///     Or a shorthand syntax:<br>
		///     <pre><code>
		///     foo.on({
		///     'click' : this.onClick,
		///     'mouseover' : this.onMouseOver,
		///     'mouseout' : this.onMouseOut,
		///     scope: this
		///     });</code></pre>
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <returns></returns>
		public virtual void addListener(System.String eventName) { _(eventName); }

		/// <summary>
		///     Appends an event handler to this component
		///     function. The handler function's "this" context.
		///     properties. This may contain any of the following properties:<ul>
		///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
		///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
		///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
		///     <li><b>buffer</b> : Number<p class="sub-desc">Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</p></li>
		///     </ul><br>
		///     <p>
		///     <b>Combining Options</b><br>
		///     Using the options argument, it is possible to combine different types of listeners:<br>
		///     <br>
		///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
		///     <pre><code>
		///     el.on('click', this.onClick, this, {
		///     single: true,
		///     delay: 100,
		///     forumId: 4
		///     });</code></pre>
		///     <p>
		///     <b>Attaching multiple handlers in 1 call</b><br>
		///     The method also allows for a single argument to be passed which is a config object containing properties
		///     which specify multiple handlers.
		///     <p>
		///     <pre><code>
		///     foo.on({
		///     'click' : {
		///     fn: this.onClick,
		///     scope: this,
		///     delay: 100
		///     },
		///     'mouseover' : {
		///     fn: this.onMouseOver,
		///     scope: this
		///     },
		///     'mouseout' : {
		///     fn: this.onMouseOut,
		///     scope: this
		///     }
		///     });</code></pre>
		///     <p>
		///     Or a shorthand syntax:<br>
		///     <pre><code>
		///     foo.on({
		///     'click' : this.onClick,
		///     'mouseover' : this.onMouseOver,
		///     'mouseout' : this.onMouseOut,
		///     scope: this
		///     });</code></pre>
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The method the event invokes</param>
		/// <returns></returns>
		public virtual void addListener(System.String eventName, Delegate handler) { _(eventName, handler); }

		/// <summary>
		///     Appends an event handler to this component
		///     function. The handler function's "this" context.
		///     properties. This may contain any of the following properties:<ul>
		///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
		///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
		///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
		///     <li><b>buffer</b> : Number<p class="sub-desc">Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</p></li>
		///     </ul><br>
		///     <p>
		///     <b>Combining Options</b><br>
		///     Using the options argument, it is possible to combine different types of listeners:<br>
		///     <br>
		///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
		///     <pre><code>
		///     el.on('click', this.onClick, this, {
		///     single: true,
		///     delay: 100,
		///     forumId: 4
		///     });</code></pre>
		///     <p>
		///     <b>Attaching multiple handlers in 1 call</b><br>
		///     The method also allows for a single argument to be passed which is a config object containing properties
		///     which specify multiple handlers.
		///     <p>
		///     <pre><code>
		///     foo.on({
		///     'click' : {
		///     fn: this.onClick,
		///     scope: this,
		///     delay: 100
		///     },
		///     'mouseover' : {
		///     fn: this.onMouseOver,
		///     scope: this
		///     },
		///     'mouseout' : {
		///     fn: this.onMouseOut,
		///     scope: this
		///     }
		///     });</code></pre>
		///     <p>
		///     Or a shorthand syntax:<br>
		///     <pre><code>
		///     foo.on({
		///     'click' : this.onClick,
		///     'mouseover' : this.onMouseOver,
		///     'mouseout' : this.onMouseOut,
		///     scope: this
		///     });</code></pre>
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The method the event invokes</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <returns></returns>
		public virtual void addListener(System.String eventName, Delegate handler, object scope) { _(eventName, handler, scope); }

		/// <summary>
		///     Appends an event handler to this component
		///     function. The handler function's "this" context.
		///     properties. This may contain any of the following properties:<ul>
		///     <li><b>scope</b> : Object<p class="sub-desc">The scope in which to execute the handler function. The handler function's "this" context.</p></li>
		///     <li><b>delay</b> : Number<p class="sub-desc">The number of milliseconds to delay the invocation of the handler after the event fires.</p></li>
		///     <li><b>single</b> : Boolean<p class="sub-desc">True to add a handler to handle just the next firing of the event, and then remove itself.</p></li>
		///     <li><b>buffer</b> : Number<p class="sub-desc">Causes the handler to be scheduled to run in an {@link Ext.util.DelayedTask} delayed
		///     by the specified number of milliseconds. If the event fires again within that time, the original
		///     handler is <em>not</em> invoked, but the new handler is scheduled in its place.</p></li>
		///     </ul><br>
		///     <p>
		///     <b>Combining Options</b><br>
		///     Using the options argument, it is possible to combine different types of listeners:<br>
		///     <br>
		///     A normalized, delayed, one-time listener that auto stops the event and passes a custom argument (forumId)
		///     <pre><code>
		///     el.on('click', this.onClick, this, {
		///     single: true,
		///     delay: 100,
		///     forumId: 4
		///     });</code></pre>
		///     <p>
		///     <b>Attaching multiple handlers in 1 call</b><br>
		///     The method also allows for a single argument to be passed which is a config object containing properties
		///     which specify multiple handlers.
		///     <p>
		///     <pre><code>
		///     foo.on({
		///     'click' : {
		///     fn: this.onClick,
		///     scope: this,
		///     delay: 100
		///     },
		///     'mouseover' : {
		///     fn: this.onMouseOver,
		///     scope: this
		///     },
		///     'mouseout' : {
		///     fn: this.onMouseOut,
		///     scope: this
		///     }
		///     });</code></pre>
		///     <p>
		///     Or a shorthand syntax:<br>
		///     <pre><code>
		///     foo.on({
		///     'click' : this.onClick,
		///     'mouseover' : this.onMouseOver,
		///     'mouseout' : this.onMouseOut,
		///     scope: this
		///     });</code></pre>
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The method the event invokes</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <param name="options">(optional) An object containing handler configuration</param>
		/// <returns></returns>
		public virtual void addListener(System.String eventName, Delegate handler, object scope, object options) { _(eventName, handler, scope, options); }

		/// <summary>Removes a listener</summary>
		/// <returns></returns>
		public virtual void removeListener() { _(); }

		/// <summary>Removes a listener</summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <returns></returns>
		public virtual void removeListener(System.String eventName) { _(eventName); }

		/// <summary>Removes a listener</summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler to remove</param>
		/// <returns></returns>
		public virtual void removeListener(System.String eventName, Delegate handler) { _(eventName, handler); }

		/// <summary>Removes a listener</summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler to remove</param>
		/// <param name="scope">(optional) The scope (this object) for the handler</param>
		/// <returns></returns>
		public virtual void removeListener(System.String eventName, Delegate handler, object scope) { _(eventName, handler, scope); }

		/// <summary>Removes all listeners for this object</summary>
		/// <returns></returns>
		public virtual void purgeListeners() { _(); }

		/// <summary>Relays selected events from the specified Observable as if the events were fired by <tt><b>this</b></tt>.</summary>
		/// <returns></returns>
		public virtual void relayEvents() { _(); }

		/// <summary>Relays selected events from the specified Observable as if the events were fired by <tt><b>this</b></tt>.</summary>
		/// <param name="o">The Observable whose events this object is to relay.</param>
		/// <returns></returns>
		public virtual void relayEvents(object o) { _(o); }

		/// <summary>Relays selected events from the specified Observable as if the events were fired by <tt><b>this</b></tt>.</summary>
		/// <param name="o">The Observable whose events this object is to relay.</param>
		/// <param name="events">Array of event names to relay.</param>
		/// <returns></returns>
		public virtual void relayEvents(object o, System.Array events) { _(o, events); }

		/// <summary>Used to define events on this Observable</summary>
		/// <returns></returns>
		public virtual void addEvents() { _(); }

		/// <summary>Used to define events on this Observable</summary>
		/// <param name="obj">The object with the events defined</param>
		/// <returns></returns>
		public virtual void addEvents(object obj) { _(obj); }

		/// <summary>Checks to see if this object has any listeners for a specified event</summary>
		/// <returns>Boolean</returns>
		public virtual void hasListener() { _(); }

		/// <summary>Checks to see if this object has any listeners for a specified event</summary>
		/// <param name="eventName">The name of the event to check for</param>
		/// <returns>Boolean</returns>
		public virtual void hasListener(System.String eventName) { _(eventName); }

		/// <summary>Suspend the firing of all events. (see {@link #resumeEvents})</summary>
		/// <returns></returns>
		public virtual void suspendEvents() { _(); }

		/// <summary>Resume firing events. (see {@link #suspendEvents})</summary>
		/// <returns></returns>
		public virtual void resumeEvents() { _(); }

		/// <summary>
		///     Appends an event handler to this element (shorthand for addListener)
		///     function. The handler function's "this" context.
		/// </summary>
		/// <returns></returns>
		public virtual void on() { _(); }

		/// <summary>
		///     Appends an event handler to this element (shorthand for addListener)
		///     function. The handler function's "this" context.
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <returns></returns>
		public virtual void on(System.String eventName) { _(eventName); }

		/// <summary>
		///     Appends an event handler to this element (shorthand for addListener)
		///     function. The handler function's "this" context.
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The method the event invokes</param>
		/// <returns></returns>
		public virtual void on(System.String eventName, Delegate handler) { _(eventName, handler); }

		/// <summary>
		///     Appends an event handler to this element (shorthand for addListener)
		///     function. The handler function's "this" context.
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The method the event invokes</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <returns></returns>
		public virtual void on(System.String eventName, Delegate handler, object scope) { _(eventName, handler, scope); }

		/// <summary>
		///     Appends an event handler to this element (shorthand for addListener)
		///     function. The handler function's "this" context.
		/// </summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The method the event invokes</param>
		/// <param name="scope">(optional) The scope in which to execute the handler</param>
		/// <param name="options">(optional)</param>
		/// <returns></returns>
		public virtual void on(System.String eventName, Delegate handler, object scope, object options) { _(eventName, handler, scope, options); }

		/// <summary>Removes a listener (shorthand for removeListener)</summary>
		/// <returns></returns>
		public virtual void un() { _(); }

		/// <summary>Removes a listener (shorthand for removeListener)</summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <returns></returns>
		public virtual void un(System.String eventName) { _(eventName); }

		/// <summary>Removes a listener (shorthand for removeListener)</summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler to remove</param>
		/// <returns></returns>
		public virtual void un(System.String eventName, Delegate handler) { _(eventName, handler); }

		/// <summary>Removes a listener (shorthand for removeListener)</summary>
		/// <param name="eventName">The type of event to listen for</param>
		/// <param name="handler">The handler to remove</param>
		/// <param name="scope">(optional) The scope (this object) for the handler</param>
		/// <returns></returns>
		public virtual void un(System.String eventName, Delegate handler, object scope) { _(eventName, handler, scope); }

		/// <summary>
		///     Starts capture on the specified Observable. All events will be passed
		///     to the supplied function with the event name + standard signature of the event
		///     <b>before</b> the event is fired. If the supplied function returns false,
		///     the event will not fire.
		/// </summary>
		/// <returns></returns>
		public static void capture() { S_(); }

		/// <summary>
		///     Starts capture on the specified Observable. All events will be passed
		///     to the supplied function with the event name + standard signature of the event
		///     <b>before</b> the event is fired. If the supplied function returns false,
		///     the event will not fire.
		/// </summary>
		/// <param name="o">The Observable to capture</param>
		/// <returns></returns>
		public static void capture(Observable o) { S_(o); }

		/// <summary>
		///     Starts capture on the specified Observable. All events will be passed
		///     to the supplied function with the event name + standard signature of the event
		///     <b>before</b> the event is fired. If the supplied function returns false,
		///     the event will not fire.
		/// </summary>
		/// <param name="o">The Observable to capture</param>
		/// <param name="fn">The function to call</param>
		/// <returns></returns>
		public static void capture(Observable o, Delegate fn) { S_(o, fn); }

		/// <summary>
		///     Starts capture on the specified Observable. All events will be passed
		///     to the supplied function with the event name + standard signature of the event
		///     <b>before</b> the event is fired. If the supplied function returns false,
		///     the event will not fire.
		/// </summary>
		/// <param name="o">The Observable to capture</param>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope (this object) for the fn</param>
		/// <returns></returns>
		public static void capture(Observable o, Delegate fn, object scope) { S_(o, fn, scope); }

		/// <summary>Removes <b>all</b> added captures from the Observable.</summary>
		/// <returns></returns>
		public static void releaseCapture() { S_(); }

		/// <summary>Removes <b>all</b> added captures from the Observable.</summary>
		/// <param name="o">The Observable to release</param>
		/// <returns></returns>
		public static void releaseCapture(Observable o) { S_(o); }



	}

	[JsAnonymous]
	public class ObservableConfig : DotWeb.Client.JsAccessible {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}
}
