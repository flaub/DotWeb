using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Provides a convenient wrapper for normalized keyboard navigation.  KeyNav allows you to bind
	///     navigation keys to function calls that will get called when the keys are pressed, providing an easy
	///     way to implement custom navigation schemes for any UI component.</p>
	///     <p>The following are all of the possible keys that can be implemented: enter, left, right, up, down, tab, esc,
	///     pageUp, pageDown, del, home, end.  Usage:</p>
	///     <pre><code>
	///     var nav = new Ext.KeyNav("my-element", {
	///     "left" : function(e){
	///     this.moveLeft(e.ctrlKey);
	///     },
	///     "right" : function(e){
	///     this.moveRight(e.ctrlKey);
	///     },
	///     "enter" : function(e){
	///     this.save();
	///     },
	///     scope : this
	///     });
	///     </code></pre>
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\KeyNav.js</jssource>
	public class KeyNav : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern KeyNav();
		/// <summary></summary>
		/// <param name="el">The element to bind to</param>
		/// <returns></returns>
		public extern KeyNav(object el);
		/// <summary></summary>
		/// <param name="el">The element to bind to</param>
		/// <param name="config">The config</param>
		/// <returns></returns>
		public extern KeyNav(object el, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static KeyNav prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>True to disable this KeyNav instance (defaults to false)</summary>
		public extern bool disabled { get; set; }

		/// <summary>
		///     The method to call on the {@link Ext.EventObject} after this KeyNav intercepts a key.  Valid values are
		///     {@link Ext.EventObject#stopEvent}, {@link Ext.EventObject#preventDefault} and
		///     {@link Ext.EventObject#stopPropagation} (defaults to 'stopEvent')
		/// </summary>
		public extern string defaultEventAction { get; set; }

		/// <summary>
		///     Handle the keydown event instead of keypress (defaults to false).  KeyNav automatically does this for IE since
		///     IE does not propagate special keys on keypress, but setting this to true will force other browsers to also
		///     handle keydown instead of keypress.
		/// </summary>
		public extern bool forceKeyDown { get; set; }


		/// <summary>Enable this KeyNav</summary>
		/// <returns></returns>
		public extern virtual void enable();

		/// <summary>Disable this KeyNav</summary>
		/// <returns></returns>
		public extern virtual void disable();



	}

	[JsAnonymous]
	public class KeyNavConfig : System.DotWeb.JsDynamic {
		/// <summary>  True to disable this KeyNav instance (defaults to false)</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary>  The method to call on the {@link Ext.EventObject} after this KeyNav intercepts a key.  Valid values are {@link Ext.EventObject#stopEvent}, {@link Ext.EventObject#preventDefault} and {@link Ext.EventObject#stopPropagation} (defaults to 'stopEvent')</summary>
		public string defaultEventAction { get { return (string)this["defaultEventAction"]; } set { this["defaultEventAction"] = value; } }

		/// <summary>  Handle the keydown event instead of keypress (defaults to false).  KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.</summary>
		public bool forceKeyDown { get { return (bool)this["forceKeyDown"]; } set { this["forceKeyDown"] = value; } }

	}
}
