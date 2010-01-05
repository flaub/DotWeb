using System;

namespace SourceConverter.Components
{
	public class ExtReturn
	{
		public string Type;
		public string TypeName;
		public string Description;

		public ExtReturn() {
			Type = Description = String.Empty;
			if (String.IsNullOrEmpty(Type))
				TypeName = "void";
			else
				TypeName = ExtType.ParseType(Type);
		}

		public static ExtReturn ParseReturn(string member) {
			// * @return {Ext.TabPanel} The tabs component
			ExtReturn er = new ExtReturn();
			string[] data = member.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			er.Type = data[1].Replace("{", "").Replace("}", "");
			er.Description = String.Empty;
			for (int i = 2; i < data.Length; i++) {
				if (i > 2) er.Description += " ";
				er.Description += data[i].Trim();
			}
			return er;
		}
	}
}
