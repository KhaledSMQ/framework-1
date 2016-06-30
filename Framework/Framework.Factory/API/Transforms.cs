// ============================================================================
// Project: Framework
// Name/Class: Transforms
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Factory.Model.Schema;
using Framework.Factory.Model.Config;
using System.Collections.Generic;

namespace Framework.Factory.API
{
    public static class Transforms
    {
        //
        // SERVICE
        //
      
        public static ServiceEntry Converter(this ServiceElement elm)
        {
            ServiceEntry service = new ServiceEntry();
            service.Unique = elm.Unique;
            service.Name = elm.Name;
            service.Description = elm.Description;
            service.Contract = elm.Contract;
            service.TypeName = elm.Type;
            service.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return service;
        }

        //
        // SETTING
        //     

        public static Setting Converter(this SettingElement elm)
        {
            Setting ast = new Setting();
            ast.Name = elm.Name;
            ast.Value = elm.Value;
            return ast;
        }
    }
}
