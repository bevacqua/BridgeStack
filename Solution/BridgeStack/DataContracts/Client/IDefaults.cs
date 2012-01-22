using System;
using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// Default values for queries coming from a particular client instance.
	/// </summary>
	public interface IDefaults : IStackClientPlugin
	{
		/// <summary>
		/// Default filter for all requests.
		/// </summary>
		string Filter { get; set; }
		/// <summary>
		/// Default page size for all requests.
		/// </summary>
		int? PageSize { get; set; }
		/// <summary>
		/// Default target network site for all requests.
		/// </summary>
		string Site { get; set; }
		/// <summary>
		/// Dictionary of cache life span default value user-defined overrides.
		/// </summary>
		IDictionary<ApiMethodEnum, TimeSpan> CacheLifeSpan { get; }
	}
}