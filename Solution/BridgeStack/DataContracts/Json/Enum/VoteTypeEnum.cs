using System.Runtime.Serialization;

namespace BridgeStack.DataContracts.Json
{
	/// <summary>
	/// Enumeration of different vote types and sources.
	/// </summary>
	public enum VoteTypeEnum
	{
		/// <summary>
		/// Accepted answers.
		/// </summary>
		[EnumMember(Value = "accepts")]
		Accepts,
		/// <summary>
		/// Up votes.
		/// </summary>
		[EnumMember(Value = "up_votes")]
		UpVotes,
		/// <summary>
		/// Down votes.
		/// </summary>
		[EnumMember(Value = "down_votes")]
		DownVotes,
		/// <summary>
		/// Offered bounties.
		/// </summary>
		[EnumMember(Value = "bounties_offered")]
		BountiesOffered,
		/// <summary>
		/// Won bounties.
		/// </summary>
		[EnumMember(Value = "bounties_won")]
		BountiesWon,
		/// <summary>
		/// Spam.
		/// </summary>
		[EnumMember(Value = "spam")]
		Spam,
		/// <summary>
		/// Suggested edits.
		/// </summary>
		[EnumMember(Value = "suggested_edits")]
		SuggestedEdits
	}
}