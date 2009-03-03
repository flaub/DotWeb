using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	public abstract class CodeStatement : CodeObject
	{
		//
		// Summary:
		//     Gets or sets the line on which the code statement occurs.
		//
		// Returns:
		//     A DotWeb.Translator.CodeModel.CodeLinePragma object that indicates the context of the
		//     code statement.
		public CodeLinePragma LinePragma { get; set; }
	}
}
