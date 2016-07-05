// ============================================================================
// Project: Framework
// Name/Class: SrvTransforms
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform methods.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Data.Model.Config;
using Framework.Data.Model.Import;
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

        public FW_DataCluster Convert(ConfigCluster elm)
        {
            FW_DataCluster ast = new FW_DataCluster();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Contexts = elm.Contexts.Map<ConfigContext, FW_DataContext>(new List<FW_DataContext>(), __Convert);
            ast.Entities = elm.Entities.Map<ConfigEntity, FW_DataEntity>(new List<FW_DataEntity>(), __Convert);
            ast.Models = elm.Models.Map<ConfigModel, FW_DataPartialModel>(new List<FW_DataPartialModel>(), __Convert);
            ast.Settings = elm.Settings.Map<ConfigSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataContext __Convert(ConfigContext elm)
        {
            FW_DataContext ast = new FW_DataContext();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Provider = __Convert(elm.Provider);
            ast.Entities = elm.Entities.Map<ConfigEntityRef, FW_DataEntityRef>(new List<FW_DataEntityRef>(), __Convert);
            ast.Models = elm.Models.Map<ConfigModelRef, FW_DataPartialModelRef>(new List<FW_DataPartialModelRef>(), __Convert);
            return ast;
        }

        private FW_DataEntityRef __Convert(ConfigEntityRef elm)
        {
            FW_DataEntityRef ast = new FW_DataEntityRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<ConfigSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataPartialModelRef __Convert(ConfigModelRef elm)
        {
            FW_DataPartialModelRef ast = new FW_DataPartialModelRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<ConfigSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataEntity __Convert(ConfigEntity elm)
        {
            FW_DataEntity ast = new FW_DataEntity();
            ast.Name = elm.Name;
            ast.Kind = elm.Kind;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Queries = elm.Queries.Map<ConfigQuery, FW_DataQuery>(new List<FW_DataQuery>(), __Convert);
            ast.Settings = elm.Settings.Map<ConfigSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataQuery __Convert(ConfigQuery elm)
        {
            FW_DataQuery ast = new FW_DataQuery();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Kind = elm.Kind;
            ast.Params = elm.Params.Map<ConfigQueryParam, FW_DataQueryParam>(new List<FW_DataQueryParam>(), __Convert);
            ast.Expression = elm.Expression;
            ast.Callback = elm.Callback;
            return ast;
        }

        private FW_DataQueryParam __Convert(ConfigQueryParam elm)
        {
            FW_DataQueryParam ast = new FW_DataQueryParam();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Required = elm.Required;
            ast.Default = elm.Default;
            ast.TypeName = elm.Type;
            return ast;
        }

        private FW_DataPartialModel __Convert(ConfigModel elm)
        {
            FW_DataPartialModel ast = new FW_DataPartialModel();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<ConfigSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataProvider __Convert(ConfigProvider elm)
        {
            FW_DataProvider ast = new FW_DataProvider();
            ast.TypeName = elm.Type;
            ast.Settings = elm.Settings.Map<ConfigSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataSetting __Convert(ConfigSetting elm)
        {
            FW_DataSetting ast = new FW_DataSetting();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Value = elm.Value;
            return ast;
        }

        //
        // IMPORT OBJECT ==> SCHEMA OBJECT
        //

        public FW_DataCluster Convert(ImportCluster elm)
        {
            FW_DataCluster ast = new FW_DataCluster();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Contexts = elm.Contexts.Map<ImportContext, FW_DataContext>(new List<FW_DataContext>(), __Convert);
            ast.Entities = elm.Entities.Map<ImportEntity, FW_DataEntity>(new List<FW_DataEntity>(), __Convert);
            ast.Models = elm.Models.Map<ImportPartialModel, FW_DataPartialModel>(new List<FW_DataPartialModel>(), __Convert);
            ast.Settings = elm.Settings.Map<ImportSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataContext __Convert(ImportContext elm)
        {
            FW_DataContext ast = new FW_DataContext();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Provider = __Convert(elm.Provider);
            ast.Entities = elm.Entities.Map<ImportEntityRef, FW_DataEntityRef>(new List<FW_DataEntityRef>(), __Convert);
            ast.Models = elm.Models.Map<ImportPartialModelRef, FW_DataPartialModelRef>(new List<FW_DataPartialModelRef>(), __Convert);
            return ast;
        }

        private FW_DataEntityRef __Convert(ImportEntityRef elm)
        {
            FW_DataEntityRef ast = new FW_DataEntityRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<ImportSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataPartialModelRef __Convert(ImportPartialModelRef elm)
        {
            FW_DataPartialModelRef ast = new FW_DataPartialModelRef();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Settings = elm.Settings.Map<ImportSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataEntity __Convert(ImportEntity elm)
        {
            FW_DataEntity ast = new FW_DataEntity();
            ast.Name = elm.Name;
            ast.Kind = elm.Kind;
            ast.Description = elm.Description;
            ast.TypeName = elm.TypeName;
            ast.Queries = elm.Queries.Map<ImportQuery, FW_DataQuery>(new List<FW_DataQuery>(), __Convert);
            ast.Settings = elm.Settings.Map<ImportSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataQuery __Convert(ImportQuery elm)
        {
            FW_DataQuery ast = new FW_DataQuery();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Kind = elm.Kind;
            ast.Params = elm.Params.Map<ImportQueryParam, FW_DataQueryParam>(new List<FW_DataQueryParam>(), __Convert);
            ast.Expression = elm.Expression;
            ast.Callback = elm.Callback;
            return ast;
        }

        private FW_DataQueryParam __Convert(ImportQueryParam elm)
        {
            FW_DataQueryParam ast = new FW_DataQueryParam();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Required = elm.Required;
            ast.Default = elm.Default;
            ast.TypeName = elm.TypeName;
            return ast;
        }

        private FW_DataPartialModel __Convert(ImportPartialModel elm)
        {
            FW_DataPartialModel ast = new FW_DataPartialModel();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.TypeName = elm.TypeName;
            ast.Settings = elm.Settings.Map<ImportSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataProvider __Convert(ImportProvider elm)
        {
            FW_DataProvider ast = new FW_DataProvider();
            ast.TypeName = elm.TypeName;
            ast.Settings = elm.Settings.Map<ImportSetting, FW_DataSetting>(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataSetting __Convert(ImportSetting elm)
        {
            FW_DataSetting ast = new FW_DataSetting();
            ast.Name = elm.Name;
            ast.Description = elm.Description;
            ast.Value = elm.Value;
            return ast;
        }

    }
}
