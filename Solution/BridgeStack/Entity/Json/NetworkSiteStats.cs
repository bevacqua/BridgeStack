using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a collection of statistics about the site.
	/// <para>https://api.stackexchange.com/docs/info</para>
	/// </summary>
	public sealed class NetworkSiteStats : INetworkSiteStats<NetworkSite, NetworkSiteStyling, NetworkSiteRelation>
	{
		/// <summary>
		/// The total amount of questions asked.
		/// </summary>
		public long? TotalQuestions { get; set; }

		/// <summary>
		/// The total amount of unanswered questions.
		/// </summary>
		public long? TotalUnanswered { get; set; }

		/// <summary>
		/// The total amount of answers accepted.
		/// </summary>
		public long? TotalAccepted { get; set; }

		/// <summary>
		/// The total amount of answers posted.
		/// </summary>
		public long? TotalAnswers { get; set; }

		/// <summary>
		/// The rate at which questions are posted.
		/// </summary>
		public decimal? QuestionsPerMinute { get; set; }

		/// <summary>
		/// The rate at which answers are posted.
		/// </summary>
		public decimal? AnswersPerMinute { get; set; }

		/// <summary>
		/// The total amount of comments on the site.
		/// </summary>
		public long? TotalComments { get; set; }

		/// <summary>
		/// The total amount of votes on the site.
		/// </summary>
		public long? TotalVotes { get; set; }

		/// <summary>
		/// The total amount of badges on the site.
		/// </summary>
		public long? TotalBadges { get; set; }

		/// <summary>
		/// The rate at which badges are awarded.
		/// </summary>
		public decimal? BadgesPerMinute { get; set; }

		/// <summary>
		/// The total amount of users registered on the site.
		/// </summary>
		public long? TotalUsers { get; set; }

		/// <summary>
		/// A hint on how many recently registered users are active on the site.
		/// </summary>
		public long? NewActiveUsers { get; set; }

		/// <summary>
		/// The build revision this site is working under.
		/// </summary>
		public string ApiRevision { get; set; }

		/// <summary>
		/// The site.
		/// </summary>
		public NetworkSite Site { get; set; }
	}
}