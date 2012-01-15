using System;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// A simple query that can be constrained to a window in time.
	/// </summary>
	public class RangedQuery : SimpleQuery, IRangedQuery
	{
		/// <summary>
		/// The date window filter's From date.
		/// </summary>
		public DateTime? FromDate { get; set; }

		/// <summary>
		/// The date window filter's To date.
		/// </summary>
		public DateTime? ToDate { get; set; }
	}
}