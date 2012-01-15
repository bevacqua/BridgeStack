using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Represents a user, but omits many of the fields found on the full <see cref="IUser"/> type.
	/// <para>https://api.stackexchange.com/docs/types/shallow-user</para>
	/// </summary>
	public interface IShallowUser
	{
		/// <summary>
		/// The user id.
		/// </summary>
		[JsonProperty("user_id")]
		long? UserId { get; set; }
		/// <summary>
		/// The user's display name.
		/// </summary>
		[JsonProperty("display_name")]
		string DisplayName { get; set; }
		/// <summary>
		/// The user's reputation score.
		/// </summary>
		[JsonProperty("reputation")]
		long? Reputation { get; set; }
		/// <summary>
		/// The user type.
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("user_type")]
		UserTypeEnum? UserType { get; set; }
		/// <summary>
		/// The user's profile image.
		/// </summary>
		[JsonProperty("profile_image")]
		string ProfileImage { get; set; }
		/// <summary>
		/// A link to the user's public profile.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}