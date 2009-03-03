
// *********************************************
//      ExtSharp Adapter/Compatability Script
// *********************************************

// **** renamed classes ****
Ext.ExtClass = Ext;
Ext.UpdaterClass = Ext.Updater;
Ext.SplitBarClass = Ext.SplitBar;
Ext.ToolbarClass = Ext.Toolbar;
Ext.WindowClass = Ext.Window;
Ext.form.ActionClass = Ext.form.Action;
Ext.layout.BorderLayoutClass = Ext.layout.BorderLayout;

// **** renamed methods ****
Ext.DomQuery.is_ = Ext.DomQuery.is;
Ext.Element.is_ = Ext.Element.is;
Ext.override_ = Ext.override;
Ext.namespace_ = Ext.namespace;
Ext.dd.DragDrop.lock_ = Ext.dd.DragDrop.lock;
Ext.dd.DragDropMgr.lock_ = Ext.dd.DragDropMgr.lock;
Ext.grid.AbstractSelectionModel.lock_ = Ext.grid.AbstractSelectionModel.lock;

// **** renamed properties ****
Ext.form.Action.params_ = Ext.form.Action.params;
Ext.form.Checkbox.checked_ = Ext.form.Checkbox.checked;
Ext.grid.ColumnModel.fixed_ = Ext.grid.ColumnModel.fixed;
Ext.menu.CheckItem.checked_ = Ext.menu.CheckItem.checked;
