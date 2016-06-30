// ============================================================================
// Project: Framework
// Name/Class: IProviderPartialModel
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Data partial model.
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Data.Patterns
{
    public interface IProviderPartialModel : ICommon
    {
        void CreateModel(object dataContext);
    }
}
