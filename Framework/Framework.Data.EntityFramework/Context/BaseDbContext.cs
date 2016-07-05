// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
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
    public class BaseDbContext : DbContext
    {
        //
        // CONSTRUCTORS
        //

        public BaseDbContext(string connectionString, IEnumerable<FW_DataEntity> entities, IEnumerable<FW_DataPartialModel> models)
            : base(connectionString)
        {
            //
            // Set the enitites and models for the context.
            //

            _Entities = entities;
            _Models = models;

            //
            // Ensure the the DLL is copied to the target bin folder.
            //

            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public BaseDbContext(string connectionString)
            : base(connectionString)
        {          
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

            _Entities.Apply(dataEntity =>
            {
                //
                // Register the entity with the model builder.
                //

                if (null != dataEntity)
                {
                    Type type = Type.GetType(dataEntity.TypeName);
                    modelBuilder.RegisterEntityType(type);                    
                }
            });
        }

        //
        // PRIVATE FIELDS
        //

        private IEnumerable<FW_DataEntity> _Entities = null;
        private IEnumerable<FW_DataPartialModel> _Models = null;
    }
}
