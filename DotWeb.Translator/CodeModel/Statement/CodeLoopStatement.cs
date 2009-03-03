using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public abstract class CodeLoopStatement : CodeStatement
	{
		public CodeLoopStatement() {
			this.Statements = new List<CodeStatement>();
		}

		public List<CodeStatement> Statements { get; set; }
		public CodeExpression TestExpression { get; set; }
	}
}
