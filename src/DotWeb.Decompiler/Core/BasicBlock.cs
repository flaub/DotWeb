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

using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using DotWeb.Decompiler.CodeModel;
using Mono.Cecil.Cil;
using Mono.Cecil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Decompiler.Core
{
	class BasicBlock : Node
	{
		public override string FullName {
			get {
				var il = Instructions.Last();
				return string.Format("{0}: {1:0000} - {2}", this.RefName, BeginOffset, il.DisplayString());
			}
		}

		public List<CodeStatement> Statements { get; private set; }

		public List<Instruction> Instructions { get; private set; }
		public int BeginOffset { get { return this.FirstInstruction.Offset; } }
		public int EndOffset { get { return this.LastInstruction.Offset; } }

		public Instruction FirstInstruction { get { return this.Instructions.First(); } }
		public Instruction LastInstruction { get { return this.Instructions.Last(); } }

		public CodeStatement FirstStatement { get { return this.Statements.First(); } }
		public CodeStatement LastStatement { get { return this.Statements.Last(); } }

		private MethodDefinition method;

		public BasicBlock(MethodDefinition method) {
			this.method = method;
			this.Instructions = new List<Instruction>();
			this.Statements = new List<CodeStatement>();
		}

		public override FlowControl FlowControl {
			get {
				var last = this.Instructions.Last();
				Debug.Assert(last != null);
				return last.OpCode.FlowControl;
			}
		}

		public bool IsTwoWay {
			get { return LastInstruction.IsTwoWay(); }
		}

		public bool IsMultiWay {
			get { return LastInstruction.IsMultiWay(); }
		}

		public void GenerateCodeModel(TypeSystem typeHierarchy, CodeModelVirtualMachine context) {
			// Iterate thru the instructions in this basic block 
			// The production of statements goes into this.Statements
			new CodeModelGenerator(typeHierarchy, this.method, context, this.Instructions, this.Statements);
			this.DfsTraversed = DfsTraversal.CodeDom;

			// Depth-first traversal into other basic blocks
			// Accumulate statements into this.Statements
			foreach (BasicBlock next in this.Successors) {
				if (next.DfsTraversed != DfsTraversal.CodeDom) {
					next.GenerateCodeModel(typeHierarchy, context);
				}
			}
		}
	}
}
