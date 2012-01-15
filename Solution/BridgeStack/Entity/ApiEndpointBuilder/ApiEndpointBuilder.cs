using System;
using System.Collections.Generic;
using BridgeStack.DataContracts;
using BridgeStack.Resources;

namespace BridgeStack.Entity
{
	/// <summary>
	/// Tasked with building endpoint URI strings to the different methods exposed by the API.
	/// </summary>
	internal sealed class ApiEndpointBuilder : IApiEndpointBuilder
	{
		/// <summary>
		/// The version of the API to target. Defaults to <value>"2.0"</value>.
		/// </summary>
		private string _apiVersion = EndpointBuilder.DefaultVersion;
		/// <summary>
		/// The internet protocol to use with the API. Defaults to <value>"HTTPS"</value>.
		/// </summary>
		private string _apiProtocol = EndpointBuilder.DefaultProtocol;
		/// <summary>
		/// The API site route. Defaults to <value>"api.stackexchange.com"</value>.
		/// </summary>
		private string _apiEndpointSite = EndpointBuilder.DefaultSite;

		/// <summary>
		/// The version of the API to target. Defaults to <value>"2.0"</value>.
		/// </summary>
		public string ApiVersion
		{
			get { return _apiVersion; }
			set { _apiVersion = value; }
		}

		/// <summary>
		/// The internet protocol to use with the API. Defaults to <value>"HTTPS"</value>.
		/// </summary>
		public string ApiProtocol
		{
			get { return _apiProtocol; }
			set { _apiProtocol = value; }
		}

		/// <summary>
		/// The API site route. Defaults to <value>"api.stackexchange.com"</value>.
		/// </summary>
		public string ApiEndpointSite
		{
			get { return _apiEndpointSite; }
			set { _apiEndpointSite = value; }
		}

		/// <summary>
		/// The resulting API endpoint base route. By default: https://api.stackexchange.com/2.0.
		/// </summary>
		public string ApiEndpoint
		{
			get { return EndpointBuilder.Target.FormatWith(ApiProtocol, ApiEndpointSite, ApiVersion); }
		}

		/// <summary>
		/// The API method to target.
		/// </summary>
		public string ApiMethod { get; set; }

		/// <summary>
		/// The application's key. Grants a higher request quota.
		/// </summary>
		public string AppKey { get; set; }
		/// <summary>
		/// The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.
		/// </summary>
		public string AccessToken { get; set; }

		/// <summary>
		/// Contains the possible query string parameters and their assigned values.
		/// </summary>
		public IQuery Query { get; set; }

		/// <summary>
		/// The objects to serialize for vectorized requests. Contains information about the vector names and value types.
		/// </summary>
		public ICollection<IRequestVector> Vectors { get; set; }

		/// <summary>
		/// The Stack Exchange client that owns this API endpoint builder.
		/// </summary>
		public IStackClient Client { get; set; }

		/// <summary>
		/// Instances the ApiEndpointBuilder without setting any of the required parameters.
		/// </summary>
		private ApiEndpointBuilder()
		{
			Vectors = new List<IRequestVector>();
		}

		/// <summary>
		/// Instances the ApiEndpointBuilder. appKey and accessToken aren't actually required parameters.
		/// </summary>
		/// <param name="client">The Stack Exchange client that owns this API endpoint builder.</param>
		/// <param name="method">The API method to target.</param>
		/// <param name="appKey">The application's key. Grants a higher request quota.</param>
		/// <param name="accessToken">The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.</param>
		public ApiEndpointBuilder(IStackClient client, string method, string appKey = null, string accessToken = null)
			: this()
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			Client = client;
			ApiMethod = method;
			AppKey = appKey;
			AccessToken = accessToken;
		}

		/// <summary>
		/// Builds and returns the target endpoint Uri.
		/// </summary>
		/// <returns>Returns the resulting endpoint, could throw exceptions.</returns>
		private string Build()
		{
			string method = ApiMethod;
			if (method.StartsWith("/"))
			{
				method = ApiMethod.Substring(1);
			}
			foreach (IRequestVector v in Vectors) // apply all request vectors.
			{
				method = method.Replace(v.Result.Name, v.Result.Value);
			}
			string parameters = BuildParameters();
			string endpoint = EndpointBuilder.Endpoint.FormatWith(ApiEndpoint, method, parameters);
			return endpoint;
		}

		/// <summary>
		/// Builds query string parameters, optionally appends authentication parameters.
		/// </summary>
		/// <returns>The query string, or the empty string.</returns>
		private string BuildParameters()
		{
			string query = GetQueryStringParameters().ToLower(); // lowered basically for easier caching.
			string auth = GetAuthenticationParameters();
			return Utility.JoinQueryStringParameters(query, auth);
		}

		/// <summary>
		/// Through reflection, lists the query string parameters, verifies they are conform to constraint attributes, and returns the deserialized version of them.
		/// </summary>
		/// <returns>The query string parameters provided by the user, or the empty string.</returns>
		private string GetQueryStringParameters()
		{
			IQuery copy = Query.ShallowCopy(); // avoid changes in the original parameter list.
			IQuery query = copy.WithDefault(Client.Default);
			return query.ToQueryParams().Deserialize();
		}

		/// <summary>
		/// Appends the application key and access token to the query string parameters. Both of these parameters are optional to the ApiEndpointBuilder.
		/// </summary>
		/// <returns>The complete query string, with any authentication parameters set.</returns>
		private string GetAuthenticationParameters()
		{
			if (AppKey.NullOrEmpty())
			{
				return string.Empty; // passing an access token makes the app key a required parameter.
			}
			IList<QueryParam> parameters = new List<QueryParam>();
			parameters.Add(new QueryParam(Shared.AppKeyParameter, AppKey));
			parameters.Add(new QueryParam(Shared.AccessTokenParameter, AccessToken));
			return parameters.Deserialize();
		}

		/// <summary>
		/// Assigns <see cref="Query"/> fluently.
		/// </summary>
		/// <param name="parameters">The <see cref="Query"/> value.</param>
		/// <returns>The current instance of an <see cref="IApiEndpointBuilder"/>.</returns>
		public IApiEndpointBuilder Params(IQuery parameters)
		{
			Query = parameters;
			return this;
		}

		/// <summary>
		/// Assigns <see cref="Vectors"/> fluently.
		/// </summary>
		/// <param name="vectors">The <see cref="Vectors"/> value.</param>
		/// <returns>The current instance of an <see cref="IApiEndpointBuilder"/>.</returns>
		public IApiEndpointBuilder Vectorized(ICollection<IRequestVector> vectors)
		{
			Vectors = vectors;
			return this;
		}

		/// <summary>
		/// Overrides the default ToString method call with a method call that actually builds the endpoint.
		/// </summary>
		/// <returns>The endpoint successfully built, or throws an exception.</returns>
		public override string ToString()
		{
			return Build();
		}
	}
}
