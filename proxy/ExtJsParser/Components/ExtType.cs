namespace SourceConverter.Components {
    public class ExtType {
        public static string ParseType(string type) {
            type = type.Replace("{", "").Replace("}", "").Replace(":", "");
            if (type.Contains(" ")) type = type.Substring(0, type.IndexOf(" "));
            if (type.Contains("/")) type = "Object";
            if (type.Contains("|")) type = "Object";
            if (type.EndsWith(".")) type = type.TrimEnd('.'); // Ext.Panel

            if (type == "Boolean") type = "bool";  // Ext.tree.TreePanel
            if (type == "Number") type = "double";  // Ext.tree.TreePanel
            if (type == "Node") type = "Ext.data.Node"; // Ext.tree.TreePanel
            if (type == "Tree") type = "Ext.data.Tree"; // Ext.tree.TreePanel
            if (type == "DD") type = "Ext.dd.DD";  // Ext.tree.TreePanel
            if (type == "event") type = "EventObject";  // Ext.tree.TreePanel
            if (type == "TreeSelectionModel") type = "object";  // Ext.tree.TreePanel
            if (type == "HTMLElement") type = "DOMElement";  // Ext.tree.TreePanel
            if (type == "HtmlElement") type = "DOMElement";  // Ext.grid.GridView
            if (type == "RegExp") type = "object"; // Ext.util.MixedCollection
            if (type == "Mixed") type = "object"; // Ext.util.ClickRepeater
            if (type == "SelectionModel") type = "object"; // Ext.grid.CellSelectionModel
            if (type == "boolean") type = "bool"; // Ext.dd.DragDrop
            if (type == "BorderLayoutRegion") type = "LayoutRegion"; // Ext.BorderLayout
            if (type == "Ext.Toolbar") type = "Ext.ToolbarClass"; // Ext.PagingToolbar
            if (type == "Ext.BorderLayout") type = "Ext.BorderLayoutClass"; // Ext.ReaderLayout
            if (type == "Ext.BasicDialog.Button") type = "Ext.Button"; // Ext.BasicDialog
            if (type == "Menu") type = "Ext.menu.Menu"; // Ext.Button
            if (type == "MixedCollection") type = "Ext.util.MixedCollection"; // Ext.ComponenetMgr
            if (type == "Function") type = "Delegate"; // Everywhere :)
            if (type == "Funtction") type = "Delegate"; // Ext.ComponenetMgr
            if (type == "ContainerLayout") type = "Ext.layout.ContainerLayout"; // Ext.Container
            if (type == "Ext.Updater") type = "Ext.UpdaterClass"; // Ext.ContentPanel
			if (type == "Ext.Window") type = "Ext.WindowClass"; // Ext.ReaderLayout
            if (type == "Updater") type = "Ext.UpdaterClass"; // Ext.Updater.BasicRenderer
            if (type == "Toolbar") type = "Ext.ToolbarClass"; // Ext.ContentPanel
            if (type == "Store") type = "Ext.data.Store"; // Ext.DataView
            if (type == "Record") type = "Ext.data.Record"; // Ext.DataView
            if (type == "Ext.data.record") type = "Ext.data.Record"; // Ext.DataView
            if (type == "Float") type = "double"; // Ext.Element
            if (type == "Region") type = "Object"; // Ext.Element
            if (type == "Ext.lib.Region") type = "Object"; // Ext.Element
            if (type == "HTMLelement") type = "DOMElement"; // Ext.EventObject
            if (type == "NodeList") type = "Array"; // Ext
            if (type == "Ext.grid.Grid") type = "object"; // Ext.GridPanel
            if (type == "DomHelper.Template") type = "object"; // Ext.JsonView
            if (type == "Ext.DomHelper.Template") type = "object"; // Ext.View
            if (type == "The") type = "object"; // Ext.SplitBar
            if (type == "Ext.SplitBar") type = "Ext.SplitBarClass"; // Ext.SplitBar
            if (type == "MenuButton") type = "Ext.Button"; // Ext.SplitBar
            if (type == "Ext.ToolbarItem") type = "Ext.Toolbar.Item"; //Toolbar.js
            if (type == "function") type = "Delegate"; // Ext.data.Record
			if (type == "Function") type = "Delegate"; // Ext.data.Record
            if (type == "Constructor") type = "Delegate"; // Ext.ComponentMgr
            if (type == "DataReader") type = "Ext.data.DataReader"; // Ext.form.BasicForm
            if (type == "Ext.data.Reader") type = "Ext.data.DataReader"; // Ext.data.Store
            if (type == "XMLDocument") type = "Object"; // Ext.data.XmlReader
            if (type == "Form") type = "Ext.form.BasicForm"; //Ext.form.BasicForm
            if (type == "Action") type = "Ext.form.ActionClass"; //Ext.form.BasicForm
            if (type == "DataSource") type = "Ext.data.Store"; // Ext.grid.GridPanel
            if (type == "Grid") type = "Ext.grid.GridPanel"; // Ext.grid.GridPanel
            if (type == "Layout") type = "object"; // Ext.layout.BorderLayout.Region
            if (type == "HtmlNode") type = "DOMElement"; // Ext.tree.TreenodeUI
            if (type == "StyleSheet") type = "Object"; // Ext.util.CSS
            if (type == "CSSRule") type = "Object"; // Ext.util.CSS
            if (type == "Ext.util.TextMetrics.Instance") type = "Ext.util.TextMetrics"; // Ext.util.TextMetrics
            if (type == "Class") type = "object"; // Ext.Container
            if (type == "Ext.form.Action") type = "Ext.form.ActionClass"; // Ext.form.Action.Load
            if (type == "Error") type = "object"; // Ext.data.MemoryProxyEvents
			if (type == "Array") type = "System.Array"; //
			if (type == "Date") type = "System.DateTime"; //
			if (type == "Number") type = "System.Number"; //
			if (type == "String") type = "string"; //
            if (type == "Integer") type = "System.Number"; //

            if (type == "Object") type = "object";
            return type;
        }

        public static string ParseClassName(string fqn) {
            if (fqn == "Ext") fqn = "ExtClass";
            if (fqn == "Ext.form.Action") fqn = "ActionClass";
            if (fqn == "Ext.layout.BorderLayout") fqn = "BorderLayoutClass";
            if (fqn == "Ext.SplitBar") fqn = "SplitBarClass";
            if (fqn == "Ext.Toolbar") fqn = "ToolbarClass";
            if (fqn == "Ext.Updater") fqn = "UpdaterClass";
            if (fqn == "Ext.Window") fqn = "WindowClass";

            if (fqn.Contains(".")) fqn = fqn.Substring(fqn.LastIndexOf(".") + 1);

            return fqn;
        }

        public static string ParseParameterName(string name) {
            if (name == "(optional)") name = "value"; // Ext.tree.TreeNodeUI
            if (name == "object") name = "obj"; // Ext.util.Observable
            if (name == "new") name = "newItem"; // Ext.util.MixedCollection
            if (name == "this") name = "objthis"; // Ext.util.ClickRepeater
            if (name == "checked") name = "chckd"; // Ext.tree.TreePanel
            if (name == "true") name = "b"; // Ext.grid.CellSelectionModel
            if (name == "params") name = "prms"; // Ext.data.ScriptTagProxy
            if (name == "string") name = "str"; // Ext.String
            if (name == "char") name = "chr"; // Ext.String
            if (name == "class") name = "cls"; // Ext.Element
            if (name == "namespace") name = "ns"; // Ext.Element
            if (name == "null") name = "nul"; // Ext.Element

            return name;
        }

        public static bool IsKeyword(string word) {
            if (word == "checked") return true;
            if (word == "fixed") return true;
            if (word == "lock") return true;
            if (word == "params") return true;
            if (word == "override") return true;
            if (word == "namespace") return true;
            if (word == "is") return true;
            return false;
        }

        public static string GetReturnValue(string type) {
            type = ParseType(type);
            switch (type) {
                case "":
                    return "";
                case "Boolean":
                    return "false";
                case "bool":
                    return "false";
                case "decimal":
                case "double":
                case "int":
                    return "0";
				case "System.DateTime":
					return "DateTime.MinValue";
            }
            return "null";
        }

        public static bool IsStatic(ExtClass ec, string member) {
            if (ec.Name == "DialogManager") return true;
            if (ec.Name == "EventObject") return false;
            if (ec.Singleton) return true;

            return false;
        }
    }
}