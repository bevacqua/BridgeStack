using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the type of a revision.
	/// </summary>
	public enum RevisionTypeEnum
	{
		/// <summary>
		/// The revision was made by a single user.
		/// </summary>
		[EnumMember(Value = "single_user")]
		SingleUser,
		/// <summary>
		/// The revision is vote based.
		/// </summary>
		[EnumMember(Value = "vote_based")]
		VoteBased
	}
}