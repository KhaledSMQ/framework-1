// ============================================================================
// Project: Framework
// Name/Class: ICnntext
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Entity configuration interface.
// ============================================================================

using Framework.Factory.Model.Config;
using Framework.Factory.Patterns;

namespace Framework.Factory.API.Interface.Config
{
    public interface IContext : IWrapperDataSet<Context>
    {
        Context GetByName(string name);

        Context GetByType(string type);
    }
}
