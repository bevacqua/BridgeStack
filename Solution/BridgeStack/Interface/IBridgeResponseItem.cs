namespace BridgeStack
{
	/// <summary>
	/// Wraps a single element returned by a request to the API.
	/// </summary>
	/// <typeparam name="T">The strong type for the <see cref="IBridgeResponse"/> object.</typeparam>
	public interface IBridgeResponseItem<T> : IBridgeResponse<T>, IBridgeResponseData<T> where T : class
	{
	}
}