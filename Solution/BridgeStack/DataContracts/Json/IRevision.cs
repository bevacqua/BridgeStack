using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack
{
	/// <summary>
	/// Represents the state of a Post at some point in its history.
	/// <para>https://api.stackexchange.com/docs/types/revision</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	public interface IRevision<TShallowUser>
		where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The guid for this revision.
		/// </summary>
		[JsonProperty("revision_guid")]
		Guid? RevisionGuid { get; set; }
		/// <summary>
		/// The order number of this revision.
		/// </summary>
		[JsonProperty("revision_number")]
		long? RevisionNumber { get; set; }
		/// <summary>
		/// The type of revision.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("revision_type")]
		RevisionTypeEnum? RevisionType { get; set; }
		/// <summary>
		/// The type of post.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("post_type")]
		PostTypeEnum? PostType { get; set; }
		/// <summary>
		/// The id of the post.
		/// </summary>
		[JsonProperty("post_id")]
		long? PostId { get; set; }
		/// <summary>
		/// An optional comment on the revision.
		/// </summary>
		[JsonProperty("comment")]
		string Comment { get; set; }
		/// <summary>
		/// The date this revision was created.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// Whether this revision is a rollback.
		/// </summary>
		[JsonProperty("is_rollback")]
		bool? IsRollback { get; set; }
		/// <summary>
		/// The body before the revision.
		/// </summary>
		[JsonProperty("last_body")]
		string LastBody { get; set; }
		/// <summary>
		/// The title before the revision.
		/// </summary>
		[JsonProperty("last_title")]
		string LastTitle { get; set; }
		/// <summary>
		/// The tags before the revision.
		/// </summary>
		[JsonProperty("last_tags")]
		IList<string> LastTags { get; set; }
		/// <summary>
		/// The body after the revision.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The title after the revision.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// The tags after the revision.
		/// </summary>
		[JsonProperty("tags")]
		IList<string> Tags { get; set; }
		/// <summary>
		/// Whether this revision marked the post as community wiki.
		/// </summary>
		[JsonProperty("set_community_wiki")]
		bool? SetCommunityWiki { get; set; }
		/// <summary>
		/// The user who made the revision.
		/// </summary>
		[JsonProperty("user")]
		TShallowUser User { get; set; }
	}
}