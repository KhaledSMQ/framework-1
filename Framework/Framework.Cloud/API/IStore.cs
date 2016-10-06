// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: Service to manage the set of domains.
// ============================================================================

using Framework.Core.Api;

namespace Framework.Cloud.Api
{
    public interface IStore : ICommon
    {
        //
        // Domain Access Service Layer.
        //
        IDomain Domain { get; set; }
    }
}
