using System;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Date Time helpers to assist in JSON deserialization.
	/// </summary>
	public static class UnixDateTimeHelpers
	{
		/// <summary>
		/// Parses a long representation of an Unix Date into a DateTime.
		/// </summary>
		/// <param name="self">The long representation of an Unix Date.</param>
		/// <returns>A DateTime object result.</returns>
		public static DateTime AsUnixDate(this long self)
		{
			DateTime result = new DateTime(1970, 1, 1);
			return result.AddSeconds(self);
		}

		/// <summary>
		/// Parses a DateTime into it's long representation in Unix Date format.
		/// </summary>
		/// <param name="self">The DateTime object to parse.</param>
		/// <returns>The long representation of an Unix Date.</returns>
		public static long ToUnixDate(this DateTime self)
		{
			if (self == DateTime.MinValue)
			{
				return 0;
			}
			DateTime epoch = new DateTime(1970, 1, 1);
			TimeSpan delta = self - epoch;
			if (delta.TotalSeconds < 0)
			{
				throw new ArgumentOutOfRangeException(Error.InvalidUnixEpochErrorMessage);
			}
			return (long)delta.TotalSeconds;
		}
	}
}
