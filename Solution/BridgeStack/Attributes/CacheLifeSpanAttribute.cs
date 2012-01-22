using System;

namespace BridgeStack
{
	/// <summary>
	/// Attribute used to indicate the life span before a cache item decays.
	/// This is verified during cache pushing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	internal sealed class CacheLifeSpanAttribute : Attribute
	{
		/// <summary>
		/// The cache life span duration.
		/// </summary>
		public TimeSpan Duration { get; private set; }

		/// <summary>
		/// Decorator to indicate the time before a cache item entry decays.
		/// </summary>
		/// <param name="days">Number of days.</param>
		/// <param name="hours">Number of hours.</param>
		/// <param name="minutes">Number of minutes.</param>
		/// <param name="seconds">Number of seconds.</param>
		public CacheLifeSpanAttribute(int days = 0, int hours = 0, int minutes = 0, int seconds = 0)
		{
			Duration = new TimeSpan(days, hours, minutes, seconds);
		}
	}
}