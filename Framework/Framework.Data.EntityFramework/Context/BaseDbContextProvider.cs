// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Data.API;
using Framework.Data.EntityFramework.Objects;
using Framework.Data.Patterns;
using Framework.Factory.Attributes;
using System;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class BaseDbContextProvider : AProviderDataContext, IDataContext
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
            initialDbContext.Database.Initialize(true);
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

        public override IGenericDataObject<T> GetDataObject<T>()
        {
            return null;
        }

        public override IGenericDataSet<T> GetDataSet<T>()
        {
            return null;
        }

        public override IDynamicDataObject GetDataObject(Type type)
        {
            return null;
        }

        public override IDynamicDataSet GetDataSet(Type type)
        {
            BaseDynamicDataSet dataSet = new BaseDynamicDataSet();
            dataSet.Entity = type;
            dataSet.DataContext = new BaseDbContext(ConnectionString);

            return dataSet;
        }

    }
}
