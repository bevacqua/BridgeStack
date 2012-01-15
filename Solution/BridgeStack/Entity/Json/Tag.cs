using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a tag on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/tag</para>
	/// </summary>
	public sealed class Tag : ITag
	{
		/// <summary>
		/// The name of the tag.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Whether this is a required tag.
		/// </summary>
		public bool? IsRequired { get; set; }

		/// <summary>
		/// Whether only moderators can use this tag.
		/// </summary>
		public bool? IsModeratorOnly { get; set; }

		/// <summary>
		/// The related user id.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// The amount of times this tag was employed.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Whether this tag has any synonyms associated to it.
		/// </summary>
		public bool? HasSynonyms { get; set; }

		/// <summary>
		/// The date this tag was last active.
		/// </summary>
		public DateTime? LastActivityDate { get; set; }
	}
}