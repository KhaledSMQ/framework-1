// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class DbCreateAlways<TDataContext> : DropCreateDatabaseAlways<TDataContext> where TDataContext : DbContext
    {
        //
        // PROPERTIES
        //

        protected Action<object> SeedHandler;

        //
        // CONSTRUCTORS
        // 

        public DbCreateAlways() : this(null) { }

        public DbCreateAlways(Action<object> seedHandler)
            : base()
        {
            SeedHandler = seedHandler;
        }

        //
        // Use this method to pre-populate the database.
        //

        protected override void Seed(TDataContext context)
        {
            //
            // Execute data initialization handler.
            //

            if (null != SeedHandler)
            {
                SeedHandler(context);
            }
        }
    }
}
