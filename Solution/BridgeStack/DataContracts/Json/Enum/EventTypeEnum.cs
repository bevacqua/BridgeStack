using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the type of event that occurred.
	/// </summary>
	public enum EventTypeEnum
	{
		/// <summary>
		/// Raised when a question is posted.
		/// </summary>
		[EnumMember(Value = "question_posted")]
		QuestionPosted,
		/// <summary>
		/// Raised when an answer is posted.
		/// </summary>
		[EnumMember(Value = "answer_posted")]
		AnswerPosted,
		/// <summary>
		/// Raised when a comment is posted.
		/// </summary>
		[EnumMember(Value = "comment_posted")]
		CommentPosted,
		/// <summary>
		/// Raised when a post is edited.
		/// </summary>
		[EnumMember(Value = "post_edited")]
		PostEdited,
		/// <summary>
		/// Raised when a user is created.
		/// </summary>
		[EnumMember(Value = "user_created")]
		UserCreated
	}
}