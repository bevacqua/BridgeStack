using System;
using System.Collections.Generic;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents a suggested edit on a Stack Exchange site.
	/// <para>https://api.stackexchange.com/docs/types/suggested-edit</para>
	/// </summary>
	public sealed class SuggestedEdit : ISuggestedEdit<ShallowUser>
	{
		/// <summary>
		/// The id of the suggested edit.
		/// </summary>
		public long? SuggestedEditId { get; set; }

		/// <summary>
		/// The id of the post this edit was suggested on.
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// The type of the post.
		/// </summary>
		public PostTypeEnum? PostType { get; set; }

		/// <summary>
		/// The body of the edited post.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The title of the edited post.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The tags of the edited post.
		/// </summary>
		public IList<string> Tags { get; set; }

		/// <summary>
		/// An optional comment regarding the reason behind the edit.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// The date this edit was suggested.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// The date this edit was approved.
		/// </summary>
		public DateTime? ApprovalDate { get; set; }

		/// <summary>
		/// The date this edit was rejected.
		/// </summary>
		public DateTime? RejectionDate { get; set; }

		/// <summary>
		/// The user who proposed the edit.
		/// </summary>
		public ShallowUser ProposingUser { get; set; }
	}
}