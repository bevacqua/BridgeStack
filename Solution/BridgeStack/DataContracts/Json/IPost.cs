using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents the intersection of the Question and Answer types.
	/// <para>https://api.stackexchange.com/docs/types/post</para>
	/// </summary>
	/// <typeparam name="TShallowUser">The concrete type of <see cref="IShallowUser"/>.</typeparam>
	/// <typeparam name="TComment">The concrete type of <see cref="IComment{TShallowUser}"/>.</typeparam>
	public interface IPost<TShallowUser, TComment> : IShallowPost<TShallowUser, TComment>
		where TShallowUser : IShallowUser
		where TComment : IComment<TShallowUser>
	{
		/// <summary>
		/// The id for this post.
		/// </summary>
		[JsonProperty("post_id")]
		long? PostId { get; set; }
		/// <summary>
		/// The type of post.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("post_type")]
		PostTypeEnum? PostType { get; set; }
	}
}