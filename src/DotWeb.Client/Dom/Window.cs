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
	public delegate void GenericEventHandler();
	public delegate bool ErrorEventHandler(string msg, string url, int line);

	[JsNamespace()]
	public class Window : JsNativeBase
	{
		public static Window Instance {
			[JsCode("return $wnd;")]
			get { return S_<Window>(); }
		}

		#region Properties

		[JsIntrinsic]
		public Document document { get { return _<Document>(); } }

		#endregion

		#region Events

		/// <summary>
		/// Fires when the window loses focus.
		/// </summary>
		[JsIntrinsic]
		public GenericEventHandler onblur { get { return _<GenericEventHandler>(); } set { _(value); } }

		/// <summary>
		/// Fires when the focus is set on the current window.
		/// </summary>
		[JsIntrinsic]
		public GenericEventHandler onfocus { get { return _<GenericEventHandler>(); } set { _(value); } }

		/// <summary>
		/// Fires when the window is resized.
		/// </summary>
		[JsIntrinsic]
		public GenericEventHandler onresize { get { return _<GenericEventHandler>(); } set { _(value); } }

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
		[JsIntrinsic]
		public GenericEventHandler onscroll { get { return _<GenericEventHandler>(); } set { _(value); } }

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
		[JsIntrinsic]
		public GenericEventHandler onbeforeunload { get { return _<GenericEventHandler>(); } set { _(value); } }

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
		[JsIntrinsic]
		public ErrorEventHandler onerror { get { return _<ErrorEventHandler>(); } set { _(value); } }
		#endregion

		#region Methods

		/// <summary>
		/// Displays an alert box with a message and an OK button
		/// </summary>
		public void alert(object message) { _(message); }

		/// <summary>
		/// Removes focus from the current window
		/// </summary>
		public void blur() { _(); }

		/// <summary>
		/// Cancels a timeout set with setInterval()
		/// </summary>
		public void clearInterval(int id) { _(id); }

		/// <summary>
		/// Cancels a timeout set with setTimeout()
		/// </summary>
		public void clearTimeout(int id) { _(id); }

		/// <summary>
		/// Closes the current window
		/// </summary>
		public void close() { _(); }

		/// <summary>
		/// Displays a dialog box with a message and an OK and a Cancel button
		/// </summary>
		public bool confirm(string message) { return _<bool>(message); }

		/// <summary>
		/// Creates a pop-up window
		/// </summary>
		public Window createPopup() { return _<Window>(); }

		/// <summary>
		/// Sets focus to the current window
		/// </summary>
		public void focus() { _(); }

		/// <summary>
		/// Moves a window relative to its current position
		/// </summary>
		public void moveBy(int x, int y) { _(x, y); }

		/// <summary>
		/// Moves a window to the specified position
		/// </summary>
		public void moveTo(int x, int y) { _(x, y); }

		/// <summary>
		/// Opens a new browser window
		/// </summary>
		public Window open(string url, string name, string features, bool replace) { return _<Window>(url, name, features, replace); }

		/// <summary>
		/// Prints the contents of the current window
		/// </summary>
		public void print() { _(); }

		/// <summary>
		/// Displays a dialog box that prompts the user for input
		/// </summary>
		public string prompt(string message) { return _<string>(message); }
		public string prompt(string message, object value) { return _<string>(message, value); }

		/// <summary>
		/// Resizes a window by the specified pixels
		/// </summary>
		public void resizeBy(int x, int y) { _(x, y); }

		/// <summary>
		/// Resizes a window to the specified width and height
		/// </summary>
		public void resizeTo(int x, int y) { _(x, y); }

		/// <summary>
		/// Scrolls the content by the specified number of pixels
		/// </summary>
		public void scrollBy(int x, int y) { _(x, y); }

		/// <summary>
		/// Scrolls the content to the specified coordinates
		/// </summary>
		public void scrollTo(int x, int y) { _(x, y); }

		/// <summary>
		/// Evaluates an expression at specified intervals
		/// </summary>
		public int setInterval(string expression, int msec) { return _<int>(expression, msec); }

		/// <summary>
		/// Evaluates an expression after a specified number of milliseconds
		/// </summary>
		public int setTimeout(string expression, int msec) { return _<int>(expression, msec); }

		#endregion
	}
}
