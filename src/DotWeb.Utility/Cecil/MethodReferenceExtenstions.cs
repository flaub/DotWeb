using System;
using Mono.Cecil;
using System.Text;

namespace DotWeb.Utility.Cecil
{
	public static class MethodReferenceExtenstions
	{
		public static string GetMethodSignature(this MethodReference method) {
			int sentinel = method.GetSentinel();

			var sb = new StringBuilder();
			sb.Append(method.ReturnType.ReturnType.FullName);
			sb.Append(" ");
			sb.Append(method.Name);
			sb.Append("(");
			if (method.HasParameters) {
				for (int i = 0; i < method.Parameters.Count; i++) {
					if (i > 0)
						sb.Append(",");

					if (i == sentinel)
						sb.Append("...,");

					sb.Append(method.Parameters[i].ParameterType.FullName);
				}
			}
			sb.Append(")");
			return sb.ToString();
		}

	}
}
