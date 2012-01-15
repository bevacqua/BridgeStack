using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a badge on one of the Stack Exchange sites.
	/// <para>https://api.stackexchange.com/docs/types/answer</para>
	/// </summary>
	public sealed class Badge : IBadge<ShallowUser>
	{
		/// <summary>
		/// The id of this badge.
		/// </summary>
		public long? BadgeId { get; set; }

		/// <summary>
		/// The rank of the badge.
		/// </summary>
		public BadgeRankEnum? BadgeRank { get; set; }

		/// <summary>
		/// The name on the badge.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The description about this the badge.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Times this badge was awarded.
		/// </summary>
		public string AwardCount { get; set; }

		/// <summary>
		/// The type of badge.
		/// </summary>
		public BadgeTypeEnum? BadgeType { get; set; }

		/// <summary>
		/// The user this badge belongs to.
		/// </summary>
		public ShallowUser User { get; set; }

		/// <summary>
		/// A link to the badge profile.
		/// </summary>
		public string Link { get; set; }
	}
}