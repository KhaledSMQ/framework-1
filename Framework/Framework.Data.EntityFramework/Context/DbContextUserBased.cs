// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 
// Company: Coop4Creativity
// Description:
// ============================================================================

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class DbContextUserBased<TUser> : IdentityDbContext<TUser> where TUser : IdentityUser
    {
        //
        // CONSTRUCTORS
        //

        public DbContextUserBased(string connectionString, Action<object> seedHandler)
            : base("name=" + connectionString)
        {
            //
            // Set the initializer for the database.
            //           
            // Database.SetInitializer<UserBasedDbContext<TUser>>(new DbCreateAlways<UserBasedDbContext<TUser>>(seedHandler));
            // Database.SetInitializer<UserBasedDbContext<TUser>>(new DbCreateIfModelChanges<UserBasedDbContext<TUser>>(seedHandler));
            //

            //
            // Ensure the the DLL is copied to the target bin folder.
            //

            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        //
        // ENTITY-CONFIGURATION
        //

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
