// ============================================================================
// Project: Framework
// Name/Class: Transforms
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Factory.Model.Relational;
using Framework.Factory.Model.Config;
using System.Collections.Generic;
using Framework.Factory.Model.Runtime;
using Framework.Core.Types.Specialized;

namespace Framework.Factory.API
{
    public static class Transforms
    {
        //
        // SERVICE
        //

        public static FW_FactoryServiceEntry Config2ServiceEntry(this ServiceElement elm)
        {
            return new FW_FactoryServiceEntry()
            {
                Unique = elm.Unique,
                Name = elm.Name,
                Description = elm.Description,
                Contract = elm.Contract,
                TypeName = elm.Type,
                Settings = elm.Settings.Map<SettingElement, FW_FactorySetting>(s => { return new FW_FactorySetting() { Name = s.Name, Value = s.Value }; })
            };
        }

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

        public static Service ServiceEntry2Service(this FW_FactoryServiceEntry elm)
        {
            return new Service()
            {
                ID = elm.ID,
                Module = elm.Module,
                Unique = elm.Unique,
                Name = elm.Name,
                Default = elm.Default,
                Description = elm.Description,
                Contract = elm.Contract,
                TypeName = elm.TypeName,
                Settings = elm.Settings.Map(new List<Setting>(), s => { return new Setting() {  ID=s.ID, Name = s.Name, Value = s.Value }; })
            };
        }

        public static FW_FactoryServiceEntry ServiceEntry2Service(this Service elm)
        {
            return new FW_FactoryServiceEntry()
            {
                ID = elm.ID,
                Module = elm.Module,
                Unique = elm.Unique,
                Name = elm.Name,
                Default = elm.Default,
                Description = elm.Description,
                Contract = elm.Contract,
                TypeName = elm.TypeName,
                Settings = elm.Settings.Map(new List<FW_FactorySetting>(), s => { return new FW_FactorySetting() { ID = s.ID, Name = s.Name, Value = s.Value }; })
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

        //
        // MODULE IMPORT
        //

        public static Module Config2Module(this ModuleElement elm)
        {
            return new Module()
            {
                Name = elm.Name,
                Description = elm.Description,
                TypeName = elm.Type,
                Settings = elm.Settings.Map<SettingElement, Setting>(s => { return new Setting() { Name = s.Name, Value = s.Value }; })
            };
        }
    }
}
