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

using DotWeb.Client.Dom.Events;
using DotWeb.Client.Dom.Html;
using System.DotWeb;
using System;

namespace DotWeb.Client.Dom
{
	public delegate bool ErrorEventHandler(string msg, string url, int line);

	[JsNamespace]
	[JsObject]
	public class Window 
	{
		public static extern Window Instance {
			[JsMacro("$wnd")]
			get;
		}

		#region Properties

		public extern HtmlDocument document { get; }

		public extern object this[string name] { get; set; }

		#endregion

		#region Events

		/// <summary>
		/// Fires when the window loses focus.
		/// </summary>
		public extern GenericEventHandler onblur { get; set; }

		/// <summary>
		/// Fires when the focus is set on the current window.
		/// </summary>
		public extern GenericEventHandler onfocus { get; set; }

		/// <summary>
		/// Fires when the window is resized.
		/// </summary>
		public extern GenericEventHandler onresize { get; set; }

		/// <summary>
		/// Fires when the window is scrolled. 
		/// </summary>
		/// <example>
		/// The following shows the current y coordinate of the upper left corner of the viewable 
		/// window in the browser's title bar when the page is scrolled:
		/// <code>
		/// window.onscroll = function() {
		///		var scrollY = window.pageYOffset || document.body.scrollTop
		///		document.title=scrollY
		///	}
		/// </code>
		/// </example>
		public extern GenericEventHandler onscroll { get; set; }

		/// <summary>
		/// Fires when the page is about to be unloaded, 
		/// prior to window.onunload event firing. 
		/// Supported in all modern browsers. 
		/// </summary>
		/// <example>
		/// By setting event.returnValue to a string, 
		/// the browser will prompt the user whether he/she wants to 
		/// leave the current page when attempting to:
		/// <code>
		/// window.onbeforeunload = function(e) {
		///		e.returnValue = "Any return string here forces a dialog to appear when user leaves this page"
		///	}
		///	
		/// window.location="http://www.google.com" //prompt is invoked
		/// </code>
		/// </example>
		public extern GenericEventHandler onbeforeunload { get; set; }

		/// <summary>
		/// Fires when a JavaScript error occurs. 
		/// By returning true inside this event, 
		/// JavaScript errors on the page (if any) are suppressed, 
		/// with no error messages popping up:
		/// </summary>
		/// <example>
		/// <code>
		/// window.onerror = function(msg, url, linenumber) {
		///		var logerror = 'Error message: ' + msg + '. Url: ' + url + 'Line Number: ' + linenumber
		///		alert(logerror)
		///		return true
		///	}
		///	</code>
		/// </example>
		public extern ErrorEventHandler onerror { get; set; }
		#endregion

		#region Methods

		/// <summary>
		/// Displays an alert box with a message and an OK button
		/// </summary>
		public extern void alert(object message);

		/// <summary>
		/// Removes focus from the current window
		/// </summary>
		public extern void blur();

		/// <summary>
		/// Cancels a timeout set with setInterval()
		/// </summary>
		public extern void clearInterval(int id);

		/// <summary>
		/// Cancels a timeout set with setTimeout()
		/// </summary>
		public extern void clearTimeout(int id);

		/// <summary>
		/// Closes the current window
		/// </summary>
		public extern void close();

		/// <summary>
		/// Displays a dialog box with a message and an OK and a Cancel button
		/// </summary>
		public extern bool confirm(string message);

		/// <summary>
		/// Creates a pop-up window
		/// </summary>
		public extern Window createPopup();

		/// <summary>
		/// Sets focus to the current window
		/// </summary>
		public extern void focus();

		/// <summary>
		/// Moves a window relative to its current position
		/// </summary>
		public extern void moveBy(int x, int y);

		/// <summary>
		/// Moves a window to the specified position
		/// </summary>
		public extern void moveTo(int x, int y);

		/// <summary>
		/// Opens a new browser window
		/// </summary>
		public extern Window open(string url, string name, string features, bool replace);

		/// <summary>
		/// Prints the contents of the current window
		/// </summary>
		public extern void print();

		/// <summary>
		/// Displays a dialog box that prompts the user for input
		/// </summary>
		public extern string prompt(string message);
		public extern string prompt(string message, object value);

		/// <summary>
		/// Resizes a window by the specified pixels
		/// </summary>
		public extern void resizeBy(int x, int y);

		/// <summary>
		/// Resizes a window to the specified width and height
		/// </summary>
		public extern void resizeTo(int x, int y);

		/// <summary>
		/// Scrolls the content by the specified number of pixels
		/// </summary>
		public extern void scrollBy(int x, int y);

		/// <summary>
		/// Scrolls the content to the specified coordinates
		/// </summary>
		public extern void scrollTo(int x, int y);

		/// <summary>
		/// Evaluates an expression at specified intervals
		/// </summary>
		public extern int setInterval(string expression, int msec);

		/// <summary>
		/// Evaluates an expression after a specified number of milliseconds
		/// </summary>
		public extern int setTimeout(string expression, int msec);

		#endregion
	}
}
