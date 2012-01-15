using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack
{
	/// <summary>
	/// Wraps an API response object in a cache entry.
	/// </summary>
	internal sealed class ApiResponseCache : IApiResponseCache
	{
		public readonly TimeSpan LifeSpan = TimeSpan.FromMinutes(1);

		/// <summary>
		/// Creates a cache item out of an API response.
		/// </summary>
		/// <param name="response">The API response object.</param>
		public ApiResponseCache(IApiResponse response)
		{
			Created = DateTime.Now;
			Response = response;
		}

		/// <summary>
		/// The date the response was saved into the cache.
		/// </summary>
		public DateTime Created { get; private set; }
		/// <summary>
		/// The response at the time.
		/// </summary>
		public IApiResponse Response { get; private set; }
		/// <summary>
		/// Whether this cache entry is still valid.
		/// </summary>
		public bool IsValid
		{
			get { return  Created + LifeSpan > DateTime.Now; }
		}
	}
}