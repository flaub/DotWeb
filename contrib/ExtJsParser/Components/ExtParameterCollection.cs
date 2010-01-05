using System;
using System.Collections.Generic;
using System.Text;

namespace SourceConverter.Components
{
    public class ExtParameterCollection : List<ExtParameter>
    {
        public string ToExtSharp()
        {
            string o = String.Empty;
            for (int i = 0; i < Count; i++)
            {
                if (i > 0) o += ", ";
                o += this[i].ToExtSharp();
            }
            return o;
        }

        public string GetDocComments() {
            return GetDocComments("\t\t");
        }

        public string GetDocComments(string pad) {
            StringBuilder sb = new StringBuilder();
            foreach (ExtParameter ep in this) {
                sb.Append(ep.GetDocComment(pad));
            }
            return sb.ToString();
        }

        public new void Add(ExtParameter p) {
            List<string> names = new List<string>();
            foreach (ExtParameter ep in this)
            {
                names.Add(ep.Name);
            }
            if (names.Contains(p.Name)) p.Name += "2";
            base.Add(p);
        }

        public bool HasParamWithManyTypes {
            get {
                foreach (ExtParameter parameter in this) {
                    if (parameter.Type.Contains("/")) {
                        return true;
                    }
                }
                return false;
            }
        }

        public string[,] SplitByParamTypes(out int count) {
            count = 0;
            string[,] combos = new string[5, this.Count];

            // loop thru each parameter
            for (int i = 0; i < this.Count; i++) {
                ExtParameter p = this[i];
                if (i == 0) {
                    // if this is the first param, just put each of the types
                    for (int j = 0; j < p.Types.Length; j++) {
                        combos[j, i] = p.Types[j];
                    }
                    count = p.Types.Length;
                } else {
                    if (p.Types.Length == 1) {
                        // the next param has one type
                        for (int j = 0; j < count; j++) {
                            combos[j, i] = p.Type;
                        }
                    } else {
                        // the next param has multiple types
                        // duplicate previous params for each type
                        combos = Expand(combos, this.Count, count, p.Types, i);
                        count = count * p.Types.Length;
                    }
                }
            }
            return combos;
        }

        private string[,] Expand(string[,] combos, int paramCount, int endOfData, string[] types, int curCol) {
            int newLength = endOfData * types.Length;
            string[,] array = new string[newLength, paramCount];

            for (int set = 0; set < types.Length; set++) {
                for (int row = 0; row < endOfData; row++) {
                    int destRow = set * endOfData + row;
                    for (int col = 0; col < paramCount; col++) {
                        array[destRow, col] = combos[row, col];
                        if (col == curCol) {
                            array[destRow, col] = types[set];
                        }
                    }
                }
            }

            return array;
        }

        public bool HasEtcParam {
            get {
                foreach (ExtParameter parameter in this) {
                    if (parameter.Name.ToLower().StartsWith("etc") ||
                        parameter.Description.Value.ToLower().StartsWith("etc")) {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
