// Copyright 2010, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Mono.Cecil;
using System.Text;
using System.Linq;

namespace DotWeb.Utility.Cecil
{
	public static class MethodReferenceExtenstions
	{
		private static string GetMethodSignature(MethodReference method, bool prependTypeName) {
			int sentinel = method.GetSentinel();

			var sb = new StringBuilder();
			sb.Append(method.ReturnType.ReturnType.FullName);
			sb.Append(" ");
			if (prependTypeName) {
				sb.Append(method.DeclaringType.FullName);
				sb.Append(".");
			}
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

		public static string GetMethodSignature(this MethodReference method) {
			return GetMethodSignature(method, false);
		}

		public static string GetMethodSignatureWithTypeName(this MethodReference method) {
			return GetMethodSignature(method, true);
		}
	}
}
