using System;

namespace BridgeStack
{
	/// <summary>
	/// ApiMethodEnum extensions.
	/// </summary>
	internal static class ApiMethodEnumHelpers
	{
		/// <summary>
		/// Gets the life span for cache items based on the extended <see cref="ApiMethodEnum"/> member.
		/// </summary>
		/// <param name="method">The API method for which to calculate the cache life span.</param>
		/// <param name="client">The governing <see cref="IStackClient"/> instance.</param>
		/// <returns>The life span duration after which a cache item is no longer considered fresh.</returns>
		public static TimeSpan? GetCacheLifeSpan(this ApiMethodEnum method, IStackClient client)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (client.Default.CacheLifeSpan.ContainsKey(method))
			{
				return client.Default.CacheLifeSpan[method];
			}
			CacheLifeSpanAttribute lifeSpan = method.GetCustomAttribute<CacheLifeSpanAttribute>();
			if (lifeSpan != null)
			{
				return lifeSpan.Duration;
			}
			return null;
		}
	}
}
