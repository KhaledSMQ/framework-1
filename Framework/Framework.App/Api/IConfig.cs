// ============================================================================
// Project: Framework
// Name/Class: IConfig
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration service for application management,
// ============================================================================

using Framework.Core.Api;

namespace Framework.App.Api
{
    public interface IConfig : ICommon
    {
        void Load();

        void Reload();
    }
}
