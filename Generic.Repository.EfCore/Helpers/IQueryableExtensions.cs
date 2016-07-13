//using System;
//using System.Linq;
//using System.Linq.Expressions;

//namespace Generic.Repository.EfCore.Helpers
//{
//    public static class IQueryableExtensions
//    {
//        /// <summary>
//        /// Allows for tables to be joined and included in a query
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="query"></param>
//        /// <param name="includes"></param>
//        /// <example>
//        /// var query = repository.AllQueryable()
//        //      .IncludeMultiple(
//        //          c => c.Address,
//        //          c => c.Orders.Select(o => o.OrderItems));
//        /// </example>
//        public static IQueryable<T> Includes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
//            where T : class
//        {
//            if (includes != null)
//            {
//                query = includes.Aggregate(query,
//                          (current, include) => current.Include(include));
//            }

//            return query;
//        }
//    }
//}