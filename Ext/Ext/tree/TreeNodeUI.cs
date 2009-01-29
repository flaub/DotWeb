using System;
using DotWeb.Core;

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
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\tree\TreeNodeUI.js</jssource>
    [Native]
    public class TreeNodeUI  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public TreeNodeUI() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TreeNodeUI prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>
        ///     Adds one or more CSS classes to the node's UI element.
        ///     Duplicate classes are automatically filtered out.
        /// </summary>
        /// <returns></returns>
        public virtual void addClass() { return ; }

        /// <summary>
        ///     Adds one or more CSS classes to the node's UI element.
        ///     Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        /// <returns></returns>
        public virtual void addClass(System.String className) { return ; }

        /// <summary>
        ///     Adds one or more CSS classes to the node's UI element.
        ///     Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="className">The CSS class to add, or an array of classes</param>
        /// <returns></returns>
        public virtual void addClass(System.Array className) { return ; }

        /// <summary>Removes one or more CSS classes from the node's UI element.</summary>
        /// <returns></returns>
        public virtual void removeClass() { return ; }

        /// <summary>Removes one or more CSS classes from the node's UI element.</summary>
        /// <param name="className">The CSS class to remove, or an array of classes</param>
        /// <returns></returns>
        public virtual void removeClass(System.String className) { return ; }

        /// <summary>Removes one or more CSS classes from the node's UI element.</summary>
        /// <param name="className">The CSS class to remove, or an array of classes</param>
        /// <returns></returns>
        public virtual void removeClass(System.Array className) { return ; }

        /// <summary>Hides this node.</summary>
        /// <returns></returns>
        public virtual void hide() { return ; }

        /// <summary>Shows this node.</summary>
        /// <returns></returns>
        public virtual void show() { return ; }

        /// <summary>
        ///     Sets the checked status of the tree node to the passed value, or, if no value was passed,
        ///     toggles the checked status. If the node was rendered with no checkbox, this has no effect.
        /// </summary>
        /// <returns></returns>
        public virtual void toggleCheck() { return ; }

        /// <summary>
        ///     Sets the checked status of the tree node to the passed value, or, if no value was passed,
        ///     toggles the checked status. If the node was rendered with no checkbox, this has no effect.
        /// </summary>
        /// <param name="value">The new checked status.</param>
        /// <returns></returns>
        public virtual void toggleCheck(bool value) { return ; }

        /// <summary>Returns the &lt;a> element that provides focus for the node's UI.</summary>
        /// <returns>HtmlElement</returns>
        public virtual DOMElement getAnchor() { return null; }

        /// <summary>Returns the text node.</summary>
        /// <returns>HtmlNode</returns>
        public virtual DOMElement getTextEl() { return null; }

        /// <summary>Returns the icon &lt;img> element.</summary>
        /// <returns>HtmlElement</returns>
        public virtual DOMElement getIconEl() { return null; }

        /// <summary>
        ///     Returns the checked status of the node. If the node was rendered with no
        ///     checkbox, it returns false.
        /// </summary>
        /// <returns>Boolean</returns>
        public virtual bool isChecked() { return false; }



    }
    [Anonymous]
    public class TreeNodeUIConfig {

    }


}
