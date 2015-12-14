// ============================================================================
// Project: Framework
// Name/Class: IDataEntity
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Entity data model specification contract.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Patterns
{
    public interface IDataEntity<TSetting> :
        IID<int>,
        IName<string>,
        IDescription<string>,
        ITypeName<string>,
        IConfigList<TSetting>,
        IAuditable<string>
        where TSetting : IConfigSetting<int, string, string, string> { }
}
