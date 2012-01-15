using System;
using System.Collections.Generic;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a question on one of the Stack Exchange sites.
	/// <para>https://api.stackexchange.com/docs/types/question</para>
	/// </summary>
	public sealed class Question : IQuestion<ShallowUser, Comment, MigrationInfo, NetworkSite, NetworkSiteStyling, NetworkSiteRelation, Answer>
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
		/// The id of this question.
		/// </summary>
		public long? QuestionId { get; set; }

		/// <summary>
		/// The date this question was locked.
		/// </summary>
		public DateTime? LockedDate { get; set; }

		/// <summary>
		/// The date this question was marked as community wiki.
		/// </summary>
		public DateTime? CommunityOwnedDate { get; set; }

		/// <summary>
		/// The amount of answers posted in response to this question.
		/// </summary>
		public long? AnswerCount { get; set; }

		/// <summary>
		/// The id of the accepted answer, if any.
		/// </summary>
		public long? AcceptedAnswerId { get; set; }

		/// <summary>
		/// Migration info telling where this question was migrated to.
		/// </summary>
		public MigrationInfo MigratedTo { get; set; }

		/// <summary>
		/// Migration info telling where this question was migrated from.
		/// </summary>
		public MigrationInfo MigratedFrom { get; set; }

		/// <summary>
		/// Date when the active bounty on this question ends.
		/// </summary>
		public DateTime? BountyClosesDate { get; set; }

		/// <summary>
		/// The amount of reputation spent on the bounty.
		/// </summary>
		public long? BountyAmount { get; set; }

		/// <summary>
		/// The date this question was closed.
		/// </summary>
		public DateTime? ClosedDate { get; set; }

		/// <summary>
		/// The date this question was marked as protected.
		/// </summary>
		public DateTime? ProtectedDate { get; set; }

		/// <summary>
		/// The title of this question.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// A list of tags applied on this question.
		/// </summary>
		public IList<string> Tags { get; set; }

		/// <summary>
		/// The reason this post was closed.
		/// </summary>
		public string ClosedReason { get; set; }

		/// <summary>
		/// The amount of users who favorited this question.
		/// </summary>
		public long? FavoriteCount { get; set; }

		/// <summary>
		/// The amount of views this question had.
		/// </summary>
		public long? ViewCount { get; set; }

		/// <summary>
		/// A list of answers posted on this question.
		/// </summary>
		public IList<Answer> Answers { get; set; }

		/// <summary>
		/// A link to the question.
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// A boolean indicating whether this question is answered or considered unanswered.
		/// </summary>
		public bool? IsAnswered { get; set; }
	}
}