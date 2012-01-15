using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The related question query parameters.
	/// </summary>
	public sealed class QuestionsRelatedQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Votes"/> and <see cref="QuerySortEnum.QuestionRank"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Votes, QuerySortEnum.QuestionRank)]
		public override QuerySortEnum? Sort { get; set; }
	}
}