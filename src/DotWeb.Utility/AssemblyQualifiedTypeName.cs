using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Utility
{
	[Serializable]
	public class AssemblyQualifiedTypeName
	{
		public AssemblyQualifiedTypeName(string asmQualifiedTypeName) {
			var firstComma = asmQualifiedTypeName.IndexOf(",");
			this.TypeName = asmQualifiedTypeName.Substring(0, firstComma);
			var remain = asmQualifiedTypeName.Substring(firstComma + 1).TrimStart();
			this.AssemblyName = new AssemblyName(remain);
		}

		public AssemblyName AssemblyName { get; private set; }
		public string TypeName { get; private set; }
	}
}
