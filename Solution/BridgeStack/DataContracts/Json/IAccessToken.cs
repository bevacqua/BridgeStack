using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents an access token created as part of an OAuth flow.
	/// <para>https://api.stackexchange.com/docs/types/access-token</para>
	/// </summary>
	public interface IAccessToken
	{
		/// <summary>
		/// The actual access token code.
		/// </summary>
		[JsonProperty("access_token")]
		string Code { get; set; }
		/// <summary>
		/// After this date the token is rendered invalid and the user has to re-authenticate through the OAuth flow.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("expires_on_date")]
		DateTime? Expires { get; set; }
		/// <summary>
		/// The associated account's id.
		/// </summary>
		[JsonProperty("account_id")]
		long? AccountId { get; set; }
		/// <summary>
		/// The special scopes of the acccess token, if any.
		/// </summary>
		[JsonProperty("scope")]
		IList<string> Scope { get; set; }
	}
}