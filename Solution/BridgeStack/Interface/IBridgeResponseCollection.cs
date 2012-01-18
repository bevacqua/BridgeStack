using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// Wraps a collection of elements returned by a request to the API.
	/// </summary>
	/// <typeparam name="T">The strong type for the <see cref="IBridgeResponse"/> object.</typeparam>
	public interface IBridgeResponseCollection<T> : IBridgeResponse<T>, IBridgeResponseData<IEnumerable<T>>, IEnumerable<T>  where T : class
	{
		/// <summary>
		/// Boolean value indicating whether there are more pages available.
		/// </summary>
		bool HasMore { get; }
		/// <summary>
		/// Requests the next page to the API, and returns it wrapped in an <see cref="IBridgeResponseCollection{T}"/> object.
		/// </summary>
		/// <returns>A wrapper around the response to the request for a next page. In abscence of a next page, this method returns the current page from the internal cache.</returns>
		IBridgeResponseCollection<T> More();
		/// <summary>
		/// Returns the first item in the response's result set. This method does not query the API.
		/// </summary>
		/// <returns>A wrapper around the result item.</returns>
		IBridgeResponseItem<T> Single();
	}
}