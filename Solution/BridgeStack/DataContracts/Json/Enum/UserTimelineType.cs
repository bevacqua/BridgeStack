using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the user timeline events.
	/// </summary>
	public enum UserTimelineType
	{
		/// <summary>
		/// Timeline event raised when a user posts a comment.
		/// </summary>
		[EnumMember(Value = "commented")]
		Commented,
		/// <summary>
		/// Timeline event raised when a user asks a question.
		/// </summary>
		[EnumMember(Value = "asked")]
		Asked,
		/// <summary>
		/// Timeline event raised when a user posts an answer.
		/// </summary>
		[EnumMember(Value = "answered")]
		Answered,
		/// <summary>
		/// Timeline event raised when a user earns a badge.
		/// </summary>
		[EnumMember(Value = "badge")]
		Badge,
		/// <summary>
		/// Timeline event raised when a user receives a revision.
		/// </summary>
		[EnumMember(Value = "revision")]
		Revision,
		/// <summary>
		/// Timeline event raised when a user accepts an answer.
		/// </summary>
		[EnumMember(Value = "accepted")]
		Accepted,
		/// <summary>
		/// Timeline event raised when a user reviews a post.
		/// </summary>
		[EnumMember(Value = "reviewed")]
		Reviewed,
		/// <summary>
		/// Timeline event raised when a user suggests an edit.
		/// </summary>
		[EnumMember(Value = "suggested")]
		Suggested
	}
}