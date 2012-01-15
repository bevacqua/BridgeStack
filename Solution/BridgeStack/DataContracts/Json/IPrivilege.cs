using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents a privilege a user may have on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/privilege</para>
	/// </summary>
	public interface IPrivilege
	{
		/// <summary>
		/// A short description for this privilege.
		/// </summary>
		[JsonProperty("short_description")]
		string ShortDescription { get; set; }
		/// <summary>
		/// The full description for this privilege.
		/// </summary>
		[JsonProperty("description")]
		string Description { get; set; }
		/// <summary>
		/// Reputation score necessary to earn this privilege.
		/// </summary>
		[JsonProperty("reputation")]
		long? Reputation { get; set; }
	}
}