using System;

namespace BridgeStack.Common
{
	public static class StringExtensions
	{
		public static string FormatWith(this string text, params object[] args)
		{
			return string.Format(text, args);
		}

		public static bool NullOrEmpty(this string text)
		{
			return string.IsNullOrEmpty(text);
		}
	}
}
