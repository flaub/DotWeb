using System.Collections.Generic;
using System.Text;

namespace SourceConverter.Components {
    public class ExtConstructorCollection : List<ExtConstructor> {
        public bool HasDefaultConstructor {
            get {
                foreach (ExtConstructor ec in this) {
                    if (ec.Parameters.Count == 0) return true;
                }
                return false;
            }
        }

        public void AddDefault(ExtClass ecc) {
            ExtConstructor ec = new ExtConstructor();
            ec.Name = ecc.Name;
            ec.Class = ecc;
            ec.Description = new ExtDescription("Auto-generated default constructor");
            ec.Parameters = new ExtParameterCollection();
            Insert(0, ec);
        }

        public void AddBaseOverloads(ExtClass ec, ExtClassCollection classes) {
            ExtClass baseClass = classes.FindClass(ec.SuperClass);
            if (baseClass != null) {
                baseClass.Constructors.AddBaseOverloads(baseClass, classes);
                foreach (ExtConstructor ctor in baseClass.Constructors) {
                    ExtConstructor newCtor = ctor.Dupe(ec);
                    if (!ContainsConstructor(newCtor)) Add(newCtor);
                }
            }
        }

        public ExtConstructorCollection CreateOverloads() {
            ExtConstructorCollection ctors = new ExtConstructorCollection();
            foreach (ExtConstructor ec in this) {
                ExtConstructorCollection overloads = ec.CreateOverloadsWithLessParams();
                foreach (ExtConstructor ov in overloads) {
                    if (!ctors.ContainsConstructor(ov)) ctors.Add(ov);
                }
            }
            return ctors;
        }

        public bool ContainsConstructor(ExtConstructor ec) {
            foreach (ExtConstructor ctor in this) {
                if (ec.IsTheSameAs(ctor)) return true;
            }
            return false;
        }

        public string ToExtSharp() {
            StringBuilder sb = new StringBuilder();
            foreach (ExtConstructor ctor in this) {
                sb.Append(ctor.ToExtSharp());
            }
            return sb.ToString();
        }
    }
}
