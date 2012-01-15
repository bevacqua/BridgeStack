namespace BridgeStack
{
	/// <summary>
	/// The named user query parameters.
	/// </summary>
	public sealed class UsersNamedQuery : UsersQuery
	{
		/// <summary>
		/// Filters the results down to just those users with a certain substring in their display name.
		/// </summary>
		public string InName { get; set; }
	}
}