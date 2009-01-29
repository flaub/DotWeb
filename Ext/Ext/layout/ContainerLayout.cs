using System;
using DotWeb.Core;

namespace Ext.layout {
    /// <summary>
    ///     /**
    ///     Every layout is composed of one or more {@link Ext.Container} elements internally, and ContainerLayout provides
    ///     the basic foundation for all other layout classes in Ext.  It is a non-visual class that simply provides the
    ///     base logic required for a Container to function as a layout.  This class is intended to be extended and should
    ///     generally not need to be created directly via the new keyword.
    ///     */
    ///     Ext.layout.ContainerLayout = function(config){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\layout\ContainerLayout.js</jssource>
    [Native]
    public class ContainerLayout  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public ContainerLayout() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static ContainerLayout prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>
        ///     An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for
        ///     adding customized styles to the container or any of its children using standard CSS rules.
        /// </summary>
        public System.String extraCls { get { return null; } set { } }

        /// <summary>True to hide each contained item on render (defaults to false).</summary>
        public bool renderHidden { get { return false; } set { } }

        /// <summary>
        ///     A reference to the {@link Ext.Component} that is active.  For example,
        ///     if(myPanel.layout.activeItem.id == 'item-1') { ... }.  activeItem only applies to layout styles that can
        ///     display items one at a time (like {@link Ext.layout.Accordion}, {@link Ext.layout.CardLayout}
        ///     and {@link Ext.layout.FitLayout}).  Read-only.  Related to {@link Ext.Container#activeItem}.
        /// </summary>
        public Ext.Component activeItem { get { return null; } set { } }




    }
    [Anonymous]
    public class ContainerLayoutConfig {

        /// <summary>  An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
        public System.String extraCls { get { return null; } set { } }

        /// <summary>  True to hide each contained item on render (defaults to false).</summary>
        public bool renderHidden { get { return false; } set { } }

    }


}
