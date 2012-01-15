using System;
using System.Collections.Generic;

namespace BridgeStack.DataContracts
{
	/// <summary>
	/// Determines the sort values this property is allowed to take.
	/// This is verified during query string parsing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class AllowedSortValuesAttribute : Attribute
	{
		/// <summary>
		/// The allowed sort values for this property.
		/// </summary>
		public IEnumerable<QuerySortEnum> Values { get; private set; }

		/// <summary>
		/// Instances an allowed sort values constraint.
		/// </summary>
		/// <param name="values">The allowed sort values for this property.</param>
		public AllowedSortValuesAttribute(params QuerySortEnum[] values)
		{
			Values = values;
		}
	}
}