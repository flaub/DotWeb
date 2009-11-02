using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Utility class for manipulating CSS rules
	///     */
	///     Ext.util.CSS = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\util\CSS.js</jssource>
	public class CSS : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern CSS();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static CSS prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>
		///     Creates a stylesheet from a text blob of rules.
		///     These rules will be wrapped in a STYLE tag and appended to the HEAD of the document.
		/// </summary>
		/// <returns>StyleSheet</returns>
		public extern static void createStyleSheet();

		/// <summary>
		///     Creates a stylesheet from a text blob of rules.
		///     These rules will be wrapped in a STYLE tag and appended to the HEAD of the document.
		/// </summary>
		/// <param name="cssText">The text containing the css rules</param>
		/// <returns>StyleSheet</returns>
		public extern static void createStyleSheet(string cssText);

		/// <summary>
		///     Creates a stylesheet from a text blob of rules.
		///     These rules will be wrapped in a STYLE tag and appended to the HEAD of the document.
		/// </summary>
		/// <param name="cssText">The text containing the css rules</param>
		/// <param name="id">An id to add to the stylesheet for later removal</param>
		/// <returns>StyleSheet</returns>
		public extern static void createStyleSheet(string cssText, string id);

		/// <summary>Removes a style or link tag by id</summary>
		/// <returns></returns>
		public extern static void removeStyleSheet();

		/// <summary>Removes a style or link tag by id</summary>
		/// <param name="id">The id of the tag</param>
		/// <returns></returns>
		public extern static void removeStyleSheet(string id);

		/// <summary>Dynamically swaps an existing stylesheet reference for a new one</summary>
		/// <returns></returns>
		public extern static void swapStyleSheet();

		/// <summary>Dynamically swaps an existing stylesheet reference for a new one</summary>
		/// <param name="id">The id of an existing link tag to remove</param>
		/// <returns></returns>
		public extern static void swapStyleSheet(string id);

		/// <summary>Dynamically swaps an existing stylesheet reference for a new one</summary>
		/// <param name="id">The id of an existing link tag to remove</param>
		/// <param name="url">The href of the new stylesheet to include</param>
		/// <returns></returns>
		public extern static void swapStyleSheet(string id, string url);

		/// <summary>Refresh the rule cache if you have dynamically added stylesheets</summary>
		/// <returns>Object</returns>
		public extern static void refreshCache();

		/// <summary>Gets all css rules for the document</summary>
		/// <returns>Object</returns>
		public extern static void getRules();

		/// <summary>Gets all css rules for the document</summary>
		/// <param name="refreshCache">true to refresh the internal cache</param>
		/// <returns>Object</returns>
		public extern static void getRules(bool refreshCache);

		/// <summary>Gets an an individual CSS rule by selector(s)</summary>
		/// <returns>CSSRule</returns>
		public extern static void getRule();

		/// <summary>Gets an an individual CSS rule by selector(s)</summary>
		/// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
		/// <returns>CSSRule</returns>
		public extern static void getRule(string selector);

		/// <summary>Gets an an individual CSS rule by selector(s)</summary>
		/// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
		/// <param name="refreshCache">true to refresh the internal cache if you have recently updated any rules or added styles dynamically</param>
		/// <returns>CSSRule</returns>
		public extern static void getRule(string selector, bool refreshCache);

		/// <summary>Gets an an individual CSS rule by selector(s)</summary>
		/// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
		/// <returns>CSSRule</returns>
		public extern static void getRule(System.Array selector);

		/// <summary>Gets an an individual CSS rule by selector(s)</summary>
		/// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
		/// <param name="refreshCache">true to refresh the internal cache if you have recently updated any rules or added styles dynamically</param>
		/// <returns>CSSRule</returns>
		public extern static void getRule(System.Array selector, bool refreshCache);

		/// <summary>Updates a rule property</summary>
		/// <returns>Boolean</returns>
		public extern static void updateRule();

		/// <summary>Updates a rule property</summary>
		/// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
		/// <returns>Boolean</returns>
		public extern static void updateRule(string selector);

		/// <summary>Updates a rule property</summary>
		/// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
		/// <param name="property">The css property</param>
		/// <returns>Boolean</returns>
		public extern static void updateRule(string selector, string property);

		/// <summary>Updates a rule property</summary>
		/// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
		/// <param name="property">The css property</param>
		/// <param name="value">The new value for the property</param>
		/// <returns>Boolean</returns>
		public extern static void updateRule(string selector, string property, string value);

		/// <summary>Updates a rule property</summary>
		/// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
		/// <returns>Boolean</returns>
		public extern static void updateRule(System.Array selector);

		/// <summary>Updates a rule property</summary>
		/// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
		/// <param name="property">The css property</param>
		/// <returns>Boolean</returns>
		public extern static void updateRule(System.Array selector, string property);

		/// <summary>Updates a rule property</summary>
		/// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
		/// <param name="property">The css property</param>
		/// <param name="value">The new value for the property</param>
		/// <returns>Boolean</returns>
		public extern static void updateRule(System.Array selector, string property, string value);



	}
}
