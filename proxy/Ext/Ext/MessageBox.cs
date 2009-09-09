using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     <p>Utility class for generating different styles of message boxes.  The alias Ext.Msg can also be used.<p/>
	///     <p>Note that the MessageBox is asynchronous.  Unlike a regular JavaScript <code>alert</code> (which will halt
	///     browser execution), showing a MessageBox will not cause the code to stop.  For this reason, if you have code
	///     that should only run <em>after</em> some user feedback from the MessageBox, you must use a callback function
	///     (see the <code>function</code> parameter for {@link #show} for more details).</p>
	///     <p>Example usage:</p>
	///     <pre><code>
	///     // Basic alert:
	///     Ext.Msg.alert('Status', 'Changes saved successfully.');
	///     // Prompt for user data and process the result using a callback:
	///     Ext.Msg.prompt('Name', 'Please enter your name:', function(btn, text){
	///     if (btn == 'ok'){
	///     // process text value and close...
	///     }
	///     });
	///     // Show a dialog using config options:
	///     Ext.Msg.show({
	///     title:'Save Changes?',
	///     msg: 'You are closing a tab that has unsaved changes. Would you like to save your changes?',
	///     buttons: Ext.Msg.YESNOCANCEL,
	///     fn: processResult,
	///     animEl: 'elId',
	///     icon: Ext.MessageBox.QUESTION
	///     });
	///     </code></pre>
	///     */
	///     Ext.MessageBox = function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\MessageBox.js</jssource>
	public class MessageBox : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public MessageBox() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static MessageBox prototype { get { return S_<MessageBox>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>Button config that displays a single OK button</summary>
		public static object OK { get { return S_<object>(); } set { S_(value); } }

		/// <summary>Button config that displays a single Cancel button</summary>
		public static object CANCEL { get { return S_<object>(); } set { S_(value); } }

		/// <summary>Button config that displays OK and Cancel buttons</summary>
		public static object OKCANCEL { get { return S_<object>(); } set { S_(value); } }

		/// <summary>Button config that displays Yes and No buttons</summary>
		public static object YESNO { get { return S_<object>(); } set { S_(value); } }

		/// <summary>Button config that displays Yes, No and Cancel buttons</summary>
		public static object YESNOCANCEL { get { return S_<object>(); } set { S_(value); } }

		/// <summary>The CSS class that provides the INFO icon image</summary>
		public static System.String INFO { get { return S_<System.String>(); } set { S_(value); } }

		/// <summary>The CSS class that provides the WARNING icon image</summary>
		public static System.String WARNING { get { return S_<System.String>(); } set { S_(value); } }

		/// <summary>The CSS class that provides the QUESTION icon image</summary>
		public static System.String QUESTION { get { return S_<System.String>(); } set { S_(value); } }

		/// <summary>The CSS class that provides the ERROR icon image</summary>
		public static System.String ERROR { get { return S_<System.String>(); } set { S_(value); } }

		/// <summary>The default height in pixels of the message box's multiline textarea if displayed (defaults to 75)</summary>
		public static double defaultTextHeight { get { return S_<double>(); } set { S_(value); } }

		/// <summary>The maximum width in pixels of the message box (defaults to 600)</summary>
		public static double maxWidth { get { return S_<double>(); } set { S_(value); } }

		/// <summary>The minimum width in pixels of the message box (defaults to 100)</summary>
		public static double minWidth { get { return S_<double>(); } set { S_(value); } }

		/// <summary>
		///     The minimum width in pixels of the message box if it is a progress-style dialog.  This is useful
		///     for setting a different minimum width than text-only dialogs may need (defaults to 250)
		/// </summary>
		public static double minProgressWidth { get { return S_<double>(); } set { S_(value); } }

		/// <summary>
		///     An object containing the default button text strings that can be overriden for localized language support.
		///     Supported properties are: ok, cancel, yes and no.  Generally you should include a locale-specific
		///     resource file for handling language support across the framework.
		///     Customize the default text like so: Ext.MessageBox.buttonText.yes = "oui"; //french
		/// </summary>
		public static object buttonText { get { return S_<object>(); } set { S_(value); } }

		/// <summary>Shorthand for {@link Ext.MessageBox}</summary>
		public static object Msg { get { return S_<object>(); } set { S_(value); } }


		/// <summary>Returns a reference to the underlying {@link Ext.Window} element</summary>
		/// <returns>Ext.Window</returns>
		public static void getDialog() { S_(); }

		/// <summary>
		///     Updates the message box body text
		///     the XHTML-compliant non-breaking space character '&amp;#160;')
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void updateText() { S_(); }

		/// <summary>
		///     Updates the message box body text
		///     the XHTML-compliant non-breaking space character '&amp;#160;')
		/// </summary>
		/// <param name="text">(optional) Replaces the message box element's innerHTML with the specified string (defaults to</param>
		/// <returns>Ext.MessageBox</returns>
		public static void updateText(System.String text) { S_(text); }

		/// <summary>
		///     Updates a progress-style message box's text and progress bar.  Only relevant on message boxes
		///     initiated via {@link Ext.MessageBox#progress} or by calling {@link Ext.MessageBox#show} with progress: true.
		///     so that any existing body text will not get overwritten by default unless a new value is passed in)
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void updateProgress() { S_(); }

		/// <summary>
		///     Updates a progress-style message box's text and progress bar.  Only relevant on message boxes
		///     initiated via {@link Ext.MessageBox#progress} or by calling {@link Ext.MessageBox#show} with progress: true.
		///     so that any existing body text will not get overwritten by default unless a new value is passed in)
		/// </summary>
		/// <param name="value">Any number between 0 and 1 (e.g., .5, defaults to 0)</param>
		/// <returns>Ext.MessageBox</returns>
		public static void updateProgress(double value) { S_(value); }

		/// <summary>
		///     Updates a progress-style message box's text and progress bar.  Only relevant on message boxes
		///     initiated via {@link Ext.MessageBox#progress} or by calling {@link Ext.MessageBox#show} with progress: true.
		///     so that any existing body text will not get overwritten by default unless a new value is passed in)
		/// </summary>
		/// <param name="value">Any number between 0 and 1 (e.g., .5, defaults to 0)</param>
		/// <param name="progressText">The progress text to display inside the progress bar (defaults to '')</param>
		/// <returns>Ext.MessageBox</returns>
		public static void updateProgress(double value, System.String progressText) { S_(value, progressText); }

		/// <summary>
		///     Updates a progress-style message box's text and progress bar.  Only relevant on message boxes
		///     initiated via {@link Ext.MessageBox#progress} or by calling {@link Ext.MessageBox#show} with progress: true.
		///     so that any existing body text will not get overwritten by default unless a new value is passed in)
		/// </summary>
		/// <param name="value">Any number between 0 and 1 (e.g., .5, defaults to 0)</param>
		/// <param name="progressText">The progress text to display inside the progress bar (defaults to '')</param>
		/// <param name="msg">The message box's body text is replaced with the specified string (defaults to undefined</param>
		/// <returns>Ext.MessageBox</returns>
		public static void updateProgress(double value, System.String progressText, System.String msg) { S_(value, progressText, msg); }

		/// <summary>Returns true if the message box is currently displayed</summary>
		/// <returns>Boolean</returns>
		public static void isVisible() { S_(); }

		/// <summary>Hides the message box if it is displayed</summary>
		/// <returns>Ext.MessageBox</returns>
		public static void hide() { S_(); }

		/// <summary>
		///     Displays a new message box, or reinitializes an existing message box, based on the config options
		///     passed in. All display functions (e.g. prompt, alert, etc.) on MessageBox call this function internally,
		///     although those calls are basic shortcuts and do not support all of the config options allowed here.
		///     <li><b>animEl</b> : String/Element<div class="sub-desc">An id or Element from which the message box should animate as it
		///     opens and closes (defaults to undefined)</div></li>
		///     <li><b>buttons</b> : Object/Boolean<div class="sub-desc">A button config object (e.g., Ext.MessageBox.OKCANCEL or {ok:'Foo',
		///     cancel:'Bar'}), or false to not show any buttons (defaults to false)</div></li>
		///     <li><b>closable</b> : Boolean<div class="sub-desc">False to hide the top-right close button (defaults to true). Note that
		///     progress and wait dialogs will ignore this property and always hide the close button as they can only
		///     be closed programmatically.</div></li>
		///     <li><b>cls</b> : String<div class="sub-desc">A custom CSS class to apply to the message box's container element</div></li>
		///     <li><b>defaultTextHeight</b> : Number<div class="sub-desc">The default height in pixels of the message box's multiline textarea
		///     if displayed (defaults to 75)</div></li>
		///     <li><b>fn</b> : Function<div class="sub-desc">A callback function which is called when the dialog is dismissed either
		///     by clicking on the configured buttons, or on the dialog close button, or by pressing
		///     the return button to enter input.
		///     <p>Progress and wait dialogs will ignore this option since they do not respond to user
		///     actions and can only be closed programmatically, so any required function should be called
		///     by the same code after it closes the dialog. Parameters passed:<ul>
		///     <li><b>buttonId</b> : String<div class="sub-desc">The ID of the button pressed, one of:<div class="sub-desc"><ul>
		///     <li><tt>ok</tt></li>
		///     <li><tt>yes</tt></li>
		///     <li><tt>no</tt></li>
		///     <li><tt>cancel</tt></li>
		///     </ul></div></div></li>
		///     <li><b>text</b> : String<div class="sub-desc">Value of the input field if either <tt>{@link #show-option-prompt prompt}</tt>
		///     or <tt>{@link #show-option-multiline multiline}</tt> is true</div></li>
		///     </p></div></li>
		///     <li><b>scope</b> : Object<div class="sub-desc">The scope of the callback function</div></li>
		///     <li><b>icon</b> : String<div class="sub-desc">A CSS class that provides a background image to be used as the body icon for the
		///     dialog (e.g. Ext.MessageBox.WARNING or 'custom-class') (defaults to '')</div></li>
		///     <li><b>iconCls</b> : String<div class="sub-desc">The standard {@link Ext.Window#iconCls} to
		///     add an optional header icon (defaults to '')</div></li>
		///     <li><b>maxWidth</b> : Number<div class="sub-desc">The maximum width in pixels of the message box (defaults to 600)</div></li>
		///     <li><b>minWidth</b> : Number<div class="sub-desc">The minimum width in pixels of the message box (defaults to 100)</div></li>
		///     <li><b>modal</b> : Boolean<div class="sub-desc">False to allow user interaction with the page while the message box is
		///     displayed (defaults to true)</div></li>
		///     <li><b>msg</b> : String<div class="sub-desc">A string that will replace the existing message box body text (defaults to the
		///     XHTML-compliant non-breaking space character '&amp;#160;')</div></li>
		///     <a id="show-option-multiline"></a><li><b>multiline</b> : Boolean<div class="sub-desc">
		///     True to prompt the user to enter multi-line text (defaults to false)</div></li>
		///     <li><b>progress</b> : Boolean<div class="sub-desc">True to display a progress bar (defaults to false)</div></li>
		///     <li><b>progressText</b> : String<div class="sub-desc">The text to display inside the progress bar if progress = true (defaults to '')</div></li>
		///     <a id="show-option-prompt"></a><li><b>prompt</b> : Boolean<div class="sub-desc">True to prompt the user to enter single-line text (defaults to false)</div></li>
		///     <li><b>proxyDrag</b> : Boolean<div class="sub-desc">True to display a lightweight proxy while dragging (defaults to false)</div></li>
		///     <li><b>title</b> : String<div class="sub-desc">The title text</div></li>
		///     <li><b>value</b> : String<div class="sub-desc">The string value to set into the active textbox element if displayed</div></li>
		///     <li><b>wait</b> : Boolean<div class="sub-desc">True to display a progress bar (defaults to false)</div></li>
		///     <li><b>waitConfig</b> : Object<div class="sub-desc">A {@link Ext.ProgressBar#waitConfig} object (applies only if wait = true)</div></li>
		///     <li><b>width</b> : Number<div class="sub-desc">The width of the dialog in pixels</div></li>
		///     </ul>
		///     Example usage:
		///     <pre><code>
		///     Ext.Msg.show({
		///     title: 'Address',
		///     msg: 'Please enter your address:',
		///     width: 300,
		///     buttons: Ext.MessageBox.OKCANCEL,
		///     multiline: true,
		///     fn: saveAddress,
		///     animEl: 'addAddressBtn',
		///     icon: Ext.MessageBox.INFO
		///     });
		///     </code></pre>
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void show() { S_(); }

		/// <summary>
		///     Displays a new message box, or reinitializes an existing message box, based on the config options
		///     passed in. All display functions (e.g. prompt, alert, etc.) on MessageBox call this function internally,
		///     although those calls are basic shortcuts and do not support all of the config options allowed here.
		///     <li><b>animEl</b> : String/Element<div class="sub-desc">An id or Element from which the message box should animate as it
		///     opens and closes (defaults to undefined)</div></li>
		///     <li><b>buttons</b> : Object/Boolean<div class="sub-desc">A button config object (e.g., Ext.MessageBox.OKCANCEL or {ok:'Foo',
		///     cancel:'Bar'}), or false to not show any buttons (defaults to false)</div></li>
		///     <li><b>closable</b> : Boolean<div class="sub-desc">False to hide the top-right close button (defaults to true). Note that
		///     progress and wait dialogs will ignore this property and always hide the close button as they can only
		///     be closed programmatically.</div></li>
		///     <li><b>cls</b> : String<div class="sub-desc">A custom CSS class to apply to the message box's container element</div></li>
		///     <li><b>defaultTextHeight</b> : Number<div class="sub-desc">The default height in pixels of the message box's multiline textarea
		///     if displayed (defaults to 75)</div></li>
		///     <li><b>fn</b> : Function<div class="sub-desc">A callback function which is called when the dialog is dismissed either
		///     by clicking on the configured buttons, or on the dialog close button, or by pressing
		///     the return button to enter input.
		///     <p>Progress and wait dialogs will ignore this option since they do not respond to user
		///     actions and can only be closed programmatically, so any required function should be called
		///     by the same code after it closes the dialog. Parameters passed:<ul>
		///     <li><b>buttonId</b> : String<div class="sub-desc">The ID of the button pressed, one of:<div class="sub-desc"><ul>
		///     <li><tt>ok</tt></li>
		///     <li><tt>yes</tt></li>
		///     <li><tt>no</tt></li>
		///     <li><tt>cancel</tt></li>
		///     </ul></div></div></li>
		///     <li><b>text</b> : String<div class="sub-desc">Value of the input field if either <tt>{@link #show-option-prompt prompt}</tt>
		///     or <tt>{@link #show-option-multiline multiline}</tt> is true</div></li>
		///     </p></div></li>
		///     <li><b>scope</b> : Object<div class="sub-desc">The scope of the callback function</div></li>
		///     <li><b>icon</b> : String<div class="sub-desc">A CSS class that provides a background image to be used as the body icon for the
		///     dialog (e.g. Ext.MessageBox.WARNING or 'custom-class') (defaults to '')</div></li>
		///     <li><b>iconCls</b> : String<div class="sub-desc">The standard {@link Ext.Window#iconCls} to
		///     add an optional header icon (defaults to '')</div></li>
		///     <li><b>maxWidth</b> : Number<div class="sub-desc">The maximum width in pixels of the message box (defaults to 600)</div></li>
		///     <li><b>minWidth</b> : Number<div class="sub-desc">The minimum width in pixels of the message box (defaults to 100)</div></li>
		///     <li><b>modal</b> : Boolean<div class="sub-desc">False to allow user interaction with the page while the message box is
		///     displayed (defaults to true)</div></li>
		///     <li><b>msg</b> : String<div class="sub-desc">A string that will replace the existing message box body text (defaults to the
		///     XHTML-compliant non-breaking space character '&amp;#160;')</div></li>
		///     <a id="show-option-multiline"></a><li><b>multiline</b> : Boolean<div class="sub-desc">
		///     True to prompt the user to enter multi-line text (defaults to false)</div></li>
		///     <li><b>progress</b> : Boolean<div class="sub-desc">True to display a progress bar (defaults to false)</div></li>
		///     <li><b>progressText</b> : String<div class="sub-desc">The text to display inside the progress bar if progress = true (defaults to '')</div></li>
		///     <a id="show-option-prompt"></a><li><b>prompt</b> : Boolean<div class="sub-desc">True to prompt the user to enter single-line text (defaults to false)</div></li>
		///     <li><b>proxyDrag</b> : Boolean<div class="sub-desc">True to display a lightweight proxy while dragging (defaults to false)</div></li>
		///     <li><b>title</b> : String<div class="sub-desc">The title text</div></li>
		///     <li><b>value</b> : String<div class="sub-desc">The string value to set into the active textbox element if displayed</div></li>
		///     <li><b>wait</b> : Boolean<div class="sub-desc">True to display a progress bar (defaults to false)</div></li>
		///     <li><b>waitConfig</b> : Object<div class="sub-desc">A {@link Ext.ProgressBar#waitConfig} object (applies only if wait = true)</div></li>
		///     <li><b>width</b> : Number<div class="sub-desc">The width of the dialog in pixels</div></li>
		///     </ul>
		///     Example usage:
		///     <pre><code>
		///     Ext.Msg.show({
		///     title: 'Address',
		///     msg: 'Please enter your address:',
		///     width: 300,
		///     buttons: Ext.MessageBox.OKCANCEL,
		///     multiline: true,
		///     fn: saveAddress,
		///     animEl: 'addAddressBtn',
		///     icon: Ext.MessageBox.INFO
		///     });
		///     </code></pre>
		/// </summary>
		/// <param name="config">The following config options are supported: <ul></param>
		/// <returns>Ext.MessageBox</returns>
		public static void show(object config) { S_(config); }

		/// <summary>
		///     Adds the specified icon to the dialog.  By default, the class 'ext-mb-icon' is applied for default
		///     styling, and the class passed in is expected to supply the background image url. Pass in empty string ('')
		///     to clear any existing icon.  The following built-in icon classes are supported, but you can also pass
		///     in a custom class name:
		///     <pre>
		///     Ext.MessageBox.INFO
		///     Ext.MessageBox.WARNING
		///     Ext.MessageBox.QUESTION
		///     Ext.MessageBox.ERROR
		///     </pre>
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void setIcon() { S_(); }

		/// <summary>
		///     Adds the specified icon to the dialog.  By default, the class 'ext-mb-icon' is applied for default
		///     styling, and the class passed in is expected to supply the background image url. Pass in empty string ('')
		///     to clear any existing icon.  The following built-in icon classes are supported, but you can also pass
		///     in a custom class name:
		///     <pre>
		///     Ext.MessageBox.INFO
		///     Ext.MessageBox.WARNING
		///     Ext.MessageBox.QUESTION
		///     Ext.MessageBox.ERROR
		///     </pre>
		/// </summary>
		/// <param name="icon">A CSS classname specifying the icon's background image url, or empty string to clear the icon</param>
		/// <returns>Ext.MessageBox</returns>
		public static void setIcon(System.String icon) { S_(icon); }

		/// <summary>
		///     Displays a message box with a progress bar.  This message box has no buttons and is not closeable by
		///     the user.  You are responsible for updating the progress bar as needed via {@link Ext.MessageBox#updateProgress}
		///     and closing the message box when the process is complete.
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void progress() { S_(); }

		/// <summary>
		///     Displays a message box with a progress bar.  This message box has no buttons and is not closeable by
		///     the user.  You are responsible for updating the progress bar as needed via {@link Ext.MessageBox#updateProgress}
		///     and closing the message box when the process is complete.
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void progress(System.String title) { S_(title); }

		/// <summary>
		///     Displays a message box with a progress bar.  This message box has no buttons and is not closeable by
		///     the user.  You are responsible for updating the progress bar as needed via {@link Ext.MessageBox#updateProgress}
		///     and closing the message box when the process is complete.
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void progress(System.String title, System.String msg) { S_(title, msg); }

		/// <summary>
		///     Displays a message box with a progress bar.  This message box has no buttons and is not closeable by
		///     the user.  You are responsible for updating the progress bar as needed via {@link Ext.MessageBox#updateProgress}
		///     and closing the message box when the process is complete.
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="progressText">(optional) The text to display inside the progress bar (defaults to '')</param>
		/// <returns>Ext.MessageBox</returns>
		public static void progress(System.String title, System.String msg, System.String progressText) { S_(title, msg, progressText); }

		/// <summary>
		///     Displays a message box with an infinitely auto-updating progress bar.  This can be used to block user
		///     interaction while waiting for a long-running process to complete that does not have defined intervals.
		///     You are responsible for closing the message box when the process is complete.
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void wait() { S_(); }

		/// <summary>
		///     Displays a message box with an infinitely auto-updating progress bar.  This can be used to block user
		///     interaction while waiting for a long-running process to complete that does not have defined intervals.
		///     You are responsible for closing the message box when the process is complete.
		/// </summary>
		/// <param name="msg">The message box body text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void wait(System.String msg) { S_(msg); }

		/// <summary>
		///     Displays a message box with an infinitely auto-updating progress bar.  This can be used to block user
		///     interaction while waiting for a long-running process to complete that does not have defined intervals.
		///     You are responsible for closing the message box when the process is complete.
		/// </summary>
		/// <param name="msg">The message box body text</param>
		/// <param name="title">(optional) The title bar text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void wait(System.String msg, System.String title) { S_(msg, title); }

		/// <summary>
		///     Displays a message box with an infinitely auto-updating progress bar.  This can be used to block user
		///     interaction while waiting for a long-running process to complete that does not have defined intervals.
		///     You are responsible for closing the message box when the process is complete.
		/// </summary>
		/// <param name="msg">The message box body text</param>
		/// <param name="title">(optional) The title bar text</param>
		/// <param name="config">(optional) A {@link Ext.ProgressBar#waitConfig} object</param>
		/// <returns>Ext.MessageBox</returns>
		public static void wait(System.String msg, System.String title, object config) { S_(msg, title, config); }

		/// <summary>
		///     Displays a standard read-only message box with an OK button (comparable to the basic JavaScript alert prompt).
		///     If a callback function is passed it will be called after the user clicks the button, and the
		///     id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void alert() { S_(); }

		/// <summary>
		///     Displays a standard read-only message box with an OK button (comparable to the basic JavaScript alert prompt).
		///     If a callback function is passed it will be called after the user clicks the button, and the
		///     id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void alert(System.String title) { S_(title); }

		/// <summary>
		///     Displays a standard read-only message box with an OK button (comparable to the basic JavaScript alert prompt).
		///     If a callback function is passed it will be called after the user clicks the button, and the
		///     id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void alert(System.String title, System.String msg) { S_(title, msg); }

		/// <summary>
		///     Displays a standard read-only message box with an OK button (comparable to the basic JavaScript alert prompt).
		///     If a callback function is passed it will be called after the user clicks the button, and the
		///     id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <returns>Ext.MessageBox</returns>
		public static void alert(System.String title, System.String msg, Delegate fn) { S_(title, msg, fn); }

		/// <summary>
		///     Displays a standard read-only message box with an OK button (comparable to the basic JavaScript alert prompt).
		///     If a callback function is passed it will be called after the user clicks the button, and the
		///     id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <returns>Ext.MessageBox</returns>
		public static void alert(System.String title, System.String msg, Delegate fn, object scope) { S_(title, msg, fn, scope); }

		/// <summary>
		///     Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm).
		///     If a callback function is passed it will be called after the user clicks either button,
		///     and the id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void confirm() { S_(); }

		/// <summary>
		///     Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm).
		///     If a callback function is passed it will be called after the user clicks either button,
		///     and the id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void confirm(System.String title) { S_(title); }

		/// <summary>
		///     Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm).
		///     If a callback function is passed it will be called after the user clicks either button,
		///     and the id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void confirm(System.String title, System.String msg) { S_(title, msg); }

		/// <summary>
		///     Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm).
		///     If a callback function is passed it will be called after the user clicks either button,
		///     and the id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <returns>Ext.MessageBox</returns>
		public static void confirm(System.String title, System.String msg, Delegate fn) { S_(title, msg, fn); }

		/// <summary>
		///     Displays a confirmation message box with Yes and No buttons (comparable to JavaScript's confirm).
		///     If a callback function is passed it will be called after the user clicks either button,
		///     and the id of the button that was clicked will be passed as the only parameter to the callback
		///     (could also be the top-right close button).
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <returns>Ext.MessageBox</returns>
		public static void confirm(System.String title, System.String msg, Delegate fn, object scope) { S_(title, msg, fn, scope); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt() { S_(); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title) { S_(title); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg) { S_(title, msg); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg, Delegate fn) { S_(title, msg, fn); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg, Delegate fn, object scope) { S_(title, msg, fn, scope); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg, Delegate fn, object scope, bool multiline) { S_(title, msg, fn, scope, multiline); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight</param>
		/// <param name="value">(optional) Default value of the text input element (defaults to '')</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg, Delegate fn, object scope, bool multiline, System.String value) { S_(title, msg, fn, scope, multiline, value); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg, Delegate fn, object scope, double multiline) { S_(title, msg, fn, scope, multiline); }

		/// <summary>
		///     Displays a message box with OK and Cancel buttons prompting the user to enter some text (comparable to JavaScript's prompt).
		///     The prompt can be a single-line or multi-line textbox.  If a callback function is passed it will be called after the user
		///     clicks either button, and the id of the button that was clicked (could also be the top-right
		///     close button) and the text that was entered will be passed as the two parameters to the callback.
		///     property, or the height in pixels to create the textbox (defaults to false / single-line)
		/// </summary>
		/// <param name="title">The title bar text</param>
		/// <param name="msg">The message box body text</param>
		/// <param name="fn">(optional) The callback function invoked after the message box is closed</param>
		/// <param name="scope">(optional) The scope of the callback function</param>
		/// <param name="multiline">(optional) True to create a multiline textbox using the defaultTextHeight</param>
		/// <param name="value">(optional) Default value of the text input element (defaults to '')</param>
		/// <returns>Ext.MessageBox</returns>
		public static void prompt(System.String title, System.String msg, Delegate fn, object scope, double multiline, System.String value) { S_(title, msg, fn, scope, multiline, value); }



	}
}
