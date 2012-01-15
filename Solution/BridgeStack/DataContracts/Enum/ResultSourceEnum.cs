using BridgeStack.DataContracts.Json;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Indicates the different sources that can be offered by <see cref="IApiResponse"/> implementations.
	/// </summary>
	public enum ResultSourceEnum
	{
		/// <summary>
		/// No result has been produced yet.
		/// </summary>
		None,
		/// <summary>
		/// An exception has been thrown by the bridge before accessing the API.
		/// </summary>
		BridgeException,
		/// <summary>
		/// An exception has been returned in the API response.
		/// </summary>
		ApiException,
		/// <summary>
		/// The result comes from the API.
		/// </summary>
		Api,
		/// <summary>
		/// The result comes from the internal cache.
		/// </summary>
		Cache
	}
}