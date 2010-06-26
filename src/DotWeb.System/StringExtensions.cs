namespace System
{
	public static class StringExtensions
	{
		/// <summary>
		/// Returns a String containing the character at position pos in the String resulting from converting this object to a 
		/// String. If there is no character at that position, the result is the empty String. The result is a String value, not a 
		/// String object. 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		[JsMacro("{1}.charAt({2})")]
		public static extern string CharAt(this string str, int pos);

		/// <summary>
		/// Returns a Number (a nonnegative integer less than 216) representing the code unit value of the character at 
		/// position  pos in the String resulting from converting this object to a String. If there is no character at that 
		/// position, the result is NaN. 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		[JsMacro("{1}.charCodeAt({2})")]
		public static extern int CharCodeAt(this string str, int pos);

		[JsMacro("{1}.valueOf({2})")]
		public static extern string ValueOf(this string str);
	}
}
