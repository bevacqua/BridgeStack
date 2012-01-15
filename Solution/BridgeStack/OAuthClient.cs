using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using BridgeStack.DataContracts;
using BridgeStack.DataContracts.Json;
using BridgeStack.Entity;
using BridgeStack.Entity.Json;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// The OAuthClient implementation.
	/// <para>See the API documentation for details</para>
	/// <para>https://api.stackexchange.com/docs/authentication</para>
	/// </summary>
	internal sealed class OAuthClient : IOAuthClient
	{
		/// <summary>
		/// For desktop applications, use this endpoint and the explicit user authentication flow.
		/// </summary>
		public static readonly string DefaultRedirectUri = OAuth.DefaultRedirectUri;
		/// <summary>
		/// This is the endpoint that yields access tokens during explicit user authentication.
		/// </summary>
		public static readonly string RequestAccessTokenEndpoint = OAuth.RequestAccessTokenEndpoint;

		/// <summary>
		/// Your application's client_id.
		/// </summary>
		public string AppId { get; private set; }
		/// <summary>
		/// Your application's redirect_uri.
		/// </summary>
		public string RedirectUri { get; private set; }

		/// <summary>
		/// Default constructor for OAuthClient.
		/// </summary>
		/// <param name="appId">Your application's client_id.</param>
		/// <param name="redirectUri">Your application's redirect_uri.</param>
		public OAuthClient(string appId, string redirectUri = null)
		{
			if (appId == null)
			{
				throw new ArgumentNullException("appId");
			}
			AppId = appId;
			RedirectUri = redirectUri ?? DefaultRedirectUri;
		}

		/// <summary>
		/// Gets the explicit OAuth flow endpoint that allows a user to approve or reject an application.
		/// </summary>
		/// <param name="scope">The scope of the token requested by the application.</param>
		/// <param name="state">The optional state object.</param>
		/// <returns>The API endpoint with the requested parameters.</returns>
		public string GetExplicitOAuthApprovalUri(IOAuthScope scope = null, IOAuthState state = null)
		{
			string uri = OAuth.ExplicitUri;
			string query = GetOAuthApprovalParameters(scope, state);
			return string.Concat(uri, query);
		}

		/// <summary>
		/// Gets the implicit OAuth flow endpoint that allows a user to approve or reject an application.
		/// </summary>
		/// <param name="scope">The scope of the token requested by the application.</param>
		/// <param name="state">The optional state object.</param>
		/// <returns>The API endpoint with the requested parameters.</returns>
		public string GetImplicitOAuthApprovalUri(IOAuthScope scope = null, IOAuthState state = null)
		{
			string uri = OAuth.ImplicitUri;
			string query = GetOAuthApprovalParameters(scope, state);
			return string.Concat(uri, query);
		}

		/// <summary>
		/// Gets the query string parameters to an OAuth flow endpoint for it's first step in the authentication process.
		/// </summary>
		/// <param name="scope">The scope of the token requested by the application.</param>
		/// <param name="state">The optional state object.</param>
		/// <returns>The requested query string parameters, serialized.</returns>
		private string GetOAuthApprovalParameters(IOAuthScope scope = null, IOAuthState state = null)
		{
			IList<QueryParam> parameters = new List<QueryParam>();
			parameters.Add(new QueryParam(OAuth.AppIdParameter, AppId));
			parameters.Add(new QueryParam(OAuth.RedirectUriParameter, RedirectUri));
			parameters.Add(new QueryParam(OAuth.StateParameter, state));
			parameters.Add(new QueryParam(OAuth.ScopeParameter, scope));

			return parameters.DeserializeAsQueryString();
		}

		/// <summary>
		/// Posts to the OAuth flow with a code retrieved during explicit authentication and attempts to retrieve an access token.
		/// </summary>
		/// <param name="appSecret">Your application's client_secret.</param>
		/// <param name="code">A code retrieved from https://stackexchange.com/oauth, as part of the explicit flow.</param>
		/// <returns>An access token or any raised exceptions wrapped in a response object.</returns>
		public IOAuthResponse RequestAccessToken(string appSecret, string code)
		{
			if (appSecret == null)
			{
				throw new ArgumentNullException("appSecret");
			}
			if (code == null)
			{
				throw new ArgumentNullException("code");
			}
			string endpoint = RequestAccessTokenEndpoint;

			IList<QueryParam> parameters = new List<QueryParam>();
			parameters.Add(new QueryParam(OAuth.AppIdParameter, AppId));
			parameters.Add(new QueryParam(OAuth.AppSecretParameter, appSecret));
			parameters.Add(new QueryParam(OAuth.RedirectUriParameter, RedirectUri));
			parameters.Add(new QueryParam(OAuth.AccessCodeParameter, code));
			string query = string.Join("&", parameters);

			OAuthResponse response = HttpPost<OAuthResponse>(endpoint, query);
			return response;
		}

		/// <summary>
		/// Makes an HTTP POST request to an endpoint URI with the passed parameters and returns the response.
		/// </summary>
		/// <typeparam name="T">The strong type of the HTTP response we are deserializing.</typeparam>
		/// <param name="endpoint">The endpoint URI where to make the request to.</param>
		/// <param name="parameters">The query string parameters, if any.</param>
		/// <returns>The HTTP response, deserialized into the strong type <typeparamref name="T"/>.</returns>
		private T HttpPost<T>(string endpoint, string parameters) where T : class, IHttpResponse, new()
		{
			T result;
			string responseText;
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(parameters);

				WebRequest request = WebRequest.Create(endpoint);
				request.Timeout = 300 * 1000;
				request.ContentType = Shared.PostMimeType;
				request.Method = Shared.PostMethod;
				request.ContentLength = bytes.Length;

				Stream stream = request.GetRequestStream();
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();

				HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				responseText = response.GetResponseString();

				string json = Utility.QueryStringToJson(responseText);
				result = json.DeserializeJson<T>();
				result.Dynamic = json.DeserializeJson();
			}
			catch (WebException web)
			{
				result = new T();
				try
				{
					WebResponse response = web.Response;
					if (response.ContentType == Utility.JsonMimeType)
					{
						responseText = response.GetResponseString();
						result.Exception = new BridgeException(Error.AccessingApiEndpoint.FormatWith(endpoint), web);
						result.Dynamic = responseText.DeserializeJson();
					}
					else
					{
						result.Exception = new BridgeException(Error.AccessingApiEndpoint.FormatWith(endpoint), web);
					}
				}
				catch (Exception e)
				{
					result.Exception = new BridgeException(Error.ExceptionAccessingApiEndpoint.FormatWith(endpoint), e);
				}
			}

			return result;
		}
	}
}