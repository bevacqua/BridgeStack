using System;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents a user on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/user</para>
	/// </summary>
	public interface IUser : IShallowUser
	{
		/// <summary>
		/// The date this user was created.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// The difference in reputation since last day.
		/// </summary>
		[JsonProperty("reputation_change_day")]
		long? ReputationChangeDay { get; set; }
		/// <summary>
		/// The difference in reputation since last week.
		/// </summary>
		[JsonProperty("reputation_change_week")]
		long? ReputationChangeWeek { get; set; }
		/// <summary>
		/// The difference in reputation since last month.
		/// </summary>
		[JsonProperty("reputation_change_month")]
		long? ReputationChangeMonth { get; set; }
		/// <summary>
		/// The difference in reputation since last quarter.
		/// </summary>
		[JsonProperty("reputation_change_quarter")]
		long? ReputationChangeQuarter { get; set; }
		/// <summary>
		/// The difference in reputation since last year.
		/// </summary>
		[JsonProperty("reputation_change_year")]
		long? ReputationChangeYear { get; set; }
		/// <summary>
		/// The age of the user.
		/// </summary>
		[JsonProperty("age")]
		int? Age { get; set; }
		/// <summary>
		/// The date this user last accessed the network.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_access_date")]
		DateTime? LastAccessDate { get; set; }
		/// <summary>
		/// The date this user was last modified.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_modified_date")]
		DateTime? LastModifiedDate { get; set; }
		/// <summary>
		/// Whether this is an Stack Exchange employee.
		/// </summary>
		[JsonProperty("is_employee")]
		bool? IsEmployee { get; set; }
		/// <summary>
		/// The user provided website.
		/// </summary>
		[JsonProperty("website_url")]
		string WebsiteUrl { get; set; }
		/// <summary>
		/// The user provided location.
		/// </summary>
		[JsonProperty("location")]
		string Location { get; set; }
		/// <summary>
		/// The associated account id.
		/// </summary>
		[JsonProperty("account_id")]
		long? AccountId { get; set; }
		/// <summary>
		/// The timed penalty date.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("timed_penalty_date")]
		DateTime? TimedPenaltyDate { get; set; }
		/// <summary>
		/// The amount of answers this user has posted.
		/// </summary>
		[JsonProperty("answer_count")]
		long? AnswerCount { get; set; }
		/// <summary>
		/// The amount of questions this user has asked.
		/// </summary>
		[JsonProperty("question_count")]
		long? QuestionCount { get; set; }
		/// <summary>
		/// The amount of up votes this user has cast.
		/// </summary>
		[JsonProperty("up_vote_count")]
		long? UpVoteCount { get; set; }
		/// <summary>
		/// The amount of down votes this user has cast.
		/// </summary>
		[JsonProperty("down_vote_count")]
		long? DownVoteCount { get; set; }
		/// <summary>
		/// The user provided description of himself.
		/// </summary>
		[JsonProperty("about_me")]
		string About { get; set; }
		/// <summary>
		/// The amount of times the user's profile has been accessed.
		/// </summary>
		[JsonProperty("view_count")]
		long? ViewCount { get; set; }
	}
}