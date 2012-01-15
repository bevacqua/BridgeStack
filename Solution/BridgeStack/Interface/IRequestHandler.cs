using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Object in charge of processing API requests, and deciding whether to access the API or return results from the internal cache instead.
	/// </summary>
	internal interface IRequestHandler
	{
		/// <summary>
		/// Processes a request, attempting to retrieve results from the cache whenever possible, and making API calls otherwise.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>A wrapper object around the result object. It's source is either the API, the internal cache, or raised exceptions.</returns>
		IBridgeResponseCollection<T> ProcessRequest<T>(IApiEndpointBuilder builder) where T : class;
	}
}