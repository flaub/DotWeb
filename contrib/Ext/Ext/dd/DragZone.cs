using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.dd {
	/// <summary>
	///     /**
	///     This class provides a container DD instance that proxies for multiple child node sources.<br />
	///     By default, this class requires that draggable child nodes are registered with {@link Ext.dd.Registry}.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\dd\DragZone.js</jssource>
	public class DragZone : Ext.dd.DragSource {

		/// <summary></summary>
		/// <returns></returns>
		public extern DragZone();
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <returns></returns>
		public extern DragZone(object el);
		/// <summary></summary>
		/// <param name="el">The container element</param>
		/// <param name="config"></param>
		/// <returns></returns>
		public extern DragZone(object el, object config);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <returns></returns>
		public extern DragZone(string id);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <returns></returns>
		public extern DragZone(string id, string sGroup);
		/// <summary>
		///     Valid properties for DDProxy in addition to those in DragDrop:
		///     resizeFrame, centerFrame, dragElId
		/// </summary>
		/// <param name="id">the id of the linked html element</param>
		/// <param name="sGroup">the group of related DragDrop objects</param>
		/// <param name="config">an object containing configurable attributes</param>
		/// <returns></returns>
		public extern DragZone(string id, string sGroup, object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static DragZone prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.dd.DragSource superclass { get; set; }

		/// <summary>True to register this container with the Scrollmanagerfor auto scrolling during drag operations.</summary>
		public extern bool containerScroll { get; set; }

		/// <summary>The color to use when visually highlighting the drag source in the afterRepairmethod after a failed drop (defaults to "c3daf9" - light blue)</summary>
		public extern string hlColor { get; set; }


		/// <summary>
		///     Called when a mousedown occurs in this container. Looks in {@link Ext.dd.Registry}
		///     for a valid target to drag based on the mouse down. Override this method
		///     to provide your own lookup logic (e.g. finding a child by class name). Make sure your returned
		///     object has a "ddel" attribute (with an HTML Element) for other functions to work.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getDragData();

		/// <summary>
		///     Called when a mousedown occurs in this container. Looks in {@link Ext.dd.Registry}
		///     for a valid target to drag based on the mouse down. Override this method
		///     to provide your own lookup logic (e.g. finding a child by class name). Make sure your returned
		///     object has a "ddel" attribute (with an HTML Element) for other functions to work.
		/// </summary>
		/// <param name="e">The mouse down event</param>
		/// <returns>Object</returns>
		public extern virtual void getDragData(EventObject e);

		/// <summary>
		///     Called once drag threshold has been reached to initialize the proxy element. By default, it clones the
		///     this.dragData.ddel
		/// </summary>
		/// <returns>Boolean</returns>
		public extern virtual void onInitDrag();

		/// <summary>
		///     Called once drag threshold has been reached to initialize the proxy element. By default, it clones the
		///     this.dragData.ddel
		/// </summary>
		/// <param name="x">The x position of the click on the dragged object</param>
		/// <returns>Boolean</returns>
		public extern virtual void onInitDrag(double x);

		/// <summary>
		///     Called once drag threshold has been reached to initialize the proxy element. By default, it clones the
		///     this.dragData.ddel
		/// </summary>
		/// <param name="x">The x position of the click on the dragged object</param>
		/// <param name="y">The y position of the click on the dragged object</param>
		/// <returns>Boolean</returns>
		public extern virtual void onInitDrag(double x, double y);

		/// <summary>Called after a repair of an invalid drop. By default, highlights this.dragData.ddel</summary>
		/// <returns></returns>
		public extern virtual void afterRepair();

		/// <summary>
		///     Called before a repair of an invalid drop to get the XY to animate to. By default returns
		///     the XY of this.dragData.ddel
		/// </summary>
		/// <returns>Array</returns>
		public extern virtual void getRepairXY();

		/// <summary>
		///     Called before a repair of an invalid drop to get the XY to animate to. By default returns
		///     the XY of this.dragData.ddel
		/// </summary>
		/// <param name="e">The mouse up event</param>
		/// <returns>Array</returns>
		public extern virtual void getRepairXY(EventObject e);



	}

	[JsAnonymous]
	public class DragZoneConfig : System.DotWeb.JsDynamic {
		/// <summary> True to register this container with the Scrollmanager for auto scrolling during drag operations.</summary>
		public bool containerScroll { get { return (bool)this["containerScroll"]; } set { this["containerScroll"] = value; } }

		/// <summary> The color to use when visually highlighting the drag source in the afterRepair method after a failed drop (defaults to "c3daf9" - light blue)</summary>
		public string hlColor { get { return (string)this["hlColor"]; } set { this["hlColor"] = value; } }

		/// <summary>  A named drag drop group to which this object belongs.  If a group is specified, then this object will only interact with other drag drop objects in the same group (defaults to undefined).</summary>
		public string ddGroup { get { return (string)this["ddGroup"]; } set { this["ddGroup"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is allowed (defaults to "x-dd-drop-ok").</summary>
		public string dropAllowed { get { return (string)this["dropAllowed"]; } set { this["dropAllowed"] = value; } }

		/// <summary>  The CSS class returned to the drag source when drop is not allowed (defaults to "x-dd-drop-nodrop").</summary>
		public string dropNotAllowed { get { return (string)this["dropNotAllowed"]; } set { this["dropNotAllowed"] = value; } }

	}
}
