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

namespace DotWeb.Decompiler.CodeModel
{
	// Summary:
	//     Represents a specific location within a specific file.
	public class CodeLinePragma
	{
		// Summary:
		//     Initializes a new instance of the DotWeb.Decompiler.CodeModel.CodeLinePragma class.
		public CodeLinePragma() { }

		//
		// Summary:
		//     Initializes a new instance of the DotWeb.Decompiler.CodeModel.CodeLinePragma class.
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
