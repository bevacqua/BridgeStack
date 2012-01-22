using System.Collections.Concurrent;
using System.Threading;

namespace BridgeStack
{
	/// <summary>
	/// Internal response cache store for the API.
	/// </summary>
	internal sealed class ResponseCache : IResponseCache
	{
		/// <summary>
		/// The actual cache dictionary persistor.
		/// </summary>
		private ConcurrentDictionary<string, IResponseCacheItem> Cache { get; set; }

		/// <summary>
		/// The parent <see cref="IStackClient"/>.
		/// </summary>
		public IStackClient Client { get; set; }

		/// <summary>
		/// Instances the cache dictionary.
		/// </summary>
		public ResponseCache()
		{
			Cache = new ConcurrentDictionary<string, IResponseCacheItem>();
		}

		/// <summary>
		/// Attempts to access the internal cache and retrieve a response cache item without querying the API.
		/// <para>If the endpoint is not present in the cache yet, null is returned, but the endpoint is added to the cache.</para>
		/// <para>If the endpoint is present, it means the request is being processed. In this case we will wait on the processing to end before returning a result.</para>
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <param name="pushEmpty">True to push an empty value into the cache if the endpoint isn't present yet.</param>
		/// <returns>Returns an API response cache item if successful, null otherwise.</returns>
		public IResponseCacheItem<T> Get<T>(IApiEndpointBuilder builder, bool pushEmpty = false) where T : class
		{
			return Get<T>(builder, pushEmpty, 0);
		}

		/// <summary>
		/// Attempts to access the internal cache and retrieve a response cache item without querying the API.
		/// <para>If the endpoint is not present in the cache yet, null is returned, but the endpoint is added to the cache.</para>
		/// <para>If the endpoint is present, it means the request is being processed. In this case we will wait on the processing to end before returning a result.</para>
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <param name="pushEmpty">True to push an empty value into the cache if the endpoint isn't present yet.</param>
		/// <param name="retries">The amount of failed push attempts.</param>
		/// <returns>Returns an API response cache item if successful, null otherwise.</returns>
		private IResponseCacheItem<T> Get<T>(IApiEndpointBuilder builder, bool pushEmpty, int retries) where T : class
		{
			string endpoint = builder.ToString();
			IResponseCacheItem cacheItem;
			if (Cache.TryGetValue(endpoint, out cacheItem))
			{
				while (cacheItem.IsFresh && cacheItem.State == CacheItemStateEnum.Processing)
				{
					using (AutoResetEvent signal = new AutoResetEvent(false))
					{
						signal.WaitOne(50);
					}
				}
				if (cacheItem.IsFresh && cacheItem.State == CacheItemStateEnum.Cached)
				{
					return cacheItem as IResponseCacheItem<T>; // avoid raising exceptions when improperly invoked.
				}
				IResponseCacheItem value;
				Cache.TryRemove(endpoint, out value);
			}
			if (!pushEmpty || Push<T>(builder, null) || retries > 1) // max retries, sanity.
			{
				return null;
			}
			else
			{
				return Get<T>(builder, true, ++retries); // retry push.
			}
		}

		/// <summary>
		/// Attempts to push API responses into the cache store.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <param name="response">The API response.</param>
		/// <returns>True if the operation was successful, false otherwise.</returns>
		public bool Push<T>(IApiEndpointBuilder builder, IApiResponse<T> response) where T : class
		{
			string endpoint = builder.ToString();
			if (endpoint.NullOrEmpty())
			{
				return false;
			}
			IResponseCacheItem item;
			if (Cache.TryGetValue(endpoint, out item))
			{
				((IResponseCacheItem<T>)item).UpdateResponse(response);
				return true;
			}
			else
			{
				item = new ResponseCacheItem<T>(response);
				return Cache.TryAdd(endpoint, item);
			}
		}
	}
}