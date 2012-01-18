namespace BridgeStack
{
	/// <summary>
	/// Internal helpers for IBridgeResponseCollection.
	/// </summary>
	internal static class IBridgeResponseCollectionHelpers
	{
		/// <summary>
		/// Returns the first item in the response's result set. This method does not query the API.
		/// </summary>
		/// <returns>A wrapper around the result item.</returns>
		public static IBridgeResponseItem<T> Single<T>(this IBridgeResponseCollection<T> collection) where T : class
		{
			return new BridgeResponseItem<T>(collection);
		}
	}
}