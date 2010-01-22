using System;
using Cecil.Decompiler;
using Cecil.Decompiler.Languages;
using Cecil.Decompiler.Steps;

namespace DotWeb.Javascript
{
	public class Javascript : ILanguage
	{
		#region ILanguage Members

		public string Name {
			get { return "DotWeb.Javascript"; }
		}

		public ILanguageWriter GetWriter(IFormatter formatter) {
			return new JavascriptWriter(this, formatter);
		}

		public DecompilationPipeline CreatePipeline() {
			return new DecompilationPipeline(
				new StatementDecompiler(BlockOptimization.Detailed),
				RemoveLastReturn.Instance,
				PropertyStep.Instance,
				CanCastStep.Instance,
				RebuildForStatements.Instance,
				RebuildForeachStatements.Instance,
				DeclareVariablesOnFirstAssignment.Instance,
				DeclareTopLevelVariables.Instance,
				SelfAssignement.Instance,
				OperatorStep.Instance);
		}

		#endregion
	}
}
