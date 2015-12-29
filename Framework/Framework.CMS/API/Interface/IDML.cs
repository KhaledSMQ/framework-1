// ============================================================================
// Project: Framework
// Name/Class: IDML
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description: (DML) Data manipulation layer interface.
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.CMS.Api.Interface
{
    public interface IDML : ICommon
    {
        object Create<T>(T item, IWrapperDataSet<T> srv);

        T Get<T>(Func<IQueryable<T>, IQueryable<T>> query, IWrapperDataSet<T> srv);

        IEnumerable<T> GetList<T>(Func<IQueryable<T>, IQueryable<T>> query, IWrapperDataSet<T> srv);

        object Update<T>(T item, IWrapperDataSet<T> srv);

        object Delete<T>(T item, IWrapperDataSet<T> srv);

    }
}
