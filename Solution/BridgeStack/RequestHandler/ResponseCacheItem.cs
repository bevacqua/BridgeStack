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
		public readonly TimeSpan LifeSpan = TimeSpan.FromMinutes(1);

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
			get { return Updated + LifeSpan > DateTime.Now; }
		}

		/// <summary>
		/// The state this cache item is currently in.
		/// </summary>
		public CacheItemStateEnum State { get; private set; }

		/// <summary>
		/// Creates a cache item out of an API response.
		/// </summary>
		/// <param name="response">The API response object.</param>
		public ResponseCacheItem(IApiResponse<T> response)
		{
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
			State = response == null ? CacheItemStateEnum.Processing : CacheItemStateEnum.Cached;
		}
	}
}