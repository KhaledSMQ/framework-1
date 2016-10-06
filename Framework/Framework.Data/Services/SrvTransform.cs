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

        public FwDataCluster Convert(Cluster<TUser> elm)
        {
            FwDataCluster ast = new FwDataCluster();
            ast.Name = elm.ID.ToString();
            ast.Contexts = elm.Contexts.Map(__Convert);
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FwDataContext __Convert(Context<TUser> elm)
        {
            FwDataContext ast = new FwDataContext();
            ast.Name = elm.ID.ToString();
            ast.Provider = __Convert(elm.Provider);
            ast.Entities = elm.Entities.Map(__Convert);
            ast.Models = elm.Models.Map(__Convert);
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FwDataEntity __Convert(Entity<TUser> elm)
        {
            FwDataEntity ast = new FwDataEntity();
            ast.Name = elm.ID.ToString();
            ast.Kind = elm.Kind;
            ast.TypeName = elm.TypeName;
            ast.Queries = elm.Queries.Map(__Convert);
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FwDataQuery __Convert(Model.Objects.Query<TUser> elm)
        {
            FwDataQuery ast = new FwDataQuery();
            ast.Name = elm.ID.ToString();
            ast.Kind = elm.Kind;
            ast.Params = elm.Params.Map(__Convert);
            ast.Expression = elm.Expression;
            ast.Callback = elm.Callback;
            return ast;
        }

        private FwDataQueryParam __Convert(QueryParam<TUser> elm)
        {
            FwDataQueryParam ast = new FwDataQueryParam();
            ast.Name = elm.ID.ToString();
            ast.Required = elm.Required;
            ast.Default = elm.Default;
            ast.TypeName = elm.TypeName;
            return ast;
        }

        private FwDataPartialModel __Convert(PartialModel<TUser> elm)
        {
            FwDataPartialModel ast = new FwDataPartialModel();
            ast.TypeName = elm.TypeName;
            ast.Settings = elm.Settings.Map(new List<FwDataSetting>(), __Convert);
            return ast;
        }

        private FwDataProvider __Convert(Provider<TUser> elm)
        {
            FwDataProvider ast = new FwDataProvider();
            ast.TypeName = elm.TypeName;
            ast.Settings = elm.Settings.Map(__Convert);
            return ast;
        }

        private FwDataSetting __Convert(Setting<TUser> elm)
        {
            FwDataSetting ast = new FwDataSetting();
            ast.Name = elm.ID.ToString();
            ast.Value = elm.Value;
            return ast;
        }
    }
}
