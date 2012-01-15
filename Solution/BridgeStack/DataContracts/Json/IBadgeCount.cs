using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents the total Badges, segregated by rank, a user has earned.
	/// <para>https://api.stackexchange.com/docs/types/badge-count</para>
	/// </summary>
	public interface IBadgeCount
	{
		/// <summary>
		/// The amount of gold badges the user has earned.
		/// </summary>
		[JsonProperty("gold")]
		int? Gold { get; set; }
		/// <summary>
		/// The amount of silver badges the user has earned.
		/// </summary>
		[JsonProperty("silver")]
		int? Silver { get; set; }
		/// <summary>
		/// The amount of bronze badges the user has earned.
		/// </summary>
		[JsonProperty("bronze")]
		int? Bronze { get; set; }
	}
}