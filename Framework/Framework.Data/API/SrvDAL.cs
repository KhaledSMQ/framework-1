// ============================================================================
// Project: Framework
// Name/Class: Data Access Layer
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 31/May/2016
// Company: Cybermap Lta.
// Description: Data Access Layer service implementation. 
// ============================================================================

using Framework.Core.Error;
using Framework.Data.Model.Mem;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Linq.Dynamic;

namespace Framework.Data.API
{
    public class SrvDAL : ACommon, IDAL
    {    
        public object Create(IProviderDataContext provider, MemEntity entity, object value)
        {
            //
            // Get the item to to process.
            //

            object item = __GetItem(entity, value);

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __GetDynamicDataSet(provider, entity);

            //
            // Create and save changes.
            //

            object output = dataSet.Create(item);
            dataSet.Save();

            //
            // Return output from create method to caller.
            //

            return output;
        }

        public object Query(IProviderDataContext provider, MemQuery query, MemEntity entity, object args)
        {
            //
            // Process arguments.
            //

            if (args.GetType() == typeof(string))
            {

            }

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __GetDynamicDataSet(provider, entity);

            //
            // Run query.
            //

            return dataSet.Queryable().Where(query.Query);
        }

        public object Update(IProviderDataContext provider, MemEntity entity, object value)
        {
            //
            // Get the item to to process.
            //

            object item = __GetItem(entity, value);

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __GetDynamicDataSet(provider, entity);

            //
            // Create and save changes.
            //

            object output = dataSet.Update(item);
            dataSet.Save();

            //
            // Return output from create method to caller.
            //

            return output;
        }

        public object Delete(IProviderDataContext provider, MemEntity entity, object value)
        {
            //
            // Get the item to to process.
            //

            object item = __GetItem(entity, value);

            //
            // Get the data layer for the entity.
            //

            IDynamicDataSet dataSet = __GetDynamicDataSet(provider, entity);            
            object output = dataSet.Delete(item);

            //
            // Create and save changes.
            //

            dataSet.Save();

            //
            // Return output from create method to caller.
            //

            return output;
        }

        private object __GetItem(MemEntity entity, object value)
        {
            object item = value;

            //
            // If value is a string, then we assume
            // that is an object in JSON fprmat.
            //

            if (value.GetType() == typeof(string))
            {
                item = Core.Helpers.JSONHelper.ReadJSONObjectFromString(entity.Type, (string)value);
            }

            return item;
        }    

        private IDynamicDataSet __GetDynamicDataSet(IProviderDataContext provider, MemEntity entity)
        {
            //
            // Default return value for entity data set.
            //            

            IDynamicDataSet dataSet = default(IDynamicDataSet);

            Type type = entity.Type;

            if (null != type)
            {
                dataSet = provider.GetDataSet(type);

                if (null == dataSet)
                {
                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get data set provider for entity '{0}'!", entity.ID);
                }
            }
            else
            {

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get type for entity '{0}'!", entity.ID);
            }

            //
            // Return the infered data set for entity.
            //

            return dataSet;
        }

        private IDynamicDataObject __GetDynamicDataObject(IProviderDataContext provider, MemEntity entity)
        {
            //
            // Default return value for entity data set.
            //            

            IDynamicDataObject dataObject = null;

            Type type = entity.Type;

            if (null != type)
            {
                dataObject = provider.GetDataObject(type);

                if (null == dataObject)
                {
                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get data set provider for entity '{0}'!", entity.ID);
                }
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "could not get type for entity '{0}'!", entity.ID);
            }

            //
            // Return the infered data set for entity.
            //

            return dataObject;
        }
    }
}
