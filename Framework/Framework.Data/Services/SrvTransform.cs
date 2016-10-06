// ============================================================================
// Project: Framework
// Name/Class: SrvTransform
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Jul/2016
// Company: Coop4Creativity
// Description: Transform methods.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Model.Objects;
using Framework.Data.Model.Relational;
using System.Collections.Generic;
using Framework.Core.Patterns;
using Framework.Data.Api;

namespace Framework.Data.Services
{
    public class SrvTransform<TUser> : ACommon, ITransform<TUser>
    {
        //
        // OBJECT ==> RELATIONAL OBJECT
        //

        public FW_DataCluster Convert(Cluster<TUser> elm)
        {
            FW_DataCluster ast = new FW_DataCluster();
            ast.Name = elm.ID.ToString();
            ast.Contexts = elm.Contexts.Map(__Convert);
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FW_DataContext __Convert(Context<TUser> elm)
        {
            FW_DataContext ast = new FW_DataContext();
            ast.Name = elm.ID.ToString();
            ast.Provider = __Convert(elm.Provider);
            ast.Entities = elm.Entities.Map(__Convert);
            ast.Models = elm.Models.Map(__Convert);
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FW_DataEntity __Convert(Entity<TUser> elm)
        {
            FW_DataEntity ast = new FW_DataEntity();
            ast.Name = elm.ID.ToString();
            ast.Kind = elm.Kind;
            ast.TypeName = elm.TypeName;
            ast.Queries = elm.Queries.Map(__Convert);
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FW_DataQuery __Convert(Model.Objects.Query<TUser> elm)
        {
            FW_DataQuery ast = new FW_DataQuery();
            ast.Name = elm.ID.ToString();
            ast.Kind = elm.Kind;
            ast.Params = elm.Params.Map(__Convert);
            ast.Expression = elm.Expression;
            ast.Callback = elm.Callback;
            return ast;
        }

        private FW_DataQueryParam __Convert(QueryParam<TUser> elm)
        {
            FW_DataQueryParam ast = new FW_DataQueryParam();
            ast.Name = elm.ID.ToString();
            ast.Required = elm.Required;
            ast.Default = elm.Default;
            ast.TypeName = elm.TypeName;
            return ast;
        }

        private FW_DataPartialModel __Convert(PartialModel<TUser> elm)
        {
            FW_DataPartialModel ast = new FW_DataPartialModel();
            ast.TypeName = elm.TypeName;
            ast.Settings = elm.Settings.Map(new List<FW_DataSetting>(), __Convert);
            return ast;
        }

        private FW_DataProvider __Convert(Provider<TUser> elm)
        {
            FW_DataProvider ast = new FW_DataProvider();
            ast.TypeName = elm.TypeName;
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FW_DataSetting __Convert(Setting<TUser> elm)
        {
            FW_DataSetting ast = new FW_DataSetting();
            ast.Name = elm.ID.ToString();
            ast.Value = elm.Value;
            return ast;
        }
    }
}
