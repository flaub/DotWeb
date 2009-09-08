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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client.Dom
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

	public abstract class Node : JsNativeBase
	{
		public NamedNodeMap attributes { get { return _<NamedNodeMap>(); } }

		public IList<Node> childNodes { get { return _<IList<Node>>(); } }

		public Node firstChild { get { return _<Node>(); } }

		public Node lastChild { get { return _<Node>(); } }

		public string localName { get { return _<string>(); } }

		public string namespaceURI { get { return _<string>(); } }

		public Node nextSibling { get { return _<Node>(); } }

		public string nodeName { get { return _<string>(); } }
//		object nodePrincipal;

		public NodeType nodeType { get { return _<NodeType>(); } }

		public object nodeValue { get { return _<object>(); } set { _(value); } }

		/// <summary>
		/// Returns a reference to the document object that contains the current element/node.
		/// </summary>
		public Document ownerDocument { get { return _<Document>(); } }

		public Node parentNode { get { return _<Node>(); } }

		public string prefix { get { return _<string>(); } set { _(value); } }

		public Node previousSibling { get { return _<Node>(); } }

		public string textContent { get { return _<string>(); } set { _(value); } }

		public Node appendChild(Node child) { return _<Node>(child); }

		public Node cloneNode(bool deep) { return _<Node>(deep); }

		public void compareDocumentPosition() { _(); }

		public bool hasAttributes() { return _<bool>(); }

		public bool hasChildNodes() { return _<bool>(); }

		public Node insertBefore(Node newChild, Node refChild) { return _<Node>(newChild, refChild); }

		public bool isDefaultNamespace() { return _<bool>(); }

		public bool isEqualNode() { return _<bool>(); }

		public bool isSameNode() { return _<bool>(); }

		public bool isSupported() { return _<bool>(); }

		public void normalize() { _(); }

		public Node removeChild(Node child) { return _<Node>(child); }

		public Node replaceChild(Node newChild, Node oldChild) { return _<Node>(newChild, oldChild); }
	}
}
