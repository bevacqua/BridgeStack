using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack
{
	/// <summary>
	/// Wraps an API response object in a cache entry.
	/// </summary>
	internal interface IApiResponseCache
	{
		/// <summary>
		/// The date the response was saved into the cache.
		/// </summary>
		DateTime Created { get; }
		/// <summary>
		/// The response at the time.
		/// </summary>
		IApiResponse Response { get; }
		/// <summary>
		/// Whether this cache entry is still valid.
		/// </summary>
		bool IsValid { get; }
	}
}