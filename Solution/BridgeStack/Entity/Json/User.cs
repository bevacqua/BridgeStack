using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a user on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/user</para>
	/// </summary>
	public sealed class User : ShallowUser, IUser
	{
		/// <summary>
		/// The date this user was created.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The difference in reputation since last day.
		/// </summary>
		public long? ReputationChangeDay { get; set; }

		/// <summary>
		/// The difference in reputation since last week.
		/// </summary>
		public long? ReputationChangeWeek { get; set; }

		/// <summary>
		/// The difference in reputation since last month.
		/// </summary>
		public long? ReputationChangeMonth { get; set; }

		/// <summary>
		/// The difference in reputation since last quarter.
		/// </summary>
		public long? ReputationChangeQuarter { get; set; }

		/// <summary>
		/// The difference in reputation since last year.
		/// </summary>
		public long? ReputationChangeYear { get; set; }

		/// <summary>
		/// The age of the user.
		/// </summary>
		public int? Age { get; set; }

		/// <summary>
		/// The date this user last accessed the network.
		/// </summary>
		public DateTime? LastAccessDate { get; set; }

		/// <summary>
		/// The date this user was last modified.
		/// </summary>
		public DateTime? LastModifiedDate { get; set; }

		/// <summary>
		/// Whether this is an Stack Exchange employee.
		/// </summary>
		public bool? IsEmployee { get; set; }

		/// <summary>
		/// The user provided website.
		/// </summary>
		public string WebsiteUrl { get; set; }

		/// <summary>
		/// The user provided location.
		/// </summary>
		public string Location { get; set; }

		/// <summary>
		/// The associated account id.
		/// </summary>
		public long? AccountId { get; set; }

		/// <summary>
		/// The timed penalty date.
		/// </summary>
		public DateTime? TimedPenaltyDate { get; set; }

		/// <summary>
		/// The amount of answers this user has posted.
		/// </summary>
		public long? AnswerCount { get; set; }

		/// <summary>
		/// The amount of questions this user has asked.
		/// </summary>
		public long? QuestionCount { get; set; }

		/// <summary>
		/// The amount of up votes this user has cast.
		/// </summary>
		public long? UpVoteCount { get; set; }

		/// <summary>
		/// The amount of down votes this user has cast.
		/// </summary>
		public long? DownVoteCount { get; set; }

		/// <summary>
		/// The user provided description of himself.
		/// </summary>
		public string About { get; set; }

		/// <summary>
		/// The amount of times the user's profile has been accessed.
		/// </summary>
		public long? ViewCount { get; set; }
	}
}