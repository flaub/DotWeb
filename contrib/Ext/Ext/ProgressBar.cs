using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>An updateable progress bar component.  The progress bar supports two different modes: manual and automatic.</p>
	///     <p>In manual mode, you are responsible for showing, updating (via {@link #updateProgress}) and clearing the
	///     progress bar as needed from your own code.  This method is most appropriate when you want to show progress
	///     throughout an operation that has predictable points of interest at which you can update the control.</p>
	///     <p>In automatic mode, you simply call {@link #wait} and let the progress bar run indefinitely, only clearing it
	///     once the operation is complete.  You can optionally have the progress bar wait for a specific amount of time
	///     and then clear itself.  Automatic mode is most appropriate for timed operations or asymchronous operations in
	///     which you have no need for indicating intermediate progress.</p>
	///     @cfg {Float} value A floating point value between 0 and 1 (e.g., .5, defaults to 0)
	///     @cfg {String} text The progress bar text (defaults to '')
	///     @cfg {Mixed} textEl The element to render the progress text to (defaults to the progress
	///     bar's internal text element)
	///     @cfg {String} id The progress bar element's id (defaults to an auto-generated id)
	///     */
	///     Ext.ProgressBar = Ext.extend(Ext.BoxComponent, {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\ProgressBar.js</jssource>
	public class ProgressBar : Ext.BoxComponent {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern ProgressBar();
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern ProgressBar(Ext.Element config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern ProgressBar(string config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern ProgressBar(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ProgressBar prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.BoxComponent superclass { get; set; }

		/// <summary>The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')</summary>
		public extern string baseCls { get; set; }


		/// <summary>
		///     Updates the progress bar value, and optionally its text.  If the text argument is not specified,
		///     any existing text value will be unchanged.  To blank out existing text, pass ''.  Note that even
		///     if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for
		///     determining when the progress is complete and calling {@link #reset} to clear and/or hide the control.
		/// </summary>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void updateProgress();

		/// <summary>
		///     Updates the progress bar value, and optionally its text.  If the text argument is not specified,
		///     any existing text value will be unchanged.  To blank out existing text, pass ''.  Note that even
		///     if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for
		///     determining when the progress is complete and calling {@link #reset} to clear and/or hide the control.
		/// </summary>
		/// <param name="value">(optional) A floating point value between 0 and 1 (e.g., .5, defaults to 0)</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void updateProgress(double value);

		/// <summary>
		///     Updates the progress bar value, and optionally its text.  If the text argument is not specified,
		///     any existing text value will be unchanged.  To blank out existing text, pass ''.  Note that even
		///     if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for
		///     determining when the progress is complete and calling {@link #reset} to clear and/or hide the control.
		/// </summary>
		/// <param name="value">(optional) A floating point value between 0 and 1 (e.g., .5, defaults to 0)</param>
		/// <param name="text">(optional) The string to display in the progress text element (defaults to '')</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void updateProgress(double value, string text);

		/// <summary>
		///     Initiates an auto-updating progress bar.  A duration can be specified, in which case the progress
		///     bar will automatically reset after a fixed amount of time and optionally call a callback function
		///     if specified.  If no duration is passed in, then the progress bar will run indefinitely and must
		///     be manually cleared by calling {@link #reset}.  The wait method accepts a config object with
		///     the following properties:
		///     <pre>
		///     Property   Type          Description
		///     ---------- ------------  ----------------------------------------------------------------------
		///     duration   Number        The length of time in milliseconds that the progress bar should
		///     run before resetting itself (defaults to undefined, in which case it
		///     will run indefinitely until reset is called)
		///     interval   Number        The length of time in milliseconds between each progress update
		///     (defaults to 1000 ms)
		///     increment  Number        The number of progress update segments to display within the progress
		///     bar (defaults to 10).  If the bar reaches the end and is still
		///     updating, it will automatically wrap back to the beginning.
		///     text       String        Optional text to display in the progress bar element (defaults to '').
		///     fn         Function      A callback function to execute after the progress bar finishes auto-
		///     updating.  The function will be called with no arguments.  This function
		///     will be ignored if duration is not specified since in that case the
		///     progress bar can only be stopped programmatically, so any required function
		///     should be called by the same code after it resets the progress bar.
		///     scope      Object        The scope that is passed to the callback function (only applies when
		///     duration and fn are both passed).
		///     </pre>
		///     Example usage:
		///     <pre><code>
		///     var p = new Ext.ProgressBar({
		///     renderTo: 'my-el'
		///     });
		///     //Wait for 5 seconds, then update the status el (progress bar will auto-reset)
		///     p.wait({
		///     interval: 100, //bar will move fast!
		///     duration: 5000,
		///     increment: 15,
		///     text: 'Updating...',
		///     scope: this,
		///     fn: function(){
		///     Ext.fly('status').update('Done!');
		///     }
		///     });
		///     //Or update indefinitely until some async action completes, then reset manually
		///     p.wait();
		///     myAction.on('complete', function(){
		///     p.reset();
		///     Ext.fly('status').update('Done!');
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void wait();

		/// <summary>
		///     Initiates an auto-updating progress bar.  A duration can be specified, in which case the progress
		///     bar will automatically reset after a fixed amount of time and optionally call a callback function
		///     if specified.  If no duration is passed in, then the progress bar will run indefinitely and must
		///     be manually cleared by calling {@link #reset}.  The wait method accepts a config object with
		///     the following properties:
		///     <pre>
		///     Property   Type          Description
		///     ---------- ------------  ----------------------------------------------------------------------
		///     duration   Number        The length of time in milliseconds that the progress bar should
		///     run before resetting itself (defaults to undefined, in which case it
		///     will run indefinitely until reset is called)
		///     interval   Number        The length of time in milliseconds between each progress update
		///     (defaults to 1000 ms)
		///     increment  Number        The number of progress update segments to display within the progress
		///     bar (defaults to 10).  If the bar reaches the end and is still
		///     updating, it will automatically wrap back to the beginning.
		///     text       String        Optional text to display in the progress bar element (defaults to '').
		///     fn         Function      A callback function to execute after the progress bar finishes auto-
		///     updating.  The function will be called with no arguments.  This function
		///     will be ignored if duration is not specified since in that case the
		///     progress bar can only be stopped programmatically, so any required function
		///     should be called by the same code after it resets the progress bar.
		///     scope      Object        The scope that is passed to the callback function (only applies when
		///     duration and fn are both passed).
		///     </pre>
		///     Example usage:
		///     <pre><code>
		///     var p = new Ext.ProgressBar({
		///     renderTo: 'my-el'
		///     });
		///     //Wait for 5 seconds, then update the status el (progress bar will auto-reset)
		///     p.wait({
		///     interval: 100, //bar will move fast!
		///     duration: 5000,
		///     increment: 15,
		///     text: 'Updating...',
		///     scope: this,
		///     fn: function(){
		///     Ext.fly('status').update('Done!');
		///     }
		///     });
		///     //Or update indefinitely until some async action completes, then reset manually
		///     p.wait();
		///     myAction.on('complete', function(){
		///     p.reset();
		///     Ext.fly('status').update('Done!');
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="config">(optional) Configuration options</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void wait(object config);

		/// <summary>Returns true if the progress bar is currently in a {@link #wait} operation</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isWaiting();

		/// <summary>
		///     Updates the progress bar text.  If specified, textEl will be updated, otherwise the progress
		///     bar itself will display the updated text.
		/// </summary>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void updateText();

		/// <summary>
		///     Updates the progress bar text.  If specified, textEl will be updated, otherwise the progress
		///     bar itself will display the updated text.
		/// </summary>
		/// <param name="text">(optional) The string to display in the progress text element (defaults to '')</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void updateText(string text);

		/// <summary>
		///     Synchronizes the inner bar width to the proper proportion of the total componet width based
		///     on the current progress {@link #value}.  This will be called automatically when the ProgressBar
		///     is resized by a layout, but if it is rendered auto width, this method can be called from
		///     another resize handler to sync the ProgressBar if necessary.
		/// </summary>
		/// <returns></returns>
		public extern virtual void syncProgressBar();

		/// <summary>Sets the size of the progress bar.</summary>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void setSize();

		/// <summary>Sets the size of the progress bar.</summary>
		/// <param name="width">The new width in pixels</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void setSize(double width);

		/// <summary>Sets the size of the progress bar.</summary>
		/// <param name="width">The new width in pixels</param>
		/// <param name="height">The new height in pixels</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void setSize(double width, double height);

		/// <summary>
		///     Resets the progress bar value to 0 and text to empty string.  If hide = true, the progress
		///     bar will also be hidden (using the {@link #hideMode} property internally).
		/// </summary>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void reset();

		/// <summary>
		///     Resets the progress bar value to 0 and text to empty string.  If hide = true, the progress
		///     bar will also be hidden (using the {@link #hideMode} property internally).
		/// </summary>
		/// <param name="hide">(optional) True to hide the progress bar (defaults to false)</param>
		/// <returns>Ext.ProgressBar</returns>
		public extern virtual void reset(bool hide);



	}

	[JsAnonymous]
	public class ProgressBarConfig : System.DotWeb.JsDynamic {
		/// <summary> @class Ext.ProgressBar @extends Ext.BoxComponent <p>An updateable progress bar component.  The progress bar supports two different modes: manual and automatic.</p> <p>In manual mode, you are responsible for showing, updating (via {@link #updateProgress}) and clearing the progress bar as needed from your own code.  This method is most appropriate when you want to show progress throughout an operation that has predictable points of interest at which you can update the control.</p> <p>In automatic mode, you simply call {@link #wait} and let the progress bar run indefinitely, only clearing it once the operation is complete.  You can optionally have the progress bar wait for a specific amount of time and then clear itself.  Automatic mode is most appropriate for timed operations or asymchronous operations in which you have no need for indicating intermediate progress.</p>A floating point value between 0 and 1 (e.g., .5, defaults to 0)The progress bar text (defaults to '')The element to render the progress text to (defaults to the progress bar's internal text element)The progress bar element's id (defaults to an auto-generated id)</summary>
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }

		/// <summary>  The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')</summary>
		public string baseCls { get { return (string)this["baseCls"]; } set { this["baseCls"] = value; } }

		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get { return (double)this["x"]; } set { this["x"] = value; } }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get { return (double)this["y"]; } set { this["y"] = value; } }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get { return (double)this["pageX"]; } set { this["pageX"] = value; } }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get { return (double)this["pageY"]; } set { this["pageY"] = value; } }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get { return (double)this["height"]; } set { this["height"] = value; } }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get { return (bool)this["autoHeight"]; } set { this["autoHeight"] = value; } }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get { return (bool)this["autoWidth"]; } set { this["autoWidth"] = value; } }

		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get { return (string)this["xtype"]; } set { this["xtype"] = value; } }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get { return (object)this["autoEl"]; } set { this["autoEl"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return (string)this["overCls"]; } set { this["overCls"] = value; } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return (string)this["style"]; } set { this["style"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return (string)this["ctCls"]; } set { this["ctCls"] = value; } }

		/// <summary>  Render this component disabled (default is false).</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get { return (bool)this["hidden"]; } set { this["hidden"] = value; } }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get { return (object)this["plugins"]; } set { this["plugins"] = value; } }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
		public object applyTo { get { return (object)this["applyTo"]; } set { this["applyTo"] = value; } }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get { return (object)this["renderTo"]; } set { this["renderTo"] = value; } }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get { return (bool)this["stateful"]; } set { this["stateful"] = value; } }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public string stateId { get { return (string)this["stateId"]; } set { this["stateId"] = value; } }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public string disabledClass { get { return (string)this["disabledClass"]; } set { this["disabledClass"] = value; } }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get { return (bool)this["allowDomMove"]; } set { this["allowDomMove"] = value; } }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get { return (bool)this["autoShow"]; } set { this["autoShow"] = value; } }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public string hideMode { get { return (string)this["hideMode"]; } set { this["hideMode"] = value; } }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get { return (bool)this["hideParent"]; } set { this["hideParent"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class ProgressBarEvents {
        /// <summary>Fires after each update interval
        /// <pre><code>
        /// USAGE: ({Ext.ProgressBar} objthis, {Number} The, {String} The2)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>The</b></term><description>current progress value</description></item>
        /// <item><term><b>The2</b></term><description>current progress text</description></item>
        /// </list>
        /// </summary>
        public static string update { get { return "update"; } }
    }

    public delegate void ProgressBarUpdateDelegate(Ext.ProgressBar objthis, double The, string The2);
}
