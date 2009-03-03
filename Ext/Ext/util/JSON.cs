using System;
using DotWeb.Client;

namespace Ext.util {
	/// <summary>
	///     /**
	///     Modified version of Douglas Crockford"s json.js that doesn"t
	///     mess with the Object prototype
	///     http://www.json.org/js.html
	///     */
	///     Ext.util.JSON = new (function(){
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\util\JSON.js</jssource>
	public class JSON : DotWeb.Client.JsNativeBase {

		/// <summary>Auto-generated default constructor</summary>
		/// <returns></returns>
		public JSON() { C_(); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static JSON prototype { get { return S_<JSON>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }


		/// <summary>Encodes an Object, Array or other value</summary>
		/// <returns>String</returns>
		public static void encode() { S_(); }

		/// <summary>Encodes an Object, Array or other value</summary>
		/// <param name="o">The variable to encode</param>
		/// <returns>String</returns>
		public static void encode(object o) { S_(o); }

		/// <summary>Decodes (parses) a JSON string to an object. If the JSON is invalid, this function throws a SyntaxError.</summary>
		/// <returns>Object</returns>
		public static void decode() { S_(); }

		/// <summary>Decodes (parses) a JSON string to an object. If the JSON is invalid, this function throws a SyntaxError.</summary>
		/// <param name="json">The JSON string</param>
		/// <returns>Object</returns>
		public static void decode(System.String json) { S_(json); }



	}
}
