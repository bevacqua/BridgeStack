using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack
{
	/// <summary>
	/// Represents a user, however it is greatly reduced when compared to the full User type to reduce
	/// the amount of work that needs to be done in order to fetch it from multiple sites in the network.
	/// <para>https://api.stackexchange.com/docs/types/network-user</para>
	/// </summary>
	/// <typeparam name="TBadgeCount">The concrete type of <see cref="IBadgeCount"/>.</typeparam>
	public interface INetworkUser<TBadgeCount> where TBadgeCount : IBadgeCount
	{
		/// <summary>
		/// The name of the site.
		/// </summary>
		[JsonProperty("site_name")]
		string SiteName { get; set; }
		/// <summary>
		/// A link to the site.
		/// </summary>
		[JsonProperty("site_url")]
		string SiteUrl { get; set; }
		/// <summary>
		/// The user id.
		/// </summary>
		[JsonProperty("user_id")]
		long? UserId { get; set; }
		/// <summary>
		/// The user's reputation.
		/// </summary>
		[JsonProperty("reputation")]
		long? Reputation { get; set; }
		/// <summary>
		/// The id of the users global account used to associate all of his user accounts.
		/// </summary>
		[JsonProperty("account_id")]
		long? AccountId { get; set; }
		/// <summary>
		/// The date this user was created.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		string CreationDate { get; set; }
		/// <summary>
		/// The type of user.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("user_type")]
		UserTypeEnum? UserType { get; set; }
		/// <summary>
		/// The amount of badges of each type the user has.
		/// </summary>
		[JsonProperty("badge_counts")]
		TBadgeCount BadgeCounts { get; set; }
		/// <summary>
		/// The date this user was last active.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_access_date")]
		DateTime? LastAccessDate { get; set; }
		/// <summary>
		/// The amount of answers this user has posted.
		/// </summary>
		[JsonProperty("answer_count")]
		long? AnswerCount { get; set; }
		/// <summary>
		/// The amoutn of questions this user has posted.
		/// </summary>
		[JsonProperty("question_count")]
		long? QuestionCount { get; set; }

	}
}