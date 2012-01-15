using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a collection of statistics about the site.
	/// <para>https://api.stackexchange.com/docs/info</para>
	/// </summary>
	/// <typeparam name="TSite">The concrete type of <see cref="INetworkSite{TStyling,TRelation}"/>.</typeparam>
	/// <typeparam name="TStyling">The concrete type of <see cref="INetworkSiteStyling"/>.</typeparam>
	/// <typeparam name="TRelation">The concrete type of <see cref="INetworkSiteRelation"/>.</typeparam>
	public interface INetworkSiteStats<TSite, TStyling, TRelation>
		where TSite : INetworkSite<TStyling, TRelation>
		where TStyling : INetworkSiteStyling
		where TRelation : INetworkSiteRelation
	{
		/// <summary>
		/// The total amount of questions asked.
		/// </summary>
		[JsonProperty("total_questions")]
		long? TotalQuestions { get; set; }
		/// <summary>
		/// The total amount of unanswered questions.
		/// </summary>
		[JsonProperty("total_unanswered")]
		long? TotalUnanswered { get; set; }
		/// <summary>
		/// The total amount of answers accepted.
		/// </summary>
		[JsonProperty("total_accepted")]
		long? TotalAccepted { get; set; }
		/// <summary>
		/// The total amount of answers posted.
		/// </summary>
		[JsonProperty("total_answers")]
		long? TotalAnswers { get; set; }
		/// <summary>
		/// The rate at which questions are posted.
		/// </summary>
		[JsonProperty("questions_per_minute")]
		decimal? QuestionsPerMinute { get; set; }
		/// <summary>
		/// The rate at which answers are posted.
		/// </summary>
		[JsonProperty("answers_per_minute")]
		decimal? AnswersPerMinute { get; set; }
		/// <summary>
		/// The total amount of comments on the site.
		/// </summary>
		[JsonProperty("total_comments")]
		long? TotalComments { get; set; }
		/// <summary>
		/// The total amount of votes on the site.
		/// </summary>
		[JsonProperty("total_votes")]
		long? TotalVotes { get; set; }
		/// <summary>
		/// The total amount of badges on the site.
		/// </summary>
		[JsonProperty("total_badges")]
		long? TotalBadges { get; set; }
		/// <summary>
		/// The rate at which badges are awarded.
		/// </summary>
		[JsonProperty("badges_per_minute")]
		decimal? BadgesPerMinute { get; set; }
		/// <summary>
		/// The total amount of users registered on the site.
		/// </summary>
		[JsonProperty("total_users")]
		long? TotalUsers { get; set; }
		/// <summary>
		/// A hint on how many recently registered users are active on the site.
		/// </summary>
		[JsonProperty("new_active_users")]
		long? NewActiveUsers { get; set; }
		/// <summary>
		/// The build revision this site is working under.
		/// </summary>
		[JsonProperty("api_revision")]
		string ApiRevision { get; set; }
		/// <summary>
		/// The site.
		/// </summary>
		[JsonProperty("site")]
		TSite Site { get; set; }
	}
}