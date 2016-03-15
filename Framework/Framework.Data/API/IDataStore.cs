// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public interface IDataStore : ICommon
    {
        //
        // INIT
        //

        void InitClusters();

        //
        // LOAD
        //

        void Load(IEnumerable<DataCluster> clusters);

        void Load(DataCluster cluster);

        //
        // RETRIEVE
        //

        IEnumerable<DataCluster> GetListOfClusters();

        Type GetEntityTypeByClusterAndName(string cluster, string entity);
    }
}
