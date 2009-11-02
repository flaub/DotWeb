using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext.form {
	/// <summary>
	///     /**
	///     Overridable validation definitions. The validations provided are basic and intended to be easily customizable and extended.
	///     */
	///     Ext.form.VTypes = function(){
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\form\VTypes.js</jssource>
	public class VTypes : System.DotWeb.JsObject {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public extern VTypes();

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static VTypes prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>The error text to display when the email validation function returns false</summary>
		public extern static string emailText { get; set; }

		/// <summary>
		///     The keystroke filter mask to be applied on email input.  See the {@link #email} method for
		///     information about more complex email validation.
		/// </summary>
		public extern static object emailMask { get; set; }

		/// <summary>The error text to display when the url validation function returns false</summary>
		public extern static string urlText { get; set; }

		/// <summary>The error text to display when the alpha validation function returns false</summary>
		public extern static string alphaText { get; set; }

		/// <summary>The keystroke filter mask to be applied on alpha input</summary>
		public extern static object alphaMask { get; set; }

		/// <summary>The error text to display when the alphanumeric validation function returns false</summary>
		public extern static string alphanumText { get; set; }

		/// <summary>The keystroke filter mask to be applied on alphanumeric input</summary>
		public extern static object alphanumMask { get; set; }


		/// <summary>
		///     The function used to validate email addresses.  Note that this is a very basic validation -- complete
		///     validation per the email RFC specifications is very complex and beyond the scope of this class, although
		///     this function can be overridden if a more comprehensive validation scheme is desired.  See the validation
		///     section of the <a href="http://en.wikipedia.org/wiki/E-mail_address">Wikipedia article on email addresses</a>
		///     for additional information.
		/// </summary>
		/// <returns></returns>
		public extern static void email();

		/// <summary>
		///     The function used to validate email addresses.  Note that this is a very basic validation -- complete
		///     validation per the email RFC specifications is very complex and beyond the scope of this class, although
		///     this function can be overridden if a more comprehensive validation scheme is desired.  See the validation
		///     section of the <a href="http://en.wikipedia.org/wiki/E-mail_address">Wikipedia article on email addresses</a>
		///     for additional information.
		/// </summary>
		/// <param name="value">The email address</param>
		/// <returns></returns>
		public extern static void email(string value);

		/// <summary>The function used to validate URLs</summary>
		/// <returns></returns>
		public extern static void url();

		/// <summary>The function used to validate URLs</summary>
		/// <param name="value">The URL</param>
		/// <returns></returns>
		public extern static void url(string value);

		/// <summary>The function used to validate alpha values</summary>
		/// <returns></returns>
		public extern static void alpha();

		/// <summary>The function used to validate alpha values</summary>
		/// <param name="value">The value</param>
		/// <returns></returns>
		public extern static void alpha(string value);

		/// <summary>The function used to validate alphanumeric values</summary>
		/// <returns></returns>
		public extern static void alphanum();

		/// <summary>The function used to validate alphanumeric values</summary>
		/// <param name="value">The value</param>
		/// <returns></returns>
		public extern static void alphanum(string value);



	}
}
