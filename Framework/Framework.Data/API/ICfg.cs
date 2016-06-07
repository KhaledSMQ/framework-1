// ============================================================================
// Project: Framework
// Name/Class: IMemStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Data.Model.Config;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public interface ICfg : ICommon
    {
        void Load();

        IEnumerable<ConfigCluster> GetListOfClusters();
    }
}
