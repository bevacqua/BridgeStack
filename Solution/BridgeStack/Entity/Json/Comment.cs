using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// All Questions and Answers on a Stack Exchange site can be commented on, and this type represents those comments.
	/// <para>https://api.stackexchange.com/docs/types/comment</para>
	/// </summary>
	public sealed class Comment : IComment<ShallowUser>
	{
		/// <summary>
		/// The comment id.
		/// </summary>
		public long? CommentId { get; set; }

		/// <summary>
		/// The id of the post this comment was posted on.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// The date this comment was posted.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The type of the post on which this comment was posted.
		/// </summary>
		public PostTypeEnum? PostType { get; set; }

		/// <summary>
		/// The voting score for this comment.
		/// </summary>
		public long? Score { get; set; }

		/// <summary>
		/// Whether this comment was edited.
		/// </summary>
		public bool? IsEdited { get; set; }

		/// <summary>
		/// The body of the comment.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The owner of this comment.
		/// </summary>
		public ShallowUser Owner { get; set; }

		/// <summary>
		/// The user this comment was posted in reply to, if any.
		/// </summary>
		public ShallowUser InReplyTo { get; set; }

		/// <summary>
		/// A direct link to the comment.
		/// </summary>
		public string Link { get; set; }
	}
}