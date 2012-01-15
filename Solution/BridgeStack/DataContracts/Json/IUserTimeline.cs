using System;
using BridgeStack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a description of public actions a User has taken.
	/// <para>https://api.stackexchange.com/docs/types/user-timeline</para>
	/// </summary>
	public interface IUserTimeline
	{
		/// <summary>
		/// The creation date for this timeline event.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// The type of post.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("post_type")]
		PostTypeEnum? PostType { get; set; }
		/// <summary>
		/// The type of timeline event.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("timeline_type")]
		UserTimelineType? TimelineType { get; set; }
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
		/// The related id of a comment.
		/// </summary>
		[JsonProperty("comment_id")]
		long? CommentId { get; set; }
		/// <summary>
		/// The related id of a suggested edit.
		/// </summary>
		[JsonProperty("suggested_edit_id")]
		long? SuggestedEditId { get; set; }
		/// <summary>
		/// The related id of a badge.
		/// </summary>
		[JsonProperty("badge_id")]
		long? BadgeId { get; set; }
		/// <summary>
		/// The title of the timeline event.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// The body of the timeline event.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The link to the timeline event.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}