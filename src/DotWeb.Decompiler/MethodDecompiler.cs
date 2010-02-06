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
		public static CodeMethodMember Parse(TypeSystem typeSystem, MethodDefinition method) {
#if DEBUG
			Console.WriteLine(method);
#endif

			var builder = new ControlFlowGraphBuilder(method);
			var graph = builder.CreateGraph();

#if DEBUG
			graph.PrintDot(method.Name);
#endif

			var interpreter = new Interpreter(typeSystem, method);
			graph.DepthFirstTraversal((Node node) => {
				// Accumulate statements into node.Statements
				interpreter.ProcessBlock((BasicBlock)node);
			});

			graph.Structure();

			var generator = new StatementsGenerator(method, graph);
			var ret = generator.WriteMethodBody();
			ret.ExternalMethods = interpreter.ExternalMethods;

			var ap = method.GetMonoAssociatedProperty();
			if (ap != null) {
				if (ap.IsGetter) {
					return new CodePropertyGetterMember(ret) {
						Property = ap.Definition
					};
				}

				return new CodePropertySetterMember(ret) {
					Property = ap.Definition
				};
			}

			return ret;
		}
	}
}
