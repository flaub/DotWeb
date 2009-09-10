using System;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeDragZone.js</jssource>
	public class TreeDragZone : Ext.dd.DragZone {

		/// <summary></summary>
		/// <returns></returns>
		public TreeDragZone() { C_(); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <returns></returns>
		public TreeDragZone(string tree) { C_(tree); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDragZone(string tree, object config) { C_(tree, config); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <returns></returns>
		public TreeDragZone(DOMElement tree) { C_(tree); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDragZone(DOMElement tree, object config) { C_(tree, config); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <returns></returns>
		public TreeDragZone(Element tree) { C_(tree); }
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDragZone(Element tree, object config) { C_(tree, config); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public TreeDragZone(object el) { C_(el); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public TreeDragZone(object el, object config) { C_(el, config); }
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public TreeDragZone(string id, string sGroup) { C_(id, sGroup); }
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public TreeDragZone(string id, string sGroup, object config) { C_(id, sGroup, config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static TreeDragZone prototype { get { return S_<TreeDragZone>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.dd.DragZone superclass { get { return S_<Ext.dd.DragZone>(); } set { S_(value); } }

		/// <summary>The TreePanel for this drag zone</summary>
		public Ext.tree.TreePanel tree { get { return _<Ext.tree.TreePanel>(); } set { _(value); } }

		/// <summary>
		///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
		///     interact with other drag drop objects in the same group (defaults to 'TreeDD').
		/// </summary>
		public string ddGroup { get { return _<string>(); } set { _(value); } }




	}

	[JsAnonymous]
	public class TreeDragZoneConfig : DotWeb.Client.JsDynamicBase {
		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to 'TreeDD').</summary>
		public string ddGroup { get { return _<string>(); } set { _(value); } }

		/// <summary> True to register this container with the Scrollmanager for auto scrolling during drag operations.</summary>
		public bool containerScroll { get { return _<bool>(); } set { _(value); } }

		/// <summary> The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to "c3daf9" - light blue)</summary>
		public string hlColor { get { return _<string>(); } set { _(value); } }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return _<string>(); } set { _(value); } }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return _<string>(); } set { _(value); } }

	}
}
