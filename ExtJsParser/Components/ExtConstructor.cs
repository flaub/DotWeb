using System;
using System.Text;
using System.Linq;

namespace SourceConverter.Components
{
	public class ExtConstructor
	{
		public ExtDescription Description;
		public ExtParameterCollection Parameters;
		public string Name;
		public ExtClass Class;

		public string ToExtSharp() {
			StringBuilder sb = new StringBuilder();
			if (SourceConverter.ShowDoc) {
				sb.AppendLine(String.Format("\t\t/// <summary>{0}</summary>", Description.GetDocComment()));
				sb.Append(Parameters.GetDocComments());
				sb.AppendLine("\t\t/// <returns></returns>");
			}
			string[] names = Parameters.Select(x => x.Name).ToArray();
			sb.AppendLine(String.Format("\t\tpublic {0}({1}) {{ C_({2}); }}",
				ExtType.ParseClassName(Class.FullyQualifiedName),
				Parameters.ToExtSharp(),
				string.Join(", ", names)
			));
			return sb.ToString();
		}

		public ExtConstructorCollection SplitByParams() {
			int count;
			string[,] combos = Parameters.SplitByParamTypes(out count);
			ExtConstructorCollection ecc = new ExtConstructorCollection();
			for (int row = 0; row < count; row++) {
				ExtConstructor ec = new ExtConstructor();
				ec.Name = Name;
				ec.Class = Class;
				ec.Description = Description;
				ec.Parameters = new ExtParameterCollection();
				for (int i = 0; i < Parameters.Count; i++) {
					ec.Parameters.Add(Parameters[i].Dupe(combos[row, i]));
				}
				ecc.Add(ec);
			}
			return ecc;
		}

		public ExtConstructorCollection CreateOverloadsWithLessParams() {
			ExtConstructorCollection ecc = new ExtConstructorCollection();

			int paramCount = Parameters.Count;

			for (int i = 0; i <= paramCount; i++) {
				ExtConstructor ec = new ExtConstructor();
				ec.Name = Name;
				ec.Class = Class;
				ec.Description = Description;
				ec.Parameters = new ExtParameterCollection();
				for (int j = 0; j < i; j++) {
					ec.Parameters.Add(Parameters[j].Dupe());
				}
				ecc.Add(ec);
			}

			return ecc;
		}

		public bool IsTheSameAs(ExtConstructor ec) {
			if (Name != ec.Name) return false;
			if (Parameters.Count != ec.Parameters.Count) return false;

			// they have the same number of parameters, check each one's type
			for (int i = 0; i < Parameters.Count; i++) {
				string curType = ExtType.ParseType(Parameters[i].Type);
				string otherType = ExtType.ParseType(ec.Parameters[i].Type);
				if (curType != otherType) return false;
			}

			return true;
		}

		public ExtConstructor Dupe() {
			return Dupe(Class);
		}

		public ExtConstructor Dupe(ExtClass ec) {
			ExtConstructor ctor = new ExtConstructor();
			ctor.Name = ec.Name;
			ctor.Class = ec;
			ctor.Description = Description;
			ctor.Parameters = new ExtParameterCollection();
			for (int j = 0; j < Parameters.Count; j++) {
				ctor.Parameters.Add(Parameters[j].Dupe());
			}
			return ctor;
		}

		public static void ParseConstructor(string member, ref ExtClass ec) {
			/**
			 * @constructor
			 * Blah Blah Blah
			 * @param {String/HTMLElement/Ext.Element} el The id of or container element
			 * @param {Object} config configuration options
			 */
			ExtConstructor ctor = new ExtConstructor();
			ctor.Name = ec.Name;
			ctor.Class = ec;
			ctor.Description = new ExtDescription();
			ctor.Parameters = new ExtParameterCollection();
			string[] data = member.Split(SourceConverter.CRLFA, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < data.Length; i++) {
				if (data[i].StartsWith("*/")) break;
				if (data[i].StartsWith("@param")) {
					ctor.Parameters.Add(ExtParameter.ParseParameter(data[i]));
				}
				else {
					ctor.Description.Value += data[i] + SourceConverter.CRLF;
				}
			}
			ctor.Description.Value = ctor.Description.Value.Trim(SourceConverter.CRLFA);

			if (ctor.Parameters.HasParamWithManyTypes) {
				ec.Constructors.AddRange(ctor.SplitByParams());
			}
			else {
				ec.Constructors.Add(ctor);
			}
		}
	}
}
