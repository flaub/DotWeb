using System;
using H8.Support;

namespace Ext.data {
    /// <summary>
    ///     /**
    ///     An implementation of Ext.data.DataProxy that simply passes the data specified in its constructor
    ///     to the Reader when its load method is called.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\data\MemoryProxy.js</jssource>
    [Native]
    public class MemoryProxy : Ext.data.DataProxy {

        /// <summary></summary>
        /// <returns></returns>
        public MemoryProxy() {}
        /// <summary></summary>
        /// <param name="data">The data object which the Reader uses to construct a block of Ext.data.Records.</param>
        /// <returns></returns>
        public MemoryProxy(object data) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static MemoryProxy prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.data.DataProxy superclass { get { return null; } set { } }


        /// <summary>
        ///     Load data from the requested source (in this case an in-memory
        ///     data object passed to the constructor), read the data object into
        ///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
        ///     process that block using the passed callback.
        ///     object into a block of Ext.data.Records.
        ///     The function must be passed <ul>
        ///     <li>The Record block object</li>
        ///     <li>The "arg" argument from the load function</li>
        ///     <li>A boolean success indicator</li>
        ///     </ul>
        /// </summary>
        /// <returns></returns>
        public virtual void load() { return ; }

        /// <summary>
        ///     Load data from the requested source (in this case an in-memory
        ///     data object passed to the constructor), read the data object into
        ///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
        ///     process that block using the passed callback.
        ///     object into a block of Ext.data.Records.
        ///     The function must be passed <ul>
        ///     <li>The Record block object</li>
        ///     <li>The "arg" argument from the load function</li>
        ///     <li>A boolean success indicator</li>
        ///     </ul>
        /// </summary>
        /// <param name="prms">This parameter is not used by the MemoryProxy class.</param>
        /// <returns></returns>
        public virtual void load(object prms) { return ; }

        /// <summary>
        ///     Load data from the requested source (in this case an in-memory
        ///     data object passed to the constructor), read the data object into
        ///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
        ///     process that block using the passed callback.
        ///     object into a block of Ext.data.Records.
        ///     The function must be passed <ul>
        ///     <li>The Record block object</li>
        ///     <li>The "arg" argument from the load function</li>
        ///     <li>A boolean success indicator</li>
        ///     </ul>
        /// </summary>
        /// <param name="prms">This parameter is not used by the MemoryProxy class.</param>
        /// <param name="reader">The Reader object which converts the data</param>
        /// <returns></returns>
        public virtual void load(object prms, Ext.data.DataReader reader) { return ; }

        /// <summary>
        ///     Load data from the requested source (in this case an in-memory
        ///     data object passed to the constructor), read the data object into
        ///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
        ///     process that block using the passed callback.
        ///     object into a block of Ext.data.Records.
        ///     The function must be passed <ul>
        ///     <li>The Record block object</li>
        ///     <li>The "arg" argument from the load function</li>
        ///     <li>A boolean success indicator</li>
        ///     </ul>
        /// </summary>
        /// <param name="prms">This parameter is not used by the MemoryProxy class.</param>
        /// <param name="reader">The Reader object which converts the data</param>
        /// <param name="callback">The function into which to pass the block of Ext.data.records.</param>
        /// <returns></returns>
        public virtual void load(object prms, Ext.data.DataReader reader, Delegate callback) { return ; }

        /// <summary>
        ///     Load data from the requested source (in this case an in-memory
        ///     data object passed to the constructor), read the data object into
        ///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
        ///     process that block using the passed callback.
        ///     object into a block of Ext.data.Records.
        ///     The function must be passed <ul>
        ///     <li>The Record block object</li>
        ///     <li>The "arg" argument from the load function</li>
        ///     <li>A boolean success indicator</li>
        ///     </ul>
        /// </summary>
        /// <param name="prms">This parameter is not used by the MemoryProxy class.</param>
        /// <param name="reader">The Reader object which converts the data</param>
        /// <param name="callback">The function into which to pass the block of Ext.data.records.</param>
        /// <param name="scope">The scope in which to call the callback</param>
        /// <returns></returns>
        public virtual void load(object prms, Ext.data.DataReader reader, Delegate callback, object scope) { return ; }

        /// <summary>
        ///     Load data from the requested source (in this case an in-memory
        ///     data object passed to the constructor), read the data object into
        ///     a block of Ext.data.Records using the passed Ext.data.DataReader implementation, and
        ///     process that block using the passed callback.
        ///     object into a block of Ext.data.Records.
        ///     The function must be passed <ul>
        ///     <li>The Record block object</li>
        ///     <li>The "arg" argument from the load function</li>
        ///     <li>A boolean success indicator</li>
        ///     </ul>
        /// </summary>
        /// <param name="prms">This parameter is not used by the MemoryProxy class.</param>
        /// <param name="reader">The Reader object which converts the data</param>
        /// <param name="callback">The function into which to pass the block of Ext.data.records.</param>
        /// <param name="scope">The scope in which to call the callback</param>
        /// <param name="arg">An optional argument which is passed to the callback as its second parameter.</param>
        /// <returns></returns>
        public virtual void load(object prms, Ext.data.DataReader reader, Delegate callback, object scope, object arg) { return ; }



    }
    [Anonymous]
    public class MemoryProxyConfig {

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }

    public class MemoryProxyEvents {
        /// <summary>
        ///     Fires if an exception occurs in the Proxy during data loading. Note that this event is also relayed
        ///     through {@link Ext.data.Store}, so you can listen for it directly on any Store instance.
        /// 
        /// <pre><code>
        /// USAGE: ({Object} objthis, {Object} arg, {Object} nul, {Error} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>arg</b></term><description>The callback's arg object passed to the {@link #load} function</description></item>
        /// <item><term><b>nul</b></term><description>This parameter does not apply and will always be null for MemoryProxy</description></item>
        /// <item><term><b>e</b></term><description>The JavaScript Error object caught if the configured Reader could not read the data</description></item>
        /// </list>
        /// </summary>
        public static string loadexception { get { return "loadexception"; } }
    }

    public delegate void MemoryProxyLoadexceptionDelegate(object objthis, object arg, object nul, object e);
}
