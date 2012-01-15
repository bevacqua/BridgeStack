using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a tag's wiki description.
	/// <para>https://api.stackexchange.com/docs/types/tag-wiki</para>
	/// </summary>
	public sealed class TagWiki : ITagWiki<ShallowUser>
	{
		/// <summary>
		/// The tag name.
		/// </summary>
		public string TagName { get; set; }

		/// <summary>
		/// The tag's description body.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The tag's description excerpt.
		/// </summary>
		public string Excerpt { get; set; }

		/// <summary>
		/// Date the body was last edited.
		/// </summary>
		public DateTime? LastBodyEdit { get; set; }

		/// <summary>
		/// Date the excerpt was last edited.
		/// </summary>
		public DateTime? LastExcerptEdit { get; set; }

		/// <summary>
		/// The last user who edited the body.
		/// </summary>
		public ShallowUser LastBodyEditor { get; set; }

		/// <summary>
		/// The last user who edited the excerpt.
		/// </summary>
		public ShallowUser LastExcerptEditor { get; set; }
	}
}