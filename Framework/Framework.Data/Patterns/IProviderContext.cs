// ============================================================================
// Project: Framework
// Name/Class: IProviderDataContext
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data context for a group of data sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Factory.Patterns;
using System;

namespace Framework.Data.Patterns
{
    public interface IProviderContext : ICommon
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
        // DATA-SOURCE-FACTORIES
        //

        IDataSet<T> GetDataSet<T>();

        IDataSet<T> GetDataSet<T>(IConfigMap cfg);

        IDataObject<T> GetDataObject<T>();

        IDataObject<T> GetDataObject<T>(IConfigMap cfg);

        //
        // Model create handler.
        //

        void OnModelCreating(object context);
    }
}
