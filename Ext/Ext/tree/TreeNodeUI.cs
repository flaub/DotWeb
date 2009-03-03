using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	///     This class provides the default UI implementation for Ext TreeNodes.
	///     The TreeNode UI implementation is separate from the
	///     tree implementation, and allows customizing of the appearance of
	///     tree nodes.<br>
	///     <p>
	///     If you are customizing the Tree's user interface, you
	///     may need to extend this class, but you should never need to instantiate this class.<br>
	///     <p>
	///     This class provides access to the user interface components of an Ext TreeNode, through
	///     {@link Ext.tree.TreeNode#getUI}
	///     */
	///     Ext.tree.TreeNodeUI = function(node){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\tree\TreeNodeUI.js</jssource>
	public class TreeNodeUI : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public TreeNodeUI() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TreeNodeUI prototype { get { return S_<TreeNodeUI>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>
		///     Adds one or more CSS classes to the node's UI element.
		///     Duplicate classes are automatically filtered out.
		/// </summary>
		/// <returns></returns>
		public virtual void addClass() { _(); }

		/// <summary>
		///     Adds one or more CSS classes to the node's UI element.
		///     Duplicate classes are automatically filtered out.
		/// </summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns></returns>
		public virtual void addClass(System.String className) { _(className); }

		/// <summary>
		///     Adds one or more CSS classes to the node's UI element.
		///     Duplicate classes are automatically filtered out.
		/// </summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns></returns>
		public virtual void addClass(System.Array className) { _(className); }

		/// <summary>Removes one or more CSS classes from the node's UI element.</summary>
		/// <returns></returns>
		public virtual void removeClass() { _(); }

		/// <summary>Removes one or more CSS classes from the node's UI element.</summary>
		/// <param name="className">The CSS class to remove, or an array of classes</param>
		/// <returns></returns>
		public virtual void removeClass(System.String className) { _(className); }

		/// <summary>Removes one or more CSS classes from the node's UI element.</summary>
		/// <param name="className">The CSS class to remove, or an array of classes</param>
		/// <returns></returns>
		public virtual void removeClass(System.Array className) { _(className); }

		/// <summary>Hides this node.</summary>
		/// <returns></returns>
		public virtual void hide() { _(); }

		/// <summary>Shows this node.</summary>
		/// <returns></returns>
		public virtual void show() { _(); }

		/// <summary>
		///     Sets the checked status of the tree node to the passed value, or, if no value was passed,
		///     toggles the checked status. If the node was rendered with no checkbox, this has no effect.
		/// </summary>
		/// <returns></returns>
		public virtual void toggleCheck() { _(); }

		/// <summary>
		///     Sets the checked status of the tree node to the passed value, or, if no value was passed,
		///     toggles the checked status. If the node was rendered with no checkbox, this has no effect.
		/// </summary>
		/// <param name="value">The new checked status.</param>
		/// <returns></returns>
		public virtual void toggleCheck(bool value) { _(value); }

		/// <summary>Returns the &lt;a> element that provides focus for the node's UI.</summary>
		/// <returns>HtmlElement</returns>
		public virtual void getAnchor() { _(); }

		/// <summary>Returns the text node.</summary>
		/// <returns>HtmlNode</returns>
		public virtual void getTextEl() { _(); }

		/// <summary>Returns the icon &lt;img> element.</summary>
		/// <returns>HtmlElement</returns>
		public virtual void getIconEl() { _(); }

		/// <summary>
		///     Returns the checked status of the node. If the node was rendered with no
		///     checkbox, it returns false.
		/// </summary>
		/// <returns>Boolean</returns>
		public virtual void isChecked() { _(); }



	}
}
