using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the user types.
	/// </summary>
	public enum UserTypeEnum
	{
		/// <summary>
		/// An unregistered user.
		/// </summary>
		[EnumMember(Value = "unregistered")]
		Unregistered,
		/// <summary>
		/// A registered user.
		/// </summary>
		[EnumMember(Value = "registered")]
		Registered,
		/// <summary>
		/// A community moderator.
		/// </summary>
		[EnumMember(Value = "moderator")]
		Moderator,
		/// <summary>
		/// A deleted or otherwise inexistent user.
		/// </summary>
		[EnumMember(Value = "does_not_exist")]
		DoesNotExist
	}
}