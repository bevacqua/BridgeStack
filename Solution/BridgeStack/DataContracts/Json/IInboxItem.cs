using System;
using Newtonsoft.Json;

namespace BridgeStack
{
	/// <summary>
	/// Represents an item in a user's Global Inbox.
	/// <para>https://api.stackexchange.com/docs/types/inbox-item</para>
	/// </summary>
	/// <typeparam name="TSite">The concrete type of <see cref="INetworkSite{TStyling,TRelation}"/>.</typeparam>
	/// /// <typeparam name="TStyling">The concrete type of <see cref="INetworkSiteStyling"/>.</typeparam>
	/// <typeparam name="TRelation">The concrete type of <see cref="INetworkSiteRelation"/>.</typeparam>
	public interface IInboxItem<TSite, TStyling, TRelation>
		where TSite : INetworkSite<TStyling, TRelation>
		where TStyling : INetworkSiteStyling
		where TRelation : INetworkSiteRelation
	{
		/// <summary>
		/// The notification type.
		/// </summary>
		[JsonProperty("item_type")]
		string ItemType { get; set; } // This field's allowed values are subject to changes, so we avoid an enumeration.
		/// <summary>
		/// The related question's id, if any.
		/// </summary>
		[JsonProperty("question_id")]
		long? QuestionId { get; set; }
		/// <summary>
		/// The related answer's id, if any.
		/// </summary>
		[JsonProperty("answer_id")]
		long? AnswerId { get; set; }
		/// <summary>
		/// The related comment's id, if any.
		/// </summary>
		[JsonProperty("comment_id")]
		long? CommentId { get; set; }
		/// <summary>
		/// The title of the inbox item.
		/// </summary>
		[JsonProperty("title")]
		string Title { get; set; }
		/// <summary>
		/// The date this item was created.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("creation_date")]
		DateTime? CreationDate { get; set; }
		/// <summary>
		/// Whether the item was read by the user.
		/// </summary>
		[JsonProperty("is_unread")]
		bool? IsUnread { get; set; }
		/// <summary>
		/// The site this notification originated in.
		/// </summary>
		[JsonProperty("site")]
		TSite Site { get; set; }
		/// <summary>
		/// The body of the notification item.
		/// </summary>
		[JsonProperty("body")]
		string Body { get; set; }
		/// <summary>
		/// The provided link to the notification's item.
		/// </summary>
		[JsonProperty("link")]
		string Link { get; set; }
	}
}