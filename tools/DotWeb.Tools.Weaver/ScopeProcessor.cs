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
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using System.Collections;

namespace DotWeb.Tools.Weaver
{
	class ScopeProcessor
	{
		private MethodProcessor parent;
		private ILGenerator generator;
		private Scope nextScope = null;
		private Scope curScope = null;
		private IEnumerator itScopes = null;

		public ScopeProcessor(MethodProcessor parent, ILGenerator generator) {
			this.parent = parent;
			this.generator = generator;
		}

		public void Push(ScopeCollection scopes) {
			itScopes = scopes.GetEnumerator();
			nextScope = Next();
		}

		private Scope Next() {
			return itScopes.MoveNext() ? (Scope)itScopes.Current : null;
		}

		public void ProcessInstruction(Instruction cil) {
			if (nextScope != null && cil.Offset >= nextScope.Start.Offset) {
				curScope = nextScope;
				nextScope = Next();

				generator.BeginScope();

				parent.DeclareLocals(generator, curScope.Variables);
			}

			if (curScope != null && cil.Offset >= curScope.End.Offset) {
				curScope = null;

				generator.EndScope();
			}
		}
	}
}
