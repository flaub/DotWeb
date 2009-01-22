using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlDom
{
	public abstract class Window
	{
		/// <summary>
		/// Displays an alert box with a message and an OK button
		/// </summary>
		public abstract void alert(string message);

		/// <summary>
		/// Removes focus from the current window
		/// </summary>
		public abstract void blur();

		/// <summary>
		/// Cancels a timeout set with setInterval()
		/// </summary>
		public abstract void clearInterval(object id);

		/// <summary>
		/// Cancels a timeout set with setTimeout()
		/// </summary>
		public abstract void clearTimeout(object id);

		/// <summary>
		/// Closes the current window
		/// </summary>
		public abstract void close();

		/// <summary>
		/// Displays a dialog box with a message and an OK and a Cancel button
		/// </summary>
		public abstract bool confirm(object message);

		/// <summary>
		/// Creates a pop-up window
		/// </summary>
		public abstract void createPopup();

		/// <summary>
		/// Sets focus to the current window
		/// </summary>
		public abstract void focus();

		/// <summary>
		/// Moves a window relative to its current position
		/// </summary>
		public abstract void moveBy();

		/// <summary>
		/// Moves a window to the specified position
		/// </summary>
		public abstract void moveTo();

		/// <summary>
		/// Opens a new browser window
		/// </summary>
		public abstract void open();

		/// <summary>
		/// Prints the contents of the current window
		/// </summary>
		public abstract void print();

		/// <summary>
		/// Displays a dialog box that prompts the user for input
		/// </summary>
		public abstract string prompt(object text);
		public abstract string prompt(object text, object value);

		/// <summary>
		/// Resizes a window by the specified pixels
		/// </summary>
		public abstract void resizeBy();

		/// <summary>
		/// Resizes a window to the specified width and height
		/// </summary>
		public abstract void resizeTo();

		/// <summary>
		/// Scrolls the content by the specified number of pixels
		/// </summary>
		public abstract void scrollBy();

		/// <summary>
		/// Scrolls the content to the specified coordinates
		/// </summary>
		public abstract void scrollTo();

		/// <summary>
		/// Evaluates an expression at specified intervals
		/// </summary>
		public abstract void setInterval();

		/// <summary>
		/// Evaluates an expression after a specified number of milliseconds
		/// </summary>
		public abstract void setTimeout();
	}
}
