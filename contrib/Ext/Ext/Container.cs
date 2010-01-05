using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Base class for any {@link Ext.BoxComponent} that can contain other components. This class is intended
	///     to be extended and should generally not need to be created directly via the new keyword. {@link Ext.Panel},
	///     {@link Ext.Window} and {@link Ext.TabPanel} are the most commonly used Container classes.</p>
	///     Containers handle the basic behavior of containing items, namely adding, inserting and removing them.
	///     The specific layout logic required to visually render contained items is delegated to any one of the different
	///     {@link #layout} classes available.</p>
	///     <p>When either specifying child {@link #items} of a Container, or dynamically adding components to a Container,
	///     remember to consider how you wish the Container to arrange those child elements, and whether those child elements
	///     need to be sized using one of Ext's built-in layout schemes.</p>
	///     <p>By default, Containers use the {@link Ext.layout.ContainerLayout ContainerLayout} scheme. This simply renders
	///     child components, appending them one after the other inside the Container, and does not apply any sizing at all.
	///     This is a common source of confusion when widgets like GridPanels or TreePanels are added to Containers for
	///     which no layout has been specified. If a Container is left to use the ContainerLayout scheme, none of its child
	///     components will be resized, or changed in any way when the Container is resized.</p>
	///     <p>A very common example of this is where a developer will attempt to add a GridPanel to a TabPanel by wrapping
	///     the GridPanel <i>inside</i> a wrapping Panel and add that wrapping Panel to the TabPanel. This misses the point that
	///     Ext's inheritance means that a GridPanel <b>is</b> a Component which can be added unadorned into a Container. If
	///     that wrapping Panel has no layout configuration, then the GridPanel will not be sized as expected.<p>
	///     <p>Below is an example of adding a newly created GridPanel to a TabPanel. A TabPanel uses {@link Ext.layout.CardLayout}
	///     as its layout manager which means all its child items are sized to fit exactly into its client area. The following
	///     code requires prior knowledge of how to create GridPanels. See {@link Ext.grid.GridPanel}, {@link Ext.data.Store}
	///     and {@link Ext.data.JsonReader} as well as the grid examples in the Ext installation's <tt>examples/grid</tt>
	///     directory.</p><pre><code>
	///     //  Create the GridPanel.
	///     myGrid = new Ext.grid.GridPanel({
	///     store: myStore,
	///     columns: myColumnModel,
	///     title: 'Results',
	///     });
	///     myTabPanel.add(myGrid);
	///     myTabPanel.setActiveItem(myGrid);
	///     </code></pre>
	///     */
	///     Ext.Container = Ext.extend(Ext.BoxComponent, {
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Container.js</jssource>
	public class Container : Ext.BoxComponent {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern Container();
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern Container(Ext.Element config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern Container(string config);
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public extern Container(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Container prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The reference to the class that this class inherits from</summary>
		public extern static Ext.BoxComponent superclass { get; set; }

		/// <summary>
		///     The layout type to be used in this container.  If not specified, a default {@link Ext.layout.ContainerLayout}
		///     will be created and used.  Valid values are: absolute, accordion, anchor, border, card, column, fit, form and table.
		///     Specific config values for the chosen layout type can be specified using {@link #layoutConfig}.
		/// </summary>
		public extern string layout { get; set; }

		/// <summary>
		///     This is a config object containing properties specific to the chosen layout (to be used in conjunction with
		///     the {@link #layout} config value).  For complete details regarding the valid config options for each layout
		///     type, see the layout class corresponding to the type specified:<ul class="mdetail-params">
		///     <li>{@link Ext.layout.Absolute}</li>
		///     <li>{@link Ext.layout.Accordion}</li>
		///     <li>{@link Ext.layout.AnchorLayout}</li>
		///     <li>{@link Ext.layout.BorderLayout}</li>
		///     <li>{@link Ext.layout.CardLayout}</li>
		///     <li>{@link Ext.layout.ColumnLayout}</li>
		///     <li>{@link Ext.layout.FitLayout}</li>
		///     <li>{@link Ext.layout.FormLayout}</li>
		///     <li>{@link Ext.layout.TableLayout}</li></ul>
		/// </summary>
		public extern object layoutConfig { get; set; }

		/// <summary>
		///     When set to true (100 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer
		///     the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers
		///     with a large quantity of sub-components for which frequent layout calls would be expensive.
		/// </summary>
		public extern object bufferResize { get; set; }

		/// <summary>
		///     A string component id or the numeric index of the component that should be initially activated within the
		///     container's layout on render.  For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first
		///     item in the container's collection).  activeItem only applies to layout styles that can display
		///     items one at a time (like {@link Ext.layout.Accordion}, {@link Ext.layout.CardLayout} and
		///     {@link Ext.layout.FitLayout}).  Related to {@link Ext.layout.ContainerLayout#activeItem}.
		/// </summary>
		public extern object activeItem { get; set; }

		/// <summary>
		///     A single item, or an array of child Components to be added to this container.
		///     Each item can be any type of object based on {@link Ext.Component}.<br><br>
		///     Component config objects may also be specified in order to avoid the overhead
		///     of constructing a real Component object if lazy rendering might mean that the
		///     added Component will not be rendered immediately. To take advantage of this
		///     "lazy instantiation", set the {@link Ext.Component#xtype} config property to
		///     the registered type of the Component wanted.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     If a single item is being passed, it should be passed directly as an object
		///     reference (e.g., items: {...}).  Multiple items should be passed as an array
		///     of objects (e.g., items: [{...}, {...}]).
		/// </summary>
		public extern object items { get; set; }

		/// <summary>
		///     A config object that will be applied to all components added to this container either via the {@link #items}
		///     config or via the {@link #add} or {@link #insert} methods.  The defaults config can contain any number of
		///     name/value property pairs to be added to each item, and should be valid for the types of items
		///     being added to the container.  For example, to automatically apply padding to the body of each of a set of
		///     contained {@link Ext.Panel} items, you could pass: defaults: {bodyStyle:'padding:15px'}.
		/// </summary>
		public extern object defaults { get; set; }


		/// <summary>
		///     <p>Adds a {@link Ext.Component Component} to this Container. Fires the {@link #beforeadd} event before
		///     adding, then fires the {@link #add} event after the component has been added.</p>
		///     <p>You will never call the render method of a child Component when using a Container.
		///     Child Components are rendered by this Container's {@link #layout} manager when
		///     this Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when add is called, you may need to call
		///     {@link #doLayout} to refresh the view which causes any unrendered child Components
		///     to be rendered. This is required so that you can add multiple child components if needed
		///     while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link #layout} manager. If
		///     you expect child items to be sized in response to user interactions, you must
		///     specify a layout manager which creates and manages the type of layout you have in mind.</p>
		///     <p><b>Omitting the {@link #layout} config means that a basic layout manager is
		///     used which does nothnig but render child components sequentially into the Container.
		///     No sizing or positioning will be performed in this situation.</b></p>
		///     Ext uses lazy rendering, and will only render the added Component should
		///     it become necessary, that is: when the Container is layed out either on first render
		///     or in response to a {@link #doLayout} call.<br><br>
		///     A Component config object may be passed instead of an instantiated Component object.
		///     The type of Component created from a config object is determined by the {@link Ext.Component#xtype xtype}
		///     config property. If no xtype is configured, the Container's {@link #defaultType}
		///     is used.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     added with the Container's default config values applied.
		///     <p>example:</p><pre><code>
		///     var myNewGrid = new Ext.grid.GridPanel({
		///     store: myStore,
		///     colModel: myColModel
		///     });
		///     myTabPanel.add(myNewGrid);
		///     myTabPanel.setActiveTab(myNewGrid);
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.Component</returns>
		public extern virtual void add();

		/// <summary>
		///     <p>Adds a {@link Ext.Component Component} to this Container. Fires the {@link #beforeadd} event before
		///     adding, then fires the {@link #add} event after the component has been added.</p>
		///     <p>You will never call the render method of a child Component when using a Container.
		///     Child Components are rendered by this Container's {@link #layout} manager when
		///     this Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when add is called, you may need to call
		///     {@link #doLayout} to refresh the view which causes any unrendered child Components
		///     to be rendered. This is required so that you can add multiple child components if needed
		///     while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link #layout} manager. If
		///     you expect child items to be sized in response to user interactions, you must
		///     specify a layout manager which creates and manages the type of layout you have in mind.</p>
		///     <p><b>Omitting the {@link #layout} config means that a basic layout manager is
		///     used which does nothnig but render child components sequentially into the Container.
		///     No sizing or positioning will be performed in this situation.</b></p>
		///     Ext uses lazy rendering, and will only render the added Component should
		///     it become necessary, that is: when the Container is layed out either on first render
		///     or in response to a {@link #doLayout} call.<br><br>
		///     A Component config object may be passed instead of an instantiated Component object.
		///     The type of Component created from a config object is determined by the {@link Ext.Component#xtype xtype}
		///     config property. If no xtype is configured, the Container's {@link #defaultType}
		///     is used.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     added with the Container's default config values applied.
		///     <p>example:</p><pre><code>
		///     var myNewGrid = new Ext.grid.GridPanel({
		///     store: myStore,
		///     colModel: myColModel
		///     });
		///     myTabPanel.add(myNewGrid);
		///     myTabPanel.setActiveTab(myNewGrid);
		///     </code></pre>
		/// </summary>
		/// <param name="component">The Component to add.<br><br></param>
		/// <returns>Ext.Component</returns>
		public extern virtual void add(Ext.Component component);

		/// <summary>
		///     <p>Adds a {@link Ext.Component Component} to this Container. Fires the {@link #beforeadd} event before
		///     adding, then fires the {@link #add} event after the component has been added.</p>
		///     <p>You will never call the render method of a child Component when using a Container.
		///     Child Components are rendered by this Container's {@link #layout} manager when
		///     this Container is first rendered.</p>
		///     <p>Certain layout managers allow dynamic addition of child components. Those that do
		///     include {@link Ext.layout.CardLayout}, {@link Ext.layout.AnchorLayout},
		///     {@link Ext.layout.FormLayout}, {@link Ext.layout.TableLayout}.</p>
		///     <p>If the Container is already rendered when add is called, you may need to call
		///     {@link #doLayout} to refresh the view which causes any unrendered child Components
		///     to be rendered. This is required so that you can add multiple child components if needed
		///     while only refreshing the layout once.</p>
		///     <p>When creating complex UIs, it is important to remember that sizing and positioning
		///     of child items is the responsibility of the Container's {@link #layout} manager. If
		///     you expect child items to be sized in response to user interactions, you must
		///     specify a layout manager which creates and manages the type of layout you have in mind.</p>
		///     <p><b>Omitting the {@link #layout} config means that a basic layout manager is
		///     used which does nothnig but render child components sequentially into the Container.
		///     No sizing or positioning will be performed in this situation.</b></p>
		///     Ext uses lazy rendering, and will only render the added Component should
		///     it become necessary, that is: when the Container is layed out either on first render
		///     or in response to a {@link #doLayout} call.<br><br>
		///     A Component config object may be passed instead of an instantiated Component object.
		///     The type of Component created from a config object is determined by the {@link Ext.Component#xtype xtype}
		///     config property. If no xtype is configured, the Container's {@link #defaultType}
		///     is used.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     added with the Container's default config values applied.
		///     <p>example:</p><pre><code>
		///     var myNewGrid = new Ext.grid.GridPanel({
		///     store: myStore,
		///     colModel: myColModel
		///     });
		///     myTabPanel.add(myNewGrid);
		///     myTabPanel.setActiveTab(myNewGrid);
		///     </code></pre>
		/// </summary>
		/// <param name="component">The Component to add.<br><br></param>
		/// <returns>Ext.Component</returns>
		public extern virtual void add(object component);

		/// <summary>
		///     Inserts a Component into this Container at a specified index. Fires the
		///     {@link #beforeadd} event before inserting, then fires the {@link #add} event after the
		///     Component has been inserted.
		///     into the Container's items collection
		///     Ext uses lazy rendering, and will only render the inserted Component should
		///     it become necessary.<br><br>
		///     A Component config object may be passed in order to avoid the overhead of
		///     constructing a real Component object if lazy rendering might mean that the
		///     inserted Component will not be rendered immediately. To take advantage of
		///     this "lazy instantiation", set the {@link Ext.Component#xtype} config
		///     property to the registered type of the Component wanted.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     inserted with the Container's default config values applied.
		/// </summary>
		/// <returns>Ext.Component</returns>
		public extern virtual void insert();

		/// <summary>
		///     Inserts a Component into this Container at a specified index. Fires the
		///     {@link #beforeadd} event before inserting, then fires the {@link #add} event after the
		///     Component has been inserted.
		///     into the Container's items collection
		///     Ext uses lazy rendering, and will only render the inserted Component should
		///     it become necessary.<br><br>
		///     A Component config object may be passed in order to avoid the overhead of
		///     constructing a real Component object if lazy rendering might mean that the
		///     inserted Component will not be rendered immediately. To take advantage of
		///     this "lazy instantiation", set the {@link Ext.Component#xtype} config
		///     property to the registered type of the Component wanted.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     inserted with the Container's default config values applied.
		/// </summary>
		/// <param name="index">The index at which the Component will be inserted</param>
		/// <returns>Ext.Component</returns>
		public extern virtual void insert(double index);

		/// <summary>
		///     Inserts a Component into this Container at a specified index. Fires the
		///     {@link #beforeadd} event before inserting, then fires the {@link #add} event after the
		///     Component has been inserted.
		///     into the Container's items collection
		///     Ext uses lazy rendering, and will only render the inserted Component should
		///     it become necessary.<br><br>
		///     A Component config object may be passed in order to avoid the overhead of
		///     constructing a real Component object if lazy rendering might mean that the
		///     inserted Component will not be rendered immediately. To take advantage of
		///     this "lazy instantiation", set the {@link Ext.Component#xtype} config
		///     property to the registered type of the Component wanted.<br><br>
		///     For a list of all available xtypes, see {@link Ext.Component}.
		///     inserted with the Container's default config values applied.
		/// </summary>
		/// <param name="index">The index at which the Component will be inserted</param>
		/// <param name="component">The child Component to insert.<br><br></param>
		/// <returns>Ext.Component</returns>
		public extern virtual void insert(double index, Ext.Component component);

		/// <summary>
		///     Removes a component from this container.  Fires the {@link #beforeremove} event before removing, then fires
		///     the {@link #remove} event after the component has been removed.
		///     Defaults to the value of this Container's {@link #autoDestroy} config.
		/// </summary>
		/// <returns></returns>
		public extern virtual void remove();

		/// <summary>
		///     Removes a component from this container.  Fires the {@link #beforeremove} event before removing, then fires
		///     the {@link #remove} event after the component has been removed.
		///     Defaults to the value of this Container's {@link #autoDestroy} config.
		/// </summary>
		/// <param name="component">The component reference or id to remove.</param>
		/// <returns></returns>
		public extern virtual void remove(Component component);

		/// <summary>
		///     Removes a component from this container.  Fires the {@link #beforeremove} event before removing, then fires
		///     the {@link #remove} event after the component has been removed.
		///     Defaults to the value of this Container's {@link #autoDestroy} config.
		/// </summary>
		/// <param name="component">The component reference or id to remove.</param>
		/// <param name="autoDestroy">(optional) True to automatically invoke the removed Component's {@link Ext.Component#destroy} function.</param>
		/// <returns></returns>
		public extern virtual void remove(Component component, bool autoDestroy);

		/// <summary>
		///     Removes a component from this container.  Fires the {@link #beforeremove} event before removing, then fires
		///     the {@link #remove} event after the component has been removed.
		///     Defaults to the value of this Container's {@link #autoDestroy} config.
		/// </summary>
		/// <param name="component">The component reference or id to remove.</param>
		/// <returns></returns>
		public extern virtual void remove(string component);

		/// <summary>
		///     Removes a component from this container.  Fires the {@link #beforeremove} event before removing, then fires
		///     the {@link #remove} event after the component has been removed.
		///     Defaults to the value of this Container's {@link #autoDestroy} config.
		/// </summary>
		/// <param name="component">The component reference or id to remove.</param>
		/// <param name="autoDestroy">(optional) True to automatically invoke the removed Component's {@link Ext.Component#destroy} function.</param>
		/// <returns></returns>
		public extern virtual void remove(string component, bool autoDestroy);

		/// <summary>Gets a direct child Component by id, or by index.</summary>
		/// <returns>Ext.Component</returns>
		public extern virtual void getComponent();

		/// <summary>Gets a direct child Component by id, or by index.</summary>
		/// <param name="id">or index of child Component to return.</param>
		/// <returns>Ext.Component</returns>
		public extern virtual void getComponent(string id);

		/// <summary>Gets a direct child Component by id, or by index.</summary>
		/// <param name="id">or index of child Component to return.</param>
		/// <returns>Ext.Component</returns>
		public extern virtual void getComponent(double id);

		/// <summary>
		///     Force this container's layout to be recalculated. A call to this function is required after adding a new component
		///     to an already rendered container, or possibly after changing sizing/position properties of child components.
		///     calc layouts as required (defaults to false, which calls doLayout recursively for each subcontainer)
		/// </summary>
		/// <returns></returns>
		public extern virtual void doLayout();

		/// <summary>
		///     Force this container's layout to be recalculated. A call to this function is required after adding a new component
		///     to an already rendered container, or possibly after changing sizing/position properties of child components.
		///     calc layouts as required (defaults to false, which calls doLayout recursively for each subcontainer)
		/// </summary>
		/// <param name="shallow">(optional) True to only calc the layout of this component, and let child components auto</param>
		/// <returns></returns>
		public extern virtual void doLayout(bool shallow);

		/// <summary>
		///     Returns the layout currently in use by the container.  If the container does not currently have a layout
		///     set, a default {@link Ext.layout.ContainerLayout} will be created and set as the container's layout.
		/// </summary>
		/// <returns>ContainerLayout</returns>
		public extern virtual void getLayout();

		/// <summary>
		///     Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the bubble is stopped.
		/// </summary>
		/// <returns></returns>
		public extern virtual void bubble();

		/// <summary>
		///     Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the bubble is stopped.
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <returns></returns>
		public extern virtual void bubble(Delegate fn);

		/// <summary>
		///     Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the bubble is stopped.
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function (defaults to current node)</param>
		/// <returns></returns>
		public extern virtual void bubble(Delegate fn, object scope);

		/// <summary>
		///     Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the bubble is stopped.
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function (defaults to current node)</param>
		/// <param name="args">(optional) The args to call the function with (default to passing the current component)</param>
		/// <returns></returns>
		public extern virtual void bubble(Delegate fn, object scope, System.Array args);

		/// <summary>
		///     Cascades down the component/container heirarchy from this component (called first), calling the specified function with
		///     each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the cascade is stopped on that branch.
		/// </summary>
		/// <returns></returns>
		public extern virtual void cascade();

		/// <summary>
		///     Cascades down the component/container heirarchy from this component (called first), calling the specified function with
		///     each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the cascade is stopped on that branch.
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <returns></returns>
		public extern virtual void cascade(Delegate fn);

		/// <summary>
		///     Cascades down the component/container heirarchy from this component (called first), calling the specified function with
		///     each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the cascade is stopped on that branch.
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function (defaults to current component)</param>
		/// <returns></returns>
		public extern virtual void cascade(Delegate fn, object scope);

		/// <summary>
		///     Cascades down the component/container heirarchy from this component (called first), calling the specified function with
		///     each component. The scope (<i>this</i>) of
		///     function call will be the scope provided or the current component. The arguments to the function
		///     will be the args provided or the current component. If the function returns false at any point,
		///     the cascade is stopped on that branch.
		/// </summary>
		/// <param name="fn">The function to call</param>
		/// <param name="scope">(optional) The scope of the function (defaults to current component)</param>
		/// <param name="args">(optional) The args to call the function with (defaults to passing the current component)</param>
		/// <returns></returns>
		public extern virtual void cascade(Delegate fn, object scope, System.Array args);

		/// <summary>Find a component under this container at any level by id</summary>
		/// <returns>Ext.Component</returns>
		public extern virtual void findById();

		/// <summary>Find a component under this container at any level by id</summary>
		/// <param name="id"></param>
		/// <returns>Ext.Component</returns>
		public extern virtual void findById(string id);

		/// <summary>Find a component under this container at any level by xtype or class</summary>
		/// <returns>Array</returns>
		public extern virtual void findByType();

		/// <summary>Find a component under this container at any level by xtype or class</summary>
		/// <param name="xtype">The xtype string for a component, or the class of the component directly</param>
		/// <returns>Array</returns>
		public extern virtual void findByType(string xtype);

		/// <summary>Find a component under this container at any level by xtype or class</summary>
		/// <param name="xtype">The xtype string for a component, or the class of the component directly</param>
		/// <returns>Array</returns>
		public extern virtual void findByType(object xtype);

		/// <summary>Find a component under this container at any level by property</summary>
		/// <returns>Array</returns>
		public extern virtual void find();

		/// <summary>Find a component under this container at any level by property</summary>
		/// <param name="prop"></param>
		/// <returns>Array</returns>
		public extern virtual void find(string prop);

		/// <summary>Find a component under this container at any level by property</summary>
		/// <param name="prop"></param>
		/// <param name="value"></param>
		/// <returns>Array</returns>
		public extern virtual void find(string prop, string value);

		/// <summary>
		///     Find a component under this container at any level by a custom function. If the passed function returns
		///     true, the component will be included in the results. The passed function is called with the arguments (component, this container).
		/// </summary>
		/// <returns>Array</returns>
		public extern virtual void findBy();

		/// <summary>
		///     Find a component under this container at any level by a custom function. If the passed function returns
		///     true, the component will be included in the results. The passed function is called with the arguments (component, this container).
		/// </summary>
		/// <param name="fcn"></param>
		/// <returns>Array</returns>
		public extern virtual void findBy(Delegate fcn);

		/// <summary>
		///     Find a component under this container at any level by a custom function. If the passed function returns
		///     true, the component will be included in the results. The passed function is called with the arguments (component, this container).
		/// </summary>
		/// <param name="fcn"></param>
		/// <param name="scope">(optional)</param>
		/// <returns>Array</returns>
		public extern virtual void findBy(Delegate fcn, object scope);



	}

	[JsAnonymous]
	public class ContainerConfig : System.DotWeb.JsDynamic {
		/// <summary> The default type of container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').</summary>
		public string defaultType { get { return (string)this["defaultType"]; } set { this["defaultType"] = value; } }

		/// <summary>  The layout type to be used in this container.  If not specified, a default {@link Ext.layout.ContainerLayout} will be created and used.  Valid values are: absolute, accordion, anchor, border, card, column, fit, form and table. Specific config values for the chosen layout type can be specified using {@link #layoutConfig}.</summary>
		public string layout { get { return (string)this["layout"]; } set { this["layout"] = value; } }

		/// <summary>  This is a config object containing properties specific to the chosen layout (to be used in conjunction with the {@link #layout} config value).  For complete details regarding the valid config options for each layout type, see the layout class corresponding to the type specified:<ul class="mdetail-params"> <li>{@link Ext.layout.Absolute}</li> <li>{@link Ext.layout.Accordion}</li> <li>{@link Ext.layout.AnchorLayout}</li> <li>{@link Ext.layout.BorderLayout}</li> <li>{@link Ext.layout.CardLayout}</li> <li>{@link Ext.layout.ColumnLayout}</li> <li>{@link Ext.layout.FitLayout}</li> <li>{@link Ext.layout.FormLayout}</li> <li>{@link Ext.layout.TableLayout}</li></ul></summary>
		public object layoutConfig { get { return (object)this["layoutConfig"]; } set { this["layoutConfig"] = value; } }

		/// <summary>{Boolean/Number}  When set to true (100 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers with a large quantity of sub-components for which frequent layout calls would be expensive.</summary>
		public object bufferResize { get { return (object)this["bufferResize"]; } set { this["bufferResize"] = value; } }

		/// <summary>{String/Number}  A string component id or the numeric index of the component that should be initially activated within the container's layout on render.  For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection).  activeItem only applies to layout styles that can display items one at a time (like {@link Ext.layout.Accordion}, {@link Ext.layout.CardLayout} and {@link Ext.layout.FitLayout}).  Related to {@link Ext.layout.ContainerLayout#activeItem}.</summary>
		public object activeItem { get { return (object)this["activeItem"]; } set { this["activeItem"] = value; } }

		/// <summary>  A single item, or an array of child Components to be added to this container. Each item can be any type of object based on {@link Ext.Component}.<br><br> Component config objects may also be specified in order to avoid the overhead of constructing a real Component object if lazy rendering might mean that the added Component will not be rendered immediately. To take advantage of this "lazy instantiation", set the {@link Ext.Component#xtype} config property to the registered type of the Component wanted.<br><br> For a list of all available xtypes, see {@link Ext.Component}. If a single item is being passed, it should be passed directly as an object reference (e.g., items: {...}).  Multiple items should be passed as an array of objects (e.g., items: [{...}, {...}]).</summary>
		public object items { get { return (object)this["items"]; } set { this["items"] = value; } }

		/// <summary>  A config object that will be applied to all components added to this container either via the {@link #items} config or via the {@link #add} or {@link #insert} methods.  The defaults config can contain any number of name/value property pairs to be added to each item, and should be valid for the types of items being added to the container.  For example, to automatically apply padding to the body of each of a set of contained {@link Ext.Panel} items, you could pass: defaults: {bodyStyle:'padding:15px'}.</summary>
		public object defaults { get { return (object)this["defaults"]; } set { this["defaults"] = value; } }

		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get { return (double)this["x"]; } set { this["x"] = value; } }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get { return (double)this["y"]; } set { this["y"] = value; } }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get { return (double)this["pageX"]; } set { this["pageX"] = value; } }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get { return (double)this["pageY"]; } set { this["pageY"] = value; } }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get { return (double)this["height"]; } set { this["height"] = value; } }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get { return (double)this["width"]; } set { this["width"] = value; } }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get { return (bool)this["autoHeight"]; } set { this["autoHeight"] = value; } }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get { return (bool)this["autoWidth"]; } set { this["autoWidth"] = value; } }

		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get { return (string)this["xtype"]; } set { this["xtype"] = value; } }

		/// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
		public string id { get { return (string)this["id"]; } set { this["id"] = value; } }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get { return (object)this["autoEl"]; } set { this["autoEl"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public string cls { get { return (string)this["cls"]; } set { this["cls"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public string overCls { get { return (string)this["overCls"]; } set { this["overCls"] = value; } }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public string style { get { return (string)this["style"]; } set { this["style"] = value; } }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public string ctCls { get { return (string)this["ctCls"]; } set { this["ctCls"] = value; } }

		/// <summary>  Render this component disabled (default is false).</summary>
		public bool disabled { get { return (bool)this["disabled"]; } set { this["disabled"] = value; } }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get { return (bool)this["hidden"]; } set { this["hidden"] = value; } }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get { return (object)this["plugins"]; } set { this["plugins"] = value; } }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.  When applyTo is used, constituent parts of the component can also be specified by id or CSS class name within the main element, and the component being created may attempt to create its subcomponents from that markup if applicable. Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the component's container.</summary>
		public object applyTo { get { return (object)this["applyTo"]; } set { this["applyTo"] = value; } }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get { return (object)this["renderTo"]; } set { this["renderTo"] = value; } }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get { return (bool)this["stateful"]; } set { this["stateful"] = value; } }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public string stateId { get { return (string)this["stateId"]; } set { this["stateId"] = value; } }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public string disabledClass { get { return (string)this["disabledClass"]; } set { this["disabledClass"] = value; } }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get { return (bool)this["allowDomMove"]; } set { this["allowDomMove"] = value; } }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get { return (bool)this["autoShow"]; } set { this["autoShow"] = value; } }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public string hideMode { get { return (string)this["hideMode"]; } set { this["hideMode"] = value; } }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get { return (bool)this["hideParent"]; } set { this["hideParent"] = value; } }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get { return (object)this["listeners"]; } set { this["listeners"] = value; } }

	}

    public class ContainerEvents {
        /// <summary>Fires when the components in this container are arranged by the associated layout manager.
        /// <pre><code>
        /// USAGE: ({Ext.Container} objthis, {ContainerLayout} layout)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>layout</b></term><description>The ContainerLayout implementation for this container</description></item>
        /// </list>
        /// </summary>
        public static string afterlayout { get { return "afterlayout"; } }
        /// <summary>
        ///     Fires before any {@link Ext.Component} is added or inserted into the container.
        ///     A handler can return false to cancel the add.
        /// 
        /// <pre><code>
        /// USAGE: ({Ext.Container} objthis, {Ext.Component} component, {Number} index)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>component</b></term><description>The component being added</description></item>
        /// <item><term><b>index</b></term><description>The index at which the component will be added to the container's items collection</description></item>
        /// </list>
        /// </summary>
        public static string beforeadd { get { return "beforeadd"; } }
        /// <summary>
        ///     Fires before any {@link Ext.Component} is removed from the container.  A handler can return
        ///     false to cancel the remove.
        /// 
        /// <pre><code>
        /// USAGE: ({Ext.Container} objthis, {Ext.Component} component)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>component</b></term><description>The component being removed</description></item>
        /// </list>
        /// </summary>
        public static string beforeremove { get { return "beforeremove"; } }
        /// <summary>Fires after any {@link Ext.Component} is added or inserted into the container.
        /// <pre><code>
        /// USAGE: ({Ext.Container} objthis, {Ext.Component} component, {Number} index)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>component</b></term><description>The component that was added</description></item>
        /// <item><term><b>index</b></term><description>The index at which the component was added to the container's items collection</description></item>
        /// </list>
        /// </summary>
        public static string add { get { return "add"; } }
        /// <summary>Fires after any {@link Ext.Component} is removed from the container.
        /// <pre><code>
        /// USAGE: ({Ext.Container} objthis, {Ext.Component} component)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>objthis</b></term><description></description></item>
        /// <item><term><b>component</b></term><description>The component that was removed</description></item>
        /// </list>
        /// </summary>
        public static string remove { get { return "remove"; } }
    }

    public delegate void ContainerAfterlayoutDelegate(Ext.Container objthis, Ext.layout.ContainerLayout layout);
    public delegate void ContainerBeforeaddDelegate(Ext.Container objthis, Ext.Component component, double index);
    public delegate void ContainerBeforeremoveDelegate(Ext.Container objthis, Ext.Component component);
    public delegate void ContainerAddDelegate(Ext.Container objthis, Ext.Component component, double index);
    public delegate void ContainerRemoveDelegate(Ext.Container objthis, Ext.Component component);
}
