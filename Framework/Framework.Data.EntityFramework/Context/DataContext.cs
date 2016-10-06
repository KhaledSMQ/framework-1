// ============================================================================
// Project:
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Data.Api;
using Framework.Data.EntityFramework.Objects;
using Framework.Data.Patterns;
using Framework.Core.Attributes;
using System;
using System.Data.Entity;

namespace Framework.Data.EntityFramework.Context
{
    public class DataContext<TUser> : ADataContext<TUser>, IDataContext<TUser>
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
            SetupDbInitializer();
            BaseDbContext<TUser> initialDbContext = new BaseDbContext<TUser>(ConnectionString, Context);
            initialDbContext.Database.Initialize(true);
        }

        public void SetupDbInitializer()
        {
            switch (Initializer)
            {
                case TypeOfDbInitializer.CREATE_ALWAYS:
                    Database.SetInitializer(new DbCreateAlways<BaseDbContext<TUser>>());
                    break;
                case TypeOfDbInitializer.CREATE_IF_MODEL_CHANGES:
                    Database.SetInitializer(new DbCreateIfModelChanges<BaseDbContext<TUser>>());
                    break;
                case TypeOfDbInitializer.CREATE_IF_NOT_EXISTS:
                    Database.SetInitializer(new DbCreateIfNotExists<BaseDbContext<TUser>>());
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
            dataSet.DataContext = new BaseDbContext<TUser>(ConnectionString, Context);

            return dataSet;
        }

    }
}
