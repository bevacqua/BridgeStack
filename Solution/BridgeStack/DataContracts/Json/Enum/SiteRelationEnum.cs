using System.Runtime.Serialization;

namespace BridgeStack
{
	/// <summary>
	/// Defines a relation between sites.
	/// </summary>
	public enum SiteRelationEnum
	{
		/// <summary>
		/// This is the parent of the related site.
		/// </summary>
		[EnumMember(Value = "parent")]
		Parent,
		/// <summary>
		/// This is the meta of the related site.
		/// </summary>
		[EnumMember(Value = "meta")]
		Meta,
		/// <summary>
		/// This is the chat of the related site.
		/// </summary>
		[EnumMember(Value = "chat")]
		Chat,
		/// <summary>
		/// This is related somehow else to the other site.
		/// </summary>
		[EnumMember(Value = "other")]
		Other
	}
}