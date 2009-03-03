using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     @cfg {TreeLoader} loader A TreeLoader to be used by this node (defaults to the loader defined on the tree)
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\tree\AsyncTreeNode.js</jssource>
	public class AsyncTreeNode : Ext.tree.TreeNode {

		/// <summary></summary>
		/// <returns></returns>
		public AsyncTreeNode() { C_(); }
		/// <summary></summary>
		/// <param name="attributes">The attributes/config for the node or just a string with the text for the node</param>
		/// <returns></returns>
		public AsyncTreeNode(object attributes) { C_(attributes); }
		/// <summary></summary>
		/// <param name="attributes">The attributes/config for the node or just a string with the text for the node</param>
		/// <returns></returns>
		public AsyncTreeNode(System.String attributes) { C_(attributes); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static AsyncTreeNode prototype { get { return S_<AsyncTreeNode>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.tree.TreeNode superclass { get { return S_<Ext.tree.TreeNode>(); } set { S_(value); } }

		/// <summary>The loader used by this node (defaults to using the tree's defined loader)</summary>
		public TreeLoader loader { get { return _<TreeLoader>(); } set { _(value); } }


		/// <summary>Returns true if this node is currently loading</summary>
		/// <returns>Boolean</returns>
		public virtual void isLoading() { _(); }

		/// <summary>Returns true if this node has been loaded</summary>
		/// <returns>Boolean</returns>
		public virtual void isLoaded() { _(); }

		/// <summary>Trigger a reload for this node</summary>
		/// <returns></returns>
		public virtual void reload() { _(); }

		/// <summary>Trigger a reload for this node</summary>
		/// <param name="callback"></param>
		/// <returns></returns>
		public virtual void reload(Delegate callback) { _(callback); }



	}

	[JsAnonymous]
	public class AsyncTreeNodeConfig : DotWeb.Client.JsAccessible {
		/// <summary> A TreeLoader to be used by this node (defaults to the loader defined on the tree)</summary>
		public TreeLoader loader { get; set; }

		/// <summary> The text for this node</summary>
		public System.String text { get; set; }

		/// <summary> true to start the node expanded</summary>
		public bool expanded { get; set; }

		/// <summary> False to make this node undraggable if {@link #draggable} = true (defaults to true)</summary>
		public bool allowDrag { get; set; }

		/// <summary> False if this node cannot have child nodes dropped on it (defaults to true)</summary>
		public bool allowDrop { get; set; }

		/// <summary> true to start the node disabled</summary>
		public bool disabled { get; set; }

		/// <summary> The path to an icon for the node. The preferred way to do this</summary>
		public System.String icon { get; set; }

		/// <summary> A css class to be added to the node</summary>
		public System.String cls { get; set; }

		/// <summary> A css class to be added to the nodes icon element for applying css background images</summary>
		public System.String iconCls { get; set; }

		/// <summary> URL of the link used for the node (defaults to #)</summary>
		public System.String href { get; set; }

		/// <summary> target frame for the link</summary>
		public System.String hrefTarget { get; set; }

		/// <summary> An Ext QuickTip for the node</summary>
		public System.String qtip { get; set; }

		/// <summary> If set to true, the node will always show a plus/minus icon, even when empty</summary>
		public bool expandable { get; set; }

		/// <summary> An Ext QuickTip config for the node (used instead of qtip)</summary>
		public System.String qtipCfg { get; set; }

		/// <summary> True for single click expand on this node</summary>
		public bool singleClickExpand { get; set; }

		/// <summary> A UI <b>class</b> to use for this node (defaults to Ext.tree.TreeNodeUI)</summary>
		public Delegate uiProvider { get; set; }

		/// <summary> True to render a checked checkbox for this node, false to render an unchecked checkbox</summary>
		public bool checked_ { get; set; }

		/// <summary> True to make this node draggable (defaults to false)</summary>
		public bool draggable { get; set; }

		/// <summary> False to not allow this node to act as a drop target (defaults to true)</summary>
		public bool isTarget { get; set; }

		/// <summary> False to not allow this node to have child nodes (defaults to true)</summary>
		public bool allowChildren { get; set; }

		/// <summary> true if this node is a leaf and does not have children</summary>
		public bool leaf { get; set; }

		/// <summary> The id for this node. If one is not specified, one is generated.</summary>
		public System.String id { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class AsyncTreeNodeEvents {
        /// <summary>Fires before this node is loaded, return false to cancel
        /// <pre><code>
        /// USAGE: ({Node} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description>This node</description></item>
        /// </list>
        /// </summary>
        public static string beforeload { get { return "beforeload"; } }
        /// <summary>Fires when this node is loaded
        /// <pre><code>
        /// USAGE: ({Node} objthis)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description>This node</description></item>
        /// </list>
        /// </summary>
        public static string load { get { return "load"; } }
    }

    public delegate void AsyncTreeNodeBeforeloadDelegate(Ext.data.Node objthis);
    public delegate void AsyncTreeNodeLoadDelegate(Ext.data.Node objthis);
}
