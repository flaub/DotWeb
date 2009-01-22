using System;
using H8.Support;

namespace Ext.tree {
    /// <summary>
    ///     /**
    ///     A TreeLoader provides for lazy loading of an {@link Ext.tree.TreeNode}'s child
    ///     nodes from a specified URL. The response must be a JavaScript Array definition
    ///     whose elements are node definition objects. eg:
    ///     <pre><code>
    ///     [{
    ///     id: 1,
    ///     text: 'A leaf Node',
    ///     leaf: true
    ///     },{
    ///     id: 2,
    ///     text: 'A folder Node',
    ///     children: [{
    ///     id: 3,
    ///     text: 'A child Node',
    ///     leaf: true
    ///     }]
    ///     }]
    ///     </code></pre>
    ///     <br><br>
    ///     A server request is sent, and child nodes are loaded only when a node is expanded.
    ///     The loading node's id is passed to the server under the parameter name "node" to
    ///     enable the server to produce the correct child nodes.
    ///     <br><br>
    ///     To pass extra parameters, an event handler may be attached to the "beforeload"
    ///     event, and the parameters specified in the TreeLoader's baseParams property:
    ///     <pre><code>
    ///     myTreeLoader.on("beforeload", function(treeLoader, node) {
    ///     this.baseParams.category = node.attributes.category;
    ///     }, this);
    ///     </code></pre>
    ///     This would pass an HTTP parameter called "category" to the server containing
    ///     the value of the Node's "category" attribute.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\tree\TreeLoader.js</jssource>
    [Native]
    public class TreeLoader : Ext.util.Observable {

        /// <summary>Creates a new Treeloader.</summary>
        /// <returns></returns>
        public TreeLoader() {}
        /// <summary>Creates a new Treeloader.</summary>
        /// <param name="config">A config object containing config properties.</param>
        /// <returns></returns>
        public TreeLoader(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TreeLoader prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.util.Observable superclass { get { return null; } set { } }

        /// <summary>
        ///     The URL from which to request a Json string whichspecifies an array of node definition objects representing the child nodes
        ///     to be loaded.
        /// </summary>
        public System.String dataUrl { get { return null; } set { } }

        /// <summary>The HTTP request method for loading data (defaults to the value of {@link Ext.Ajax#method}).</summary>
        public System.String requestMethod { get { return null; } set { } }

        /// <summary>Equivalent to {@link #dataUrl}.</summary>
        public System.String url { get { return null; } set { } }

        /// <summary>If set to true, the loader recursively loads "children" attributes when doing the first load on nodes.</summary>
        public bool preloadChildren { get { return false; } set { } }

        /// <summary>(optional) An object containing properties whichspecify HTTP parameters to be passed to each request for child nodes.</summary>
        public object baseParams { get { return null; } set { } }

        /// <summary>
        ///     (optional) An object containing attributes to be added to all nodescreated by this loader. If the attributes sent by the server have an attribute in this object,
        ///     they take priority.
        /// </summary>
        public object baseAttrs { get { return null; } set { } }

        /// <summary>
        ///     (optional) An object containing properties whichspecify custom {@link Ext.tree.TreeNodeUI} implementations. If the optional
        ///     <i>uiProvider</i> attribute of a returned child node is a string rather
        ///     than a reference to a TreeNodeUI implementation, then that string value
        ///     is used as a property name in the uiProviders object.
        /// </summary>
        public object uiProviders { get { return null; } set { } }

        /// <summary>(optional) Default to true. Remove previously existingchild nodes before loading.</summary>
        public bool clearOnLoad { get { return false; } set { } }


        /// <summary>
        ///     Load an {@link Ext.tree.TreeNode} from the URL specified in the constructor.
        ///     This is called automatically when a node is expanded, but may be used to reload
        ///     a node (or append new children if the {@link #clearOnLoad} option is false.)
        /// </summary>
        /// <returns></returns>
        public virtual void load() { return ; }

        /// <summary>
        ///     Load an {@link Ext.tree.TreeNode} from the URL specified in the constructor.
        ///     This is called automatically when a node is expanded, but may be used to reload
        ///     a node (or append new children if the {@link #clearOnLoad} option is false.)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual void load(Ext.tree.TreeNode node) { return ; }

        /// <summary>
        ///     Load an {@link Ext.tree.TreeNode} from the URL specified in the constructor.
        ///     This is called automatically when a node is expanded, but may be used to reload
        ///     a node (or append new children if the {@link #clearOnLoad} option is false.)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual void load(Ext.tree.TreeNode node, Delegate callback) { return ; }

        /// <summary>Override this function for custom TreeNode node implementation</summary>
        /// <returns></returns>
        public virtual void createNode() { return ; }



    }
    [Anonymous]
    public class TreeLoaderConfig {

