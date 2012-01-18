using System.Linq;

namespace BridgeStack
{
	/// <summary>
	/// Wraps a single element returned by a request to the API.
	/// </summary>
	/// <typeparam name="T">The strong type for the <see cref="IBridgeResponse"/> object.</typeparam>
	internal sealed class BridgeResponseItem<T> : IBridgeResponseItem<T> where T : class
	{
		/// <summary>
		/// The base Bridge response object.
		/// </summary>
		private IBridgeResponseCollection<T> Component { get; set; }

		/// <summary>
		/// The object that builds the API route endpoint.
		/// </summary>
		public IApiEndpointBuilder EndpointBuilder
		{
			get { return Component.EndpointBuilder; }
		}

		/// <summary>
		/// The API response common "wrapper" object, as is.
		/// </summary>
		public IApiResponse<T> Response
		{
			get { return Component.Response; }
		}

		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be an internal error or come from the API response.
		/// </summary>
		public IBridgeException Exception
		{
			get { return Component.Exception; }
		}

		/// <summary>
		/// A list of elements of type <typeparamref name="T"/>, that's returned from the API.
		/// </summary>
		public T Safe
		{
			get { return Component.Safe.FirstOrDefault(); }
		}

		/// <summary>
		/// Returns the result directly, but raises an exception if the query resulted in an error.
		/// </summary>
		public T Unsafe
		{
			get
			{
				return Component.Unsafe.FirstOrDefault();
			}
		}

		/// <summary>
		/// True if the API call yielded no result items. This could be due to an error.
		/// </summary>
		public bool IsEmpty
		{
			get { return Safe == null; }
		}

		/// <summary>
		/// Creates a Bridge response object that contains a single result item.
		/// </summary>
		/// <param name="component">The base Bridge response object.</param>
		internal BridgeResponseItem(IBridgeResponseCollection<T> component)
		{
			Component = component;
		}
	}
}