
// *********************************************
//      ExtSharp Adapter/Compatability Script
// *********************************************

// **** renamed classes ****
ExtClass = Ext;
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

// changes Script#'s inheritance to use Ext.extend()
// backup the existing createClass function
Type.prototype._createClass = Type.prototype.createClass;
Type.prototype.createClass = function(n,b,i) {
    // if a base type is defined then use Ext.extend()
    if(b) {
        var ct=b.prototype.ctype;
        var sp = typeof b.superclass != 'undefined';
        // if the base type is an ExtJS class
        if(sp || (ct && ct.substring(0,3)=='Ext')) {
            // stop Script# from copying members
            delete this.__basePrototypePending;
            // ugly, I know, but i don't know any other way to accoplish this
            eval(n+' = Ext.extend(b, this.prototype);');
            this._createClass(n);
            return;
        }
    }
    this._createClass(n,b,i);
}


// **** bug fixes ****

// Script# overwrites the String.replace() method with a different implementation
// that replaces all occurences of the text to search for instead of just the 
// first occurrence. This behavior breaks the Ext DomQuery class. Luckily Script#
//  stores a backup of the original method, so I'll just revert the change back
//  - sscorlib.debug.js, line #564
String.prototype.replace = String.prototype._replace;
