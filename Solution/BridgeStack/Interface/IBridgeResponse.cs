using BridgeStack.DataContracts;
using BridgeStack.DataContracts.Json;

namespace BridgeStack
{
	/// <summary>
	/// Strongly typed interface for the API result "wrapper" object provided by the bridge.
	/// </summary>
	/// <typeparam name="T">The strong type for the <see cref="Response"/> object.</typeparam>
	public interface IBridgeResponse<T> : IBridgeResponse where T : class
	{
		/// <summary>
		/// The API response common "wrapper" object, as is.
		/// </summary>
		IApiResponse<T> Response { get; }
	}

	/// <summary>
	/// API response "wrapper" object provided by the bridge.
	/// </summary>
	public interface IBridgeResponse
	{
		/// <summary>
		/// The object that builds the API route endpoint.
		/// </summary>
		IApiEndpointBuilder EndpointBuilder { get; }
		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be an internal error or come from the API response.
		/// </summary>
		IBridgeException Exception { get; }
		/// <summary>
		/// True if the API call was successful. False otherwise.
		/// </summary>
		bool HasResult { get; }
	}
}