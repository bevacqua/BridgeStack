using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Internal response cache store for the API.
	/// </summary>
	internal interface IApiResponseStore
	{
		/// <summary>
		/// Remove cached response elements that have become invalid (old).
		/// </summary>
		void Invalidate();
		/// <summary>
		/// Attempts to access the internal cache and retrieve a response object without querying the API.
		/// </summary>
		/// <typeparam name="T">The strong type in <see cref="IApiResponse{T}"/>.</typeparam>
		/// <param name="endpoint">The API endpoint</param>
		/// <returns>Returns an API response object if successful, null otherwise.</returns>
		IApiResponse<T> Get<T>(string endpoint);
		/// <summary>
		/// Attempts to push API responses into the cache store.
		/// </summary>
		/// <param name="endpoint">The queried API endpoint.</param>
		/// <param name="response">The API response.</param>
		void Push(string endpoint, IApiResponse response);
	}
}