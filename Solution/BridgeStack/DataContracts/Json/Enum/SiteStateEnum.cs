using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines the site status.
	/// </summary>
	public enum SiteStateEnum
	{
		/// <summary>
		/// The site is in production state.
		/// </summary>
		[EnumMember(Value = "normal")]
		Normal,
		/// <summary>
		/// The site is in closed beta.
		/// </summary>
		[EnumMember(Value = "closed_beta")]
		ClosedBeta,
		/// <summary>
		/// The site is in open beta.
		/// </summary>
		[EnumMember(Value = "open_beta")]
		OpenBeta,
		/// <summary>
		/// This is the linked meta of a parent site.
		/// </summary>
		[EnumMember(Value = "linked_meta")]
		LinkedMeta
	}
}