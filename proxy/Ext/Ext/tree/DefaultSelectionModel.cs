using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     The default single selection for a TreePanel.
	///     */
	///     Ext.tree.DefaultSelectionModel = function(config){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeSelectionModel.js</jssource>
	public class DefaultSelectionModel : Ext.util.Observable {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public DefaultSelectionModel() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DefaultSelectionModel prototype { get { return S_<DefaultSelectionModel>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.util.Observable superclass { get { return S_<Ext.util.Observable>(); } set { S_(value); } }


		/// <summary>Select a node.</summary>
		/// <returns>TreeNode</returns>
		public virtual void select() { _(); }

		/// <summary>Select a node.</summary>
		/// <param name="node">The node to select</param>
		/// <returns>TreeNode</returns>
		public virtual void select(TreeNode node) { _(node); }

		/// <summary>Deselect a node.</summary>
		/// <returns></returns>
		public virtual void unselect() { _(); }

		/// <summary>Deselect a node.</summary>
		/// <param name="node">The node to unselect</param>
		/// <returns></returns>
		public virtual void unselect(TreeNode node) { _(node); }

		/// <summary>Clear all selections</summary>
		/// <returns></returns>
		public virtual void clearSelections() { _(); }

		/// <summary>Get the selected node</summary>
		/// <returns>TreeNode</returns>
		public virtual void getSelectedNode() { _(); }

		/// <summary>Returns true if the node is selected</summary>
		/// <returns>Boolean</returns>
		public virtual void isSelected() { _(); }

		/// <summary>Returns true if the node is selected</summary>
		/// <param name="node">The node to check</param>
		/// <returns>Boolean</returns>
		public virtual void isSelected(TreeNode node) { _(node); }

		/// <summary>Selects the node above the selected node in the tree, intelligently walking the nodes</summary>
		/// <returns>TreeNode</returns>
		public virtual void selectPrevious() { _(); }

		/// <summary>Selects the node above the selected node in the tree, intelligently walking the nodes</summary>
		/// <returns>TreeNode</returns>
		public virtual void selectNext() { _(); }



	}

	[JsAnonymous]
	public class DefaultSelectionModelConfig : DotWeb.Client.JsDynamicBase {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return _<object>(); } set { _(value); } }

	}

    public class DefaultSelectionModelEvents {
        /// <summary>Fires when the selected node changes
        /// <pre><code>
        /// USAGE: ({DefaultSelectionModel} objthis, {TreeNode} node)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>node</b></term><description>the new selection</description></item>
        /// </list>
        /// </summary>
        public static string selectionchange { get { return "selectionchange"; } }
        /// <summary>Fires before the selected node changes, return false to cancel the change
        /// <pre><code>
        /// USAGE: ({DefaultSelectionModel} objthis, {TreeNode} node, {TreeNode} node2)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>node</b></term><description>the new selection</description></item>
        /// <item><term><b>node2</b></term><description>the old selection</description></item>
        /// </list>
        /// </summary>
        public static string beforeselect { get { return "beforeselect"; } }
    }

    public delegate void DefaultSelectionModelSelectionchangeDelegate(DefaultSelectionModel objthis, TreeNode node);
    public delegate void DefaultSelectionModelBeforeselectDelegate(DefaultSelectionModel objthis, TreeNode node, TreeNode node2);
}
