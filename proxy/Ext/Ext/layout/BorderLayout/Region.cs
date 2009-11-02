using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.layout.BorderLayout {
	/// <summary>
	///     /**
	///     This is a region of a BorderLayout that acts as a subcontainer within the layout.  Each region has its own
	///     layout that is independent of other regions and the containing BorderLayout, and can be any of the valid
	///     Ext layout types.  Region size is managed automatically and cannot be changed by the user -- for resizable
	///     regions, see {@link Ext.layout.BorderLayout.SplitRegion}.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\layout\BorderLayout.js</jssource>
	public class Region : System.DotWeb.JsObject {

		/// <summary>
		///     Create a new Region.
		///     BorderLayout must have a center region for the primary content -- all other regions are optional.
		/// </summary>
		/// <returns></returns>
		public extern Region();
		/// <summary>
		///     Create a new Region.
		///     BorderLayout must have a center region for the primary content -- all other regions are optional.
		/// </summary>
		/// <param name="layout">Any valid Ext layout class</param>
		/// <returns></returns>
		public extern Region(object layout);
		/// <summary>
		///     Create a new Region.
		///     BorderLayout must have a center region for the primary content -- all other regions are optional.
		/// </summary>
		/// <param name="layout">Any valid Ext layout class</param>
		/// <param name="config">The configuration options</param>
		/// <returns></returns>
		public extern Region(object layout, object config);
		/// <summary>
		///     Create a new Region.
		///     BorderLayout must have a center region for the primary content -- all other regions are optional.
		/// </summary>
		/// <param name="layout">Any valid Ext layout class</param>
		/// <param name="config">The configuration options</param>
		/// <param name="position">The region position.  Valid values are: north, south, east, west and center.  Every</param>
		/// <returns></returns>
		public extern Region(object layout, object config, string position);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static object prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>
		///     When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will
		///     close again once the user mouses out of that panel (or clicks out if autoHide = false).  Setting animFloat
		///     to false will prevent the open and close of these floated panels from being animated (defaults to true).
		/// </summary>
		public extern bool animFloat { get; set; }

		/// <summary>
		///     When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel.  If
		///     autoHide is true, the panel will automatically hide after the user mouses out of the panel.  If autoHide
		///     is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).
		/// </summary>
		public extern bool autoHide { get; set; }

		/// <summary>
		///     By default, collapsible regions will be visible when rendered. Set the collapsed config to true to render
		///     the region as collapsed.
		/// </summary>
		public extern bool collapsed { get; set; }

		/// <summary>
		///     By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into
		///     the region's title bar.  Optionally, when collapseMode is set to 'mini' the region's split bar will also
		///     display a small collapse button in the center of the bar.  In 'mini' mode the region will collapse to a
		///     thinner bar than in normal mode.  By default collapseMode is undefined, and the only two supported values
		///     are undefined and 'mini'.  Note that if a collapsible region does not have a title bar, then collapseMode
		///     must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not
		///     be rendered.
		/// </summary>
		public extern string collapseMode { get; set; }

		/// <summary>
		///     An object containing margins to apply to the region in the format {left: (left margin), top: (top margin),
		///     right: (right margin), bottom: (bottom margin)}
		/// </summary>
		public extern object margins { get; set; }

		/// <summary>
		///     An object containing margins to apply to the region's collapsed element in the format {left: (left margin),
		///     top: (top margin), right: (right margin), bottom: (bottom margin)}
		/// </summary>
		public extern object cmargins { get; set; }

		/// <summary>
		///     True to allow the user to collapse this region (defaults to false).  If true, an expand/collapse tool button
		///     will automatically be rendered into the title bar of the region, otherwise the button will not be shown.
		///     Note that a title bar is required to display the toggle button -- if no region title is specified, the
		///     region will only be collapsible if {@link #collapseMode} is set to 'mini'.
		/// </summary>
		public extern bool collapsible { get; set; }

		/// <summary>
		///     True to display a {@link Ext.SplitBar} between this region and its neighbor, allowing the user to resize
		///     the regions dynamically (defaults to false).  When split == true, it is common to specify a minSize
		///     and maxSize for the BoxComponent representing the region. These are not native configs of BoxComponent, and
		///     are used only by this class.
		/// </summary>
		public extern bool split { get; set; }

		/// <summary>
		///     True to allow clicking a collapsed region's bar to display the region's panel floated above the layout,
		///     false to force the user to fully expand a collapsed region by clicking the expand button to see it again
		///     (defaults to true).
		/// </summary>
		public extern bool floatable { get; set; }

		/// <summary>The minimum allowable width in pixels for this region (defaults to 50)</summary>
		public extern double minWidth { get; set; }

		/// <summary>The minimum allowable height in pixels for this region (defaults to 50)</summary>
		public extern double minHeight { get; set; }

		/// <summary>True if this region is collapsed. Read-only.</summary>
		public extern bool isCollapsed { get; set; }

		/// <summary>This region's layout position (north, south, east, west or center).  Read-only.</summary>
		public extern string position { get; set; }


		/// <summary>True if this region is currently visible, else false.</summary>
		/// <returns>Boolean</returns>
		public extern virtual void isVisible();

		/// <summary>
		///     Returns the current margins for this region.  If the region is collapsed, the cmargins (collapsed
		///     margins) value will be returned, otherwise the margins value will be returned.
		///     right: (right margin), bottom: (bottom margin)}
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getMargins();

		/// <summary>
		///     Returns the current size of this region.  If the region is collapsed, the size of the collapsedEl will
		///     be returned, otherwise the size of the region's panel will be returned.
		/// </summary>
		/// <returns>Object</returns>
		public extern virtual void getSize();

		/// <summary>Sets the specified panel as the container element for this region.</summary>
		/// <returns></returns>
		public extern virtual void setPanel();

		/// <summary>Sets the specified panel as the container element for this region.</summary>
		/// <param name="panel">The new panel</param>
		/// <returns></returns>
		public extern virtual void setPanel(Ext.Panel panel);

		/// <summary>Returns the minimum allowable width for this region.</summary>
		/// <returns>Number</returns>
		public extern virtual void getMinWidth();

		/// <summary>Returns the minimum allowable height for this region.</summary>
		/// <returns>Number</returns>
		public extern virtual void getMinHeight();



	}

	[JsAnonymous]
	public class RegionConfig : System.DotWeb.JsDynamic {
		/// <summary>  When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will close again once the user mouses out of that panel (or clicks out if autoHide = false).  Setting animFloat to false will prevent the open and close of these floated panels from being animated (defaults to true).</summary>
		public bool animFloat { get { return (bool)this["animFloat"]; } set { this["animFloat"] = value; } }

		/// <summary>  When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel.  If autoHide is true, the panel will automatically hide after the user mouses out of the panel.  If autoHide is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).</summary>
		public bool autoHide { get { return (bool)this["autoHide"]; } set { this["autoHide"] = value; } }

		/// <summary>  By default, collapsible regions will be visible when rendered. Set the collapsed config to true to render the region as collapsed.</summary>
		public bool collapsed { get { return (bool)this["collapsed"]; } set { this["collapsed"] = value; } }

		/// <summary>  By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar.  Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar.  In 'mini' mode the region will collapse to a thinner bar than in normal mode.  By default collapseMode is undefined, and the only two supported values are undefined and 'mini'.  Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.</summary>
		public string collapseMode { get { return (string)this["collapseMode"]; } set { this["collapseMode"] = value; } }

		/// <summary>  An object containing margins to apply to the region in the format {left: (left margin), top: (top margin), right: (right margin), bottom: (bottom margin)}</summary>
		public object margins { get { return (object)this["margins"]; } set { this["margins"] = value; } }

		/// <summary>  An object containing margins to apply to the region's collapsed element in the format {left: (left margin), top: (top margin), right: (right margin), bottom: (bottom margin)}</summary>
		public object cmargins { get { return (object)this["cmargins"]; } set { this["cmargins"] = value; } }

		/// <summary>  True to allow the user to collapse this region (defaults to false).  If true, an expand/collapse tool button will automatically be rendered into the title bar of the region, otherwise the button will not be shown. Note that a title bar is required to display the toggle button -- if no region title is specified, the region will only be collapsible if {@link #collapseMode} is set to 'mini'.</summary>
		public bool collapsible { get { return (bool)this["collapsible"]; } set { this["collapsible"] = value; } }

		/// <summary>  True to display a {@link Ext.SplitBar} between this region and its neighbor, allowing the user to resize the regions dynamically (defaults to false).  When split == true, it is common to specify a minSize and maxSize for the BoxComponent representing the region. These are not native configs of BoxComponent, and are used only by this class.</summary>
		public bool split { get { return (bool)this["split"]; } set { this["split"] = value; } }

		/// <summary>  True to allow clicking a collapsed region's bar to display the region's panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).</summary>
		public bool floatable { get { return (bool)this["floatable"]; } set { this["floatable"] = value; } }

		/// <summary>  The minimum allowable width in pixels for this region (defaults to 50)</summary>
		public double minWidth { get { return (double)this["minWidth"]; } set { this["minWidth"] = value; } }

		/// <summary>  The minimum allowable height in pixels for this region (defaults to 50)</summary>
		public double minHeight { get { return (double)this["minHeight"]; } set { this["minHeight"] = value; } }

	}
}
