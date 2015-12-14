// ============================================================================
// Project: Framework
// Name/Class: IDataModel
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data model specification contract.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Patterns
{
    public interface IDataModel<TSetting> :
        IID<int>,
        IName<string>,
        IDescription<string>,
        ITypeName<string>,
        IConfigList<TSetting>,
        IAuditable<string>
        where TSetting : IConfigSetting<int, string, string, string> { }
}
