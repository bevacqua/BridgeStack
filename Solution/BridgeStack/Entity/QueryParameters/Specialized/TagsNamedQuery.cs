namespace BridgeStack.Entity
{
	/// <summary>
	/// The named tags query parameters.
	/// </summary>
	public sealed class TagsNamedQuery : TagsQuery
	{
		/// <summary>
		/// Filters the results down to just those users with a certain substring in their display name.
		/// </summary>
		public string InName { get; set; }
	}
}