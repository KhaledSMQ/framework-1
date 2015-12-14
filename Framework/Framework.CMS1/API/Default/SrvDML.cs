// ============================================================================
// Project: Toolkit Apps 
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 16/Mar/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Toolkit.Apps.Web.Framework.Config;
using Toolkit.Apps.Web.Framework.Context;
using Toolkit.Apps.Web.Framework.Services.Default;
using Toolkit.Apps.Web.Framework.Services.Interface;
using Framework.CMS1.Api.Interface;
using Toolkit.Core.Patterns;

namespace Framework.CMS1.Api.Default
{
    public class SrvDML : ACommon, IDML
    {
        //
        // INITIALIZATION
        //

        public override void Init(CfgService servConfig, CtxObject ownerContext)
        {
            base.Init(servConfig, ownerContext);
        }

        //
        // API
        //         

        public TID Create<T, TID>(T item, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable
        {
            return srv.Create(item, ctx);
        }

        public T Get<T, TID>(Func<IQueryable<T>, IQueryable<T>> query, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable
        {
            return query(srv.Queryable(ctx)).SingleOrDefault();
        }

        public IEnumerable<T> GetList<T, TID>(Func<IQueryable<T>, IQueryable<T>> query, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable
        {
            return query(srv.Queryable(ctx)).ToList();
        }

        public TID Update<T, TID>(T item, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable
        {
            return srv.Update(item, ctx);
        }

        public TID Delete<T, TID>(T item, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable
        {
            return srv.Delete(item, ctx);
        }
    }
}
