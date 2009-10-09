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
	/// The Attr interface represents an attribute in an Element object. 
	/// Typically the allowable values for the attribute are defined in a document type definition.
	/// </para>
	/// <para>
	/// Attr objects inherit the Node interface, but since they are not actually 
	/// child nodes of the element they describe, the DOM does not consider them part 
	/// of the document tree. Thus, the Node attributes parentNode, previousSibling, 
	/// and nextSibling have a null value for Attr objects. The DOM takes the view that 
	/// attributes are properties of elements rather than having a separate identity from 
	/// the elements they are associated with; this should make it more efficient to 
	/// implement such features as default attributes associated with all elements of a given type. 
	/// Furthermore, Attr nodes may not be immediate children of a DocumentFragment. However, 
	/// they can be associated with Element nodes contained within a DocumentFragment. In short, 
	/// users and implementors of the DOM need to be aware that Attr nodes have some things in 
	/// common with other objects inheriting the Node interface, but they also are quite distinct.
	/// </para>
	/// <para>
	/// The attribute's effective value is determined as follows: if this attribute has been 
	/// explicitly assigned any value, that value is the attribute's effective value; otherwise, 
	/// if there is a declaration for this attribute, and that declaration includes a default value, 
	/// then that default value is the attribute's effective value; otherwise, the attribute does not 
	/// exist on this element in the structure model until it has been explicitly added. Note that 
	/// the nodeValue attribute on the Attr instance can also be used to retrieve the string 
	/// version of the attribute's value(s).
	/// </para>
	/// <para>
	/// In XML, where the value of an attribute can contain entity references, the child nodes 
	/// of the Attr node may be either Text or EntityReference nodes (when these are in use; 
	/// see the description of EntityReference for discussion). Because the DOM Core is not aware 
	/// of attribute types, it treats all attribute values as simple strings, even if the DTD or 
	/// schema declares them as having tokenized types.
	/// </para>
	/// </summary>
	[JsIntrinsic]
	public interface Attr : Node
	{
		/// <summary>
		/// Returns the name of this attribute.
		/// </summary>
		string name { get; }
		
		/// <summary>
		/// If this attribute was explicitly given a value in the original document, this is true; otherwise, it is false.
		/// </summary>
		bool specified { get; }

		/// <summary>
		/// The value of the attribute as a string.
		/// </summary>
		string value { get; set; }

		/// <summary>
		/// The Element node this attribute is attached to or null if this attribute is not in use
		/// </summary>
		Element ownerElement { get; }
	}
}
