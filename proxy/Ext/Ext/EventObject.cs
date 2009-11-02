using System;
using System.DotWeb;
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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\EventManager.js</jssource>
	public class EventObject : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern EventObject();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static EventObject prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The normal browser event</summary>
		public extern object browserEvent { get; set; }

		/// <summary>The button pressed in a mouse event</summary>
		public extern object button { get; set; }

		/// <summary>True if the shift key was down during the event</summary>
		public extern object shiftKey { get; set; }

		/// <summary>True if the control key was down during the event</summary>
		public extern object ctrlKey { get; set; }

		/// <summary>True if the alt key was down during the event</summary>
		public extern object altKey { get; set; }

		/// <summary>Key constant</summary>
		public extern double BACKSPACE { get; set; }

		/// <summary>Key constant</summary>
		public extern double TAB { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_CENTER { get; set; }

		/// <summary>Key constant</summary>
		public extern double ENTER { get; set; }

		/// <summary>Key constant</summary>
		public extern double RETURN { get; set; }

		/// <summary>Key constant</summary>
		public extern double SHIFT { get; set; }

		/// <summary>Key constant</summary>
		public extern double CTRL { get; set; }

		/// <summary>Key constant</summary>
		public extern double ALT { get; set; }

		/// <summary>Key constant</summary>
		public extern double PAUSE { get; set; }

		/// <summary>Key constant</summary>
		public extern double CAPS_LOCK { get; set; }

		/// <summary>Key constant</summary>
		public extern double ESC { get; set; }

		/// <summary>Key constant</summary>
		public extern double SPACE { get; set; }

		/// <summary>Key constant</summary>
		public extern double PAGE_UP { get; set; }

		/// <summary>Key constant</summary>
		public extern double PAGE_DOWN { get; set; }

		/// <summary>Key constant</summary>
		public extern double END { get; set; }

		/// <summary>Key constant</summary>
		public extern double HOME { get; set; }

		/// <summary>Key constant</summary>
		public extern double LEFT { get; set; }

		/// <summary>Key constant</summary>
		public extern double UP { get; set; }

		/// <summary>Key constant</summary>
		public extern double RIGHT { get; set; }

		/// <summary>Key constant</summary>
		public extern double DOWN { get; set; }

		/// <summary>Key constant</summary>
		public extern double PRINT_SCREEN { get; set; }

		/// <summary>Key constant</summary>
		public extern double INSERT { get; set; }

		/// <summary>Key constant</summary>
		public extern double DELETE { get; set; }

		/// <summary>Key constant</summary>
		public extern double ZERO { get; set; }

		/// <summary>Key constant</summary>
		public extern double ONE { get; set; }

		/// <summary>Key constant</summary>
		public extern double TWO { get; set; }

		/// <summary>Key constant</summary>
		public extern double THREE { get; set; }

		/// <summary>Key constant</summary>
		public extern double FOUR { get; set; }

		/// <summary>Key constant</summary>
		public extern double FIVE { get; set; }

		/// <summary>Key constant</summary>
		public extern double SIX { get; set; }

		/// <summary>Key constant</summary>
		public extern double SEVEN { get; set; }

		/// <summary>Key constant</summary>
		public extern double EIGHT { get; set; }

		/// <summary>Key constant</summary>
		public extern double NINE { get; set; }

		/// <summary>Key constant</summary>
		public extern double A { get; set; }

		/// <summary>Key constant</summary>
		public extern double B { get; set; }

		/// <summary>Key constant</summary>
		public extern double C { get; set; }

		/// <summary>Key constant</summary>
		public extern double D { get; set; }

		/// <summary>Key constant</summary>
		public extern double E { get; set; }

		/// <summary>Key constant</summary>
		public extern double F { get; set; }

		/// <summary>Key constant</summary>
		public extern double G { get; set; }

		/// <summary>Key constant</summary>
		public extern double H { get; set; }

		/// <summary>Key constant</summary>
		public extern double I { get; set; }

		/// <summary>Key constant</summary>
		public extern double J { get; set; }

		/// <summary>Key constant</summary>
		public extern double K { get; set; }

		/// <summary>Key constant</summary>
		public extern double L { get; set; }

		/// <summary>Key constant</summary>
		public extern double M { get; set; }

		/// <summary>Key constant</summary>
		public extern double N { get; set; }

		/// <summary>Key constant</summary>
		public extern double O { get; set; }

		/// <summary>Key constant</summary>
		public extern double P { get; set; }

		/// <summary>Key constant</summary>
		public extern double Q { get; set; }

		/// <summary>Key constant</summary>
		public extern double R { get; set; }

		/// <summary>Key constant</summary>
		public extern double S { get; set; }

		/// <summary>Key constant</summary>
		public extern double T { get; set; }

		/// <summary>Key constant</summary>
		public extern double U { get; set; }

		/// <summary>Key constant</summary>
		public extern double V { get; set; }

		/// <summary>Key constant</summary>
		public extern double W { get; set; }

		/// <summary>Key constant</summary>
		public extern double X { get; set; }

		/// <summary>Key constant</summary>
		public extern double Y { get; set; }

		/// <summary>Key constant</summary>
		public extern double Z { get; set; }

		/// <summary>Key constant</summary>
		public extern double CONTEXT_MENU { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_ZERO { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_ONE { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_TWO { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_THREE { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_FOUR { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_FIVE { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_SIX { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_SEVEN { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_EIGHT { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_NINE { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_MULTIPLY { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_PLUS { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_MINUS { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_PERIOD { get; set; }

		/// <summary>Key constant</summary>
		public extern double NUM_DIVISION { get; set; }

		/// <summary>Key constant</summary>
		public extern double F1 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F2 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F3 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F4 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F5 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F6 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F7 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F8 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F9 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F10 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F11 { get; set; }

		/// <summary>Key constant</summary>
		public extern double F12 { get; set; }


		/// <summary>Stop the event (preventDefault and stopPropagation)</summary>
		/// <returns></returns>
		public extern virtual void stopEvent();

		/// <summary>Prevents the browsers default handling of the event.</summary>
		/// <returns></returns>
		public extern virtual void preventDefault();

		/// <summary>Cancels bubbling of the event.</summary>
		/// <returns></returns>
		public extern virtual void stopPropagation();

		/// <summary>Gets the character code for the event.</summary>
		/// <returns>Number</returns>
		public extern virtual void getCharCode();

		/// <summary>Returns a normalized keyCode for the event.</summary>
		/// <returns>Number</returns>
		public extern virtual void getKey();

		/// <summary>Gets the x coordinate of the event.</summary>
		/// <returns>Number</returns>
		public extern virtual void getPageX();

		/// <summary>Gets the y coordinate of the event.</summary>
		/// <returns>Number</returns>
		public extern virtual void getPageY();

		/// <summary>Gets the time of the event.</summary>
		/// <returns>Number</returns>
		public extern virtual void getTime();

		/// <summary>Gets the page coordinates of the event.</summary>
		/// <returns>Array</returns>
		public extern virtual void getXY();

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <returns>HTMLelement</returns>
		public extern virtual void getTarget();

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <returns>HTMLelement</returns>
		public extern virtual void getTarget(string selector);

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLelement</returns>
		public extern virtual void getTarget(string selector, double maxDepth);

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLelement</returns>
		public extern virtual void getTarget(string selector, double maxDepth, bool returnEl);

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <returns>HTMLelement</returns>
		public extern virtual void getTarget(string selector, object maxDepth);

		/// <summary>
		///     Gets the target for the event.
		///     search as a number or element (defaults to 10 || document.body)
		/// </summary>
		/// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
		/// <param name="maxDepth">(optional) The max depth to</param>
		/// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
		/// <returns>HTMLelement</returns>
		public extern virtual void getTarget(string selector, object maxDepth, bool returnEl);

		/// <summary>Gets the related target.</summary>
		/// <returns>HTMLElement</returns>
		public extern virtual void getRelatedTarget();

		/// <summary>Normalizes mouse wheel delta across browsers</summary>
		/// <returns>Number</returns>
		public extern virtual void getWheelDelta();

		/// <summary>Returns true if the control, meta, shift or alt key was pressed during this event.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void hasModifier();

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
		public extern virtual void within();

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
		public extern virtual void within(object el);

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
		public extern virtual void within(object el, bool related);



	}
}
