// ============================================================================
// Project: Framework
// Name/Class: Transforms
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Model.Config;
using Framework.Core.Model.Runtime;
using Framework.Core.Types.Specialized;

namespace Framework.Core.API
{
    public static class Transforms
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

        //
        // MODULE IMPORT
        //

        public static Module Config2Module(this ModuleImportElement elm)
        {
            return new Module()
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
