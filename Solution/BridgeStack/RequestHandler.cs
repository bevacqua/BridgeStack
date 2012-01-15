using System;
using System.Net;
using BridgeStack;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Object in charge of processing API requests, and deciding whether to access the API or return results from the internal cache instead.
	/// </summary>
	internal sealed class RequestHandler : IRequestHandler
	{
		/// <summary>
		/// Internal response cache store for the API.
		/// </summary>
		private IApiResponseStore _store;

		/// <summary>
		/// Instances the request handler.
		/// </summary>
		public RequestHandler()
		{
			_store = new ApiResponseStore();
		}

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
			IApiResponse<T> response = Request<T>(builder);
			IBridgeResponseCollection<T> result = new BridgeResponseCollection<T>(this, builder, response);
			return result;
		}

		/// <summary>
		/// Checks the cache and then performs the actual request, if required.
		/// </summary>
		/// <typeparam name="T">The strong type of the expected API result against which to deserialize JSON.</typeparam>
		/// <param name="builder">The object that builds the API route endpoint.</param>
		/// <returns>The API response object.</returns>
		private IApiResponse<T> Request<T>(IApiEndpointBuilder builder)
		{
			if (builder == null)
			{
				throw new ArgumentNullException("builder");
			}
			string endpoint = null;
			string responseText;
			IApiResponse<T> result;
			try
			{
				endpoint = builder.ToString();

				_store.Invalidate();
				IApiResponse<T> cached = _store.Get<T>(endpoint);
				if (cached != null)
				{
					result = cached;
					result.Source = ResultSourceEnum.Cache;
					return result;
				}

				using (WebClient client = new ApiWebClient())
				{
					responseText = client.DownloadString(endpoint);
				}
				result = responseText.DeserializeJson<ApiResponse<T>>();
				result.Dynamic = responseText.DeserializeJson();
				result.Source = ResultSourceEnum.Api;
			}
			catch (BridgeException api)
			{
				result = new ApiResponse<T>();
				result.Exception = api;
				result.Source = ResultSourceEnum.BridgeException;
			}
			catch (WebException web)
			{
				result = new ApiResponse<T>();
				try
				{
					WebResponse response = web.Response;
					if (response.ContentType == Utility.JsonMimeType)
					{
						responseText = response.GetResponseString();
						IApiException details = responseText.DeserializeJson<ApiException>();
						result.Exception = new BridgeException(Error.AccessingApiEndpoint.FormatWith(endpoint), web, details);
						result.Dynamic = responseText.DeserializeJson();
						result.Source = ResultSourceEnum.ApiException;
					}
					else
					{
						result.Exception = new BridgeException(Error.AccessingApiEndpoint.FormatWith(endpoint), web);
						result.Source = ResultSourceEnum.ApiException;
					}
				}
				catch (Exception e)
				{
					result.Exception = new BridgeException(Error.ExceptionAccessingApiEndpoint.FormatWith(endpoint), e);
					result.Source = ResultSourceEnum.ApiException;
				}
			}
			_store.Push(endpoint, result);
			return result;
		}
	}
}
