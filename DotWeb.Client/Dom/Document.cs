using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotWeb.Client.Dom
{
	public class Document : Node
	{
		/// <summary>
		/// References the body element of the page. 
		/// From there, you can then access other nodes contained within the body.
		/// </summary>
		public Element body { get { return _<Element>(); } }

		/// <summary>
		/// A string containing the name/value pair of cookies in the document.
		/// </summary>
		public string cookie { get { return _<string>(); } }

		/// <summary>
		/// References the root element of the document, 
		/// in the case of HTML documents, the html element. 
		/// This read only property is useful for accessing all elements on the page, such as the HEAD.
		/// </summary>
		public Element documentElement { get { return _<Element>(); } }

		/// <summary>
		/// Gets/sets the domain of the current document. 
		/// Useful in cross domain scripting when one domain is to communicate with another.
		/// </summary>
		public string domain { get { return _<string>(); } set { _(value); } }

		/// <summary>
		/// Specifies the title of the document. Read/write in modern browsers.
		/// </summary>
		public string title { get { return _<string>(); } set { _(value); } }

		/// <summary>
		/// A string that specifies the complete URL of the document.
		/// </summary>
		public string URL { get { return _<string>(); } }

		/// <summary>
		/// A string that specifies the URL in which the user 
		/// derived from to reach the current, usually via a link.
		/// </summary>
		public string referrer { get { return _<string>(); } }

		/// <summary>
		/// Specifies the last modified date of the document, as reported by the web server.
		/// </summary>
		public string lastModified { get { return _<string>(); } }

		/// <summary>
		/// Specifies the color of activated links in the document (Alink attribute).
		/// </summary>
		public string alinkColor { get { return _<string>(); } set { _(value); } }

		/// <summary>
		/// Specifies the color of unvisited links in the document (link attribute).
		/// </summary>
		public string linkColor { get { return _<string>(); } set { _(value); } }

		/// <summary>
		/// Specifies the color of visited links in the document (vlink attribute).
		/// </summary>
		public string vlinkColor { get { return _<string>(); } set { _(value); } }

		/// <summary>
		/// Specifies the background color of the document.
		/// </summary>
		public string bgColor { get { return _<string>(); } set { _(value); } }
	
		/// <summary>
		/// Specifies the default text color of the document (text attribute).
		/// </summary>
		public string fgColor { get { return _<string>(); } set { _(value); } }

		/// <summary>
		/// Adds an event listener to the document.
		/// </summary>
		public void addEventListener() { _(); }

//		void adoptNode();

		[Obsolete]
		public void clear() { _(); }

		/// <summary>
		/// Closes a document stream opened using document.open().
		/// </summary>
		public void close() { _(); }

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
		public Attribute createAttribute(string name) { return _<Attribute>(name); }

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

		public Node createTreeWalker() { return _<Node>(); }

		//Node elementFromPoint();

		public void evaluate() { _(); }

		public void execCommand() { _(); }
		
		/// <summary>
		/// Accesses any element on the page via its ID attribute. 
		/// A fundamental method within the DOM for accessing elements on the page.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Element getElementById(string id) { return _<Element>(id); }

		//void getElementsByClassName();
		
		/// <summary>
		/// Returns an array of elements with a name attribute whose value matches 
		/// that of the parameter's. 
		/// In IE6, elements with an ID attribute of the matching value will 
		/// also be included in the array, and getElementsByName() is limited 
		/// to retrieving form objects such as checkboxes and INPUT. 
		/// In Firefox, nither of these "pitfalls" apply.
		/// </summary>
		/// <example>
		/// <code>
		/// <div name="george">f</div>
		/// <div name="george">f</div>
		/// 
		/// <script type="text/javascript">
		///		var georges=document.getElementsByName("george")
		///		for (i=0; i< georges.length; i++)
		///		// do something with each DIV tag with name="george". Firefox only.
		///	</script>
		/// </code>
		/// </example>
		/// <param name="name"></param>
		/// <returns></returns>
		public IEnumerable<Element> getElementsByName(string name) { return _<IEnumerable<Element>>(name); }
		
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

		public void load() { _(); }

		//void loadOverlay();

		/// <summary>
		/// Opens a document stream in preparation for document.write() to write to it. 
		/// Use the optional <paramref name="mimetype"/> argument (default is text/html) to specify a 
		/// specific minetype, such as "image/gif." 
		/// </summary>
		/// <param name="mimeType"></param>
		public void open(string mimeType) { _(mimeType); }

		/// <summary>
		/// Accepts a CSS selector(s) and returns the first matching element 
		/// (based on the document tree) within the document, or null. 
		/// </summary>
		/// <remarks>
		/// Note: Currently supported in FF3.1+, IE8+ (only in IE8 standards mode), and Safari 3.1+
		/// </remarks>
		/// <param name="selector"></param>
		/// <returns></returns>
		public IEnumerable<Element> querySelector(string selector) { return _<IEnumerable<Element>>(selector); }

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
		public IEnumerable<Element> querySelectorAll(string selector) { return _<IEnumerable<Element>>(selector); }

		/// <summary>
		/// Writes to the document (as it's loading) or document stream the <paramref name="markup"/> entered.
		/// </summary>
		/// <param name="markup"></param>
		public void write(string markup) { _(markup); }

		/// <summary>
		/// Writes to the document (as it's loading) or document stream the <paramref name="line"/> entered 
		/// and inserts a newline character at the end.
		/// </summary>
		/// <param name="line"></param>
		public void writeln(string line) { _(line); }
	}
}
