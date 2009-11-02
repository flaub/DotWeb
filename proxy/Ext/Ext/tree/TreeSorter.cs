using System;
using System.DotWeb;
using DotWeb.Client;

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
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeSorter.js</jssource>
	public class TreeSorter : System.DotWeb.JsObject {

		/// <summary></summary>
		/// <returns></returns>
		public extern TreeSorter();
		/// <summary></summary>
		/// <param name="tree"></param>
		/// <returns></returns>
		public extern TreeSorter(TreePanel tree);
		/// <summary></summary>
		/// <param name="tree"></param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeSorter(TreePanel tree, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TreeSorter prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>True to sort leaf nodes under non-leaf nodes (defaults to false)</summary>
		public extern bool folderSort { get; set; }

		/// <summary>The named attribute on the node to sort by (defaults to "text").  Note that thisproperty is only used if no {@link #sortType} function is specified, otherwise it is ignored.</summary>
		public extern string property { get; set; }

		/// <summary>The direction to sort ("asc" or "desc," case-insensitive, defaults to "asc")</summary>
		public extern string dir { get; set; }

		/// <summary>The attribute used to determine leaf nodes when {@link #folderSort} = true (defaults to "leaf")</summary>
		public extern string leafAttr { get; set; }

		/// <summary>true for case-sensitive sort (defaults to false)</summary>
		public extern bool caseSensitive { get; set; }

		/// <summary>
		///     A custom "casting" function used to convert node values before sorting.  The functionwill be called with a single parameter (the {@link Ext.tree.TreeNode} being evaluated) and is expected to return
		///     the node's sort value cast to the specific data type required for sorting.  This could be used, for example, when
		///     a node's text (or other attribute) should be sorted as a date or numeric value.  See the class description for
		///     example usage.  Note that if a sortType is specified, any {@link #property} config will be ignored.
		/// </summary>
		public extern Delegate sortType { get; set; }




	}

	[JsAnonymous]
	public class TreeSorterConfig : System.DotWeb.JsDynamic {
		/// <summary> True to sort leaf nodes under non-leaf nodes (defaults to false)</summary>
		public bool folderSort { get { return (bool)this["folderSort"]; } set { this["folderSort"] = value; } }

		/// <summary> The named attribute on the node to sort by (defaults to "text").  Note that this property is only used if no {@link #sortType} function is specified, otherwise it is ignored.</summary>
		public string property { get { return (string)this["property"]; } set { this["property"] = value; } }

		/// <summary> The direction to sort ("asc" or "desc," case-insensitive, defaults to "asc")</summary>
		public string dir { get { return (string)this["dir"]; } set { this["dir"] = value; } }

		/// <summary> The attribute used to determine leaf nodes when {@link #folderSort} = true (defaults to "leaf")</summary>
		public string leafAttr { get { return (string)this["leafAttr"]; } set { this["leafAttr"] = value; } }

		/// <summary> true for case-sensitive sort (defaults to false)</summary>
		public bool caseSensitive { get { return (bool)this["caseSensitive"]; } set { this["caseSensitive"] = value; } }

		/// <summary> A custom "casting" function used to convert node values before sorting.  The function will be called with a single parameter (the {@link Ext.tree.TreeNode} being evaluated) and is expected to return the node's sort value cast to the specific data type required for sorting.  This could be used, for example, when a node's text (or other attribute) should be sorted as a date or numeric value.  See the class description for example usage.  Note that if a sortType is specified, any {@link #property} config will be ignored.</summary>
		public Delegate sortType { get { return (Delegate)this["sortType"]; } set { this["sortType"] = value; } }

	}
}
