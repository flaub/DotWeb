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

using System.DotWeb;
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
	[JsIntrinsic]
	public abstract class Element : Node
	{
		/// <summary>
		/// The name of the element.
		/// </summary>
		/// <returns></returns>
		public extern string tagName { get; }

		/// <summary>
		/// Retrieves an attribute value by name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public extern string getAttribute(string name);

		/// <summary>
		/// Retrieves an attribute node by name.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public extern Attr getAttributeNode(string name);

		/// <summary>
		/// Retrieves an Attr node by local name and namespace URI.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public extern Attr getAttributeNodeNS(string namespaceURI, string localName);

		/// <summary>
		/// Retrieves an attribute value by local name and namespace URI.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public extern string getAttributeNS(string namespaceURI, string localName);

		/// <summary>
		/// Returns a NodeList of all descendant Elements with a given tag name, in the order in which they are encountered in a preorder traversal of this Element tree.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public extern NodeList getElementsByTagName(string name);

		/// <summary>
		/// Returns a NodeList of all the descendant Elements with a given local name and namespace URI in the order in which they are encountered in a preorder traversal of this Element tree.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public extern NodeList getElementsByTagNameNS(string namespaceURI, string localName);

		/// <summary>
		/// Returns true when an attribute with a given name is specified on this element or has a default value, false otherwise.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public extern bool hasAttribute(string name);

		/// <summary>
		/// Returns true when an attribute with a given local name and namespace URI is specified on this element or has a default value, false otherwise.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		/// <returns></returns>
		public extern bool hasAttributeNS(string namespaceURI, string localName);

		/// <summary>
		/// Removes an attribute by name.
		/// </summary>
		/// <param name="name"></param>
		public extern void removeAttribute(string name);

		/// <summary>
		/// Removes the specified attribute node.
		/// </summary>
		/// <param name="oldAttr"></param>
		/// <returns></returns>
		public extern Attr removeAttributeNode(Attr oldAttr);

		/// <summary>
		/// Removes an attribute by local name and namespace URI.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="localName"></param>
		public extern void removeAttributeNS(string namespaceURI, string localName);

		/// <summary>
		/// Adds a new attribute.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public extern void setAttribute(string name, string value);

		/// <summary>
		/// Adds a new attribute node.
		/// </summary>
		/// <param name="newAttr"></param>
		/// <returns></returns>
		public extern Attr setAttributeNode(Attr newAttr);

		/// <summary>
		/// Adds a new attribute.
		/// </summary>
		/// <param name="newAttr"></param>
		/// <returns></returns>
		public extern Attr setAttributeNodeNS(Attr newAttr);

		/// <summary>
		/// Adds a new attribute.
		/// </summary>
		/// <param name="namespaceURI"></param>
		/// <param name="qualifiedName"></param>
		/// <param name="value"></param>
		public extern void setAttributeNS(string namespaceURI, string qualifiedName, string value);
	}
}
