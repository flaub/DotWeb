using System;
using DotWeb.Core;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\core\EventManager.js</jssource>
    [Native]
    public class EventObject  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public EventObject() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static EventObject prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The normal browser event</summary>
        public object browserEvent { get { return null; } set { } }

        /// <summary>The button pressed in a mouse event</summary>
        public object button { get { return null; } set { } }

        /// <summary>True if the shift key was down during the event</summary>
        public object shiftKey { get { return null; } set { } }

        /// <summary>True if the control key was down during the event</summary>
        public object ctrlKey { get { return null; } set { } }

        /// <summary>True if the alt key was down during the event</summary>
        public object altKey { get { return null; } set { } }

        /// <summary>Key constant</summary>
        public double BACKSPACE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double TAB { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_CENTER { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double ENTER { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double RETURN { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double SHIFT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double CTRL { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double ALT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double PAUSE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double CAPS_LOCK { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double ESC { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double SPACE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double PAGE_UP { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double PAGE_DOWN { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double END { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double HOME { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double LEFT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double UP { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double RIGHT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double DOWN { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double PRINT_SCREEN { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double INSERT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double DELETE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double ZERO { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double ONE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double TWO { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double THREE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double FOUR { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double FIVE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double SIX { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double SEVEN { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double EIGHT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NINE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double A { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double B { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double C { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double D { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double E { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double G { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double H { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double I { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double J { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double K { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double L { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double M { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double N { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double O { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double P { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double Q { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double R { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double S { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double T { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double U { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double V { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double W { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double X { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double Y { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double Z { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double CONTEXT_MENU { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_ZERO { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_ONE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_TWO { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_THREE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_FOUR { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_FIVE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_SIX { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_SEVEN { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_EIGHT { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_NINE { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_MULTIPLY { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_PLUS { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_MINUS { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_PERIOD { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double NUM_DIVISION { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F1 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F2 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F3 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F4 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F5 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F6 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F7 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F8 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F9 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F10 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F11 { get { return 0; } set { } }

        /// <summary>Key constant</summary>
        public double F12 { get { return 0; } set { } }


        /// <summary>Stop the event (preventDefault and stopPropagation)</summary>
        /// <returns></returns>
        public virtual void stopEvent() { return ; }

        /// <summary>Prevents the browsers default handling of the event.</summary>
        /// <returns></returns>
        public virtual void preventDefault() { return ; }

        /// <summary>Cancels bubbling of the event.</summary>
        /// <returns></returns>
        public virtual void stopPropagation() { return ; }

        /// <summary>Gets the character code for the event.</summary>
        /// <returns>Number</returns>
        public virtual double getCharCode() { return 0; }

        /// <summary>Returns a normalized keyCode for the event.</summary>
        /// <returns>Number</returns>
        public virtual double getKey() { return 0; }

        /// <summary>Gets the x coordinate of the event.</summary>
        /// <returns>Number</returns>
        public virtual double getPageX() { return 0; }

        /// <summary>Gets the y coordinate of the event.</summary>
        /// <returns>Number</returns>
        public virtual double getPageY() { return 0; }

        /// <summary>Gets the time of the event.</summary>
        /// <returns>Number</returns>
        public virtual double getTime() { return 0; }

        /// <summary>Gets the page coordinates of the event.</summary>
        /// <returns>Array</returns>
        public virtual System.Array getXY() { return null; }

        /// <summary>
        ///     Gets the target for the event.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <returns>HTMLelement</returns>
        public virtual DOMElement getTarget() { return null; }

        /// <summary>
        ///     Gets the target for the event.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
        /// <returns>HTMLelement</returns>
        public virtual DOMElement getTarget(System.String selector) { return null; }

        /// <summary>
        ///     Gets the target for the event.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>HTMLelement</returns>
        public virtual DOMElement getTarget(System.String selector, double maxDepth) { return null; }

        /// <summary>
        ///     Gets the target for the event.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
        /// <returns>HTMLelement</returns>
        public virtual DOMElement getTarget(System.String selector, double maxDepth, bool returnEl) { return null; }

        /// <summary>
        ///     Gets the target for the event.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <returns>HTMLelement</returns>
        public virtual DOMElement getTarget(System.String selector, object maxDepth) { return null; }

        /// <summary>
        ///     Gets the target for the event.
        ///     search as a number or element (defaults to 10 || document.body)
        /// </summary>
        /// <param name="selector">(optional) A simple selector to filter the target or look for an ancestor of the target</param>
        /// <param name="maxDepth">(optional) The max depth to</param>
        /// <param name="returnEl">(optional) True to return a Ext.Element object instead of DOM node</param>
        /// <returns>HTMLelement</returns>
        public virtual DOMElement getTarget(System.String selector, object maxDepth, bool returnEl) { return null; }

        /// <summary>Gets the related target.</summary>
        /// <returns>HTMLElement</returns>
        public virtual DOMElement getRelatedTarget() { return null; }

        /// <summary>Normalizes mouse wheel delta across browsers</summary>
        /// <returns>Number</returns>
        public virtual double getWheelDelta() { return 0; }

        /// <summary>Returns true if the control, meta, shift or alt key was pressed during this event.</summary>
        /// <returns>Boolean</returns>
        public virtual bool hasModifier() { return false; }

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
        public virtual bool within() { return false; }

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
        public virtual bool within(object el) { return false; }

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
        public virtual bool within(object el, bool related) { return false; }



    }
    [Anonymous]
    public class EventObjectConfig {

    }


}
