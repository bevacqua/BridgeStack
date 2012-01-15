using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Represents a change in reputation for a User.
	/// <para>https://api.stackexchange.com/docs/types/reputation</para>
	/// </summary>
	public sealed class Reputation : IReputation
	{
		/// <summary>
		/// The related id of an user.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// The related id of a post.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// The type of post.
		/// </summary>
		public PostTypeEnum? PostType { get; set; }

		/// <summary>
		/// The type of vote.
		/// </summary>
		public VoteTypeEnum? VoteType { get; set; }

		/// <summary>
		/// The title associated with the reputation change event.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// A link associated with the reputation change event.
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// The reputation change offset.
		/// </summary>
		public long? ReputationChange { get; set; }

		/// <summary>
		/// The date this reputation change took place.
		/// </summary>
		public DateTime? Date { get; set; }
	}
}