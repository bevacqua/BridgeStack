using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a user's statistics within a tag.
	/// <para>https://api.stackexchange.com/docs/types/tag-score</para>
	/// </summary>
	public sealed class TagScore : ITagScore<ShallowUser>
	{
		/// <summary>
		/// The user.
		/// </summary>
		public ShallowUser User { get; set; }

		/// <summary>
		/// The current score for the user and tag.
		/// </summary>
		public long? Score { get; set; }

		/// <summary>
		/// The amount of posts for the user under this tag.
		/// </summary>
		public long? PostCount { get; set; }
	}
}