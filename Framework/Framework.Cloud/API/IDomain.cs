// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: Service to manage the set of domains.
// ============================================================================

using Framework.Core.Api;

namespace Framework.Cloud.Api
{
    public interface IDomain : ICommon
    {
        void Init(string domainID);
    }
}
