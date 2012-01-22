namespace BridgeStack
{
	/// <summary>
	/// Response cache store.
	/// </summary>
	public interface IResponseCache : IStackClientPlugin
	{
		/// <summary>
		/// Attempts to access the internal cache and retrieve a response cache item without querying the API.
		/// <para>If the endpoint is not present in the cache yet, null is returned, but the endpoint is added to the cache.</para>
		/// <para>If the endpoint is present, it means the request is being processed. In this case we will wait on the processing to end before returning a result.</para>
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <param name="pushEmpty">True to push an empty value into the cache if the endpoint isn't present yet.</param>
		/// <returns>Returns an API response cache item if successful, null otherwise.</returns>
		IResponseCacheItem<T> Get<T>(IApiEndpointBuilder builder, bool pushEmpty = false) where T : class;
		/// <summary>
		/// Attempts to push API responses into the cache store.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <param name="response">The API response.</param>
		/// <returns>True if the operation was successful, false otherwise.</returns>
		bool Push<T>(IApiEndpointBuilder builder, IApiResponse<T> response) where T : class;
	}
}