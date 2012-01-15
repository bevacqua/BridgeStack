using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Describes a user's score and activity in a given Tag.
	/// <para>https://api.stackexchange.com/docs/types/top-tag</para>
	/// </summary>
	public interface ITagTop
	{
		/// <summary>
		/// The tag name.
		/// </summary>
		[JsonProperty("tag_name")]
		string TagName { get; set; }
		/// <summary>
		/// The score on questions in this tag.
		/// </summary>
		[JsonProperty("question_score")]
		long? QuestionScore { get; set; }
		/// <summary>
		/// The amount of questions in this tag.
		/// </summary>
		[JsonProperty("question_count")]
		long? QuestionCount { get; set; }
		/// <summary>
		/// The score on answers in this tag.
		/// </summary>
		[JsonProperty("answer_score")]
		long? AnswerScore { get; set; }
		/// <summary>
		/// The amount of answers in this tag.
		/// </summary>
		[JsonProperty("answer_count")]
		long? AnswerCount { get; set; }
	}
}