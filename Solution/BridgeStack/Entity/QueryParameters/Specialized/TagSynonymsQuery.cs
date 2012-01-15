using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// The tag synonyms query parameters.
	/// </summary>
	public sealed class TagSynonymsQuery : ComplexQuery
	{
		/// <summary>
		/// The sort criteria. Allows <see cref="QuerySortEnum.Activity"/>, <see cref="QuerySortEnum.Creation"/> and <see cref="QuerySortEnum.Applied"/>.
		/// </summary>
		[AllowedSortValues(QuerySortEnum.Activity, QuerySortEnum.Creation, QuerySortEnum.Applied)]
		public override QuerySortEnum? Sort { get; set; }
	}
}