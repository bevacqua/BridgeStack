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
		/// Instantiates an instance of StackClient.
		/// </summary>
		/// <param name="appKey">The application's key. Grants a higher request quota.</param>
		/// <param name="accessToken">The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.</param>
		/// <returns>An instance of StackClient.</returns>
		public IStackClient Create(string appKey, string accessToken)
		{
			return new StackClient(new RequestHandler(), appKey, accessToken);
		}
	}
}