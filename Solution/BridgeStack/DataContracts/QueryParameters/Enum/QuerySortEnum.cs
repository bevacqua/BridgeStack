using System;
using System.Runtime.Serialization;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Query sort available fields.
	/// </summary>
	public enum QuerySortEnum
	{
		/// <summary>
		/// Sort by activity. Date range.
		/// </summary>
		[RangeTypeConstraint(typeof(DateTime))]
		[EnumMember(Value = "activity")]
		Activity,
		/// <summary>
		/// Sort by creation date. Date range.
		/// </summary>
		[RangeTypeConstraint(typeof(DateTime))]
		[EnumMember(Value = "creation")]
		Creation,
		/// <summary>
		/// Sort by votes. Numeric range.
		/// </summary>
		[RangeTypeConstraint(typeof(int))]
		[EnumMember(Value = "votes")]
		Votes,
		/// <summary>
		/// Sort by "hotness" score. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "hot")]
		Hot,
		/// <summary>
		/// Sort by highest voted this week. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "week")]
		Week,
		/// <summary>
		/// Sort by highest score this month. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "month")]
		Month,
		/// <summary>
		/// Sort by badge name. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "badgename")]
		BadgeName,
		/// <summary>
		/// Does not return unapproved suggestions. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "approval")]
		Approval,
		/// <summary>
		/// Does not return unrejected suggestions. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "rejection")]
		Rejection,
		/// <summary>
		/// Sort by badge rank. Allows <see cref="BadgeRankEnum"/> range.
		/// </summary>
		[RangeTypeConstraint(typeof(BadgeRankEnum))]
		[EnumMember(Value = "rank")]
		BadgeRank,
		/// <summary>
		/// Sort by last modification date. Date range.
		/// </summary>
		[RangeTypeConstraint(typeof(DateTime))]
		[EnumMember(Value = "modified")]
		Modified,
		/// <summary>
		/// Sort by name. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "name")]
		Name,
		/// <summary>
		/// Sort by reputation score. Numeric range.
		/// </summary>
		[RangeTypeConstraint(typeof(int))]
		[EnumMember(Value = "reputation")]
		Reputation,
		/// <summary>
		/// Sort by date added. Date range.
		/// </summary>
		[RangeTypeConstraint(typeof(DateTime))]
		[EnumMember(Value = "added")]
		Added,
		/// <summary>
		/// Sort by count. Numeric range.
		/// </summary>
		[RangeTypeConstraint(typeof(int))]
		[EnumMember(Value = "popular")]
		Popular,
		/// <summary>
		/// Sort by amount applied. Numeric range.
		/// </summary>
		[RangeTypeConstraint(typeof(int))]
		[EnumMember(Value = "applied")]
		Applied,
		/// <summary>
		/// Sort by relevance. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "relevance")]
		Relevance,
		/// <summary>
		/// Sort by type. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "type")]
		Type,
		/// <summary>
		/// Sort by date awarded. Date range.
		/// </summary>
		[RangeTypeConstraint(typeof(DateTime))]
		[EnumMember(Value = "awarded")]
		Awarded,
		/// <summary>
		/// Priority sort by site. No range.
		/// </summary>
		[RangeTypeConstraint]
		[EnumMember(Value = "rank")]
		QuestionRank
	}
}