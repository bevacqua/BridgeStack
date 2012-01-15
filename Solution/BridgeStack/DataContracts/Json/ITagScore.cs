using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents a user's statistics within a tag.
	/// <para>https://api.stackexchange.com/docs/types/tag-score</para>
	/// </summary>
	/// <typeparam name="TShallowUser"></typeparam>
	public interface ITagScore<TShallowUser> where TShallowUser : IShallowUser
	{
		/// <summary>
		/// The user.
		/// </summary>
		[JsonProperty("user")]
		TShallowUser User { get; set; }
		/// <summary>
		/// The current score for the user and tag.
		/// </summary>
		[JsonProperty("score")]
		long? Score { get; set; }
		/// <summary>
		/// The amount of posts for the user under this tag.
		/// </summary>
		[JsonProperty("post_count")]
		long? PostCount { get; set; }
	}
}