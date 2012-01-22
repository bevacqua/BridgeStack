using System;

namespace BridgeStack
{
	/// <summary>
	/// Request throttling is to be handled through this contract.
	/// </summary>
	public interface IRequestThrottler : IStackClientPlugin
	{
		/// <summary>
		/// When necessary, throttles requests in order to prevent flooding the API endpoints.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="endpoint">The API endpoint to query.</param>
		/// <returns>The API response object.</returns>
		IApiResponse<T> Throttle<T>(string endpoint) where T : class;

		/// <summary>
		/// The total amount of requests performed through this request throttler.
		/// </summary>
		int TotalRequests { get; }

		/// <summary>
		/// The amount of completed requests performed through this request throttler.
		/// </summary>
		int CompletedRequests { get; }

		/// <summary>
		/// The amount of requests being concurrently performed.
		/// </summary>
		int ConcurrentRequests { get; }

		/// <summary>
		/// The allowed maximum of requests to be concurrently performed.
		/// </summary>
		int MaxConcurrentRequests { get; set; }

		/// <summary>
		/// The allowed maximum of requests in the sliding timeframe window, at any given time.
		/// </summary>
		int MaxRequestsInTimeframe { get; set; }

		/// <summary>
		/// The sliding timeframe window duration.
		/// </summary>
		TimeSpan SlidingTimeframe { get; set; }
	}
}