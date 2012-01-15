using System;
using Newtonsoft.Json;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a tag's wiki description.
	/// <para>https://api.stackexchange.com/docs/types/tag-wiki</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	public interface ITagWiki<TShallowUser> where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The tag name.
		/// </summary>
		[JsonProperty("tag_name")]
		string TagName { get; set; }
		/// <summary>
		/// The tag's description body.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The tag's description excerpt.
		/// </summary>
		[JsonProperty("excerpt")]
		string Excerpt { get; set; }
		/// <summary>
		/// Date the body was last edited.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("body_last_edit_date")]
		DateTime? LastBodyEdit { get; set; }
		/// <summary>
		/// Date the excerpt was last edited.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("excerpt_last_edit_date")]
		DateTime? LastExcerptEdit { get; set; }
		/// <summary>
		/// The last user who edited the body.
		/// </summary>
		[JsonProperty("last_body_editor")]
		TShallowUser LastBodyEditor { get; set; }
		/// <summary>
		/// The last user who edited the excerpt.
		/// </summary>
		[JsonProperty("last_excerpt_editor")]
		TShallowUser LastExcerptEditor { get; set; }
	}
}