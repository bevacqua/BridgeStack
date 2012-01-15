using System;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Wrapper interface for OAuth responses.
	/// </summary>
	public interface IOAuthResponse : IHttpResponse
	{
		/// <summary>
		/// The Access Token retrieved from the response, if any.
		/// </summary>
		[JsonProperty("access_token")]
		string AccessToken { get; set; }
		/// <summary>
		/// A value indicating when the access token expires, if ever.
		/// </summary>
		[JsonConverter(typeof(UnixTimeSpanConverter))]
		[JsonProperty("expires")]
		TimeSpan? Expires { get; set; }
	}
}