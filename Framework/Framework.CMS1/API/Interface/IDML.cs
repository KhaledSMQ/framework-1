// ============================================================================
// Project: Toolkit Apps
// Name/Class: IDML
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description: (DML) Data manipulation layer interface.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using Toolkit.Apps.Web.Framework.Services.Interface;
using Toolkit.Core.Patterns;

namespace Framework.CMS1.Api.Interface
{
    public interface IDML : ICommon
    {
        TID Create<T, TID>(T item, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable;

        T Get<T, TID>(Func<IQueryable<T>, IQueryable<T>> query, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable;

        IEnumerable<T> GetList<T, TID>(Func<IQueryable<T>, IQueryable<T>> query, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable;

        TID Update<T, TID>(T item, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable;

        TID Delete<T, TID>(T item, IContextObjectSourceWrapper<T, TID> srv, object ctx)
            where T : IID<TID>
            where TID : IComparable;

    }
}
