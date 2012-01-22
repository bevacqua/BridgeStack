using System;
using System.Net;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Object in charge of processing API requests, and deciding whether to access the API or return results from the internal cache instead.
	/// </summary>
	internal sealed class RequestHandler : IRequestHandler
	{
		/// <summary>
		/// The parent <see cref="IStackClient"/>.
		/// </summary>
		public IStackClient Client { get; set; }

		/// <summary>
		/// Processes a request, attempting to retrieve results from the cache whenever possible, and making API calls otherwise.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>A wrapper object around the result object. It's source is either the API, the internal cache, or raised exceptions.</returns>
		public IBridgeResponseCollection<T> ProcessRequest<T>(IApiEndpointBuilder builder) where T : class
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}
			IApiResponse<T> response = GetResponse<T>(builder);
			IBridgeResponseCollection<T> result = new BridgeResponseCollection<T>(this, builder, response);
			return result;
		}

		/// <summary>
		/// Produces the response object based on the API endpoint builder provided.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> GetResponse<T>(IApiEndpointBuilder builder) where T : class
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}
			IApiResponse<T> result = null;
			try
			{
				result = InternalProcessing<T>(builder); // Source = Api | Cache
			}
			catch (BridgeException api)
			{
				result = new ApiResponse<T> // Source = BridgeException
				{
					Exception = api,
					Source = ResultSourceEnum.BridgeException
				};
			}
			catch (WebException web)
			{
				result = HandleWebException<T>(web); // Source = ApiException
			}
			finally
			{
				if (result != null && result.Source != ResultSourceEnum.Cache)
				{
					Client.Cache.Push(builder, result);
				}
			}
			return result;
		}

		/// <summary>
		/// Checks the cache and then performs the actual request, if required.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> InternalProcessing<T>(IApiEndpointBuilder builder) where T : class
		{
			IApiResponse<T> result = FetchFromCache<T>(builder);
			return result ?? FetchFromThrottler<T>(builder);
		}

		/// <summary>
		/// Attempts to fetch the response object from the cache instead of directly from the API.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> FetchFromCache<T>(IApiEndpointBuilder builder) where T : class
		{
			IResponseCacheItem<T> cacheItem = Client.Cache.Get<T>(builder, true);
			if (cacheItem != null)
			{
				IApiResponse<T> result = cacheItem.Response;
				result.Source = ResultSourceEnum.Cache;
				return result;
			}
			return null;
		}

		/// <summary>
		/// Throttling ensures the API isn't flooded with requests and prevents us from getting cut off from the API.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> FetchFromThrottler<T>(IApiEndpointBuilder builder) where T : class
		{
			return Client.Throttler.Throttle<T>(builder);
		}

		/// <summary>
		/// Handles a web exception and returns an API response wrapper object filled with error debugging data.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="web">The web exception that has been raised.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> HandleWebException<T>(WebException web) where T : class
		{
			IApiResponse<T> result = new ApiResponse<T>();
			string endpoint = web.Response.ResponseUri.AbsoluteUri;
			try
			{
				WebResponse response = web.Response;
				if (response.ContentType == Utility.JsonMimeType)
				{
					string responseText = response.GetResponseString();
					IApiException details = responseText.DeserializeJson<ApiException>();
					result.Exception = new BridgeException(Error.AccessingApiEndpoint.FormatWith(endpoint), web, details);
					result.Dynamic = responseText.DeserializeJson();
				}
				else
				{
					result.Exception = new BridgeException(Error.AccessingApiEndpoint.FormatWith(endpoint), web);
				}
			}
			catch (Exception e)
			{
				result.Exception = new BridgeException(Error.ExceptionAccessingApiEndpoint.FormatWith(endpoint), e);
			}
			result.Source = ResultSourceEnum.ApiException;
			return result;
		}
	}
}