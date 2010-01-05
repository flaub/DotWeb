using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     This class provides a container DD instance that proxies for multiple child node targets.<br />
	///     By default, this class requires that child nodes accepting drop are registered with {@link Ext.dd.Registry}.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\dd\DropZone.js</jssource>
	public class DropZone : Ext.dd.DropTarget {

		/// <summary></summary>
		/// <returns></returns>
		public extern DropZone();
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public extern DropZone(object el);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern DropZone(object el, object config);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <returns></returns>
		public extern DropZone(string id);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public extern DropZone(string id, string sGroup);
		/// <summary>
		///     Valid properties for DDTarget in addition to those in
		///     DragDrop:
		///     none
		/// </summary>
		/// <param name="id">the id of the element that is a drop target</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public extern DropZone(string id, string sGroup, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static DropZone prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.dd.DropTarget superclass { get; set; }


		/// <summary>
		///     Returns a custom data object associated with the DOM node that is the target of the event.  By default
		///     this looks up the event target in the {@link Ext.dd.Registry}, although you can override this method to
		///     provide your own custom lookup.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getTargetFromEvent();

		/// <summary>
		///     Returns a custom data object associated with the DOM node that is the target of the event.  By default
		///     this looks up the event target in the {@link Ext.dd.Registry}, although you can override this method to
		///     provide your own custom lookup.
		/// </summary>
		/// <param name="e">The event</param>
		/// <returns>Object</returns>
		public extern virtual void getTargetFromEvent(Event e);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has entered a drop node
		///     that it has registered.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <returns></returns>
		public extern virtual void onNodeEnter();

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has entered a drop node
		///     that it has registered.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <returns></returns>
		public extern virtual void onNodeEnter(object nodeData);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has entered a drop node
		///     that it has registered.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns></returns>
		public extern virtual void onNodeEnter(object nodeData, Ext.dd.DragSource source);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has entered a drop node
		///     that it has registered.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns></returns>
		public extern virtual void onNodeEnter(object nodeData, Ext.dd.DragSource source, Event e);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has entered a drop node
		///     that it has registered.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns></returns>
		public extern virtual void onNodeEnter(object nodeData, Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is over a drop node
		///     that it has registered.  The default implementation returns this.dropNotAllowed, so it should be
		///     overridden to provide the proper feedback.
		///     {@link #getTargetFromEvent} for this node)
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <returns>String</returns>
		public extern virtual void onNodeOver();

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is over a drop node
		///     that it has registered.  The default implementation returns this.dropNotAllowed, so it should be
		///     overridden to provide the proper feedback.
		///     {@link #getTargetFromEvent} for this node)
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <returns>String</returns>
		public extern virtual void onNodeOver(object nodeData);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is over a drop node
		///     that it has registered.  The default implementation returns this.dropNotAllowed, so it should be
		///     overridden to provide the proper feedback.
		///     {@link #getTargetFromEvent} for this node)
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>String</returns>
		public extern virtual void onNodeOver(object nodeData, Ext.dd.DragSource source);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is over a drop node
		///     that it has registered.  The default implementation returns this.dropNotAllowed, so it should be
		///     overridden to provide the proper feedback.
		///     {@link #getTargetFromEvent} for this node)
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>String</returns>
		public extern virtual void onNodeOver(object nodeData, Ext.dd.DragSource source, Event e);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is over a drop node
		///     that it has registered.  The default implementation returns this.dropNotAllowed, so it should be
		///     overridden to provide the proper feedback.
		///     {@link #getTargetFromEvent} for this node)
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>String</returns>
		public extern virtual void onNodeOver(object nodeData, Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dragged out of
		///     the drop node without dropping.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <returns></returns>
		public extern virtual void onNodeOut();

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dragged out of
		///     the drop node without dropping.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <returns></returns>
		public extern virtual void onNodeOut(object nodeData);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dragged out of
		///     the drop node without dropping.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns></returns>
		public extern virtual void onNodeOut(object nodeData, Ext.dd.DragSource source);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dragged out of
		///     the drop node without dropping.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns></returns>
		public extern virtual void onNodeOut(object nodeData, Ext.dd.DragSource source, Event e);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dragged out of
		///     the drop node without dropping.  This method has no default implementation and should be overridden to provide
		///     node-specific processing if necessary.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns></returns>
		public extern virtual void onNodeOut(object nodeData, Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped onto
		///     the drop node.  The default implementation returns false, so it should be overridden to provide the
		///     appropriate processing of the drop event and return true so that the drag source's repair action does not run.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void onNodeDrop();

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped onto
		///     the drop node.  The default implementation returns false, so it should be overridden to provide the
		///     appropriate processing of the drop event and return true so that the drag source's repair action does not run.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <returns>Boolean</returns>
		public extern virtual void onNodeDrop(object nodeData);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped onto
		///     the drop node.  The default implementation returns false, so it should be overridden to provide the
		///     appropriate processing of the drop event and return true so that the drag source's repair action does not run.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>Boolean</returns>
		public extern virtual void onNodeDrop(object nodeData, Ext.dd.DragSource source);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped onto
		///     the drop node.  The default implementation returns false, so it should be overridden to provide the
		///     appropriate processing of the drop event and return true so that the drag source's repair action does not run.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>Boolean</returns>
		public extern virtual void onNodeDrop(object nodeData, Ext.dd.DragSource source, Event e);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped onto
		///     the drop node.  The default implementation returns false, so it should be overridden to provide the
		///     appropriate processing of the drop event and return true so that the drag source's repair action does not run.
		///     {@link #getTargetFromEvent} for this node)
		/// </summary>
		/// <param name="nodeData">The custom data associated with the drop node (this is the same value returned from</param>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>Boolean</returns>
		public extern virtual void onNodeDrop(object nodeData, Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is being dragged over it,
		///     but not over any of its registered drop nodes.  The default implementation returns this.dropNotAllowed, so
		///     it should be overridden to provide the proper feedback if necessary.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <returns>String</returns>
		public extern virtual void onContainerOver();

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is being dragged over it,
		///     but not over any of its registered drop nodes.  The default implementation returns this.dropNotAllowed, so
		///     it should be overridden to provide the proper feedback if necessary.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>String</returns>
		public extern virtual void onContainerOver(Ext.dd.DragSource source);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is being dragged over it,
		///     but not over any of its registered drop nodes.  The default implementation returns this.dropNotAllowed, so
		///     it should be overridden to provide the proper feedback if necessary.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>String</returns>
		public extern virtual void onContainerOver(Ext.dd.DragSource source, Event e);

		/// <summary>
		///     Called internally while the DropZone determines that a {@link Ext.dd.DragSource} is being dragged over it,
		///     but not over any of its registered drop nodes.  The default implementation returns this.dropNotAllowed, so
		///     it should be overridden to provide the proper feedback if necessary.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>String</returns>
		public extern virtual void onContainerOver(Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped on it,
		///     but not on any of its registered drop nodes.  The default implementation returns false, so it should be
		///     overridden to provide the appropriate processing of the drop event if you need the drop zone itself to
		///     be able to accept drops.  It should return true when valid so that the drag source's repair action does not run.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void onContainerDrop();

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped on it,
		///     but not on any of its registered drop nodes.  The default implementation returns false, so it should be
		///     overridden to provide the appropriate processing of the drop event if you need the drop zone itself to
		///     be able to accept drops.  It should return true when valid so that the drag source's repair action does not run.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>Boolean</returns>
		public extern virtual void onContainerDrop(Ext.dd.DragSource source);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped on it,
		///     but not on any of its registered drop nodes.  The default implementation returns false, so it should be
		///     overridden to provide the appropriate processing of the drop event if you need the drop zone itself to
		///     be able to accept drops.  It should return true when valid so that the drag source's repair action does not run.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>Boolean</returns>
		public extern virtual void onContainerDrop(Ext.dd.DragSource source, Event e);

		/// <summary>
		///     Called internally when the DropZone determines that a {@link Ext.dd.DragSource} has been dropped on it,
		///     but not on any of its registered drop nodes.  The default implementation returns false, so it should be
		///     overridden to provide the appropriate processing of the drop event if you need the drop zone itself to
		///     be able to accept drops.  It should return true when valid so that the drag source's repair action does not run.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>Boolean</returns>
		public extern virtual void onContainerDrop(Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source is now over
		///     the zone.  The default implementation returns this.dropNotAllowed and expects that only registered drop
		///     nodes can process drag drop operations, so if you need the drop zone itself to be able to process drops
		///     you should override this method and provide a custom implementation.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <returns>String</returns>
		public extern virtual void notifyEnter();

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source is now over
		///     the zone.  The default implementation returns this.dropNotAllowed and expects that only registered drop
		///     nodes can process drag drop operations, so if you need the drop zone itself to be able to process drops
		///     you should override this method and provide a custom implementation.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>String</returns>
		public extern virtual void notifyEnter(Ext.dd.DragSource source);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source is now over
		///     the zone.  The default implementation returns this.dropNotAllowed and expects that only registered drop
		///     nodes can process drag drop operations, so if you need the drop zone itself to be able to process drops
		///     you should override this method and provide a custom implementation.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>String</returns>
		public extern virtual void notifyEnter(Ext.dd.DragSource source, Event e);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source is now over
		///     the zone.  The default implementation returns this.dropNotAllowed and expects that only registered drop
		///     nodes can process drag drop operations, so if you need the drop zone itself to be able to process drops
		///     you should override this method and provide a custom implementation.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>String</returns>
		public extern virtual void notifyEnter(Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the drop zone.
		///     This method will be called on every mouse movement while the drag source is over the drop zone.
		///     It will call {@link #onNodeOver} while the drag source is over a registered node, and will also automatically
		///     delegate to the appropriate node-specific methods as necessary when the drag source enters and exits
		///     registered nodes ({@link #onNodeEnter}, {@link #onNodeOut}). If the drag source is not currently over a
		///     registered node, it will call {@link #onContainerOver}.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <returns>String</returns>
		public extern virtual void notifyOver();

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the drop zone.
		///     This method will be called on every mouse movement while the drag source is over the drop zone.
		///     It will call {@link #onNodeOver} while the drag source is over a registered node, and will also automatically
		///     delegate to the appropriate node-specific methods as necessary when the drag source enters and exits
		///     registered nodes ({@link #onNodeEnter}, {@link #onNodeOut}). If the drag source is not currently over a
		///     registered node, it will call {@link #onContainerOver}.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>String</returns>
		public extern virtual void notifyOver(Ext.dd.DragSource source);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the drop zone.
		///     This method will be called on every mouse movement while the drag source is over the drop zone.
		///     It will call {@link #onNodeOver} while the drag source is over a registered node, and will also automatically
		///     delegate to the appropriate node-specific methods as necessary when the drag source enters and exits
		///     registered nodes ({@link #onNodeEnter}, {@link #onNodeOut}). If the drag source is not currently over a
		///     registered node, it will call {@link #onContainerOver}.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>String</returns>
		public extern virtual void notifyOver(Ext.dd.DragSource source, Event e);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls continuously while it is being dragged over the drop zone.
		///     This method will be called on every mouse movement while the drag source is over the drop zone.
		///     It will call {@link #onNodeOver} while the drag source is over a registered node, and will also automatically
		///     delegate to the appropriate node-specific methods as necessary when the drag source enters and exits
		///     registered nodes ({@link #onNodeEnter}, {@link #onNodeOut}). If the drag source is not currently over a
		///     registered node, it will call {@link #onContainerOver}.
		///     underlying {@link Ext.dd.StatusProxy} can be updated
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>String</returns>
		public extern virtual void notifyOver(Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source has been dragged
		///     out of the zone without dropping.  If the drag source is currently over a registered node, the notification
		///     will be delegated to {@link #onNodeOut} for node-specific handling, otherwise it will be ignored.
		/// </summary>
		/// <returns></returns>
		public extern virtual void notifyOut();

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source has been dragged
		///     out of the zone without dropping.  If the drag source is currently over a registered node, the notification
		///     will be delegated to {@link #onNodeOut} for node-specific handling, otherwise it will be ignored.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <returns></returns>
		public extern virtual void notifyOut(Ext.dd.DragSource source);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source has been dragged
		///     out of the zone without dropping.  If the drag source is currently over a registered node, the notification
		///     will be delegated to {@link #onNodeOut} for node-specific handling, otherwise it will be ignored.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <returns></returns>
		public extern virtual void notifyOut(Ext.dd.DragSource source, Event e);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the source has been dragged
		///     out of the zone without dropping.  If the drag source is currently over a registered node, the notification
		///     will be delegated to {@link #onNodeOut} for node-specific handling, otherwise it will be ignored.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop target</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag zone</param>
		/// <returns></returns>
		public extern virtual void notifyOut(Ext.dd.DragSource source, Event e, object data);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the dragged item has
		///     been dropped on it.  The drag zone will look up the target node based on the event passed in, and if there
		///     is a node registered for that event, it will delegate to {@link #onNodeDrop} for node-specific handling,
		///     otherwise it will call {@link #onContainerDrop}.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void notifyDrop();

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the dragged item has
		///     been dropped on it.  The drag zone will look up the target node based on the event passed in, and if there
		///     is a node registered for that event, it will delegate to {@link #onNodeDrop} for node-specific handling,
		///     otherwise it will call {@link #onContainerDrop}.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <returns>Boolean</returns>
		public extern virtual void notifyDrop(Ext.dd.DragSource source);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the dragged item has
		///     been dropped on it.  The drag zone will look up the target node based on the event passed in, and if there
		///     is a node registered for that event, it will delegate to {@link #onNodeDrop} for node-specific handling,
		///     otherwise it will call {@link #onContainerDrop}.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <returns>Boolean</returns>
		public extern virtual void notifyDrop(Ext.dd.DragSource source, Event e);

		/// <summary>
		///     The function a {@link Ext.dd.DragSource} calls once to notify this drop zone that the dragged item has
		///     been dropped on it.  The drag zone will look up the target node based on the event passed in, and if there
		///     is a node registered for that event, it will delegate to {@link #onNodeDrop} for node-specific handling,
		///     otherwise it will call {@link #onContainerDrop}.
		/// </summary>
		/// <param name="source">The drag source that was dragged over this drop zone</param>
		/// <param name="e">The event</param>
		/// <param name="data">An object containing arbitrary data supplied by the drag source</param>
		/// <returns>Boolean</returns>
		public extern virtual void notifyDrop(Ext.dd.DragSource source, Event e, object data);



	}

	[JsAnonymous]
	public class DropZoneConfig : System.DotWeb.JsDynamic {
		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
		public string ddGroup { get { return (string)this["ddGroup"]; } set { this["ddGroup"] = value; } }

		/// <summary>  The CSS class applied to the drop target element while the drag source is over it (defaults to "").</summary>
		public string overClass { get { return (string)this["overClass"]; } set { this["overClass"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return (string)this["dropAllowed"]; } set { this["dropAllowed"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return (string)this["dropNotAllowed"]; } set { this["dropNotAllowed"] = value; } }

	}
}
