using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotWeb.Core;

namespace HtmlDom
{
	public class Window : JsNativeBase
	{
		Document document { get { return _<Document>(); } }

		/// <summary>
		/// Displays an alert box with a message and an OK button
		/// </summary>
		void alert(string message) { _(message); }

		/// <summary>
		/// Removes focus from the current window
		/// </summary>
		void blur() { _(); }

		/// <summary>
		/// Cancels a timeout set with setInterval()
		/// </summary>
		void clearInterval(int id) { _(id); }

		/// <summary>
		/// Cancels a timeout set with setTimeout()
		/// </summary>
		void clearTimeout(int id) { _(id); }

		/// <summary>
		/// Closes the current window
		/// </summary>
		void close() { _(); }

		/// <summary>
		/// Displays a dialog box with a message and an OK and a Cancel button
		/// </summary>
		bool confirm(string message) { return _<bool>(message); }

		/// <summary>
		/// Creates a pop-up window
		/// </summary>
		Window createPopup() { return _<Window>(); }

		/// <summary>
		/// Sets focus to the current window
		/// </summary>
		void focus() { _(); }

		/// <summary>
		/// Moves a window relative to its current position
		/// </summary>
		void moveBy(int x, int y) { _(x, y); }

		/// <summary>
		/// Moves a window to the specified position
		/// </summary>
		void moveTo(int x, int y) { _(x, y); }

		/// <summary>
		/// Opens a new browser window
		/// </summary>
		Window open(string url, string name, string features, bool replace) { return _<Window>(url, name, features, replace); }

		/// <summary>
		/// Prints the contents of the current window
		/// </summary>
		void print() { _(); }

		/// <summary>
		/// Displays a dialog box that prompts the user for input
		/// </summary>
		string prompt(string message) { return _<string>(message); }
		string prompt(string message, object value) { return _<string>(message, value); }

		/// <summary>
		/// Resizes a window by the specified pixels
		/// </summary>
		void resizeBy(int x, int y) { _(x, y); }

		/// <summary>
		/// Resizes a window to the specified width and height
		/// </summary>
		void resizeTo(int x, int y) { _(x, y); }

		/// <summary>
		/// Scrolls the content by the specified number of pixels
		/// </summary>
		void scrollBy(int x, int y) { _(x, y); }

		/// <summary>
		/// Scrolls the content to the specified coordinates
		/// </summary>
		void scrollTo(int x, int y) { _(x, y); }

		/// <summary>
		/// Evaluates an expression at specified intervals
		/// </summary>
		int setInterval(string expression, int msec) { return _<int>(expression, msec); }

		/// <summary>
		/// Evaluates an expression after a specified number of milliseconds
		/// </summary>
		int setTimeout(string expression, int msec) { return _<int>(expression, msec); }
	}
}
