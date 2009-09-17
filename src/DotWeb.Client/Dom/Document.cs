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
	public class Document : Node
	{
		/// <summary>
		/// References the root element of the document, 
		/// in the case of HTML documents, the html element. 
		/// This read only property is useful for accessing all elements on the page, such as the HEAD.
		/// </summary>
		public Element documentElement { get { return _<Element>(); } }

		/// <summary>
		/// Creates a new attribute, ready to be inserted somewhere in the document. 
		/// It returns a reference to the created attribute.
		/// </summary>
		/// <example>
		/// <code>
		/// var styleattr=document.createAttribute("align")
		/// styleattr.nodeValue="center"
		/// document.getElementById("sister").setAttributeNode(styleattr)
		/// </code>
		/// </example>
		/// <param name="name"></param>
		/// <returns></returns>
		public Attr createAttribute(string name) { return _<Attr>(name); }

		public Node createCDATASection() { return _<Node>(); }
		
		/// <summary>
		/// Creates an instance of the comment node. 
		/// Once created, you can then insert it into the document tree using appendChild(), for example.
		/// </summary>
		/// <example>
		/// <code>
		/// var commentnode = document.createComment("Copyright JavaScript Kit")
		/// document.getElementById("mydiv").appendChild(commentnode)
		/// </code>
		/// </example>
		/// <param name="comment"></param>
		/// <returns></returns>
		public Node createComment(string comment) { return _<Node>(comment); }
		
		/// <summary>
		/// Creates an empty document fragment. 
		/// The result is a temporary container for creating and modifying new elements or 
		/// attributes before introducing the final result to your document tree. 
		/// This is a very useful method when you're performing multiple operations that 
		/// add to or modify the document tree. 
		/// Instead of directly modifying the document tree each time (very inefficient), 
		/// it's much better to use a temporary "whiteboard" that is created by 
		/// createDocumentFragment() to perform all your operations on first before 
		/// finally inserting the result to the document tree.
		/// </summary>
		/// <example>
		/// <code>
		/// <div id="sister"></div>
		/// <script type="text/javascript">
		///		var docfrag=document.createDocumentFragment()
		///		var mydiv=document.createElement("div")
		///		var divtext=document.createTextNode("This is div text")
		///		mydiv.appendChild(divtext)
		///		docfrag.appendChild(mydiv)
		///		document.getElementById("sister").appendChild(docfrag) //div now reads "this is div text"
		/// </script>
		/// </code>
		/// </example>
		/// <returns></returns>
		public Document createDocumentFragment() { return _<Document>(); }
		
		/// <summary>
		/// Creates an instance of the element object, 
		/// which can then added to the document tree using appendChild(), for example.
		/// </summary>
		/// <example>
		/// <code>
		/// var textblock=document.createElement("p")
		/// textblock.setAttribute("id", "george")
		/// textblock.setAttribute("align", "center")
		/// document.body.appendChild(textblock)
		/// </code>
		/// </example>
		/// <param name="tag"></param>
		/// <returns></returns>
		public Element createElement(string tag) { return _<Element>(tag); }

		public Node createElementNS() { return _<Node>(); }

		public Node createEntityReference() { return _<Node>(); }

		public Node createEvent() { return _<Node>(); }

		public Node createNodeIterator() { return _<Node>(); }

		public Node createNSResolver() { return _<Node>(); }

		public Node createProcessingInstruction() { return _<Node>(); }

		public Node createRange() { return _<Node>(); }

		/// <summary>
		/// Creates a new text node, which can then be added to an element in the document tree.
		/// </summary>
		/// <example>
		/// <code>
		/// var headertext=document.createTextNode("Welcome to JavaScript Kit")
		/// document.getElementById("mytitle").appendChild(headertext)
		/// </code>
		/// </example>
		/// <param name="text"></param>
		/// <returns></returns>
		public Node createTextNode(string text) { return _<Node>(text); }

		/// <summary>
		/// Accesses any element on the page via its ID attribute. 
		/// A fundamental method within the DOM for accessing elements on the page.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Element getElementById(string id) { return _<Element>(id); }

		/// <summary>
		/// Returns an array of elements whose tag name matches the parameter. 
		/// In Firefox/ IE6+, you may enter an asterisk ("*") as the parameter to 
		/// retrieve a list of all elements within the document.
		/// </summary>
		/// <example>
		/// <code>
		/// var ptags=document.getElementsByTagName("p")
		/// var alltags=document.getElementsByTagName("*") //returns all elements on page
		/// </code>
		/// </example>
		/// <param name="tag"></param>
		/// <returns></returns>
		IEnumerable<Element> getElementsByTagName(string tag) { return _<IEnumerable<Element>>(tag); }

		public IEnumerable<Element> getElementsByTagNameNS() { return _<IEnumerable<Element>>(); }

		public void importNode() { _(); }

		/// <summary>
		/// Accepts a CSS selector(s) and returns the first matching element 
		/// (based on the document tree) within the document, or null. 
		/// </summary>
		/// <remarks>
		/// Note: Currently supported in FF3.1+, IE8+ (only in IE8 standards mode), and Safari 3.1+
		/// </remarks>
		/// <param name="selector"></param>
		/// <returns></returns>
//		public IEnumerable<Element> querySelector(string selector) { return _<IEnumerable<Element>>(selector); }

		/// <summary>
		/// Accepts a CSS selector(s) and returns all matching elements 
		/// (based on the document tree) within the document as a staticNodeList, or null. 
		/// A staticNodeList is a static collection of elements that are not affected by 
		/// any subsequent changes occuring on the document tree.
		/// </summary>
		/// <remarks>
		/// Note: Currently supported in FF3.1+, IE8+ (only in IE8 standards mode), and Safari 3.1+
		/// </remarks>
		/// <param name="selector"></param>
		/// <returns></returns>
//		public IEnumerable<Element> querySelectorAll(string selector) { return _<IEnumerable<Element>>(selector); }
	}
}
