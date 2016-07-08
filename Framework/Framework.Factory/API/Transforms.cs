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
using Framework.Factory.Config;

namespace Framework.Factory.API
{
    public static class Transforms
    {
        //
        // SERVICE
        //
      
        public static FW_FactoryServiceEntry Converter(this ServiceElement elm)
        {
            FW_FactoryServiceEntry service = new FW_FactoryServiceEntry();
            service.Unique = elm.Unique;
            service.Name = elm.Name;
            service.Description = elm.Description;
            service.Contract = elm.Contract;
            service.TypeName = elm.Type;
            service.Settings = elm.Settings.Map<SettingElement, FW_FactorySetting>(new List<FW_FactorySetting>(), Converter);
            return service;
        }

        //
        // SETTING
        //     

        public static FW_FactorySetting Converter(this SettingElement elm)
        {
            FW_FactorySetting ast = new FW_FactorySetting();
            ast.Name = elm.Name;
            ast.Value = elm.Value;
            return ast;
        }

        //
        // STARTUP-SEQUENCE
        //

        public static IEnumerable<MethodCall> ToSequence(this MethodCallElementCollection lst)
        {
            List<MethodCall> output = new List<MethodCall>();
            foreach (MethodCallElement elm in lst) { output.Add(elm.ToSequence()); }
            return output;
        }

        public static MethodCall ToSequence(this MethodCallElement elm)
        {
            MethodCall output = new MethodCall();
            output.Service = elm.Service;
            output.Method = elm.Method;
            return output;
        }
    }
}
