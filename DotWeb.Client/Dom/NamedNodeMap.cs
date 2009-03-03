using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client.Dom
{
	public interface NamedNodeMap
	{
		int length { get; }

		Node getNamedItem(string name);
		Node setNamedItem(Node node);
		Node removeNamedItem(string name);

		Node getNamedItemNS(string namespaceURI, string localName);
		Node setNamedItemNS(Node arg);
		Node removeNamedItemNS(string namespaceURI, string localName);
	}
}
