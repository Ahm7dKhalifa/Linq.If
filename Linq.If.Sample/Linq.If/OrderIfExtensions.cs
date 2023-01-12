using System;
using System.Linq;
using System.Linq.Expressions;

namespace Linq.If
{
    public static class OrdersExtensions
    {
        public static IOrderedQueryable<TSource> OrderByIf<TSource, TKey>(this IQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
           return condition ? query.OrderBy(orderByExpression):query.OrderBy(i=>0);
        }
        public static IOrderedQueryable<TSource> OrderByIf<TSource, TKey>(this IOrderedQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
          return condition ? query.OrderBy(orderByExpression):query;
        }

        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
          return  condition? query.OrderByDescending(orderByExpression):
                query.OrderByDescending(i=>0);
        }
        public static IOrderedQueryable<TSource> OrderByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
           return condition ? query.OrderByDescending(orderByExpression): query;
        }
        public static IOrderedQueryable<TSource> ThenByIf<TSource, TKey>(this IOrderedQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
            return condition ? query.ThenBy(orderByExpression) : query;
        }


        public static IOrderedQueryable<TSource> ThenByDescendingIf<TSource, TKey>(this IOrderedQueryable<TSource> query, bool condition, Expression<Func<TSource, TKey>> orderByExpression)
        {
            return condition ? query.ThenByDescending(orderByExpression) : query;
        }
    }
}
