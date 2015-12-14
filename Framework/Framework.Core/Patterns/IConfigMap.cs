// ============================================================================
// Project: Framework
// Name/Class: IConfigMap
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration object behaviour.
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    //
    // Generic configuration object.
    // @param T The type of the configuration setting value.
    //

    public interface IConfigMap<TID, TName, TDescription, TValue>
    {
        //
        // PROPERTIES
        // 

        IDictionary<TName, IConfigSetting<TID, TName, TDescription, TValue>> Settings { get; set; }
    }

    //
    // General configuration object.
    // Set the configuration setting to be a generic object.
    //

    public interface IConfigMap 
    {
        IDictionary<string, Setting> Settings { get; set; }
    }
}
