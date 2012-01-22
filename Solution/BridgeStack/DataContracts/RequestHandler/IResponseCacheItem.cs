using System;

namespace BridgeStack
{
	/// <summary>
	/// Wraps a response object in a cache item.
	/// </summary>
	public interface IResponseCacheItem<T> : IResponseCacheItem where T : class
	{
		/// <summary>
		/// The cached response.
		/// </summary>
		IApiResponse<T> Response { get; }
		/// <summary>
		/// Updates a cache item with a new API response object.
		/// </summary>
		/// <param name="response">The API response object.</param>
		void UpdateResponse(IApiResponse<T> response);
	}

	/// <summary>
	/// Wraps a response object in a cache item.
	/// </summary>
	public interface IResponseCacheItem
	{
		/// <summary>
		/// The date the response was last updated into the cache.
		/// </summary>
		DateTime Updated { get; }
		/// <summary>
		/// Whether this cache item is still fresh.
		/// </summary>
		bool IsFresh { get; }
		/// <summary>
		/// The state this cache item is currently in.
		/// </summary>
		CacheItemStateEnum State { get; }
	}
}