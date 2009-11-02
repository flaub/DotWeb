using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     A simple class that provides the basic implementation needed to make any element draggable.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\dd\DragSource.js</jssource>
	public class DragSource : Ext.dd.DDProxy {

		/// <summary></summary>
		/// <returns></returns>
		public extern DragSource();
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public extern DragSource(object el);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern DragSource(object el, object config);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <returns></returns>
		public extern DragSource(string id);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public extern DragSource(string id, string sGroup);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public extern DragSource(string id, string sGroup, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static DragSource prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.dd.DDProxy superclass { get; set; }

		/// <summary>
		///     A named drag drop group to which this object belongs.  If a group is specified, then this object will only
		///     interact with other drag drop objects in the same group (defaults to undefined).
		/// </summary>
		public extern string ddGroup { get; set; }

		/// <summary>The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public extern string dropAllowed { get; set; }

		/// <summary>The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public extern string dropNotAllowed { get; set; }

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action once the initial
		///     drag event has begun.  The drag cannot be canceled from this function.
		///     @param {Number} x The x position of the click on the dragged object
		///     @param {Number} y The y position of the click on the dragged object
		/// </summary>
		public extern object onStartDrag { get; set; }


		/// <summary>Returns the data object associated with this drag source</summary>
		/// <returns>Object</returns>
		public extern virtual void getDragData();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     when the dragged item enters the drop target by providing an implementation.
		/// </summary>
		/// <returns></returns>
		public extern virtual void afterDragEnter();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     when the dragged item enters the drop target by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns></returns>
		public extern virtual void afterDragEnter(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     when the dragged item enters the drop target by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns></returns>
		public extern virtual void afterDragEnter(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     when the dragged item enters the drop target by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns></returns>
		public extern virtual void afterDragEnter(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragEnter();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragEnter(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragEnter(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     before the dragged item enters the drop target and optionally cancel the onDragEnter.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragEnter(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target by providing an implementation.
		/// </summary>
		/// <returns></returns>
		public extern virtual void afterDragOver();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns></returns>
		public extern virtual void afterDragOver(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns></returns>
		public extern virtual void afterDragOver(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns></returns>
		public extern virtual void afterDragOver(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target and optionally cancel the onDragOver.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOver();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target and optionally cancel the onDragOver.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOver(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target and optionally cancel the onDragOver.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOver(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     while the dragged item is over the drop target and optionally cancel the onDragOver.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOver(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after the dragged item is dragged out of the target without dropping.
		/// </summary>
		/// <returns></returns>
		public extern virtual void afterDragOut();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after the dragged item is dragged out of the target without dropping.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns></returns>
		public extern virtual void afterDragOut(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after the dragged item is dragged out of the target without dropping.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns></returns>
		public extern virtual void afterDragOut(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after the dragged item is dragged out of the target without dropping.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns></returns>
		public extern virtual void afterDragOut(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOut();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOut(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOut(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dragged out of the target without dropping, and optionally cancel the onDragOut.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragOut(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drag drop has occurred by providing an implementation.
		/// </summary>
		/// <returns></returns>
		public extern virtual void afterDragDrop();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drag drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns></returns>
		public extern virtual void afterDragDrop(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drag drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns></returns>
		public extern virtual void afterDragDrop(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drag drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dropped element</param>
		/// <returns></returns>
		public extern virtual void afterDragDrop(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dropped onto the target and optionally cancel the onDragDrop.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragDrop();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dropped onto the target and optionally cancel the onDragDrop.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragDrop(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dropped onto the target and optionally cancel the onDragDrop.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragDrop(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the dragged
		///     item is dropped onto the target and optionally cancel the onDragDrop.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeDragDrop(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drop has occurred by providing an implementation.
		/// </summary>
		/// <returns></returns>
		public extern virtual void afterInvalidDrop();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="target">The target DD</param>
		/// <returns></returns>
		public extern virtual void afterInvalidDrop(object target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="target">The target DD</param>
		/// <param name="e">The event object</param>
		/// <returns></returns>
		public extern virtual void afterInvalidDrop(object target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after a valid drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="target">The target DD</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dropped element</param>
		/// <returns></returns>
		public extern virtual void afterInvalidDrop(object target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after an invalid drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="e">The event object</param>
		/// <returns></returns>
		public extern virtual void afterInvalidDrop(Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action
		///     after an invalid drop has occurred by providing an implementation.
		/// </summary>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dropped element</param>
		/// <returns></returns>
		public extern virtual void afterInvalidDrop(Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action after an invalid
		///     drop has occurred.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void beforeInvalidDrop();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action after an invalid
		///     drop has occurred.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeInvalidDrop(Ext.dd.DragDrop target);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action after an invalid
		///     drop has occurred.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeInvalidDrop(Ext.dd.DragDrop target, Event e);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action after an invalid
		///     drop has occurred.
		/// </summary>
		/// <param name="target">The drop target</param>
		/// <param name="e">The event object</param>
		/// <param name="id">The id of the dragged element</param>
		/// <returns>Boolean</returns>
		public extern virtual void beforeInvalidDrop(Ext.dd.DragDrop target, Event e, string id);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the initial
		///     drag event begins and optionally cancel it.
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void onBeforeDrag();

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the initial
		///     drag event begins and optionally cancel it.
		/// </summary>
		/// <param name="data">An object containing arbitrary data to be shared with drop targets</param>
		/// <returns>Boolean</returns>
		public extern virtual void onBeforeDrag(object data);

		/// <summary>
		///     An empty function by default, but provided so that you can perform a custom action before the initial
		///     drag event begins and optionally cancel it.
		/// </summary>
		/// <param name="data">An object containing arbitrary data to be shared with drop targets</param>
		/// <param name="e">The event object</param>
		/// <returns>Boolean</returns>
		public extern virtual void onBeforeDrag(object data, Event e);

		/// <summary>Returns the drag source's underlying {@link Ext.dd.StatusProxy}</summary>
		/// <returns>Ext.dd.StatusProxy</returns>
		public extern virtual void getProxy();

		/// <summary>Hides the drag source's {@link Ext.dd.StatusProxy}</summary>
		/// <returns></returns>
		public extern virtual void hideProxy();



	}

	[JsAnonymous]
	public class DragSourceConfig : System.DotWeb.JsDynamic {
		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
		public string ddGroup { get { return (string)this["ddGroup"]; } set { this["ddGroup"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return (string)this["dropAllowed"]; } set { this["dropAllowed"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return (string)this["dropNotAllowed"]; } set { this["dropNotAllowed"] = value; } }

	}
}
