// ============================================================================
// Project: Framework
// Name/Class: IConfigList
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration object behaviour.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    //
    // Generic configuration object.
    // @param T The type of the configuration setting value.
    //

    public interface IConfigList<TID, TName, TDescription, TValue>
    {
        //
        // PROPERTIES
        // 

        ICollection<IConfigSetting<TID, TName, TDescription, TValue>> Settings { get; set; }
    }

    //
    // General configuration object.
    // Set the configuration setting to be a generic object.
    //

    public interface IConfigList<TSetting> where TSetting : IConfigSetting<int, string, string, string>
    {
        ICollection<TSetting> Settings { get; set; }
    }
}
