using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     The default global window group that is available automatically.  To have more than one group of windows
	///     with separate z-order stacks, create additional instances of {@link Ext.WindowGroup} as needed.
	///     */
	///     Ext.WindowMgr = new Ext.WindowGroup();
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\WindowManager.js</jssource>
	public class WindowMgr : Ext.WindowGroup {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern WindowMgr();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static WindowMgr prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.WindowGroup superclass { get; set; }




	}
}
