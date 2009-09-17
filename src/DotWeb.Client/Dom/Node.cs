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

	/// <summary>
	/// <para>
	/// The Node interface is the primary datatype for the entire Document Object Model. 
	/// It represents a single node in the document tree. While all objects implementing 
	/// the Node interface expose methods for dealing with children, not all objects implementing 
	/// the Node interface may have children. For example, Text nodes may not have children, 
	/// and adding children to such nodes results in a DOMException being raised.
	/// </para>
	/// <para>
	/// The attributes nodeName, nodeValue and attributes are included as a mechanism to 
	/// get at node information without casting down to the specific derived interface. 
	/// In cases where there is no obvious mapping of these attributes for a specific nodeType 
	/// (e.g., nodeValue for an Element or attributes for a Comment ), this returns null. 
	/// Note that the specialized interfaces may contain additional and more convenient mechanisms 
	/// to get and set the relevant information.
	/// </para>
	/// </summary>
	public class Node : JsNativeBase
	{
		#region Properties
		
		[JsIntrinsic]
		public string nodeName { get { return _<string>(); } }

		[JsIntrinsic]
		public string nodeValue { get { return _<string>(); } set { _(value); } }

		[JsIntrinsic]
		public NodeType nodeType { get { return _<NodeType>(); } }

		[JsIntrinsic]
		public Node parentNode { get { return _<Node>(); } }

		[JsIntrinsic]
		public NodeList childNodes { get { return _<NodeList>(); } }

		[JsIntrinsic]
		public Node firstChild { get { return _<Node>(); } }

		[JsIntrinsic]
		public Node lastChild { get { return _<Node>(); } }

		[JsIntrinsic]
		public Node previousSibling { get { return _<Node>(); } }

		[JsIntrinsic]
		public Node nextSibling { get { return _<Node>(); } }

		[JsIntrinsic]
		public NamedNodeMap attributes { get { return _<NamedNodeMap>(); } }

		/// <summary>
		/// Returns a reference to the document object that contains the current element/node.
		/// </summary>
		[JsIntrinsic]
		public Document ownerDocument { get { return _<Document>(); } }

		#region DOM Level 2
		[JsIntrinsic]
		public string namespaceURI { get { return _<string>(); } }

		[JsIntrinsic]
		public string prefix { get { return _<string>(); } set { _(value); } }

		[JsIntrinsic]
		public string localName { get { return _<string>(); } }
		#endregion

		#region Gecko
		[JsIntrinsic]
		public string textContent { get { return _<string>(); } set { _(value); } }
		#endregion

		#endregion

		#region Methods

		public Node insertBefore(Node newChild, Node refChild) { return _<Node>(newChild, refChild); }
		public Node replaceChild(Node newChild, Node oldChild) { return _<Node>(newChild, oldChild); }
		public Node removeChild(Node child) { return _<Node>(child); }
		public Node appendChild(Node child) { return _<Node>(child); }
		public bool hasChildNodes() { return _<bool>(); }
		public Node cloneNode(bool deep) { return _<Node>(deep); }
		public void normalize() { _(); }
		public bool isSupported(string feature, string version) { return _<bool>(feature, version); }

		#region DOM Level 2
		public bool hasAttributes() { return _<bool>(); }
		#endregion

		#region Gecko
		public void compareDocumentPosition() { _(); }
		public bool isDefaultNamespace() { return _<bool>(); }
		public bool isEqualNode() { return _<bool>(); }
		public bool isSameNode() { return _<bool>(); }
		#endregion

		#endregion
	}
}
