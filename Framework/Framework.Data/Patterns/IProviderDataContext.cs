﻿// ============================================================================
// Project: Framework
// Name/Class: IProviderDataContext
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data context for a group of data sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.Patterns
{
    public interface IProviderDataContext : ICommon
    {
        //
        // CRUDs
        //

        void Load(IEnumerable<DataEntity> entities);

        void Load(IEnumerable<DataPartialModel> models);

        IEnumerable<DataEntity> GetListOfEntities();

        IEnumerable<DataPartialModel> GetListOfPartialModels();

        //
        // DATA-SOURCE-FACTORIES
        //

        IDataSet<T> GetDataSet<T>();

        IDataObject<T> GetDataObject<T>();

        //
        // Model create handler.
        //

        void CreateModel();
    }
}