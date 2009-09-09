using System;
using DotWeb.Client;

namespace Ext.grid {
	/// <summary>
	///     /**
	///     Class for creating and editable grid.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\grid\EditorGrid.js</jssource>
	public class EditorGridPanel : Ext.grid.GridPanel {

		/// <summary></summary>
		/// <returns></returns>
		public EditorGridPanel() { C_(); }
		/// <summary></summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public EditorGridPanel(object config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public EditorGridPanel(Ext.Element config) { C_(config); }
		/// <summary></summary>
		/// <param name="config">The configuration options.</param>
		/// <returns></returns>
		public EditorGridPanel(System.String config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static EditorGridPanel prototype { get { return S_<EditorGridPanel>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>The reference to the class that this class inherits from</summary>
		public static Ext.grid.GridPanel superclass { get { return S_<Ext.grid.GridPanel>(); } set { S_(value); } }

		/// <summary>The number of clicks on a cell required to display the cell's editor (defaults to 2)</summary>
		public double clicksToEdit { get { return _<double>(); } set { _(value); } }

		/// <summary>True to automatically HTML encode and decode values pre and post edit (defaults to false)</summary>
		public bool autoEncode { get { return _<bool>(); } set { _(value); } }

		/// <summary>Any subclass of AbstractSelectionModel that will provide the selection model forthe grid (defaults to {@link Ext.grid.CellSelectionModel} if not specified).</summary>
		public object selModel { get { return _<object>(); } set { _(value); } }


		/// <summary>Starts editing the specified for the specified row/column</summary>
		/// <returns></returns>
		public virtual void startEditing() { _(); }

		/// <summary>Starts editing the specified for the specified row/column</summary>
		/// <param name="rowIndex"></param>
		/// <returns></returns>
		public virtual void startEditing(double rowIndex) { _(rowIndex); }

		/// <summary>Starts editing the specified for the specified row/column</summary>
		/// <param name="rowIndex"></param>
		/// <param name="colIndex"></param>
		/// <returns></returns>
		public virtual void startEditing(double rowIndex, double colIndex) { _(rowIndex, colIndex); }

		/// <summary>Stops any active editing</summary>
		/// <returns></returns>
		public virtual void stopEditing() { _(); }

		/// <summary>Stops any active editing</summary>
		/// <param name="cancel">(optional) True to cancel any changes</param>
		/// <returns></returns>
		public virtual void stopEditing(bool cancel) { _(cancel); }



	}

	[JsAnonymous]
	public class EditorGridPanelConfig : DotWeb.Client.JsAccessible {
		/// <summary>  The number of clicks on a cell required to display the cell's editor (defaults to 2)</summary>
		public double clicksToEdit { get; set; }

		/// <summary>  True to automatically HTML encode and decode values pre and post edit (defaults to false)</summary>
		public bool autoEncode { get; set; }

		/// <summary> Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to {@link Ext.grid.CellSelectionModel} if not specified).</summary>
		public object selModel { get; set; }

		/// <summary> The {@link Ext.data.Store} the grid should use as its data source (required).</summary>
		public Ext.data.Store store { get; set; }

		/// <summary> Shorthand for {@link #colModel}.</summary>
		public object cm { get; set; }

		/// <summary> The {@link Ext.grid.ColumnModel} to use when rendering the grid (required).</summary>
		public object colModel { get; set; }

		/// <summary> Shorthand for {@link #selModel}.</summary>
		public object sm { get; set; }

		/// <summary> An array of columns to auto create a ColumnModel</summary>
		public System.Array columns { get; set; }

		/// <summary> Sets the maximum height of the grid - ignored if autoHeight is not on.</summary>
		public double maxHeight { get; set; }

		/// <summary> True to disable selections in the grid (defaults to false). - ignored if a SelectionModel is specified</summary>
		public bool disableSelection { get; set; }

		/// <summary> False to turn off column reordering via drag drop (defaults to true).</summary>
		public bool enableColumnMove { get; set; }

		/// <summary> False to turn off column resizing for the whole grid (defaults to true).</summary>
		public bool enableColumnResize { get; set; }

		/// <summary> A config object that will be applied to the grid's UI view.  Any of the config options available for {@link Ext.grid.GridView} can be specified here.</summary>
		public object viewConfig { get; set; }

		/// <summary> True to hide the grid's header (defaults to false).</summary>
		public bool hideHeaders { get; set; }

		/// <summary> The minimum width a column can be resized to. Defaults to 25.</summary>
		public double minColumnWidth { get; set; }

		/// <summary> True to highlight rows when the mouse is over. Default is true.</summary>
		public bool trackMouseOver { get; set; }

		/// <summary> True to enable dragging of the selected rows of the GridPanel.</p> <p>Setting this to <b><tt>true</tt></b> causes this GridPanel's {@link #getView GridView} to create an instance of {@link Ext.grid.GridDragZone}. This is available <b>(only after the Grid has been rendered)</b> as the GridView's {@link Ext.grid.GridView#dragZone dragZone} property.</p> <p>A cooperating {@link Ext.dd.DropZone DropZone} must be created who's implementations of {@link Ext.dd.DropZone#onNodeEnter onNodeEnter}, {@link Ext.dd.DropZone#onNodeOver onNodeOver}, {@link Ext.dd.DropZone#onNodeOut onNodeOut} and {@link Ext.dd.DropZone#onNodeDrop onNodeDrop}</p> are able to process the {@link Ext.grid.GridDragZone#getDragData data} which is provided.</summary>
		public bool enableDragDrop { get; set; }

		/// <summary> True to enable hiding of columns with the header context menu.</summary>
		public bool enableColumnHide { get; set; }

		/// <summary> True to enable the drop down button for menu in the headers.</summary>
		public bool enableHdMenu { get; set; }

		/// <summary> True to stripe the rows. Default is false.</summary>
		public bool stripeRows { get; set; }

		/// <summary> The id of a column in this grid that should expand to fill unused space. This id can not be 0.</summary>
		public System.String autoExpandColumn { get; set; }

		/// <summary> The minimum width the autoExpandColumn can have (if enabled). defaults to 50.</summary>
		public double autoExpandMin { get; set; }

		/// <summary> The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.</summary>
		public double autoExpandMax { get; set; }

		/// <summary> The {@link Ext.grid.GridView} used by the grid. This can be set before a call to render().</summary>
		public object view { get; set; }

		/// <summary> An {@link Ext.LoadMask} config or true to mask the grid while loading (defaults to false).</summary>
		public object loadMask { get; set; }

		/// <summary> True to enable deferred row rendering. Default is true.</summary>
		public bool deferRowRender { get; set; }

		/// <summary>  The id of the node, a DOM node or an existing Element corresponding to a DIV that is already present in the document that specifies some panel-specific structural markup.  When applyTo is used, constituent parts of the panel can be specified by CSS class name within the main element, and the panel will automatically create those components from that markup. Any required components not specified in the markup will be autogenerated if necessary. The following class names are supported (baseCls will be replaced by {@link #baseCls}): <ul><li>baseCls + '-header'</li> <li>baseCls + '-header-text'</li> <li>baseCls + '-bwrap'</li> <li>baseCls + '-tbar'</li> <li>baseCls + '-body'</li> <li>baseCls + '-bbar'</li> <li>baseCls + '-footer'</li></ul> Using this config, a call to render() is not required.  If applyTo is specified, any value passed for {@link #renderTo} will be ignored and the target element's parent node will automatically be used as the panel's container.</summary>
		public object applyTo { get; set; }

		/// <summary>{Object/Array}  The top toolbar of the panel. This can be a {@link Ext.Toolbar} object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.  Note that this is not available as a property after render. To access the top toolbar after render, use {@link #getTopToolbar}.</summary>
		public object tbar { get; set; }

		/// <summary>{Object/Array}  The bottom toolbar of the panel. This can be a {@link Ext.Toolbar} object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.  Note that this is not available as a property after render. To access the bottom toolbar after render, use {@link #getBottomToolbar}.</summary>
		public object bbar { get; set; }

		/// <summary>  True to create the header element explicitly, false to skip creating it.  By default, when header is not specified, if a {@link #title} is set the header will be created automatically, otherwise it will not.  If a title is set but header is explicitly set to false, the header will not be rendered.</summary>
		public bool header { get; set; }

		/// <summary>  True to create the footer element explicitly, false to skip creating it.  By default, when footer is not specified, if one or more buttons have been added to the panel the footer will be created automatically, otherwise it will not.</summary>
		public bool footer { get; set; }

		/// <summary>  The title text to display in the panel header (defaults to '').  When a title is specified the header element will automatically be created and displayed unless {@link #header} is explicitly set to false.  If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the container element will get created.</summary>
		public System.String title { get; set; }

		/// <summary>  An array of {@link Ext.Button}s or {@link Ext.Button} configs used to add buttons to the footer of this panel.</summary>
		public System.Array buttons { get; set; }

		/// <summary>{Object/String/Function}  A valid url spec according to the Updater {@link Ext.Updater#update} method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render.<p> The URL will become the default URL for this panel's {@link #body} element, so it may be {@link Ext.Element#refresh refresh}ed at any time.</p></summary>
		public object autoLoad { get; set; }

		/// <summary>  True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to false).</summary>
		public bool frame { get; set; }

		/// <summary>  True to display the borders of the panel's body element, false to hide them (defaults to true).  By default, the border is a 2px wide inset border, but this can be further altered by setting {@link #bodyBorder} to false.</summary>
		public bool border { get; set; }

		/// <summary>  True to display an interior border on the body element of the panel, false to hide it (defaults to true). This only applies when {@link #border} == true.  If border == true and bodyBorder == false, the border will display as a 1px wide inset border, giving the entire body element an inset appearance.</summary>
		public bool bodyBorder { get; set; }

		/// <summary>{String/Object/Function}  Custom CSS styles to be applied to the body element in the format expected by {@link Ext.Element#applyStyles} (defaults to null).</summary>
		public object bodyStyle { get; set; }

		/// <summary>  A CSS class that will provide a background image to be used as the header icon (defaults to '').  An example custom icon class would be something like: .my-icon { background: url(../images/my-icon.gif) 0 6px no-repeat !important;}</summary>
		public System.String iconCls { get; set; }

		/// <summary>  True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).</summary>
		public bool collapsible { get; set; }

		/// <summary>  An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an {@link Ext.Element Element} referenced by a public property called <tt><b></b>tools.<i>&lt;tool-type&gt;</i></tt> <p>Each tool config may contain the following properties: <div class="mdetail-params"><ul> <li><b>id</b> : String<div class="sub-desc"><b>Required.</b> The type of tool to create. Values may be<ul> <li><tt>toggle</tt> (Created by default when {@link #collapsible} is <tt>true</tt>)</li> <li><tt>close</tt></li> <li><tt>minimize</tt></li> <li><tt>maximize</tt></li> <li><tt>restore</tt></li> <li><tt>gear</tt></li> <li><tt>pin</tt></li> <li><tt>unpin</tt></li> <li><tt>right</tt></li> <li><tt>left</tt></li> <li><tt>up</tt></li> <li><tt>down</tt></li> <li><tt>refresh</tt></li> <li><tt>minus</tt></li> <li><tt>plus</tt></li> <li><tt>help</tt></li> <li><tt>search</tt></li> <li><tt>save</tt></li> <li><tt>print</tt></li> </ul></div></li> <li><b>handler</b> : Function<div class="sub-desc"><b>Required.</b> The function to call when clicked. Arguments passed are:<ul> <li><b>event</b> : Ext.EventObject<div class="sub-desc">The click event.</div></li> <li><b>toolEl</b> : Ext.Element<div class="sub-desc">The tool Element.</div></li> <li><b>Panel</b> : Ext.Panel<div class="sub-desc">The host Panel</div></li> </ul></div></li> <li><b>scope</b> : Object<div class="sub-desc">The scope in which to call the handler.</div></li> <li><b>qtip</b> : String/Object<div class="sub-desc">A tip string, or a config argument to {@link Ext.QuickTip#register}</div></li> <li><b>hidden</b> : Boolean<div class="sub-desc">True to initially render hidden.</div></li> <li><b>on</b> : Object<div class="sub-desc">A listener config object specifiying event listeners in the format of an argument to {@link #addListener}</div></li> </ul></div> Example usage: <pre><code> tools:[{ id:'refresh', qtip: 'Refresh form Data', // hidden:true, handler: function(event, toolEl, panel){ // refresh logic } }] </code></pre> Note that apart from the toggle tool which is provided when a panel is collapsible, these tools only provide the visual button. Any required functionality must be provided by adding handlers that implement the necessary behavior.</summary>
		public System.Array tools { get; set; }

		/// <summary>  True to hide the expand/collapse toggle button when {@link #collapsible} = true, false to display it (defaults to false).</summary>
		public bool hideCollapseTool { get; set; }

		/// <summary>  True to allow expanding and collapsing the panel (when {@link #collapsible} = true) by clicking anywhere in the header bar, false to allow it only by clicking to tool button (defaults to false).</summary>
		public bool titleCollapse { get; set; }

		/// <summary>  True to use overflow:'auto' on the panel's body element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).</summary>
		public bool autoScroll { get; set; }

		/// <summary>  True to float the panel (absolute position it with automatic shimming and shadow), false to display it inline where it is rendered (defaults to false).  Note that by default, setting floating to true will cause the panel to display at negative offsets so that it is hidden -- because the panel is absolute positioned, the position must be set explicitly after render (e.g., myPanel.setPosition(100,100);).  Also, when floating a panel you should always assign a fixed width, otherwise it will be auto width and will expand to fill to the right edge of the viewport.</summary>
		public bool floating { get; set; }

		/// <summary>{Boolean/String}  True (or a valid Ext.Shadow {@link Ext.Shadow#mode} value) to display a shadow behind the panel, false to display no shadow (defaults to 'sides').  Note that this option only applies when floating = true.</summary>
		public object shadow { get; set; }

		/// <summary>  The number of pixels to offset the shadow if displayed (defaults to 4). Note that this option only applies when floating = true.</summary>
		public double shadowOffset { get; set; }

		/// <summary>  False to disable the iframe shim in browsers which need one (defaults to true).  Note that this option only applies when floating = true.</summary>
		public bool shim { get; set; }

		/// <summary>{String/Object}  An HTML fragment, or a {@link Ext.DomHelper DomHelper} specification to use as the panel's body content (defaults to '').</summary>
		public object html { get; set; }

		/// <summary>  The id of an existing HTML node to use as the panel's body content (defaults to '').</summary>
		public System.String contentEl { get; set; }

		/// <summary>{Object/Array}  A KeyMap config object (in the format expected by {@link Ext.KeyMap#addBinding} used to assign custom key handling to this panel (defaults to null).</summary>
		public object keys { get; set; }

		/// <summary>  <p>True to enable dragging of this Panel (defaults to false).</p> <p>For custom drag/drop implementations, an Ext.Panel.DD config could also be passed in this config instead of true. Ext.Panel.DD is an internal, undocumented class which moves a proxy Element around in place of the Panel's element, but provides no other behaviour during dragging or on drop. It is a subclass of {@link Ext.dd.DragSource}, so behaviour may be added by implementing the interface methods of {@link Ext.dd.DragDrop} eg: <pre><code> new Ext.Panel({ title: 'Drag me', x: 100, y: 100, renderTo: Ext.getBody(), floating: true, frame: true, width: 400, height: 200, draggable: { //      Config option of Ext.Panel.DD class. //      It's a floating Panel, so do not show a placeholder proxy in the original position. insertProxy: false, //      Called for each mousemove event while dragging the DD object. onDrag : function(e){ //          Record the x,y position of the drag proxy so that we can //          position the Panel at end of drag. var pel = this.proxy.getEl(); this.x = pel.getLeft(true); this.y = pel.getTop(true); //          Keep the Shadow aligned if there is one. var s = this.panel.getEl().shadow; if (s) { s.realign(this.x, this.y, pel.getWidth(), pel.getHeight()); } }, //      Called on the mouseup event. endDrag : function(e){ this.panel.setPosition(this.x, this.y); } } }).show(); </code></pre></summary>
		public bool draggable { get; set; }

		/// <summary>  Adds a tooltip when mousing over the tab of a Ext.Panel which is an item of a Ext.TabPanel. Ext.QuickTips.init() must be called in order for the tips to render.</summary>
		public System.String tabTip { get; set; }

		/// <summary>  Render this panel disabled (default is false). An important note when using the disabled config on panels is that IE will often fail to initialize the disabled mask element correectly if the panel's layout has not yet completed by the time the Panel is disabled during the render process. If you experience this issue, you may need to instead use the {@link afterlayout} event to initialize the disabled state: <pre><code> new Ext.Panel({ ... listeners: { 'afterlayout': { fn: function(p){ p.disable(); }, single: true // important, as many layouts can occur } } }); </code></pre></summary>
		public bool disabled { get; set; }

		/// <summary>  The base CSS class to apply to this panel's element (defaults to 'x-panel').</summary>
		public System.String baseCls { get; set; }

		/// <summary>  A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').</summary>
		public System.String collapsedCls { get; set; }

		/// <summary>  True to mask the panel when it is disabled, false to not mask it (defaults to true).  Either way, the panel will always tell its contained elements to disable themselves when it is disabled, but masking the panel can provide an additional visual cue that the panel is disabled.</summary>
		public bool maskDisabled { get; set; }

		/// <summary>  True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the {@link Ext.Fx} class is available, otherwise false).</summary>
		public bool animCollapse { get; set; }

		/// <summary>  True to display the panel title in the header, false to hide it (defaults to true).</summary>
		public bool headerAsText { get; set; }

		/// <summary>  The alignment of any buttons added to this panel.  Valid values are 'right,' 'left' and 'center' (defaults to 'right').</summary>
		public System.String buttonAlign { get; set; }

		/// <summary>  True to render the panel collapsed, false to render it expanded (defaults to false).</summary>
		public bool collapsed { get; set; }

		/// <summary>  True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).</summary>
		public bool collapseFirst { get; set; }

		/// <summary>  Minimum width in pixels of all buttons in this panel (defaults to 75)</summary>
		public double minButtonWidth { get; set; }

		/// <summary>  A comma-delimited list of panel elements to initialize when the panel is rendered.  Normally, this list will be generated automatically based on the items added to the panel at config time, but sometimes it might be useful to make sure a structural element is rendered even if not specified at config time (for example, you may want to add a button or toolbar dynamically after the panel has been rendered).  Adding those elements to this list will allocate the required placeholders in the panel when it is rendered.  Valid values are<ul> <li><b>header</b></li> <li><b>tbar</b> (top bar)</li> <li><b>body</b> (required)</li> <li><b>bbar</b> (bottom bar)</li> <li><b>footer</b><li> </ul> Defaults to 'body'.</summary>
		public System.String elements { get; set; }

		/// <summary> The default type of container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').</summary>
		public string defaultType { get; set; }

		/// <summary>  The layout type to be used in this container.  If not specified, a default {@link Ext.layout.ContainerLayout} will be created and used.  Valid values are: absolute, accordion, anchor, border, card, column, fit, form and table. Specific config values for the chosen layout type can be specified using {@link #layoutConfig}.</summary>
		public System.String layout { get; set; }

		/// <summary>  This is a config object containing properties specific to the chosen layout (to be used in conjunction with the {@link #layout} config value).  For complete details regarding the valid config options for each layout type, see the layout class corresponding to the type specified:<ul class="mdetail-params"> <li>{@link Ext.layout.Absolute}</li> <li>{@link Ext.layout.Accordion}</li> <li>{@link Ext.layout.AnchorLayout}</li> <li>{@link Ext.layout.BorderLayout}</li> <li>{@link Ext.layout.CardLayout}</li> <li>{@link Ext.layout.ColumnLayout}</li> <li>{@link Ext.layout.FitLayout}</li> <li>{@link Ext.layout.FormLayout}</li> <li>{@link Ext.layout.TableLayout}</li></ul></summary>
		public object layoutConfig { get; set; }

		/// <summary>{Boolean/Number}  When set to true (100 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers with a large quantity of sub-components for which frequent layout calls would be expensive.</summary>
		public object bufferResize { get; set; }

		/// <summary>{String/Number}  A string component id or the numeric index of the component that should be initially activated within the container's layout on render.  For example, activeItem: 'item-1' or activeItem: 0 (index 0 = the first item in the container's collection).  activeItem only applies to layout styles that can display items one at a time (like {@link Ext.layout.Accordion}, {@link Ext.layout.CardLayout} and {@link Ext.layout.FitLayout}).  Related to {@link Ext.layout.ContainerLayout#activeItem}.</summary>
		public object activeItem { get; set; }

		/// <summary>  A single item, or an array of child Components to be added to this container. Each item can be any type of object based on {@link Ext.Component}.<br><br> Component config objects may also be specified in order to avoid the overhead of constructing a real Component object if lazy rendering might mean that the added Component will not be rendered immediately. To take advantage of this "lazy instantiation", set the {@link Ext.Component#xtype} config property to the registered type of the Component wanted.<br><br> For a list of all available xtypes, see {@link Ext.Component}. If a single item is being passed, it should be passed directly as an object reference (e.g., items: {...}).  Multiple items should be passed as an array of objects (e.g., items: [{...}, {...}]).</summary>
		public object items { get; set; }

		/// <summary>  A config object that will be applied to all components added to this container either via the {@link #items} config or via the {@link #add} or {@link #insert} methods.  The defaults config can contain any number of name/value property pairs to be added to each item, and should be valid for the types of items being added to the container.  For example, to automatically apply padding to the body of each of a set of contained {@link Ext.Panel} items, you could pass: defaults: {bodyStyle:'padding:15px'}.</summary>
		public object defaults { get; set; }

		/// <summary>  The local x (left) coordinate for this component if contained within a positioning container.</summary>
		public double x { get; set; }

		/// <summary>  The local y (top) coordinate for this component if contained within a positioning container.</summary>
		public double y { get; set; }

		/// <summary>  The page level x coordinate for this component if contained within a positioning container.</summary>
		public double pageX { get; set; }

		/// <summary>  The page level y coordinate for this component if contained within a positioning container.</summary>
		public double pageY { get; set; }

		/// <summary>  The height of this component in pixels (defaults to auto).</summary>
		public double height { get; set; }

		/// <summary>  The width of this component in pixels (defaults to auto).</summary>
		public double width { get; set; }

		/// <summary>  True to use height:'auto', false to use fixed height. Note: although many components inherit this config option, not all will function as expected with a height of 'auto'. (defaults to false).</summary>
		public bool autoHeight { get; set; }

		/// <summary>  True to use width:'auto', false to use fixed width. Note: although many components inherit this config option, not all will function as expected with a width of 'auto'. (defaults to false).</summary>
		public bool autoWidth { get; set; }

		/// <summary> 
		///     The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
		///     The predefined xtypes are listed at the top of this document.
		///     If you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering.
		/// </summary>
		public string xtype { get; set; }

		/// <summary>  The unique id of this component (defaults to an auto-assigned id).</summary>
		public System.String id { get; set; }

		/// <summary>{String/Object}  A tag name or DomHelper spec to create an element with. This is intended to create shorthand utility components inline via JSON. It should not be used for higher level components which already create their own elements. Example usage: <pre><code> {xtype:'box', autoEl: 'div', cls:'my-class'} {xtype:'box', autoEl: {tag:'blockquote', html:'autoEl is cool!'}} // with DomHelper </code></pre></summary>
		public object autoEl { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's Element (defaults to '').  This can be useful for adding customized styles to the component or any of its children using standard CSS rules.</summary>
		public System.String cls { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').  This can be useful for adding customized "active" or "hover" styles to the component or any of its children using standard CSS rules.</summary>
		public System.String overCls { get; set; }

		/// <summary>  A custom style specification to be applied to this component's Element.  Should be a valid argument to {@link Ext.Element#applyStyles}.</summary>
		public System.String style { get; set; }

		/// <summary>  An optional extra CSS class that will be added to this component's container (defaults to '').  This can be useful for adding customized styles to the container or any of its children using standard CSS rules.</summary>
		public System.String ctCls { get; set; }

		/// <summary>  Render this component hidden (default is false).</summary>
		public bool hidden { get; set; }

		/// <summary>{Object/Array}  An object or array of objects that will provide custom functionality for this component.  The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself.  Each plugin can then call methods or respond to events on the component as needed to provide its functionality.</summary>
		public object plugins { get; set; }

		/// <summary>  The id of the node, a DOM node or an existing Element that will be the container to render this component into. Using this config, a call to render() is not required.</summary>
		public object renderTo { get; set; }

		/// <summary>  A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.<p> For state saving to work, the state manager's provider must have been set to an implementation of {@link Ext.state.Provider} which overrides the {@link Ext.state.Provider#set set} and {@link Ext.state.Provider#get get} methods to save and recall name/value pairs. A built-in implementation, {@link Ext.state.CookieProvider} is available.</p> <p>To set the state provider for the current page:</p> <pre><code> Ext.state.Manager.setProvider(new Ext.state.CookieProvider()); </code></pre> <p>Components attempt to save state when one of the events listed in the {@link #stateEvents} configuration fires.</p> <p>You can perform extra processing on state save and restore by attaching handlers to the {@link #beforestaterestore}, {@link staterestore}, {@link beforestatesave} and {@link statesave} events</p></summary>
		public bool stateful { get; set; }

		/// <summary>  The unique id for this component to use for state management purposes (defaults to the component id). <p>See {@link #stateful} for an explanation of saving and restoring Component state.</p></summary>
		public System.String stateId { get; set; }

		/// <summary>  CSS class added to the component when it is disabled (defaults to "x-item-disabled").</summary>
		public System.String disabledClass { get; set; }

		/// <summary>  Whether the component can move the Dom node when rendering (defaults to true).</summary>
		public bool allowDomMove { get; set; }

		/// <summary>  True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).</summary>
		public bool autoShow { get; set; }

		/// <summary>  How this component should hidden. Supported values are "visibility" (css visibility), "offsets" (negative offset position) and "display" (css display) - defaults to "display".</summary>
		public System.String hideMode { get; set; }

		/// <summary>  True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).  For example, this can be used as a shortcut for a hide button on a window by setting hide:true on the button when adding it to its parent container.</summary>
		public bool hideParent { get; set; }

		/// <summary> A config object containing one or more event handlers to be added to this object during initialization.  This should be a valid listeners config object as specified in the {@link #addListener} example for attaching multiple handlers at once.</summary>
		public object listeners { get; set; }

	}

    public class EditorGridPanelEvents {
        /// <summary>
        ///     Fires before cell editing is triggered. The edit event object has the following properties <br />
        ///     <ul style="padding:5px;padding-left:16px;">
        ///     <li>grid - This grid</li>
        ///     <li>record - The record being edited</li>
        ///     <li>field - The field name being edited</li>
        ///     <li>value - The value for the field being edited.</li>
        ///     <li>row - The grid row index</li>
        ///     <li>column - The grid column index</li>
        ///     <li>cancel - Set this to true to cancel the edit or return false from your handler.</li>
        ///     </ul>
        /// 
        /// <pre><code>
        /// USAGE: ({Object} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>e</b></term><description>An edit event (see above for description)</description></item>
        /// </list>
        /// </summary>
        public static string beforeedit { get { return "beforeedit"; } }
        /// <summary>
        ///     Fires after a cell is edited. <br />
        ///     <ul style="padding:5px;padding-left:16px;">
        ///     <li>grid - This grid</li>
        ///     <li>record - The record being edited</li>
        ///     <li>field - The field name being edited</li>
        ///     <li>value - The value being set</li>
        ///     <li>originalValue - The original value for the field, before the edit.</li>
        ///     <li>row - The grid row index</li>
        ///     <li>column - The grid column index</li>
        ///     </ul>
        /// 
        /// <pre><code>
        /// USAGE: ({Object} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>e</b></term><description>An edit event (see above for description)</description></item>
        /// </list>
        /// </summary>
        public static string afteredit { get { return "afteredit"; } }
        /// <summary>
        ///     Fires after a cell is edited, but before the value is set in the record. Return false
        ///     to cancel the change. The edit event object has the following properties <br />
        ///     <ul style="padding:5px;padding-left:16px;">
        ///     <li>grid - This grid</li>
        ///     <li>record - The record being edited</li>
        ///     <li>field - The field name being edited</li>
        ///     <li>value - The value being set</li>
        ///     <li>originalValue - The original value for the field, before the edit.</li>
        ///     <li>row - The grid row index</li>
        ///     <li>column - The grid column index</li>
        ///     <li>cancel - Set this to true to cancel the edit or return false from your handler.</li>
        ///     </ul>
        /// 
        /// <pre><code>
        /// USAGE: ({Object} e)
        /// </code></pre>
        /// <list type="bullet">
        /// <item><term><b>e</b></term><description>An edit event (see above for description)</description></item>
        /// </list>
        /// </summary>
        public static string validateedit { get { return "validateedit"; } }
    }

    public delegate void EditorGridPanelBeforeeditDelegate(object e);
    public delegate void EditorGridPanelAftereditDelegate(object e);
    public delegate void EditorGridPanelValidateeditDelegate(object e);
}
