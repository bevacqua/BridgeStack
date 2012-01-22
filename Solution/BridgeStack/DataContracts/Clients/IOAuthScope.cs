namespace BridgeStack
{
	/// <summary>
	/// OAuth scope parameters contract.
	/// </summary>
	public interface IOAuthScope
	{
		/// <summary>
		/// Sets an scope parameter that grants the access token the privilege to access the authenticated user's inbox.
		/// </summary>
		bool ReadInbox { get; set; }
		/// <summary>
		/// Sets an scope parameter indicating that the access token does not expire.
		/// </summary>
		bool NoExpiry { get; set; }
	}
}