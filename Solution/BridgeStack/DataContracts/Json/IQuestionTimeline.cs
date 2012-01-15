using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack
{
	/// <summary>
	/// Represents events in the history of a Question.
	/// <para>https://api.stackexchange.com/docs/types/question-timeline</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	public interface IQuestionTimeline<TShallowUser> where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The event type.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("timeline_type")]
		QuestionTimelineEventEnum? Event { get; set; }
		/// <summary>
		/// The related question id.
		/// </summary>
		[JsonProperty("question_id")]
		long? QuestionId { get; set; }
		/// <summary>
		/// The related post id.
		/// </summary>
		[JsonProperty("post_id")]
		long? PostId { get; set; }
		/// <summary>
		/// The related comment id.
		/// </summary>
		[JsonProperty("comment_id")]
		long? CommentId { get; set; }
		/// <summary>
		/// The related revision guid.
		/// </summary>
		[JsonProperty("revision_guid")]
		Guid? RevisionGuid { get; set; }
		/// <summary>
		/// The amount of up votes.
		/// </summary>
		[JsonProperty("up_vote_count")]
		long? UpVoteCount { get; set; }
		/// <summary>
		/// The amount of down votes.
		/// </summary>
		[JsonProperty("down_vote_count")]
		long? DownVoteCount { get; set; }
		/// <summary>
		/// The date this event occurred.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// The related user.
		/// </summary>
		[JsonProperty("user")]
		TShallowUser User { get; set; }
		/// <summary>
		/// The related owner.
		/// </summary>
		[JsonProperty("owner")]
		TShallowUser Owner { get; set; }
	}
}