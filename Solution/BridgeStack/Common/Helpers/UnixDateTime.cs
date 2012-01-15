using System;

namespace BridgeStack.Common
{
	public static class UnixDateTimeHelpers
	{
		private const string InvalidUnixEpochErrorMessage = "Unix epoch starts January 1st, 1970";

		/// <summary>
		///   Convert a long into a DateTime
		/// </summary>
		public static DateTime FromUnixTime(this Int64 self)
		{
			DateTime result = new DateTime(1970, 1, 1);
			return result.AddSeconds(self);
		}

		/// <summary>
		///   Convert a DateTime into a long
		/// </summary>
		public static Int64 ToUnixTime(this DateTime self)
		{
			if (self == DateTime.MinValue)
			{
				return 0;
			}
			DateTime epoch = new DateTime(1970, 1, 1);
			TimeSpan delta = self - epoch;
			if (delta.TotalSeconds < 0)
			{
				throw new ArgumentOutOfRangeException(InvalidUnixEpochErrorMessage);
			}
			return (long)delta.TotalSeconds;
		}
	}
}
