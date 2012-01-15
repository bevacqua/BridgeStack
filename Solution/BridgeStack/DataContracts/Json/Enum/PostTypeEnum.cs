using System.Runtime.Serialization;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Defines the type of a post.
	/// </summary>
	public enum PostTypeEnum
	{
		/// <summary>
		/// The post represents a question.
		/// </summary>
		[EnumMember(Value = "question")]
		Question,
		/// <summary>
		/// The post represents an answer.
		/// </summary>
		[EnumMember(Value = "answer")]
		Answer
	}
}