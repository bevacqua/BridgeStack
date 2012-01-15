using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a change in reputation for a User.
	/// <para>https://api.stackexchange.com/docs/types/reputation</para>
	/// </summary>
	public interface IReputation
	{
		/// <summary>
		/// The related id of an user.
		/// </summary>
		[JsonProperty("user_id")]
		long? UserId { get; set; }
		/// <summary>
		/// The related id of a post.
		/// </summary>
		[JsonProperty("post_id")]
		long? PostId { get; set; }
		/// <summary>
		/// The type of post.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("post_type")]
		PostTypeEnum? PostType { get; set; }
		/// <summary>
		/// The type of vote.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("vote_type")]
		VoteTypeEnum? VoteType { get; set; }
		/// <summary>
		/// The title associated with the reputation change event.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// A link associated with the reputation change event.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
		/// <summary>
		/// The reputation change offset.
		/// </summary>
		[JsonProperty("reputation_change")]
		long? ReputationChange { get; set; }
		/// <summary>
		/// The date this reputation change took place.
		/// </summary>
		[JsonProperty("on_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		DateTime? Date { get; set; }
	}
}