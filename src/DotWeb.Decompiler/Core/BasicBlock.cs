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
using System.Text;

namespace DotWeb.Decompiler.Core
{
	public class BasicBlock : Node
	{
		public override string FullName {
			get {
				var il = Instructions.Last();
				return string.Format("{0}: {1:0000} - {2}", this.RefName, BeginOffset, il.DisplayString());
			}
		}

		public string ToStringDetails() {
			var sb = new StringBuilder();
			sb.AppendFormat("{0}", FullName);
			if (Predecessors.Any()) {
				string[] values = Predecessors.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				sb.AppendLine();
				sb.AppendFormat("\tIn : {0}", line);
			}
			if (Successors.Any()) {
				string[] values = Successors.Select(x => x.RefName).ToArray();
				string line = string.Join(", ", values);
				sb.AppendLine();
				sb.AppendFormat("\tOut: {0}", line);
			}
			sb.AppendLine();
			foreach (var cil in this.Instructions) {
				sb.Append("\t");
				sb.Append(cil.DisplayString());
				sb.AppendLine();
			}
			return sb.ToString();
		}

		public List<CodeStatement> Statements { get; private set; }

		public List<Instruction> Instructions { get; private set; }
		public int BeginOffset { get { return this.FirstInstruction.Offset; } }
		public int EndOffset { get { return this.LastInstruction.Offset; } }

		public Instruction FirstInstruction { get { return this.Instructions.First(); } }
		public Instruction LastInstruction { get { return this.Instructions.Last(); } }

		public CodeStatement FirstStatement { get { return this.Statements.First(); } }
		public CodeStatement LastStatement { get { return this.Statements.Last(); } }

		public ExceptionHandler ExceptionHandler { get; set; }

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

		#region Stack Stash
		private int stashSize = 0;
		private Dictionary<int, CodeExpression> stash = new Dictionary<int, CodeExpression>();

		internal CodeExpression PushStash(TypeSystem typeSystem, CodeExpressionEntry item) {
			this.stashSize++;

			int index = this.StashSize;
			var variableName = string.Format("R_{0}", index);
			var eval = new CodeTypeEvaluator(typeSystem, this.method);
			var variableType = eval.Evaluate(item.Expression);
			var variable = new VariableDefinition(variableName, -index, this.method, variableType);
			var lhs = new CodeVariableReference(variable);

			this.stash[index] = lhs;

			return lhs;
		}

		public CodeExpression GetStashItem(int index) {
			CodeExpression item;
			if (!this.stash.TryGetValue(index, out item)) {
				var pred = (BasicBlock)this.Predecessors.First();
				item = pred.GetStashItem(index);
			}
			return item;
		}

		public CodeExpression PopStash() {
			var index = this.StashSize;
			this.stashSize--;
			return GetStashItem(index);
		}

		public CodeExpression PeekStash() {
			var index = this.StashSize;
			return GetStashItem(index);
		}

		public int StashSize {
			get {
				if (this.Predecessors.Count == 0)
					return this.stashSize;
				var pred = (BasicBlock)this.Predecessors.First();
				return pred.StashSize + stashSize;
			}
		}
		#endregion
	}
}
