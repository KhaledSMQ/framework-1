// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 
// Company: Cybermap Lda.
// Description:
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;
using Framework.Factory.API.Attributes;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class EFBaseDataContextProvider : AProviderDataContext, IProviderDataContext
    {
        //
        // PROPERTIES
        //

        [ServiceProperty(Name = "CONNECTION-STRING")]
        public string ConnectionString { get; set; }

        [ServiceProperty(Name = "INITIALIZER")]
        public TypeOfDbInitializer Initializer { get; set; }

        //
        // CREATE MODEL
        // Method to initialize and cretae the model that the context
        // requires. In this case, We need to create an initial DbContext
        // and send it the data entities that we require, we also require
        // other properties, like the connection string name.
        //

        public override void CreateModel()
        {
            _SetupDbInitializer();
            BaseDbContext initialDbContext = new BaseDbContext(ConnectionString, GetListOfEntities(), GetListOfPartialModels());
        }

        public void _SetupDbInitializer()
        {
            switch (Initializer)
            {
                case TypeOfDbInitializer.CREATE_ALWAYS:
                    Database.SetInitializer(new DbCreateAlways<BaseDbContext>());
                    break;
                case TypeOfDbInitializer.CREATE_IF_MODEL_CHANGES:
                    Database.SetInitializer(new DbCreateIfModelChanges<BaseDbContext>());
                    break;
                case TypeOfDbInitializer.CREATE_IF_NOT_EXISTS:
                    Database.SetInitializer(new DbCreateIfNotExists<BaseDbContext>());
                    break;
            }
        }

        //
        // DATA LAYERS
        // Retrieve the data access layers for this data context.
        //

        public override IDataObject<T> GetDataObject<T>()
        {
            return null;
        }

        public override IDataSet<T> GetDataSet<T>()
        {
            return null;
        }
    }
}
