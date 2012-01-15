using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// Tasked with building endpoint URI strings to the different methods exposed by the API.
	/// </summary>
	public interface IApiEndpointBuilder
	{
		/// <summary>
		/// The version of the API to target. Defaults to <value>"2.0"</value>.
		/// </summary>
		string ApiVersion { get; set; }
		/// <summary>
		/// The internet protocol to use with the API. Defaults to <value>"HTTPS"</value>.
		/// </summary>
		string ApiProtocol { get; set; }
		/// <summary>
		/// The API site route. Defaults to <value>"api.stackexchange.com"</value>.
		/// </summary>
		string ApiEndpointSite { get; set; }
		/// <summary>
		/// The resulting API endpoint base route. By default: https://api.stackexchange.com/2.0.
		/// </summary>
		string ApiEndpoint { get; }
		/// <summary>
		/// The API method to target.
		/// </summary>
		string ApiMethod { get; set; }
		/// <summary>
		/// The application's key. Grants a higher request quota.
		/// </summary>
		string AppKey { get; set; }
		/// <summary>
		/// The user's access token. Grants authentication and access to methods which require that the application be acting on behalf of a user in order to be invoked.
		/// </summary>
		string AccessToken { get; set; }
		/// <summary>
		/// Contains the possible query string parameters and their assigned values.
		/// </summary>
		IQuery Query { get; set; }
		/// <summary>
		/// The objects to serialize for vectorized requests. Contains information about the vector names and value types.
		/// </summary>
		ICollection<IRequestVector> Vectors { get; set; }
		/// <summary>
		/// Assigns <see cref="Query"/> fluently.
		/// </summary>
		/// <param name="parameters">The <see cref="Query"/> value.</param>
		/// <returns>The current instance of an <see cref="IApiEndpointBuilder"/>.</returns>
		IApiEndpointBuilder Params(IQuery parameters);
		/// <summary>
		/// Assigns <see cref="Vectors"/> fluently.
		/// </summary>
		/// <param name="vectors">The <see cref="Vectors"/> value.</param>
		/// <returns>The current instance of an <see cref="IApiEndpointBuilder"/>.</returns>
		IApiEndpointBuilder Vectorized(ICollection<IRequestVector> vectors);
		/// <summary>
		/// The Stack Exchange client that owns this API endpoint builder.
		/// </summary>
		IStackClient Client { get; set; }
	}
}