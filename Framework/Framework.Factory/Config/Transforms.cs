// ============================================================================
// Project: Framework
// Name/Class: Transform
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Factory.Model;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Factory.Config
{
    public static class Transforms
    {
        //
        // SERVICES
        //

        public static IEnumerable<ServiceEntry> ToService(this ServiceElementCollection collection)
        {
            List<ServiceEntry> coll = new List<ServiceEntry>();
            if (null != collection)
            {
                foreach (ServiceElement elm in collection)
                {
                    coll.Add(ToService(elm));
                }
            }
            return coll;
        }

        public static ServiceEntry ToService(this ServiceElement serviceElm)
        {
            ServiceEntry service = new ServiceEntry();
            service.Unique = serviceElm.Unique;
            service.Name = serviceElm.Name;
            service.Description = serviceElm.Description;
            service.Contract = serviceElm.Contract;
            service.TypeName = serviceElm.Type;
            service.Settings = ToSetting(serviceElm.Settings);
            return service;
        }

        //
        // SETTING
        //

        public static ICollection<Setting> ToSetting(this SettingElementCollection collection)
        {
            List<Setting> settingCollection = new List<Setting>();
            if (null != collection)
            {
                foreach (SettingElement settingElm in collection)
                {
                    settingCollection.Add(ToSetting(settingElm));
                }
            }
            return settingCollection;
        }

        public static Setting ToSetting(this SettingElement settingElm)
        {
            Setting setting = new Setting();
            setting.Name = settingElm.Name;
            setting.Value = settingElm.Value;
            return setting;
        }
    }
}
