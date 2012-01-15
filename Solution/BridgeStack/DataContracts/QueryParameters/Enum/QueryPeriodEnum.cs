using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// The period on which to query.
	/// </summary>
	public enum QueryPeriodEnum
	{
		/// <summary>
		/// All time.
		/// </summary>
		[EnumMember(Value="all_time")]
		AllTime,
		/// <summary>
		/// Last thirty days.
		/// </summary>
		[EnumMember(Value = "month")]
		Month
	}
}