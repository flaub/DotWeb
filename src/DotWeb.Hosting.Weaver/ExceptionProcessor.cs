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
using Mono.Cecil.Cil;
using System.Reflection.Emit;
using System.Collections;

namespace DotWeb.Hosting.Weaver
{
	class ExceptionProcessor
	{
		enum ExceptionLabelType
		{
			Start,
			End,
			Catch,
			Finally
		}

		class InstructionRange
		{
			public int Start { get; set; }
			public int End { get; set; }

			public InstructionRange(int start, int end) {
				this.Start = start;
				this.End = end;
			}

			public override bool Equals(object obj) {
				var rhs = obj as InstructionRange;
				if (rhs == null) {
					return false;
				}
				return this.Start == rhs.Start && this.End == rhs.End;
			}

			public override int GetHashCode() {
				return Start ^ End;
			}
		}

		class ExceptionLabel
		{
			public ExceptionLabelType Type { get; set; }
			public Type CatchType { get; set; }
		}

		class LabelDictionary
		{
			private Dictionary<InstructionRange, ExceptionLabel> labels;

			public LabelDictionary() {
				this.labels = new Dictionary<InstructionRange, ExceptionLabel>();
			}

			public IEnumerable<ExceptionLabel> GetAllWithStart(int start) {
				var result = new List<ExceptionLabel>();
				foreach (var entry in this.labels) {
					if (entry.Key.Start == start) {
						result.Add(entry.Value);
					}
				}
				return result;
			}

			public bool TryGetValue(InstructionRange key, out ExceptionLabel value) {
				return this.labels.TryGetValue(key, out value);
			}

			public void Add(InstructionRange key, ExceptionLabel value) {
				this.labels.Add(key, value);
			}
		}

		private MethodProcessor parent;
		private ILGenerator generator;
		private LabelDictionary labels = new LabelDictionary();

		public ExceptionProcessor(MethodProcessor parent, ILGenerator generator) {
			this.parent = parent;
			this.generator = generator;
		}

		public void Start(ExceptionHandlerCollection handlers) {
			var ends = new Dictionary<InstructionRange, int>();

			foreach (ExceptionHandler handler in handlers) {
				var tryRange = new InstructionRange(handler.TryStart.Offset, handler.TryEnd.Offset);
				ExceptionLabel tryLabel;
				if (!this.labels.TryGetValue(tryRange, out tryLabel)) {
					tryLabel = new ExceptionLabel {
						Type = ExceptionLabelType.Start
					};
					this.labels.Add(tryRange, tryLabel);
				}

				var handlerRange = new InstructionRange(handler.HandlerStart.Offset, handler.HandlerEnd.Offset);
				ExceptionLabel handlerLabel;
				if (!this.labels.TryGetValue(handlerRange, out handlerLabel)) {
					handlerLabel = new ExceptionLabel();
					switch (handler.Type) {
						case ExceptionHandlerType.Catch:
							handlerLabel.Type = ExceptionLabelType.Catch;
							handlerLabel.CatchType = this.parent.ResolveTypeReference(handler.CatchType);
							break;
						case ExceptionHandlerType.Finally:
							handlerLabel.Type = ExceptionLabelType.Finally;
							break;
						default:
							throw new NotSupportedException();
					}
					this.labels.Add(handlerRange, handlerLabel);
				}

				int end = 0;
				ends.TryGetValue(tryRange, out end);

				end = Math.Max(end, handler.TryEnd.Offset);
				end = Math.Max(end, handler.HandlerEnd.Offset);

				ends[tryRange] = end;
			}

			foreach (var end in ends.Values) {
				var endLabel = new ExceptionLabel { Type = ExceptionLabelType.End };
				var endRange = new InstructionRange(end, end);
				this.labels.Add(endRange, endLabel);
			}
		}

		public void ProcessInstruction(Instruction cil) {
			var blocks = this.labels.GetAllWithStart(cil.Offset);
			foreach (var block in blocks) {
				switch (block.Type) {
					case ExceptionLabelType.Start:
						this.generator.BeginExceptionBlock();
						break;
					case ExceptionLabelType.End:
						this.generator.EndExceptionBlock();
						break;
					case ExceptionLabelType.Catch:
						this.generator.BeginCatchBlock(block.CatchType);
						break;
					case ExceptionLabelType.Finally:
						this.generator.BeginFinallyBlock();
						break;
				}
			}
		}
	}

}
