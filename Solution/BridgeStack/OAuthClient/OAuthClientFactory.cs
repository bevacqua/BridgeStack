namespace BridgeStack
{
	/// <summary>
	/// Creates concrete instances of the OAuthClient.
	/// </summary>
	public sealed class OAuthClientFactory
	{
		/// <summary>
		/// Creates concrete instances of the OAuthClient.
		/// </summary>
		public OAuthClientFactory()
		{
		}

		/// <summary>
		/// Instantiates an instance of OAuthClient. Uses default redirect uri endpoint.
		/// </summary>
		/// <param name="appId">Your application's client_id.</param>
		/// <returns>An instance of OAuthClient.</returns>
		public IOAuthClient Create(string appId)
		{
			return new OAuthClient(appId);
		}
		/// <summary>
		/// Instantiates an instance of OAuthClient.
		/// </summary>
		/// <param name="appId">Your application's client_id.</param>
		/// <param name="redirectUri">Your application's redirect_uri.</param>
		/// <returns>An instance of OAuthClient.</returns>
		public IOAuthClient Create(string appId, string redirectUri)
		{
			return new OAuthClient(appId, redirectUri);
		}
	}
}