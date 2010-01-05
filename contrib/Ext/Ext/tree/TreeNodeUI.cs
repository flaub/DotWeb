using System;
using System.DotWeb;
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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeNodeUI.js</jssource>
	public class TreeNodeUI : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern TreeNodeUI();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TreeNodeUI prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }


		/// <summary>
		///     Adds one or more CSS classes to the node's UI element.
		///     Duplicate classes are automatically filtered out.
		/// </summary>
		/// <returns></returns>
		public extern virtual void addClass();

		/// <summary>
		///     Adds one or more CSS classes to the node's UI element.
		///     Duplicate classes are automatically filtered out.
		/// </summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns></returns>
		public extern virtual void addClass(string className);

		/// <summary>
		///     Adds one or more CSS classes to the node's UI element.
		///     Duplicate classes are automatically filtered out.
		/// </summary>
		/// <param name="className">The CSS class to add, or an array of classes</param>
		/// <returns></returns>
		public extern virtual void addClass(System.Array className);

		/// <summary>Removes one or more CSS classes from the node's UI element.</summary>
		/// <returns></returns>
		public extern virtual void removeClass();

		/// <summary>Removes one or more CSS classes from the node's UI element.</summary>
		/// <param name="className">The CSS class to remove, or an array of classes</param>
		/// <returns></returns>
		public extern virtual void removeClass(string className);

		/// <summary>Removes one or more CSS classes from the node's UI element.</summary>
		/// <param name="className">The CSS class to remove, or an array of classes</param>
		/// <returns></returns>
		public extern virtual void removeClass(System.Array className);

		/// <summary>Hides this node.</summary>
		/// <returns></returns>
		public extern virtual void hide();

		/// <summary>Shows this node.</summary>
		/// <returns></returns>
		public extern virtual void show();

		/// <summary>
		///     Sets the checked status of the tree node to the passed value, or, if no value was passed,
		///     toggles the checked status. If the node was rendered with no checkbox, this has no effect.
		/// </summary>
		/// <returns></returns>
		public extern virtual void toggleCheck();

		/// <summary>
		///     Sets the checked status of the tree node to the passed value, or, if no value was passed,
		///     toggles the checked status. If the node was rendered with no checkbox, this has no effect.
		/// </summary>
		/// <param name="value">The new checked status.</param>
		/// <returns></returns>
		public extern virtual void toggleCheck(bool value);

		/// <summary>Returns the &lt;a> element that provides focus for the node's UI.</summary>
		/// <returns>HtmlElement</returns>
		public extern virtual void getAnchor();

		/// <summary>Returns the text node.</summary>
		/// <returns>HtmlNode</returns>
		public extern virtual void getTextEl();

		/// <summary>Returns the icon &lt;img> element.</summary>
		/// <returns>HtmlElement</returns>
		public extern virtual void getIconEl();

		/// <summary>
		///     Returns the checked status of the node. If the node was rendered with no
		///     checkbox, it returns false.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void isChecked();



	}
}
