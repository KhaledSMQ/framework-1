// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: Service to manage the set of backend servers.
// ============================================================================

using Framework.Core.API;

namespace Framework.Server.API
{
    public interface IStore : ICommon
    {
        void ServerInit(string serverID);
    }
}
