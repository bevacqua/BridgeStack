using System.Runtime.Serialization;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Badge rank enumeration.
	/// </summary>
	public enum BadgeRankEnum
	{
		/// <summary>
		/// Gold badges.
		/// </summary>
		[EnumMember(Value = "gold")]
		Gold,
		/// <summary>
		/// Silver badges.
		/// </summary>
		[EnumMember(Value = "silver")]
		Silver,
		/// <summary>
		/// Bronze badges.
		/// </summary>
		[EnumMember(Value = "bronze")]
		Bronze
	}
}