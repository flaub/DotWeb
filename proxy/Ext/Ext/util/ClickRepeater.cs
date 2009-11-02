using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     A wrapper class which can be applied to any element. Fires a "click" event while the
	///     mouse is pressed. The interval between firings may be specified in the config but
	///     defaults to 20 milliseconds.
	///     Optionally, a CSS class may be applied to the element during the time it is pressed.
	///     @cfg {Mixed} el The element to act as a button.
	///     @cfg {Number} delay The initial delay before the repeating event begins firing.
	///     Similar to an autorepeat key delay.
	///     @cfg {Number} interval The interval between firings of the "click" event. Default 20 ms.
	///     @cfg {String} pressClass A CSS class name to be applied to the element while pressed.
	///     @cfg {Boolean} accelerate True if autorepeating should start slowly and accelerate.
	///     "interval" and "delay" are ignored.
	///     @cfg {Boolean} preventDefault True to prevent the default click event
	///     @cfg {Boolean} stopDefault True to stop the default click event
	///     @history
	///     2007-02-02 jvs Original code contributed by Nige "Animal" White
	///     2007-02-02 jvs Renamed to ClickRepeater
	///     2007-02-03 jvs Modifications for FF Mac and Safari
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\ClickRepeater.js</jssource>
	public class ClickRepeater : Ext.util.Observable {

		/// <summary></summary>
		/// <returns></returns>
		public extern ClickRepeater();
		/// <summary></summary>
		/// <param name="el">The element to listen on</param>
		/// <returns></returns>
		public extern ClickRepeater(object el);
		/// <summary></summary>
		/// <param name="el">The element to listen on</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern ClickRepeater(object el, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ClickRepeater prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }




	}

	[JsAnonymous]
	public class ClickRepeaterConfig : System.DotWeb.JsDynamic {
		/// <summary> The element to act as a button.</summary>
		public object el { get { return (object)this["el"]; } set { this["el"] = value; } }

		/// <summary> The initial delay before the repeating event begins firing.</summary>
		public double delay { get { return (double)this["delay"]; } set { this["delay"] = value; } }

		/// <summary> The interval between firings of the "click" event. Default 20 ms.</summary>
		public double interval { get { return (double)this["interval"]; } set { this["interval"] = value; } }

		/// <summary> A CSS class name to be applied to the element while pressed.</summary>
		public string pressClass { get { return (string)this["pressClass"]; } set { this["pressClass"] = value; } }

		/// <summary> True if autorepeating should start slowly and accelerate.</summary>
		public bool accelerate { get { return (bool)this["accelerate"]; } set { this["accelerate"] = value; } }

		/// <summary> True to prevent the default click event</summary>
		public bool preventDefault { get { return (bool)this["preventDefault"]; } set { this["preventDefault"] = value; } }

		/// <summary> True to stop the default click event</summary>
		public bool stopDefault { get { return (bool)this["stopDefault"]; } set { this["stopDefault"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class ClickRepeaterEvents {
        /// <summary>Fires when the mouse button is depressed.
        /// <pre><code>
        /// USAGE: ({Ext.util.ClickRepeater} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string mousedown { get { return "mousedown"; } }
        /// <summary>Fires on a specified interval during the time the element is pressed.
        /// <pre><code>
        /// USAGE: ({Ext.util.ClickRepeater} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string click { get { return "click"; } }
        /// <summary>Fires when the mouse key is released.
        /// <pre><code>
        /// USAGE: ({Ext.util.ClickRepeater} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// </list>
        /// </summary>
        public static string mouseup { get { return "mouseup"; } }
    }

    public delegate void ClickRepeaterMousedownDelegate(Ext.util.ClickRepeater objthis);
    public delegate void ClickRepeaterClickDelegate(Ext.util.ClickRepeater objthis);
    public delegate void ClickRepeaterMouseupDelegate(Ext.util.ClickRepeater objthis);
}
