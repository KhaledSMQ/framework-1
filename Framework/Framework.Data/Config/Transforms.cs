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

        public static FW_DataDomain Converter(this DomainElement elm)
        {
            FW_DataDomain ast = new FW_DataDomain();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Clusters = elm.Contexts.Map<ClusterElement, FW_DataCluster>(new List<FW_DataCluster>(), Converter);
            return ast;
        }

        //
        // CLUSTER
        //

        public static FW_DataCluster Converter(this ClusterElement elm)
        {
            FW_DataCluster ast = new FW_DataCluster();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Contexts = elm.Contexts.Map<ContextElement, FW_DataContext>(new List<FW_DataContext>(), Converter);
            ast.Entities = elm.Entities.Map<EntityElement, FW_DataEntity>(new List<FW_DataEntity>(), Converter);
            ast.Models = elm.Models.Map<ModelElement, FW_DataPartialModel>(new List<FW_DataPartialModel>(), Converter);
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // CONTEXT
        //

        public static FW_DataContext Converter(this ContextElement elm)
        {
            FW_DataContext ast = new FW_DataContext();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Provider = elm.Provider.Converter();
            ast.Entities = elm.Entities.Map<EntityRefElement, FW_DataEntityRef>(new List<FW_DataEntityRef>(), Converter);
            ast.Models = elm.Models.Map<ModelRefElement, FW_DataPartialModelRef>(new List<FW_DataPartialModelRef>(), Converter);
            return ast;
        }

        //
        // ENTITY-REF
        // 

        public static FW_DataEntityRef Converter(this EntityRefElement elm)
        {
            FW_DataEntityRef ast = new FW_DataEntityRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // MODEL-REF
        // 

        public static FW_DataPartialModelRef Converter(this ModelRefElement elm)
        {
            FW_DataPartialModelRef ast = new FW_DataPartialModelRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // ENTITY
        //

        public static FW_DataEntity Converter(this EntityElement elm)
        {
            FW_DataEntity ast = new FW_DataEntity();
            ast.Name = elm.Name;
            ast.Kind = elm.Kind;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Queries = elm.Queries.Map<QueryElement, FW_DataQuery>(new List<FW_DataQuery>(), Converter);
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // QUERY
        //

        public static FW_DataQuery Converter(this QueryElement elm)
        {
            FW_DataQuery ast = new FW_DataQuery();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Kind = elm.Kind;
            ast.Params = elm.Params.Map<QueryParamElement, FW_DataQueryParam>(new List<FW_DataQueryParam>(), Converter);
            ast.Expression = elm.Expression;
            ast.Callback = elm.Callback;
            return ast;
        }

        //
        // QUERY-PARAM
        //

        public static FW_DataQueryParam Converter(this QueryParamElement elm)
        {
            FW_DataQueryParam ast = new FW_DataQueryParam();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Required = elm.Required;
            ast.Default = elm.Default;
            ast.TypeName = elm.Type;
            return ast;
        }

        //
        // PARTIAL-MODEL
        //     

        public static FW_DataPartialModel Converter(this ModelElement elm)
        {
            FW_DataPartialModel ast = new FW_DataPartialModel();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), Converter);
            return ast;
        }

        //
        // PROVIDER
        //     

        public static FW_DataProvider Converter(this ProviderElement elm)
        {
            FW_DataProvider ast = new FW_DataProvider();
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
