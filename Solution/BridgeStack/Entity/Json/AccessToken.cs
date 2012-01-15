using System;
using System.Collections.Generic;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents an access token created as part of an OAuth flow.
	/// <para>https://api.stackexchange.com/docs/types/access-token</para>
	/// </summary>
	public sealed class AccessToken : IAccessToken
	{
		/// <summary>
		/// The actual access token code.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// After this date the token is rendered invalid and the user has to re-authenticate through the OAuth flow.
		/// </summary>
		public DateTime? Expires { get; set; }

		/// <summary>
		/// The associated account's id.
		/// </summary>
		public long? AccountId { get; set; }

		/// <summary>
		/// The special scopes of the acccess token, if any.
		/// </summary>
		public IList<string> Scope { get; set; }
	}
}