using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     @cfg {TreeLoader} loader A TreeLoader to be used by this node (defaults to the loader defined on the tree)
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\AsyncTreeNode.js</jssource>
	public class AsyncTreeNode : Ext.tree.TreeNode {

		/// <summary></summary>
		/// <returns></returns>
		public extern AsyncTreeNode();
		/// <summary></summary>
		/// <param name="attributes">The attributes/config for the node or just a string with the text for the node</param>
		/// <returns></returns>
		public extern AsyncTreeNode(object attributes);
		/// <summary></summary>
		/// <param name="attributes">The attributes/config for the node or just a string with the text for the node</param>
		/// <returns></returns>
		public extern AsyncTreeNode(string attributes);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static AsyncTreeNode prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.tree.TreeNode superclass { get; set; }

		/// <summary>The loader used by this node (defaults to using the tree's defined loader)</summary>
		public extern TreeLoader loader { get; set; }


		/// <summary>Returns true if this node is currently loading</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isLoading();

		/// <summary>Returns true if this node has been loaded</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isLoaded();

		/// <summary>Trigger a reload for this node</summary>
		/// <returns></returns>
		public extern virtual void reload();

		/// <summary>Trigger a reload for this node</summary>
		/// <param name="callback"></param>
		/// <returns></returns>
		public extern virtual void reload(Delegate callback);



	}

	[JsAnonymous]
	public class AsyncTreeNodeConfig : System.DotWeb.JsDynamic {
		/// <summary> A TreeLoader to be used by this node (defaults to the loader defined on the tree)</summary>
		public TreeLoader loader { get { return (TreeLoader)this["loader"]; } set { this["loader"] = value; } }

		/// <summary> The text for this node</summary>
		public string text { get { return (string)this["text"]; } set { this["text"] = value; } }

		/// <summary> true to start the node expanded</summary>
		public bool expanded { get { return (bool)this["expanded"]; } set { this["expanded"] = value; } }

		/// <summary> False to make this node undraggable if {@link #draggable} = true (defaults to true)</summary>
		public bool allowDrag { get { return (bool)this["allowDrag"]; } set { this["allowDrag"] = value; } }

		/// <summary> False if this node cannot have child nodes dropped on it (defaults to true)</summary>
		public bool allowDrop { get { return (bool)this["allowDrop"]; } set { this["allowDrop"] = value; } }

		/// <summary> true to start the node disabled</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary> The path to an icon for the node. The preferred way to do this</summary>
		public string icon { get { return (string)this["icon"]; } set { this["icon"] = value; } }

		/// <summary> A css class to be added to the node</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

		/// <summary> A css class to be added to the nodes icon element for applying css background images</summary>
		public string iconCls { get { return (string)this["iconCls"]; } set { this["iconCls"] = value; } }

		/// <summary> URL of the link used for the node (defaults to #)</summary>
		public string href { get { return (string)this["href"]; } set { this["href"] = value; } }

		/// <summary> target frame for the link</summary>
		public string hrefTarget { get { return (string)this["hrefTarget"]; } set { this["hrefTarget"] = value; } }

		/// <summary> An Ext QuickTip for the node</summary>
		public string qtip { get { return (string)this["qtip"]; } set { this["qtip"] = value; } }

		/// <summary> If set to true, the node will always show a plus/minus icon, even when empty</summary>
		public bool expandable { get { return (bool)this["expandable"]; } set { this["expandable"] = value; } }

		/// <summary> An Ext QuickTip config for the node (used instead of qtip)</summary>
		public string qtipCfg { get { return (string)this["qtipCfg"]; } set { this["qtipCfg"] = value; } }

		/// <summary> True for single click expand on this node</summary>
		public bool singleClickExpand { get { return (bool)this["singleClickExpand"]; } set { this["singleClickExpand"] = value; } }

		/// <summary> A UI <b>class</b> to use for this node (defaults to Ext.tree.TreeNodeUI)</summary>
		public Delegate uiProvider { get { return (Delegate)this["uiProvider"]; } set { this["uiProvider"] = value; } }

		/// <summary> True to render a checked checkbox for this node, false to render an unchecked checkbox</summary>
		public bool checked_ { get { return (bool)this["checked_"]; } set { this["checked_"] = value; } }

		/// <summary> True to make this node draggable (defaults to false)</summary>
		public bool draggable { get { return (bool)this["draggable"]; } set { this["draggable"] = value; } }

		/// <summary> False to not allow this node to act as a drop target (defaults to true)</summary>
		public bool isTarget { get { return (bool)this["isTarget"]; } set { this["isTarget"] = value; } }

		/// <summary> False to not allow this node to have child nodes (defaults to true)</summary>
		public bool allowChildren { get { return (bool)this["allowChildren"]; } set { this["allowChildren"] = value; } }

		/// <summary> true if this node is a leaf and does not have children</summary>
		public bool leaf { get { return (bool)this["leaf"]; } set { this["leaf"] = value; } }

		/// <summary> The id for this node. If one is not specified, one is generated.</summary>
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

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
