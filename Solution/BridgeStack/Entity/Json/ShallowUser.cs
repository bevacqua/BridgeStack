using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a user, but omits many of the fields found on the full <see cref="IUser"/> type.
	/// <para>https://api.stackexchange.com/docs/types/shallow-user</para>
	/// </summary>
	public class ShallowUser : IShallowUser
	{
		/// <summary>
		/// The user id.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// The user's display name.
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		/// The user's reputation score.
		/// </summary>
		public long? Reputation { get; set; }

		/// <summary>
		/// The user type.
		/// </summary>
		public UserTypeEnum? UserType { get; set; }

		/// <summary>
		/// The user's profile image.
		/// </summary>
		public string ProfileImage { get; set; }

		/// <summary>
		/// A link to the user's public profile.
		/// </summary>
		public string Link { get; set; }
	}
}