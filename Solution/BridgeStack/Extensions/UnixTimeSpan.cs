using System;

namespace BridgeStack
{
	/// <summary>
	/// Time Span helpers to assist in JSON deserialization.
	/// </summary>
	public static class UnixTimeSpanHelpers
	{
		/// <summary>
		/// Parses a long representation of an Unix TimeSpan into a TimeSpan.
		/// </summary>
		/// <param name="self">The long representation of an Unix TimeSpan.</param>
		/// <returns>A TimeSpan object result.</returns>
		public static TimeSpan AsUnixTime(this long self)
		{
			return TimeSpan.FromSeconds(self);
		}

		/// <summary>
		/// Parses a TimeSpan into it's long representation in Unix Date format.
		/// </summary>
		/// <param name="self">The TimeSpan object to parse.</param>
		/// <returns>The long representation of an Unix Date.</returns>
		public static long ToUnixTime(this TimeSpan self)
		{
			return (long)self.TotalSeconds;
		}
	}
}