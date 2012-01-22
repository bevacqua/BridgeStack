namespace BridgeStack
{
	/// <summary>
	/// State enumeration for cache items condition.
	/// </summary>
	public enum CacheItemStateEnum
	{
		/// <summary>
		/// The request is being processed.
		/// </summary>
		Processing,
		/// <summary>
		/// The response is cached and ready to use.
		/// </summary>
		Cached
	}
}