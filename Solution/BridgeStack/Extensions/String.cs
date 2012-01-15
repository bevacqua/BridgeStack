namespace BridgeStack
{
	/// <summary>
	/// String extensions. Mostly syntactic sugar.
	/// </summary>
	public static class StringHelpers
	{
		/// <summary>
		/// Replaces the format item in a specified string with the string representations of a corresponding object in a specified array.
		/// </summary>
		/// <param name="text">A composite format string.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>The formatted string result.</returns>
		public static string FormatWith(this string text, params object[] args)
		{
			return string.Format(text, args);
		}

		/// <summary>
		/// Indicates whether the specified string is null or a System.String.Empty string.
		/// </summary>
		/// <param name="text">The string to test.</param>
		/// <returns>A boolean value indicating the test results.</returns>
		public static bool NullOrEmpty(this string text)
		{
			return string.IsNullOrEmpty(text);
		}
	}
}
