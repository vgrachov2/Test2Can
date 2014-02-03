﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test2Can.EFDao.Extensions
{
		public static class QueryExtension
		{
				/// <summary>
				/// Расширение позволяющие сортировать по имени свойства в EF. http://philsversion.com/2012/02/21/orderby-a-string-in-entity-framework/
				/// </summary>
				/// <typeparam name="T"></typeparam>
				/// <param name="source"></param>
				/// <param name="sortExpression"></param>
				/// <returns></returns>
				public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortExpression)
				{
						if (source == null)
								throw new ArgumentNullException("source", "source is null.");

						if (string.IsNullOrEmpty(sortExpression))
								throw new ArgumentException("sortExpression is null or empty.", "sortExpression");

						var parts = sortExpression.Split(' ');
						var isDescending = false;
						var propertyName = "";
						var tType = typeof(T);

						if (parts.Length > 0 && parts[0] != "")
						{
								propertyName = parts[0];

								if (parts.Length > 1)
								{
										isDescending = parts[1].ToLower().Contains("esc");
								}

								PropertyInfo prop = tType.GetProperty(propertyName);

								if (prop == null)
								{
										throw new ArgumentException(string.Format("No property '{0}' on type '{1}'", propertyName, tType.Name));
								}

								var funcType = typeof(Func<,>)
										.MakeGenericType(tType, prop.PropertyType);

								var lambdaBuilder = typeof(Expression)
										.GetMethods()
										.First(x => x.Name == "Lambda" && x.ContainsGenericParameters && x.GetParameters().Length == 2)
										.MakeGenericMethod(funcType);

								var parameter = Expression.Parameter(tType);
								var propExpress = Expression.Property(parameter, prop);

								var sortLambda = lambdaBuilder
										.Invoke(null, new object[] { propExpress, new ParameterExpression[] { parameter } });

								var sorter = typeof(Queryable)
										.GetMethods()
										.FirstOrDefault(x => x.Name == (isDescending ? "OrderByDescending" : "OrderBy") && x.GetParameters().Length == 2)
										.MakeGenericMethod(new[] { tType, prop.PropertyType });

								return (IQueryable<T>)sorter
										.Invoke(null, new object[] { source, sortLambda });
						}

						return source;
				}
		}
}
