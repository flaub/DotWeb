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

	public class Node
	{
		public readonly NamedNodeMap attributes;
		public readonly List<Node> childNodes;
		public readonly Node firstChild;
		public readonly Node lastChild;
		public readonly string localName;
		public readonly string namespaceURI;
		public readonly Node nextSibling;
		public readonly string nodeName;
//		public readonly object nodePrincipal;
		public readonly NodeType nodeType;
		public object nodeValue;
		public readonly Document ownerDocument;
		public readonly Node parentNode;
		public string prefix;
		public readonly Node previousSibling;
		public string textContent;

		public void appendChild() { }
		public void cloneNode() { }
		public void compareDocumentPosition() { }
		public bool hasAttributes() { return false; }
		public bool hasChildNodes() { return false; }
		public void insertBefore() { }
		public bool isDefaultNamespace() { return false; }
		public bool isEqualNode() { return false; }
		public bool isSameNode() { return false; }
		public bool isSupported() { return false; }
		public void normalize() { }
		public void removeChild() { }
		public void replaceChild() { }

		public const int ELEMENT_NODE = 1;
		public const int ATTRIBUTE_NODE = 2;
		public const int TEXT_NODE = 3;
		public const int CDATA_SECTION_NODE = 4;
		public const int ENTITY_REFERENCE_NODE = 5;
		public const int ENTITY_NODE = 6;
		public const int PROCESSING_INSTRUCTION_NODE = 7;
		public const int COMMENT_NODE = 8;
		public const int DOCUMENT_NODE = 9;
		public const int DOCUMENT_TYPE_NODE = 10;
		public const int DOCUMENT_FRAGMENT_NODE = 11;
		public const int NOTATION_NODE = 12;

		public const int DOCUMENT_POSITION_DISCONNECTED = 1;
		public const int DOCUMENT_POSITION_PRECEDING = 2;
		public const int DOCUMENT_POSITION_FOLLOWING = 4;
		public const int DOCUMENT_POSITION_CONTAINS = 8;
		public const int DOCUMENT_POSITION_CONTAINED_BY = 16;
		public const int DOCUMENT_POSITION_IMPLEMENTATION_SPECIFIC = 32;
	}
}
