// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: Service to manage the set of backend servers.
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Client.API
{
    public interface IStore : ICommon
    {
        void ClientInit(string clientID);
    }
}
