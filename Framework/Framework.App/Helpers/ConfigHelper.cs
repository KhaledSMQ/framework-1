// ============================================================================
// Project: Framework
// Name/Class: Transforms
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.App.Config;
using Framework.Core.Extensions;
using Framework.Core.Config;
using Framework.Core.Types.Specialized;
using Framework.App.Runtime;

namespace Framework.App.Api
{
    public static class Transforms
    {
        //
        // MODULE IMPORT
        //

        public static Core.Types.Specialized.Module Config2Module(this ModuleImportElement elm)
        {
            return new Core.Types.Specialized.Module()
            {
                Name = elm.Name,
                Description = elm.Description,
                TypeName = elm.Type,
                Settings = elm.Settings.Map<SettingElement, Setting>(s => { return new Setting() { Name = s.Name, Value = s.Value }; })
            };
        }

        //
        // STARTUP-SEQUENCE
        //

        public static MethodCall Config2MethodCall(this MethodCallElement elm)
        {
            return new MethodCall()
            {
                Service = elm.Service,
                Method = elm.Method
            };
        }
    }
}
