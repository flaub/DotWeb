using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using System.Collections;

namespace DotWeb.Sandbox
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
