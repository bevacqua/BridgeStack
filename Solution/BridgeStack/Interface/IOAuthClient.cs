using BridgeStack.DataContracts.Json;

namespace BridgeStack
{
	/// <summary>
	/// Contract for the API OAuth Client.
	/// </summary>
	public interface IOAuthClient
	{
		/// <summary>
		/// Your application's client_id.
		/// </summary>
		string AppId { get; }
		/// <summary>
		/// Your application's redirect_uri.
		/// </summary>
		string RedirectUri { get; }
		/// <summary>
		/// Gets the explicit OAuth flow endpoint that allows a user to approve or reject an application.
		/// </summary>
		/// <param name="scope">The scope of the token requested by the application.</param>
		/// <param name="state">The optional state string.</param>
		/// <returns>The API endpoint with the requested parameters.</returns>
		string GetExplicitOAuthApprovalUri(IOAuthScope scope = null, IOAuthState state = null);
		/// <summary>
		/// Gets the implicit OAuth flow endpoint that allows a user to approve or reject an application.
		/// </summary>
		/// <param name="scope">The scope of the token requested by the application.</param>
		/// <param name="state">The optional state string.</param>
		/// <returns>The API endpoint with the requested parameters.</returns>
		string GetImplicitOAuthApprovalUri(IOAuthScope scope = null, IOAuthState state = null);
		/// <summary>
		/// Posts to the OAuth flow with a code retrieved during explicit authentication and attempts to retrieve an access token.
		/// </summary>
		/// <param name="appSecret">Your application's client_secret.</param>
		/// <param name="code">A code retrieved from https://stackexchange.com/oauth, as part of the explicit flow.</param>
		/// <returns>An access token or any raised exceptions wrapped in a response object.</returns>
		IOAuthResponse RequestAccessToken(string appSecret, string code);
	}
}