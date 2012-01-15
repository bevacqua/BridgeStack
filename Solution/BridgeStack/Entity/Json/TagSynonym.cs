using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a mapping from one tag to another, as part of a system's tag synonym list.
	/// <para>https://api.stackexchange.com/docs/types/tag-synonym</para>
	/// </summary>
	public sealed class TagSynonym : ITagSynonym
	{
		/// <summary>
		/// The tag synonym.
		/// </summary>
		public string FromTag { get; set; }

		/// <summary>
		/// The master tag.
		/// </summary>
		public string ToTag { get; set; }

		/// <summary>
		/// The count of how many times this mapping has been applied.
		/// </summary>
		public long? AppliedCount { get; set; }

		/// <summary>
		/// Date the mapping was last applied
		/// </summary>
		public DateTime? LastAppliedDate { get; set; }

		/// <summary>
		/// Date the tag synonym was created.
		/// </summary>
		public DateTime? CreationDate { get; set; }
	}
}