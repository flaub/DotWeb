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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection.Emit;
using System.Diagnostics;
using DotWeb.Translator.CodeModel;
using System.Reflection;

namespace DotWeb.Translator
{
	public class BasicBlock : Node
	{
		public override string FullName {
			get {
				ILInstruction il = Instructions.Last();
				return string.Format("{0}: {1:0000} - {2}", this.RefName, BeginOffset, il);
			}
		}

		public List<CodeStatement> Statements { get; private set; }

		public List<ILInstruction> Instructions { get; private set; }
		public int BeginOffset { get { return this.FirstInstruction.Offset; } }
		public int EndOffset { get { return this.LastInstruction.Offset; } }

		public ILInstruction FirstInstruction { get { return this.Instructions.First(); } }
		public ILInstruction LastInstruction { get { return this.Instructions.Last(); } }

		public CodeStatement FirstStatement { get { return this.Statements.First(); } }
		public CodeStatement LastStatement { get { return this.Statements.Last(); } }

		public BasicBlock(int id)
			: base(id) {
			this.Instructions = new List<ILInstruction>();
			this.Statements = new List<CodeStatement>();
		}

		public override FlowControl FlowControl {
			get {
				ILInstruction last = this.Instructions.Last();
				Debug.Assert(last != null);
				return last.Code.FlowControl;
			}
		}

		public bool IsTwoWay {
			get { return LastInstruction.IsTwoWay; }
		}

		public bool IsMultiWay {
			get { return LastInstruction.IsMultiWay; }
		}

		public void GenerateCodeModel(CodeModelVirtualMachine context) {
			CodeModelGenerator cma = new CodeModelGenerator(context, this.Instructions);
			this.Statements = cma.Statements;
			this.DfsTraversed = DfsTraversal.CodeDom;

			foreach (BasicBlock next in this.OutEdges) {
				if (next.DfsTraversed != DfsTraversal.CodeDom) {
					next.GenerateCodeModel(context);
				}
			}
		}
	}
}
