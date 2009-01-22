using System;
using H8.Support;

namespace Ext.tree {
    /// <summary>
    ///     /**
    ///     The default single selection for a TreePanel.
    ///     */
    ///     Ext.tree.DefaultSelectionModel = function(config){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\tree\TreeSelectionModel.js</jssource>
    [Native]
    public class DefaultSelectionModel : Ext.util.Observable {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public DefaultSelectionModel() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static DefaultSelectionModel prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.util.Observable superclass { get { return null; } set { } }


        /// <summary>Select a node.</summary>
        /// <returns>TreeNode</returns>
        public virtual TreeNode select() { return null; }

        /// <summary>Select a node.</summary>
        /// <param name="node">The node to select</param>
        /// <returns>TreeNode</returns>
        public virtual TreeNode select(TreeNode node) { return null; }

        /// <summary>Deselect a node.</summary>
        /// <returns></returns>
        public virtual void unselect() { return ; }

        /// <summary>Deselect a node.</summary>
        /// <param name="node">The node to unselect</param>
        /// <returns></returns>
        public virtual void unselect(TreeNode node) { return ; }

        /// <summary>Clear all selections</summary>
        /// <returns></returns>
        public virtual void clearSelections() { return ; }

        /// <summary>Get the selected node</summary>
        /// <returns>TreeNode</returns>
        public virtual TreeNode getSelectedNode() { return null; }

        /// <summary>Returns true if the node is selected</summary>
        /// <returns>Boolean</returns>
        public virtual bool isSelected() { return false; }

        /// <summary>Returns true if the node is selected</summary>
        /// <param name="node">The node to check</param>
        /// <returns>Boolean</returns>
        public virtual bool isSelected(TreeNode node) { return false; }

        /// <summary>Selects the node above the selected node in the tree, intelligently walking the nodes</summary>
        /// <returns>TreeNode</returns>
        public virtual TreeNode selectPrevious() { return null; }

        /// <summary>Selects the node above the selected node in the tree, intelligently walking the nodes</summary>
        /// <returns>TreeNode</returns>
        public virtual TreeNode selectNext() { return null; }



    }
    [Anonymous]
    public class DefaultSelectionModelConfig {

        /// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
        public object listeners { get { return null; } set { } }

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
