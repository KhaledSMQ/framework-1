// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Data.Model.Query;
using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public interface IQueryProcessor : ICommon
    {
        Expression Parse(string input);
    }
}
