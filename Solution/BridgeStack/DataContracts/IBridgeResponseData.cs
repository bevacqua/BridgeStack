namespace BridgeStack
{
	/// <summary>
	/// Wraps the result data items returned by an API request.
	/// </summary>
	/// <typeparam name="T">The type of the data result set.</typeparam>
	public interface IBridgeResponseData<out T>
	{
		/// <summary>
		/// A list of elements of type <typeparamref name="T"/>, that's returned from the API.
		/// </summary>
		T Safe { get; }
		/// <summary>
		/// Returns the result directly, but raises an exception if the query resulted in an error.
		/// </summary>
		T Unsafe { get; }
	}
}