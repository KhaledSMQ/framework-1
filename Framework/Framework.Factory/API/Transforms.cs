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
using Framework.Factory.Model.Relational;

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
                Settings = elm.Settings.Map(s => { return new Setting() { ID = s.ID, Name = s.Name, Value = s.Value }; })
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
                Settings = elm.Settings.Map(s => { return new FW_FactorySetting() { ID = s.ID, Name = s.Name, Value = s.Value }; })
            };
        }
    }
}
