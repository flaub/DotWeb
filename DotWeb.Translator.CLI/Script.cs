using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Client;
using Ext;
using Ext.grid;
using Ext.data;

namespace H8.CLI
{
	public class IndexScript
	{
		private int id = NextId();
		private GridPanel grid;

		private static int counter = 0;
		private static int NextId() {
			return counter++;
		}

		[JsAnonymous]
		class Schema
		{
			public string name;
			public string type;
		}

		[JsAnonymous]
		class MyRecord
		{
			public int id;
			public string value;
		}

		public IndexScript() {
			Console.WriteLine("IndexScript()");

			Delegate record = null; Record.create(new Schema[] {
				new Schema { name = "id", type = "int" },
				new Schema { name = "value" }
			});

			JsonReader reader = new JsonReader(new JsonReaderConfig {
				id = "id"
			}, record);
			Console.WriteLine(reader);

			Store store = new Store(new StoreConfig {
				reader = reader
			});

			var data = new MyRecord[] {
				new MyRecord { id = 1, value = "first" },
				new MyRecord { id = 2, value = "second" }
			};
			Console.WriteLine(data);
			store.loadData(data);

			ColumnModelConfig[] columns = new ColumnModelConfig[] {
				new ColumnModelConfig {
					dataIndex = "id", header = "ID"
				},
				new ColumnModelConfig {
					dataIndex = "value", header = "Value"
				}
			};

			this.grid = new GridPanel(new GridPanelConfig {
				height = 150,
				renderTo = "grid",
				colModel = new ColumnModel(columns),
				store = store
			});
			Console.WriteLine(this.grid);

			this.grid.on("dblclick", new GridPanelDblclickDelegate(this.OnDblClick), this);
		}

		private void OnDblClick(Ext.EventObject e) {
			Console.WriteLine("DblClick");
			Console.WriteLine(e);
			Console.WriteLine(this);
		}
	}
}
