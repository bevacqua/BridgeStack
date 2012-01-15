using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Common interface of shared by posts, questions, and answers.
	/// <para>https://api.stackexchange.com/docs/types/post</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	/// <typeparam name="TComment">The concrete type of <see cref="IComment{TShallowUser}"/>.</typeparam>
	public interface IShallowPost<TShallowUser, TComment>
		where TShallowUser : IShallowUser
		where TComment : IComment<TShallowUser>
	{
		/// <summary>
		/// The body of the post.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The post owner.
		/// </summary>
		[JsonProperty("owner")]
		TShallowUser Owner { get; set; }
		/// <summary>
		/// The date this post was created.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// The date this post was last edited.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_edit_date")]
		DateTime? LastEditDate { get; set; }
		/// <summary>
		/// The date this post was last active.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_activity_date")]
		DateTime? LastActivityDate { get; set; }
		/// <summary>
		/// The current score for this post.
		/// </summary>
		[JsonProperty("score")]
		long? Score { get; set; }
		/// <summary>
		/// Total up votes on this post.
		/// </summary>
		[JsonProperty("up_vote_count")]
		long? UpVoteCount { get; set; }
		/// <summary>
		/// Total down votes on this post.
		/// </summary>
		[JsonProperty("down_vote_count")]
		long? DownVoteCount { get; set; }
		/// <summary>
		/// A list of comments on this post.
		/// </summary>
		[JsonProperty("comments")]
		IList<TComment> Comments { get; set; }
	}
}