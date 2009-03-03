using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Translator.CodeModel
{
	// Summary:
	//     Represents a specific location within a specific file.
	public class CodeLinePragma
	{
		// Summary:
		//     Initializes a new instance of the DotWeb.Translator.CodeModel.CodeLinePragma class.
		public CodeLinePragma() { }

		//
		// Summary:
		//     Initializes a new instance of the DotWeb.Translator.CodeModel.CodeLinePragma class.
		//
		// Parameters:
		//   fileName:
		//     The file name of the associated file.
		//
		//   lineNumber:
		//     The line number to store a reference to.
		public CodeLinePragma(string fileName, int lineNumber) {
			this.FileName = fileName;
			this.LineNumber = lineNumber;
		}

		// Summary:
		//     Gets or sets the name of the associated file.
		//
		// Returns:
		//     The file name of the associated file.
		public string FileName { get; set; }

		//
		// Summary:
		//     Gets or sets the line number of the associated reference.
		//
		// Returns:
		//     The line number.
		public int LineNumber { get; set; }
	}
}
