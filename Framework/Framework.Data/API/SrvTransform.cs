// ============================================================================
// Project: Framework
// Name/Class: SrvTransforms
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Transform methods.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Data.Model.Config;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Data.API
{
    public class SrvTransform : ACommon, ITransform
    {
        //
        // CONFIGURATION OBJECT ==> SCHEMA OBJECT
        //

        public FW_DataDomain Convert(DomainElement elm)
        {
            FW_DataDomain ast = new FW_DataDomain();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Clusters = elm.Contexts.Map<ClusterElement, FW_DataCluster>(new List<FW_DataCluster>(), __Convert);
            return ast;
        }

        private FW_DataCluster __Convert(ClusterElement elm)
        {
            FW_DataCluster ast = new FW_DataCluster();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Contexts = elm.Contexts.Map<ContextElement, FW_DataContext>(new List<FW_DataContext>(), __Convert);
            ast.Entities = elm.Entities.Map<EntityElement, FW_DataEntity>(new List<FW_DataEntity>(), __Convert);
            ast.Models = elm.Models.Map<ModelElement, FW_DataPartialModel>(new List<FW_DataPartialModel>(), __Convert);
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), __Convert);
            return ast;
        }

        private FW_DataContext __Convert(ContextElement elm)
        {
            FW_DataContext ast = new FW_DataContext();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Provider = __Convert(elm.Provider);
            ast.Entities = elm.Entities.Map<EntityRefElement, FW_DataEntityRef>(new List<FW_DataEntityRef>(), __Convert);
            ast.Models = elm.Models.Map<ModelRefElement, FW_DataPartialModelRef>(new List<FW_DataPartialModelRef>(), __Convert);
            return ast;
        }

        private FW_DataEntityRef __Convert(EntityRefElement elm)
        {
            FW_DataEntityRef ast = new FW_DataEntityRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), __Convert);
            return ast;
        }

        private FW_DataPartialModelRef __Convert(ModelRefElement elm)
        {
            FW_DataPartialModelRef ast = new FW_DataPartialModelRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), __Convert);
            return ast;
        }

        private FW_DataEntity __Convert(EntityElement elm)
        {
            FW_DataEntity ast = new FW_DataEntity();
            ast.Name = elm.Name;
            ast.Kind = elm.Kind;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Queries = elm.Queries.Map<QueryElement, FW_DataQuery>(new List<FW_DataQuery>(), __Convert);
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), __Convert);
            return ast;
        }

        private FW_DataQuery __Convert(QueryElement elm)
        {
            FW_DataQuery ast = new FW_DataQuery();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Kind = elm.Kind;
            ast.Params = elm.Params.Map<QueryParamElement, FW_DataQueryParam>(new List<FW_DataQueryParam>(), __Convert);
            ast.Expression = elm.Expression;
            ast.Callback = elm.Callback;
            return ast;
        }

        private FW_DataQueryParam __Convert(QueryParamElement elm)
        {
            FW_DataQueryParam ast = new FW_DataQueryParam();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Required = elm.Required;
            ast.Default = elm.Default;
            ast.TypeName = elm.Type;
            return ast;
        }

        private FW_DataPartialModel __Convert(ModelElement elm)
        {
            FW_DataPartialModel ast = new FW_DataPartialModel();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), __Convert);
            return ast;
        }

        private FW_DataProvider __Convert(ProviderElement elm)
        {
            FW_DataProvider ast = new FW_DataProvider();
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<SettingElement, Setting>(new List<Setting>(), __Convert);
            return ast;
        }

        private Setting __Convert(SettingElement elm)
        {
            Setting ast = new Setting();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Value = elm.Value;
            return ast;
        }
    }
}
