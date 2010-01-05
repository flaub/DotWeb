using System;
using System.Collections.Generic;
using System.Text;

namespace SourceConverter.Components {
    public class ExtMethodCollection : List<ExtMethod> {
        public string ToExtSharp() {
            StringBuilder sb = new StringBuilder();
            foreach (ExtMethod em in this) {
                sb.AppendLine(em.ToExtSharp());
            }
            return sb.ToString();
        }

        public void AddAndSplitParams(ExtMethod m) {
            if (m.Parameters.HasParamWithManyTypes) {
                AddRangeAndSplitParams(m.SplitByParamTypes());
            } else if (m.Parameters.HasEtcParam) {
                m.ConvertEtcToParamsArg();
                AddMethod(m);
            } else {
                AddMethod(m);
            }
        }

        public void AddMethod(ExtMethod m) {
            if (!ContainsMethod(m)) Add(m);
        }

        public void AddRangeAndSplitParams(ExtMethodCollection emc) {
            foreach (ExtMethod method in emc) {
                AddAndSplitParams(method);
            }
        }

        public ExtMethodCollection CreateOverloads() {
            ExtMethodCollection methods = new ExtMethodCollection();
            foreach (ExtMethod em in this) {
                ExtMethodCollection overloads = em.CreateOverloadsWithLessParams();
                foreach (ExtMethod ov in overloads) {
                    if (!methods.ContainsMethod(ov)) methods.Add(ov);
                }
            }
            return methods;
        }

        public bool ContainsMethod(ExtMethod em) {
            foreach (ExtMethod method in this) {
                if (em.IsTheSameAs(method)) return true;
            }
            return false;
        }
    }
}
