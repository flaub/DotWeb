using System;
using DotWeb.Core;

namespace Ext.tree {
    /// <summary>
    ///     /**
    ///     Provides sorting of nodes in a {@link Ext.tree.TreePanel}.  The TreeSorter automatically monitors events on the
    ///     associated TreePanel that might affect the tree's sort order (beforechildrenrendered, append, insert and textchange).
    ///     Example usage:<br />
    ///     <pre><code>
    ///     new Ext.tree.TreeSorter(myTree, {
    ///     folderSort: true,
    ///     dir: "desc",
    ///     sortType: function(node) {
    ///     // sort by a custom, typed attribute:
    ///     return parseInt(node.id, 10);
    ///     }
    ///     });
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\tree\TreeSorter.js</jssource>
    [Native]
    public class TreeSorter  {

        /// <summary></summary>
        /// <returns></returns>
        public TreeSorter() {}
        /// <summary></summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public TreeSorter(TreePanel tree) {}
        /// <summary></summary>
        /// <param name="tree"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public TreeSorter(TreePanel tree, object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TreeSorter prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>True to sort leaf nodes under non-leaf nodes (defaults to false)</summary>
        public bool folderSort { get { return false; } set { } }

        /// <summary>The named attribute on the node to sort by (defaults to "text").  Note that thisproperty is only used if no {@link #sortType} function is specified, otherwise it is ignored.</summary>
        public System.String property { get { return null; } set { } }

        /// <summary>The direction to sort ("asc" or "desc," case-insensitive, defaults to "asc")</summary>
        public System.String dir { get { return null; } set { } }

        /// <summary>The attribute used to determine leaf nodes when {@link #folderSort} = true (defaults to "leaf")</summary>
        public System.String leafAttr { get { return null; } set { } }

        /// <summary>true for case-sensitive sort (defaults to false)</summary>
        public bool caseSensitive { get { return false; } set { } }

        /// <summary>
        ///     A custom "casting" function used to convert node values before sorting.  The functionwill be called with a single parameter (the {@link Ext.tree.TreeNode} being evaluated) and is expected to return
        ///     the node's sort value cast to the specific data type required for sorting.  This could be used, for example, when
        ///     a node's text (or other attribute) should be sorted as a date or numeric value.  See the class description for
        ///     example usage.  Note that if a sortType is specified, any {@link #property} config will be ignored.
        /// </summary>
        public Delegate sortType { get { return null; } set { } }




    }
    [Anonymous]
    public class TreeSorterConfig {

        /// <summary> True to sort leaf nodes under non-leaf nodes (defaults to false)</summary>
        public bool folderSort { get { return false; } set { } }

        /// <summary> The named attribute on the node to sort by (defaults to "text").  Note that this property is only used if no {@link #sortType} function is specified, otherwise it is ignored.</summary>
        public System.String property { get { return null; } set { } }

        /// <summary> The direction to sort ("asc" or "desc," case-insensitive, defaults to "asc")</summary>
        public System.String dir { get { return null; } set { } }

        /// <summary> The attribute used to determine leaf nodes when {@link #folderSort} = true (defaults to "leaf")</summary>
        public System.String leafAttr { get { return null; } set { } }

        /// <summary> true for case-sensitive sort (defaults to false)</summary>
        public bool caseSensitive { get { return false; } set { } }

        /// <summary> A custom "casting" function used to convert node values before sorting.  The function will be called with a single parameter (the {@link Ext.tree.TreeNode} being evaluated) and is expected to return the node's sort value cast to the specific data type required for sorting.  This could be used, for example, when a node's text (or other attribute) should be sorted as a date or numeric value.  See the class description for example usage.  Note that if a sortType is specified, any {@link #property} config will be ignored.</summary>
        public Delegate sortType { get { return null; } set { } }

    }


}
