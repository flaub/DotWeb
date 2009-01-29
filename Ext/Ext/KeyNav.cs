using System;
using DotWeb.Core;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\util\KeyNav.js</jssource>
    [Native]
    public class KeyNav  {

        /// <summary></summary>
        /// <returns></returns>
        public KeyNav() {}
        /// <summary></summary>
        /// <param name="el">The element to bind to</param>
        /// <returns></returns>
        public KeyNav(object el) {}
        /// <summary></summary>
        /// <param name="el">The element to bind to</param>
        /// <param name="config">The config</param>
        /// <returns></returns>
        public KeyNav(object el, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static KeyNav prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>True to disable this KeyNav instance (defaults to false)</summary>
        public bool disabled { get { return false; } set { } }

        /// <summary>
        ///     The method to call on the {@link Ext.EventObject} after this KeyNav intercepts a key.  Valid values are
        ///     {@link Ext.EventObject#stopEvent}, {@link Ext.EventObject#preventDefault} and
        ///     {@link Ext.EventObject#stopPropagation} (defaults to 'stopEvent')
        /// </summary>
        public System.String defaultEventAction { get { return null; } set { } }

        /// <summary>
        ///     Handle the keydown event instead of keypress (defaults to false).  KeyNav automatically does this for IE since
        ///     IE does not propagate special keys on keypress, but setting this to true will force other browsers to also
        ///     handle keydown instead of keypress.
        /// </summary>
        public bool forceKeyDown { get { return false; } set { } }


        /// <summary>Enable this KeyNav</summary>
        /// <returns></returns>
        public virtual void enable() { return ; }

        /// <summary>Disable this KeyNav</summary>
        /// <returns></returns>
        public virtual void disable() { return ; }



    }
    [Anonymous]
    public class KeyNavConfig {

        /// <summary>  True to disable this KeyNav instance (defaults to false)</summary>
        public bool disabled { get { return false; } set { } }

        /// <summary>  The method to call on the {@link Ext.EventObject} after this KeyNav intercepts a key.  Valid values are {@link Ext.EventObject#stopEvent}, {@link Ext.EventObject#preventDefault} and {@link Ext.EventObject#stopPropagation} (defaults to 'stopEvent')</summary>
        public System.String defaultEventAction { get { return null; } set { } }

        /// <summary>  Handle the keydown event instead of keypress (defaults to false).  KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.</summary>
        public bool forceKeyDown { get { return false; } set { } }

    }


}
