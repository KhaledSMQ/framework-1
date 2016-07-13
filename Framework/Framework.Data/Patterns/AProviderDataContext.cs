// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base service for single object sources.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.API;
using Framework.Data.Model.Relational;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.Patterns
{
    public abstract class AProviderDataContext : ACommon, IDataContext
    {
        //
        // IMPLEMENTATION SPECIFIC
        // To be implemented by data context providers.
        //

        public abstract IGenericDataObject<T> GetDataObject<T>();

        public abstract IGenericDataSet<T> GetDataSet<T>();

        public abstract IDynamicDataObject GetDataObject(Type type);

        public abstract IDynamicDataSet GetDataSet(Type type);

        public abstract void CreateModel();

        //
        // INIT
        //

        public override void Init()
        {
            base.Init();
            __Entities = new SortedDictionary<string, FW_DataEntity>();
            __Models = new SortedDictionary<string, FW_DataPartialModel>();
        }

        //
        // LOAD
        //

        public void Load(IEnumerable<FW_DataEntity> entities)
        {
            entities.Apply(Load);
        }

        public void Load(FW_DataEntity entity)
        {
            if (null != entity)
            {
                if (entity.Name.IsNotNullAndEmpty())
                {
                    if (!__Entities.ContainsKey(entity.Name))
                    {
                        __Entities.Add(entity.Name, entity);
                    }
                    else
                    {
                        //
                        // ERROR: Duplicate entity 
                        // 
                    }
                }
                else
                {
                    //
                    // ERROR: Invalid entity name.
                    //
                }
            }
            else
            {
                //
                // ERROR: Invalid entity object.
                //
            }
        }

        public void Load(IEnumerable<FW_DataPartialModel> models)
        {
            models.Apply(Load);
        }

        public void Load(FW_DataPartialModel model)
        {
            if (null != model)
            {
                if (model.Name.IsNotNullAndEmpty())
                {
                    if (!__Models.ContainsKey(model.Name))
                    {
                        __Models.Add(model.Name, model);
                    }
                    else
                    {
                        //
                        // ERROR: Duplicate model  
                        // 
                    }
                }
                else
                {
                    //
                    // ERROR: Invalid model name.
                    //
                }
            }
            else
            {
                //
                // ERROR: Invalid model object.
                //
            }
        }

        //
        // RETRIEVE
        //

        public IEnumerable<FW_DataEntity> GetListOfEntities()
        {
            return __Entities.Values.ToList();
        }

        public IEnumerable<FW_DataPartialModel> GetListOfPartialModels()
        {
            return __Models.Values.ToList(); ;
        }

        //
        // PRIVATE STATE
        //

        private IDictionary<string, FW_DataEntity> __Entities = null;
        private IDictionary<string, FW_DataPartialModel> __Models = null;
    }
}
