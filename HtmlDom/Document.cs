using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDom
{
	public interface Document : Node
	{
		/// <summary>
		/// Adds an event listener to the document.
		/// </summary>
		void addEventListener();

//		void adoptNode();

		[Obsolete]
		void clear();

		void close();

		Attribute createAttribute(string name);
		Node createCDATASection();
		Node createComment(string comment);
		Document createDocumentFragment();
		Element createElement(string tag);
		Node createElementNS();
		Node createEntityReference();
		Node createEvent();
		Node createNodeIterator();
		Node createNSResolver();
		Node createProcessingInstruction();
		Node createRange();
		Node createTextNode(string text);
		Node createTreeWalker();

//		Node elementFromPoint();
		void evaluate();
		void execCommand();
		Element getElementById(string id);
//		void getElementsByClassName();
		IEnumerable<Element> getElementsByName(string name);
		IEnumerable<Element> getElementsByTagName(string tag);
		IEnumerable<Element> getElementsByTagNameNS();
		void importNode();
		void load();
//		void loadOverlay();
		void open(string url, string name, string features, bool replace);
		void querySelector();
		void querySelectorAll();
		void write(string markup);
		void writeln(string line);
	}
}
