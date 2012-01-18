using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BridgeStack
{
	/// <summary>
	/// Wraps a collection of elements returned by a request to the API.
	/// </summary>
	/// <typeparam name="T">The strong type for the <see cref="IBridgeResponse"/> object.</typeparam>
	public sealed class BridgeResponseCollection<T> : IBridgeResponseCollection<T> where T : class
	{
		/// <summary>
		/// The request handler.
		/// </summary>
		internal readonly IRequestHandler _requestHandler;

		/// <summary>
		/// The object that builds the API route endpoint.
		/// </summary>
		public IApiEndpointBuilder EndpointBuilder { get; private set; }

		/// <summary>
		/// The API response common "wrapper" object, as is.
		/// </summary>
		public IApiResponse<T> Response { get; private set; }

		/// <summary>
		/// The exception that was raised during the API call, if any. This can either be an error raised by the bridge or come from the API response.
		/// </summary>
		public IBridgeException Exception
		{
			get { return Response.Exception; }
		}

		/// <summary>
		/// A list of elements of type <typeparamref name="T"/>, that's returned from the API.
		/// </summary>
		public IEnumerable<T> Safe
		{
			get { return Response.Items ?? Enumerable.Empty<T>(); }
		}

		/// <summary>
		/// Returns the result directly, but raises an exception if the query resulted in an error.
		/// </summary>
		public IEnumerable<T> Unsafe
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
				return Safe;
			}
		}

		/// <summary>
		/// True if the API call yielded no result items. This could be due to an error.
		/// </summary>
		public bool IsEmpty
		{
			get { return !Safe.Any(); }
		}

		/// <summary>
		/// Boolean value indicating whether there are more pages available.
		/// </summary>
		public bool HasMore
		{
			get { return Response.HasMore ?? false; }
		}

		/// <summary>
		/// Requests the next page to the API, and returns it wrapped in an <see cref="IBridgeResponseCollection{T}"/> object.
		/// </summary>
		/// <returns>A wrapper around the response to the request for a next page. In abscence of a next page, this method returns the current page from the internal cache.</returns>
		public IBridgeResponseCollection<T> More()
		{
			if (HasMore)
			{
				if (EndpointBuilder.Query is IPagedQuery)
				{
					IPagedQuery paged = (IPagedQuery)EndpointBuilder.Query;
					paged.Page = (paged.Page ?? 1) + 1;
					return _requestHandler.ProcessRequest<T>(EndpointBuilder);
				}
			}
			return this;
		}

		/// <summary>
		/// Returns the first item in the response's result set. This method does not query the API.
		/// </summary>
		/// <returns>A wrapper around the result item.</returns>
		public IBridgeResponseItem<T> Single()
		{
			return new BridgeResponseItem<T>(this);
		}

		/// <summary>
		/// Creates a Bridge response object that contains a collection of result items.
		/// </summary>
		/// <param name="requestHandler">The request handler.</param>
		/// <param name="builder">The API endpoint builder.</param>
		/// <param name="response">The API response object.</param>
		internal BridgeResponseCollection(IRequestHandler requestHandler, IApiEndpointBuilder builder, IApiResponse<T> response)
		{
			if (requestHandler == null)
			{
				throw new ArgumentNullException("requestHandler");
			}
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}
			if (response == null)
			{
				throw new ArgumentNullException("response");
			}
			_requestHandler = requestHandler;
			EndpointBuilder = builder;
			Response = response;
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<T> GetEnumerator()
		{
			return Safe.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}