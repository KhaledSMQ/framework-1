// ============================================================================
// Project: Framework
// Name/Class: Transforms
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Config;
using Framework.Core.Types.Specialized;
using Framework.Server.Model.Relational;

namespace Framework.Server.Helpers
{
    public static class Transforms
    {
        //
        // SERVICE
        //

        public static FwServService Config2ServiceEntry(this ServiceElement elm)
        {
            return new FwServService()
            {
                Unique = elm.Unique,
                Name = elm.Name,
                Description = elm.Description,
                Contract = elm.Contract,
                TypeName = elm.Type,
                Settings = elm.Settings.Map<SettingElement, FwServSetting>(s => { return new FwServSetting() { Name = s.Name, Value = s.Value }; })
            };
        }


        public static Service ServiceEntry2Service(this FwServService elm)
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

        public static FwServService ServiceEntry2Service(this Service elm)
        {
            return new FwServService()
            {
                ID = elm.ID,
                Module = elm.Module,
                Unique = elm.Unique,
                Name = elm.Name,
                Default = elm.Default,
                Description = elm.Description,
                Contract = elm.Contract,
                TypeName = elm.TypeName,
                Settings = elm.Settings.Map(s => { return new FwServSetting() { ID = s.ID, Name = s.Name, Value = s.Value }; })
            };
        }
    }
}
