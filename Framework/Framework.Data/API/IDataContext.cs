// ============================================================================
// Project: Framework
// Name/Class: IProviderDataContext
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Data context for a group of data sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Model.Relational;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public interface IDataContext : ICommon
    {
        //
        // CRUDs
        //

        void Load(IEnumerable<FW_DataEntity> entities);

        void Load(IEnumerable<FW_DataPartialModel> models);

        IEnumerable<FW_DataEntity> GetListOfEntities();

        IEnumerable<FW_DataPartialModel> GetListOfPartialModels();

        //
        // DATA-SOURCE-FACTORIES
        //

        IGenericDataSet<T> GetDataSet<T>();

        IGenericDataObject<T> GetDataObject<T>();

        IDynamicDataSet GetDataSet(Type type);

        IDynamicDataObject GetDataObject(Type type);

        //
        // Model create handler.
        //

        void CreateModel();
    }
}
