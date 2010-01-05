using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeDropZone.js</jssource>
	public class TreeDropZone : Ext.dd.DropZone {

		/// <summary></summary>
		/// <returns></returns>
		public extern TreeDropZone();
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <returns></returns>
		public extern TreeDropZone(string tree);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDropZone(string tree, object config);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <returns></returns>
		public extern TreeDropZone(DOMElement tree);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDropZone(DOMElement tree, object config);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <returns></returns>
		public extern TreeDropZone(Element tree);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDropZone(Element tree, object config);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public extern TreeDropZone(object el);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDropZone(object el, object config);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public extern TreeDropZone(string id, string sGroup);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public extern TreeDropZone(string id, string sGroup, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TreeDropZone prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.dd.DropZone superclass { get; set; }

		/// <summary>
		///     Allow inserting a dragged node between an expanded parent node and its first child that will become a
		///     sibling of the parent when dropped (defaults to false)
		/// </summary>
		public extern bool allowParentInsert { get; set; }

		/// <summary>True if drops on the tree container (outside of a specific tree node) are allowed (defaults to false)</summary>
		public extern string allowContainerDrop { get; set; }

		/// <summary>True if the tree should only allow append drops (use for trees which are sorted, defaults to false)</summary>
		public extern string appendOnly { get; set; }

		/// <summary>The TreePanel for this drop zone</summary>
		public extern Ext.tree.TreePanel tree { get; set; }

		/// <summary>
		///     Arbitrary data that can be associated with this tree and will be included in the event object that gets
		///     passed to any nodedragover event handler (defaults to {})
		/// </summary>
		public extern Ext.tree.TreePanel dragOverData { get; set; }

		/// <summary>
		///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
		///     interact with other drag drop objects in the same group (defaults to 'TreeDD').
		/// </summary>
		public extern string ddGroup { get; set; }

		/// <summary>
		///     The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node
		///     over the target (defaults to 1000)
		/// </summary>
		public extern string expandDelay { get; set; }




	}

	[JsAnonymous]
	public class TreeDropZoneConfig : System.DotWeb.JsDynamic {
		/// <summary>  Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped (defaults to false)</summary>
		public bool allowParentInsert { get { return (bool)this["allowParentInsert"]; } set { this["allowParentInsert"] = value; } }

		/// <summary>  True if drops on the tree container (outside of a specific tree node) are allowed (defaults to false)</summary>
		public string allowContainerDrop { get { return (string)this["allowContainerDrop"]; } set { this["allowContainerDrop"] = value; } }

		/// <summary>  True if the tree should only allow append drops (use for trees which are sorted, defaults to false)</summary>
		public string appendOnly { get { return (string)this["appendOnly"]; } set { this["appendOnly"] = value; } }

		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to 'TreeDD').</summary>
		public string ddGroup { get { return (string)this["ddGroup"]; } set { this["ddGroup"] = value; } }

		/// <summary>  The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target (defaults to 1000)</summary>
		public string expandDelay { get { return (string)this["expandDelay"]; } set { this["expandDelay"] = value; } }

		/// <summary>  The CSS class applied to the drop target element while the drag source is over it (defaults to "").</summary>
		public string overClass { get { return (string)this["overClass"]; } set { this["overClass"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return (string)this["dropAllowed"]; } set { this["dropAllowed"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return (string)this["dropNotAllowed"]; } set { this["dropNotAllowed"] = value; } }

	}
}
