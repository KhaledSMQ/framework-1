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

namespace Framework.Data.EntityFramework.Context
{
    public class DbCreateIfNotExists<TDataContext> : DropCreateDatabaseAlways<TDataContext> where TDataContext : DbContext
    {
        //
        // PROPERTIES
        //

        protected Action<object> SeedHandler;

        //
        // CONSTRUCTORS
        // 

        public DbCreateIfNotExists() : this(null) { }

        public DbCreateIfNotExists(Action<object> seedHandler)
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
