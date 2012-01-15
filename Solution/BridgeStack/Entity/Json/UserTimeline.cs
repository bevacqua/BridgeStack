using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a description of public actions a User has taken.
	/// <para>https://api.stackexchange.com/docs/types/user-timeline</para>
	/// </summary>
	public sealed class UserTimeline : IUserTimeline
	{
		/// <summary>
		/// The creation date for this timeline event.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The type of post.
		/// </summary>
		public PostTypeEnum? PostType { get; set; }

		/// <summary>
		/// The type of timeline event.
		/// </summary>
		public UserTimelineType? TimelineType { get; set; }

		/// <summary>
		/// The related id of an user.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// The related id of a post.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// The related id of a comment.
		/// </summary>
		public long? CommentId { get; set; }

		/// <summary>
		/// The related id of a suggested edit.
		/// </summary>
		public long? SuggestedEditId { get; set; }

		/// <summary>
		/// The related id of a badge.
		/// </summary>
		public long? BadgeId { get; set; }

		/// <summary>
		/// The title of the timeline event.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The body of the timeline event.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The link to the timeline event.
		/// </summary>
		public string Link { get; set; }
	}
}