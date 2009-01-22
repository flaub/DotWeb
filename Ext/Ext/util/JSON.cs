using System;
using H8.Support;

namespace Ext.util {
    /// <summary>
    ///     /**
    ///     Modified version of Douglas Crockford"s json.js that doesn"t
    ///     mess with the Object prototype
    ///     http://www.json.org/js.html
    ///     */
    ///     Ext.util.JSON = new (function(){
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\JSON.js</jssource>
    [Native]
    public class JSON  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public JSON() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static JSON prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }


        /// <summary>Encodes an Object, Array or other value</summary>
        /// <returns>String</returns>
        public static System.String encode() { return null; }

        /// <summary>Encodes an Object, Array or other value</summary>
        /// <param name="o">The variable to encode</param>
        /// <returns>String</returns>
        public static System.String encode(object o) { return null; }

        /// <summary>Decodes (parses) a JSON string to an object. If the JSON is invalid, this function throws a SyntaxError.</summary>
        /// <returns>Object</returns>
        public static object decode() { return null; }

        /// <summary>Decodes (parses) a JSON string to an object. If the JSON is invalid, this function throws a SyntaxError.</summary>
        /// <param name="json">The JSON string</param>
        /// <returns>Object</returns>
        public static object decode(System.String json) { return null; }



    }
    [Anonymous]
    public class JSONConfig {

    }


}
