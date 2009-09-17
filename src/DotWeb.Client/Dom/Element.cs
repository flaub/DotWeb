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

namespace DotWeb.Client.Dom
{
	/// <summary>
	/// <para>
	/// The Element interface represents an element in an HTML or XML document. 
	/// Elements may have attributes associated with them; since the Element interface 
	/// inherits from Node, the generic Node interface attribute attributes may be used 
	/// to retrieve the set of all attributes for an element. There are methods on 
	/// the Element interface to retrieve either an Attr object by name or an attribute 
	/// value by name. In XML, where an attribute value may contain entity references, 
	/// an Attr object should be retrieved to examine the possibly fairly complex 
	/// sub-tree representing the attribute value. On the other hand, in HTML, where all 
	/// attributes have simple string values, methods to directly access an attribute 
	/// value can safely be used as a convenience.
	/// </para>
	/// <remarks>
	/// Note: In DOM Level 2, the method normalize is inherited from the Node interface where it was moved.
	/// </remarks>
	/// </summary>
	public class Element : Node
	{
		/// <summary>
		/// The name of the element.
		/// </summary>
		/// <returns></returns>
		public string tagName { get { return _<string>(); } }

		/// <summary>
		/// Retrieves an attribute value by name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public string getAttribute(string name) { return _<string>(); }

		/// <summary>
		/// Retrieves an attribute node by name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Attr getAttributeNode(string name) { return _<Attr>(); }

		/// <summary>
		/// Retrieves an Attr node by local name and namespace URI.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public Attr getAttributeNodeNS(string namespaceURI, string localName) { return _<Attr>(namespaceURI, localName); }

		/// <summary>
		/// Retrieves an attribute value by local name and namespace URI.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public string getAttributeNS(string namespaceURI, string localName) { return _<string>(namespaceURI, localName); }

		/// <summary>
		/// Returns a NodeList of all descendant Elements with a given tag name, in the order in which they are encountered in a preorder traversal of this Element tree.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public NodeList getElementsByTagName(string name) { return _<NodeList>(name); }

		/// <summary>
		/// Returns a NodeList of all the descendant Elements with a given local name and namespace URI in the order in which they are encountered in a preorder traversal of this Element tree.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public NodeList getElementsByTagNameNS(string namespaceURI, string localName) { return _<NodeList>(namespaceURI, localName); }

		/// <summary>
		/// Returns true when an attribute with a given name is specified on this element or has a default value, false otherwise.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool hasAttribute(string name) { return _<bool>(); }

		/// <summary>
		/// Returns true when an attribute with a given local name and namespace URI is specified on this element or has a default value, false otherwise.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public bool hasAttributeNS(string namespaceURI, string localName) { return _<bool>(namespaceURI, localName); }

		/// <summary>
		/// Removes an attribute by name.
		/// </summary>
		/// <param name="name"></param>
		public void removeAttribute(string name) { _(name); }

		/// <summary>
		/// Removes the specified attribute node.
		/// </summary>
		/// <param name="oldAttr"></param>
		/// <returns></returns>
		public Attr removeAttributeNode(Attr oldAttr) { return _<Attr>(oldAttr); }

		/// <summary>
		/// Removes an attribute by local name and namespace URI.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		public void removeAttributeNS(string namespaceURI, string localName) { _(namespaceURI, localName); }

		/// <summary>
		/// Adds a new attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void setAttribute(string name, string value) { _(name, value); }

		/// <summary>
		/// Adds a new attribute node.
		/// </summary>
		/// <param name="newAttr"></param>
		/// <returns></returns>
		public Attr setAttributeNode(Attr newAttr) { return _<Attr>(newAttr); }

		/// <summary>
		/// Adds a new attribute.
		/// </summary>
		/// <param name="newAttr"></param>
		/// <returns></returns>
		public Attr setAttributeNodeNS(Attr newAttr) { return _<Attr>(newAttr); }

		/// <summary>
		/// Adds a new attribute.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="qualifiedName"></param>
		/// <param name="value"></param>
		public void setAttributeNS(string namespaceURI, string qualifiedName, string value) { _(namespaceURI, qualifiedName, value); }
	}
}
