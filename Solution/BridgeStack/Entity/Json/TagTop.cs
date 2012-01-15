using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Describes a user's score and activity in a given Tag.
	/// <para>https://api.stackexchange.com/docs/types/top-tag</para>
	/// </summary>
	public sealed class TagTop : ITagTop
	{
		/// <summary>
		/// The tag name.
		/// </summary>
		public string TagName { get; set; }

		/// <summary>
		/// The score on questions in this tag.
		/// </summary>
		public long? QuestionScore { get; set; }

		/// <summary>
		/// The amount of questions in this tag.
		/// </summary>
		public long? QuestionCount { get; set; }

		/// <summary>
		/// The score on answers in this tag.
		/// </summary>
		public long? AnswerScore { get; set; }

		/// <summary>
		/// The amount of answers in this tag.
		/// </summary>
		public long? AnswerCount { get; set; }
	}
}