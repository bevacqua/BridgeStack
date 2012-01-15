using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;
using BridgeStack.Common;
using BridgeStack.Common.Resources;
using BridgeStack.DataContracts;

namespace BridgeStack.Entity
{
	/// <summary>
	/// Helper methods for the QueryParam class
	/// </summary>
	public static class QueryParamHelpers
	{
		/// <summary>
		/// Converts a IQuery concrete implementation into a query string parameter collection
		/// </summary>
		/// <typeparam name="T">The concrete type of the implementation</typeparam>
		/// <param name="entity">The query object to parse</param>
		/// <returns>A collection of query string parameters</returns>
		public static IEnumerable<QueryParam> ToQueryParams<T>(this T entity) where T : class, IQuery
		{
			if (entity == null)
			{
				yield break;
			}
			CheckRequiredPropertiesOnInterface(entity);

			foreach (PropertyInfo prop in Utility.GetAllProperiesOfObject(entity))
			{
				string name = prop.Name;
				object gotten = prop.GetGetMethod().Invoke(entity, null);

				CheckRequiredPropertyOnMember(entity, prop, gotten, false);

				if (gotten == null)
				{
					continue;
				}
				if (gotten is IEnumerable<string>)
				{
					IEnumerable<string> values = ((IEnumerable<string>)gotten).Where(v => !v.NullOrEmpty());
					string value = string.Join(";", values);
					if (!value.NullOrEmpty())
					{
						yield return new QueryParam(name, value);
					}
				}
				else if (gotten is DateTime)
				{
					string value = ((DateTime)gotten).ToUnixTime().ToString();
					if (!value.NullOrEmpty())
					{
						yield return new QueryParam(name, value);
					}
				}
				else if (gotten is Enum)
				{
					string value;
					var alt = ((Enum)gotten).GetCustomAttribute<EnumMemberAttribute>();
					if (alt != null && !alt.Value.NullOrEmpty())
					{
						value = alt.Value;
					}
					else
					{
						value = Enum.GetName(gotten.GetType(), gotten);
					}

					if (entity is ISortableQuery && gotten is QuerySortEnum)
					{
						var allowed = prop.GetCustomAttribute<AllowedSortValuesAttribute>();
						if (allowed != null && !allowed.Values.Contains((QuerySortEnum)gotten))
						{
							string message = Error.SortValueConstraint;
							throw new ApiException(message.FormatWith(name, value, Error.BadRequestParameter));
						}
						ISortableQuery sortable = (ISortableQuery)entity;
						var allowedType = ((Enum)gotten).GetCustomAttribute<AllowedRangeTypeAttribute>();
						if (allowedType != null)
						{
							Type expected = allowedType.Target;
							if (expected == null && (sortable.Min != null || sortable.Max != null))
							{
								string message = Error.SortMinMaxConstraint;
								throw new ApiException(message.FormatWith(name, value, Error.BadRequestParameter));
							}
							if (expected != null)
							{
								CheckTypeConstrain("Min", sortable.Min, expected);
								CheckTypeConstrain("Max", sortable.Max, expected);
							}
						}
					}
					yield return new QueryParam(name, value);
				}
				else
				{
					string value = gotten.ToString();
					if (!value.NullOrEmpty())
					{
						yield return new QueryParam(name, value);
					}
				}
			}
		}

		/// <summary>
		/// Performs a check for required parameters attributes declared directly on interface members (instead of on concrete members).
		/// Throws an exception when a parameter marked as required has a null value or is an empty string.
		/// </summary>
		/// <typeparam name="T">The concrete type of the implementation</typeparam>
		/// <param name="entity">The query object to parse</param>
		private static void CheckRequiredPropertiesOnInterface<T>(this T entity) where T : class, IQuery
		{
			Type[] interfaces = entity.GetType().GetInterfaces();
			foreach (PropertyInfo prop in interfaces.SelectMany(type => type.GetProperties()))
			{
				CheckRequiredPropertyOnMember(entity, prop);
			}
		}

		/// <summary>
		/// Throws an exception when a parameter marked as required has a null value or is an empty string.
		/// </summary>
		/// <typeparam name="T">The concrete type of the implementation</typeparam>
		/// <param name="entity">The query object to parse</param>
		/// <param name="prop">The property to check for required parameter attributes</param>
		/// <param name="value">The value assigned to the property</param>
		/// <param name="useGetter">If set, the value will be overridden with the result of invoking the getter for the property. Defaults to true.</param>
		private static void CheckRequiredPropertyOnMember<T>(this T entity, PropertyInfo prop, object value = null, bool useGetter = true) where T : class, IQuery
		{
			if (Attribute.IsDefined(prop, typeof(RequiredParameterAttribute)))
			{
				if (useGetter)
				{
					value = prop.GetGetMethod().Invoke(entity, null);
				}
				if (value == null || (value is string && (string)value == string.Empty))
				{
					string message = Error.RequiredParameterConstraint;
					throw new ApiException(message.FormatWith(prop.Name, Error.BadRequestParameter));
				}
			}
		}

		/// <summary>
		/// Throws an exception if a parameter is of a Type other than the type expected
		/// </summary>
		/// <param name="name">The property name</param>
		/// <param name="target">The parameter object</param>
		/// <param name="expected">The expected type for this parameter</param>
		private static void CheckTypeConstrain(string name, object target, Type expected)
		{
			if (target == null)
			{
				return;
			}
			Type actual = target.GetType();
			if (actual != expected)
			{
				string message = Error.SortRangeTypeConstraint;
				throw new ApiException(message.FormatWith(name, expected.Name, actual.Name, Error.BadRequestParameter));
			}
		}
	}
}
