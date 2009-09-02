using System.Collections.Generic;
using System.Text;

namespace SourceConverter.Components {
    public class ExtPropertyCollection : List<ExtProperty> {
        public string ToExtSharp() {
            StringBuilder sb = new StringBuilder();
            foreach (ExtProperty ep in this) {
                sb.AppendLine(ep.ToExtSharp());
            }
            return sb.ToString();
        }

        public bool ContainsProperty(ExtProperty p) {
            bool found = false;
            ForEach(delegate(ExtProperty prop) { if (p.Name == prop.Name) found = true; });
            return found;
        }

        public void AddProperty(ExtProperty p) {
            if (!ContainsProperty(p)) Add(p);
        }
    }
}
