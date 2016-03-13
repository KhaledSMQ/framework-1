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

namespace Framework.CMS.API
{
    public interface IDML : ICommon
    {
        object Create<T>(T item, IDataSet<T> srv);

        T Get<T>(Func<IQueryable<T>, IQueryable<T>> query, IDataSet<T> srv);

        IEnumerable<T> GetList<T>(Func<IQueryable<T>, IQueryable<T>> query, IDataSet<T> srv);

        object Update<T>(T item, IDataSet<T> srv);

        object Delete<T>(T item, IDataSet<T> srv);

    }
}
