using System;
using System.Collections.Generic;
using System.Linq;

namespace BridgeStack
{
	/// <summary>
	/// OAuth state parameters implementation.
	/// </summary>
	public sealed class OAuthState : Dictionary<string, string>, IOAuthState
	{
		/// <summary>
		/// Override to facilitate serialization of the user state parameters.
		/// </summary>
		/// <returns>Returns the state string.</returns>
		public override string ToString()
		{
			IEnumerable<string> parameters = this.Where(p => !p.Value.NullOrEmpty()).Select(p => "{0}:{1}".FormatWith(p.Key, p.Value));
			string state = string.Join("+", parameters);
			return state;
		}

		/// <summary>
		/// Creates an empty OAuthState object.
		/// </summary>
		public OAuthState()
		{
		}

		/// <summary>
		/// Creates an OAuthState object based on a query string result.
		/// </summary>
		/// <param name="state">The query string value for state.</param>
		public OAuthState(string state)
		{
			string query = Uri.UnescapeDataString(state ?? string.Empty);
			string[] pairs = query.Split('+');
			var parameters = pairs.Select(p => p.Split(':')).Select(r => new
			{
				Key = r[0],
				Value = r[1]
			});
			foreach (var parameter in parameters)
			{
				Add(parameter.Key, parameter.Value);
			}
		}
	}
}