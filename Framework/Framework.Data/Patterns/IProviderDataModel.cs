// ============================================================================
// Project: Framework
// Name/Class: IDataModelProvider
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data partial model.
// ============================================================================

using Framework.Core.Patterns;
using System;

namespace Framework.Data.Patterns
{
    public interface IProviderDataModel : IProvider
    {
        //
        // DATA-SOURCE-REGISTRY
        //

        void AddDataSet<T>();

        void AddDataSet(Type type);

        void AddDataSet(string type);

        void AddDataObject<T>();

        void AddDataObject(Type type);

        void AddDataObject(string type);

        //
        // DATA-SOURCE-QUERY
        //

        bool HasDataSet<T>();

        bool HasDataSet(Type type);

        bool HasDataSet(string type);

        bool HasDataObject<T>();

        bool HasDataObject(Type type);

        bool HasDataObject(string type);

        //
        // MODEL-BUILD-HANDLER
        //

        void OnModelCreate(object context, IConfigMap config);
    }
}
