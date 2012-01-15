using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The question query parameters.
	/// </summary>
	public sealed class QuestionsQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Votes"/>, <see cref="QuerySortEnum.Hot"/>, <see cref="QuerySortEnum.Week"/> and <see cref="QuerySortEnum.Month"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Votes, QuerySortEnum.Hot, QuerySortEnum.Week, QuerySortEnum.Month)]
		public override QuerySortEnum? Sort { get; set; }
	}
}