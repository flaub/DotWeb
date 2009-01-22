using System;
using H8.Support;

namespace Ext.data {
    /// <summary>
    ///     /**
    ///     This class is an abstract base class for implementations which provide retrieval of
    ///     unformatted data objects.<br>
    ///     <p>
    ///     DataProxy implementations are usually used in conjunction with an implementation of Ext.data.DataReader
    ///     (of the appropriate type which knows how to parse the data object) to provide a block of
    ///     {@link Ext.data.Records} to an {@link Ext.data.Store}.<br>
    ///     <p>
    ///     Custom implementations must implement the load method as described in
    ///     {@link Ext.data.HttpProxy#load}.
    ///     */
    ///     Ext.data.DataProxy = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\data\DataProxy.js</jssource>
    [Native]
    public class DataProxy : Ext.util.Observable {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public DataProxy() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DataProxy prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.util.Observable superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class DataProxyConfig {

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }

    public class DataProxyEvents {
        /// <summary>Fires before a network request is made to retrieve a data object.
        /// <pre><code>
        /// USAGE: ({Object} objthis, {Object} prms)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>prms</b></term><description>The params object passed to the {@link #load} function</description></item>
        /// </list>
        /// </summary>
        public static string beforeload { get { return "beforeload"; } }
        /// <summary>Fires before the load method's callback is called.
        /// <pre><code>
        /// USAGE: ({Object} objthis, {Object} o, {Object} arg)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>o</b></term><description>The data object</description></item>
        /// <item><term><b>arg</b></term><description>The callback's arg object passed to the {@link #load} function</description></item>
        /// </list>
        /// </summary>
        public static string load { get { return "load"; } }
    }

    public delegate void DataProxyBeforeloadDelegate(object objthis, object prms);
    public delegate void DataProxyLoadDelegate(object objthis, object o, object arg);
}
