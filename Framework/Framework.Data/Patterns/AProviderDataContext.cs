// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service for single object sources.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Model;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.Patterns
{
    public abstract class AProviderDataContext : ACommon, IProviderDataContext
    {
        //
        // IMPLEMENTATION SPECIFIC
        // To be implemented by data context providers.
        //

        public abstract IGenericDataObject<T> GetDataObject<T>();

        public abstract IGenericDataSet<T> GetDataSet<T>();

        public abstract void CreateModel();

        //
        // INIT
        //

        public override void Init()
        {
            base.Init();
            _InitInMemoryStorage();

        }

        private void _InitInMemoryStorage()
        {
            _Entities = new SortedDictionary<string, DataEntity>();
            _Models = new SortedDictionary<string, DataPartialModel>();
        }

        //
        // LOAD
        //

        public void Load(IEnumerable<DataEntity> entities)
        {
            entities.Apply(Load);
        }

        public void Load(DataEntity entity)
        {
            if (null != entity)
            {
                if (entity.Name.isNotNullAndEmpty())
                {
                    if (!_Entities.ContainsKey(entity.Name))
                    {
                        _Entities.Add(entity.Name, entity);
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

        public void Load(IEnumerable<DataPartialModel> models)
        {
            models.Apply(Load);
        }

        public void Load(DataPartialModel model)
        {
            if (null != model)
            {
                if (model.Name.isNotNullAndEmpty())
                {
                    if (!_Models.ContainsKey(model.Name))
                    {
                        _Models.Add(model.Name, model);
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

        public IEnumerable<DataEntity> GetListOfEntities()
        {
            return _Entities.Values.ToList();
        }

        public IEnumerable<DataPartialModel> GetListOfPartialModels()
        {
            return _Models.Values.ToList(); ;
        }

        //
        // PRIVATE STATE
        //

        private IDictionary<string, DataEntity> _Entities = null;
        private IDictionary<string, DataPartialModel> _Models = null;
    }
}
