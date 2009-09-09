using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ext.grid;
using Ext.data;

namespace Ext
{
	public class Test
	{
		private JsonStore store;
//		private GridPanel grid;

		public Test() {
			this.store = new JsonStore(new JsonStoreConfig {
				url = "url"
			});
		}
	}
}
