// ============================================================================
// Project: Framework
// Name/Class: IEntity
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Entity configuration interface.
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;

namespace Framework.Data.API.Interface
{
    public interface IEntity : IWrapperDataSet<Entity>
    {
        Entity GetByName(string name);

        Entity GetByType(string type);
    }
}
