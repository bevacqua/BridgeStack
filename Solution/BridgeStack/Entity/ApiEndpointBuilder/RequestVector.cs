using System.Collections.Generic;
using System.Linq;
using BridgeStack.Resources;
using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// A request vector is tasked with parsing lists of elements when building an endpoint.
	/// </summary>
	/// <typeparam name="T">The strong type of the vector values.</typeparam>
	internal sealed class RequestVector<T> : IRequestVector
	{
		/// <summary>
		/// Even though request vectors can be smaller than this, the API is limited to responding at most with this amount of elements.
		/// </summary>
		public const int VectorMaxLength = 100;

		/// <summary>
		/// The name of the vector.
		/// </summary>
		private string Name { get; set; }
		/// <summary>
		/// A list of the values of this request vector.
		/// </summary>
		private T[] Values { get; set; }

		/// <summary>
		/// When this property is accessed, the request vector should be processed and it's result presented.
		/// </summary>
		public QueryParam Result
		{
			get { return new QueryParam(Name, SerializeVector(Values)); }
		}

		/// <summary>
		/// This method returns the serialized version of a collection of values to create a query parameter for the vectorized request.
		/// </summary>
		/// <param name="vector">The strongly typed vector values</param>
		/// <returns>The serialized vector values</returns>
		private string SerializeVector(ICollection<T> vector)
		{
			if (vector == null || vector.Count() == 0)
			{
				throw new BridgeException(Error.EmptyVector.FormatWith(Error.BadRequestParameter));
			}

			ICollection<string> parameters = vector
				.Where(v => v != null) // possible compare of value type with 'null' is to be ignored here.
				.Select(v => v.ToString()) // convert to strings.
				.Where(v => !v.NullOrEmpty()) // remove empties.
				.Distinct() // remove duplicates.
				.OrderBy(v => v) // sort the list in order to cache requests more effectively.
				.Take(VectorMaxLength) // the amount of parameters that can be passed to a vector is capped.
				.ToList();

			if (parameters.Count == 0)
			{
				throw new BridgeException(Error.EmptyVector.FormatWith(Error.BadRequestParameter));
			}
			string result = string.Join(";", parameters);
			return result;
		}

		/// <summary>
		/// Constructs an instance of a Request Vector
		/// </summary>
		/// <param name="name">The name of the vector.</param>
		/// <param name="values">A list of the values of this request vector.</param>
		public RequestVector(string name, T[] values)
		{
			Name = name;
			Values = values;
		}
	}
}