using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Request throttling is to be handled through this object.
	/// </summary>
	internal sealed class RequestThrottler : IRequestThrottler
	{
		/// <summary>
		/// The parent <see cref="IStackClient"/>.
		/// </summary>
		public IStackClient Client { get; set; }

		/// <summary>
		/// The total amount of requests performed through this request throttler.
		/// </summary>
		private int _totalRequests;

		/// <summary>
		/// The total amount of requests performed through this request throttler.
		/// </summary>
		public int TotalRequests
		{
			get { return _totalRequests; }
		}

		/// <summary>
		/// The amount of completed requests performed through this request throttler.
		/// </summary>
		public int CompletedRequests
		{
			get { return _totalRequests - _concurrentRequests; }
		}

		/// <summary>
		/// The amount of requests being concurrently performed.
		/// </summary>
		private int _concurrentRequests;

		/// <summary>
		/// The amount of requests being concurrently performed.
		/// </summary>
		public int ConcurrentRequests
		{
			get
			{
				return _concurrentRequests;
			}
		}

		/// <summary>
		/// The allowed maximum of requests to be concurrently performed.
		/// </summary>
		public int MaxConcurrentRequests { get; set; }

		/// <summary>
		/// The allowed maximum of requests in the sliding timeframe window, at any given time.
		/// </summary>
		public int MaxRequestsInTimeframe { get; set; }

		/// <summary>
		/// The sliding timeframe window duration.
		/// </summary>
		public TimeSpan SlidingTimeframe { get; set; }

		/// <summary>
		/// Concurrent queue registry storing the time at which requests were introduced.
		/// </summary>
		private readonly ConcurrentQueue<DateTime> _requestStartTime;

		/// <summary>
		/// Instances a request throttler object.
		/// </summary>
		/// <param name="maxConcurrentRequests">The allowed maximum of requests to be concurrently performed. Defaults at 15.</param>
		/// <param name="maxRequestsInWindow">The allowed maximum of requests in the sliding time window, at any given time. Defaults at 30.</param>
		/// <param name="slidingTimeframe">The sliding timeframe window duration in seconds. Defaults at 3 seconds.</param>
		public RequestThrottler(int maxConcurrentRequests = 15, int maxRequestsInWindow = 30, int slidingTimeframe = 3)
		{
			MaxConcurrentRequests = maxConcurrentRequests;
			MaxRequestsInTimeframe = maxRequestsInWindow;
			SlidingTimeframe = TimeSpan.FromSeconds(slidingTimeframe);
			_requestStartTime = new ConcurrentQueue<DateTime>();
		}

		/// <summary>
		/// When necessary, throttles requests in order to prevent flooding the API endpoints.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="endpoint">The API endpoint to query.</param>
		/// <returns>The API response object.</returns>
		public IApiResponse<T> Throttle<T>(string endpoint) where T : class
		{
			while (ConcurrentRequests >= MaxConcurrentRequests)
			{
				using (AutoResetEvent signal = new AutoResetEvent(false))
				{
					signal.WaitOne(100);
				}
			}
			if (_requestStartTime.Count >= MaxRequestsInTimeframe)
			{
				DateTime start;
				if (_requestStartTime.TryDequeue(out start))
				{
					TimeSpan delta = DateTime.Now - start;
					TimeSpan delay = SlidingTimeframe - delta;
					if (delay > TimeSpan.Zero)
					{
						using (AutoResetEvent signal = new AutoResetEvent(false))
						{
							signal.WaitOne(delay);
						}
					}
				}
			}
			_requestStartTime.Enqueue(DateTime.Now);
			return PerformRequest<T>(endpoint);
		}

		/// <summary>
		/// Actually performs a request against the API, and returns the response object.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="endpoint">The API endpoint to query.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> PerformRequest<T>(string endpoint) where T : class
		{
			Client.EventLog.InfoFormat(Events.ApiRequest, endpoint);
			Interlocked.Increment(ref _totalRequests);
			Interlocked.Increment(ref _concurrentRequests);
			string responseText;
			using (WebClient client = new ApiWebClient())
			{
				responseText = client.DownloadString(endpoint);
			}
			Interlocked.Decrement(ref _concurrentRequests);
			IApiResponse<T> result = responseText.DeserializeJson<ApiResponse<T>>();
			result.Dynamic = responseText.DeserializeJson();
			result.Source = ResultSourceEnum.Api;
			return result;
		}
	}
}