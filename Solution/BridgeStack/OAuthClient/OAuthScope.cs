using System.Collections.Generic;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// OAuth scope parameters implementation.
	/// </summary>
	public class OAuthScope : IOAuthScope
	{
		/// <summary>
		/// Sets an scope parameter that grants the access token the privilege to access the authenticated user's inbox.
		/// </summary>
		public bool ReadInbox { get; set; }
		/// <summary>
		/// Sets an scope parameter indicating that the access token does not expire.
		/// </summary>
		public bool NoExpiry { get; set; }

		/// <summary>
		/// Override to facilitate serialization of the options selected in this scope.
		/// </summary>
		/// <returns>Returns the scope string.</returns>
		public override string ToString()
		{
			IList<string> parameters = new List<string>();
			if (ReadInbox)
			{
				parameters.Add(OAuth.ScopeReadInbox);
			}
			if (NoExpiry)
			{
				parameters.Add(OAuth.ScopeNoExpiry);
			}
			string scope = string.Join(",", parameters);
			return scope;
		}
	}
}