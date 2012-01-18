using System;
using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// Represents an answer to a question on one of the Stack Exchange sites.
	/// <para>https://api.stackexchange.com/docs/types/answer</para>
	/// </summary>
	public sealed class Answer : IAnswer<ShallowUser, Comment>
	{
		/// <summary>
		/// The body of the post.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The post owner.
		/// </summary>
		public ShallowUser Owner { get; set; }

		/// <summary>
		/// The date this post was created.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The date this post was last edited.
		/// </summary>
		public DateTime? LastEditDate { get; set; }

		/// <summary>
		/// The date this post was last active.
		/// </summary>
		public DateTime? LastActivityDate { get; set; }

		/// <summary>
		/// The current score for this post.
		/// </summary>
		public long? Score { get; set; }

		/// <summary>
		/// Total up votes on this post.
		/// </summary>
		public long? UpVoteCount { get; set; }

		/// <summary>
		/// Total down votes on this post.
		/// </summary>
		public long? DownVoteCount { get; set; }

		/// <summary>
		/// A list of comments on this post.
		/// </summary>
		public IList<Comment> Comments { get; set; }

		/// <summary>
		/// The id of the question this answer is posted on.
		/// </summary>
		public long? QuestionId { get; set; }

		/// <summary>
		/// Tne answer id.
		/// </summary>
		public long? AnswerId { get; set; }

		/// <summary>
		/// The date this post was locked.
		/// </summary>
		public DateTime? LockedDate { get; set; }

		/// <summary>
		/// The date this post was marked as community wiki.
		/// </summary>
		public DateTime? CommunityOwnedDate { get; set; }

		/// <summary>
		/// Whether this is marked as the accepted answer.
		/// </summary>
		public bool? IsAccepted { get; set; }

		/// <summary>
		/// The title of the answer.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// A direct link to the answer.
		/// </summary>
		public string Link { get; set; }
	}
}