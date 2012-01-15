using System.Runtime.Serialization;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// The types of site.
	/// </summary>
	public enum SiteTypeEnum
	{
		/// <summary>
		/// A main site.
		/// </summary>
		[EnumMember(Value = "main_site")]
		Main,
		/// <summary>
		/// A meta site.
		/// </summary>
		[EnumMember(Value = "meta_site")]
		Meta
	}
}