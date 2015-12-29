// ============================================================================
// Project: Framework
// Name/Class: ICluster
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Cluster configuration interface.
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;

namespace Framework.Data.API.Interface
{
    public interface ICluster : IWrapperDataSet<DataCluster>
    {
        DataCluster GetByName(string name);
    }
}
