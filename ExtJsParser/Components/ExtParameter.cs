using System;

namespace SourceConverter.Components
{
    public class ExtParameter
    {
        public string Type;
        public string Name;
        public string Usage;
        public ExtDescription Description;

        public string ToExtSharp()
        {
            if (Usage == "params") {
                return String.Format("params {0}[] {1}", ExtType.ParseType(Type), Name);
            }
            return String.Format("{0} {1}", ExtType.ParseType(Type), Name);
        }

        public string GetDocComment() {
            return GetDocComment("        ");
        }        
        public string GetDocComment(string pad) {
            return String.Format(pad + "/// <param name=\"{0}\">{1}{2}</param>\r\n", Name, Type.Contains("/") ? " {" + Type + "} " : "", Description.GetDocComment(pad));
        }
        
        public string[] Types {
            get {
                string[] t = Type.Split("/".ToCharArray());
                if (t.Length == 1) return new string[] { ExtType.ParseType(Type) };
                for (int i = 0; i < t.Length; i++) {
                    t[i] = ExtType.ParseType(t[i]);
                }
                return t;
            }
        }

        public ExtParameter Dupe() {
            return Dupe(Type);
        }

        public ExtParameter Dupe(string type) {
            ExtParameter p = new ExtParameter();
            p.Type = type;
            p.Name = Name;
            p.Usage = Usage;
            p.Description = Description;
            return p;
        }
        public static ExtParameter ParseParameter(string member) {
            /**
             * @param {String/HTMLElement/Ext.Element} el The id of or container element
             */
            member = member.Substring("@param".Length).Trim(); // leaving "{String/HTMLElement/Ext.Element} el The id of or container element"
            ExtParameter ep = new ExtParameter();
            ep.Type = "Object";
            ep.Name = "obj";
            ep.Description = new ExtDescription();
            if (member.StartsWith("{")) {
                int i = member.IndexOf("}");
                if (i < 0) i = member.IndexOf(")");
                ep.Type = member.Substring(1, i - 1);
                member = member.Substring(i + 1).Trim(); // leaving "el The id of or container element"
                i = member.IndexOf(" ");
                if (i < 0) {
                    ep.Name = member; // only one word left
                } else {
                    ep.Name = member.Substring(0, i);
                    member = member.Substring(i).Trim(); // leaving "The id of or container element"
                    ep.Description.Value = member;
                }
            } else {
                string[] data = member.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                ep.Type = "Object";
                ep.Name = data.Length > 0 ? data[0] : "obj";

                for (int i = 1; i < data.Length; i++) {
                    if (i > 1) ep.Description.Value += " ";
                    ep.Description.Value += data[i];
                }
            }

            ep.Name = ExtType.ParseParameterName(ep.Name);

            if (ep.Type.Contains("...")) {
                ep.Type = ep.Type.Replace("...", "");
                ep.Name = "etc"; // many args expected
            }
            //            if (ep.Type.Contains("@link ")) ep.Type = ep.Type.Replace("@link ", "");

            return ep;
        }
    }
}
