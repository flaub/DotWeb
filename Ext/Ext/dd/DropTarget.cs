using System;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     A simple class that provides the basic implementation needed to make any element a drop target that can have
	///     draggable items dropped onto it.  The drop has no effect until an implementation of notifyDrop is provided.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\dd\DropTarget.js</jssource>
	public class DropTarget : Ext.dd.DDTarget {

		/// <summary></summary>
		/// <returns></returns>
		public DropTarget() { C_(); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public DropTarget(object el) { C_(el); }
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public DropTarget(object el, object config) { C_(el, config); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <returns></returns>
		public DropTarget(System.String id) { C_(id); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public DropTarget(System.String id, System.String sGroup) { C_(id, sGroup); }
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public DropTarget(System.String id, System.String sGroup, object config) { C_(id, sGroup, config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static DropTarget prototype { get { return S_<DropTarget>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.dd.DDTarget superclass { get { return S_<Ext.dd.DDTarget>(); } set { S_(value); } }

		/// <summary>
		///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
		///     interact with other drag drop objects in the same group (defaults to undefined).
		/// </summary>
		public System.String ddGroup { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The CSS class applied to the drop target element while the drag source is over it (defaults to "").</summary>
		public System.String overClass { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public System.String dropAllowed { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public System.String dropNotAllowed { get { return _<System.String>(); } set { _(value); } }


		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source is now over the
		///     target.  This default implementation adds the CSS class specified by overClass (if any) to the drop element
		///     and returns the dropAllowed config value.  This method should be overridden if drop validation is required.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <returns>String</returns>
		public virtual void notifyEnter() { _(); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source is now over the
		///     target.  This default implementation adds the CSS class specified by overClass (if any) to the drop element
		///     and returns the dropAllowed config value.  This method should be overridden if drop validation is required.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <returns>String</returns>
		public virtual void notifyEnter(Ext.dd.DragSource source) { _(source); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source is now over the
		///     target.  This default implementation adds the CSS class specified by overClass (if any) to the drop element
		///     and returns the dropAllowed config value.  This method should be overridden if drop validation is required.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <returns>String</returns>
		public virtual void notifyEnter(Ext.dd.DragSource source, Event e) { _(source, e); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source is now over the
		///     target.  This default implementation adds the CSS class specified by overClass (if any) to the drop element
		///     and returns the dropAllowed config value.  This method should be overridden if drop validation is required.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>String</returns>
		public virtual void notifyEnter(Ext.dd.DragSource source, Event e, object data) { _(source, e, data); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the target.
		///     This method will be called on every mouse movement while the drag source is over the drop target.
		///     This default implementation simply returns the dropAllowed config value.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <returns>String</returns>
		public virtual void notifyOver() { _(); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the target.
		///     This method will be called on every mouse movement while the drag source is over the drop target.
		///     This default implementation simply returns the dropAllowed config value.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <returns>String</returns>
		public virtual void notifyOver(Ext.dd.DragSource source) { _(source); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the target.
		///     This method will be called on every mouse movement while the drag source is over the drop target.
		///     This default implementation simply returns the dropAllowed config value.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <returns>String</returns>
		public virtual void notifyOver(Ext.dd.DragSource source, Event e) { _(source, e); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the target.
		///     This method will be called on every mouse movement while the drag source is over the drop target.
		///     This default implementation simply returns the dropAllowed config value.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>String</returns>
		public virtual void notifyOver(Ext.dd.DragSource source, Event e, object data) { _(source, e, data); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source has been dragged
		///     out of the target without dropping.  This default implementation simply removes the CSS class specified by
		///     overClass (if any) from the drop element.
		/// </summary>
		/// <returns></returns>
		public virtual void notifyOut() { _(); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source has been dragged
		///     out of the target without dropping.  This default implementation simply removes the CSS class specified by
		///     overClass (if any) from the drop element.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <returns></returns>
		public virtual void notifyOut(Ext.dd.DragSource source) { _(source); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source has been dragged
		///     out of the target without dropping.  This default implementation simply removes the CSS class specified by
		///     overClass (if any) from the drop element.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <returns></returns>
		public virtual void notifyOut(Ext.dd.DragSource source, Event e) { _(source, e); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the source has been dragged
		///     out of the target without dropping.  This default implementation simply removes the CSS class specified by
		///     overClass (if any) from the drop element.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns></returns>
		public virtual void notifyOut(Ext.dd.DragSource source, Event e, object data) { _(source, e, data); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the dragged item has
		///     been dropped on it.  This method has no default implementation and returns false, so you must provide an
		///     implementation that does something to process the drop event and returns true so that the drag source's
		///     repair action does not run.
		/// </summary>
		/// <returns>Boolean</returns>
		public virtual void notifyDrop() { _(); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the dragged item has
		///     been dropped on it.  This method has no default implementation and returns false, so you must provide an
		///     implementation that does something to process the drop event and returns true so that the drag source's
		///     repair action does not run.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <returns>Boolean</returns>
		public virtual void notifyDrop(Ext.dd.DragSource source) { _(source); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the dragged item has
		///     been dropped on it.  This method has no default implementation and returns false, so you must provide an
		///     implementation that does something to process the drop event and returns true so that the drag source's
		///     repair action does not run.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <returns>Boolean</returns>
		public virtual void notifyDrop(Ext.dd.DragSource source, Event e) { _(source, e); }

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop target that the dragged item has
		///     been dropped on it.  This method has no default implementation and returns false, so you must provide an
		///     implementation that does something to process the drop event and returns true so that the drag source's
		///     repair action does not run.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>Boolean</returns>
		public virtual void notifyDrop(Ext.dd.DragSource source, Event e, object data) { _(source, e, data); }



	}

	[JsAnonymous]
	public class DropTargetConfig : DotWeb.Client.JsAccessible {
		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
		public System.String ddGroup { get; set; }

		/// <summary>  The CSS class applied to the drop target element while the drag source is over it (defaults to "").</summary>
		public System.String overClass { get; set; }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public System.String dropAllowed { get; set; }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public System.String dropNotAllowed { get; set; }

	}
}
