using System;
using System.Collections.Generic;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents the state of a Post at some point in its history.
	/// <para>https://api.stackexchange.com/docs/types/revision</para>
	/// </summary>
	public sealed class Revision : IRevision<ShallowUser>
	{
		/// <summary>
		/// The guid for this revision.
		/// </summary>
		public Guid? RevisionGuid { get; set; }

		/// <summary>
		/// The order number of this revision.
		/// </summary>
		public long? RevisionNumber { get; set; }

		/// <summary>
		/// The type of revision.
		/// </summary>
		public RevisionTypeEnum? RevisionType { get; set; }

		/// <summary>
		/// The type of post.
		/// </summary>
		public PostTypeEnum? PostType { get; set; }

		/// <summary>
		/// The id of the post.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// An optional comment on the revision.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// The date this revision was created.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// Whether this revision is a rollback.
		/// </summary>
		public bool? IsRollback { get; set; }

		/// <summary>
		/// The body before the revision.
		/// </summary>
		public string LastBody { get; set; }

		/// <summary>
		/// The title before the revision.
		/// </summary>
		public string LastTitle { get; set; }

		/// <summary>
		/// The tags before the revision.
		/// </summary>
		public IList<string> LastTags { get; set; }

		/// <summary>
		/// The body after the revision.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The title after the revision.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The tags after the revision.
		/// </summary>
		public IList<string> Tags { get; set; }

		/// <summary>
		/// Whether this revision marked the post as community wiki.
		/// </summary>
		public bool? SetCommunityWiki { get; set; }

		/// <summary>
		/// The user who made the revision.
		/// </summary>
		public ShallowUser User { get; set; }
	}
}