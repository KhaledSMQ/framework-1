// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Api;

namespace Framework.Data.Api
{
    public interface IPartialModel : ICommon
    {
        void CreateModel(object dataContext);
    }
}
