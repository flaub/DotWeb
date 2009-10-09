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

namespace DotWeb.Client.Dom.Html
{
	[JsIntrinsic]
	public interface HtmlDocument : Document
	{
		/// <summary>
		/// Specifies the title of the document. Read/write in modern browsers.
		/// </summary>
		string title { get; set; }

		/// <summary>
		/// A string that specifies the URL in which the user 
		/// derived from to reach the current, usually via a link.
		/// </summary>
		string referrer { get; }

		/// <summary>
		/// Gets the domain of the current document. 
		/// Useful in cross domain scripting when one domain is to communicate with another.
		/// </summary>
		string domain { get; }

		/// <summary>
		/// A string that specifies the complete URL of the document.
		/// </summary>
		string URL { get; }

		/// <summary>
		/// References the body element of the page. 
		/// From there, you can then access other nodes contained within the body.
		/// </summary>
		HtmlBodyElement body { get; set; }

		HtmlCollection images { get; }
		HtmlCollection applets { get; }
		HtmlCollection links { get; }
		HtmlCollection forms { get; }
		HtmlCollection anchors { get; }

		/// <summary>
		/// A string containing the name/value pair of cookies in the document.
		/// </summary>
		string cookie { get; }

		/// <summary>
		/// Opens a document stream in preparation for document.write() to write to it. 
		/// </summary>
		/// <param name="mimeType"></param>
		void open();

		/// <summary>
		/// Closes a document stream opened using document.open().
		/// </summary>
		void close();

		/// <summary>
		/// Writes to the document (as it's loading) or document stream the <paramref name="markup"/> entered.
		/// </summary>
		/// <param name="markup"></param>
		void write(string markup);

		/// <summary>
		/// Writes to the document (as it's loading) or document stream the <paramref name="line"/> entered 
		/// and inserts a newline character at the end.
		/// </summary>
		/// <param name="line"></param>
		void writeln(string line);

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
		NodeList getElementsByName(string name);
	}
}
