using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the order direction for the query results.
	/// </summary>
	public enum QueryOrderEnum
	{
		/// <summary>
		/// Descending order direction.
		/// </summary>
		[EnumMember(Value = "desc")]
		Descending,
		/// <summary>
		/// Ascending order direction.
		/// </summary>
		[EnumMember(Value = "asc")]
		Ascending
	}
}