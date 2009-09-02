using System;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     <p>A customized implementation of a {@link Ext.dd.DragZone DragZone} which provides default implementations of two of the
	///     template methods of DragZone to enable dragging of the selected rows of a GridPanel.</p>
	///     <p>A cooperating {@link Ext.dd.DropZone DropZone} must be created who's template method implementations of
	///     {@link Ext.dd.DropZone#onNodeEnter onNodeEnter}, {@link Ext.dd.DropZone#onNodeOver onNodeOver},
	///     {@link Ext.dd.DropZone#onNodeOut onNodeOut} and {@link Ext.dd.DropZone#onNodeDrop onNodeDrop}</p> are able
	///     to process the {@link #getDragData data} which is provided.
	///     */
	///     Ext.grid.GridDragZone = function(grid, config){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\grid\GridDD.js</jssource>
	public class GridDragZone : Ext.dd.DragZone {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public GridDragZone() { C_(); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public GridDragZone(object el) { C_(el); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public GridDragZone(object el, object config) { C_(el, config); }
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <returns></returns>
		public GridDragZone(System.String id) { C_(id); }
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public GridDragZone(System.String id, System.String sGroup) { C_(id, sGroup); }
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public GridDragZone(System.String id, System.String sGroup, object config) { C_(id, sGroup, config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static GridDragZone prototype { get { return S_<GridDragZone>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.dd.DragZone superclass { get { return S_<Ext.dd.DragZone>(); } set { S_(value); } }


		/// <summary>
		///     <p>The provided implementation of the getDragData method which collects the data to be dragged from the GridPanel on mousedown.</p>
		///     <p>This data is available for processing in the {@link Ext.dd.DropZone#onNodeEnter onNodeEnter}, {@link Ext.dd.DropZone#onNodeOver onNodeOver},
		///     {@link Ext.dd.DropZone#onNodeOut onNodeOut} and {@link Ext.dd.DropZone#onNodeDrop onNodeDrop} methods of a cooperating {@link Ext.dd.DropZone DropZone}.</p>
		///     <p>The data object contains the following properties:<ul>
		///     <li><b>grid</b> : Ext.Grid.GridPanel<div class="sub-desc">The GridPanel from which the data is being dragged.</div></li>
		///     <li><b>ddel</b> : htmlElement<div class="sub-desc">An htmlElement which provides the "picture" of the data being dragged.</div></li>
		///     <li><b>rowIndex</b> : Number<div class="sub-desc">The index of the row which receieved the mousedown gesture which triggered the drag.</div></li>
		///     <li><b>selections</b> : Array<div class="sub-desc">An Array of the selected Records which are being dragged from the GridPanel.</div></li>
		///     </ul></p>
		/// </summary>
		/// <returns></returns>
		public virtual void getDragData() { _(); }

		/// <summary>
		///     <p>The provided implementation of the onInitDrag method. Sets the <tt>innerHTML</tt> of the drag proxy which provides the "picture"
		///     of the data being dragged.</p>
		///     <p>The <tt>innerHTML</tt> data is found by calling the owning GridPanel's {@link Ext.grid.GridPanel#getDragDropText getDragDropText}.</p>
		/// </summary>
		/// <returns></returns>
		public virtual void onInitDrag() { _(); }

		/// <summary>
		///     An empty immplementation. Implement this to provide behaviour after a repair of an invalid drop. An implementation might highlight
		///     the selected rows to show that they have not been dragged.
		/// </summary>
		/// <returns></returns>
		public virtual void afterRepair() { _(); }

		/// <summary>
		///     <p>An empty implementation. Implement this to provide coordinates for the drag proxy to slide back to after an invalid drop.</p>
		///     <p>Called before a repair of an invalid drop to get the XY to animate to.</p>
		/// </summary>
		/// <returns>Array</returns>
		public virtual void getRepairXY() { _(); }

		/// <summary>
		///     <p>An empty implementation. Implement this to provide coordinates for the drag proxy to slide back to after an invalid drop.</p>
		///     <p>Called before a repair of an invalid drop to get the XY to animate to.</p>
		/// </summary>
		/// <param name="e">The mouse up event</param>
		/// <returns>Array</returns>
		public virtual void getRepairXY(EventObject e) { _(e); }



	}

	[JsAnonymous]
	public class GridDragZoneConfig : DotWeb.Client.JsAccessible {
		/// <summary> True to register this container with the Scrollmanager for auto scrolling during drag operations.</summary>
		public bool containerScroll { get; set; }

		/// <summary> The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to "c3daf9" - light blue)</summary>
		public System.String hlColor { get; set; }

		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
		public System.String ddGroup { get; set; }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public System.String dropAllowed { get; set; }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public System.String dropNotAllowed { get; set; }

	}
}
