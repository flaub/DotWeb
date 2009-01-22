using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     A simple utility class for generically masking elements while loading data.  If the {@link #store}
    ///     config option is specified, the masking will be automatically synchronized with the store's loading
    ///     process and the mask element will be cached for reuse.  For all other elements, this mask will replace the
    ///     element's Updater load indicator and will be destroyed after the initial load.
    ///     <p>Example usage:</p>
    ///     <pre><code>
    ///     // Basic mask:
    ///     var myMask = new Ext.LoadMask(Ext.getBody(), {msg:"Please wait..."});
    ///     myMask.show();
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\LoadMask.js</jssource>
    [Native]
    public class LoadMask  {

        /// <summary>Create a new LoadMask</summary>
        /// <returns></returns>
        public LoadMask() {}
        /// <summary>Create a new LoadMask</summary>
        /// <param name="el">The element or DOM node, or its id</param>
        /// <returns></returns>
        public LoadMask(object el) {}
        /// <summary>Create a new LoadMask</summary>
        /// <param name="el">The element or DOM node, or its id</param>
        /// <param name="config">The config object</param>
        /// <returns></returns>
        public LoadMask(object el, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static LoadMask prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>
        ///     Optional Store to which the mask is bound. The mask is displayed when a load request is issued, and
        ///     hidden on either load sucess, or load fail.
        /// </summary>
        public Ext.data.Store store { get { return null; } set { } }

        /// <summary>
        ///     True to create a single-use mask that is automatically destroyed after loading (useful for page loads),
        ///     False to persist the mask element reference for multiple uses (e.g., for paged data widgets).  Defaults to false.
        /// </summary>
        public bool removeMask { get { return false; } set { } }

        /// <summary>The text to display in a centered loading message box (defaults to 'Loading...')</summary>
        public System.String msg { get { return null; } set { } }

        /// <summary>The CSS class to apply to the loading message element (defaults to "x-mask-loading")</summary>
        public System.String msgCls { get { return null; } set { } }

        /// <summary>Read-only. True if the mask is currently disabled so that it will not be displayed (defaults to false)</summary>
        public bool disabled { get { return false; } set { } }


        /// <summary>Disables the mask to prevent it from being displayed</summary>
        /// <returns></returns>
        public virtual void disable() { return ; }

        /// <summary>Enables the mask so that it can be displayed</summary>
        /// <returns></returns>
        public virtual void enable() { return ; }

        /// <summary>Show this LoadMask over the configured Element.</summary>
        /// <returns></returns>
        public virtual void show() { return ; }

        /// <summary>Hide this LoadMask.</summary>
        /// <returns></returns>
        public virtual void hide() { return ; }



    }
    [Anonymous]
    public class LoadMaskConfig {

        /// <summary>  Optional Store to which the mask is bound. The mask is displayed when a load request is issued, and hidden on either load sucess, or load fail.</summary>
        public Ext.data.Store store { get { return null; } set { } }

        /// <summary>  True to create a single-use mask that is automatically destroyed after loading (useful for page loads), False to persist the mask element reference for multiple uses (e.g., for paged data widgets).  Defaults to false.</summary>
        public bool removeMask { get { return false; } set { } }

        /// <summary>  The text to display in a centered loading message box (defaults to 'Loading...')</summary>
        public System.String msg { get { return null; } set { } }

        /// <summary>  The CSS class to apply to the loading message element (defaults to "x-mask-loading")</summary>
        public System.String msgCls { get { return null; } set { } }

    }


}
