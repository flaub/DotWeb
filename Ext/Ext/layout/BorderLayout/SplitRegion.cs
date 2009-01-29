using System;
using DotWeb.Core;

namespace Ext.layout.BorderLayout {
    /// <summary>
    ///     /**
    ///     This is a specialized type of BorderLayout region that has a built-in {@link Ext.SplitBar} for user resizing of regions.
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\layout\BorderLayout.js</jssource>
    [Native]
    public class SplitRegion : Ext.layout.BorderLayout.Region {

        /// <summary>
        ///     Create a new SplitRegion.
        ///     BorderLayout must have a center region for the primary content -- all other regions are optional.
        /// </summary>
        /// <returns></returns>
        public SplitRegion() {}
        /// <summary>
        ///     Create a new SplitRegion.
        ///     BorderLayout must have a center region for the primary content -- all other regions are optional.
        /// </summary>
        /// <param name="layout">Any valid Ext layout class</param>
        /// <returns></returns>
        public SplitRegion(object layout) {}
        /// <summary>
        ///     Create a new SplitRegion.
        ///     BorderLayout must have a center region for the primary content -- all other regions are optional.
        /// </summary>
        /// <param name="layout">Any valid Ext layout class</param>
        /// <param name="config">The configuration options</param>
        /// <returns></returns>
        public SplitRegion(object layout, object config) {}
        /// <summary>
        ///     Create a new SplitRegion.
        ///     BorderLayout must have a center region for the primary content -- all other regions are optional.
        /// </summary>
        /// <param name="layout">Any valid Ext layout class</param>
        /// <param name="config">The configuration options</param>
        /// <param name="position">The region position.  Valid values are: north, south, east, west and center.  Every</param>
        /// <returns></returns>
        public SplitRegion(object layout, object config, System.String position) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static SplitRegion prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.layout.BorderLayout.Region superclass { get { return null; } set { } }

        /// <summary>
        ///     The tooltip to display when the user hovers over a non-collapsible region's split bar (defaults to "Drag
        ///     to resize.").  Only applies if {@link #useSplitTips} = true.
        /// </summary>
        public System.String splitTip { get { return null; } set { } }

        /// <summary>
        ///     The tooltip to display when the user hovers over a collapsible region's split bar (defaults to "Drag
        ///     to resize. Double click to hide.").  Only applies if {@link #useSplitTips} = true.
        /// </summary>
        public System.String collapsibleSplitTip { get { return null; } set { } }

        /// <summary>
        ///     True to display a tooltip when the user hovers over a region's split bar (defaults to false).  The tooltip
        ///     text will be the value of either {@link #splitTip} or {@link #collapsibleSplitTip} as appropriate.
        /// </summary>
        public bool useSplitTips { get { return false; } set { } }


        /// <summary>Returns a reference to the split bar in use by this region.</summary>
        /// <returns>Ext.SplitBar</returns>
        public virtual Ext.SplitBarClass getSplitBar() { return null; }



    }
    [Anonymous]
    public class SplitRegionConfig {

        /// <summary>  The tooltip to display when the user hovers over a non-collapsible region's split bar (defaults to "Drag to resize.").  Only applies if {@link #useSplitTips} = true.</summary>
        public System.String splitTip { get { return null; } set { } }

        /// <summary>  The tooltip to display when the user hovers over a collapsible region's split bar (defaults to "Drag to resize. Double click to hide.").  Only applies if {@link #useSplitTips} = true.</summary>
        public System.String collapsibleSplitTip { get { return null; } set { } }

        /// <summary>  True to display a tooltip when the user hovers over a region's split bar (defaults to false).  The tooltip text will be the value of either {@link #splitTip} or {@link #collapsibleSplitTip} as appropriate.</summary>
        public bool useSplitTips { get { return false; } set { } }

        /// <summary>  When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will close again once the user mouses out of that panel (or clicks out if autoHide = false).  Setting animFloat to false will prevent the open and close of these floated panels from being animated (defaults to true).</summary>
        public bool animFloat { get { return false; } set { } }

        /// <summary>  When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel.  If autoHide is true, the panel will automatically hide after the user mouses out of the panel.  If autoHide is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).</summary>
        public bool autoHide { get { return false; } set { } }

        /// <summary>  By default, collapsible regions will be visible when rendered. Set the collapsed config to true to render the region as collapsed.</summary>
        public bool collapsed { get { return false; } set { } }

        /// <summary>  By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar.  Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar.  In 'mini' mode the region will collapse to a thinner bar than in normal mode.  By default collapseMode is undefined, and the only two supported values are undefined and 'mini'.  Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.</summary>
        public System.String collapseMode { get { return null; } set { } }

        /// <summary>  An object containing margins to apply to the region in the format {left: (left margin), top: (top margin), right: (right margin), bottom: (bottom margin)}</summary>
        public object margins { get { return null; } set { } }

        /// <summary>  An object containing margins to apply to the region's collapsed element in the format {left: (left margin), top: (top margin), right: (right margin), bottom: (bottom margin)}</summary>
        public object cmargins { get { return null; } set { } }

        /// <summary>  True to allow the user to collapse this region (defaults to false).  If true, an expand/collapse tool button will automatically be rendered into the title bar of the region, otherwise the button will not be shown. Note that a title bar is required to display the toggle button -- if no region title is specified, the region will only be collapsible if {@link #collapseMode} is set to 'mini'.</summary>
        public bool collapsible { get { return false; } set { } }

        /// <summary>  True to display a {@link Ext.SplitBar} between this region and its neighbor, allowing the user to resize the regions dynamically (defaults to false).  When split == true, it is common to specify a minSize and maxSize for the BoxComponent representing the region. These are not native configs of BoxComponent, and are used only by this class.</summary>
        public bool split { get { return false; } set { } }

        /// <summary>  True to allow clicking a collapsed region's bar to display the region's panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).</summary>
        public bool floatable { get { return false; } set { } }

        /// <summary>  The minimum allowable width in pixels for this region (defaults to 50)</summary>
        public double minWidth { get { return 0; } set { } }

        /// <summary>  The minimum allowable height in pixels for this region (defaults to 50)</summary>
        public double minHeight { get { return 0; } set { } }

    }


}
