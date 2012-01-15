using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the different question timeline events available.
	/// </summary>
	public enum QuestionTimelineEventEnum
	{
		/// <summary>
		/// Event raised when the question is asked.
		/// </summary>
		[EnumMember(Value = "question")]
		Question,
		/// <summary>
		/// Event raised when an answer is posted.
		/// </summary>
		[EnumMember(Value = "answer")]
		Answer,
		/// <summary>
		/// Event raised when a comment is posted.
		/// </summary>
		[EnumMember(Value = "comment")]
		Comment,
		/// <summary>
		/// Event raised when an answer is unaccepted.
		/// </summary>
		[EnumMember(Value = "unaccepted_answer")]
		UnacceptedAnswer,
		/// <summary>
		/// Event raised when an answer is accepted.
		/// </summary>
		[EnumMember(Value = "accepted_answer")]
		AcceptedAnswer,
		/// <summary>
		/// Event raised when a vote aggregate occurs.
		/// </summary>
		[EnumMember(Value = "vote_aggregate")]
		VoteAggregate,
		/// <summary>
		/// Event raised when a revision occurs.
		/// </summary>
		[EnumMember(Value = "revision")]
		Revision,
		/// <summary>
		/// Event raised when the post state is changed.
		/// </summary>
		[EnumMember(Value = "post_state_changed")]
		PostStateChanged
	}
}