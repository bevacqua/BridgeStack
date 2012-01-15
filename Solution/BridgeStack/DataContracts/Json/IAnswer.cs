using System;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents an answer to a question on one of the Stack Exchange sites.
	/// <para>https://api.stackexchange.com/docs/types/answer</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	/// <typeparam name="TComment">The concrete type of <see cref="IComment{T}"/>.</typeparam>
	public interface IAnswer<TShallowUser, TComment> : IShallowPost<TShallowUser, TComment>
		where TShallowUser : IShallowUser
		where TComment : IComment<TShallowUser>
	{
		/// <summary>
		/// The id of the question this answer is posted on.
		/// </summary>
		[JsonProperty("question_id")]
		long? QuestionId { get; set; }
		/// <summary>
		/// Tne answer id.
		/// </summary>
		[JsonProperty("answer_id")]
		long? AnswerId { get; set; }
		/// <summary>
		/// The date this post was locked.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("locked_date")]
		DateTime? LockedDate { get; set; }
		/// <summary>
		/// The date this post was marked as community wiki.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("community_owned_date")]
		DateTime? CommunityOwnedDate { get; set; }
		/// <summary>
		/// Whether this is marked as the accepted answer.
		/// </summary>
		[JsonProperty("is_accepted")]
		bool? IsAccepted { get; set; }
		/// <summary>
		/// The title of the answer.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// A direct link to the answer.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}