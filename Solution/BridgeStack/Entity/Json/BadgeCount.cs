using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents the total Badges, segregated by rank, a user has earned.
	/// <para>https://api.stackexchange.com/docs/types/badge-count</para>
	/// </summary>
	public sealed class BadgeCount : IBadgeCount
	{
		/// <summary>
		/// The amount of gold badges the user has earned.
		/// </summary>
		public int? Gold { get; set; }

		/// <summary>
		/// The amount of silver badges the user has earned.
		/// </summary>
		public int? Silver { get; set; }

		/// <summary>
		/// The amount of bronze badges the user has earned.
		/// </summary>
		public int? Bronze { get; set; }
	}
}