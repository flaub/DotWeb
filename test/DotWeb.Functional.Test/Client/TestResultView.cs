﻿using System;
using DotWeb.Client;
using DotWeb.Client.Dom.Html;
using DotWeb.Client.Dom.Helper;
using System.DotWeb;

namespace DotWeb.Functional.Test.Client
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

		public void AddRow(string name, string expected, string actual, bool success) {
			var row = ElementFactory.CreateTableRow();
			AddCell(row, name);
			AddCell(row, expected);
			AddCell(row, actual);
			if (success) {
				row.bgColor = "green";
			}
			else {
				row.bgColor = "red";
			}
			this.table.tBodies[0].appendChild(row);
		}
	}
}
