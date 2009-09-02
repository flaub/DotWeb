using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\tree\TreeDropZone.js</jssource>
	public class TreeDropZone : Ext.dd.DropZone {

		/// <summary></summary>
		/// <returns></returns>
		public TreeDropZone() { C_(); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <returns></returns>
		public TreeDropZone(System.String tree) { C_(tree); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDropZone(System.String tree, object config) { C_(tree, config); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <returns></returns>
		public TreeDropZone(DOMElement tree) { C_(tree); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDropZone(DOMElement tree, object config) { C_(tree, config); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <returns></returns>
		public TreeDropZone(Element tree) { C_(tree); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dropping</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDropZone(Element tree, object config) { C_(tree, config); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public TreeDropZone(object el) { C_(el); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDropZone(object el, object config) { C_(el, config); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public TreeDropZone(System.String id, System.String sGroup) { C_(id, sGroup); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public TreeDropZone(System.String id, System.String sGroup, object config) { C_(id, sGroup, config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TreeDropZone prototype { get { return S_<TreeDropZone>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.dd.DropZone superclass { get { return S_<Ext.dd.DropZone>(); } set { S_(value); } }

		/// <summary>
		///     Allow inserting a dragged node between an expanded parent node and its first child that will become a
		///     sibling of the parent when dropped (defaults to false)
		/// </summary>
		public bool allowParentInsert { get { return _<bool>(); } set { _(value); } }

		/// <summary>True if drops on the tree container (outside of a specific tree node) are allowed (defaults to false)</summary>
		public System.String allowContainerDrop { get { return _<System.String>(); } set { _(value); } }

		/// <summary>True if the tree should only allow append drops (use for trees which are sorted, defaults to false)</summary>
		public System.String appendOnly { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The TreePanel for this drop zone</summary>
		public Ext.tree.TreePanel tree { get { return _<Ext.tree.TreePanel>(); } set { _(value); } }

		/// <summary>
		///     Arbitrary data that can be associated with this tree and will be included in the event object that gets
		///     passed to any nodedragover event handler (defaults to {})
		/// </summary>
		public Ext.tree.TreePanel dragOverData { get { return _<Ext.tree.TreePanel>(); } set { _(value); } }

		/// <summary>
		///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
		///     interact with other drag drop objects in the same group (defaults to 'TreeDD').
		/// </summary>
		public System.String ddGroup { get { return _<System.String>(); } set { _(value); } }

		/// <summary>
		///     The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node
		///     over the target (defaults to 1000)
		/// </summary>
		public System.String expandDelay { get { return _<System.String>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class TreeDropZoneConfig : DotWeb.Client.JsAccessible {
		/// <summary>  Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped (defaults to false)</summary>
		public bool allowParentInsert { get; set; }

		/// <summary>  True if drops on the tree container (outside of a specific tree node) are allowed (defaults to false)</summary>
		public System.String allowContainerDrop { get; set; }

		/// <summary>  True if the tree should only allow append drops (use for trees which are sorted, defaults to false)</summary>
		public System.String appendOnly { get; set; }

		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to 'TreeDD').</summary>
		public System.String ddGroup { get; set; }

		/// <summary>  The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target (defaults to 1000)</summary>
		public System.String expandDelay { get; set; }

		/// <summary>  The CSS class applied to the drop target element while the drag source is over it (defaults to "").</summary>
		public System.String overClass { get; set; }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public System.String dropAllowed { get; set; }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public System.String dropNotAllowed { get; set; }

	}
}
