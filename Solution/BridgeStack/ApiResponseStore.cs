using System.Collections.Generic;
using System.Linq;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Internal response cache store for the API.
	/// </summary>
	internal sealed class ApiResponseStore : IApiResponseStore
	{
		/// <summary>
		/// The actual cache dictionary persistor.
		/// </summary>
		private IDictionary<string, IApiResponseCache> Cache { get; set; }

		/// <summary>
		/// Instances the cache dictionary.
		/// </summary>
		public ApiResponseStore()
		{
			Cache = new Dictionary<string, IApiResponseCache>();
		}

		/// <summary>
		/// Remove cached response elements that have become invalid (old).
		/// </summary>
		public void Invalidate()
		{
			Cache = Cache.Where(e => e.Value.IsValid).ToDictionary(p => p.Key, p => p.Value);
		}

		/// <summary>
		/// Attempts to access the internal cache and retrieve a response object without querying the API.
		/// </summary>
		/// <typeparam name="T">The strong type in <see cref="IApiResponse{T}"/>.</typeparam>
		/// <param name="endpoint">The API endpoint</param>
		/// <returns>Returns an API response object if successful, null otherwise.</returns>
		public IApiResponse<T> Get<T>(string endpoint)
		{
			if (Cache.ContainsKey(endpoint))
			{
				IApiResponseCache cache;
				if (Cache.TryGetValue(endpoint, out cache))
				{
					if (cache.IsValid)
					{
						return (IApiResponse<T>)cache.Response;
					}
					Cache.Remove(endpoint);
				}
			}
			return null;
		}

		/// <summary>
		/// Attempts to push API responses into the cache store.
		/// </summary>
		/// <param name="endpoint">The queried API endpoint.</param>
		/// <param name="response">The API response.</param>
		public void Push(string endpoint, IApiResponse response)
		{
			if (endpoint == null)
			{
				return;
			}
			var value = new ApiResponseCache(response);
			if (Cache.ContainsKey(endpoint))
			{
				Cache[endpoint] = value;
			}
			else
			{
				Cache.Add(new KeyValuePair<string, IApiResponseCache>(endpoint, value));
			}
		}
	}
}