using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>An Action is a piece of reusable functionality that can be abstracted out of any particular component so that it
	///     can be usefully shared among multiple components.  Actions let you share handlers, configuration options and UI
	///     updates across any components that support the Action interface (primarily {@link Ext.Toolbar}, {@link Ext.Button}
	///     and {@link Ext.menu.Menu} components).</p>
	///     <p>Aside from supporting the config object interface, any component that needs to use Actions must also support
	///     the following method list, as these will be called as needed by the Action class: setText(string), setIconCls(string),
	///     setDisabled(boolean), setVisible(boolean) and setHandler(function).</p>
	///     Example usage:<br>
	///     <pre><code>
	///     // Define the shared action.  Each component below will have the same
	///     // display text and icon, and will display the same message on click.
	///     var action = new Ext.Action({
	///     text: 'Do something',
	///     handler: function(){
	///     Ext.Msg.alert('Click', 'You did something.');
	///     },
	///     iconCls: 'do-something'
	///     });
	///     var panel = new Ext.Panel({
	///     title: 'Actions',
	///     width:500,
	///     height:300,
	///     tbar: [
	///     // Add the action directly to a toolbar as a menu button
	///     action, {
	///     text: 'Action Menu',
	///     // Add the action to a menu as a text item
	///     menu: [action]
	///     }
	///     ],
	///     items: [
	///     // Add the action to the panel body as a standard button
	///     new Ext.Button(action)
	///     ],
	///     renderTo: Ext.getBody()
	///     });
	///     // Change the text for all components using the action
	///     action.setText('Something else');
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Action.js</jssource>
	public class Action : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern Action();
		/// <summary></summary>
		/// <param name="config">The configuration options</param>
		/// <returns></returns>
		public extern Action(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Ext.form.ActionClass prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The text to set for all components using this action (defaults to '').</summary>
		public extern string text { get; set; }

		/// <summary>The icon CSS class for all components using this action (defaults to '').The class should supply a background image that will be used as the icon image.</summary>
		public extern string iconCls { get; set; }

		/// <summary>True to disable all components using this action, false to enable them (defaults to false).</summary>
		public extern bool disabled { get; set; }

		/// <summary>True to hide all components using this action, false to show them (defaults to false).</summary>
		public extern bool hidden { get; set; }

		/// <summary>The function that will be invoked by each component tied to this actionwhen the component's primary event is triggered (defaults to undefined).</summary>
		public extern Delegate handler { get; set; }

		/// <summary>The scope in which the {@link #handler} function will execute.</summary>
		public extern object scope { get; set; }


		/// <summary>Sets the text to be displayed by all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void setText();

		/// <summary>Sets the text to be displayed by all components using this action.</summary>
		/// <param name="text">The text to display</param>
		/// <returns></returns>
		public extern virtual void setText(string text);

		/// <summary>Gets the text currently displayed by all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void getText();

		/// <summary>
		///     Sets the icon CSS class for all components using this action.  The class should supply
		///     a background image that will be used as the icon image.
		/// </summary>
		/// <returns></returns>
		public extern virtual void setIconClass();

		/// <summary>
		///     Sets the icon CSS class for all components using this action.  The class should supply
		///     a background image that will be used as the icon image.
		/// </summary>
		/// <param name="cls">The CSS class supplying the icon image</param>
		/// <returns></returns>
		public extern virtual void setIconClass(string cls);

		/// <summary>Gets the icon CSS class currently used by all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void getIconClass();

		/// <summary>
		///     Sets the disabled state of all components using this action.  Shortcut method
		///     for {@link #enable} and {@link #disable}.
		/// </summary>
		/// <returns></returns>
		public extern virtual void setDisabled();

		/// <summary>
		///     Sets the disabled state of all components using this action.  Shortcut method
		///     for {@link #enable} and {@link #disable}.
		/// </summary>
		/// <param name="disabled">True to disable the component, false to enable it</param>
		/// <returns></returns>
		public extern virtual void setDisabled(bool disabled);

		/// <summary>Enables all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void enable();

		/// <summary>Disables all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void disable();

		/// <summary>
		///     Returns true if the components using this action are currently disabled, else returns false.  Read-only.
		///     @property
		/// </summary>
		/// <returns></returns>
		public extern virtual void isDisabled();

		/// <summary>
		///     Sets the hidden state of all components using this action.  Shortcut method
		///     for {@link #hide} and {@link #show}.
		/// </summary>
		/// <returns></returns>
		public extern virtual void setHidden();

		/// <summary>
		///     Sets the hidden state of all components using this action.  Shortcut method
		///     for {@link #hide} and {@link #show}.
		/// </summary>
		/// <param name="hidden">True to hide the component, false to show it</param>
		/// <returns></returns>
		public extern virtual void setHidden(bool hidden);

		/// <summary>Shows all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void show();

		/// <summary>Hides all components using this action.</summary>
		/// <returns></returns>
		public extern virtual void hide();

		/// <summary>
		///     Returns true if the components using this action are currently hidden, else returns false.  Read-only.
		///     @property
		/// </summary>
		/// <returns></returns>
		public extern virtual void isHidden();

		/// <summary>
		///     Sets the function that will be called by each component using this action when its primary event is triggered.
		///     will be called with no arguments.
		/// </summary>
		/// <returns></returns>
		public extern virtual void setHandler();

		/// <summary>
		///     Sets the function that will be called by each component using this action when its primary event is triggered.
		///     will be called with no arguments.
		/// </summary>
		/// <param name="fn">The function that will be invoked by the action's components.  The function</param>
		/// <returns></returns>
		public extern virtual void setHandler(Delegate fn);

		/// <summary>
		///     Sets the function that will be called by each component using this action when its primary event is triggered.
		///     will be called with no arguments.
		/// </summary>
		/// <param name="fn">The function that will be invoked by the action's components.  The function</param>
		/// <param name="scope">The scope in which the function will execute</param>
		/// <returns></returns>
		public extern virtual void setHandler(Delegate fn, object scope);

		/// <summary>
		///     Executes the specified function once for each component currently tied to this action.  The function passed
		///     in should accept a single argument that will be an object that supports the basic Action config/method interface.
		/// </summary>
		/// <returns></returns>
		public extern virtual void each();

		/// <summary>
		///     Executes the specified function once for each component currently tied to this action.  The function passed
		///     in should accept a single argument that will be an object that supports the basic Action config/method interface.
		/// </summary>
		/// <param name="fn">The function to execute for each component</param>
		/// <returns></returns>
		public extern virtual void each(Delegate fn);

		/// <summary>
		///     Executes the specified function once for each component currently tied to this action.  The function passed
		///     in should accept a single argument that will be an object that supports the basic Action config/method interface.
		/// </summary>
		/// <param name="fn">The function to execute for each component</param>
		/// <param name="scope">The scope in which the function will execute</param>
		/// <returns></returns>
		public extern virtual void each(Delegate fn, object scope);

		/// <summary>
		///     Executes this action manually using the default handler specified in the original config object.  Any arguments
		///     passed to this function will be passed on to the handler function.
		/// </summary>
		/// <returns></returns>
		public extern virtual void execute();

		/// <summary>
		///     Executes this action manually using the default handler specified in the original config object.  Any arguments
		///     passed to this function will be passed on to the handler function.
		/// </summary>
		/// <param name="args">(optional)</param>
		/// <returns></returns>
		public extern virtual void execute(params object[] args);



	}

	[JsAnonymous]
	public class ActionConfig : System.DotWeb.JsDynamic {
		/// <summary> The text to set for all components using this action (defaults to '').</summary>
		public string text { get { return (string)this["text"]; } set { this["text"] = value; } }

		/// <summary> The icon CSS class for all components using this action (defaults to ''). The class should supply a background image that will be used as the icon image.</summary>
		public string iconCls { get { return (string)this["iconCls"]; } set { this["iconCls"] = value; } }

		/// <summary> True to disable all components using this action, false to enable them (defaults to false).</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary> True to hide all components using this action, false to show them (defaults to false).</summary>
		public bool hidden { get { return (bool)this["hidden"]; } set { this["hidden"] = value; } }

		/// <summary> The function that will be invoked by each component tied to this action when the component's primary event is triggered (defaults to undefined).</summary>
		public Delegate handler { get { return (Delegate)this["handler"]; } set { this["handler"] = value; } }

		/// <summary> The scope in which the {@link #handler} function will execute.</summary>
		public object scope { get { return (object)this["scope"]; } set { this["scope"] = value; } }

	}
}
