using System;
using System.Collections.Generic;
using System.Text;

namespace SourceConverter.Components
{
	public class ExtConfigCollection : List<ExtConfig>
	{
		public string ToExtSharp(ExtClass ec) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("\t[JsAnonymous]");
			sb.AppendFormat("\tpublic class {0}Config : System.DotWeb.JsDynamic {{", ec.Name);
			sb.AppendLine();
			foreach (ExtConfig ev in this) {
				sb.AppendLine(ev.ToExtSharp(ec.Name + "Config"));
			}
			sb.AppendLine("\t}");
			return sb.ToString();
		}

		public new void Add(ExtConfig ec) {
			if (ec.Name == "cm" && ec.Type == "{Store}") return; // incorrect documentation in GridPanel
			bool found = false;
			ForEach(delegate(ExtConfig c) { if (c.Name == ec.Name) found = true; });
			if (!found) base.Add(ec);
		}

		public void CopyBaseConfigs(ExtClass ec, ExtClassCollection classes) {
			ExtClass baseClass = classes.FindClass(ec.SuperClass);
			if (baseClass != null) {
				baseClass.Configs.CopyBaseConfigs(baseClass, classes);
				foreach (ExtConfig config in baseClass.Configs) {
					Add(config.Dupe());
				}
			}
		}
	}
}
