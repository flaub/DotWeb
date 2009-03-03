using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     Multi selection for a TreePanel.
	///     */
	///     Ext.tree.MultiSelectionModel = function(config){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\tree\TreeSelectionModel.js</jssource>
	public class MultiSelectionModel : Ext.util.Observable {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public MultiSelectionModel() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static MultiSelectionModel prototype { get { return S_<MultiSelectionModel>(); } set { S_(value); } }

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

		/// <summary>Select a node.</summary>
		/// <param name="node">The node to select</param>
		/// <param name="e">(optional) An event associated with the selection</param>
		/// <returns>TreeNode</returns>
		public virtual void select(TreeNode node, EventObject e) { _(node, e); }

		/// <summary>Select a node.</summary>
		/// <param name="node">The node to select</param>
		/// <param name="e">(optional) An event associated with the selection</param>
		/// <param name="keepExisting">True to retain existing selections</param>
		/// <returns>TreeNode</returns>
		public virtual void select(TreeNode node, EventObject e, bool keepExisting) { _(node, e, keepExisting); }

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

		/// <summary>Returns true if the node is selected</summary>
		/// <returns>Boolean</returns>
		public virtual void isSelected() { _(); }

		/// <summary>Returns true if the node is selected</summary>
		/// <param name="node">The node to check</param>
		/// <returns>Boolean</returns>
		public virtual void isSelected(TreeNode node) { _(node); }

		/// <summary>Returns an array of the selected nodes</summary>
		/// <returns>Array</returns>
		public virtual void getSelectedNodes() { _(); }



	}

	[JsAnonymous]
	public class MultiSelectionModelConfig : DotWeb.Client.JsAccessible {
		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class MultiSelectionModelEvents {
        /// <summary>Fires when the selected nodes change
        /// <pre><code>
        /// USAGE: ({MultiSelectionModel} objthis, {Array} nodes)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>nodes</b></term><description>Array of the selected nodes</description></item>
        /// </list>
        /// </summary>
        public static string selectionchange { get { return "selectionchange"; } }
    }

    public delegate void MultiSelectionModelSelectionchangeDelegate(MultiSelectionModel objthis, System.Array nodes);
}
