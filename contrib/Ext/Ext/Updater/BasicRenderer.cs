using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.Updater {
	/// <summary>
	///     /**
	///     Default Content renderer. Updates the elements innerHTML with the responseText.
	///     */
	///     Ext.Updater.BasicRenderer = function(){};
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\core\UpdateManager.js</jssource>
	public class BasicRenderer : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern BasicRenderer();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static BasicRenderer prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>
		///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
		///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
		///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
		/// </summary>
		/// <returns></returns>
		public extern virtual void render();

		/// <summary>
		///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
		///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
		///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
		/// </summary>
		/// <param name="el">The element being rendered</param>
		/// <returns></returns>
		public extern virtual void render(Ext.Element el);

		/// <summary>
		///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
		///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
		///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
		/// </summary>
		/// <param name="el">The element being rendered</param>
		/// <param name="response">The XMLHttpRequest object</param>
		/// <returns></returns>
		public extern virtual void render(Ext.Element el, object response);

		/// <summary>
		///     This is called when the transaction is completed and it's time to update the element - The BasicRenderer
		///     updates the elements innerHTML with the responseText - To perform a custom render (i.e. XML or JSON processing),
		///     create an object with a "render(el, response)" method and pass it to setRenderer on the Updater.
		/// </summary>
		/// <param name="el">The element being rendered</param>
		/// <param name="response">The XMLHttpRequest object</param>
		/// <param name="updateManager">The calling update manager</param>
		/// <returns></returns>
		public extern virtual void render(Ext.Element el, object response, Ext.UpdaterClass updateManager);

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
		public extern virtual void render(Ext.Element el, object response, Ext.UpdaterClass updateManager, Delegate callback);



	}
}
