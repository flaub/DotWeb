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
using System.DotWeb;

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
	[JsIntrinsic]
	public interface Node
	{
		#region Properties

		string nodeName { get; }
		string nodeValue { get; set; }
		NodeType nodeType { get; }
		Node parentNode { get; }
		NodeList childNodes { get; }
		Node firstChild { get; }
		Node lastChild { get; }
		Node previousSibling { get; }
		Node nextSibling { get; }
		NamedNodeMap attributes { get; }

		/// <summary>
		/// Returns a reference to the document object that contains the current element/node.
		/// </summary>
		Document ownerDocument { get; }

		#region DOM Level 2
		string namespaceURI { get; }
		string prefix { get; set; }
		string localName { get; }
		#endregion

		#region Gecko
		string textContent { get; set; }
		#endregion

		#endregion

		#region Methods

		Node insertBefore(Node newChild, Node refChild);
		Node replaceChild(Node newChild, Node oldChild);
		Node removeChild(Node child);
		Node appendChild(Node child);
		bool hasChildNodes();
		Node cloneNode(bool deep);
		void normalize();
		bool isSupported(string feature, string version);

		#region DOM Level 2
		bool hasAttributes();
		#endregion

		#region Gecko
		void compareDocumentPosition();
		bool isDefaultNamespace();
		bool isEqualNode();
		bool isSameNode();
		#endregion

		#endregion
	}
}
