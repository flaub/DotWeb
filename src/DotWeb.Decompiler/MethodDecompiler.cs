// Copyright 2009, Frank Laub
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
using DotWeb.Decompiler.CodeModel;
using System.Reflection;
using DotWeb.Decompiler.Core;
using Mono.Cecil;
using DotWeb.Utility;
using DotWeb.Utility.Cecil;

namespace DotWeb.Decompiler
{
	public static class MethodDecompiler
	{
		public static CodeMethodMember Parse(TypeSystem typeHierarchy, MethodDefinition method) {
			var cfg = new ControlFlowGraph(typeHierarchy, method);
#if DEBUG
			Console.WriteLine(method);
			Console.WriteLine(cfg);
#endif

			var cfa = new ControlFlowAnalyzer(cfg);
			cfa.Structure();

			var be = new BackEnd(cfg);
			be.WriteCode();

			var ap = method.GetMonoAssociatedProperty();
			if (ap != null) {
				if (ap.IsGetter) {
					return new CodePropertyGetterMember(be.Method) {
						Property = ap.Definition
					};
				}

				return new CodePropertySetterMember(be.Method) {
					Property = ap.Definition
				};
			}

			return be.Method;
		}
	}
}
