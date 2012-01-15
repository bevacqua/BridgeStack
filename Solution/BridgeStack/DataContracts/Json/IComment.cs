using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// All Questions and Answers on a Stack Exchange site can be commented on, and this type represents those comments.
	/// <para>https://api.stackexchange.com/docs/types/comment</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	public interface IComment<TShallowUser> where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The comment id.
		/// </summary>
		[JsonProperty("comment_id")]
		long? CommentId { get; set; }
		/// <summary>
		/// The id of the post this comment was posted on.
		/// </summary>
		[JsonProperty("post_id")]
		long? PostId { get; set; }
		/// <summary>
		/// The date this comment was posted.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// The type of the post on which this comment was posted.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("post_type")]
		PostTypeEnum? PostType { get; set; }
		/// <summary>
		/// The voting score for this comment.
		/// </summary>
		[JsonProperty("score")]
		long? Score { get; set; }
		/// <summary>
		/// Whether this comment was edited.
		/// </summary>
		[JsonProperty("edited")]
		bool? IsEdited { get; set; }
		/// <summary>
		/// The body of the comment.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The owner of this comment.
		/// </summary>
		[JsonProperty("owner")]
		TShallowUser Owner { get; set; }
		/// <summary>
		/// The user this comment was posted in reply to, if any.
		/// </summary>
		[JsonProperty("reply_to_user")]
		TShallowUser InReplyTo { get; set; }
		/// <summary>
		/// A direct link to the comment.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}