using System;
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
	public class KeyNav : DotWeb.Client.JsNativeBase {

		/// <summary></summary>
		/// <returns></returns>
		public KeyNav() { C_(); }
		/// <summary></summary>
		/// <param name="el">The element to bind to</param>
		/// <returns></returns>
		public KeyNav(object el) { C_(el); }
		/// <summary></summary>
		/// <param name="el">The element to bind to</param>
		/// <param name="config">The config</param>
		/// <returns></returns>
		public KeyNav(object el, object config) { C_(el, config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static KeyNav prototype { get { return S_<KeyNav>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>True to disable this KeyNav instance (defaults to false)</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

		/// <summary>
		///     The method to call on the {@link Ext.EventObject} after this KeyNav intercepts a key.  Valid values are
		///     {@link Ext.EventObject#stopEvent}, {@link Ext.EventObject#preventDefault} and
		///     {@link Ext.EventObject#stopPropagation} (defaults to 'stopEvent')
		/// </summary>
		public string defaultEventAction { get { return _<string>(); } set { _(value); } }

		/// <summary>
		///     Handle the keydown event instead of keypress (defaults to false).  KeyNav automatically does this for IE since
		///     IE does not propagate special keys on keypress, but setting this to true will force other browsers to also
		///     handle keydown instead of keypress.
		/// </summary>
		public bool forceKeyDown { get { return _<bool>(); } set { _(value); } }


		/// <summary>Enable this KeyNav</summary>
		/// <returns></returns>
		public virtual void enable() { _(); }

		/// <summary>Disable this KeyNav</summary>
		/// <returns></returns>
		public virtual void disable() { _(); }



	}

	[JsAnonymous]
	public class KeyNavConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>  True to disable this KeyNav instance (defaults to false)</summary>
		public bool disabled { get { return _<bool>(); } set { _(value); } }

		/// <summary>  The method to call on the {@link Ext.EventObject} after this KeyNav intercepts a key.  Valid values are {@link Ext.EventObject#stopEvent}, {@link Ext.EventObject#preventDefault} and {@link Ext.EventObject#stopPropagation} (defaults to 'stopEvent')</summary>
		public string defaultEventAction { get { return _<string>(); } set { _(value); } }

		/// <summary>  Handle the keydown event instead of keypress (defaults to false).  KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.</summary>
		public bool forceKeyDown { get { return _<bool>(); } set { _(value); } }

	}
}
