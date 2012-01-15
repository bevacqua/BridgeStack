using System.Runtime.Serialization;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Badge types enumeration.
	/// </summary>
	public enum BadgeTypeEnum
	{
		/// <summary>
		/// Named badges.
		/// </summary>
		[EnumMember(Value = "named")]
		Named,
		/// <summary>
		/// Badges based on tags.
		/// </summary>
		[EnumMember(Value = "tag_based")]
		TagBased
	}
}