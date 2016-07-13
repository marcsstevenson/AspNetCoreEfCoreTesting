//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace FWS.Generic.Framework.Repository.EF.Helpers
//{
//    public class DbMigrationManager<i, k> where i : DbMigrationsConfiguration<k>, new() where k: DbContext
//    {
//        public static DbMigrator GetMigrator()
//        {
//            var configuration = new i
//            {
//                AutomaticMigrationDataLossAllowed = true
//            };

//            return new DbMigrator(configuration);
//        }

//        public static IEnumerable<string> GetPendingCodeMigrations()
//        {
//            var migrator = GetMigrator();
//            return migrator.GetPendingMigrations();
//        }

//        public static void RunUpdate()
//        {
//            var migrator = GetMigrator();
//            migrator.Update();
//        }

//        /// <summary>
//        /// Running this should clear all database structures and restore them using migrations
//        /// </summary>
//        public static void RollbackAndUpdate()
//        {
//            var dBMigrator = GetMigrator();
//            dBMigrator.Update("0");
//            dBMigrator.Update();
//        }
//    }
//}