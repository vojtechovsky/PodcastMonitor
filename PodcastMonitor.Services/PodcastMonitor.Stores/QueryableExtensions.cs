using System;
using System.Linq;
using System.Linq.Expressions;

namespace PodcastMonitor.Stores
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property, bool sortDescending)
        {
            return OrderBy(source, property, sortDescending ? "OrderByDescending" : "OrderBy");
        }

        private static IOrderedQueryable<T> OrderBy<T>(IQueryable<T> source, string property, string methodName)
        {
            var props = property.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            foreach (var prop in props)
            {
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(method => method.Name == methodName &&
                                                                         method.IsGenericMethodDefinition &&
                                                                         method.GetGenericArguments().Length == 2 &&
                                                                         method.GetParameters().Length == 2)
                                          .MakeGenericMethod(typeof(T), type)
                                          .Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<T>)result;
        }
    }
}