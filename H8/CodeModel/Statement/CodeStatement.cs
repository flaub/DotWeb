using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H8.CodeModel
{
	public abstract class CodeStatement : CodeObject
	{
		//
		// Summary:
		//     Gets or sets the line on which the code statement occurs.
		//
		// Returns:
		//     A H8.CodeModel.CodeLinePragma object that indicates the context of the
		//     code statement.
		public CodeLinePragma LinePragma { get; set; }
	}
}
