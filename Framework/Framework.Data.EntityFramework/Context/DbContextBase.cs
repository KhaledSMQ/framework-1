// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Model.Relational;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class BaseDbContext<TUser> : DbContext
    {
        //
        // CONSTRUCTORS
        //

        public BaseDbContext(string connectionString, Model.Objects.Context<TUser> dataContext)
            : base(connectionString)
        {
            //
            // Set the enitites and models for the context.
            //

            _Context = dataContext;

            //
            // Ensure the the DLL is copied to the target bin folder.
            //

            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }       

        //
        // MODEL-CONFIGURATION
        //

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            // Always call the base model create method.
            //

            base.OnModelCreating(modelBuilder);

            //
            // Add all entities in this data context to model.
            // These were setup by its constructor.
            //

            _Context.Entities.Apply(dataEntity =>
            {
                //
                // Register the entity with the model builder.
                //

                if (null != dataEntity)
                {
                    Type type = dataEntity.Type;
                    modelBuilder.RegisterEntityType(type);                    
                }
            });
        }

        //
        // PRIVATE FIELDS
        //

        private Model.Objects.Context<TUser> _Context = null;
    }
}
