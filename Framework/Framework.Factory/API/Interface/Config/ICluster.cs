// ============================================================================
// Project: Framework
// Name/Class: ICluster
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Cluster configuration interface.
// ============================================================================

using Framework.Factory.Model.Config;
using Framework.Factory.Patterns;

namespace Framework.Factory.API.Interface.Config
{
    public interface ICluster : IWrapperDataSet<Cluster>
    {
        Cluster GetByName(string name);

        Cluster GetByType(string type);
    }
}
