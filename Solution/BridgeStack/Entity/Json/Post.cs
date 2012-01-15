using System;
using System.Collections.Generic;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents the intersection of the Question and Answer types.
	/// <para>https://api.stackexchange.com/docs/types/post</para>
	/// </summary>
	public sealed class Post : IPost<ShallowUser, Comment>
	{
		/// <summary>
		/// The body of the post.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The post owner.
		/// </summary>
		public ShallowUser Owner { get; set; }

		/// <summary>
		/// The date this post was created.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The date this post was last edited.
		/// </summary>
		public DateTime? LastEditDate { get; set; }

		/// <summary>
		/// The date this post was last active.
		/// </summary>
		public DateTime? LastActivityDate { get; set; }

		/// <summary>
		/// The current score for this post.
		/// </summary>
		public long? Score { get; set; }

		/// <summary>
		/// Total up votes on this post.
		/// </summary>
		public long? UpVoteCount { get; set; }

		/// <summary>
		/// Total down votes on this post.
		/// </summary>
		public long? DownVoteCount { get; set; }

		/// <summary>
		/// A list of comments on this post.
		/// </summary>
		public IList<Comment> Comments { get; set; }

		/// <summary>
		/// The id for this post.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// The type of post.
		/// </summary>
		public PostTypeEnum? PostType { get; set; }
	}
}