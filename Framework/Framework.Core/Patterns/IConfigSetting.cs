// ============================================================================
// Project: Framework
// Name/Class: IConfigSetting
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Config setting data model specification contract.
// ============================================================================

namespace Framework.Core.Patterns
{
    public interface IConfigSetting<TID, TName, TDescription, TValue> : IID<TID>, IName<TName>, IDescription<TDescription>
    {
        //
        // PROPERTIES
        //

        TValue Value { get; set; }
    }
}
