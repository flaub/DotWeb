using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     History management component that allows you to register arbitrary tokens that signify application
    ///     history state on navigation actions.  You can then handle the history {@link #change} event in order
    ///     to reset your application UI to the appropriate state when the user navigates forward or backward through
    ///     the browser history stack.
    ///     */
    ///     Ext.History = (function () {
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\History.js</jssource>
    [Native]
    public class History : Ext.util.Observable {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public History() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static History prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.util.Observable superclass { get { return null; } set { } }

        /// <summary>The id of the hidden field required for storing the current history token.</summary>
        public static System.String fieldId { get { return null; } set { } }

        /// <summary>The id of the iframe required by IE to manage the history stack.</summary>
        public static System.String iframeId { get { return null; } set { } }


        /// <summary>
        ///     Initialize the global History instance.
        ///     component is fully initialized.
        /// </summary>
        /// <returns></returns>
        public static void init() { return ; }

        /// <summary>
        ///     Initialize the global History instance.
        ///     component is fully initialized.
        /// </summary>
        /// <param name="onReady">(optional) A callback function that will be called once the history</param>
        /// <returns></returns>
        public static void init(bool onReady) { return ; }

        /// <summary>
        ///     Initialize the global History instance.
        ///     component is fully initialized.
        /// </summary>
        /// <param name="onReady">(optional) A callback function that will be called once the history</param>
        /// <param name="scope">(optional) The callback scope</param>
        /// <returns></returns>
        public static void init(bool onReady, object scope) { return ; }

        /// <summary>
        ///     Add a new token to the history stack. This can be any arbitrary value, although it would
        ///     commonly be the concatenation of a component id and another id marking the specifc history
        ///     state of that component.  Example usage:
        ///     <pre><code>
        ///     // Handle tab changes on a TabPanel
        ///     tabPanel.on('tabchange', function(tabPanel, tab){
        ///     Ext.History.add(tabPanel.id + ':' + tab.id);
        ///     });
        ///     </code></pre>
        ///     it will not save a new history step. Set to false if the same state can be saved more than once
        ///     at the same history stack location (defaults to true).
        /// </summary>
        /// <returns></returns>
        public static void add() { return ; }

        /// <summary>
        ///     Add a new token to the history stack. This can be any arbitrary value, although it would
        ///     commonly be the concatenation of a component id and another id marking the specifc history
        ///     state of that component.  Example usage:
        ///     <pre><code>
        ///     // Handle tab changes on a TabPanel
        ///     tabPanel.on('tabchange', function(tabPanel, tab){
        ///     Ext.History.add(tabPanel.id + ':' + tab.id);
        ///     });
        ///     </code></pre>
        ///     it will not save a new history step. Set to false if the same state can be saved more than once
        ///     at the same history stack location (defaults to true).
        /// </summary>
        /// <param name="token">The value that defines a particular application-specific history state</param>
        /// <returns></returns>
        public static void add(System.String token) { return ; }

        /// <summary>
        ///     Add a new token to the history stack. This can be any arbitrary value, although it would
        ///     commonly be the concatenation of a component id and another id marking the specifc history
        ///     state of that component.  Example usage:
        ///     <pre><code>
        ///     // Handle tab changes on a TabPanel
        ///     tabPanel.on('tabchange', function(tabPanel, tab){
        ///     Ext.History.add(tabPanel.id + ':' + tab.id);
        ///     });
        ///     </code></pre>
        ///     it will not save a new history step. Set to false if the same state can be saved more than once
        ///     at the same history stack location (defaults to true).
        /// </summary>
        /// <param name="token">The value that defines a particular application-specific history state</param>
        /// <param name="preventDuplicates">When true, if the passed token matches the current token</param>
        /// <returns></returns>
        public static void add(System.String token, bool preventDuplicates) { return ; }

        /// <summary>Programmatically steps back one step in browser history (equivalent to the user pressing the Back button).</summary>
        /// <returns></returns>
        public static void back() { return ; }

        /// <summary>Programmatically steps forward one step in browser history (equivalent to the user pressing the Forward button).</summary>
        /// <returns></returns>
        public static void forward() { return ; }

        /// <summary>Retrieves the currently-active history token.</summary>
        /// <returns>String</returns>
        public static System.String getToken() { return null; }



    }
    [Anonymous]
    public class HistoryConfig {

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }


}
