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

namespace DotWeb.Decompiler
{
	public static class MethodDecompiler
	{
		public static CodeMethodMember Parse(MethodBase method) {
			Console.WriteLine(method);

			var cfg = new ControlFlowGraph(method);
			Console.WriteLine(cfg);

			var cfa = new ControlFlowAnalyzer(cfg);
			cfa.Structure();

			var be = new BackEnd(cfg);
			be.WriteCode();

			AssociatedProperty ap = method.GetAssociatedProperty();
			if (ap != null) {
				if (ap.IsGetter) {
					return new CodePropertyGetterMember(be.Method) {
						PropertyInfo = ap.Info
					};
				}

				return new CodePropertySetterMember(be.Method) {
					PropertyInfo = ap.Info
				};
			}

			return be.Method;
		}
	}
}
