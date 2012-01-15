using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// The suggested edit query parameters.
	/// </summary>
	public sealed class SuggestedEditsQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Creation"/>, <see cref="QuerySortEnum.Approval"/> and <see cref="QuerySortEnum.Rejection"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Creation, QuerySortEnum.Approval, QuerySortEnum.Rejection)]
		public override QuerySortEnum? Sort { get; set; }
	}
}