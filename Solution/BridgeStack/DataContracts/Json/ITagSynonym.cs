using System;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a mapping from one tag to another, as part of a system's tag synonym list.
	/// <para>https://api.stackexchange.com/docs/types/tag-synonym</para>
	/// </summary>
	public interface ITagSynonym
	{
		/// <summary>
		/// The tag synonym.
		/// </summary>
		[JsonProperty("from_tag")]
		string FromTag { get; set; }
		/// <summary>
		/// The master tag.
		/// </summary>
		[JsonProperty("to_tag")]
		string ToTag { get; set; }
		/// <summary>
		/// The count of how many times this mapping has been applied.
		/// </summary>
		[JsonProperty("applied_count")]
		long? AppliedCount { get; set; }
		/// <summary>
		/// Date the mapping was last applied
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("last_applied_date")]
		DateTime? LastAppliedDate { get; set; }
		/// <summary>
		/// Date the tag synonym was created.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
	}
}