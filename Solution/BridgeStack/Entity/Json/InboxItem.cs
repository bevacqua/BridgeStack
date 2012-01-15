using System;
using BridgeStack.DataContracts.Json;

namespace BridgeStack.Entity.Json
{
	/// <summary>
	/// Represents an item in a user's Global Inbox.
	/// <para>https://api.stackexchange.com/docs/types/inbox-item</para>
	/// </summary>
	public sealed class InboxItem : IInboxItem<NetworkSite, NetworkSiteStyling, NetworkSiteRelation>
	{
		/// <summary>
		/// The notification type.
		/// </summary>
		public string ItemType { get; set; }

		/// <summary>
		/// The related question's id, if any.
		/// </summary>
		public long? QuestionId { get; set; }

		/// <summary>
		/// The related answer's id, if any.
		/// </summary>
		public long? AnswerId { get; set; }

		/// <summary>
		/// The related comment's id, if any.
		/// </summary>
		public long? CommentId { get; set; }

		/// <summary>
		/// The title of the inbox item.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The date this item was created.
		/// </summary>
		public DateTime? CreationDate { get; set; }

		/// <summary>
		/// Whether the item was read by the user.
		/// </summary>
		public bool? IsUnread { get; set; }

		/// <summary>
		/// The site this notification originated in.
		/// </summary>
		public NetworkSite Site { get; set; }

		/// <summary>
		/// The body of the notification item.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The provided link to the notification's item.
		/// </summary>
		public string Link { get; set; }
	}
}