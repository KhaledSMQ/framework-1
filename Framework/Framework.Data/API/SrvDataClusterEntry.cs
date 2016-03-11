﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.API;
using Framework.Data.Model;
using Framework.Data.Patterns;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvDataClusterEntry : AWrapperDataSet<DataCluster>, IDataClusterEntry
    {
        public DataCluster GetByName(string name)
        {
            return DataLayer.Queryable().Where(i => i.Name == name).FirstOrDefault();
        }
    }
}