using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     EventObject exposes the Yahoo! UI Event functionality directly on the object
	///     passed to your event handler. It exists mostly for convenience. It also fixes the annoying null checks automatically to cleanup your code
	///     Example:
	///     <pre><code>
	///     function handleClick(e){ // e is not a standard event object, it is a Ext.EventObject
	///     e.preventDefault();
	///     var target = e.getTarget();
	///     ...
	///     }
	///     var myDiv = Ext.get("myDiv");
	///     myDiv.on("click", handleClick);
	///     //or
	///     Ext.EventManager.on("myDiv", 'click', handleClick);
	///     Ext.EventManager.addListener("myDiv", 'click', handleClick);
	///     </code></pre>
	///     */
	///     Ext.EventObject = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\core\EventManager.js</jssource>
	public class EventObject : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public EventObject() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static EventObject prototype { get { return S_<EventObject>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The normal browser event</summary>
		public object browserEvent { get { return _<object>(); } set { _(value); } }

		/// <summary>The button pressed in a mouse event</summary>
		public object button { get { return _<object>(); } set { _(value); } }

		/// <summary>True if the shift key was down during the event</summary>
		public object shiftKey { get { return _<object>(); } set { _(value); } }

		/// <summary>True if the control key was down during the event</summary>
		public object ctrlKey { get { return _<object>(); } set { _(value); } }

		/// <summary>True if the alt key was down during the event</summary>
		public object altKey { get { return _<object>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double BACKSPACE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double TAB { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_CENTER { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double ENTER { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double RETURN { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double SHIFT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double CTRL { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double ALT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double PAUSE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double CAPS_LOCK { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double ESC { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double SPACE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double PAGE_UP { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double PAGE_DOWN { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double END { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double HOME { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double LEFT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double UP { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double RIGHT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double DOWN { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double PRINT_SCREEN { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double INSERT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double DELETE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double ZERO { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double ONE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double TWO { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double THREE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double FOUR { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double FIVE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double SIX { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double SEVEN { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double EIGHT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NINE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double A { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double B { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double C { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double D { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double E { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double G { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double H { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double I { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double J { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double K { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double L { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double M { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double N { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double O { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double P { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double Q { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double R { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double S { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double T { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double U { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double V { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double W { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double X { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double Y { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double Z { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double CONTEXT_MENU { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_ZERO { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_ONE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_TWO { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_THREE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_FOUR { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_FIVE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_SIX { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_SEVEN { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_EIGHT { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_NINE { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_MULTIPLY { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_PLUS { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_MINUS { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_PERIOD { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double NUM_DIVISION { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F1 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F2 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F3 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F4 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F5 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F6 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F7 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F8 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F9 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F10 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F11 { get { return _<double>(); } set { _(value); } }

		/// <summary>Key constant</summary>
		public double F12 { get { return _<double>(); } set { _(value); } }


		/// <summary>Stop the event (preventDefault and stopPropagation)</summary>
		/// <returns></returns>
		public virtual void stopEvent() { _(); }

		/// <summary>Prevents the browsers default handling of the event.</summary>
		/// <returns></returns>
		public virtual void preventDefault() { _(); }

		/// <summary>Cancels bubbling of the event.</summary>
		/// <returns></returns>
		public virtual void stopPropagation() { _(); }

		/// <summary>Gets the character code for the event.</summary>
		/// <returns>Number</returns>
		public virtual void getCharCode() { _(); }

		/// <summary>Returns a normalized keyCode for the event.</summary>
		/// <returns>Number</returns>
		public virtual void getKey() { _(); }

		/// <summary>Gets the x coordinate of the event.</summary>
		/// <returns>Number</returns>
		public virtual void getPageX() { _(); }

		/// <summary>Gets the y coordinate of the event.</summary>
		/// <returns>Number</returns>
		public virtual void getPageY() { _(); }

		/// <summary>Gets the time of the event.</summary>
		/// <returns>Number</returns>
		public virtual void getTime() { _(); }

		/// <summary>Gets the page coordinates of the event.</summary>
		/// <returns>Array</returns>
		public virtual void getXY() { _(); }

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <returns>HTMLelement</returns>
		public virtual void getTarget() { _(); }

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <returns>HTMLelement</returns>
		public virtual void getTarget(System.String selector) { _(selector); }

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLelement</returns>
		public virtual void getTarget(System.String selector, double maxDepth) { _(selector, maxDepth); }

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLelement</returns>
		public virtual void getTarget(System.String selector, double maxDepth, bool returnEl) { _(selector, maxDepth, returnEl); }

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLelement</returns>
		public virtual void getTarget(System.String selector, object maxDepth) { _(selector, maxDepth); }

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLelement</returns>
		public virtual void getTarget(System.String selector, object maxDepth, bool returnEl) { _(selector, maxDepth, returnEl); }

		/// <summary>Gets the related target.</summary>
		/// <returns>HTMLElement</returns>
		public virtual void getRelatedTarget() { _(); }

		/// <summary>Normalizes mouse wheel delta across browsers</summary>
		/// <returns>Number</returns>
		public virtual void getWheelDelta() { _(); }

		/// <summary>Returns true if the control, meta, shift or alt key was pressed during this event.</summary>
		/// <returns>Boolean</returns>
		public virtual void hasModifier() { _(); }

		/// <summary>
		///     Returns true if the target of this event is a child of el.  If the target is el, it returns false.
		///     Example usage:<pre><code>
		///     // Handle click on any child of an element
		///     Ext.getBody().on('click', function(e){
		///     if(e.within('some-el')){
		///     alert('Clicked on a child of some-el!');
		///     }
		///     });
		///     // Handle click directly on an element, ignoring clicks on child nodes
		///     Ext.getBody().on('click', function(e,t){
		///     if((t.id == 'some-el') && !e.within(t, true)){
		///     alert('Clicked directly on some-el!');
		///     }
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Boolean</returns>
		public virtual void within() { _(); }

		/// <summary>
		///     Returns true if the target of this event is a child of el.  If the target is el, it returns false.
		///     Example usage:<pre><code>
		///     // Handle click on any child of an element
		///     Ext.getBody().on('click', function(e){
		///     if(e.within('some-el')){
		///     alert('Clicked on a child of some-el!');
		///     }
		///     });
		///     // Handle click directly on an element, ignoring clicks on child nodes
		///     Ext.getBody().on('click', function(e,t){
		///     if((t.id == 'some-el') && !e.within(t, true)){
		///     alert('Clicked directly on some-el!');
		///     }
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="el">The id, DOM element or Ext.Element to check</param>
		/// <returns>Boolean</returns>
		public virtual void within(object el) { _(el); }

		/// <summary>
		///     Returns true if the target of this event is a child of el.  If the target is el, it returns false.
		///     Example usage:<pre><code>
		///     // Handle click on any child of an element
		///     Ext.getBody().on('click', function(e){
		///     if(e.within('some-el')){
		///     alert('Clicked on a child of some-el!');
		///     }
		///     });
		///     // Handle click directly on an element, ignoring clicks on child nodes
		///     Ext.getBody().on('click', function(e,t){
		///     if((t.id == 'some-el') && !e.within(t, true)){
		///     alert('Clicked directly on some-el!');
		///     }
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="el">The id, DOM element or Ext.Element to check</param>
		/// <param name="related">(optional) true to test if the related target is within el instead of the target</param>
		/// <returns>Boolean</returns>
		public virtual void within(object el, bool related) { _(el, related); }



	}
}
