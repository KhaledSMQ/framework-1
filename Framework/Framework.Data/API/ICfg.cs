﻿// ============================================================================
// Project: Framework
// Name/Class: IMemStore
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Data.Model.Config;
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
