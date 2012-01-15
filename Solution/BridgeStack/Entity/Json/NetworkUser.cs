using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a user, however it is greatly reduced when compared to the full User type to reduce
	/// the amount of work that needs to be done in order to fetch it from multiple sites in the network.
	/// <para>https://api.stackexchange.com/docs/types/network-user</para>
	/// </summary>
	public sealed class NetworkUser : INetworkUser<BadgeCount>
	{
		/// <summary>
		/// The name of the site.
		/// </summary>
		public string SiteName { get; set; }

		/// <summary>
		/// A link to the site.
		/// </summary>
		public string SiteUrl { get; set; }

		/// <summary>
		/// The user id.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// The user's reputation.
		/// </summary>
		public long? Reputation { get; set; }

		/// <summary>
		/// The id of the users global account used to associate all of his user accounts.
		/// </summary>
		public long? AccountId { get; set; }

		/// <summary>
		/// The date this user was created.
		/// </summary>
		public string CreationDate { get; set; }

		/// <summary>
		/// The type of user.
		/// </summary>
		public UserTypeEnum? UserType { get; set; }

		/// <summary>
		/// The amount of badges of each type the user has.
		/// </summary>
		public BadgeCount BadgeCounts { get; set; }

		/// <summary>
		/// The date this user was last active.
		/// </summary>
		public DateTime? LastAccessDate { get; set; }

		/// <summary>
		/// The amount of answers this user has posted.
		/// </summary>
		public long? AnswerCount { get; set; }

		/// <summary>
		/// The amoutn of questions this user has posted.
		/// </summary>
		public long? QuestionCount { get; set; }
	}
}