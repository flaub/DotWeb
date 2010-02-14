using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;
using DotWeb.Client.Dom.Html;
using DotWeb.Client.Dom.Helper;

namespace DotWeb.Weaver.Test.Script
{
	class TestResultView : JsScript
	{
		private HtmlTableElement table;
		private HtmlElement container;

		public TestResultView(HtmlElement container) {
			this.container = container;
			this.table = ElementFactory.CreateTable();
			this.table.id = "dotweb-unit";
			this.table.innerHTML =
				"<thead><tr><th>Test Name</th><th>Expected</th><th>Actual</th></tr></thead><tbody></tbody>";
			this.container.appendChild(this.table);
		}

		private HtmlTableCellElement AddCell(HtmlTableRowElement row, string text) {
			var cell = ElementFactory.CreateTableCell();
			cell.textContent = text;
			row.appendChild(cell);
			return cell;
		}

		public void AddRow(string name, object expected, object actual) {
			var row = ElementFactory.CreateTableRow();
			var str1 = expected.ToString();
			var str2 = actual.ToString();
			AddCell(row, name);
			AddCell(row, str1);
			AddCell(row, str2);
			if (str1 == str2) {
				row.bgColor = "green";
			}
			else {
				row.bgColor = "red";
			}
			this.table.tBodies[0].appendChild(row);
		}
	}

	class Misc_ListTest : JsScript
	{
		public Misc_ListTest() {
			var sandbox = Document.getElementById("sandbox");
			var view = new TestResultView(sandbox);

			//Log.Write("List test starting");

			var list = new List<string>();
			//list.Add("one");
			//list.Add("two");
			//list.Add("three");

			//view.AddRow("list.ToString()", "[ one,two,three ]", list);

			//view.AddRow("list.IndexOf('one')", 0, list.IndexOf("one"));
			//view.AddRow("list.IndexOf('two')", 1, list.IndexOf("two"));
			//view.AddRow("list.IndexOf('three')", 2, list.IndexOf("three"));
			//view.AddRow("list.IndexOf('none')", -1, list.IndexOf("none"));

			//list.Add("two");
			//view.AddRow("list.Add('two')", "[ one,two,three,two ]", list);

			//list.Remove("two");
			//view.AddRow("list.Remove('two')", "[ one,three,two ]", list);
		}
	}
}
