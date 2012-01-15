using System;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents a tag on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/tag</para>
	/// </summary>
	public interface ITag
	{
		/// <summary>
		/// The name of the tag.
		/// </summary>
		[JsonProperty("name")]
		string Name { get; set; }
		/// <summary>
		/// Whether this is a required tag.
		/// </summary>
		[JsonProperty("is_required")]
		bool? IsRequired { get; set; }
		/// <summary>
		/// Whether only moderators can use this tag.
		/// </summary>
		[JsonProperty("is_moderator_only")]
		bool? IsModeratorOnly { get; set; }
		/// <summary>
		/// The related user id.
		/// </summary>
		[JsonProperty("user_id")]
		long? UserId { get; set; }
		/// <summary>
		/// The amount of times this tag was employed.
		/// </summary>
		[JsonProperty("count")]
		long? Count { get; set; }
		/// <summary>
		/// Whether this tag has any synonyms associated to it.
		/// </summary>
		[JsonProperty("has_synonyms")]
		bool? HasSynonyms { get; set; }
		/// <summary>
		/// The date this tag was last active.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_activity_date")]
		DateTime? LastActivityDate { get; set; }
	}
}