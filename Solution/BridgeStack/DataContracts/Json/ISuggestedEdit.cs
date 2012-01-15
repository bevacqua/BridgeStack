using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack
{
	/// <summary>
	/// Represents a suggested edit on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/suggested-edit</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	public interface ISuggestedEdit<TShallowUser>
		where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The id of the suggested edit.
		/// </summary>
		[JsonProperty("suggested_edit_id")]
		long? SuggestedEditId { get; set; }
		/// <summary>
		/// The id of the post this edit was suggested on.
		/// </summary>
		[JsonProperty("post_id")]
		long? PostId { get; set; }
		/// <summary>
		/// The type of the post.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("post_type")]
		PostTypeEnum? PostType { get; set; }
		/// <summary>
		/// The body of the edited post.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The title of the edited post.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// The tags of the edited post.
		/// </summary>
		[JsonProperty("tags")]
		IList<string> Tags { get; set; }
		/// <summary>
		/// An optional comment regarding the reason behind the edit.
		/// </summary>
		[JsonProperty("comment")]
		string Comment { get; set; }
		/// <summary>
		/// The date this edit was suggested.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// The date this edit was approved.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("approval_date")]
		DateTime? ApprovalDate { get; set; }
		/// <summary>
		/// The date this edit was rejected.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("rejection_date")]
		DateTime? RejectionDate { get; set; }
		/// <summary>
		/// The user who proposed the edit.
		/// </summary>
		[JsonProperty("proposing_user")]
		TShallowUser ProposingUser { get; set; }
	}
}