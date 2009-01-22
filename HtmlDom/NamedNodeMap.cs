using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDom
{
	public class NamedNodeMap
	{
		public int length { get { return 0; } }

		public Node getNamedItem(string name) { return null; }
		public Node setNamedItem(Node node) { return null; }
		public Node removeNamedItem(string name) { return null; }

		public Node getNamedItemNS(string namespaceURI, string localName) { return null; }
		public Node setNamedItemNS(Node arg) { return null; }
		public Node removeNamedItemNS(string namespaceURI, string localName) { return null; }
	}
}
