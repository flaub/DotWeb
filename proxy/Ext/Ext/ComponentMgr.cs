using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Provides a registry of all Components (specifically subclasses of
	///     {@link Ext.Component}) on a page so that they can be easily accessed by
	///     component id (see {@link Ext.getCmp}).</p>
	///     <p>This object also provides a registry of available Component <i>classes</i>
	///     indexed by a mnemonic code known as the Component's {@link Ext.Component#xtype}.
	///     The <tt>xtype</tt> provides a way to avoid instantiating child Components
	///     when creating a full, nested config object for a complete Ext page.</p>
	///     <p>
	///     A child Component may be specified simply as a <i>config object</i>
	///     as long as the correct xtype is specified so that if and when the Component
	///     needs rendering, the correct type can be looked up for lazy instantiation.</p>
	///     <p>For a list of all available xtypes, see {@link Ext.Component}.</p>
	///     */
	///     Ext.ComponentMgr = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\ComponentMgr.js</jssource>
	public class ComponentMgr : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern ComponentMgr();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static ComponentMgr prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>
		///     The MixedCollection used internally for the component cache. An example usage may be subscribing to
		///     events on the MixedCollection to monitor addition or removal.  Read-only.
		/// </summary>
		public extern static Ext.util.MixedCollection all { get; set; }


		/// <summary>Registers a component.</summary>
		/// <returns></returns>
		public extern static void register();

		/// <summary>Registers a component.</summary>
		/// <param name="c">The component</param>
		/// <returns></returns>
		public extern static void register(Ext.Component c);

		/// <summary>Unregisters a component.</summary>
		/// <returns></returns>
		public extern static void unregister();

		/// <summary>Unregisters a component.</summary>
		/// <param name="c">The component</param>
		/// <returns></returns>
		public extern static void unregister(Ext.Component c);

		/// <summary>Returns a component by id</summary>
		/// <returns>Ext.Component</returns>
		public extern static void get();

		/// <summary>Returns a component by id</summary>
		/// <param name="id">The component id</param>
		/// <returns>Ext.Component</returns>
		public extern static void get(string id);

		/// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
		/// <returns></returns>
		public extern static void onAvailable();

		/// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
		/// <param name="id">The component id</param>
		/// <returns></returns>
		public extern static void onAvailable(string id);

		/// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
		/// <param name="id">The component id</param>
		/// <param name="fn">The callback function</param>
		/// <returns></returns>
		public extern static void onAvailable(string id, Delegate fn);

		/// <summary>Registers a function that will be called when a specified component is added to ComponentMgr</summary>
		/// <param name="id">The component id</param>
		/// <param name="fn">The callback function</param>
		/// <param name="scope">The scope of the callback</param>
		/// <returns></returns>
		public extern static void onAvailable(string id, Delegate fn, object scope);

		/// <summary>
		///     <p>Registers a new Component constructor, keyed by a new
		///     {@link Ext.Component#xtype}.</p>
		///     <p>Use this method to register new subclasses of {@link Ext.Component} so
		///     that lazy instantiation may be used when specifying child Components.
		///     see {@link Ext.Container#items}</p>
		///     may be looked up.
		/// </summary>
		/// <returns></returns>
		public extern static void registerType();

		/// <summary>
		///     <p>Registers a new Component constructor, keyed by a new
		///     {@link Ext.Component#xtype}.</p>
		///     <p>Use this method to register new subclasses of {@link Ext.Component} so
		///     that lazy instantiation may be used when specifying child Components.
		///     see {@link Ext.Container#items}</p>
		///     may be looked up.
		/// </summary>
		/// <param name="xtype">The mnemonic string by which the Component class</param>
		/// <returns></returns>
		public extern static void registerType(string xtype);

		/// <summary>
		///     <p>Registers a new Component constructor, keyed by a new
		///     {@link Ext.Component#xtype}.</p>
		///     <p>Use this method to register new subclasses of {@link Ext.Component} so
		///     that lazy instantiation may be used when specifying child Components.
		///     see {@link Ext.Container#items}</p>
		///     may be looked up.
		/// </summary>
		/// <param name="xtype">The mnemonic string by which the Component class</param>
		/// <param name="cls">The new Component class.</param>
		/// <returns></returns>
		public extern static void registerType(string xtype, Delegate cls);

		/// <summary>
		///     Creates a new Component from the specified config object using the
		///     config object's {@link Ext.component#xtype xtype} to determine the class to instantiate.
		///     the config object does not contain an xtype. (Optional if the config contains an xtype).
		/// </summary>
		/// <returns></returns>
		public extern static Delegate create();

		/// <summary>
		///     Creates a new Component from the specified config object using the
		///     config object's {@link Ext.component#xtype xtype} to determine the class to instantiate.
		///     the config object does not contain an xtype. (Optional if the config contains an xtype).
		/// </summary>
		/// <param name="config">{Object} A configuration object for the Component you wish to create.</param>
		/// <returns></returns>
		public extern static Delegate create(object config);

		/// <summary>
		///     Creates a new Component from the specified config object using the
		///     config object's {@link Ext.component#xtype xtype} to determine the class to instantiate.
		///     the config object does not contain an xtype. (Optional if the config contains an xtype).
		/// </summary>
		/// <param name="config">{Object} A configuration object for the Component you wish to create.</param>
		/// <param name="defaultType">{Constructor} The constructor to provide the default Component type if</param>
		/// <returns></returns>
		public extern static Delegate create(object config, object defaultType);



	}
}
