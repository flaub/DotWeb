using System;
using H8.Support;

namespace Ext.form {
    /// <summary>
    ///     /**
    ///     Overridable validation definitions. The validations provided are basic and intended to be easily customizable and extended.
    ///     */
    ///     Ext.form.VTypes = function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\form\VTypes.js</jssource>
    [Native]
    public class VTypes  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public VTypes() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static VTypes prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }

        /// <summary>The error text to display when the email validation function returns false</summary>
        public static System.String emailText { get { return null; } set { } }

        /// <summary>
        ///     The keystroke filter mask to be applied on email input.  See the {@link #email} method for
        ///     information about more complex email validation.
        /// </summary>
        public static object emailMask { get { return null; } set { } }

        /// <summary>The error text to display when the url validation function returns false</summary>
        public static System.String urlText { get { return null; } set { } }

        /// <summary>The error text to display when the alpha validation function returns false</summary>
        public static System.String alphaText { get { return null; } set { } }

        /// <summary>The keystroke filter mask to be applied on alpha input</summary>
        public static object alphaMask { get { return null; } set { } }

        /// <summary>The error text to display when the alphanumeric validation function returns false</summary>
        public static System.String alphanumText { get { return null; } set { } }

        /// <summary>The keystroke filter mask to be applied on alphanumeric input</summary>
        public static object alphanumMask { get { return null; } set { } }


        /// <summary>
        ///     The function used to validate email addresses.  Note that this is a very basic validation -- complete
        ///     validation per the email RFC specifications is very complex and beyond the scope of this class, although
        ///     this function can be overridden if a more comprehensive validation scheme is desired.  See the validation
        ///     section of the <a href="http://en.wikipedia.org/wiki/E-mail_address">Wikipedia article on email addresses</a>
        ///     for additional information.
        /// </summary>
        /// <returns></returns>
        public static void email() { return ; }

        /// <summary>
        ///     The function used to validate email addresses.  Note that this is a very basic validation -- complete
        ///     validation per the email RFC specifications is very complex and beyond the scope of this class, although
        ///     this function can be overridden if a more comprehensive validation scheme is desired.  See the validation
        ///     section of the <a href="http://en.wikipedia.org/wiki/E-mail_address">Wikipedia article on email addresses</a>
        ///     for additional information.
        /// </summary>
        /// <param name="value">The email address</param>
        /// <returns></returns>
        public static void email(System.String value) { return ; }

        /// <summary>The function used to validate URLs</summary>
        /// <returns></returns>
        public static void url() { return ; }

        /// <summary>The function used to validate URLs</summary>
        /// <param name="value">The URL</param>
        /// <returns></returns>
        public static void url(System.String value) { return ; }

        /// <summary>The function used to validate alpha values</summary>
        /// <returns></returns>
        public static void alpha() { return ; }

        /// <summary>The function used to validate alpha values</summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static void alpha(System.String value) { return ; }

        /// <summary>The function used to validate alphanumeric values</summary>
        /// <returns></returns>
        public static void alphanum() { return ; }

        /// <summary>The function used to validate alphanumeric values</summary>
        /// <param name="value">The value</param>
        /// <returns></returns>
        public static void alphanum(System.String value) { return ; }



    }
    [Anonymous]
    public class VTypesConfig {

    }


}
