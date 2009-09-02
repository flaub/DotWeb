using System;
using System.Diagnostics;
using System.Text;
using System.Linq;

namespace SourceConverter.Components
{
	[DebuggerVisualizer("{Name}({Parameters})")]
	public class ExtMethod
	{
		public string Name;
		public string Scope;
		public ExtReturn Return;
		public ExtDescription Description;
		public ExtParameterCollection Parameters;

		public ExtMethodCollection SplitByParamTypes() {
			int count;
			string[,] combos = Parameters.SplitByParamTypes(out count);
			ExtMethodCollection emc = new ExtMethodCollection();
			for (int row = 0; row < count; row++) {
				ExtMethod m = new ExtMethod();
				m.Name = Name;
				m.Scope = Scope;
				m.Return = Return;
				m.Description = Description;
				m.Parameters = new ExtParameterCollection();
				for (int i = 0; i < Parameters.Count; i++) {
					m.Parameters.Add(Parameters[i].Dupe(combos[row, i]));
				}
				emc.AddAndSplitParams(m);
			}
			return emc;
		}

		public void ConvertEtcToParamsArg() {
			int paramCount = Parameters.Count;
			int startIndex = 0; // index where the first etc param is
			ExtParameter etc = Parameters[paramCount - 1]; // the etc param should always be the last one

			for (int i = paramCount - 1; i >= 0; i--) {
				// start at the last param counting each param with the same type as the etc param
				if (Parameters[i].Type != etc.Type) {
					startIndex = i + 1;
					break; // stop at the param with a different type
				}
			}

			// remove all etc params
			Parameters.RemoveRange(startIndex, paramCount - startIndex);

			// create etc parameter with the "params" modifier
			ExtParameter p = etc.Dupe();
			p.Usage = "params";
			p.Name = "args";
			Parameters.Add(p);
		}

		public ExtMethodCollection CreateOverloadsWithLessParams() {
			ExtMethodCollection emc = new ExtMethodCollection();

			int paramCount = Parameters.Count;

			for (int i = 0; i <= paramCount; i++) {
				ExtMethod m = new ExtMethod();
				m.Name = Name;
				m.Scope = Scope;
				m.Return = Return;
				m.Description = Description;
				m.Parameters = new ExtParameterCollection();
				for (int j = 0; j < i; j++) {
					m.Parameters.Add(Parameters[j].Dupe());
				}
				emc.Add(m);
			}

			return emc;
		}

		public bool IsTheSameAs(ExtMethod em) {
			if (Name != em.Name) return false;
			if (Parameters.Count != em.Parameters.Count) return false;

			// they have the same number of parameters, check each one's type
			for (int i = 0; i < Parameters.Count; i++) {
				if (Parameters[i].Type != em.Parameters[i].Type) return false;
			}

			return true;
		}

		public string ToExtSharp() {
			StringBuilder sb = new StringBuilder();
			if (SourceConverter.ShowDoc) {
				sb.AppendLine(String.Format("\t\t/// <summary>{0}</summary>", Description.GetDocComment()));
				sb.Append(Parameters.GetDocComments());
				sb.AppendLine(String.Format("\t\t/// <returns>{0}</returns>", Return.Type));
			}
			sb.Append("\t\tpublic ");
			string prefix = "";
			if (Scope == "static") {
				sb.Append("static ");
				prefix = "S";
			}
			else {
				sb.Append("virtual ");
			}

			if (Scope == "static" && Name == "create") {
				Return.TypeName = "Delegate";
			}

			string format;
			if (Return.TypeName == "void") {
				format = "{0} {1}({2}) {{ {3}_({4}); }}";
			}
			else {
				format = "{0} {1}({2}) {{ return {3}_<{0}>({4}); }}";
			}

			string[] names = Parameters.Select(x => x.Name).ToArray();
			sb.Append(string.Format(format,
				Return.TypeName,
				Name,
				Parameters.ToExtSharp(),
				prefix,
				string.Join(", ", names)
			));
			sb.AppendLine();
			return sb.ToString();
		}

		public static void ParseMethod(string member, ref ExtClass ec) {
			/**
			 * Sets this button's click handler
			 * @param {Function} handler The function to call when the button is clicked
			 * @param {Object} scope (optional) Scope for the function passed above
			 */
			string[] data = member.Split(SourceConverter.CRLFA, StringSplitOptions.RemoveEmptyEntries);
			ExtMethod em = new ExtMethod();
			em.Description = new ExtDescription();
			em.Parameters = new ExtParameterCollection();
			em.Return = new ExtReturn();
			for (int i = 1; i < data.Length - 1; i++) {
				string line = data[i];
				if (line.StartsWith("*/")) break;
				if (line.StartsWith("/**")) continue;
				if (line.StartsWith("@ignore")) return;
				if (line.StartsWith("@param")) {
					em.Parameters.Add(ExtParameter.ParseParameter(line));
				}
				else if (line.StartsWith("@return")) {
					em.Return = ExtReturn.ParseReturn(line);
					if (em.Return.Type == "this") em.Return.Type = ec.Name;
				}
				else if (line.StartsWith("@static")) {
					em.Scope = "static";
				}
				else if (line.StartsWith("@method")) {
					em.Name = line.Substring("@method".Length).Trim();
				}
				else if (line.StartsWith("@private") || line.StartsWith("@member")) {
					return; // ignore private methods
				}
				else {
					em.Description.Value += line.Trim() + SourceConverter.CRLF;
				}
			}
			em.Description.Value = em.Description.Value.Trim(SourceConverter.CRLFA);

			if (String.IsNullOrEmpty(em.Name)) {
				string[] lastLine = SourceConverter.ParseLastLine(member);
				if (lastLine.Length > 0) {
					em.Name = lastLine[0].Replace("this.", "").Replace("var", "").Trim();
					em.Name = em.Name.Replace("'", "").Replace("\"", ""); // remove quotes
					if (em.Name.Contains(".")) {
						string[] split = em.Name.Split(".".ToCharArray());
						em.Name = split[split.Length - 1];
					}
				}
				else {
					return; // dont add if we cant parse the name
				}
			}

			if (ExtType.IsStatic(ec, em.Name)) em.Scope = "static";

			if (ExtType.IsKeyword(em.Name)) {
				string fqn = String.Format("{0}.{1}", ec.FullyQualifiedName, em.Name);
				SourceConverter.MethodAliases.Add(fqn, fqn + "_");
				em.Name += "_";
			}
			//            if (em.Name == "*/") return; //JSON.js
			//            if (ec.Name == "SortTypes" && em.Name == "asFloat") return; // script# compiler does not like this method
			//            if (ec.FullyQualifiedName == "Ext.data.Record" && em.Name == "create") {
			//                em.Return.Type = "Delegate"; 
			//            }

			ec.Methods.AddAndSplitParams(em);
		}
	}
}
