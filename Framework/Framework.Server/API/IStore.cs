// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: Service to manage the set of backend servers.
// ============================================================================

using Framework.Core.Api;

namespace Framework.Server.Api
{
    public interface IStore : ICommon
    {
        void ServerInit(string serverID);
    }
}
