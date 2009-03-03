using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     The default global window group that is available automatically.  To have more than one group of windows
	///     with separate z-order stacks, create additional instances of {@link Ext.WindowGroup} as needed.
	///     */
	///     Ext.WindowMgr = new Ext.WindowGroup();
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\WindowManager.js</jssource>
	public class WindowMgr : Ext.WindowGroup {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public WindowMgr() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static WindowMgr prototype { get { return S_<WindowMgr>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.WindowGroup superclass { get { return S_<Ext.WindowGroup>(); } set { S_(value); } }




	}
}
