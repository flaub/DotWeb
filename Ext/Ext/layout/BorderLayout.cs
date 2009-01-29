using System;
using DotWeb.Core;

namespace Ext.layout {
    /// <summary>
    ///     /**
    ///     <p>This is a multi-pane, application-oriented UI layout style that supports multiple nested panels, automatic
    ///     split bars between regions and built-in expanding and collapsing of regions.
    ///     This class is intended to be extended or created via the layout:'border' {@link Ext.Container#layout} config,
    ///     and should generally not need to be created directly via the new keyword.</p>
    ///     <p>BorderLayout does not have any direct config options (other than inherited ones).  All configs available
    ///     for customizing the BorderLayout are at the {@link Ext.layout.BorderLayout.Region} and
    ///     {@link Ext.layout.BorderLayout.SplitRegion} levels.</p>
    ///     <p><b>The regions of a BorderLayout are fixed at render time and thereafter, no regions may be removed or
    ///     added.</b></p>
    ///     <p>Example usage:</p>
    ///     <pre><code>
    ///     var border = new Ext.Panel({
    ///     title: 'Border Layout',
    ///     layout:'border',
    ///     items: [{
    ///     title: 'South Panel',
    ///     region: 'south',
    ///     height: 100,
    ///     minSize: 75,
    ///     maxSize: 250,
    ///     margins: '0 5 5 5'
    ///     },{
    ///     title: 'West Panel',
    ///     region:'west',
    ///     margins: '5 0 0 5',
    ///     cmargins: '5 5 0 5',
    ///     width: 200,
    ///     minSize: 100,
    ///     maxSize: 300
    ///     },{
    ///     title: 'Main Content',
    ///     region:'center',
    ///     margins: '5 5 0 0'
    ///     }]
    ///     });
    ///     </code></pre>
    ///     */
    ///     Ext.layout.BorderLayout = Ext.extend(Ext.layout.ContainerLayout, {
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\layout\BorderLayout.js</jssource>
    [Native]
    public class BorderLayoutClass : Ext.layout.ContainerLayout {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public BorderLayoutClass() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static BorderLayoutClass prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The reference to the class that this class inherits from</summary>
        public static Ext.layout.ContainerLayout superclass { get { return null; } set { } }




    }
    [Anonymous]
    public class BorderLayoutConfig {

        /// <summary>  An optional extra CSS class that will be added to the container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
        public System.String extraCls { get { return null; } set { } }

        /// <summary>  True to hide each contained item on render (defaults to false).</summary>
        public bool renderHidden { get { return false; } set { } }

    }


}
