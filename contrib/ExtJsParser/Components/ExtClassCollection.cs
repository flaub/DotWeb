using System.Collections.Generic;

namespace SourceConverter.Components {
    public class ExtClassCollection : List<ExtClass> {
        
        public ExtClass FindClass(string type) {
            if (string.IsNullOrEmpty(type)) return null;

            string ns = string.Empty;
            string cls;
            if (type.Contains(".")) {
                ns = type.Substring(0, type.LastIndexOf("."));
                cls = type.Substring(type.LastIndexOf(".") + 1);
            } else {
                cls = type;
            }

            foreach (ExtClass ec in this) {
                if (ec.Name != cls) continue;

                if (!string.IsNullOrEmpty(ns)) {
                    if (ec.Namespace != ns) continue;
                }

                return ec;
            }
            return null;
        }
    }
}