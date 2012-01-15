using System;
using System.Diagnostics;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The concrete OAuthResponse implementation.
	/// </summary>
	[DebuggerDisplay("AccessToken={AccessToken}, Expires={Exception}")]
	public sealed class OAuthResponse : IOAuthResponse
	{
		/// <summary>
		/// The API response as is, in dynamic format.
		/// </summary>
		public dynamic Dynamic { get; set; }
		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be an internal error or come from the API response.
		/// </summary>
		public IBridgeException Exception { get; set; }
		/// <summary>
		/// The Access Token retrieved from the response, if any.
		/// </summary>
		public string AccessToken { get; set; }
		/// <summary>
		/// The API response as is, in dynamic format.
		/// </summary>
		public TimeSpan? Expires { get; set; }
	}
}