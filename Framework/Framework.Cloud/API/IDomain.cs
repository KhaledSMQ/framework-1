// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: Service to manage the set of domains.
// ============================================================================

using Framework.Core.API;

namespace Framework.Cloud.API
{
    public interface IDomain : ICommon
    {
        void Init(string domainID);
    }
}
