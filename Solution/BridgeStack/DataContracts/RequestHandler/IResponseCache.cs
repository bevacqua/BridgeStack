namespace BridgeStack
{
	/// <summary>
	/// Response cache store.
	/// </summary>
	public interface IResponseCache : IStackClientPlugin
	{
		/// <summary>
		/// Attempts to access the internal cache and retrieve a response cache item without querying the API.
		/// </summary>
		/// <typeparam name="T">The strong type in <see cref="IResponseCacheItem{T}"/>.</typeparam>
		/// <param name="endpoint">The API endpoint</param>
		/// <param name="pushEmpty">True to push an empty value into the cache if the endpoint isn't present yet.</param>
		/// <returns>Returns an API response cache item if successful, null otherwise.</returns>
		IResponseCacheItem<T> Get<T>(string endpoint, bool pushEmpty = false) where T : class;
		/// <summary>
		/// Attempts to push API responses into the cache store.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result.</typeparam>
		/// <param name="endpoint">The queried API endpoint.</param>
		/// <param name="response">The API response.</param>
		/// <returns>True if the operation was successful, false otherwise.</returns>
		bool Push<T>(string endpoint, IApiResponse<T> response) where T : class;
	}
}