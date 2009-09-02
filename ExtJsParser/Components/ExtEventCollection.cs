using System;
using System.Collections.Generic;
using System.Text;

namespace SourceConverter.Components
{
    public class ExtEventCollection : List<ExtEvent>
    {
        public string ToExtSharp(string type)
        {
            if (Count == 0) return String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("    public class {0}Events {{", type));
            foreach (ExtEvent ev in this) {
                sb.AppendLine(ev.ToExtSharp());
            }
            sb.AppendLine("    }");
            return sb.ToString();
        }

        public string Delegates(string className) {
            StringBuilder sb = new StringBuilder();
            foreach (ExtEvent ev in this) {
                string evName = ev.Name.ToUpper()[0] + ev.Name.Substring(1);
                sb.AppendLine(String.Format("    public delegate void {0}{1}Delegate({2});", className, evName, ev.Parameters.ToExtSharp()));
            }
            return sb.ToString();
        }
    }
}
