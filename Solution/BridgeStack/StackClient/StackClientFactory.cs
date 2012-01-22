namespace BridgeStack
{
	/// <summary>
	/// Creates concrete instances of the StackClient.
	/// </summary>
	public sealed class StackClientFactory
	{
		/// <summary>
		/// Creates concrete instances of the StackClient.
		/// </summary>
		public StackClientFactory()
		{
		}

		/// <summary>
		/// Instantiates an StackClient.
		/// </summary>
		/// <param name="appKey">The application's key. Grants a higher request quota.</param>
		/// <returns>An instance of StackClient.</returns>
		public IStackClient Create(string appKey)
		{
			return new StackClient(appKey, InstancePlugins());
		}
		/// <summary>
		/// Instantiates an AuthorizedStackClient using an access token.
		/// </summary>
		/// <param name="appKey">The application's key. Grants a higher request quota.</param>
		/// <param name="accessToken">The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.</param>
		/// <returns>An instance of AuthorizedStackClient.</returns>
		public IAuthorizedStackClient Create(string appKey, string accessToken)
		{
			return new AuthorizedStackClient(appKey, accessToken, InstancePlugins());
		}

		/// <summary>
		/// Creates a default instance of the plugin container for a StackClient.
		/// </summary>
		/// <returns></returns>
		private StackClientPlugins InstancePlugins()
		{
			StackClientPlugins plugins = new StackClientPlugins(
				new Defaults(),
				new RequestHandler(),
				new EventLog(),
				new ResponseCache(),
				new RequestThrottler()
			);
			return plugins;
		}
	}
}