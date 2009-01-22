using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using H8.CodeModel;

namespace H8
{
	public class DependencyAnalyzer
	{
		public DependencyAnalyzer() {
		}

		public void AnalyzeMethod(CodeMethodMember method) {
			CodeSequence sequencer = new CodeSequence();
			method.Accept(sequencer);

			var methodRefs = sequencer.Sequence.Where(x => x is CodeMethodReference);
			CodeTypeEvaluator evaluator = new CodeTypeEvaluator(method.Info);
			foreach (CodeMethodReference methodRef in methodRefs) {
				Type type = evaluator.Evaluate(methodRef.TargetObject);
				Console.WriteLine(type);
			}
		}

		public void AnalyzeType(Type type) {
		}
	}
}
