using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDom
{
	public class Document : Node
	{
		/// <summary>
		/// Adds an event listener to the document.
		/// </summary>
		public void addEventListener() { }

//		public void adoptNode() { }

		[Obsolete]
		public void clear() { }

		public void close() { }

		public Node createAttribute() { return null;  }
		public Node createCDATASection() { return null; }
		public Node createComment() { return null; }
		public Node createDocumentFragment() { return null; }
		public Node createElement() { return null; }
		public Node createElementNS() { return null; }
		public Node createEntityReference() { return null; }
		public Node createEvent() { return null; }
		public Node createNodeIterator() { return null; }
		public Node createNSResolver() { return null; }
		public Node createProcessingInstruction() { return null; }
		public Node createRange() { return null; }
		public Node createTextNode() { return null; }
		public Node createTreeWalker() { return null; }

//		public Node elementFromPoint() { return null; }
		public void evaluate() { }
		public void execCommand() { }
		public void getElementById() { }
//		public void getElementsByClassName() { }
		public void getElementsByName() { }
		public void getElementsByTagName() { }
		public void getElementsByTagNameNS() { }
		public void importNode() { }
		public void load() { }
//		public void loadOverlay() { }
		public void open() { }
		public void querySelector() { }
		public void querySelectorAll() { }
		public void write(string markup) { }
		public void writeln(string line) { }
	}
}
