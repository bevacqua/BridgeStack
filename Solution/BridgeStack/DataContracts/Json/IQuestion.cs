using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a question on one of the Stack Exchange sites.
	/// <para>https://api.stackexchange.com/docs/types/question</para>
	/// </summary>
	/// <typeparam name="TSite">The concrete type of <see cref="INetworkSite{TStyling,TRelation}"/>.</typeparam>
	/// /// <typeparam name="TStyling">The concrete type of <see cref="INetworkSiteStyling"/>.</typeparam>
	/// <typeparam name="TRelation">The concrete type of <see cref="INetworkSiteRelation"/>.</typeparam>
	/// <typeparam name="TMigrationInfo">The concrete type of <see cref="IMigrationInfo{TSite,TStyling,TRelation}"/>.</typeparam>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	/// <typeparam name="TComment">The concrete type of <see cref="IComment{TShallowUser}"/>.</typeparam>
	/// <typeparam name="TAnswer">The concrete type of <see cref="IAnswer{TShallowUser,TComment}"/>.</typeparam>
	public interface IQuestion<TShallowUser, TComment, TMigrationInfo, TSite, TStyling, TRelation, TAnswer> : IShallowPost<TShallowUser, TComment>
		where TShallowUser : IShallowUser
		where TComment : IComment<TShallowUser>
		where TSite : INetworkSite<TStyling, TRelation>
		where TStyling : INetworkSiteStyling
		where TRelation : INetworkSiteRelation
		where TMigrationInfo : IMigrationInfo<TSite, TStyling, TRelation>
		where TAnswer : IAnswer<TShallowUser, TComment>
	{
		/// <summary>
		/// The id of this question.
		/// </summary>
		[JsonProperty("question_id")]
		long? QuestionId { get; set; }
		/// <summary>
		/// The date this question was locked.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("locked_date")]
		DateTime? LockedDate { get; set; }
		/// <summary>
		/// The date this question was marked as community wiki.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("community_owned_date")]
		DateTime? CommunityOwnedDate { get; set; }
		/// <summary>
		/// The amount of answers posted in response to this question.
		/// </summary>
		[JsonProperty("answer_count")]
		long? AnswerCount { get; set; }
		/// <summary>
		/// The id of the accepted answer, if any.
		/// </summary>
		[JsonProperty("accepted_answer_id")]
		long? AcceptedAnswerId { get; set; }
		/// <summary>
		/// Migration info telling where this question was migrated to.
		/// </summary>
		[JsonProperty("migrated_to")]
		TMigrationInfo MigratedTo { get; set; }
		/// <summary>
		/// Migration info telling where this question was migrated from.
		/// </summary>
		[JsonProperty("migrated_from")]
		TMigrationInfo MigratedFrom { get; set; }
		/// <summary>
		/// Date when the active bounty on this question ends.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("bounty_closes_date")]
		DateTime? BountyClosesDate { get; set; }
		/// <summary>
		/// The amount of reputation spent on the bounty.
		/// </summary>
		[JsonProperty("bounty_amount ")]
		long? BountyAmount { get; set; }
		/// <summary>
		/// The date this question was closed.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("closed_date")]
		DateTime? ClosedDate { get; set; }
		/// <summary>
		/// The date this question was marked as protected.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("protected_date")]
		DateTime? ProtectedDate { get; set; }
		/// <summary>
		/// The title of this question.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// A list of tags applied on this question.
		/// </summary>
		[JsonProperty("tags")]
		IList<string> Tags { get; set; }
		/// <summary>
		/// The reason this post was closed.
		/// </summary>
		[JsonProperty("closed_reason")]
		string ClosedReason { get; set; }
		/// <summary>
		/// The amount of users who favorited this question.
		/// </summary>
		[JsonProperty("favorite_count")]
		long? FavoriteCount { get; set; }
		/// <summary>
		/// The amount of views this question had.
		/// </summary>
		[JsonProperty("view_count")]
		long? ViewCount { get; set; }
		/// <summary>
		/// A list of answers posted on this question.
		/// </summary>
		[JsonProperty("answers")]
		IList<TAnswer> Answers { get; set; }
		/// <summary>
		/// A link to the question.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
		/// <summary>
		/// A boolean indicating whether this question is answered or considered unanswered.
		/// </summary>
		[JsonProperty("is_answered")]
		bool? IsAnswered { get; set; }
	}
}