//using System;
//using Microsoft.EntityFrameworkCore;

//namespace Generic.Repository.EfCore.Helpers
//{
//    public static class DbContextExtensions
//    {
//        /// <summary>
//        /// Gets the object context from the specified <see cref="DbContext"/>.
//        /// </summary>
//        /// <param name="dbContext">The db context.</param>
//        /// <returns>The ObjectContext.</returns>
//        /// <exception cref="ArgumentNullException">The <paramref name="dbContext"/> is <c>null</c>.</exception>
//        public static ObjectContext GetObjectContext(this DbContext dbContext)
//        {
//            if (dbContext == null)
//            {
//                throw new ArgumentNullException("dbContext");
//            }

//            return ((IObjectContextAdapter)dbContext).ObjectContext;
//        }
//    }
//}
