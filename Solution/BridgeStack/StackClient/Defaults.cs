using System;
using System.Collections.Generic;

namespace BridgeStack
{
	/// <summary>
	/// Default values for queries coming from a particular client instance.
	/// </summary>
	internal sealed class Defaults : IDefaults
	{
		/// <summary>
		/// Default filter for all requests.
		/// </summary>
		public string Filter { get; set; }

		/// <summary>
		/// Default page size for all requests.
		/// </summary>
		public int? PageSize { get; set; }

		/// <summary>
		/// Default target network site for all requests.
		/// </summary>
		public string Site { get; set; }

		/// <summary>
		/// Dictionary of cache life span default value user-defined overrides.
		/// </summary>
		public IDictionary<ApiMethodEnum, TimeSpan> CacheLifeSpan { get; private set; }

		/// <summary>
		/// The parent <see cref="IStackClient"/>.
		/// </summary>
		public IStackClient Client { get; set; }

		/// <summary>
		/// Initializes the Defaults object.
		/// </summary>
		public Defaults()
		{
			CacheLifeSpan = new Dictionary<ApiMethodEnum, TimeSpan>();
		}
	}
}