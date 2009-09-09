using System;
using System.Text;

namespace SourceConverter.Components
{
    public class ExtEvent
    {
        public string Name;
        public ExtDescription Description;
        public ExtParameterCollection Parameters;

        public string ToExtSharp()
        {
            StringBuilder sb = new StringBuilder();
            if (SourceConverter.ShowDoc) {
                sb.AppendLine(String.Format("        /// <summary>{0}", Description.GetDocComment("        ")));
                sb.AppendLine("        /// <pre><code>");
                sb.Append("        /// USAGE: (");
                for (int i = 0; i < Parameters.Count; i++)
                {
                    ExtParameter p = Parameters[i];
                    sb.Append(String.Format("{{{0}}} {1}", p.Type, p.Name));
                    if (i < Parameters.Count - 1) sb.Append(", ");
                }
                sb.AppendLine(")");
                sb.AppendLine("        /// </code></pre>");
                sb.AppendLine("        /// <list type=\"bullet\">");
                foreach (ExtParameter p in Parameters)
                {
                    sb.AppendLine(String.Format("        /// <item><term><b>{0}</b></term><description>{1}</description></item>", p.Name, p.Description.Value));
                }
                sb.AppendLine("        /// </list>");
                sb.AppendLine("        /// </summary>");
            }
            sb.Append(String.Format("        public static string {0} {{ get {{ return \"{0}\"; }} }}",Name));
            return sb.ToString();
        }

        public static void ParseEvent(string member, ref ExtClass ec) {
            /**
             * @event arrowclick
             * Fires when this button's arrow is clicked
             * @param {SplitButton} this
             * @param {EventObject} e The click event
             */
            ExtEvent ev = new ExtEvent();
            ev.Description = new ExtDescription();
            ev.Parameters = new ExtParameterCollection();
            string[] data = member.Split(SourceConverter.CRLFA, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in data) {
                if (line.StartsWith("*/")) break;
                if (line.StartsWith("/**")) continue;
                if (line.StartsWith("@event")) {
                    ev.Name = line.Substring("@event ".Length).Trim();
                } else if (line.StartsWith("@param")) {
                    ev.Parameters.Add(ExtParameter.ParseParameter(line));
                } else if (line.StartsWith("@hide")) {
                    return;
                } else {
                    ev.Description.Value += line + SourceConverter.CRLF;
                }
            }
            ev.Description.Value = ev.Description.Value.Trim(SourceConverter.CRLFA);
            ec.Events.Add(ev);
        }
    }
}