// ============================================================================
// Project: Framework
// Name/Class: ICnntext
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Entity configuration interface.
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;

namespace Framework.Data.API.Interface
{
    public interface IContext : IWrapperDataSet<DataContext>
    {
        DataContext GetByName(string name);

        DataContext GetByType(string type);
    }
}
