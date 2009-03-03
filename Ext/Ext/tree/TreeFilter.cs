using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     Note this class is experimental and doesn't update the indent (lines) or expand collapse icons of the nodes
	///     @param {TreePanel} tree
	///     @param {Object} config (optional)
	///     */
	///     Ext.tree.TreeFilter = function(tree, config){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\tree\TreeFilter.js</jssource>
	public class TreeFilter : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public TreeFilter() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TreeFilter prototype { get { return S_<TreeFilter>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <returns></returns>
		public virtual void filter() { _(); }

		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <param name="value">Either string that the attribute value</param>
		/// <returns></returns>
		public virtual void filter(System.String value) { _(value); }

		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <param name="value">Either string that the attribute value</param>
		/// <param name="attr">(optional) The attribute passed in your node's attributes collection. Defaults to "text".</param>
		/// <returns></returns>
		public virtual void filter(System.String value, System.String attr) { _(value, attr); }

		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <param name="value">Either string that the attribute value</param>
		/// <param name="attr">(optional) The attribute passed in your node's attributes collection. Defaults to "text".</param>
		/// <param name="startNode">(optional) The node to start the filter at.</param>
		/// <returns></returns>
		public virtual void filter(System.String value, System.String attr, TreeNode startNode) { _(value, attr, startNode); }

		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <param name="value">Either string that the attribute value</param>
		/// <returns></returns>
		public virtual void filter(object value) { _(value); }

		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <param name="value">Either string that the attribute value</param>
		/// <param name="attr">(optional) The attribute passed in your node's attributes collection. Defaults to "text".</param>
		/// <returns></returns>
		public virtual void filter(object value, System.String attr) { _(value, attr); }

		/// <summary>
		///     Filter the data by a specific attribute.
		///     should start with or a RegExp to test against the attribute
		/// </summary>
		/// <param name="value">Either string that the attribute value</param>
		/// <param name="attr">(optional) The attribute passed in your node's attributes collection. Defaults to "text".</param>
		/// <param name="startNode">(optional) The node to start the filter at.</param>
		/// <returns></returns>
		public virtual void filter(object value, System.String attr, TreeNode startNode) { _(value, attr, startNode); }

		/// <summary>
		///     Filter by a function. The passed function will be called with each
		///     node in the tree (or from the startNode). If the function returns true, the node is kept
		///     otherwise it is filtered. If a node is filtered, its children are also filtered.
		/// </summary>
		/// <returns></returns>
		public virtual void filterBy() { _(); }

		/// <summary>
		///     Filter by a function. The passed function will be called with each
		///     node in the tree (or from the startNode). If the function returns true, the node is kept
		///     otherwise it is filtered. If a node is filtered, its children are also filtered.
		/// </summary>
		/// <param name="fn">The filter function</param>
		/// <returns></returns>
		public virtual void filterBy(Delegate fn) { _(fn); }

		/// <summary>
		///     Filter by a function. The passed function will be called with each
		///     node in the tree (or from the startNode). If the function returns true, the node is kept
		///     otherwise it is filtered. If a node is filtered, its children are also filtered.
		/// </summary>
		/// <param name="fn">The filter function</param>
		/// <param name="scope">(optional) The scope of the function (defaults to the current node)</param>
		/// <returns></returns>
		public virtual void filterBy(Delegate fn, object scope) { _(fn, scope); }

		/// <summary>
		///     Clears the current filter. Note: with the "remove" option
		///     set a filter cannot be cleared.
		/// </summary>
		/// <returns></returns>
		public virtual void clear() { _(); }



	}
}
