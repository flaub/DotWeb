using System;
using DotWeb.Core;

namespace Ext.SplitBar {
    /// <summary>
    ///     /**
    ///     Default Adapter. It assumes the splitter and resizing element are not positioned
    ///     elements and only gets/sets the width of the element. Generally used for table based layouts.
    ///     */
    ///     Ext.SplitBar.BasicLayoutAdapter = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\SplitBar.js</jssource>
    [Native]
    public class BasicLayoutAdapter  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public BasicLayoutAdapter() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static BasicLayoutAdapter prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Called before drag operations to get the current size of the resizing element.</summary>
        /// <returns></returns>
        public virtual void getElementSize() { return ; }

        /// <summary>Called before drag operations to get the current size of the resizing element.</summary>
        /// <param name="s">The SplitBar using this adapter</param>
        /// <returns></returns>
        public virtual void getElementSize(Ext.SplitBarClass s) { return ; }

        /// <summary>Called after drag operations to set the size of the resizing element.</summary>
        /// <returns></returns>
        public virtual void setElementSize() { return ; }

        /// <summary>Called after drag operations to set the size of the resizing element.</summary>
        /// <param name="s">The SplitBar using this adapter</param>
        /// <returns></returns>
        public virtual void setElementSize(Ext.SplitBarClass s) { return ; }

        /// <summary>Called after drag operations to set the size of the resizing element.</summary>
        /// <param name="s">The SplitBar using this adapter</param>
        /// <param name="newSize">The new size to set</param>
        /// <returns></returns>
        public virtual void setElementSize(Ext.SplitBarClass s, double newSize) { return ; }

        /// <summary>Called after drag operations to set the size of the resizing element.</summary>
        /// <param name="s">The SplitBar using this adapter</param>
        /// <param name="newSize">The new size to set</param>
        /// <param name="onComplete">A function to be invoked when resizing is complete</param>
        /// <returns></returns>
        public virtual void setElementSize(Ext.SplitBarClass s, double newSize, Delegate onComplete) { return ; }



    }
    [Anonymous]
    public class BasicLayoutAdapterConfig {

    }


}