        /// <summary> The URL from which to request a Json string which specifies an array of node definition objects representing the child nodes to be loaded.</summary>
        public System.String dataUrl { get { return null; } set { } }

        /// <summary> The HTTP request method for loading data (defaults to the value of {@link Ext.Ajax#method}).</summary>
        public System.String requestMethod { get { return null; } set { } }

        /// <summary> Equivalent to {@link #dataUrl}.</summary>
        public System.String url { get { return null; } set { } }

        /// <summary> If set to true, the loader recursively loads "children" attributes when doing the first load on nodes.</summary>
        public bool preloadChildren { get { return false; } set { } }

        /// <summary> (optional) An object containing properties which specify HTTP parameters to be passed to each request for child nodes.</summary>
        public object baseParams { get { return null; } set { } }

        /// <summary> (optional) An object containing attributes to be added to all nodes created by this loader. If the attributes sent by the server have an attribute in this object, they take priority.</summary>
        public object baseAttrs { get { return null; } set { } }

        /// <summary> (optional) An object containing properties which specify custom {@link Ext.tree.TreeNodeUI} implementations. If the optional <i>uiProvider</i> attribute of a returned child node is a string rather than a reference to a TreeNodeUI implementation, then that string value is used as a property name in the uiProviders object.</summary>
        public object uiProviders { get { return null; } set { } }

        /// <summary> (optional) Default to true. Remove previously existing child nodes before loading.</summary>
        public bool clearOnLoad { get { return false; } set { } }

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

    }

    public class TreeLoaderEvents {
        /// <summary>Fires before a network request is made to retrieve the Json text which specifies a node's children.
        /// <pre><code>
        /// USAGE: ({Object} This, {Object} node, {Object} callback)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>This</b></term><description>TreeLoader object.</description></item>
        /// <item><term><b>node</b></term><description>The {@link Ext.tree.TreeNode} object being loaded.</description></item>
        /// <item><term><b>callback</b></term><description>The callback function specified in the {@link #load} call.</description></item>
        /// </list>
        /// </summary>
        public static string beforeload { get { return "beforeload"; } }
        /// <summary>Fires when the node has been successfuly loaded.
        /// <pre><code>
        /// USAGE: ({Object} This, {Object} node, {Object} response)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>This</b></term><description>TreeLoader object.</description></item>
        /// <item><term><b>node</b></term><description>The {@link Ext.tree.TreeNode} object being loaded.</description></item>
        /// <item><term><b>response</b></term><description>The response object containing the data from the server.</description></item>
        /// </list>
        /// </summary>
        public static string load { get { return "load"; } }
        /// <summary>Fires if the network request failed.
        /// <pre><code>
        /// USAGE: ({Object} This, {Object} node, {Object} response)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>This</b></term><description>TreeLoader object.</description></item>
        /// <item><term><b>node</b></term><description>The {@link Ext.tree.TreeNode} object being loaded.</description></item>
        /// <item><term><b>response</b></term><description>The response object containing the data from the server.</description></item>
        /// </list>
        /// </summary>
        public static string loadexception { get { return "loadexception"; } }
    }

    public delegate void TreeLoaderBeforeloadDelegate(object This, object node, object callback);
    public delegate void TreeLoaderLoadDelegate(object This, object node, object response);
    public delegate void TreeLoaderLoadexceptionDelegate(object This, object node, object response);
}
