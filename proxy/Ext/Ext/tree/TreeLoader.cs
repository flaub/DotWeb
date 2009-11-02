using System;
using System.DotWeb;
using DotWeb.Client;

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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeLoader.js</jssource>
	public class TreeLoader : Ext.util.Observable {

		/// <summary>Creates a new Treeloader.</summary>
		/// <returns></returns>
		public extern TreeLoader();
		/// <summary>Creates a new Treeloader.</summary>
		/// <param name="config">A config object containing config properties.</param>
		/// <returns></returns>
		public extern TreeLoader(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TreeLoader prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.util.Observable superclass { get; set; }

		/// <summary>
		///     The URL from which to request a Json string whichspecifies an array of node definition objects representing the child nodes
		///     to be loaded.
		/// </summary>
		public extern string dataUrl { get; set; }

		/// <summary>The HTTP request method for loading data (defaults to the value of {@link Ext.Ajax#method}).</summary>
		public extern string requestMethod { get; set; }

		/// <summary>Equivalent to {@link #dataUrl}.</summary>
		public extern string url { get; set; }

		/// <summary>If set to true, the loader recursively loads "children" attributes when doing the first load on nodes.</summary>
		public extern bool preloadChildren { get; set; }

		/// <summary>(optional) An object containing properties whichspecify HTTP parameters to be passed to each request for child nodes.</summary>
		public extern object baseParams { get; set; }

		/// <summary>
		///     (optional) An object containing attributes to be added to all nodescreated by this loader. If the attributes sent by the server have an attribute in this object,
		///     they take priority.
		/// </summary>
		public extern object baseAttrs { get; set; }

		/// <summary>
		///     (optional) An object containing properties whichspecify custom {@link Ext.tree.TreeNodeUI} implementations. If the optional
		///     <i>uiProvider</i> attribute of a returned child node is a string rather
		///     than a reference to a TreeNodeUI implementation, then that string value
		///     is used as a property name in the uiProviders object.
		/// </summary>
		public extern object uiProviders { get; set; }

		/// <summary>(optional) Default to true. Remove previously existingchild nodes before loading.</summary>
		public extern bool clearOnLoad { get; set; }


		/// <summary>
		///     Load an {@link Ext.tree.TreeNode} from the URL specified in the constructor.
		///     This is called automatically when a node is expanded, but may be used to reload
		///     a node (or append new children if the {@link #clearOnLoad} option is false.)
		/// </summary>
		/// <returns></returns>
		public extern virtual void load();

		/// <summary>
		///     Load an {@link Ext.tree.TreeNode} from the URL specified in the constructor.
		///     This is called automatically when a node is expanded, but may be used to reload
		///     a node (or append new children if the {@link #clearOnLoad} option is false.)
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public extern virtual void load(Ext.tree.TreeNode node);

		/// <summary>
		///     Load an {@link Ext.tree.TreeNode} from the URL specified in the constructor.
		///     This is called automatically when a node is expanded, but may be used to reload
		///     a node (or append new children if the {@link #clearOnLoad} option is false.)
		/// </summary>
		/// <param name="node"></param>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern virtual void load(Ext.tree.TreeNode node, Delegate callback);

		/// <summary>Override this function for custom TreeNode node implementation</summary>
		/// <returns></returns>
		public extern virtual void createNode();



	}

	[JsAnonymous]
	public class TreeLoaderConfig : System.DotWeb.JsDynamic {
		/// <summary> The URL from which to request a Json string which specifies an array of node definition objects representing the child nodes to be loaded.</summary>
		public string dataUrl { get { return (string)this["dataUrl"]; } set { this["dataUrl"] = value; } }

		/// <summary> The HTTP request method for loading data (defaults to the value of {@link Ext.Ajax#method}).</summary>
		public string requestMethod { get { return (string)this["requestMethod"]; } set { this["requestMethod"] = value; } }

		/// <summary> Equivalent to {@link #dataUrl}.</summary>
		public string url { get { return (string)this["url"]; } set { this["url"] = value; } }

		/// <summary> If set to true, the loader recursively loads "children" attributes when doing the first load on nodes.</summary>
		public bool preloadChildren { get { return (bool)this["preloadChildren"]; } set { this["preloadChildren"] = value; } }

		/// <summary> (optional) An object containing properties which specify HTTP parameters to be passed to each request for child nodes.</summary>
		public object baseParams { get { return (object)this["baseParams"]; } set { this["baseParams"] = value; } }

		/// <summary> (optional) An object containing attributes to be added to all nodes created by this loader. If the attributes sent by the server have an attribute in this object, they take priority.</summary>
		public object baseAttrs { get { return (object)this["baseAttrs"]; } set { this["baseAttrs"] = value; } }

		/// <summary> (optional) An object containing properties which specify custom {@link Ext.tree.TreeNodeUI} implementations. If the optional <i>uiProvider</i> attribute of a returned child node is a string rather than a reference to a TreeNodeUI implementation, then that string value is used as a property name in the uiProviders object.</summary>
		public object uiProviders { get { return (object)this["uiProviders"]; } set { this["uiProviders"] = value; } }

		/// <summary> (optional) Default to true. Remove previously existing child nodes before loading.</summary>
		public bool clearOnLoad { get { return (bool)this["clearOnLoad"]; } set { this["clearOnLoad"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

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
