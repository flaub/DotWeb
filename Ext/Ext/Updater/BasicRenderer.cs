using System;
using DotWeb.Core;

namespace Ext.Updater {
    /// <summary>
    ///     /**
    ///     Default Content renderer. Updates the elements innerHTML with the responseText.
    ///     */
    ///     Ext.Updater.BasicRenderer = function(){};
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\core\UpdateManager.js</jssource>
    [Native]
    public class BasicRenderer  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public BasicRenderer() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static BasicRenderer prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>
        ///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
        ///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
        ///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
        /// </summary>
        /// <returns></returns>
        public virtual void render() { return ; }

        /// <summary>
        ///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
        ///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
        ///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
        /// </summary>
        /// <param name="el">The element being rendered</param>
        /// <returns></returns>
        public virtual void render(Ext.Element el) { return ; }

        /// <summary>
        ///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
        ///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
        ///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
        /// </summary>
        /// <param name="el">The element being rendered</param>
        /// <param name="response">The XMLHttpRequest object</param>
        /// <returns></returns>
        public virtual void render(Ext.Element el, object response) { return ; }

        /// <summary>
        ///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
        ///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
        ///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
        /// </summary>
        /// <param name="el">The element being rendered</param>
        /// <param name="response">The XMLHttpRequest object</param>
        /// <param name="updateManager">The calling update manager</param>
        /// <returns></returns>
        public virtual void render(Ext.Element el, object response, Ext.UpdaterClass updateManager) { return ; }

        /// <summary>
        ///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
        ///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
        ///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
        /// </summary>
        /// <param name="el">The element being rendered</param>
        /// <param name="response">The XMLHttpRequest object</param>
        /// <param name="updateManager">The calling update manager</param>
        /// <param name="callback">A callback that will need to be called if loadScripts is true on the Updater</param>
        /// <returns></returns>
        public virtual void render(Ext.Element el, object response, Ext.UpdaterClass updateManager, Delegate callback) { return ; }



    }
    [Anonymous]
    public class BasicRendererConfig {

    }


}
