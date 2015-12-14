// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Patterns;
using CONFIG = Framework.Factory.Model.Config;

namespace Framework.Factory.API.Interface.Config
{
    public interface IModel : IWrapperDataSet<CONFIG.Model>
    {
        CONFIG.Model GetByName(string name);

        CONFIG.Model GetByType(string type);
    }
}
