using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.tree {
	/// <summary>
	///     /**
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\tree\TreeDragZone.js</jssource>
	public class TreeDragZone : Ext.dd.DragZone {

		/// <summary></summary>
		/// <returns></returns>
		public extern TreeDragZone();
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <returns></returns>
		public extern TreeDragZone(string tree);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDragZone(string tree, object config);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <returns></returns>
		public extern TreeDragZone(DOMElement tree);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDragZone(DOMElement tree, object config);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <returns></returns>
		public extern TreeDragZone(Element tree);
		/// <summary></summary>
		/// <param name="tree">The {@link Ext.tree.TreePanel} for which to enable dragging</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDragZone(Element tree, object config);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public extern TreeDragZone(object el);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern TreeDragZone(object el, object config);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public extern TreeDragZone(string id, string sGroup);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public extern TreeDragZone(string id, string sGroup, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static TreeDragZone prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.dd.DragZone superclass { get; set; }

		/// <summary>The TreePanel for this drag zone</summary>
		public extern Ext.tree.TreePanel tree { get; set; }

		/// <summary>
		///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
		///     interact with other drag drop objects in the same group (defaults to 'TreeDD').
		/// </summary>
		public extern string ddGroup { get; set; }




	}

	[JsAnonymous]
	public class TreeDragZoneConfig : System.DotWeb.JsDynamic {
		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to 'TreeDD').</summary>
		public string ddGroup { get { return (string)this["ddGroup"]; } set { this["ddGroup"] = value; } }

		/// <summary> True to register this container with the Scrollmanager for auto scrolling during drag operations.</summary>
		public bool containerScroll { get { return (bool)this["containerScroll"]; } set { this["containerScroll"] = value; } }

		/// <summary> The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to "c3daf9" - light blue)</summary>
		public string hlColor { get { return (string)this["hlColor"]; } set { this["hlColor"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return (string)this["dropAllowed"]; } set { this["dropAllowed"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return (string)this["dropNotAllowed"]; } set { this["dropNotAllowed"] = value; } }

	}
}
