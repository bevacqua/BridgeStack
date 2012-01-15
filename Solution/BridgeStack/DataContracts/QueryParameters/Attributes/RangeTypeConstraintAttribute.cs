using System;

namespace BridgeStack
{
	/// <summary>
	/// Defines the Type that Min and Max parameters are constrained to.
	/// This is verified during query string parsing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class RangeTypeConstraintAttribute : Attribute
	{
		/// <summary>
		/// Indicates the type Min and Max parameters are constrained to.
		/// </summary>
		public Type Target { get; private set; }

		/// <summary>
		/// Indicates that this field does not accept min or max parameters.
		/// </summary>
		public RangeTypeConstraintAttribute()
			: this(null)
		{
		}

		/// <summary>
		/// Indicates the type Min and Max parameters are constrained to.
		/// </summary>
		public RangeTypeConstraintAttribute(Type type)
		{
			Target = type;
		}
	}
}