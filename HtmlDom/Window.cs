using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H8.Support;

namespace HtmlDom
{
	public static class Window
	{
		//public static IWindow Window {
		//    get {
		//        return null;
		//    }
		//}
	}

	public interface IWindow
	{
		Document document { get; }

		/// <summary>
		/// Displays an alert box with a message and an OK button
		/// </summary>
		void alert(string message);

		/// <summary>
		/// Removes focus from the current window
		/// </summary>
		void blur();

		/// <summary>
		/// Cancels a timeout set with setInterval()
		/// </summary>
		void clearInterval(int id);

		/// <summary>
		/// Cancels a timeout set with setTimeout()
		/// </summary>
		void clearTimeout(int id);

		/// <summary>
		/// Closes the current window
		/// </summary>
		void close();

		/// <summary>
		/// Displays a dialog box with a message and an OK and a Cancel button
		/// </summary>
		bool confirm(string message);

		/// <summary>
		/// Creates a pop-up window
		/// </summary>
		void createPopup();

		/// <summary>
		/// Sets focus to the current window
		/// </summary>
		void focus();

		/// <summary>
		/// Moves a window relative to its current position
		/// </summary>
		void moveBy(int x, int y);

		/// <summary>
		/// Moves a window to the specified position
		/// </summary>
		void moveTo(int x, int y);

		/// <summary>
		/// Opens a new browser window
		/// </summary>
		IWindow open(string url, string name, string features, bool replace);

		/// <summary>
		/// Prints the contents of the current window
		/// </summary>
		void print();

		/// <summary>
		/// Displays a dialog box that prompts the user for input
		/// </summary>
		string prompt(string message);
		string prompt(string message, object value);

		/// <summary>
		/// Resizes a window by the specified pixels
		/// </summary>
		void resizeBy(int x, int y);

		/// <summary>
		/// Resizes a window to the specified width and height
		/// </summary>
		void resizeTo(int x, int y);

		/// <summary>
		/// Scrolls the content by the specified number of pixels
		/// </summary>
		void scrollBy(int x, int y);

		/// <summary>
		/// Scrolls the content to the specified coordinates
		/// </summary>
		void scrollTo(int x, int y);

		/// <summary>
		/// Evaluates an expression at specified intervals
		/// </summary>
		int setInterval(string expression, int msec);

		/// <summary>
		/// Evaluates an expression after a specified number of milliseconds
		/// </summary>
		int setTimeout(string expression, int msec);
	}
}
