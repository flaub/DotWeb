using System;
using System.Text;

namespace SourceConverter.Components
{
	public class ExtProperty
	{
		public string Name;
		public string Type;
		public string Scope;
		public string Access;
		public ExtDescription Description;

		public static string Print(string name, string type, string scope, string access, ExtDescription desc) {
			ExtProperty prop = new ExtProperty {
				Name = name,
				Type = type,
				Scope = scope,
				Access = access,
				Description = desc
			};
			return prop.ToExtSharp();
		}

		public string ToExtSharp() {
			StringBuilder sb = new StringBuilder();
			if (SourceConverter.ShowDoc)
				sb.AppendLine(String.Format("\t\t/// <summary>{0}</summary>", Description.GetDocComment()));
			sb.Append("\t\tpublic extern ");
			string prefix = "";
			if (Scope == "static") {
				prefix = "S";
				sb.Append("static ");
			}
			string retType = ExtType.ParseType(Type);
			sb.Append(retType + " " + Name);
			string getter = string.Format("return {0}_<{1}>();", prefix, retType);
			sb.AppendLine(" { get; set; }");
			return sb.ToString();
		}

		public static void ParseProperty(string member, ref ExtClass ec) {
			/**
			 * true if this component has been rendered. Read-only.
			 */
			// rendered : false,
			string[] data = member.Split(SourceConverter.CRLFA, StringSplitOptions.RemoveEmptyEntries);
			ExtProperty ep = new ExtProperty();
			ep.Description = new ExtDescription();
			for (int i = 0; i < data.Length; i++) {
				string line = data[i];
				if (line.StartsWith("/**") && line.EndsWith("*/")) {
					if (line.Contains("@type")) {
						// /** blah blah @type Boolean */
						// isOpera : isOpera,
						line = line.Replace("/**", "").Replace("*/", "").Trim();
						if (line.StartsWith("@type")) {
							ep.Type = line.Replace("@type", "").Trim();
						}
						else {
							int index = line.IndexOf("@type");
							ep.Description.Value += line.Substring(0, index).Trim();
							ep.Type = line.Substring(index + "@type".Length).Trim();
						}
					}
					else {
						// /** The normal browser event */
						// browserEvent : null,
						line = line.Replace("/**", "").Replace("*/", "").Trim();
						ep.Type = "object";
						ep.Description.Value = line;
					}
					break;
				}
				if (line.StartsWith("*/")) break;
				if (line.StartsWith("/**")) continue;
				if (line.StartsWith("@type")) {
					ep.Type = line.Substring("@type".Length).Trim();
					if (ep.Type.IndexOf(" ") > 0) ep.Type = ep.Type.Substring(0, ep.Type.IndexOf(" ")).Trim();
				}
				else if (line.StartsWith("@cfg") && !line.Contains("@hide")) {
					// @cfg {String} emptyText The default text to display in an empty field (defaults to null).
					string[] text = line.Split(" ".ToCharArray());
					if (text.Length > 1) ep.Type = text[1]; // capture {String}
					if (text.Length > 2) ep.Name = text[2]; // capture emptyText
					if (text.Length > 3) {
						// capture "The default text to display in an empty field (defaults to null)."
						for (int j = 3; j < text.Length; j++) {
							ep.Description.Value += text[j] + " ";
						}
						ep.Description.Value = ep.Description.Value.Trim();
					}
				}
				else if (line.StartsWith("@static")) {
					ep.Scope = "static";
				}
				else if (line.StartsWith("@property")) {
					ep.Name = line.Substring("@property".Length).Trim();
					if (ep.Name.Contains(".")) ep.Name = ep.Name.Substring(0, ep.Name.IndexOf(".")).Trim();

					// hack for ColumnModel config property
					//     @property {Array} config
					if (ec.Name == "ColumnModel" && line.EndsWith("config")) {
						ep.Name = "config";
						ep.Type = "Array";
					}
				}
				else if (line.StartsWith("@private") || line.StartsWith("@hide")) {
					return; // ignore private & hidden members
				}
				else if (!line.Contains("@extproperty")) {
					ep.Description.Value += line.Trim() + SourceConverter.CRLF;
				}
			}
			ep.Description.Value = ep.Description.Value.Trim(SourceConverter.CRLFA);

			if (String.IsNullOrEmpty(ep.Name)) {
				string[] lastLine = SourceConverter.ParseLastLine(member);
				if (lastLine.Length > 0) {
					ep.Name = lastLine[0].Replace("this.", "").Replace("var", "").Trim();
					ep.Name = ep.Name.Replace("'", "").Replace("\"", ""); // remove quotes
					if (ep.Name.Contains(".")) {
						string[] split = ep.Name.Split(".".ToCharArray());
						ep.Name = split[split.Length - 1];
					}
				}
				else {
					return; // dont add if we cant parse the name
				}
			}

			ep.Name = ep.Name.Replace("<p>", "");

			if (String.IsNullOrEmpty(ep.Type)) {
				// try to guess the type based on the value on the last line
				string[] lastLine = SourceConverter.ParseLastLine(member);
				if (lastLine.Length > 1) {
					string value = lastLine[1].Trim();
					value.TrimEnd(',');
					ep.Type = "Object";
					if (value == "true" || value == "false") ep.Type = "boolean";
					if (value.IndexOf("\"") >= 0) ep.Type = "String";
					int d;
					if (Int32.TryParse(value, out d)) ep.Type = "int";
				}
			}

			if (ExtType.IsStatic(ec, ep.Name)) ep.Scope = "static";

			if (ExtType.IsKeyword(ep.Name)) {
				string fqn = String.Format("{0}.{1}", ec.FullyQualifiedName, ep.Name);
				SourceConverter.PropertyAliases.Add(fqn, fqn + "_");
				ep.Name += "_";
			}

			// Ext.BasicForm bug
			if (ep.Name == "fileUpload.") ep.Name = "fileUpload";

			ec.Properties.AddProperty(ep);
		}
	}
}
