using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using BridgeStack.Resources;

namespace BridgeStack
{
	/// <summary>
	/// Helper methods for the QueryParam class.
	/// </summary>
	internal static class QueryParamHelpers
	{
		/// <summary>
		/// Converts a IQuery concrete implementation into a query string parameter collection.
		/// </summary>
		/// <typeparam name="T">The concrete type of the implementation.</typeparam>
		/// <param name="entity">The query object to parse.</param>
		/// <returns>A collection of query string parameters.</returns>
		public static IEnumerable<QueryParam> ToQueryParams<T>(this T entity) where T : class, IQuery
		{
			if (entity == null)
			{
				yield break;
			}
			CheckRequiredPropertiesOnInterface(entity); // in case constrains are present on the interface.
			bool? hasUnsetRequiredOr = null;
			IList<string> requiredOrFields = new List<string>();

			foreach (PropertyInfo prop in Utility.GetAllProperiesOfObject(entity))
			{
				string name = prop.Name;
				object gotten = prop.GetGetMethod().Invoke(entity, null);

				CheckRequiredProperty(entity, prop, gotten, false); // in case constrains are present at class level.

				RequiredParameterOrAttribute requiredOr = prop.GetCustomAttribute<RequiredParameterOrAttribute>();
				if (requiredOr != null)
				{
					requiredOrFields.Add(name);
					bool unset = gotten == null || (gotten is string && (string)gotten == string.Empty);
					if (!hasUnsetRequiredOr.HasValue && unset)
					{
						hasUnsetRequiredOr = true;
					}
					else
					{
						hasUnsetRequiredOr = false;
					}
				}
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
					string value = ((DateTime)gotten).ToUnixDate().ToString();
					if (!value.NullOrEmpty())
					{
						yield return new QueryParam(name, value);
					}
				}
				else if (gotten is Enum)
				{
					string value = ((Enum)gotten).GetValue();

					if (entity is ISortableQuery && gotten is QuerySortEnum)
					{
						var allowed = prop.GetCustomAttribute<AllowedSortValuesAttribute>();
						if (allowed != null && !allowed.Values.Contains((QuerySortEnum)gotten))
						{
							string message = Error.SortValueConstraint;
							throw new BridgeException(message.FormatWith(name, value, Error.BadRequestParameter));
						}
						ISortableQuery sortable = (ISortableQuery)entity;
						var allowedType = ((Enum)gotten).GetCustomAttribute<RangeTypeConstraintAttribute>();
						if (allowedType != null)
						{
							Type expected = allowedType.Target;
							if (expected == null && (sortable.Min != null || sortable.Max != null))
							{
								string message = Error.SortMinMaxConstraint;
								throw new BridgeException(message.FormatWith(name, value, Error.BadRequestParameter));
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
			if (hasUnsetRequiredOr.HasValue && hasUnsetRequiredOr.Value)
			{
				string message = Error.RequiredParameterFieldsConstraint;
				string fields = string.Join(", ", requiredOrFields.Select(f => "'{0}'".FormatWith(f)));
				throw new BridgeException(message.FormatWith(fields, Error.BadRequestParameter));
			}
		}

		/// <summary>
		/// Performs a check for required parameters attributes declared directly on interface members (instead of on concrete members).
		/// Throws an exception when a parameter marked as required has a null value or is an empty string.
		/// </summary>
		/// <typeparam name="T">The concrete type of the implementation.</typeparam>
		/// <param name="entity">The query object to parse.</param>
		private static void CheckRequiredPropertiesOnInterface<T>(this T entity) where T : class, IQuery
		{
			Type[] interfaces = entity.GetType().GetInterfaces();
			foreach (PropertyInfo prop in interfaces.SelectMany(type => type.GetProperties()))
			{
				CheckRequiredProperty(entity, prop);
			}
		}

		/// <summary>
		/// Throws an exception when a parameter marked as required has a null value or is an empty string.
		/// </summary>
		/// <typeparam name="T">The concrete type of the implementation.</typeparam>
		/// <param name="entity">The query object to parse.</param>
		/// <param name="prop">The property to check for required parameter attributes.</param>
		/// <param name="value">The value assigned to the property.</param>
		/// <param name="useGetter">If set, the value will be overridden with the result of invoking the getter for the property. Defaults to true.</param>
		private static void CheckRequiredProperty<T>(this T entity, PropertyInfo prop, object value = null, bool useGetter = true) where T : class, IQuery
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
					throw new BridgeException(message.FormatWith(prop.Name, Error.BadRequestParameter));
				}
			}
		}

		/// <summary>
		/// Throws an exception if a parameter is of a Type other than the type expected.
		/// </summary>
		/// <param name="name">The property name.</param>
		/// <param name="target">The parameter object.</param>
		/// <param name="expected">The expected type for this parameter.</param>
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
				throw new BridgeException(message.FormatWith(name, expected.Name, actual.Name, Error.BadRequestParameter));
			}
		}

		/// <summary>
		/// Deserializes a list of <see cref="QueryParam"/> into a query parameters string list.
		/// </summary>
		/// <param name="query">The typed query parameters.</param>
		/// <returns>A query parameters concatenated string.</returns>
		public static string Deserialize(this IEnumerable<QueryParam> query)
		{
			IEnumerable<QueryParam> parameters = query.Where(p => !p.ToString().NullOrEmpty());
			string result = string.Join("&", parameters);
			return result;
		}

		/// <summary>
		/// Deserializes a list of <see cref="QueryParam"/> and returns the full query string.
		/// </summary>
		/// <param name="query">The typed query parameters.</param>
		/// <returns>A query string.</returns>
		public static string DeserializeAsQueryString(this IEnumerable<QueryParam> query)
		{
			string parameters = query.Deserialize();
			if (parameters.Any())
			{
				return string.Concat("?", parameters);
			}
			return string.Empty;
		}
	}
}
