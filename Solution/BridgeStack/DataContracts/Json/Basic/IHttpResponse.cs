using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// HTTP Response common "wrapper" object.
	/// </summary>
	public interface IHttpResponse
	{
		/// <summary>
		/// The request's response as is, in dynamic format.
		/// </summary>
		[JsonIgnore]
		dynamic Dynamic { get; set; }
		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be raised by the bridge or come from the API response itself.
		/// </summary>
		[JsonIgnore]
		IBridgeException Exception { get; set; }
	}
}