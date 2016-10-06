// ============================================================================
// Project: Framework
// Name/Class: ConfigHelper
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Config;
using Framework.Core.Types.Specialized;

namespace Framework.Core.Helpers
{
    public static class ConfigHelper
    {
        //
        // SERVICE
        //

        public static Service Config2Service(this ServiceElement elm)
        {
            return new Service()
            {
                Unique = elm.Unique,
                Name = elm.Name,
                Description = elm.Description,
                Contract = elm.Contract,
                TypeName = elm.Type,
                Settings = elm.Settings.Map<SettingElement, Setting>(s => { return new Setting() { Name = s.Name, Value = s.Value }; })
            };
        }       
    }
}
