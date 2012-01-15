using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents events in the history of a Question.
	/// <para>https://api.stackexchange.com/docs/types/question-timeline</para>
	/// </summary>
	public sealed class QuestionTimeline : IQuestionTimeline<ShallowUser>
	{
		/// <summary>
		/// The event type.
		/// </summary>
		public QuestionTimelineEventEnum? Event { get; set; }

		/// <summary>
		/// The related question id.
		/// </summary>
		public long? QuestionId { get; set; }

		/// <summary>
		/// The related post id.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// The related comment id.
		/// </summary>
		public long? CommentId { get; set; }

		/// <summary>
		/// The related revision guid.
		/// </summary>
		public Guid? RevisionGuid { get; set; }

		/// <summary>
		/// The amount of up votes.
		/// </summary>
		public long? UpVoteCount { get; set; }

		/// <summary>
		/// The amount of down votes.
		/// </summary>
		public long? DownVoteCount { get; set; }

		/// <summary>
		/// The date this event occurred.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The related user.
		/// </summary>
		public ShallowUser User { get; set; }

		/// <summary>
		/// The related owner.
		/// </summary>
		public ShallowUser Owner { get; set; }
	}
}