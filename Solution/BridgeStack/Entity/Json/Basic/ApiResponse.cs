using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// Strongly typed interface for the API response common "wrapper" object.
	/// <para>https://api.stackexchange.com/docs/wrapper</para>
	/// </summary>
	public sealed class ApiResponse<T> : IApiResponse<T> where T : class
	{
		/// <summary>
		/// The request's response as is, in dynamic format.
		/// </summary>
		public dynamic Dynamic { get; set; }

		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be raised by the bridge or come from the API response itself.
		/// </summary>
		public IBridgeException Exception { get; set; }

		/// <summary>
		/// Indicates the different sources that can be offered by <see cref="IApiResponse{T}"/> implementations.
		/// </summary>
		public ResultSourceEnum Source { get; set; }

		/// <summary>
		/// The <see cref="IStackClient"/> which produced this API response.
		/// </summary>
		public IStackClient SourceClient { get; set; }

		/// <summary>
		/// The remaining amount of API calls that can be executed.
		/// </summary>
		public long? QuotaRemaining { get; set; }

		/// <summary>
		/// The maximum API call quota available to the invoking credentials.
		/// </summary>
		public long? QuotaMax { get; set; }

		/// <summary>
		/// Seconds the application must wait before hitting the same method again.
		/// </summary>
		public int? Backoff { get; set; }

		/// <summary>
		/// Boolean value indicating whether there are more pages available.
		/// </summary>
		public bool? HasMore { get; set; }

		/// <summary>
		/// Number indicating the total count of elements that satisfy this query.
		/// </summary>
		public long? Total { get; set; }

		/// <summary>
		/// The type of elements being returned in the <see cref="IApiResponse{T}.Items"/> collection.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// The list of <see cref="IApiResponse.Type"/> returned by the API response.
		/// </summary>
		public IList<T> Items { get; set; }
	}
}