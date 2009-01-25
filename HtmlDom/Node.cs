using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDom
{
	public enum NodeType
	{
		ELEMENT_NODE = 1,
		ATTRIBUTE_NODE = 2,
		TEXT_NODE = 3,
		CDATA_SECTION_NODE = 4,
		ENTITY_REFERENCE_NODE = 5,
		ENTITY_NODE = 6,
		PROCESSING_INSTRUCTION_NODE = 7,
		COMMENT_NODE = 8,
		DOCUMENT_NODE = 9,
		DOCUMENT_TYPE_NODE = 10,
		DOCUMENT_FRAGMENT_NODE = 11,
		NOTATION_NODE = 12
	}

	[Flags]
	public enum DocumentPosition
	{
		DOCUMENT_POSITION_DISCONNECTED = 1,
		DOCUMENT_POSITION_PRECEDING = 2,
		DOCUMENT_POSITION_FOLLOWING = 4,
		DOCUMENT_POSITION_CONTAINS = 8,
		DOCUMENT_POSITION_CONTAINED_BY = 16,
		DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC = 32
	}

	public interface Node
	{
		NamedNodeMap attributes { get; }
		IList<Node> childNodes { get; }
		Node firstChild { get; }
		Node lastChild { get; }
		string localName { get; }
		string namespaceURI { get; }
		Node nextSibling { get; }
		string nodeName { get; }
//		object nodePrincipal;
		NodeType nodeType { get; }
		object nodeValue { get; set;  }
		Document ownerDocument { get; }
		Node parentNode { get; }
		string prefix { get; set;  }
		Node previousSibling { get; }
		string textContent { get; set;  }

		Node appendChild(Node child);
		Node cloneNode(bool deep);
		void compareDocumentPosition();
		bool hasAttributes();
		bool hasChildNodes();
		Node insertBefore(Node newChild, Node refChild);
		bool isDefaultNamespace();
		bool isEqualNode();
		bool isSameNode();
		bool isSupported();
		void normalize();
		Node removeChild(Node child);
		Node replaceChild(Node newChild, Node oldChild);
	}
}
