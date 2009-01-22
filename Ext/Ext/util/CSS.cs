using System;
using H8.Support;

namespace Ext.util {
    /// <summary>
    ///     /**
    ///     Utility class for manipulating CSS rules
    ///     */
    ///     Ext.util.CSS = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\CSS.js</jssource>
    [Native]
    public class CSS  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public CSS() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static CSS prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>
        ///     Creates a stylesheet from a text blob of rules.
        ///     These rules will be wrapped in a STYLE tag and appended to the HEAD of the document.
        /// </summary>
        /// <returns>StyleSheet</returns>
        public static object createStyleSheet() { return null; }

        /// <summary>
        ///     Creates a stylesheet from a text blob of rules.
        ///     These rules will be wrapped in a STYLE tag and appended to the HEAD of the document.
        /// </summary>
        /// <param name="cssText">The text containing the css rules</param>
        /// <returns>StyleSheet</returns>
        public static object createStyleSheet(System.String cssText) { return null; }

        /// <summary>
        ///     Creates a stylesheet from a text blob of rules.
        ///     These rules will be wrapped in a STYLE tag and appended to the HEAD of the document.
        /// </summary>
        /// <param name="cssText">The text containing the css rules</param>
        /// <param name="id">An id to add to the stylesheet for later removal</param>
        /// <returns>StyleSheet</returns>
        public static object createStyleSheet(System.String cssText, System.String id) { return null; }

        /// <summary>Removes a style or link tag by id</summary>
        /// <returns></returns>
        public static void removeStyleSheet() { return ; }

        /// <summary>Removes a style or link tag by id</summary>
        /// <param name="id">The id of the tag</param>
        /// <returns></returns>
        public static void removeStyleSheet(System.String id) { return ; }

        /// <summary>Dynamically swaps an existing stylesheet reference for a new one</summary>
        /// <returns></returns>
        public static void swapStyleSheet() { return ; }

        /// <summary>Dynamically swaps an existing stylesheet reference for a new one</summary>
        /// <param name="id">The id of an existing link tag to remove</param>
        /// <returns></returns>
        public static void swapStyleSheet(System.String id) { return ; }

        /// <summary>Dynamically swaps an existing stylesheet reference for a new one</summary>
        /// <param name="id">The id of an existing link tag to remove</param>
        /// <param name="url">The href of the new stylesheet to include</param>
        /// <returns></returns>
        public static void swapStyleSheet(System.String id, System.String url) { return ; }

        /// <summary>Refresh the rule cache if you have dynamically added stylesheets</summary>
        /// <returns>Object</returns>
        public static object refreshCache() { return null; }

        /// <summary>Gets all css rules for the document</summary>
        /// <returns>Object</returns>
        public static object getRules() { return null; }

        /// <summary>Gets all css rules for the document</summary>
        /// <param name="refreshCache">true to refresh the internal cache</param>
        /// <returns>Object</returns>
        public static object getRules(bool refreshCache) { return null; }

        /// <summary>Gets an an individual CSS rule by selector(s)</summary>
        /// <returns>CSSRule</returns>
        public static object getRule() { return null; }

        /// <summary>Gets an an individual CSS rule by selector(s)</summary>
        /// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
        /// <returns>CSSRule</returns>
        public static object getRule(System.String selector) { return null; }

        /// <summary>Gets an an individual CSS rule by selector(s)</summary>
        /// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
        /// <param name="refreshCache">true to refresh the internal cache if you have recently updated any rules or added styles dynamically</param>
        /// <returns>CSSRule</returns>
        public static object getRule(System.String selector, bool refreshCache) { return null; }

        /// <summary>Gets an an individual CSS rule by selector(s)</summary>
        /// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
        /// <returns>CSSRule</returns>
        public static object getRule(System.Array selector) { return null; }

        /// <summary>Gets an an individual CSS rule by selector(s)</summary>
        /// <param name="selector">The CSS selector or an array of selectors to try. The first selector that is found is returned.</param>
        /// <param name="refreshCache">true to refresh the internal cache if you have recently updated any rules or added styles dynamically</param>
        /// <returns>CSSRule</returns>
        public static object getRule(System.Array selector, bool refreshCache) { return null; }

        /// <summary>Updates a rule property</summary>
        /// <returns>Boolean</returns>
        public static bool updateRule() { return false; }

        /// <summary>Updates a rule property</summary>
        /// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
        /// <returns>Boolean</returns>
        public static bool updateRule(System.String selector) { return false; }

        /// <summary>Updates a rule property</summary>
        /// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
        /// <param name="property">The css property</param>
        /// <returns>Boolean</returns>
        public static bool updateRule(System.String selector, System.String property) { return false; }

        /// <summary>Updates a rule property</summary>
        /// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
        /// <param name="property">The css property</param>
        /// <param name="value">The new value for the property</param>
        /// <returns>Boolean</returns>
        public static bool updateRule(System.String selector, System.String property, System.String value) { return false; }

        /// <summary>Updates a rule property</summary>
        /// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
        /// <returns>Boolean</returns>
        public static bool updateRule(System.Array selector) { return false; }

        /// <summary>Updates a rule property</summary>
        /// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
        /// <param name="property">The css property</param>
        /// <returns>Boolean</returns>
        public static bool updateRule(System.Array selector, System.String property) { return false; }

        /// <summary>Updates a rule property</summary>
        /// <param name="selector">If it's an array it tries each selector until it finds one. Stops immediately once one is found.</param>
        /// <param name="property">The css property</param>
        /// <param name="value">The new value for the property</param>
        /// <returns>Boolean</returns>
        public static bool updateRule(System.Array selector, System.String property, System.String value) { return false; }



    }
    [Anonymous]
    public class CSSConfig {

    }


}
