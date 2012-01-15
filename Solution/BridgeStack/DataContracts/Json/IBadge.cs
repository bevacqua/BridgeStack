using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a badge on one of the Stack Exchange sites.
	/// <para>https://api.stackexchange.com/docs/types/answer</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	public interface IBadge<TShallowUser> where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The id of this badge.
		/// </summary>
		[JsonProperty("badge_id")]
		long? BadgeId { get; set; }
		/// <summary>
		/// The rank of the badge.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("rank")]
		BadgeRankEnum? BadgeRank { get; set; }
		/// <summary>
		/// The name on the badge.
		/// </summary>
		[JsonProperty("name")]
		string Name { get; set; }
		/// <summary>
		/// The description about this the badge.
		/// </summary>
		[JsonProperty("description")]
		string Description { get; set; }
		/// <summary>
		/// Times this badge was awarded.
		/// </summary>
		[JsonProperty("award_count")]
		string AwardCount { get; set; }
		/// <summary>
		/// The type of badge.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("badge_type")]
		BadgeTypeEnum? BadgeType { get; set; }
		/// <summary>
		/// The user this badge belongs to.
		/// </summary>
		[JsonProperty("user")]
		TShallowUser User { get; set; }
		/// <summary>
		/// A link to the badge profile.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}