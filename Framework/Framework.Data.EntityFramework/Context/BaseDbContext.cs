// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 
// Company: Cybermap Lda.
// Description:
// ============================================================================

using System;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Objects
{
    public class BaseDbContext : DbContext
    {
        //
        // CONSTRUCTORS
        //

        public BaseDbContext(string connectionString, Action<object> seedHandler)
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
