// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 
// Company: Coop4Creativity
// Description:
// ============================================================================

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class UserBasedDbContext<TUser> : IdentityDbContext<TUser> where TUser : IdentityUser
    {
        //
        // CONSTRUCTORS
        //

        public UserBasedDbContext(string connectionString, Action<object> seedHandler)
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
