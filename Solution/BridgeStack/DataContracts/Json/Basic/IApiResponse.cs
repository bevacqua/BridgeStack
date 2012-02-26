using System.Collections.Generic;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Strongly typed interface for the API response common "wrapper" object.
	/// <para>https://api.stackexchange.com/docs/wrapper</para>
	/// </summary>
	/// <typeparam name="T">The strong type for elements in the <see cref="Items"/> collections.</typeparam>
	public interface IApiResponse<T> : IApiResponse where T : class
	{
		/// <summary>
		/// The list of <see cref="IApiResponse.Type"/> returned by the API response.
		/// </summary>
		[JsonProperty("items")]
		IList<T> Items { get; set; }
	}

	/// <summary>
	/// API response common "wrapper" object.
	/// <para>https://api.stackexchange.com/docs/wrapper</para>
	/// </summary>
	public interface IApiResponse : IHttpResponse
	{
		/// <summary>
		/// Indicates the different sources that can be offered by <see cref="IApiResponse{T}"/> implementations.
		/// </summary>
		[JsonIgnore]
		ResultSourceEnum Source { get; set; }
		/// <summary>
		/// The <see cref="IStackClient"/> which produced this API response.
		/// </summary>
		[JsonIgnore]
		IStackClient SourceClient { get; set; }
		/// <summary>
		/// The remaining amount of API calls that can be executed.
		/// </summary>
		[JsonProperty("quota_remaining")]
		long? QuotaRemaining { get; set; }
		/// <summary>
		/// The maximum API call quota available to the invoking credentials.
		/// </summary>
		[JsonProperty("quota_max")]
		long? QuotaMax { get; set; }
		/// <summary>
		/// Seconds the application must wait before hitting the same method again.
		/// </summary>
		[JsonProperty("backoff")]
		int? Backoff { get; set; }
		/// <summary>
		/// Boolean value indicating whether there are more pages available.
		/// </summary>
		[JsonProperty("has_more")]
		bool? HasMore { get; set; }
		/// <summary>
		/// Number indicating the total count of elements that satisfy this query.
		/// </summary>
		[JsonProperty("total")]
		long? Total { get; set; }
		/// <summary>
		/// The type of elements being returned in the <see cref="IApiResponse{T}.Items"/>  collection.
		/// </summary>
		[JsonProperty("type")]
		string Type { get; set; }
	}
}