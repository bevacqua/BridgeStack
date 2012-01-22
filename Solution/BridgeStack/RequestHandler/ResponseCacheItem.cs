using System;

namespace BridgeStack
{
	/// <summary>
	/// Wraps a response object in a cache item.
	/// </summary>
	internal sealed class ResponseCacheItem<T> : IResponseCacheItem<T> where T : class
	{
		/// <summary>
		/// Default life span of a cache item object.
		/// </summary>
		public readonly TimeSpan DefaultLifeSpan = TimeSpan.FromMinutes(1);

		/// <summary>
		/// Life span of this particular response cache item object instance.
		/// </summary>
		public TimeSpan LifeSpan { get; private set; }

		/// <summary>
		/// The date the response was last updated into the cache.
		/// </summary>
		public DateTime Updated { get; private set; }

		/// <summary>
		/// The response at the time.
		/// </summary>
		public IApiResponse<T> Response { get; private set; }

		/// <summary>
		/// Whether this cache item is still fresh.
		/// </summary>
		public bool IsFresh
		{
			get
			{
				TimeSpan lifeSpan = LifeSpan;
				if (State == CacheItemStateEnum.Processing) // time out consistently during request processing.
				{
					lifeSpan = DefaultLifeSpan;
				}
				return Updated + lifeSpan > DateTime.Now;
			}
		}

		/// <summary>
		/// The state this cache item is currently in.
		/// </summary>
		public CacheItemStateEnum State
		{
			get { return Response == null ? CacheItemStateEnum.Processing : CacheItemStateEnum.Cached; }
		}

		/// <summary>
		/// Creates a cache item out of an API response.
		/// </summary>
		/// <param name="response">The API response object.</param>
		/// <param name="builder">The API endpoint builder that generated the endpoint the response came from.</param>
		public ResponseCacheItem(IApiResponse<T> response, IApiEndpointBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}
			LifeSpan = builder.Client.Cache.GetCacheLifeSpan(builder) ?? DefaultLifeSpan;
			UpdateResponse(response);
		}

		/// <summary>
		/// Updates a cache item with a new API response object.
		/// </summary>
		/// <param name="response">The API response object.</param>
		public void UpdateResponse(IApiResponse<T> response)
		{
			Updated = DateTime.Now;
			Response = response;
		}
	}
}