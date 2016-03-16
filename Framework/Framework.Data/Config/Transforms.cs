// ============================================================================
// Project: Framework
// Name/Class: Transforms
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Data.Model.Schema;
using System.Collections.Generic;

namespace Framework.Data.Config
{
    public static class Transforms
    {
        //
        // DOMAIN
        //

        public static DataDomain Converter(this DomainElement elm)
        {
            DataDomain ast = new DataDomain();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Clusters = elm.Contexts.Map<ClusterElement, DataCluster>(new List<DataCluster>(), Converter);
            return ast;
        }

        //
        // CLUSTER
        //

        public static DataCluster Converter(this ClusterElement elm)
        {
            DataCluster ast = new DataCluster();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Contexts = elm.Contexts.Map<ContextElement, DataContext>(new List<DataContext>(), Converter);
            ast.Entities = elm.Entities.Map<EntityElement, DataEntity>(new List<DataEntity>(), Converter);
            ast.Models = elm.Models.Map<ModelElement, DataPartialModel>(new List<DataPartialModel>(), Converter);
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // CONTEXT
        //

        public static DataContext Converter(this ContextElement elm)
        {
            DataContext ast = new DataContext();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Provider = elm.Provider.Converter();
            ast.Entities = elm.Entities.Map<EntityRefElement, DataEntityRef>(new List<DataEntityRef>(), Converter);
            ast.Models = elm.Models.Map<ModelRefElement, DataPartialModelRef>(new List<DataPartialModelRef>(), Converter);
            return ast;
        }

        //
        // ENTITY-REF
        // 

        public static DataEntityRef Converter(this EntityRefElement elm)
        {
            DataEntityRef ast = new DataEntityRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // MODEL-REF
        // 

        public static DataPartialModelRef Converter(this ModelRefElement elm)
        {
            DataPartialModelRef ast = new DataPartialModelRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // ENTITY
        //

        public static DataEntity Converter(this EntityElement elm)
        {
            DataEntity ast = new DataEntity();
            ast.Name = elm.Name;
            ast.Kind = elm.Kind;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // PARTIAL-MODEL
        //     

        public static DataPartialModel Converter(this ModelElement elm)
        {
            DataPartialModel ast = new DataPartialModel();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // PROVIDER
        //     

        public static DataProvider Converter(this ProviderElement elm)
        {
            DataProvider ast = new DataProvider();
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // SETTING
        //

        public static Setting Converter(this SettingElement elm)
        {
            Setting ast = new Setting();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Value = elm.Value;
            return ast;
        }
    }
}
