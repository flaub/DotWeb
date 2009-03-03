using System;
using System.Text;
using System.Diagnostics;

namespace SourceConverter.Components
{
    [DebuggerDisplay("{Value}")]
    public class ExtDescription
    {
        public string Value;
        public bool IsSingleLine { get { return !Value.Contains(Environment.NewLine); } }
        
        public ExtDescription() {
            Value = String.Empty;
        }
        public ExtDescription(string val)
        {
            Value = val;
        }
        
        public string GetDocComment() {
            return GetDocComment("\t\t");
        }
        
        public string GetDocComment(string pad) {
            if (!Value.Contains("\n")) {
                return Value;
            } else {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                foreach (string l in Value.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)) {
                    if (!String.IsNullOrEmpty(l.Trim())) sb.AppendLine(pad + "///     " + l.Trim());
                }
                sb.Append(pad + "/// ");
                return sb.ToString();
            }
        }
    }
}
