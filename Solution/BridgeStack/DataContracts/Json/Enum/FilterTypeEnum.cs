using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the type of filter.
	/// </summary>
	public enum FilterTypeEnum
	{
		/// <summary>
		/// Safe filter type.
		/// </summary>
		[EnumMember(Value = "safe")]
		Safe,
		/// <summary>
		/// Unsafe filter type.
		/// </summary>
		[EnumMember(Value = "unsafe")]
		Unsafe,
		/// <summary>
		/// Invalid filter type.
		/// </summary>
		[EnumMember(Value = "invalid")]
		Invalid
	}
}