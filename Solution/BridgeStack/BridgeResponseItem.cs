using System;
using System.Linq;
using BridgeStack;

namespace BridgeStack
{
	/// <summary>
	/// Wraps a single element returned by a request to the API.
	/// </summary>
	/// <typeparam name="T">The strong type for the <see cref="IBridgeResponse"/> object.</typeparam>
	public sealed class BridgeResponseItem<T> : IBridgeResponseItem<T> where T : class
	{
		/// <summary>
		/// The base Bridge response object.
		/// </summary>
		private IBridgeResponse<T> Component { get; set; }

		/// <summary>
		/// The object that builds the API route endpoint.
		/// </summary>
		public IApiEndpointBuilder EndpointBuilder { get; private set; }

		/// <summary>
		/// The API response common "wrapper" object, as is.
		/// </summary>
		public IApiResponse<T> Response { get; private set; }

		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be an internal error or come from the API response.
		/// </summary>
		public IBridgeException Exception
		{
			get { return Response.Exception; }
		}

		/// <summary>
		/// A list of elements of type <typeparamref name="T"/>, that's returned from the API.
		/// </summary>
		public T Safe
		{
			get { return Response.Items == null ? null : Response.Items.FirstOrDefault(); }
		}

		/// <summary>
		/// Returns the result directly, but raises an exception if the query resulted in an error.
		/// </summary>
		public T Unsafe
		{
			get
			{
				if (Response.Source == ResultSourceEnum.ApiException || Response.Source == ResultSourceEnum.BridgeException)
				{
					if (Response.Exception is Exception)
					{
						throw (Exception)Response.Exception;
					}
					throw Response.Exception.InnerException;
				}
				return Response.Items.FirstOrDefault();
			}
		}

		/// <summary>
		/// True if the API call was successful. False otherwise.
		/// </summary>
		public bool HasResult
		{
			get { return Safe != null; }
		}

		/// <summary>
		/// Creates a Bridge response object that contains a single result item.
		/// </summary>
		/// <param name="component">The base Bridge response object.</param>
		internal BridgeResponseItem(IBridgeResponse<T> component)
		{
			Component = component;
		}
	}
}